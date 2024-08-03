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
    public partial class DragDropUserControl : UserControl
    {
        private SettingsModel settings;
        public DragDropUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;
            LoadSettings();
            BindControls();
        }

        private void LoadSettings()
        {
            if (settings.PlayOnDrop)
            {
                rbDropPlay.Checked = true;
            }
            else
            {
                rbDropQueue.Checked = true;
            }

            cbAlwaysAddFilesToQueue.Checked = settings.AlwaysAddFilesToQueue;
        }

        private void BindControls()
        {
            rbDropPlay.CheckedChanged += (s, e) =>
            {
                settings.PlayOnDrop = rbDropPlay.Checked;
            };

            cbAlwaysAddFilesToQueue.CheckedChanged += (s, e) =>
            {
                settings.AlwaysAddFilesToQueue = cbAlwaysAddFilesToQueue.Checked;
            };
        }
    }
}
