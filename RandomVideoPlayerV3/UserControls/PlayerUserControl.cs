using FontAwesome.Sharp;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System.Diagnostics;
using System.Windows.Forms;


namespace RandomVideoPlayer.UserControls
{
    public partial class PlayerUserControl : UserControl
    {
        private SettingsModel settings;

        private ContextMenuStrip contextLogLevel;

        private Color _textColor;
        private Color _backColorDark;
        private Color _highlightColor;
        private Color _textColorBack;
        private Color _backColor;


        private Color HoverColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 60);
        private Color PressedColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 20);

        private readonly Dictionary<IconButton, Color> idleColors = new();
        public PlayerUserControl(SettingsModel settings)
        {
            InitializeComponent();



            this.settings = settings;
            InitializeUI();
            LoadSettings();
            BindControls();

            DPI.UpdateDPIScaling(this);
        }
        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);

            _textColor = ThemeManager.CurrentTheme.StTextColor;
            _backColorDark = ThemeManager.CurrentTheme.StBackColorDark;
            _highlightColor = ThemeManager.CurrentTheme.StHighlightColor;
            _textColorBack = ThemeManager.CurrentTheme.StTextColorBack;
            _backColor = ThemeManager.CurrentTheme.StBackColor;

            var renderer = new CustomRenderer()
            {
                BackgroundColor = _backColor,
                TextColor = _textColorBack,
                HighlightColor = _highlightColor
            };
            renderer.ApplyColors();
            contextLogLevel = new ContextMenuStrip()
            {
                ShowImageMargin = false,
                ShowCheckMargin = false,
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };

            WireIconButton(btnRTXHelp);
        }
        private void WireIconButton(IconButton btn)
        {
            btn.FlatAppearance.MouseOverBackColor = _backColorDark;
            btn.FlatAppearance.MouseDownBackColor = _backColorDark;
            btn.BackColor = _backColorDark;

            idleColors[btn] = _textColor;
            btn.IconColor = _textColor;

            btn.MouseEnter += (_, _) => btn.IconColor = HoverColor(btn);
            btn.MouseLeave += (_, _) => btn.IconColor = idleColors[btn];
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    btn.IconColor = PressedColor(btn);
            };
            btn.MouseUp += (_, _) =>
            {
                btn.IconColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn)
                    : idleColors[btn];
            };
            btn.GotFocus += (_, _) => btn.IconColor = HoverColor(btn);
            btn.LostFocus += (_, _) => btn.IconColor = idleColors[btn];
        }
        private void LoadSettings()
        {
            cbShufflePlayer.Checked = settings.ShufflePlaylist;
            cbReshuffle.Checked = settings.ReShuffle;

            cbEnableRTXVSR.Checked = settings.RTXVSREnabled;

            cbLeftMousePause.Checked = settings.LeftMousePause;

            if(settings.LoopEnabled)
            {
                rbRepeatVideo.Checked = true;
            }
            else
            {
                rbAutoNext.Checked = true;
            }

            inputSFS.Value = settings.CustomSeekForwardValueSmall;
            inputSBS.Value = settings.CustomSeekBackwardValueSmall;
            inputSFL.Value = settings.CustomSeekForwardValueLarge;
            inputSBL.Value = settings.CustomSeekBackwardValueLarge;
            inputVideoThreshold.Value = settings.VideoSizeThreshold / 60; //convert to minutes

            btnLogLevel.Text = settings.LogLevel.ToString();
        }


        private void BindControls()
        {
            cbShufflePlayer.CheckedChanged += (s, e) =>
            {
                settings.ShufflePlaylist = cbShufflePlayer.Checked;
            };

            cbReshuffle.CheckedChanged += (s, e) =>
            {
                settings.ReShuffle = cbReshuffle.Checked;
            };

            cbEnableRTXVSR.CheckedChanged += (s, e) =>
            {
                settings.RTXVSREnabled = cbEnableRTXVSR.Checked;
            };

            cbLeftMousePause.CheckedChanged += (s, e) =>
            {
                settings.LeftMousePause = cbLeftMousePause.Checked;
            };

            rbRepeatVideo.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rbAutoNext.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);



            inputSFS.ValueChanged += (s, e) =>
            {
                settings.CustomSeekForwardValueSmall = (int)inputSFS.Value;
            };
            inputSBS.ValueChanged += (s, e) =>
            {
                settings.CustomSeekBackwardValueSmall = (int)inputSBS.Value;
            };
            inputSFL.ValueChanged += (s, e) =>
            {
                settings.CustomSeekForwardValueLarge = (int)inputSFL.Value;
            };
            inputSBL.ValueChanged += (s, e) =>
            {
                settings.CustomSeekBackwardValueLarge = (int)inputSBL.Value;
            };
            inputVideoThreshold.ValueChanged += (s, e) =>
            {
                settings.VideoSizeThreshold = (int)inputVideoThreshold.Value;
            };

            btnLogLevel.Click += (s, e) =>
            {
                ContextLogLevel_Click(s, e);
            };
        }

        private void ContextLogLevel_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var easingMethods = Enum.GetValues(typeof(LogLevel));

            contextLogLevel.Items.Clear();
            foreach (var easingMethod in easingMethods)
            {
                var item = contextLogLevel.Items.Add(easingMethod.ToString());
                item.Click += (s, _) =>
                {
                    button.Text = easingMethod.ToString();

                    settings.LogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), button.Text);
                };
                contextLogLevel.Show(button, new Point(0, 0), ToolStripDropDownDirection.AboveRight);
            }
        }
        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is RadioButton selectedRadioButton && selectedRadioButton.Checked)
            {
                rbRepeatVideo.Checked = selectedRadioButton == rbRepeatVideo;
                rbAutoNext.Checked = selectedRadioButton == rbAutoNext;

                switch (selectedRadioButton.Name)
                {
                    case "rbRepeatVideo":
                        settings.LoopEnabled = true;
                        break;
                    case "rbAutoNext":
                        settings.LoopEnabled = false;
                        break;
                }
            }
        }

        private void btnRTXHelp_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://nvidia.custhelp.com/app/answers/detail/a_id/5448/~/rtx-video-faq") { UseShellExecute = true });
        }
    }
}
