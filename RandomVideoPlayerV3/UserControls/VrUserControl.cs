using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomVideoPlayer.UserControls
{
    public partial class VrUserControl : UserControl
    {
        private SettingsModel settings;
        public VrUserControl(SettingsModel settings)
        {
            InitializeComponent();
            DPI.UpdateDPIScaling(this);

            this.settings = settings;

            InitializeUI();
            BindControls();
            LoadSettings();
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);
            iconPictureBox1.IconColor = ThemeManager.CurrentTheme.StAccentColor;
        }

        private void LoadSettings()
        {
            cbToggleDetection.Checked = settings.VrAutoDetectionEnabled;
            cbEnableAutoDetectDebug.Checked = settings.VrAutoDetectionDebugerEnabled;

            sliderConfidence.Value = (int)settings.VrDetectionMinConfidence;

            switch (settings.VrMaxShiftWide)
            {
                case 8:
                    rbToleranceLow.Checked = true;
                    break;
                case 16:
                    rbToleranceMed.Checked = true;
                    break;
                case 21:
                    rbToleranceHigh.Checked = true;
                    break;
            }

            switch (settings.VrQualityPreset)
            {
                case VrRenderQuality.Perfomance:
                    rbQualityPerformance.Checked = true;
                    break;
                case VrRenderQuality.Balanced:
                    rbQualityBalanced.Checked = true;
                    break;
                case VrRenderQuality.High:
                    rbQualityHigh.Checked = true;
                    break;                
                case VrRenderQuality.Ultra:
                    rbQualityUltra.Checked = true;
                    break;
            }

            switch (settings.VrInterpolation)
            {
                case VrInterpolation.Linear:
                    rbInterpLine.Checked = true;
                    break;
                case VrInterpolation.Cubic:
                    rbInterpCubic.Checked = true;
                    break;
                case VrInterpolation.Lanczos:
                    rbInterpLanc.Checked = true;
                    break;
                case VrInterpolation.Spline:
                    rbInterpSpline.Checked = true;
                    break;
            }
        }
        private void BindControls()
        {
            cbToggleDetection.CheckedChanged += (s, e) =>
            {
                settings.VrAutoDetectionEnabled = cbToggleDetection.Checked;
            };

            cbEnableAutoDetectDebug.CheckedChanged += (s, e) =>
            {
                settings.VrAutoDetectionDebugerEnabled = cbEnableAutoDetectDebug.Checked;
            };

            sliderConfidence.ValueChanged += (s, e) =>
            {
                settings.VrDetectionMinConfidence = sliderConfidence.Value;
                lblInfoConfidence.Text = sliderConfidence.Value.ToString() + "%";
            };

            rbToleranceLow.CheckedChanged += rbMaxShift_CheckedChanged;
            rbToleranceMed.CheckedChanged += rbMaxShift_CheckedChanged;
            rbToleranceHigh.CheckedChanged += rbMaxShift_CheckedChanged;

            rbQualityPerformance.CheckedChanged += rbQualityPreset_CheckedChanged;
            rbQualityBalanced.CheckedChanged += rbQualityPreset_CheckedChanged;
            rbQualityHigh.CheckedChanged += rbQualityPreset_CheckedChanged;
            rbQualityUltra.CheckedChanged += rbQualityPreset_CheckedChanged;

            rbInterpLine.CheckedChanged += rbInterpolation_CheckedChanged;
            rbInterpCubic.CheckedChanged += rbInterpolation_CheckedChanged;
            rbInterpLanc.CheckedChanged += rbInterpolation_CheckedChanged;
            rbInterpSpline.CheckedChanged += rbInterpolation_CheckedChanged;
        }
        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            settings.VrAutoDetectionEnabled = false;
            settings.VrDetectionMinConfidence = 80;
            settings.VrInterpolation = VrInterpolation.Cubic;
            settings.VrMaxShiftWide = 16;
            settings.VrMaxShiftTall = 5;
            settings.VrQualityPreset = VrRenderQuality.Balanced;

            LoadSettings();
        }

        private void btnClearSetups_Click(object sender, EventArgs e)
        {
            var vrSettingsPath = VrConfigManager.ConfigFilePath;
            if (File.Exists(vrSettingsPath))
            {
                try
                {
                    File.Delete(vrSettingsPath);
                    MessageBox.Show("All VR setups have been cleared.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing VR setups: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error.Log(ex, "Error clearing VR setups", LogLevel.Error);
                }
            }
            else
            {
                MessageBox.Show("No VR setups found to clear.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void rbMaxShift_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked)
                return;
            switch (rb.Name)
            {
                case "rbToleranceLow":
                    settings.VrMaxShiftWide = 8;
                    settings.VrMaxShiftTall = 3;
                    break;
                case "rbToleranceMed":
                    settings.VrMaxShiftWide = 16;
                    settings.VrMaxShiftTall = 5;
                    break;
                case "rbToleranceHigh":
                    settings.VrMaxShiftWide = 21;
                    settings.VrMaxShiftTall = 7;
                    break;
            }
        }

        private void rbQualityPreset_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked)
                return;
            switch (rb.Name)
            {
                case "rbQualityPerformance":
                    settings.VrQualityPreset = VrRenderQuality.Perfomance;
                    break;
                case "rbQualityBalanced":
                    settings.VrQualityPreset = VrRenderQuality.Balanced;
                    break;
                case "rbQualityHigh":
                    settings.VrQualityPreset = VrRenderQuality.High;
                    break;                
                case "rbQualityUltra":
                    settings.VrQualityPreset = VrRenderQuality.Ultra;
                    break;
            }
        }

        private void rbInterpolation_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null || !rb.Checked)
                return;

            switch (rb.Name)
            {
                case "rbInterpLine":
                    settings.VrInterpolation = VrInterpolation.Linear;
                    break;

                case "rbInterpCubic":
                    settings.VrInterpolation = VrInterpolation.Cubic;
                    break;

                case "rbInterpLanc":
                    settings.VrInterpolation = VrInterpolation.Lanczos;
                    break;
                case "rbInterpSpline":
                    settings.VrInterpolation = VrInterpolation.Spline;
                    break;
            }
        }
    }
}
