using Mpv.NET.Player;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.Functions
{
    public delegate void AnimationCompletedHandler();
    public static class VideoManipulation
    {
        public static void ZoomVideo(MpvPlayer player, double zoomStep)
        {
            int increment = zoomStep > 0 ? 1 : -1;
            if (CommandSettings.Instance.IncrementZoomCounter(increment)) return;

            player.ZoomVideo(zoomStep);
        }

        public static void PanVideo(MpvPlayer player, double panStep, bool horizontal)
        {
            int increment = panStep > 0 ? 1 : -1;

            if (horizontal)
            {
                if (CommandSettings.Instance.IncrementPanCounterHorizontal(increment)) return;
                player.PanVideoHorizontal(panStep);
            }
            else
            {
                if (CommandSettings.Instance.IncrementPanCounterVertical(increment)) return;
                player.PanVideoVertical(panStep);
            }
        }

        public static void ScaleVideo(MpvPlayer player, double scaleStep, bool horizontal)
        {
            int increment = scaleStep > 0 ? 1 : -1;

            if (horizontal)
            {
                if (CommandSettings.Instance.IncrementScaleCounterHorizontal(increment)) return;
                player.ScaleVideoHoriztonal(scaleStep);
            }
            else
            {
                if (CommandSettings.Instance.IncrementScaleCounterVertical(increment)) return;
                player.ScaleVideoVertical(scaleStep);
            }
        }

        public static void RotateVideo(MpvPlayer player, int rotateFactor, bool absolute)
        {
            player.RotateVideo(rotateFactor, absolute);
        }
        public static void AutoFillVideoHorizontally(MpvPlayer player, bool alignHorizontally)
        {
            player.Panscan(alignHorizontally);
        }

        public static void ResetVideoManipulation(MpvPlayer player)
        {
            //Reset zoom factor
            CommandSettings.Instance.ZoomCounter = 0;
            player.ZoomVideo(0, true);
            //Reset pan factors
            CommandSettings.Instance.PanCounterHorizonal = 0;
            CommandSettings.Instance.PanCounterVertical = 0;
            player.PanVideoHorizontal(0, true);
            player.PanVideoVertical(0, true);
            //Reset panscan
            player.Panscan(false);
            //Reset scale factors
            player.ScaleVideoHoriztonal(1, true);
            player.ScaleVideoVertical(1, true);
            //Reset rotation
            player.RotateVideo(0, true);
            //Reset alignment
            player.VideoAlign("Center");
        }


        public static void ChangePlaybackSpeed(MpvPlayer player, Form f, Control ctrl, Speed action)
        {
            if (action == Speed.Reset)
            {
                ThreadHelper.SetText(f, ctrl, "");
                player.Speed = 1.0;
                return;
            }

            double[] playbackSpeeds = { 0.125, 0.25, 0.5, 0.75, 1.0, 1.2, 1.5, 2.0, 4.0 };
            string[] playbackSpeedStrings = { "0.125", "0.25", "0.5", "0.75", "1.0", "1.2", "1.5", "2.0", "4.0" }; //Because I couldn't figure another way to display the values as is

            double currentSpeed = player.Speed;

            int currentIndex = Array.IndexOf(playbackSpeeds, currentSpeed);

            if (currentIndex == -1)
            {
                currentIndex = Array.IndexOf(playbackSpeeds, 1.0);
            }

            if (action == Speed.Increase)
            {
                currentIndex = Math.Min(currentIndex + 1, playbackSpeeds.Length - 1);
            }
            else if (action == Speed.Decrease)
            {
                currentIndex = Math.Max(currentIndex - 1, 0);
            }

            player.Speed = playbackSpeeds[currentIndex];

            ThreadHelper.SetText(f, ctrl, $"x{playbackSpeedStrings[currentIndex]} -");
        }

        public enum Speed
        {
            Increase,
            Decrease,
            Reset
        }


        #region Effect paramter
        private static System.Timers.Timer _animationTimer;
        private static double _startZoom, _endZoom;
        private static double _startPanX, _endPanX;
        private static double _startPanY, _endPanY;
        private static double _duration;
        private static double _elapsedTime;
        private static int TimerInterval = 2;
        private static Func<double, double> _easingFunction;
        private static bool _resetAfter;
        private static AnimationCompletedHandler _onAnimationCompleted;
        private static int selectedZoomEasingFunction { get; set; } = (int)EasingMethods.Linear;
        private static int selectedPanEasingFunction { get; set; } = (int)EasingMethods.Linear;
        #endregion

        private static double zoomAmount = 0.5;
        private static double zoomDuration = 4000;
        private static double panAmount = 0.2; //Distance to move video
        private static double panDuration = 8000;


        private static AnimationType _animationType;
        private static Random _random = new Random();
        public static void KenBurnsEffectInitializeTimer(MpvPlayer player)
        {
            _animationTimer = new System.Timers.Timer(TimerInterval);
            _animationTimer.Elapsed += (sender, e) => effectTimer_Tick(sender, e, player);
        }

        public static void KenBurnsEffectUpdateSettings()
        {
            zoomAmount = SettingsHandler.ZoomAmount;
            zoomDuration = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
            panAmount = SettingsHandler.PanAmount;
            panDuration = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
            selectedZoomEasingFunction = SettingsHandler.ZoomEasingFunction;
            selectedPanEasingFunction = SettingsHandler.PanEasingFunction;
        }

        private static Func<double, double> GetZoomEasingFunction()
        {
            return selectedZoomEasingFunction switch
            {
                (int)EasingMethods.Linear => Easing.Linear,
                (int)EasingMethods.EaseInQuad => Easing.EaseInQuad,
                (int)EasingMethods.EaseOutQuad => Easing.EaseOutQuad,
                (int)EasingMethods.EaseInOutQuad => Easing.EaseInOutQuad,
                (int)EasingMethods.EaseOutBack => Easing.EaseOutBack,
                _ => Easing.Linear,
            };
        }

        private static Func<double, double> GetPanEasingFunction()
        {
            return selectedPanEasingFunction switch
            {
                (int)EasingMethods.Linear => Easing.Linear,
                (int)EasingMethods.EaseInQuad => Easing.EaseInQuad,
                (int)EasingMethods.EaseOutQuad => Easing.EaseOutQuad,
                (int)EasingMethods.EaseInOutQuad => Easing.EaseInOutQuad,
                (int)EasingMethods.EaseOutBack => Easing.EaseOutBack,
                _ => Easing.Linear,
            };
        }

        public static void StartRandomAnimation(MpvPlayer player, AnimationCompletedHandler onAnimationCompleted = null)
        {
            int randomIndex = SettingsHandler.SelectedAnimations.Count > 0 ? _random.Next(SettingsHandler.SelectedAnimations.Count) : _random.Next(3);
            int animationType = SettingsHandler.SelectedAnimations[randomIndex]; // 0: Zoom, 1: PanHorizontal, 2: PanVertical
            double direction = _random.Next(2) == 0 ? 1 : -1; //Randomize direction of paning
            double preZoomFactor = 0.3; // Only used to pre-zoom before paning

            var zoomEasingFunction = GetZoomEasingFunction();
            var panEasingFunction = GetPanEasingFunction();

            switch (animationType)
            {
                case 0:
                    player.VideoAlign("Center");
                    StartZoomAnimation(0, zoomAmount, zoomDuration, zoomEasingFunction, true, onAnimationCompleted); 
                    break;
                case 1: //Horizontal
                    double panStartX = -direction * panAmount / 2;
                    double panEndX = direction * panAmount / 2;
                    player.VideoAlign("Top");
                    StartZoomAndPanAnimation(preZoomFactor, panStartX, panEndX, true, panDuration, panEasingFunction, onAnimationCompleted); 
                    break;
                case 2: //Vertical
                    double panStartY = -direction * panAmount / 2;
                    double panEndY = direction * panAmount / 2;
                    player.VideoAlign("Center");
                    StartZoomAndPanAnimation(preZoomFactor, panStartY, panEndY, false, panDuration, panEasingFunction, onAnimationCompleted); 
                    break;
            }
        }
        private static void StartZoomAndPanAnimation(double preZoomFactor, double panStart, double panEnd, bool isHorizontal, double duration, Func<double, double> easingFunction, AnimationCompletedHandler onAnimationCompleted = null)
        {
            // First, zoom in slightly
            StartZoomAnimation(0, preZoomFactor, 100, Easing.Linear, false, () =>
            {
                if (isHorizontal)
                {                    
                    StartPanHorizontalAnimation(panStart, panEnd, duration / 2, easingFunction, true, onAnimationCompleted);
                }
                else
                {
                    StartPanVerticalAnimation(panStart, panEnd, duration / 2, easingFunction, true, onAnimationCompleted);
                }
            });
        }
        public static void StartZoomAnimation(double startZoom, double endZoom, double duration, Func<double, double> easingFunction, bool resetAfter = false, AnimationCompletedHandler onAnimationCompleted = null)
        {
            _startZoom = startZoom;
            _endZoom = endZoom;
            _duration = duration;
            _elapsedTime = 0;
            _easingFunction = easingFunction;
            _resetAfter = resetAfter;
            _onAnimationCompleted = onAnimationCompleted;

            _animationType = AnimationType.Zoom;
            _animationTimer.Start();
        }
        private static void StartPanHorizontalAnimation(double startPan, double endPan, double duration, Func<double, double> easingFunction, bool resetAfter = false, AnimationCompletedHandler onAnimationCompleted = null)
        {
            _startPanX = startPan;
            _endPanX = endPan;
            _duration = duration;
            _elapsedTime = 0;
            _easingFunction = easingFunction;
            _resetAfter = resetAfter;
            _onAnimationCompleted = onAnimationCompleted;

            _animationType = AnimationType.PanHorizontal;
            _animationTimer.Start();
        }

        private static void StartPanVerticalAnimation(double startPan, double endPan, double duration, Func<double, double> easingFunction, bool resetAfter = false, AnimationCompletedHandler onAnimationCompleted = null)
        {
            _startPanY = startPan;
            _endPanY = endPan;
            _duration = duration;
            _elapsedTime = 0;
            _easingFunction = easingFunction;
            _resetAfter = resetAfter;
            _onAnimationCompleted = onAnimationCompleted;

            _animationType = AnimationType.PanVertical;
            _animationTimer.Start();
        }
        public static void KenBurnsEffectStop()
        {
            _animationTimer.Stop();
        }

        private static void effectTimer_Tick(object sender, EventArgs e, MpvPlayer player)
        {
            _elapsedTime += TimerInterval;

            double t = _elapsedTime / _duration;
            if (t > 1) t = 1;

            double easedT = _easingFunction(t);

            switch (_animationType)
            {
                case AnimationType.Zoom:
                    double currentZoom = _startZoom + (easedT * (_endZoom - _startZoom));
                    player.ScaleVideoHoriztonal(1 + currentZoom, true);
                    player.ScaleVideoVertical(1 + currentZoom, true);
                    break;
                case AnimationType.PanHorizontal:
                    double currentPanX = _startPanX + (easedT * (_endPanX - _startPanX));
                    player.PanVideoHorizontal(currentPanX, true);
                    break;
                case AnimationType.PanVertical:
                    double currentPanY = _startPanY + (easedT * (_endPanY - _startPanY));
                    player.PanVideoVertical(currentPanY, true);
                    break;
            }

            if (t >= 1)
            {
                _animationTimer.Stop();
                if (_resetAfter)
                {                                      
                    switch (_animationType)
                    {
                        case AnimationType.Zoom:
                            StartZoomAnimation(_endZoom, 0, 200, Easing.EaseOutQuad, false, _onAnimationCompleted); // Reset to default zoom quickly
                            break;
                        case AnimationType.PanHorizontal:
                            StartPanHorizontalAnimation(_endPanX, 0, 200, Easing.EaseOutQuad, false, _onAnimationCompleted); // Reset to default pan quickly
                            break;
                        case AnimationType.PanVertical:
                            StartPanVerticalAnimation(_endPanY, 0, 200, Easing.EaseOutQuad, false, _onAnimationCompleted); // Reset to default pan quickly
                            break;
                    }
                }
                else
                {
                    Thread.Sleep(50);
                    _onAnimationCompleted?.Invoke();
                }
            }
        }
        private enum AnimationType
        {
            Zoom,
            PanHorizontal,
            PanVertical
        }
    }
}
