using RandomVideoPlayer.Model;
using System.Windows.Forms;


namespace RandomVideoPlayer.UserControls
{
    public partial class PlayerUserControl : UserControl
    {
        private SettingsModel settings;
        public PlayerUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;
            LoadSettings();
            BindControls();
            InitializeCheckboxEvents();
        }

        private void LoadSettings()
        {
            if (settings.SortCreated)
            {
                rbDateCreated.Checked = true;
            }
            else
            {
                rbDateModified.Checked = true;
            }

            if (settings.PlayOnDrop)
            {
                rbDropPlay.Checked = true;
            }
            else
            {
                rbDropQueue.Checked = true;
            }

            cbLoopPlayer.Checked = settings.LoopPlayer;
            cbShufflePlayer.Checked = settings.ShufflePlaylist;

            foreach (Control control in panelVideoExtensions.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = settings.SelectedExtensions.Contains(checkBox.Text);
                }
            }

            foreach (Control control in panelImageExtensions.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = settings.SelectedExtensions.Contains(checkBox.Text);
                }
            }

            cbFilterApply.Checked = settings.ApplyFilterToList;
        }


        private void BindControls()
        {
            cbLoopPlayer.CheckedChanged += (s, e) =>
            {
                settings.LoopPlayer = cbLoopPlayer.Checked;
            };

            cbShufflePlayer.CheckedChanged += (s, e) =>
            {
                settings.ShufflePlaylist = cbShufflePlayer.Checked;
            };

            rbDateCreated.CheckedChanged += (s, e) =>
            {
                settings.SortCreated = rbDateCreated.Checked;
            };

            rbDropPlay.CheckedChanged += (s, e) =>
            {
                settings.PlayOnDrop = rbDropPlay.Checked;
            };

            cbFilterApply.CheckedChanged += (s, e) =>
            {
                settings.ApplyFilterToList = cbFilterApply.Checked;
            };
        }

        private void RbDropPlay_CheckedChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitializeCheckboxEvents()
        {
            cbAVI.CheckedChanged += CheckBox_CheckedChanged;
            cbAVCHD.CheckedChanged += CheckBox_CheckedChanged;
            cbF4V.CheckedChanged += CheckBox_CheckedChanged;
            cbFLV.CheckedChanged += CheckBox_CheckedChanged;
            cbM4V.CheckedChanged += CheckBox_CheckedChanged;
            cbMKV.CheckedChanged += CheckBox_CheckedChanged;
            cbMOV.CheckedChanged += CheckBox_CheckedChanged;
            cbMP4.CheckedChanged += CheckBox_CheckedChanged;
            cbWEBM.CheckedChanged += CheckBox_CheckedChanged;
            cbWMV.CheckedChanged += CheckBox_CheckedChanged;

            cbJPG.CheckedChanged += CheckBox_CheckedChanged;
            cbJPEG.CheckedChanged += CheckBox_CheckedChanged;
            cbPNG.CheckedChanged += CheckBox_CheckedChanged;
            cbGIF.CheckedChanged += CheckBox_CheckedChanged;
            cbTIF.CheckedChanged += CheckBox_CheckedChanged;
            cbTIFF.CheckedChanged += CheckBox_CheckedChanged;
            cbBMP.CheckedChanged += CheckBox_CheckedChanged;
            cbWEBP.CheckedChanged += CheckBox_CheckedChanged;
            cbAVIF.CheckedChanged += CheckBox_CheckedChanged;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                if (checkBox.Checked)
                {
                    if (!settings.SelectedExtensions.Contains(checkBox.Text))
                    {
                        settings.SelectedExtensions.Add(checkBox.Text);
                    }
                }
                else
                {
                    if (settings.SelectedExtensions.Contains(checkBox.Text))
                    {
                        settings.SelectedExtensions.Remove(checkBox.Text);
                    }
                }
            }
        }

        private void btnSelectVideoExt_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelVideoExtensions.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void btnDeselectVideoExt_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelVideoExtensions.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void btnSelectImageExt_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelImageExtensions.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void btnDeselectImageExt_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelImageExtensions.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }
    }
}
