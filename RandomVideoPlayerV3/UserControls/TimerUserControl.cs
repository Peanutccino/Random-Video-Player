using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomVideoPlayer.UserControls
{
    public partial class TimerUserControl : UserControl
    {
        private SettingsModel settings;
        public TimerUserControl(SettingsModel settings)
        {
            InitializeComponent();

            this.settings = settings;

            InitializeUI();
            BindControls();
            LoadSettings();

            DPI.UpdateDPIScaling(this);
        }

        private void LoadSettings()
        {
            inputTimerValueStartPoint.Value = settings.AutoPlayTimerValueStartPoint;
            inputTimerValueEndPoint.Value = settings.AutoPlayTimerValueEndPoint;
            cbEnableTimeRange.Checked = settings.AutoPlayTimerRangeEnabled;
            cbEnableTimer.Checked = settings.TimerEnabled;
            cbResetTimerOnSeek.Checked = settings.TimerResetOnSeek;

            inputTimerMaxVideoDuration.Value = settings.TimerVideoMaxDuration;
            cbEnablePlayFully.Checked = settings.TimerVideoPlayFully;

            UpdateRangeIndicator();
        }

        private void BindControls()
        {
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

            cbEnableTimer.CheckedChanged += (s, e) =>
            {
                settings.TimerEnabled = cbEnableTimer.Checked;
            };

            cbResetTimerOnSeek.CheckedChanged += (s, e) =>
            {
                settings.TimerResetOnSeek = cbResetTimerOnSeek.Checked;
            };

            inputTimerMaxVideoDuration.ValueChanged += (s, e) =>
            {
                settings.TimerVideoMaxDuration = (int)inputTimerMaxVideoDuration.Value;

                TimeSpan time = TimeSpan.FromSeconds(settings.TimerVideoMaxDuration);
                lblMaxDurationTime.Text = $"( {(int)time.TotalMinutes}:{time.Seconds:D2} minutes)";
            };

            cbEnablePlayFully.CheckedChanged += (s, e) =>
            {
                settings.TimerVideoPlayFully = cbEnablePlayFully.Checked;
            };
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);
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
    }
}
