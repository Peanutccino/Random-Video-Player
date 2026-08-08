using Mpv.NET.Player;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandomVideoPlayer.Functions.FunscriptHeatmapRenderer;

namespace RandomVideoPlayer.Controls
{
    public sealed class SeekPreviewControl : Panel
    {
        private readonly TableLayoutPanel _backgroundPanel;
        private readonly Panel _playerContainer;
        private readonly MpvPlayer _previewPlayer;
        private readonly PictureBox _pictureBox;
        private readonly OverlayLabel _label;

        private double _lastCenterMs = -1;
        private Bitmap? _currentBitmap = null;

        private const int WindowWidth = 230;
        private const int WindowHeight = 182;

        public SeekPreviewControl()
        {
            Width = WindowWidth;
            Height = WindowHeight;

            BackColor = ThemeManager.CurrentTheme.FormBackColor;

            _backgroundPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
            };
            _backgroundPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            _backgroundPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _backgroundPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _backgroundPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.Controls.Add(_backgroundPanel);

            _playerContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Green,
                Height = 130,
                Margin = new Padding(2,2,2,0)
            };
            _backgroundPanel.Controls.Add(_playerContainer, column: 0, row: 0);

            var libMpv = MainFormData.startupPath + "lib\\libmpv-2.dll";
            _previewPlayer = new MpvPlayer(_playerContainer.Handle, libMpv)
            {
                Volume = 0,
                KeepOpen = KeepOpen.Yes
            };
            PlayerInitCommands();


