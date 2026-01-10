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
        public PlayerUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

            this.settings = settings;
            LoadSettings();
            BindControls();
        }
        private void LoadSettings()
        {
            cbShufflePlayer.Checked = settings.ShufflePlaylist;
            cbReshuffle.Checked = settings.ReShuffle;

            cbEnableRTXVSR.Checked = settings.RTXVSREnabled;

            cbLeftMousePause.Checked = settings.LeftMousePause;

            switch (settings.AutoPlayMethod)
            {
                case AutoPlayMethod.LoopVideo:
                    rbRepeatVideo.Checked = true;
                    break;
                case AutoPlayMethod.AutoNext:
                    rbAutoNext.Checked = true;
                    break;
                case AutoPlayMethod.AutoTimer:
                    rbAutoTimer.Checked = true;
                    break;
            }

            inputTimerValueStartPoint.Value = settings.AutoPlayTimerValueStartPoint;
            inputTimerValueEndPoint.Value = settings.AutoPlayTimerValueEndPoint;
            cbEnableTimeRange.Checked = settings.AutoPlayTimerRangeEnabled;

            inputSFS.Value = settings.CustomSeekForwardValueSmall;
            inputSBS.Value = settings.CustomSeekBackwardValueSmall;
            inputSFL.Value = settings.CustomSeekForwardValueLarge;
            inputSBL.Value = settings.CustomSeekBackwardValueLarge;
            inputVideoThreshold.Value = settings.VideoSizeThreshold / 60; //convert to minutes

            IReadOnlyDictionary<string, Theme> themes = ThemeLoader.LoadThemes();

            if (!themes.ContainsKey("Light"))
            {
                themes = themes.Concat(new[] {
            new KeyValuePair<string, Theme>("Light", ThemeDefaults.Light)}).ToDictionary(k => k.Key, k => k.Value);
            }

            var options = themes
                .Select(kvp => new ThemeOption(kvp.Key, kvp.Value))
                .OrderBy(opt => opt.Name)
                .ToList();

            comboThemes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboThemes.DisplayMember = nameof(ThemeOption.Name);
            comboThemes.ValueMember = nameof(ThemeOption.Theme);
            comboThemes.DataSource = options;

            string savedThemeName = settings.SelectedTheme;
            var match = options.FirstOrDefault(o => o.Name == savedThemeName)
                        ?? options.First(o => o.Name == "Light");
            comboThemes.SelectedItem = match;

            UpdateRangeIndicator();
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
            rbAutoTimer.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);

            inputTimerValueStartPoint.ValueChanged += (s, e) =>
            {
                settings.AutoPlayTimerValueStartPoint = (int)inputTimerValueStartPoint.Value;
                TimeRangeValidation(s);
            };

            inputTimerValueEndPoint.ValueChanged += (s, e) =>
            {
                settings.AutoPlayTimerValueEndPoint = (int)inputTimerValueEndPoint.Value;
                TimeRangeValidation(s);
            };

            cbEnableTimeRange.CheckedChanged += (s, e) =>
            {
                settings.AutoPlayTimerRangeEnabled = cbEnableTimeRange.Checked;
                UpdateRangeIndicator();
            };

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

            comboThemes.SelectedIndexChanged += (s, e) =>
            {
                if (comboThemes.SelectedItem is ThemeOption selectedOption)
                {
                    settings.SelectedTheme = selectedOption.Name;                    
                }
            };
        }
        public sealed record ThemeOption(string Name, Theme Theme);
        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is RadioButton selectedRadioButton && selectedRadioButton.Checked)
            {
                rbRepeatVideo.Checked = selectedRadioButton == rbRepeatVideo;
                rbAutoNext.Checked = selectedRadioButton == rbAutoNext;
                rbAutoTimer.Checked = selectedRadioButton == rbAutoTimer;

                switch (selectedRadioButton.Name)
                {
                    case "rbRepeatVideo":
                        settings.AutoPlayMethod = AutoPlayMethod.LoopVideo;
                        break;
                    case "rbAutoNext":
                        settings.AutoPlayMethod = AutoPlayMethod.AutoNext;
                        break;
                    case "rbAutoTimer":
                        settings.AutoPlayMethod = AutoPlayMethod.AutoTimer;
                        break;
                }
            }
        }

        private void UpdateRangeIndicator()
        {
            if (cbEnableTimeRange.Checked)
            {
                lblBetweenTime.Text = "to";
                lblAfterTime.Visible = true;
                inputTimerValueEndPoint.Visible = true;
            }
            else
            {
                lblBetweenTime.Text = "seconds";
                lblAfterTime.Visible = false;
                inputTimerValueEndPoint.Visible = false;
            }
        }
        private void TimeRangeValidation(object sender)
        {
            int minValue = (int)inputTimerValueStartPoint.Value;
            int maxValue = (int)inputTimerValueEndPoint.Value;

            CustomNumericUpDown inputBox = sender as CustomNumericUpDown;

            if (inputBox != null && inputBox == inputTimerValueStartPoint)
            {
                if (minValue >= maxValue)
                {
                    inputTimerValueEndPoint.Value = minValue + 1;
                }
            }
            else if (inputBox != null && inputBox == inputTimerValueEndPoint)
            {
                if (maxValue <= minValue)
                {
                    inputTimerValueStartPoint.Value = maxValue - 1;
                }
            }

        }
        private void btnRTXHelp_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://nvidia.custhelp.com/app/answers/detail/a_id/5448/~/rtx-video-faq") { UseShellExecute = true });
        }

        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);

            panel1.Size = DPI.GetSizeScaled(panel1.Size);
            panel2.Size = DPI.GetSizeScaled(panel2.Size);
            panel3.Size = DPI.GetSizeScaled(panel3.Size);
            panel4.Size = DPI.GetSizeScaled(panel4.Size);
            flowLayoutPanel1.Size = DPI.GetSizeScaled(flowLayoutPanel1.Size);
            flowLayoutPanel2.Size = DPI.GetSizeScaled(flowLayoutPanel2.Size);
            flowLayoutPanel3.Size = DPI.GetSizeScaled(flowLayoutPanel3.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);
            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);
            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);
            lbl4.Size = DPI.GetSizeScaled(lbl4.Size);
            lbl4.Font = DPI.GetFontScaled(lbl4.Font);
            lbl5.Size = DPI.GetSizeScaled(lbl5.Size);
            lbl5.Font = DPI.GetFontScaled(lbl5.Font);

            cbLeftMousePause.Size = DPI.GetSizeScaled(cbLeftMousePause.Size);
            cbLeftMousePause.Font = DPI.GetFontScaled(cbLeftMousePause.Font);

            rbRepeatVideo.Size = DPI.GetSizeScaled(rbRepeatVideo.Size);
            rbRepeatVideo.Font = DPI.GetFontScaled(rbRepeatVideo.Font);

            rbAutoNext.Size = DPI.GetSizeScaled(rbAutoNext.Size);
            rbAutoNext.Font = DPI.GetFontScaled(rbAutoNext.Font);

            rbAutoTimer.Size = DPI.GetSizeScaled(rbAutoTimer.Size);
            rbAutoTimer.Font = DPI.GetFontScaled(rbAutoTimer.Font);

            inputTimerValueStartPoint.Size = DPI.GetSizeScaled(inputTimerValueStartPoint.Size);
            inputTimerValueStartPoint.Font = DPI.GetFontScaled(inputTimerValueStartPoint.Font);

            lblBetweenTime.Size = DPI.GetSizeScaled(lblBetweenTime.Size);
            lblBetweenTime.Font = DPI.GetFontScaled(lblBetweenTime.Font);

            inputTimerValueEndPoint.Size = DPI.GetSizeScaled(inputTimerValueEndPoint.Size);
            inputTimerValueEndPoint.Font = DPI.GetFontScaled(inputTimerValueEndPoint.Font);

            lblAfterTime.Size = DPI.GetSizeScaled(lblAfterTime.Size);
            lblAfterTime.Font = DPI.GetFontScaled(lblAfterTime.Font);

            cbEnableTimeRange.Size = DPI.GetSizeScaled(cbEnableTimeRange.Size);
            cbEnableTimeRange.Font = DPI.GetFontScaled(cbEnableTimeRange.Font);

            cbShufflePlayer.Size = DPI.GetSizeScaled(cbShufflePlayer.Size);
            cbShufflePlayer.Font = DPI.GetFontScaled(cbShufflePlayer.Font);

            cbReshuffle.Size = DPI.GetSizeScaled(cbReshuffle.Size);
            cbReshuffle.Font = DPI.GetFontScaled(cbReshuffle.Font);

            cbEnableRTXVSR.Size = DPI.GetSizeScaled(cbEnableRTXVSR.Size);
            cbEnableRTXVSR.Font = DPI.GetFontScaled(cbEnableRTXVSR.Font);

            btnRTXHelp.Size = DPI.GetSizeScaled(btnRTXHelp.Size);
            btnRTXHelp.Font = DPI.GetFontScaled(btnRTXHelp.Font);
        }
    }
}
