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

namespace RandomVideoPlayer.UserControls
{
    public partial class SkipUserControl: UserControl
    {
        private SettingsModel settings;
        public SkipUserControl(SettingsModel settings)
        {
            InitializeComponent();

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
        }


    }
}