            _pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Height = 30,
                BackColor = Color.Black,
                Margin = new Padding(2, 2, 2, 0)
            };
            _backgroundPanel.Controls.Add(_pictureBox, column: 0, row: 1);

            _label = new OverlayLabel
            {
                Dock = DockStyle.Fill,
                MiddleAlignment = true,
                AutoSize = false,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = ThemeManager.CurrentTheme.TextColor,
                BackColor = this.BackColor,
                Font = new Font("Segoe UI", 9f / DPI.Scale, FontStyle.Bold)
            };
            _backgroundPanel.Controls.Add(_label, column: 0, row: 2);

            DPI.UpdateDPIScaling(this);
        }
        public void LoadPreviewVideo(string videoPath)
        {
            if (SettingsHandler.PreviewSeekBarEnabled)
            {
                _previewPlayer.Load(videoPath, true);
            }
        }
        public void UpdatePreview(Funscript? script, string loadedVideo, double centerMs, double radiusMs, double durationMs, double fallbackCenterMs = 0, VrInputStereo vrType = VrInputStereo.Mono)
        {
            if (Math.Abs(centerMs - _lastCenterMs) < 50)
                return;

            if(fallbackCenterMs <= 0) fallbackCenterMs = centerMs;

            this.BackColor = ThemeManager.CurrentTheme.FormBackColor;

            _lastCenterMs = centerMs;
            var labelOnly = true;
            var playerLoaded = false;
            var imageLoaded = false;

            try
            {
                if (_previewPlayer.IsMediaLoaded && SettingsHandler.PreviewSeekBarEnabled)
                {
                    ApplyPreviewVrEyeCrop(vrType);
                    _previewPlayer.API.Command("seek", (centerMs / 1000.0).ToString(CultureInfo.InvariantCulture), "absolute+keyframes");
                    _previewPlayer.Pause();
                    _playerContainer.Visible = true;
                    playerLoaded = true;
                    labelOnly = false;
                }
                else
                {
                    _playerContainer.Visible = false;
                }
            }
            catch (Exception) { }

            _currentBitmap?.Dispose();
            _currentBitmap = null;
            if (SettingsHandler.PreviewSeekBarGraphEnabled && script != null)
            {
                _currentBitmap = FunscriptHeatmapRenderer.RenderHeatmapWindow(
                                    script,
                                    width: _pictureBox.Width,
                                    height: _pictureBox.Height,
                                    durationMs: durationMs,
                                    centerMs: fallbackCenterMs,
                                    radiusMs: radiusMs,
                                    options: new HeatmapOptions
                                    {
                                        Background = Color.Black,
                                        LineWidth = 2.5f,
                                        ColorSmoothing = 5,
                                        Solid = false
                                    });
            }

            if (_currentBitmap != null)
            {
                _pictureBox.Image = _currentBitmap;
                _pictureBox.Visible = true;

                labelOnly = false;
                imageLoaded = true;
            }
            else
            {
                _pictureBox.Visible = false;

            }


            if (labelOnly)
            {
                this.Height = WindowHeight - _playerContainer.Height - _pictureBox.Height;
                this.Width = 80;
            }
            else
            {
                this.Height = WindowHeight - (imageLoaded ? 0 : _pictureBox.Height) - (playerLoaded ? 0 : _playerContainer.Height);
                this.Width = WindowWidth;
            }

            _label.Text = $"{FormatTimestamp(centerMs)}";
            _label.BackColor = this.BackColor;
            _label.ForeColor = ThemeManager.CurrentTheme.TextColor;
            _label.Refresh();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _currentBitmap?.Dispose();
            }

            base.Dispose(disposing);
        }

        private static string FormatTimestamp(double ms)
        {
            var ts = TimeSpan.FromMilliseconds(ms);

            return ts.ToString(@"hh\:mm\:ss");
        }
        private void ApplyPreviewVrEyeCrop(VrInputStereo layout)
        {
            if (layout == VrInputStereo.SideBySide)
            {
                _previewPlayer.API.Command("set", "video-zoom", "1.3");
                _previewPlayer.API.Command("set", "video-pan-x", "-0.25");
                _previewPlayer.API.Command("set", "video-pan-y", "0");
            }
            else if (layout == VrInputStereo.TopBottom)
            {
                _previewPlayer.API.Command("set", "video-zoom", "1.3");
                _previewPlayer.API.Command("set", "video-pan-x", "0");
                _previewPlayer.API.Command("set", "video-pan-y", "-0.25");
            }
            else
            {
                ResetPreviewCrop();
            }
        }

        private void ResetPreviewCrop()
        {
            _previewPlayer.API.Command("set", "video-zoom", "0");
            _previewPlayer.API.Command("set", "video-pan-x", "0");
            _previewPlayer.API.Command("set", "video-pan-y", "0");
        }
        private void PlayerInitCommands()
        {
            _previewPlayer.API.Command("set", "msg-level", "all=no");
            _previewPlayer.API.Command("set", "terminal", "no");
            _previewPlayer.API.Command("set", "idle", "yes");
            _previewPlayer.API.Command("set", "pause", "yes");
            _previewPlayer.API.Command("set", "hr-seek", "no");
            _previewPlayer.API.Command("set", "hr-seek-framedrop", "yes");
            _previewPlayer.API.Command("set", "load-scripts", "no");
            _previewPlayer.API.Command("set", "osc", "no");
            _previewPlayer.API.Command("set", "ytdl", "no");
            _previewPlayer.API.Command("set", "load-stats-overlay", "no");
            _previewPlayer.API.Command("set", "load-osd-console", "no");
            _previewPlayer.API.Command("set", "load-auto-profiles", "no");
            _previewPlayer.API.Command("set", "sub", "no");
            _previewPlayer.API.Command("set", "audio", "no");
            _previewPlayer.API.Command("set", "demuxer-readahead-secs", "0");
            _previewPlayer.API.Command("set", "demuxer-max-bytes", "8MiB");
            _previewPlayer.API.Command("set", "demuxer-max-back-bytes", "0");
            _previewPlayer.API.Command("set", "sws-scaler", "fast-bilinear");
            _previewPlayer.API.Command("set", "hwdec", "auto-safe");
            _previewPlayer.API.Command("set", "vf", "");
            _previewPlayer.API.Command("set", "scale", "bilinear");
            _previewPlayer.API.Command("set", "cscale", "bilinear");
            _previewPlayer.API.Command("set", "dscale", "bilinear");
            _previewPlayer.API.Command("set", "correct-downscaling", "no");
            _previewPlayer.API.Command("set", "sigmoid-upscaling", "no");
            _previewPlayer.API.Command("set", "deband", "no");
        }
    }
}
