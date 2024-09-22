using RandomVideoPlayer.Model;


namespace RandomVideoPlayer.UserControls
{
    public partial class SyncUserControl : UserControl
    {
        private SettingsModel settings;
        public SyncUserControl(SettingsModel settings)
        {
            InitializeComponent();
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
    }
}
