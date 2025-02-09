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

            cbToggleZoomEffect.Checked = settings.SelectedAnimations.Contains(0);
            cbToggleMoveHorizontalEffect.Checked = settings.SelectedAnimations.Contains(1);
            cbToggleMoveVerticalEffect.Checked = settings.SelectedAnimations.Contains(2);

            cbKenBurnsEffect.Checked = settings.BurnsEffectEnabled;
            cbFadeEffect.Checked = settings.FadeEffectEnabled;

            inputTimerValueStartPoint.Value = settings.AutoPlayTimerValueStartPoint;
            inputTimerValueEndPoint.Value = settings.AutoPlayTimerValueEndPoint;
            cbEnableTimeRange.Checked = settings.AutoPlayTimerRangeEnabled;


            inputPanAmountValue.Value = (int)(settings.PanAmount * 10);
            inputZoomAmountValue.Value = (int)(settings.ZoomAmount * 10);

            comboZoomEffects.DataSource = Enum.GetValues(typeof(EasingMethods));
            comboZoomEffects.SelectedIndex = settings.ZoomEasingFunction;

            comboPanEffects.DataSource = Enum.GetValues(typeof(EasingMethods));
            comboPanEffects.SelectedIndex = settings.PanEasingFunction;

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

            cbToggleZoomEffect.CheckedChanged += (s, e) =>
            {
                UpdateSelectedAnimations();
            };

            cbToggleMoveHorizontalEffect.CheckedChanged += (s, e) =>
            {
                UpdateSelectedAnimations();
            };

            cbToggleMoveVerticalEffect.CheckedChanged += (s, e) =>
            {
                UpdateSelectedAnimations();
            };

            cbKenBurnsEffect.CheckedChanged += (s, e) =>
            {
                settings.BurnsEffectEnabled = cbKenBurnsEffect.Checked;
            };

            cbFadeEffect.CheckedChanged += (s, e) =>
            {
                settings.FadeEffectEnabled = cbFadeEffect.Checked;
            };

            inputPanAmountValue.ValueChanged += (s, e) =>
            {
                settings.PanAmount = ((double)inputPanAmountValue.Value / 10);
            };

            inputZoomAmountValue.ValueChanged += (s, e) =>
            {
                settings.ZoomAmount = ((double)inputZoomAmountValue.Value / 10);
            };

            comboZoomEffects.SelectedIndexChanged += (s, e) =>
            {
                settings.ZoomEasingFunction = comboZoomEffects.SelectedIndex;
            };

            comboPanEffects.SelectedIndexChanged += (s, e) =>
            {
                settings.PanEasingFunction = comboPanEffects.SelectedIndex;
            };
        }

        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                switch (radioButton.Name)
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

        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            settings.ZoomAmount = 0.5;
            settings.PanAmount = 0.2;

            inputZoomAmountValue.Value = 5;
            inputPanAmountValue.Value = 2;

            comboZoomEffects.SelectedIndex = 0;
            comboPanEffects.SelectedIndex = 0;
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

        private void UpdateSelectedAnimations()
        {
            var checkedEffects = new List<int>();
            if (cbToggleZoomEffect.Checked) checkedEffects.Add(0);
            if (cbToggleMoveHorizontalEffect.Checked) checkedEffects.Add(1);
            if (cbToggleMoveVerticalEffect.Checked) checkedEffects.Add(2);

            settings.SelectedAnimations = checkedEffects;
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
    }
}
