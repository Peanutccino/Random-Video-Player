using Mpv.NET.Player;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Timer = System.Windows.Forms.Timer;

namespace RandomVideoPlayer.Functions
{
    public sealed class VrController
    {
        private readonly MpvPlayer _mpv;

        public bool Enabled { get; private set; }

        public VrInputProjection InputProjection { get; set; } = VrInputProjection.HalfEquirectangular;
        public string OutputProjection { get; set; } = "flat"; //flat

        public VrInputStereo InputStereo { get; set; } = VrInputStereo.SideBySide;   // sbs or tb
        public string OutputStereo { get; set; } = "2d";   // 2d or sbs

        public VrInputFov InputFov { get; set; } = VrInputFov.Fov180;
        public double DisplayFov { get; set; } = 110.0;

        public double Yaw { get; set; } = 0.0;
        public double Pitch { get; set; } = 0.0;
        public double Roll { get; set; } = 0.0;

        public int OutputWidth { get; set; } = 1920;
        public int OutputHeight { get; set; } = 1080;
        public bool FlipEye { get; set; } = false;

        public VrInterpolation Interpolation { get; set; } = VrInterpolation.Linear;

        public VrRenderQuality RenderQuality { get; set; } = VrRenderQuality.Balanced;

        public VrController(MpvPlayer mpv)
        {
            _mpv = mpv;
            SetupVrTimer();
        }

        private readonly Timer vrUpdateTimer = new Timer();
        private bool _vrUpdatePending;
        private bool _vrUpdateInProgress;
        private bool _runtimeCommandsFailed;
        private double _lastAppliedYaw = double.NaN;
        private double _lastAppliedPitch = double.NaN;
        private double _lastAppliedRoll = double.NaN;
        private double _lastAppliedDisplayFov = double.NaN;
        private int _normalOutputWidth;
        private int _normalOutputHeight;
        private bool _interactivePanMode;
        private void SetupVrTimer()
        {
            vrUpdateTimer.Interval = 32;
            vrUpdateTimer.Tick += (s, e) =>
            {
                if (!_vrUpdatePending) return;

                if (_vrUpdateInProgress) return;

                _vrUpdatePending = false;
                _vrUpdateInProgress = true;

                try
                {
                    UpdateViewOnly();
                }
                finally
                {
                    _vrUpdateInProgress = false;
                }
            };
            vrUpdateTimer.Start();
        }

        public void Enable()
        {
            if (Enabled)
                return;

            _mpv.API.Command("set", "hwdec", "no");

            Enabled = true;
            ApplyFilter(add: true);
        }

        public void Disable()
        {
            if (!Enabled)
                return;

            try
            {
                _mpv.API.Command("vf", "remove", "@vrrev");
            }
            catch { }

            Enabled = false;
        }

        public void Update()
        {
            if (!Enabled)
                return;
            Interpolation = SettingsHandler.VrInterpolation;
            ApplyFilter(add: false);
        }
        public void UpdateViewOnly()
        {
            if (!Enabled)
                return;

            if (!ApplyRuntimeViewOptions())
            {
                ApplyFilter(add: false);
            }
        }
        public void ResetView()
        {
            Yaw = 0;
            Pitch = 0;
            Roll = 0;
            Update();
        }

        public void Zoom(double delta)
        {
            DisplayFov += delta;
            DisplayFov = Math.Max(30.0, Math.Min(150.0, DisplayFov));
            _vrUpdatePending = true;
        }

        public void Pan(double yawDelta, double pitchDelta)
        {
            Yaw += yawDelta;
            Pitch += pitchDelta;

            Yaw = Math.Max(-180.0, Math.Min(180.0, Yaw));
            Pitch = Math.Max(-180.0, Math.Min(180.0, Pitch));

            _vrUpdatePending = true;
        }

        private void ApplyFilter(bool add)
        {
            string filter = BuildFilter();

            if (add)
            {
                _mpv.API.Command("vf", "add", filter);
            }
            else
            {
                _mpv.API.Command("vf", "set", filter);
            }

            ResetRuntimeCommandCache();
            _runtimeCommandsFailed = false;
        }

        private string BuildFilter()
        {
            var ci = CultureInfo.InvariantCulture;

            var prefix = GetPrefix();
            var flipMode = GetFlipMode();//FlipEye ? "h_flip=1" : "0";

            return string.Format(
                ci,
                "@vrrev:{0}v360={1}:{2}:in_stereo={3}:out_stereo={4}:id_fov={5}:d_fov={6:F3}:yaw={7:F3}:pitch={8:F3}:roll={9:F3}:w={10}:h={11}:{12}:interp={13}",
                prefix,
                InputProjection.ToMpvValue(),
                OutputProjection,
                InputStereo.ToMpvValue(),
                OutputStereo,
                InputFov.ToMpvValue(),
                DisplayFov,
                Yaw,
                Pitch,
                Roll,
                OutputWidth,
                OutputHeight,
                flipMode,
                Interpolation.ToMpvValue()
            );
        }

