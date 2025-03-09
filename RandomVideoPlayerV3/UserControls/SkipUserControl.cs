using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RandomVideoPlayer.Model;
using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.UserControls
{
    public partial class SkipUserControl : UserControl
    {
        private SettingsModel settings;
        public SkipUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

            this.settings = settings;
            BindControls();
            LoadSettings();
        }

        private void LoadSettings()
        {
            cbEnableSkip.Checked = settings.EnableAutoSkip;
            cbSkipVideoStart.Checked = settings.SkipVideoStart;
            cbSkipAlways.Checked = settings.SkipAlways;
            inputSkipGapLength.Value = settings.AutoSkipSeconds;
            cbRandomStartPoint.Checked = settings.EnableRandomVideoStartPoint;
            cbRandomVideoStartPointIgnoreScripts.Checked = settings.RandomVideoStartPointIgnoreScripts;
        }
        private void BindControls()
        {
            cbEnableSkip.CheckedChanged += (s, e) =>
            {
                settings.EnableAutoSkip = cbEnableSkip.Checked;
            };
            cbSkipVideoStart.CheckedChanged += (s, e) =>
            {
                settings.SkipVideoStart = cbSkipVideoStart.Checked;
            };
            cbSkipAlways.CheckedChanged += (s, e) =>
            {
                settings.SkipAlways = cbSkipAlways.Checked;
            };
            inputSkipGapLength.ValueChanged += (s, e) =>
            {
                settings.AutoSkipSeconds = (int)inputSkipGapLength.Value;
            };
            cbRandomStartPoint.CheckedChanged += (s, e) =>
            {
                settings.EnableRandomVideoStartPoint = cbRandomStartPoint.Checked;
            };
            cbRandomVideoStartPointIgnoreScripts.CheckedChanged += (s, e) =>
            {
                settings.RandomVideoStartPointIgnoreScripts = cbRandomVideoStartPointIgnoreScripts.Checked;
            };
        }
        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);

            panel1.Size = DPI.GetSizeScaled(panel1.Size);
            panel2.Size = DPI.GetSizeScaled(panel2.Size);
            panel3.Size = DPI.GetSizeScaled(panel3.Size);
            panel4.Size = DPI.GetSizeScaled(panel4.Size);
            panel5.Size = DPI.GetSizeScaled(panel5.Size);
            flowLayoutPanel1.Size = DPI.GetSizeScaled(flowLayoutPanel1.Size);

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
            lbl6.Size = DPI.GetSizeScaled(lbl6.Size);
            lbl6.Font = DPI.GetFontScaled(lbl6.Font);

            cbEnableSkip.Size = DPI.GetSizeScaled(cbEnableSkip.Size);
            cbEnableSkip.Font = DPI.GetFontScaled(cbEnableSkip.Font);
            cbSkipVideoStart.Size = DPI.GetSizeScaled(cbSkipVideoStart.Size);
            cbSkipVideoStart.Font = DPI.GetFontScaled(cbSkipVideoStart.Font);
            cbSkipAlways.Size = DPI.GetSizeScaled(cbSkipAlways.Size);
            cbSkipAlways.Font = DPI.GetFontScaled(cbSkipAlways.Font);
            inputSkipGapLength.Size = DPI.GetSizeScaled(inputSkipGapLength.Size);
            inputSkipGapLength.Font = DPI.GetFontScaled(inputSkipGapLength.Font);
            cbRandomStartPoint.Size = DPI.GetSizeScaled(cbRandomStartPoint.Size);
            cbRandomStartPoint.Font = DPI.GetFontScaled(cbRandomStartPoint.Font);
            cbRandomVideoStartPointIgnoreScripts.Size = DPI.GetSizeScaled(cbRandomVideoStartPointIgnoreScripts.Size);
            cbRandomVideoStartPointIgnoreScripts.Font = DPI.GetFontScaled(cbRandomVideoStartPointIgnoreScripts.Font);
        }
    }
}
