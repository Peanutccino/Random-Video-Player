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
    public partial class SubtitlesUserControl : UserControl
    {
        private SettingsModel settings;
        private List<string> fontTypes = new List<string> { "Arial", "Calibri", "Comic Sans MS", "Sans-Serif", "Times New Roman", "Trebuchet MS", "Verdana" };
        public SubtitlesUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

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
            lblPreview.Font = DPI.GetFontScaled(lblPreview.Font);
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

        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);
            panel1.Size = DPI.GetSizeScaled(panel1.Size);
            panel2.Size = DPI.GetSizeScaled(panel2.Size);
            panel3.Size = DPI.GetSizeScaled(panel3.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);
            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);
            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);

            lblFontSize.Size = DPI.GetSizeScaled(lblFontSize.Size);
            lblFontSize.Font = DPI.GetFontScaled(lblFontSize.Font);
            lblFontSize.Location = new Point(3, lbl2.Height);
            inputFontSize.Size = DPI.GetSizeScaled(inputFontSize.Size);
            inputFontSize.Font = DPI.GetFontScaled(inputFontSize.Font);
            inputFontSize.Location = new Point(lblFontSize.Location.X + lblFontSize.Width + 3, lblFontSize.Location.Y);

            lblBorderSize.Size = DPI.GetSizeScaled(lblBorderSize.Size);
            lblBorderSize.Font = DPI.GetFontScaled(lblBorderSize.Font);
            lblBorderSize.Location = new Point(inputFontSize.Location.X + inputFontSize.Width + 80, lblFontSize.Location.Y);
            inputBorderSize.Size = DPI.GetSizeScaled(inputBorderSize.Size);
            inputBorderSize.Font = DPI.GetFontScaled(inputBorderSize.Font);
            inputBorderSize.Location = new Point(lblBorderSize.Location.X + lblBorderSize.Width + 3, lblBorderSize.Location.Y);

            lblFontType.Size = DPI.GetSizeScaled(lblFontType.Size);
            lblFontType.Font = DPI.GetFontScaled(lblFontType.Font);
            lblFontType.Location = new Point(3,lblFontSize.Location.Y + lblFontSize.Height + 6);
            comboFontType.Size = DPI.GetSizeScaled(comboFontType.Size);
            comboFontType.Font = DPI.GetFontScaled(comboFontType.Font);
            comboFontType.Location = new Point(lblFontType.Location.X + lblFontType.Width + 3, lblFontType.Location.Y);

            lblFontColor.Size = DPI.GetSizeScaled(lblFontColor.Size);
            lblFontColor.Font = DPI.GetFontScaled(lblFontColor.Font);
            lblFontColor.Location = new Point(lblBorderSize.Location.X, lblFontType.Location.Y);
            btnPickColor.Size = DPI.GetSizeScaled(btnPickColor.Size);
            btnPickColor.Font = DPI.GetFontScaled(btnPickColor.Font);
            btnPickColor.Location = new Point(lblFontColor.Location.X + lblFontColor.Width + 3, lblFontColor.Location.Y);

            lblPreview.Size = DPI.GetSizeScaled(lblPreview.Size);
            lblPreview.Font = DPI.GetFontScaled(lblPreview.Font);
            
            cbEnableSubtitles.Size = DPI.GetSizeScaled(cbEnableSubtitles.Size);
            cbEnableSubtitles.Font = DPI.GetFontScaled(cbEnableSubtitles.Font);

            btnRestoreDefaultsFont.Size = DPI.GetSizeScaled(btnRestoreDefaultsFont.Size);
            btnRestoreDefaultsFont.Font = DPI.GetFontScaled(btnRestoreDefaultsFont.Font);
            btnRestoreDefaultsFont.Location = new Point(panel2.Width - btnRestoreDefaultsFont.Width - 3, panel2.Height - btnRestoreDefaultsFont.Height -3);
        }
    }
}
