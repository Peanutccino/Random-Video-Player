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
    public partial class AudioUserControl : UserControl
    {
        private SettingsModel settings;

        public AudioUserControl(SettingsModel settings)
        {
            InitializeComponent();

            this.settings = settings;

            InitializeUI();
            LoadSettings();
            BindControls();

            DPI.UpdateDPIScaling(this);
        }

        private void LoadSettings()
        {
            cbAudioNormalization.Checked = settings.AudioNormalizerEnabled;

            sliderFrameLen.Value = settings.FrameLen;
            sliderGaussSize.Value = settings.GaussSize;
            sliderPeak.Value = (int)(settings.Peak * 100);
            sliderMaxGain.Value = (int)(settings.MaxGain);
            sliderTargetRMS.Value = (int)(settings.TargetRMS * 100);
            sliderAltBound.Value = settings.AltBoundary ? 1 : 0;

            UpdateLabels();
        }
        private void BindControls()
        {
            cbAudioNormalization.CheckedChanged += (s, e) =>
            {
                settings.AudioNormalizerEnabled = cbAudioNormalization.Checked;
            };

            sliderFrameLen.ValueChanged += (s, e) =>
            {
                settings.FrameLen = sliderFrameLen.Value;
                UpdateLabels();
            };

            sliderGaussSize.ValueChanged += (s, e) =>
            {
                settings.GaussSize = sliderGaussSize.Value;
                UpdateLabels();
            };

            sliderPeak.ValueChanged += (s, e) =>
            {
                settings.Peak = sliderPeak.Value / 100.0d;
                UpdateLabels();
            };

            sliderMaxGain.ValueChanged += (s, e) =>
            {
                settings.MaxGain = sliderMaxGain.Value;
                UpdateLabels();
            };

            sliderTargetRMS.ValueChanged += (s, e) =>
            {
                settings.TargetRMS = sliderTargetRMS.Value / 100.0d;
                UpdateLabels();
            };

            sliderAltBound.ValueChanged += (s, e) =>
            {
                settings.AltBoundary = sliderAltBound.Value == 1;
                UpdateLabels();
            };

            btnRestoreDefaults.Click += (s, e) =>
            {
                btnRestoreDefaults_Click(s, e);
            };
        }
        #region Defaults
        private const int frameLen = 250;
        private const int gaussSize = 31;
        private const double peak = 0.5d;
        private const double maxGain = 20.0d;
        private const double targetRMS = 0.9d;
        private const int altBoundary = 1;
        #endregion

        private void btnRestoreDefaults_Click(object s, EventArgs e)
        {
            settings.FrameLen = frameLen;
            settings.GaussSize = gaussSize;
            settings.Peak = peak;
            settings.MaxGain = maxGain;
            settings.TargetRMS = targetRMS;
            settings.AltBoundary = altBoundary == 1;

            LoadSettings();
        }

        private void UpdateLabels()
        {
            lblInfoFrameLen.Text = sliderFrameLen.Value.ToString() + "ms";
            lblInfoGaussSize.Text = sliderGaussSize.Value.ToString() + " frames";
            lblInfoPeak.Text = sliderPeak.Value.ToString() + "%";
            lblInfoMaxGain.Text = sliderMaxGain.Value.ToString() + "%";
            lblInfoTargetRMS.Text = sliderTargetRMS.Value.ToString() + "%";
            lblInfoAltBound.Text = sliderAltBound.Value == 1 ? "Enabled" : "Disabled";

        }
        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);
        }
    }
}
