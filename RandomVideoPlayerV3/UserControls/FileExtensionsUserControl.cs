using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class FileExtensionsUserControl : UserControl
    {
        private SettingsModel settings;
        public FileExtensionsUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

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

            rbDateCreated.CheckedChanged += (s, e) =>
            {
                settings.SortCreated = rbDateCreated.Checked;
            };
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
                RoundedCheckBox checkBox = new RoundedCheckBox(); ;
                checkBox.Text = extension;
                checkBox.AutoSize = false;
                checkBox.Margin = new Padding(6, 3, 3, 3);
                checkBox.Size = new Size(66, 22);
                checkBox.Checked = settings.SelectedExtensions.Contains(extension);
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                flowPanelVideoCheckboxes.Controls.Add(checkBox);
                checkBox.Font = DPI.GetFontScaled(checkBox.Font);
            }

            foreach (var extension in ListHandler.ImageExtensions)
            {
                RoundedCheckBox checkBox = new RoundedCheckBox();
                checkBox.Text = extension;
                checkBox.AutoSize = false;
                checkBox.Margin = new Padding(6, 3, 3, 3);
                checkBox.Size = new Size(66, 22);
                checkBox.Checked = settings.SelectedExtensions.Contains(extension);
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                flowPanelImageCheckboxes.Controls.Add(checkBox);
                checkBox.Font = DPI.GetFontScaled(checkBox.Font);

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

        private void UpdateDPIScaling()
        {
            this.MinimumSize = DPI.GetSizeScaled(this.MinimumSize);
            this.Size = DPI.GetSizeScaled(this.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            label4.Size = DPI.GetSizeScaled(label4.Size);
            label4.Font = DPI.GetFontScaled(label4.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);

            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);

            panelVideoExtensionContainer.Size = DPI.GetSizeScaled(panelVideoExtensionContainer.Size);

            btnSelectVideoExt.Size = DPI.GetSizeScaled(btnSelectVideoExt.Size);
            btnSelectVideoExt.Font = DPI.GetFontScaled(btnSelectVideoExt.Font);
            btnSelectVideoExt.Location = new Point(panelVideoExtensionContainer.Width - btnSelectVideoExt.Width - 3, 3);

            btnDeselectVideoExt.Size = DPI.GetSizeScaled(btnDeselectVideoExt.Size);
            btnDeselectVideoExt.Font = DPI.GetFontScaled(btnDeselectVideoExt.Font);
            btnDeselectVideoExt.Location = new Point(panelVideoExtensionContainer.Width - btnDeselectVideoExt.Width - 3, panelVideoExtensionContainer.Height - btnDeselectVideoExt.Height - 3);

            flowPanelVideoCheckboxes.Width = panelVideoExtensionContainer.Width - btnSelectVideoExt.Width - 20;

            panelImageExtensionContainer.Size = DPI.GetSizeScaled(panelImageExtensionContainer.Size);

            btnSelectImageExt.Size = DPI.GetSizeScaled(btnSelectImageExt.Size);
            btnSelectImageExt.Font = DPI.GetFontScaled(btnSelectImageExt.Font);
            btnSelectImageExt.Location = new Point(panelImageExtensionContainer.Width - btnSelectImageExt.Width - 3, 3);

            btnDeselectImageExt.Size = DPI.GetSizeScaled(btnDeselectImageExt.Size);
            btnDeselectImageExt.Font = DPI.GetFontScaled(btnDeselectImageExt.Font);
            btnDeselectImageExt.Location = new Point(panelImageExtensionContainer.Width - btnDeselectImageExt.Width - 3, panelImageExtensionContainer.Height - btnDeselectImageExt.Height - 3);

            flowPanelImageCheckboxes.Width = panelImageExtensionContainer.Width - btnSelectImageExt.Width - 20;

            cbFilterApply.Size = DPI.GetSizeScaled(cbFilterApply.Size);
            cbFilterApply.Font = DPI.GetFontScaled(cbFilterApply.Font);

            panel1.Size = DPI.GetSizeScaled(panel1.Size);

            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);

            cbEnableVideoFilter.Size = new Size(30,30);
            cbEnableImageFilter.Size = new Size(30, 30);
            cbEnableScriptFilter.Size = new Size(30, 30);

            panel2.Size = DPI.GetSizeScaled(panel2.Size);

            lbl4.Size = DPI.GetSizeScaled(lbl4.Size);
            lbl4.Font = DPI.GetFontScaled(lbl4.Font);

            rbDateCreated.Size = DPI.GetSizeScaled(rbDateCreated.Size);
            rbDateCreated.Font = DPI.GetFontScaled(rbDateCreated.Font);

            rbDateModified.Size = DPI.GetSizeScaled(rbDateModified.Size);
            rbDateModified.Font = DPI.GetFontScaled(rbDateModified.Font);
        }
    }
}
