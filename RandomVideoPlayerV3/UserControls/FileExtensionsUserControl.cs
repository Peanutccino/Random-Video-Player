using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class FileExtensionsUserControl : UserControl
    {
        private SettingsModel settings;
        public FileExtensionsUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;
            LoadSettings();
            BindControls();
        }

        private void BindControls()
        {
            cbFilterApply.CheckedChanged += (s, e) =>
            {
                settings.ApplyFilterToList = cbFilterApply.Checked;
            };

            cbEnableVideoFilter.CheckedChanged += (s, e) =>
            {
                settings.FilterVideoEnabled = cbEnableVideoFilter.Checked;
                if(cbEnableVideoFilter.Checked)
                {
                    cbEnableScriptFilter.Checked = false;
                }
            };

            cbEnableImageFilter.CheckedChanged += (s, e) =>
            {
                settings.FilterImageEnabled = cbEnableImageFilter.Checked;
                if (cbEnableImageFilter.Checked)
                {
                    cbEnableScriptFilter.Checked = false;
                }
            };

            cbEnableScriptFilter.CheckedChanged += (s, e) =>
            {
                settings.FilterScriptEnabled = cbEnableScriptFilter.Checked;
                if(cbEnableScriptFilter.Checked)
                {
                    cbEnableVideoFilter.Checked = false;
                    cbEnableImageFilter.Checked = false;
                }
            };
        }

        private void LoadSettings()
        {
            cbFilterApply.Checked = settings.ApplyFilterToList;
            cbEnableVideoFilter.Checked = settings.FilterVideoEnabled;
            cbEnableImageFilter.Checked = settings.FilterImageEnabled;
            cbEnableScriptFilter.Checked = settings.FilterScriptEnabled;

            CreateCheckBoxesForExtensions();
            SetupTooltips();
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

        private void CreateCheckBoxesForExtensions()
        {
            foreach (var extension in ListHandler.VideoExtensions)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = extension;
                checkBox.AutoSize = false;
                checkBox.Margin = new Padding(6, 3, 3, 3);
                checkBox.Size = new Size(66, 18);
                checkBox.Checked = settings.SelectedExtensions.Contains(extension);
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                flowPanelVideoCheckboxes.Controls.Add(checkBox);
            }

            foreach (var extension in ListHandler.ImageExtensions)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = extension;
                checkBox.AutoSize = false;
                checkBox.Margin = new Padding(6, 3, 3, 3);
                checkBox.Size = new Size(66, 18);
                checkBox.Checked = settings.SelectedExtensions.Contains(extension);
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                flowPanelImageCheckboxes.Controls.Add(checkBox);
            }
        }

        private void btnSelectVideoExt_Click(object sender, EventArgs e)
        {
            foreach(Control control in flowPanelVideoCheckboxes.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void btnDeselectVideoExt_Click(object sender, EventArgs e)
        {
            foreach (Control control in flowPanelVideoCheckboxes.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void btnSelectImageExt_Click(object sender, EventArgs e)
        {
            foreach(Control control in flowPanelImageCheckboxes.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void btnDeselectImageExt_Click(object sender, EventArgs e)
        {
            foreach (Control control in flowPanelImageCheckboxes.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void SetupTooltips()
        {
            toolTipInfo.SetToolTip(cbEnableVideoFilter, "Use selected video extensions");
            toolTipInfo.SetToolTip(cbEnableImageFilter, "Use selected image extensions");
            toolTipInfo.SetToolTip(cbEnableScriptFilter, "Play only videos that have a funscript available");
        }
    }
}
