using FontAwesome.Sharp;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using UserControl = System.Windows.Forms.UserControl;


namespace RandomVideoPlayer.UserControls
{
    public sealed record ThemeOption(string Name, Theme Theme);
    public partial class InterfaceUserControl : UserControl
    {
        private SettingsModel settings;
        private List<CheckBox> checkboxes;
        private List<PictureBox> iconBoxes;

        private PictureBox draggedPictureBox;
        private PictureBox dragPreview;
        private int dragIndex = -1;

        public InterfaceUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

            this.settings = settings;

            checkboxes = new List<CheckBox> { cbDeleteButton, cbListAddButton, cbAddToFavButton, cbMoveToButton, cbShuffleButton, cbLoopButton, cbSourceSelector, cbSkipButton, cbTouchButton };
            iconBoxes = new List<PictureBox> { iconDelete, iconListAdd_PB, iconAddToFav, iconMoveTo, iconShuffle, iconLoop, iconSourceSelector_PB, iconSkip, iconTouch };

            LoadSettings();
            BindControls();
        }

        private void icon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draggedPictureBox = sender as PictureBox;
                dragIndex = Convert.ToInt32(draggedPictureBox.Tag);

                dragPreview = new PictureBox
                {
                    Size = draggedPictureBox.Size,
                    Image = draggedPictureBox.Image,
                    BackColor = Color.DeepPink,
                    Location = draggedPictureBox.Location
                };
                panelIcons.Controls.Add(dragPreview);
                dragPreview.BringToFront();
            }
        }

        private void icon_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedPictureBox != null && e.Button == MouseButtons.Left)
            {
                var mousePosition = panelIcons.PointToClient(Cursor.Position);
                dragPreview.Location = new Point(mousePosition.X - dragPreview.Width / 2, dragPreview.Location.Y);
            }
        }
        private void icon_MouseUp(object sender, MouseEventArgs e)
        {
            if (draggedPictureBox != null)
            {
                var mousePosition = panelIcons.PointToClient(Cursor.Position);
                int newIndex = -1;

                var sortedControls = panelIcons.Controls.Cast<System.Windows.Forms.Control>()
                .Where(c => c is PictureBox && !string.IsNullOrWhiteSpace(c.Name))
                .OrderBy(c => c.Left)
                .ToList();

                for (int i = 0; i < sortedControls.Count; i++)
                {
                    var pictureBox = (PictureBox)sortedControls[i];

                    if (mousePosition.X > pictureBox.Left - 3 && mousePosition.X < pictureBox.Right + 3)
                    {
                        newIndex = i;
                        break;
                    }

                }

                if (newIndex >= sortedControls.Count - 1)
                {
                    newIndex = sortedControls.Count - 1;
                }
                else if (newIndex < 0)
                {
                    newIndex = 0;
                }

                int iconIndex = settings.ButtonOrder.IndexOf(dragIndex);
                settings.ButtonOrder.RemoveAt(iconIndex);
                settings.ButtonOrder.Insert(newIndex, dragIndex);

                panelIcons.Controls.Remove(dragPreview);
                dragPreview = null;
                draggedPictureBox = null;
                dragIndex = -1;

                RepositionButtons();
            }
        }

        private void LoadSettings()
        {
            suppressCheckedChanged = true;

            cbDeleteButton.Checked = settings.ButtonStates[0];
            cbListAddButton.Checked = settings.ButtonStates[1];
            cbAddToFavButton.Checked = settings.ButtonStates[2];
            cbMoveToButton.Checked = settings.ButtonStates[3];
            cbShuffleButton.Checked = settings.ButtonStates[4];
            cbLoopButton.Checked = settings.ButtonStates[5];
            cbSourceSelector.Checked = settings.ButtonStates[6];
            cbSkipButton.Checked = settings.ButtonStates[7];
            cbTouchButton.Checked = settings.ButtonStates[8];

            suppressCheckedChanged = false;

            cbShowButtonToPlayFromCurrentFolder.Checked = settings.ShowButtonToPlayFromCurrentFolder;

            UpdateSourceSelectorIcon();
            UpdateListEditIcon();
            UpdateMoveFileIcon();
            RepositionButtons();

            IReadOnlyDictionary<string, Theme> themes = ThemeLoader.LoadThemes();

            if (!themes.ContainsKey("Light"))
            {
                themes = themes.Concat(new[] {
            new KeyValuePair<string, Theme>("Light", ThemeDefaults.Light)}).ToDictionary(k => k.Key, k => k.Value);
            }

            var options = themes
                .Select(kvp => new ThemeOption(kvp.Key, kvp.Value))
                .OrderBy(opt => opt.Name)
                .ToList();

            comboThemes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboThemes.DisplayMember = nameof(ThemeOption.Name);
            comboThemes.ValueMember = nameof(ThemeOption.Theme);
            comboThemes.DataSource = options;

            string savedThemeName = settings.SelectedTheme;
            var match = options.FirstOrDefault(o => o.Name == savedThemeName)
                        ?? options.First(o => o.Name == "Light");
            comboThemes.SelectedItem = match;
        }
        private void BindControls()
        {
            cbDeleteButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbListAddButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbAddToFavButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbMoveToButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbShuffleButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbLoopButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbSourceSelector.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbSkipButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbTouchButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);

            cbShowButtonToPlayFromCurrentFolder.CheckedChanged += (s, e) =>
            {
                settings.ShowButtonToPlayFromCurrentFolder = cbShowButtonToPlayFromCurrentFolder.Checked;
            };

            comboThemes.SelectedIndexChanged += (s, e) =>
            {
                if (comboThemes.SelectedItem is ThemeOption selectedOption)
                {
                    settings.SelectedTheme = selectedOption.Name;
                }
            };
        }
        private bool suppressCheckedChanged = false;
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (suppressCheckedChanged) return;

            settings.ButtonStates[0] = cbDeleteButton.Checked;
            settings.ButtonStates[1] = cbListAddButton.Checked;
            settings.ButtonStates[2] = cbAddToFavButton.Checked;
            settings.ButtonStates[3] = cbMoveToButton.Checked;
            settings.ButtonStates[4] = cbShuffleButton.Checked;
            settings.ButtonStates[5] = cbLoopButton.Checked;
            settings.ButtonStates[6] = cbSourceSelector.Checked;
            settings.ButtonStates[7] = cbSkipButton.Checked;
            settings.ButtonStates[8] = cbTouchButton.Checked;

            //UpdateIconVisibility();
            RepositionButtons();
        }
        private void InitializeDynamicButtons(int buttonCount)
        {
            for (int i = 0; i < buttonCount; i++) //Button move up
            {
                FontAwesome.Sharp.IconButton button = new FontAwesome.Sharp.IconButton();
                button.IconChar = FontAwesome.Sharp.IconChar.CircleUp;
                button.IconFont = FontAwesome.Sharp.IconFont.Solid;
                button.IconSize = 28;
                button.IconColor = Color.Indigo;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Width = 24;
                button.Height = 28;
                button.Margin = new Padding(3);

                button.Tag = i;

                button.Click += new EventHandler(ButtonUp_Click);
                this.flowPanel.Controls.Add(button);
            }
            for (int i = 0; i < buttonCount; i++) //Button move down
            {
                FontAwesome.Sharp.IconButton button = new FontAwesome.Sharp.IconButton();
                button.IconChar = FontAwesome.Sharp.IconChar.CircleDown;
                button.IconFont = FontAwesome.Sharp.IconFont.Solid;
                button.IconSize = 28;
                button.IconColor = Color.Indigo;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Width = 24;
                button.Height = 28;
                button.Margin = new Padding(3);

                button.Tag = i;

                button.Click += new EventHandler(ButtonDown_Click);
                this.flowPanel.Controls.Add(button);
            }
        }
        private void ButtonUp_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int buttonIndex = (int)clickedButton.Tag;

            if (buttonIndex == 0) return;

            int buttonIndexEntry = settings.ButtonOrder[buttonIndex];
            settings.ButtonOrder.RemoveAt(buttonIndex);
            settings.ButtonOrder.Insert(buttonIndex - 1, buttonIndexEntry);

            RepositionButtons();
        }
        private void ButtonDown_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int buttonIndex = (int)clickedButton.Tag;

            if (buttonIndex == settings.ButtonStates.Length - 1) return;

            int buttonIndexEntry = settings.ButtonOrder[buttonIndex];
            settings.ButtonOrder.RemoveAt(buttonIndex);
            settings.ButtonOrder.Insert(buttonIndex + 1, buttonIndexEntry);

            RepositionButtons();
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            settings.ButtonOrder.Clear();

            for (int i = 0; i < SettingsHandler.ButtonStates.Length; i++)
            {
                settings.ButtonOrder.Add(i);
            }
            for (int i = 0; i < SettingsHandler.ButtonStates.Length; i++)
            {
                settings.ButtonStates[i] = true;
            }
            //UpdateIconVisibility();
            LoadSettings();
        }
        private void RepositionButtons()
        {
            int x = 3; //Starting x position
            int y = 3; //Starting Y position
            int margin = 6; //Spacing

            int xIcon = 3;
            int yIcon = 3;

            foreach (int index in settings.ButtonOrder)
            {
                CheckBox cbx = checkboxes[index];
                cbx.Location = new Point(x, y);
                x += cbx.Width + margin;

                PictureBox ipx = iconBoxes[index];
                ipx.Location = new Point(xIcon, yIcon);
                xIcon += ipx.Width + margin;

            }
        }

        private void UpdateIconVisibility()
        {
            iconDelete.Visible = settings.ButtonStates[0];
            iconListAdd_PB.Visible = settings.ButtonStates[1];
            iconAddToFav.Visible = settings.ButtonStates[2];
            iconMoveTo.Visible = settings.ButtonStates[3];
            iconShuffle.Visible = settings.ButtonStates[4];
            iconLoop.Visible = settings.ButtonStates[5];
            iconSourceSelector_PB.Visible = settings.ButtonStates[6];
            iconSkip.Visible = settings.ButtonStates[7];
            iconTouch.Visible = settings.ButtonStates[8];
        }

        private void UpdateSourceSelectorIcon()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = "RandomVideoPlayer.Resources.SplitIconFolderHighlight.png";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                try
                {
                    if (stream != null)
                    {
                        var image = Image.FromStream(stream);
                        iconSourceSelector_PB.Image = image;

                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to load SplitIcon");
                }
            }
        }

        private void UpdateListEditIcon()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = "RandomVideoPlayer.Resources.list-colored-add.png";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                try
                {
                    if (stream != null)
                    {
                        var image = Image.FromStream(stream);
                        iconListAdd_PB.Image = image;
                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to load ListEdit icon");
                }
            }
        }
        private void UpdateMoveFileIcon()
        {
            iconMoveTo.IconChar = SettingsHandler.FileCopy ? FontAwesome.Sharp.IconChar.Copy : FontAwesome.Sharp.IconChar.FileExport;
        }

        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);

            panelButtonPreview.Size = DPI.GetSizeScaled(panelButtonPreview.Size);
            panelIcons.Size = DPI.GetSizeScaled(panelIcons.Size);
            panelVisibilityToggles.Size = DPI.GetSizeScaled(panelVisibilityToggles.Size);
            panel1.Size = DPI.GetSizeScaled(panel1.Size);
            panel3.Size = DPI.GetSizeScaled(panel3.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);
            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);
            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);

            foreach(PictureBox pictureBox in panelIcons.Controls)
            {
                pictureBox.Size = DPI.GetSizeScaled(pictureBox.Size);
                pictureBox.Font = DPI.GetFontScaled(pictureBox.Font);
            }
            foreach(CheckBox checkBox in panelVisibilityToggles.Controls)
            {
                checkBox.Size = DPI.GetSizeScaled(checkBox.Size);
                checkBox.Font = DPI.GetFontScaled(checkBox.Font);
            }

            cbShowButtonToPlayFromCurrentFolder.Size = DPI.GetSizeScaled(cbShowButtonToPlayFromCurrentFolder.Size);
            cbShowButtonToPlayFromCurrentFolder.Font = DPI.GetFontScaled(cbShowButtonToPlayFromCurrentFolder.Font);

            btnRestore.Size = DPI.GetSizeScaled(btnRestore.Size);
            btnRestore.Font = DPI.GetFontScaled(btnRestore.Font);
            btnRestore.Location = new Point(panelButtonPreview.Width - btnRestore.Width - 3, panelButtonPreview.Height - btnRestore.Height - 3);
        }
    }
}
