using FontAwesome.Sharp;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using Svg;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection;
using System.Text;
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

        private ContextMenuStrip contextThemeSelection;
        private ContextMenuStrip contextScaleSelection;
        private List<ThemeOption> _themeOptions;

        private Color _textColorBack;
        private Color _backColor;
        private Color _backColorLight;
        private Color _highlightColor;

        public InterfaceUserControl(SettingsModel settings)
        {
            InitializeComponent();

            this.settings = settings;

            checkboxes = new List<CheckBox> { cbDeleteButton, cbListAddButton, cbAddToFavButton, cbMoveToButton, cbShuffleButton, cbLoopButton, cbSourceSelector, cbTimerButton, cbSkipButton, cbTouchButton };
            iconBoxes = new List<PictureBox> { iconDelete, iconListAdd_PB, iconAddToFav, iconMoveTo, iconShuffle, iconLoop, iconSourceSelector_PB, iconTimer, iconSkip, iconTouch };
            InitializeUI();
            LoadSettings();
            BindControls();

            DPI.UpdateDPIScaling(this);
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);

            _textColorBack = ThemeManager.CurrentTheme.StTextColorBack;
            _backColor = ThemeManager.CurrentTheme.StBackColor;
            _backColorLight = ThemeManager.CurrentTheme.StBackColorLight;
            _highlightColor = ThemeManager.CurrentTheme.StHighlightColor;

            var renderer = new CustomRenderer()
            {
                BackgroundColor = _backColor,
                TextColor = _textColorBack,
                HighlightColor = _highlightColor
            };
            renderer.ApplyColors();
            contextThemeSelection = new ContextMenuStrip()
            {
                ShowImageMargin = false,
                ShowCheckMargin = false,
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };
            contextScaleSelection = new ContextMenuStrip()
            {
                ShowImageMargin = false,
                ShowCheckMargin = false,
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };

            panelIcons.BackColor = ThemeManager.CurrentTheme.FormBackColor;
            panelVisibilityToggles.BackColor = _backColorLight;
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
                    BackColor = _highlightColor,
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
            cbTimerButton.Checked = settings.ButtonStates[7];
            cbSkipButton.Checked = settings.ButtonStates[8];
            cbTouchButton.Checked = settings.ButtonStates[9];

            suppressCheckedChanged = false;

            cbShowButtonToPlayFromCurrentFolder.Checked = settings.ShowButtonToPlayFromCurrentFolder;
            cbEnableCustomScaling.Checked = settings.EnableCustomScaling;

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

            _themeOptions = themes
                .Select(kvp => new ThemeOption(kvp.Key, kvp.Value))
                .OrderBy(opt => opt.Name)
                .ToList();

            var match = _themeOptions.FirstOrDefault(o => o.Name == settings.SelectedTheme)
                        ?? _themeOptions.First(o => o.Name == "Light");


            btnThemeSelector.Text = match.Name;

            var scaleMatch = CustomScaling.ScalingFactors.FirstOrDefault(kvp => kvp.Value == settings.CustomScaling);
            btnScalingSelector.Text = scaleMatch.Key;
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
            cbTimerButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbSkipButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbTouchButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);

            cbShowButtonToPlayFromCurrentFolder.CheckedChanged += (s, e) =>
            {
                settings.ShowButtonToPlayFromCurrentFolder = cbShowButtonToPlayFromCurrentFolder.Checked;
            };

            cbEnableCustomScaling.CheckedChanged += (s, e) =>
            {
                settings.EnableCustomScaling = cbEnableCustomScaling.Checked;
            };

            btnThemeSelector.Click += (s, e) =>
            {
                btnThemeSelector_Click(s, e);
            };

            btnScalingSelector.Click += (s, e) =>
            {
                btnScaleSelector_Click(s, e);
            };
        }

        private void btnScaleSelector_Click(object s, EventArgs e)
        {
            contextScaleSelection.Items.Clear();

            foreach(var scaleValue in CustomScaling.ScalingFactors)
            {
                var item = contextScaleSelection.Items.Add(scaleValue.Key);
                item.Click += (s, _) =>
                {
                    settings.CustomScaling = scaleValue.Value;
                    btnScalingSelector.Text = scaleValue.Key;
                };
            }
            contextScaleSelection.Show(btnScalingSelector, new Point(0, 0), ToolStripDropDownDirection.AboveRight);
        }

        private void btnThemeSelector_Click(object s, EventArgs e)
        {
            contextThemeSelection.Items.Clear();
            
            foreach(var theme in _themeOptions)
            {
                var item = contextThemeSelection.Items.Add(theme.Name);
                item.Click += (s, _) =>
                {
                    btnThemeSelector.Text = theme.Name;

                    settings.SelectedTheme = theme.Name;
                };
                contextThemeSelection.Show(btnThemeSelector, new Point(0, btnThemeSelector.Height), ToolStripDropDownDirection.BelowRight);
            }
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
            LoadSettings();
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
            settings.ButtonStates[7] = cbTimerButton.Checked;
            settings.ButtonStates[8] = cbSkipButton.Checked;
            settings.ButtonStates[9] = cbTouchButton.Checked;

            RepositionButtons();
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
        private void UpdateSourceSelectorIcon()
        {
            if (SettingsHandler.SourceSelected)
            {
                ApplyIcon(iconSourceSelector_PB, SVGTemplates.SplitIconList, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);
            }
            else
            {
                ApplyIcon(iconSourceSelector_PB, SVGTemplates.SplitIconFolder, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);
            }
            iconSourceSelector_PB.BackColor = ThemeManager.CurrentTheme.FormBackColor;
        }
        private void UpdateListEditIcon()
        {
            if (MainFormData.presentInCustomList)
            {
                ApplyIcon(iconListAdd_PB, SVGTemplates.ListRemoveIcon, ThemeManager.CurrentTheme.ButtonIconColor, Color.Red);
            }
            else
            {
                ApplyIcon(iconListAdd_PB, SVGTemplates.ListAddIcon, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);
            }
            iconListAdd_PB.BackColor = ThemeManager.CurrentTheme.FormBackColor;
        }
        private void UpdateMoveFileIcon()
        {
            iconMoveTo.IconChar = SettingsHandler.FileCopy ? FontAwesome.Sharp.IconChar.Copy : FontAwesome.Sharp.IconChar.FileExport;
        }
        private void ApplyIcon(PictureBox target, string template, Color main, Color accent)
        {
            var svgMarkup = template
                .Replace("{{main}}", ColorTranslator.ToHtml(main))
                .Replace("{{accent}}", ColorTranslator.ToHtml(accent));

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svgMarkup));
            var svgDoc = SvgDocument.Open<SvgDocument>(stream); // SVG.NET
            using var bmp = svgDoc.Draw(20, 20);

            target.Image?.Dispose();
            target.Image = (Bitmap)bmp.Clone();
        }
    }
}