        private string GetFlipMode()
        {
            var flipMode = "";
            if(FlipEye && InputStereo == VrInputStereo.SideBySide)
            {
                flipMode = "h_flip=1";
            }
            else if(FlipEye && InputStereo == VrInputStereo.TopBottom)
            {
                flipMode = "v_flip=1";
            }
            else
            {
                flipMode = "h_flip=0";
            }

            return flipMode;
        }

        private string GetPrefix()
        {
            var flipMode = "";
            if (FlipEye && InputStereo == VrInputStereo.SideBySide)
            {
                flipMode = "hflip,";
            }
            else if (FlipEye && InputStereo == VrInputStereo.TopBottom)
            {
                flipMode = "vflip,";
            }

            return flipMode;
        }
        public void BeginInteractivePan()
        {
            if (_interactivePanMode)
                return;

            _interactivePanMode = true;

            _normalOutputWidth = OutputWidth;
            _normalOutputHeight = OutputHeight;

            int targetHeight = 360;

            int panelW = Math.Max(1, OutputWidth);
            int panelH = Math.Max(1, OutputHeight);

            double aspect = panelW / (double)panelH;

            int outH = targetHeight;
            int outW = (int)Math.Round(outH * aspect);

            outW -= outW % 2;
            outH -= outH % 2;


            OutputWidth = Math.Min(OutputWidth, outW);
            OutputHeight = Math.Min(OutputHeight, outH);

            Update(); 
        }

        public void EndInteractivePan()
        {
            if (!_interactivePanMode)
                return;

            _interactivePanMode = false;

            OutputWidth = _normalOutputWidth;
            OutputHeight = _normalOutputHeight;

            Update(); 
        }

        private bool ApplyRuntimeViewOptions()
        {
            bool ok = true;

            if (!NearlyEqual(Yaw, _lastAppliedYaw))
            {
                ok &= TrySetV360RuntimeOption("yaw", Yaw);
                _lastAppliedYaw = Yaw;
            }

            if (!NearlyEqual(Pitch, _lastAppliedPitch))
            {
                ok &= TrySetV360RuntimeOption("pitch", Pitch);
                _lastAppliedPitch = Pitch;
            }

            if (!NearlyEqual(Roll, _lastAppliedRoll))
            {
                ok &= TrySetV360RuntimeOption("roll", Roll);
                _lastAppliedRoll = Roll;
            }

            if (!NearlyEqual(DisplayFov, _lastAppliedDisplayFov))
            {
                ok &= TrySetV360RuntimeOption("d_fov", DisplayFov);
                _lastAppliedDisplayFov = DisplayFov;
            }

            return ok;
        }

        private static bool NearlyEqual(double a, double b)
        {
            if (double.IsNaN(a) || double.IsNaN(b))
                return false;

            return Math.Abs(a - b) < 0.001;
        }
        private void ResetRuntimeCommandCache()
        {
            _lastAppliedYaw = double.NaN;
            _lastAppliedPitch = double.NaN;
            _lastAppliedRoll = double.NaN;
            _lastAppliedDisplayFov = double.NaN;
        }
        private bool TrySetV360RuntimeOption(string name, double value)
        {
            if (_runtimeCommandsFailed)
                return false;

            try
            {
                string valueText = value.ToString("F3", CultureInfo.InvariantCulture);

                _mpv.API.Command("vf-command", "@vrrev", name, valueText);

                return true;
            }
            catch
            {
                _runtimeCommandsFailed = true;
                return false;
            }
        }

        public void ApplyVrQualityPreset(System.Windows.Forms.Control panel)
        {
            int targetHeight;

            switch (RenderQuality)
            {
                case VrRenderQuality.Perfomance:
                    targetHeight = 576;
                    break;

                case VrRenderQuality.Balanced:
                    targetHeight = 720;
                    break;

                case VrRenderQuality.High:
                    targetHeight = 1080;
                    break;

                case VrRenderQuality.Ultra:
                    targetHeight = 1440;
                    break;

                default:
                    targetHeight = 1080;
                    break;
            }

            int panelW = Math.Max(1, panel.ClientSize.Width);
            int panelH = Math.Max(1, panel.ClientSize.Height);

            double aspect = panelW / (double)panelH;

            int outH = targetHeight;
            int outW = (int)Math.Round(outH * aspect);

            outW -= outW % 2;
            outH -= outH % 2;

            OutputWidth = Math.Max(320, outW);
            OutputHeight = Math.Max(180, outH);
        }
    }

    public enum VrRenderQuality
    {
        Perfomance,
        Balanced,
        High,
        Ultra
    }
}
