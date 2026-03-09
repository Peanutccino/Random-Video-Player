using FontAwesome.Sharp;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomVideoPlayer.UserControls
{
    public partial class ExperimentalUserControl : UserControl
    {
        private SettingsModel settings;

        private ContextMenuStrip contextEasingMethods;

        private Color _textColorBack;
        private Color _backColor;
        private Color _highlightColor;


        public ExperimentalUserControl(SettingsModel settings)
        {
            InitializeComponent();
            DPI.UpdateDPIScaling(this);
            this.settings = settings;
            InitializeUI();
            LoadSettings();
            BindControls();
        }

        private void InitializeUI()
        {
            _textColorBack = ThemeManager.CurrentTheme.StTextColorBack;
            _backColor = ThemeManager.CurrentTheme.StBackColor;
            _highlightColor = ThemeManager.CurrentTheme.StHighlightColor;

            var renderer = new CustomRenderer()
            {
                BackgroundColor = _backColor,
                TextColor = _textColorBack,
                HighlightColor = _highlightColor
            };
            renderer.ApplyColors();
            contextEasingMethods = new ContextMenuStrip()
            {
                ShowImageMargin = false,
                ShowCheckMargin = false,
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };

            ThemeManager.ApplyThemeSettings(this);
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

            btnZoomEffects.Text = ((EasingMethods)settings.ZoomEasingFunction).ToString();

            btnPanEffects.Text = ((EasingMethods)settings.PanEasingFunction).ToString();

            cbEnableThumbPreview.Checked = settings.ThumbnailPreviewEnabled;
            cbEnablePreviewSB.Checked = settings.PreviewSeekBarEnabled;
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

            cbEnableThumbPreview.CheckedChanged += (s, e) =>
            {
                settings.ThumbnailPreviewEnabled = cbEnableThumbPreview.Checked;
            };

            cbEnablePreviewSB.CheckedChanged += (s, e) =>
            {
                settings.PreviewSeekBarEnabled = cbEnablePreviewSB.Checked;
            };

            btnZoomEffects.Click += (s, e) =>
            {
                ContextEasingMethods_Click(s, e);
            };

            btnPanEffects.Click += (s, e) =>
            {
                ContextEasingMethods_Click(s, e);
            };
        }
        private void ContextEasingMethods_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var easingMethods = Enum.GetValues(typeof(EasingMethods));

            contextEasingMethods.Items.Clear();
            foreach (var easingMethod in easingMethods)
            {
                var item = contextEasingMethods.Items.Add(easingMethod.ToString());
                item.Click += (s, _) =>
                {
                    button.Text = easingMethod.ToString();

                    switch (button)
                    {
                        case Button button when button.Name == "btnZoomEffects":
                            settings.ZoomEasingFunction = (int)Enum.Parse(typeof(EasingMethods), button.Text);
                            break;
                        case Button button when button.Name == "btnPanEffects":
                            settings.PanEasingFunction = (int)Enum.Parse(typeof(EasingMethods), button.Text);
                            break;
                    }
                };
                contextEasingMethods.Show(button, new Point(0, button.Height), ToolStripDropDownDirection.BelowRight);
            }
        }
        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            settings.ZoomAmount = 0.5;
            settings.PanAmount = 0.2;

            inputZoomAmountValue.Value = 5;
            inputPanAmountValue.Value = 2;

            settings.ZoomEasingFunction = 0;
            settings.PanEasingFunction = 0;

            btnZoomEffects.Text = ((EasingMethods)settings.ZoomEasingFunction).ToString();
            btnPanEffects.Text = ((EasingMethods)settings.PanEasingFunction).ToString();
        }
        private void UpdateSelectedAnimations()
        {
            var checkedEffects = new List<int>();
            if (cbToggleZoomEffect.Checked) checkedEffects.Add(0);
            if (cbToggleMoveHorizontalEffect.Checked) checkedEffects.Add(1);
            if (cbToggleMoveVerticalEffect.Checked) checkedEffects.Add(2);

            settings.SelectedAnimations = checkedEffects;
        }
    }
}
