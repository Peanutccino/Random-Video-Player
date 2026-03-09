using FontAwesome.Sharp;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;


namespace RandomVideoPlayer.UserControls
{
    public partial class SyncUserControl : UserControl
    {
        private SettingsModel settings;
        private Color _textColor;
        private Color _backColorDark;
        private Color _highlightColor;

        private Color HoverColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 60);
        private Color PressedColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 20);

        private readonly Dictionary<IconButton, Color> idleColors = new();
        public SyncUserControl(SettingsModel settings)
        {
            InitializeComponent();

            DPI.UpdateDPIScaling(this);

            this.settings = settings;
            InitializeUI();
            BindControls();
            LoadSettings();
            SetupToolTips();
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);

            _textColor = ThemeManager.CurrentTheme.StTextColor;
            _backColorDark = ThemeManager.CurrentTheme.StBackColorDark;
            _highlightColor = ThemeManager.CurrentTheme.StHighlightColor;

            WireIconButton(btnAddFolder);
            WireIconButton(btnAddLocal);
            WireIconButton(btnDeleteFolder);
            WireIconButton(btnItemDown);
            WireIconButton(btnItemUp);
        }
        private void WireIconButton(IconButton btn)
        {
            btn.FlatAppearance.MouseOverBackColor = _backColorDark;
            btn.FlatAppearance.MouseDownBackColor = _backColorDark;
            btn.BackColor = _backColorDark;

            idleColors[btn] = _textColor;
            btn.IconColor = _textColor;

            btn.MouseEnter += (_, _) => btn.IconColor = HoverColor(btn);
            btn.MouseLeave += (_, _) => btn.IconColor = idleColors[btn];
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    btn.IconColor = PressedColor(btn);
            };
            btn.MouseUp += (_, _) =>
            {
                btn.IconColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn)
                    : idleColors[btn];
            };
            btn.GotFocus += (_, _) => btn.IconColor = HoverColor(btn);
            btn.LostFocus += (_, _) => btn.IconColor = idleColors[btn];
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
