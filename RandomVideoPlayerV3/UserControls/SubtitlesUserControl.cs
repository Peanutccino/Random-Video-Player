using RandomVideoPlayer.Controls;
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
    public partial class SubtitlesUserControl : UserControl
    {
        private SettingsModel settings;
        private List<string> fontTypes = new List<string> { "Arial", "Calibri", "Comic Sans MS", "Sans-Serif", "Times New Roman", "Trebuchet MS", "Verdana" };
        public SubtitlesUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;
            LoadSettings();
            BindControls();
        }
        private void LoadSettings()
        {
            cbEnableSubtitles.Checked = settings.EnableSubtitles;

            inputFontSize.Value = settings.SubtitleSize;
            inputBorderSize.Value = settings.SubtitleBorderSize;
            comboFontType.SetFontTypes(fontTypes);
            comboFontType.SelectedItem = settings.SubtitleFontType;

            UpdatePreview();
            lblPreview.Text = "Random Video Player";
        }
        private void BindControls()
        {
            cbEnableSubtitles.CheckedChanged += (s, e) =>
            {
                settings.EnableSubtitles = cbEnableSubtitles.Checked;
            };

            inputFontSize.ValueChanged += (s, e) =>
            {
                settings.SubtitleSize = (int)inputFontSize.Value;
                UpdatePreview();
            };

            inputBorderSize.ValueChanged += (s, e) =>
            {
                settings.SubtitleBorderSize = (int)inputBorderSize.Value;
                UpdatePreview();
            };

            comboFontType.SelectedIndexChanged += (s, e) =>
            {
                settings.SubtitleFontType = comboFontType.SelectedItem.ToString();
                UpdatePreview();
            };
        }

        private void UpdatePreview()
        {
            lblPreview.Font = new Font(settings.SubtitleFontType, settings.SubtitleSize);
            lblPreview.ForeColor = ColorTranslator.FromHtml(settings.SubtitleFontColor);
            lblPreview.OutlineThickness = settings.SubtitleBorderSize;
            btnPickColor.BackColor = lblPreview.ForeColor;
            Invalidate();
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    string hexColor = ColorToHex(selectedColor);
                    settings.SubtitleFontColor = hexColor;
                    UpdatePreview();
                }
            }
        }

        private string ColorToHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void btnRestoreDefaultsFont_Click(object sender, EventArgs e)
        {
            settings.SubtitleFontType = "Arial";
            settings.SubtitleSize = 55;
            settings.SubtitleBorderSize = 3;
            settings.SubtitleFontColor = "#FFFFFF";
            UpdatePreview();
        }
    }
}
