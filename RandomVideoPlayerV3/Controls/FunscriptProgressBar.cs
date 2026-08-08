using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class FunscriptProgressBar : Control
    {
        private double _positionMs;
        private int _scriptDurationMs;
        private int _scriptPositionMs;
        public Bitmap? Heatmap { get; set; }
        public double DurationMs { get; set; }



        public int ScriptDurationMs
        {
            get => _scriptDurationMs;
            set
            {
                if (_scriptDurationMs == value)
                    return;

                _scriptDurationMs = value;
                Invalidate(); // Schedules the entire control for repainting
            }
        }
        public int ScriptPositionMs
        {
            get => _scriptPositionMs;
            set
            {
                if (_scriptPositionMs == value)
                    return;

                _scriptPositionMs = value;
                //Invalidate();
            }
        }

        public Color _progressOverlayColor { get; set; } = Color.FromArgb(90, 255, 255, 255);
        public Color _positionIndicatorColor { get; set; } = Color.White;

        private int? _seekValue = null;
        private int _seekIndicatorAlpha = 160;

        public FunscriptProgressBar()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);

            UpdateStyles();

            Cursor = Cursors.Hand;
        }
        public double PositionMs
        {
            get => _positionMs;
            set
            {
                if (Math.Abs(_positionMs - value) < 1)
                    return;

                int oldX = GetPositionX(_positionMs);
                _positionMs = value;
                int newX = GetPositionX(_positionMs);

                InvalidateMarkerArea(oldX);
                InvalidateMarkerArea(newX);
            }
        }
        public Color ProgressOverLayColor
        {
            get => _progressOverlayColor;  
            set
            {
                _progressOverlayColor = value;
                Invalidate();
            }
        }
        public Color PositionIndicatorColor
        {
            get => _positionIndicatorColor;
            set
            {
                _positionIndicatorColor = value;
                Invalidate();
            }
        }

        public int? SeekValue
        {
            get => _seekValue;
            set
            {
                if (value.HasValue)
                {
                    int v = value.Value;
                    if (v > DurationMs) v = (int)DurationMs;
                    else if (v < 0) v = 0;
                    _seekValue = v;
                }
                else
                {
                    _seekValue = null;
                }
                Invalidate();
            }
        }

        public int SeekIndicatorAlpha
        {
            get => _seekIndicatorAlpha;
            set { _seekIndicatorAlpha = Math.Max(0, Math.Min(255, value)); Invalidate(); }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Prevent painting
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            if (Heatmap != null)
            {
                g.DrawImageUnscaled(Heatmap, 0, 0);
            }
            else
            {
                using (var backBrush = new SolidBrush(Color.Black))
                    g.FillRectangle(backBrush, ClientRectangle);
            }

            if (ScriptDurationMs > 0)
            {
                int playX = GetScriptPositionX(ScriptPositionMs);

                using (var markerPen = new Pen(Color.FromArgb(160, Color.Red), 4))
                    g.DrawLine(markerPen, playX, 0, playX, Height);
            }

            if (DurationMs > 0)
            {
                int playX = GetPositionX(PositionMs);

                using (var progressBrush = new SolidBrush(Color.FromArgb(45, _progressOverlayColor)))
                    g.FillRectangle(progressBrush, 0, 0, playX, Height);

                using (var markerPen = new Pen(Color.White, 2))
                    g.DrawLine(markerPen, playX, 0, playX, Height);
            }

            if (_seekValue.HasValue && DurationMs > 0)
            {
                int seekX = GetPositionX(_seekValue.Value);
                int progressWidth = GetPositionX(PositionMs);

                int left = Math.Min(progressWidth, seekX);
                int right = Math.Max(progressWidth, seekX);
                int bandWidth = Math.Max(right - left, 1);

                bool seekingForward = seekX >= progressWidth;

                using (var band = new SolidBrush(Color.FromArgb(90, _progressOverlayColor)))
                    g.FillRectangle(band, left, 0, bandWidth, Height);

                using (var marker = new Pen(Color.FromArgb(_seekIndicatorAlpha, _positionIndicatorColor), 2))
                    g.DrawLine(marker, seekX, 0, seekX, Height);
            }
        }

        private int GetPositionX(double timeMs)
        {
            if (DurationMs <= 0 || Width <= 0)
                return 0;

            double progress = timeMs / DurationMs;
            progress = Math.Max(0, Math.Min(1, progress));

            return (int)Math.Round(progress * Width);
        }

        private int GetScriptPositionX(double timeMs)
        {
            if(ScriptDurationMs <= 0 || Width <= 0)
                return 0;
            double progress = timeMs / ScriptDurationMs;
            progress = Math.Max(0, Math.Min(1, progress));
            return (int)Math.Round(progress * Width);
        }

        private void InvalidateMarkerArea(int x)
        {
            const int padding = 5;

            Invalidate(new Rectangle(
                x - padding,
                0,
                padding * 2 + 1,
                Height));
        }
    }
}
