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
    public partial class ExperimentalUserControl : UserControl
    {
        private SettingsModel settings;
        public ExperimentalUserControl(SettingsModel settings)
        {
            InitializeComponent();
            UpdateDPIScaling();
            this.settings = settings;
            LoadSettings();
            BindControls();
        }
        private void LoadSettings()
        {
            cbToggleZoomEffect.Checked = settings.SelectedAnimations.Contains(0);
            cbToggleMoveHorizontalEffect.Checked = settings.SelectedAnimations.Contains(1);
            cbToggleMoveVerticalEffect.Checked = settings.SelectedAnimations.Contains(2);

            cbKenBurnsEffect.Checked = settings.BurnsEffectEnabled;
            cbFadeEffect.Checked = settings.FadeEffectEnabled;

            inputPanAmountValue.Value = (int)(settings.PanAmount * 10);
            inputZoomAmountValue.Value = (int)(settings.ZoomAmount * 10);

            comboZoomEffects.DataSource = Enum.GetValues(typeof(EasingMethods));
            comboZoomEffects.SelectedIndex = settings.ZoomEasingFunction;

            comboPanEffects.DataSource = Enum.GetValues(typeof(EasingMethods));
            comboPanEffects.SelectedIndex = settings.PanEasingFunction;
        }        
        
        private void BindControls()
        {
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
        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            settings.ZoomAmount = 0.5;
            settings.PanAmount = 0.2;

            inputZoomAmountValue.Value = 5;
            inputPanAmountValue.Value = 2;

            comboZoomEffects.SelectedIndex = 0;
            comboPanEffects.SelectedIndex = 0;
        }
        private void UpdateSelectedAnimations()
        {
            var checkedEffects = new List<int>();
            if (cbToggleZoomEffect.Checked) checkedEffects.Add(0);
            if (cbToggleMoveHorizontalEffect.Checked) checkedEffects.Add(1);
            if (cbToggleMoveVerticalEffect.Checked) checkedEffects.Add(2);

            settings.SelectedAnimations = checkedEffects;
        }

        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);
            panel1.Size = DPI.GetSizeScaled(panel1.Size);
            flowLayoutPanel1.Size = DPI.GetSizeScaled(flowLayoutPanel1.Size);
            flowLayoutPanel2.Size = DPI.GetSizeScaled(flowLayoutPanel2.Size);
            flowLayoutPanel3.Size = DPI.GetSizeScaled(flowLayoutPanel3.Size);
            flowLayoutPanel4.Size = DPI.GetSizeScaled(flowLayoutPanel4.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);

            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);

            cbKenBurnsEffect.Size = DPI.GetSizeScaled(cbKenBurnsEffect.Size);
            cbKenBurnsEffect.Font = DPI.GetFontScaled(cbKenBurnsEffect.Font);

            cbFadeEffect.Size = DPI.GetSizeScaled(cbFadeEffect.Size);
            cbFadeEffect.Font = DPI.GetFontScaled(cbFadeEffect.Font);

            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);

            inputZoomAmountValue.Size = DPI.GetSizeScaled(inputZoomAmountValue.Size);
            inputZoomAmountValue.Font = DPI.GetFontScaled(inputZoomAmountValue.Font);

            lbl4.Size = DPI.GetSizeScaled(lbl4.Size);
            lbl4.Font = DPI.GetFontScaled(lbl4.Font);

            comboZoomEffects.Size = DPI.GetSizeScaled(comboZoomEffects.Size);
            comboZoomEffects.Font = DPI.GetFontScaled(comboZoomEffects.Font);

            lbl5.Size = DPI.GetSizeScaled(lbl5.Size);
            lbl5.Font = DPI.GetFontScaled(lbl5.Font);

            inputPanAmountValue.Size = DPI.GetSizeScaled(inputPanAmountValue.Size);
            inputPanAmountValue.Font = DPI.GetFontScaled(inputPanAmountValue.Font);

            lbl6.Size = DPI.GetSizeScaled(lbl6.Size);
            lbl6.Font = DPI.GetFontScaled(lbl6.Font);

            comboPanEffects.Size = DPI.GetSizeScaled(comboPanEffects.Size);
            comboPanEffects.Font = DPI.GetFontScaled(comboPanEffects.Font);

            lbl7.Size = DPI.GetSizeScaled(lbl7.Size);
            lbl7.Font = DPI.GetFontScaled(lbl7.Font);

            cbToggleZoomEffect.Size = DPI.GetSizeScaled(cbToggleZoomEffect.Size);
            cbToggleZoomEffect.Font = DPI.GetFontScaled(cbToggleZoomEffect.Font);

            cbToggleMoveHorizontalEffect.Size = DPI.GetSizeScaled(cbToggleMoveHorizontalEffect.Size);
            cbToggleMoveHorizontalEffect.Font = DPI.GetFontScaled(cbToggleMoveHorizontalEffect.Font);

            cbToggleMoveVerticalEffect.Size = DPI.GetSizeScaled(cbToggleMoveVerticalEffect.Size);
            cbToggleMoveVerticalEffect.Font = DPI.GetFontScaled(cbToggleMoveVerticalEffect.Font);

            btnRestoreDefaults.Size = DPI.GetSizeScaled(btnRestoreDefaults.Size);
            btnRestoreDefaults.Font = DPI.GetFontScaled(btnRestoreDefaults.Font);
            btnRestoreDefaults.Location = new Point(panel1.Width - btnRestoreDefaults.Width - 3, panel1.Height - btnRestoreDefaults.Height - 3);

        }
    }
}
