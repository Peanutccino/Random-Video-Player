using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;


namespace RandomVideoPlayer.UserControls
{
    public partial class SyncUserControl : UserControl
    {
        private SettingsModel settings;
        public SyncUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

            this.settings = settings;

            BindControls();
            LoadSettings();
            SetupToolTips();
        }

        private void LoadSettings()
        {
            cbTimeCodeServer.Checked = settings.IsTimeCodeServerEnabled;
            cbScriptGraph.Checked = settings.IsGraphEnabled;
            foreach (var directory in settings.ScriptDirectories)
            {
                lvDirectories.Items.Add(directory);
            }
            cbShowScriptPath.Checked = settings.ShowScriptPath;
            cbHandleMultiAxis.Checked = settings.HandleMultiAxisScripts;
            cbUsingScriptPlayer.Checked = settings.UsingScriptPlayer;
            cbIncludeSubdirectoriesForScriptLoad.Checked = settings.IncludeSubdirectoriesForScriptLoad;
        }

        private void BindControls()
        {
            cbTimeCodeServer.CheckedChanged += (s, e) =>
            {
                settings.IsTimeCodeServerEnabled = cbTimeCodeServer.Checked;
            };

            cbScriptGraph.CheckedChanged += (s, e) =>
            {
                settings.IsGraphEnabled = cbScriptGraph.Checked;
            };

            cbShowScriptPath.CheckedChanged += (s, e) =>
            {
                settings.ShowScriptPath = cbShowScriptPath.Checked;
            };

            cbHandleMultiAxis.CheckedChanged += (s, e) =>
            {
                settings.HandleMultiAxisScripts = cbHandleMultiAxis.Checked;
            };

            cbUsingScriptPlayer.CheckedChanged += (s, e) =>
            {
                settings.UsingScriptPlayer = cbUsingScriptPlayer.Checked;
            };

            cbIncludeSubdirectoriesForScriptLoad.CheckedChanged += (s, e) =>
            {
                settings.IncludeSubdirectoriesForScriptLoad = cbIncludeSubdirectoriesForScriptLoad.Checked;
            };
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.UseDescriptionForTitle = true;
            folderBrowserDialog.Description = "Select a folder to add";
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath))
                {
                    lvDirectories.Items.Add(folderBrowserDialog.SelectedPath);
                    settings.ScriptDirectories.Add(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            if (lvDirectories.SelectedItems.Count > 0)
            {
                settings.ScriptDirectories.Remove(lvDirectories.SelectedItems[0].Text);
                lvDirectories.Items.Remove(lvDirectories.SelectedItems[0]);
            }
        }

        private void btnItemUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(-1);
        }

        private void btnItemDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(1);
        }
        private void btnAddLocal_Click(object sender, EventArgs e)
        {
            bool localExists = lvDirectories.Items.Cast<ListViewItem>().Any(item => item.Text.Equals("local", StringComparison.OrdinalIgnoreCase));

            if (!localExists)
            {
                lvDirectories.Items.Add("local");
                settings.ScriptDirectories.Add("local");
            }
        }
        private void MoveSelectedItem(int direction)
        {
            if (lvDirectories.SelectedItems.Count == 0) return;

            int selectedIndex = lvDirectories.SelectedIndices[0];
            int newIndex = selectedIndex + direction;

            if (newIndex < 0 || newIndex >= lvDirectories.Items.Count) return;

            ListViewItem selectedItem = lvDirectories.SelectedItems[0];
            string directoryPath = selectedItem.Text;

            lvDirectories.Items.RemoveAt(selectedIndex);
            settings.ScriptDirectories.RemoveAt(selectedIndex);

            lvDirectories.Items.Insert(newIndex, selectedItem);
            settings.ScriptDirectories.Insert(newIndex, directoryPath);

            lvDirectories.Items[newIndex].Selected = true;
            lvDirectories.Select();
        }

        private void SetupToolTips()
        {
            toolTipInfo.SetToolTip(btnAddFolder, "Add a folder to the list");
            toolTipInfo.SetToolTip(btnDeleteFolder, "Delete the selected folder from the list");
            toolTipInfo.SetToolTip(btnItemUp, "Move the selected folder up");
            toolTipInfo.SetToolTip(btnItemDown, "Move the selected folder down");
            toolTipInfo.SetToolTip(btnAddLocal, "Add the local placeholder to the list");
        }
        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);
            panelMain.Size = DPI.GetSizeScaled(panelMain.Size);
            panelDirectories.Size = DPI.GetSizeScaled(panelDirectories.Size);
            panel2.Size = DPI.GetSizeScaled(panel2.Size);
            flowLayoutPanel1.Size = DPI.GetSizeScaled(flowLayoutPanel1.Size);
            flowLayoutPanel2.Size = DPI.GetSizeScaled(flowLayoutPanel2.Size);

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

            cbTimeCodeServer.Size = DPI.GetSizeScaled(cbTimeCodeServer.Size);
            cbTimeCodeServer.Font = DPI.GetFontScaled(cbTimeCodeServer.Font);
            cbTimeCodeServer.Location = new Point((panelMain.Width / 2) - cbTimeCodeServer.Width - 3, 8);
            cbScriptGraph.Size = DPI.GetSizeScaled(cbScriptGraph.Size);
            cbScriptGraph.Font = DPI.GetFontScaled(cbScriptGraph.Font);
            cbScriptGraph.Location = new Point((panelMain.Width / 2) + 3, 8);

            lvDirectories.Size = DPI.GetSizeScaled(lvDirectories.Size);
            lvDirectories.Font = DPI.GetFontScaled(lvDirectories.Font);

            btnAddFolder.Size = DPI.GetSizeScaled(btnAddFolder.Size);
            btnDeleteFolder.Size = DPI.GetSizeScaled(btnDeleteFolder.Size);
            btnItemUp.Size = DPI.GetSizeScaled(btnItemUp.Size);
            btnItemDown.Size = DPI.GetSizeScaled(btnItemDown.Size);
            btnAddLocal.Size = DPI.GetSizeScaled(btnAddLocal.Size);

            cbShowScriptPath.Size = DPI.GetSizeScaled(cbShowScriptPath.Size);
            cbShowScriptPath.Font = DPI.GetFontScaled(cbShowScriptPath.Font);
            cbHandleMultiAxis.Size = DPI.GetSizeScaled(cbHandleMultiAxis.Size);
            cbHandleMultiAxis.Font = DPI.GetFontScaled(cbHandleMultiAxis.Font);
            cbUsingScriptPlayer.Size = DPI.GetSizeScaled(cbUsingScriptPlayer.Size);
            cbUsingScriptPlayer.Font = DPI.GetFontScaled(cbUsingScriptPlayer.Font);
            cbIncludeSubdirectoriesForScriptLoad.Size = DPI.GetSizeScaled(cbIncludeSubdirectoriesForScriptLoad.Size);
            cbIncludeSubdirectoriesForScriptLoad.Font = DPI.GetFontScaled(cbIncludeSubdirectoriesForScriptLoad.Font);
        }
    }
}
