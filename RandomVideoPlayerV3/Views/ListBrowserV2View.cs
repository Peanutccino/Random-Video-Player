using FontAwesome.Sharp;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using Svg;
using System.Collections.Concurrent;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace RandomVideoPlayer.Views
{
    public partial class ListBrowserV2View : Form
    {
        #region Variables
        FormResize formResize = new FormResize();

        private readonly List<FileSystemInfo> _listItemFileExplorerEntries = new();

        private readonly Dictionary<string, int> _imageIndexCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, byte> _pendingThumbs = new();
        private (int Start, int End) _cachedRange = (-1, -1);
        private ImageList _thumbs = new();
        private Size _thumbSize = new(110, 82);
        private bool _thumbPreviewEnabled = false;
        readonly float aspectRatio = 110f / 82f;
        private const int ThumbMin = 48;
        private const int ThumbMax = 256;
        private const int SliderDefault = 10;

        private ContextMenuStrip contextHiddenPath;
        private ContextMenuStrip contextVideoExtensions;
        private ContextMenuStrip contextImageExtensions;

        private Color _textColor = Color.Black;
        private Color _textColorMainAccent = Color.Black;
        private Color _textColorSideAccent = Color.Black;
        private Color _backColorMainLight = Color.White;
        private Color _backColorMainDark = Color.LightGray;
        private Color _backColorSideLight = Color.White;
        private Color _backColorSideDark = Color.Gray;
        private Color _accentColorMain = Color.Pink;
        private Color _accentColorSide = Color.Pink;
        private Color _highlightColorMain = Color.OrangeRed;
        private Color _highlightColorSide = Color.Olive;
        private Color _pressedColorMain => Lighten(_highlightColorMain, -30, _highlightColorMain);
        private Color _hoverColorMain => Lighten(_highlightColorMain, 50, _highlightColorMain);
        private Color _pressedColorSide => Lighten(_highlightColorMain, -30, _highlightColorSide);
        private Color _hoverColorSide => Lighten(_highlightColorMain, 50, _highlightColorSide);
        private Color HoverColor(IconButton btn, Color highlight) => Lighten(idleColors[btn], 60, highlight);
        private Color PressedColor(IconButton btn, Color highlight) => Lighten(idleColors[btn], 20, highlight);

        private readonly Dictionary<IconButton, Color> idleColors = new();
        private readonly HashSet<IconButton> highlightedButtons = new();

        private readonly List<BreadcrumbPathSegment> _segments = new();
        private sealed record BreadcrumbPathSegment(string DisplayText, string FullPath);
        private List<Label> _dirLabels = new();
        private List<Label> _favLabels = new();
        private string _selectedPath { get; set; }
        private View _viewState { get; set; } = View.SmallIcon;
        private List<string> _tempFavoritesList = new();
        private string _favoriteSelected;
        private Dictionary<IconButton, bool> _filterButtons = new();

        private FileSystemInfo? _dragCandidate;
        private Point _dragStartPoint;
        private const string DummyPayload = "Payload";

        private ToolTip toolTipInfo;

        private List<string> _extensionFilter { get; set; }
        private List<string> _localCustomList { get; set; }
        private bool _showFullPathCustomList = false;
        private IEnumerable<(FileSystemInfo Entry, bool IsDirectory)> GetSelectedEntries() =>
                    lvFileExplore.SelectedIndices
                        .Cast<int>()
                        .Select(i => _listItemFileExplorerEntries[i])
                        .Select(fsi => (Entry: fsi, IsDirectory: fsi is DirectoryInfo));

        #endregion

        public ListBrowserV2View()
        {
            InitializeComponent();

            this.Padding = new Padding(formResize.BorderSize);
            this.BackColor = Color.FromArgb(255, 221, 26);

            InitializeUI();
            LoadSettings();
        }

        private void ListBrowserV2View_Load(object sender, EventArgs e)
        {
            SwitchView(_viewState);
            RenderDirectoryBreadcrumbs();
            RenderFavoriteBreadcrumbs();
            LoadFolder(_selectedPath);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SaveSettings();
            this.Close();
        }

        private void lvFileExplore_ItemActivate(object sender, EventArgs e)
        {
            if (lvFileExplore.SelectedIndices.Count == 0)
                return;

            var fsi = _listItemFileExplorerEntries[lvFileExplore.SelectedIndices[0]];
            if (fsi is DirectoryInfo dir)
                LoadFolder(dir.FullName);
        }

        private void btnResetSize_Click(object sender, EventArgs e)
        {
            sliderZoom.Value = SliderDefault;
        }

        private void sliderZoom_ValueChanged(object sender, EventArgs e)
        {
            ResizeTileFromSlider(sliderZoom.Value);
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            SwitchView(View.Details);
        }

        private void btnViewSmallGrid_Click(object sender, EventArgs e)
        {
            SwitchView(View.SmallIcon);
        }

        private void btnViewLargeGrid_Click(object sender, EventArgs e)
        {
            SwitchView(View.LargeIcon);
        }

        private void btnFilterVideo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleFilter(sender as IconButton);
                LoadFolder(_selectedPath);
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextVideoExtensions.Show(btnFilterVideo, new Point(0, btnFilterVideo.Height), ToolStripDropDownDirection.BelowRight);
            }
        }

        private void btnFilterImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleFilter(sender as IconButton);
                LoadFolder(_selectedPath);
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextImageExtensions.Show(btnFilterImage, new Point(0, btnFilterImage.Height), ToolStripDropDownDirection.BelowRight);
            }
        }

        private void btnFilterScript_MouseDown(object sender, MouseEventArgs e)
        {
            ToggleFilter(sender as IconButton);
            LoadFolder(_selectedPath);
        }

        private void btnDeleteFav_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_favoriteSelected))
            {
                var tempFavCache = new List<string>();
                tempFavCache.AddRange(_tempFavoritesList);
                foreach (var fav in tempFavCache)
                {
                    if (fav == _favoriteSelected)
                        _tempFavoritesList.Remove(fav);
                }

                RenderFavoriteBreadcrumbs();
            }
        }

        private void btnAddFav_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_selectedPath))
                _tempFavoritesList.Add(_selectedPath);

            RenderFavoriteBreadcrumbs();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedPath)) return;

            FillCustomListFromDirectory(_selectedPath);
            DisplayCustomList();
            UpdateListInfo();
            ListHandler.ListChanged = true;
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            FillCustomListFromSelection();
            DisplayCustomList();
            UpdateListInfo();
            ListHandler.ListChanged = true;
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            _localCustomList.Clear();
            lvCustomList.Items.Clear();
            ListHandler.ClearCustomList();
            ListHandler.ListNameTemp = "Unspecified";
            ListHandler.ListChanged = false;
            UpdateListInfo();
        }

        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            if (lvCustomList.SelectedIndices.Count <= 0) return;

            foreach (var selectedItem in lvCustomList.SelectedItems.Cast<ListViewItem>().ToList())
            {
                _localCustomList.RemoveAt(selectedItem.Index);
                lvCustomList.Items.Remove(selectedItem);
            }
            UpdateListInfo();
        }

        private void btnDelDuplicates_Click(object sender, EventArgs e)
        {
            var filteredList = _localCustomList
                .GroupBy(path => Path.GetFileName(path))
                .Select(g => g.First())
                .OrderBy(path => _localCustomList.IndexOf(path))
                .ToList();

            _localCustomList = filteredList;
            DisplayCustomList();
            ListHandler.ListChanged = true;
            UpdateListInfo();
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            LoadListView loadListView = new LoadListView();
            loadListView.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = loadListView.ShowDialog();

            if (result == DialogResult.OK)
            {
                var strings = new List<string>();
                var entriesFromTXT = File.ReadLines(loadListView.ListToLoad);

                foreach (string str in entriesFromTXT)
                {
                    strings.Add(str);
                }
                _localCustomList = strings;
                DisplayCustomList();

                string listName = Path.GetFileNameWithoutExtension(loadListView.ListToLoad);

                ListHandler.ListNameTemp = listName;
                ListHandler.ListChanged = false;

                UpdateListInfo();
            }
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            SaveListView saveListView = new SaveListView();
            saveListView.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = saveListView.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    var pathToList = PathHandler.PathToListFolder + @"\" + saveListView.ListToSave + ".txt";
                    File.WriteAllLines(pathToList, _localCustomList, Encoding.UTF8);

                    ListHandler.ListNameTemp = saveListView.ListToSave;
                    ListHandler.ListChanged = false;

                    UpdateListInfo();
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to save list");
                    MessageBox.Show($"Failed to save list: {ex}");
                    throw;
                }
            }
        }

        private void btnAddFromPlaylist_Click(object sender, EventArgs e)
        {
            _localCustomList.AddRange(ListHandler.PlayList);
            DisplayCustomList();
            ListHandler.ListChanged = true;
            UpdateListInfo();
        }

        private void btnMoveList_Click(object sender, EventArgs e)
        {
            MoveListForm moveListForm = new MoveListForm(_localCustomList);
            moveListForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult moveResult = moveListForm.ShowDialog();

            if (moveResult == DialogResult.OK)
            {
                _localCustomList = moveListForm.movedFilePaths;
                DisplayCustomList();
                UpdateListInfo();

                MessageBox.Show("Remember to save/overwrite the updated list!");
            }
        }

        private void cbFullPath_CheckedChanged(object sender, EventArgs e)
        {
            _showFullPathCustomList = cbFullPath.Checked;
            DisplayCustomList();
        }

        private void BreadcrumbPath_Click(object sender, EventArgs e)
        {
            var targetPath = (string)((Label)sender).Tag;
            LoadFolder(targetPath);
        }

        private void EllipsisPath_Click(object sender, EventArgs e)
        {
            var hidden = (List<BreadcrumbPathSegment>)((Label)sender).Tag;
            contextHiddenPath.Items.Clear();
            foreach (var segment in hidden)
            {
                var item = contextHiddenPath.Items.Add(segment.DisplayText);
                item.Tag = segment.FullPath;
                item.Click += (s, _) => LoadFolder((string)((ToolStripItem)s).Tag);
            }
            contextHiddenPath.Show(Cursor.Position);
        }
        private void Directory_DoubleClick(object? sender, EventArgs e)
        {
            var targetPath = (string)((Label)sender).Tag;
            LoadFolder(targetPath);
        }

        #region Settings
        private void LoadSettings()
        {
            _selectedPath = FileManipulation.GetFirstExistingPath(
              () => PathHandler.TempRecentFolder,
              () => PathHandler.DefaultFolder,
              () => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            _tempFavoritesList.AddRange(ListHandler.FavoriteFolderList);

            _thumbPreviewEnabled = SettingsHandler.ThumbnailPreviewEnabled;

            _extensionFilter = new List<string>(ListHandler.ExtensionFilterForList);

            _localCustomList = (bool)ListHandler.CustomList.Any() ? new List<string>(ListHandler.CustomList) : new List<string>();

            DisplayCustomList();
            UpdateListInfo();
            InitializeFilterContextMenus();
        }
        private void SaveSettings()
        {
            if (_tempFavoritesList?.Any() == true)
                ListHandler.FavoriteFolderList = _tempFavoritesList;
            else
                ListHandler.ClearFavoriteFolderList();

            if (_localCustomList?.Any() == true)
                ListHandler.CustomList = _localCustomList;

            if (!string.IsNullOrWhiteSpace(_selectedPath))
                PathHandler.TempRecentFolder = _selectedPath;

            SettingsHandler.ThumbSizeFactorListBrowser = sliderZoom.Value;
            SettingsHandler.ListBrowserViewState = _viewState;
            ListHandler.ExtensionFilterForList = _extensionFilter;
            SettingsHandler.ShowFullPathCustomList = _showFullPathCustomList;


            PathHandler.TempRecentFolder = _selectedPath;
        }
        #endregion

        #region Themepark
        private void InitializeUI()
        {
            ThemeManager.ApplyThemeLBV2(this);

            _thumbs.ColorDepth = ColorDepth.Depth32Bit;
            _thumbs.ImageSize = _thumbSize;

            lvFileExplore.LargeImageList = _thumbs;
            lvFileExplore.SmallImageList = _thumbs;

            _textColor = ThemeManager.CurrentTheme.LbTextColor;
            _textColorMainAccent = ThemeManager.CurrentTheme.LbTextColorMainAccent;
            _textColorSideAccent = ThemeManager.CurrentTheme.LbTextColorSideAccent;
            _backColorMainLight = ThemeManager.CurrentTheme.LbBackColorMainLight;
            _backColorMainDark = ThemeManager.CurrentTheme.LbBackColorMainDark;
            _backColorSideLight = ThemeManager.CurrentTheme.LbBackColorSideLight;
            _backColorSideDark = ThemeManager.CurrentTheme.LbBackColorSideDark;
            _accentColorMain = ThemeManager.CurrentTheme.LbAccentColorMain;
            _accentColorSide = ThemeManager.CurrentTheme.LbAccentColorSide;
            _highlightColorMain = ThemeManager.CurrentTheme.LbHighlightColorMain;
            _highlightColorSide = ThemeManager.CurrentTheme.LbHighlightColorSide;

            sliderZoom.Value = SettingsHandler.ThumbSizeFactorListBrowser;
            _viewState = SettingsHandler.ListBrowserViewState;

            var renderer = new CustomRenderer()
            {
                BackgroundColor = _backColorMainLight,
                TextColor = _textColor,
                HighlightColor = _highlightColorMain,
            };
            renderer.ApplyColors();
            contextHiddenPath = new ContextMenuStrip()
            {
                ShowImageMargin = false,
                ShowCheckMargin = false,
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };
            contextVideoExtensions = new ContextMenuStrip()
            {
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };
            contextVideoExtensions.Closing += (s, e) => e.Cancel = e.CloseReason == ToolStripDropDownCloseReason.ItemClicked;

            contextImageExtensions = new ContextMenuStrip()
            {
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };
            contextImageExtensions.Closing += (s, e) => e.Cancel = e.CloseReason == ToolStripDropDownCloseReason.ItemClicked;

            EnsureBaselineIcons();
            WireIconButtonMain(btnResetSize);
            WireIconButtonMain(btnViewList);
            WireIconButtonMain(btnViewSmallGrid);
            WireIconButtonMain(btnViewLargeGrid);
            WireIconButtonMain(btnFilterVideo);
            WireIconButtonMain(btnFilterImage);
            WireIconButtonMain(btnFilterScript);
            WireIconButtonMain(btnAddFav);
            WireIconButtonMain(btnDeleteFav);
            WireIconButtonSide(btnClearList);
            WireIconButtonMain(btnAddAll);
            WireIconButtonMain(btnAddSelected);

            WireIconButtonSide(btnClearSelected);
            WireIconButtonSide(btnDelDuplicates);
            WireIconButtonSide(btnLoadList);
            WireIconButtonSide(btnSaveList);
            WireIconButtonSide(btnAddFromPlaylist);
            WireIconButtonSide(btnMoveList);

            _filterButtons.Add(btnFilterVideo, ListHandler.FilterVideoEnabled);
            _filterButtons.Add(btnFilterImage, ListHandler.FilterImageEnabled);
            _filterButtons.Add(btnFilterScript, ListHandler.FilterScriptEnabled);
            ToggleFilter(null);

            ApplyIcon(btnStart, SVGTemplates.PlayIcon, _textColorMainAccent, _hoverColorMain);
            ApplyIcon(btnBack, SVGTemplates.BackIcon, _textColorMainAccent, _hoverColorMain, 24, 24);

            toolTipInfo = new ToolTip()
            {
                BackColor = _backColorMainLight,
                ForeColor = _textColor,
            };
            SetupTooltips();
            UpdateDPIScaling(this);
        }
        private void HighLightDrive(string path)
        {
            string drive = path.Substring(0, 3);

            foreach (var dir in _dirLabels)
            {
                if (dir.Tag.ToString() == drive)
                {
                    dir.BackColor = lvFileExplore.BackColor;
                }
                else
                {
                    dir.BackColor = flowPanelDir.BackColor;
                }
            }
        }

        private void SwitchView(View targetView)
        {
            lvFileExplore.BeginUpdate();
            lvFileExplore.View = targetView;
            _viewState = targetView;

            switch (targetView)
            {
                case View.Details:
                    lvFileExplore.Columns[0].Width = lvFileExplore.ClientSize.Width - 30;
                    SetHighlight(btnViewList, true);
                    SetHighlight(btnViewSmallGrid, false);
                    SetHighlight(btnViewLargeGrid, false);
                    LoadFolder(_selectedPath);
                    break;
                case View.SmallIcon:
                    SetHighlight(btnViewList, false);
                    SetHighlight(btnViewSmallGrid, true);
                    SetHighlight(btnViewLargeGrid, false);
                    LoadFolder(_selectedPath);
                    break;
                case View.LargeIcon:
                    SetHighlight(btnViewList, false);
                    SetHighlight(btnViewSmallGrid, false);
                    SetHighlight(btnViewLargeGrid, true);
                    LoadFolder(_selectedPath);
                    break;
            }

            lvFileExplore.EndUpdate();
            lvFileExplore.Invalidate();
        }
        private void WireIconButtonMain(IconButton btn)
        {
            btn.FlatAppearance.MouseOverBackColor = _backColorMainLight;
            btn.FlatAppearance.MouseDownBackColor = _backColorMainLight;

            idleColors[btn] = ThemeManager.CurrentTheme.LbTextColor;
            btn.IconColor = ThemeManager.CurrentTheme.LbTextColor;
            btn.ForeColor = ThemeManager.CurrentTheme.LbTextColor;

            btn.MouseEnter += (_, _) =>
            {
                btn.IconColor = HoverColor(btn, _highlightColorMain);
                btn.ForeColor = HoverColor(btn, _highlightColorMain);
            };
            btn.MouseLeave += (_, _) =>
            {
                btn.IconColor = idleColors[btn];
                btn.ForeColor = idleColors[btn];
            };
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    btn.IconColor = PressedColor(btn, _highlightColorMain);
                    btn.ForeColor = PressedColor(btn, _highlightColorMain);
                }

            };
            btn.MouseUp += (_, _) =>
            {
                btn.IconColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn, _highlightColorMain)
                    : idleColors[btn];
                btn.ForeColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn, _highlightColorMain)
                    : idleColors[btn];
            };
            btn.GotFocus += (_, _) =>
            {
                btn.IconColor = HoverColor(btn, _highlightColorMain);
                btn.ForeColor = HoverColor(btn, _highlightColorMain);
            };
            btn.LostFocus += (_, _) =>
            {
                btn.IconColor = idleColors[btn];
                btn.ForeColor = idleColors[btn];
            };
        }
        private void WireIconButtonSide(IconButton btn)
        {
            btn.FlatAppearance.MouseOverBackColor = _backColorSideDark;
            btn.FlatAppearance.MouseDownBackColor = _backColorSideDark;

            idleColors[btn] = ThemeManager.CurrentTheme.LbTextColor;
            btn.IconColor = ThemeManager.CurrentTheme.LbTextColor;
            btn.ForeColor = ThemeManager.CurrentTheme.LbTextColor;

            btn.MouseEnter += (_, _) =>
            {
                btn.IconColor = HoverColor(btn, _highlightColorSide);
                btn.ForeColor = HoverColor(btn, _highlightColorSide);
            };
            btn.MouseLeave += (_, _) =>
            {
                btn.IconColor = idleColors[btn];
                btn.ForeColor = idleColors[btn];
            };
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    btn.IconColor = PressedColor(btn, _highlightColorSide);
                    btn.ForeColor = PressedColor(btn, _highlightColorSide);
                }
            };
            btn.MouseUp += (_, _) =>
            {
                btn.IconColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn, _highlightColorSide)
                    : idleColors[btn];
                btn.ForeColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn, _highlightColorSide)
                    : idleColors[btn];
            };
            btn.GotFocus += (_, _) =>
            {
                btn.IconColor = HoverColor(btn, _highlightColorSide);
                btn.ForeColor = HoverColor(btn, _highlightColorSide);
            };
            btn.LostFocus += (_, _) =>
            {
                btn.IconColor = idleColors[btn];
                btn.ForeColor = idleColors[btn];
            };
        }

        private void SetHighlight(IconButton btn, bool highlight, Color? customColor = null)
        {
            if (highlight)
                highlightedButtons.Add(btn);
            else
                highlightedButtons.Remove(btn);

            var color = customColor ?? _highlightColorMain;

            idleColors[btn] = highlight ? color
                                        : _textColor;

            btn.IconColor = idleColors[btn];
        }

        void ResizeTileFromSlider(int sliderValue)
        {
            int newWidth = ThumbMin + (sliderValue * (ThumbMax - ThumbMin)) / 100;
            int newHeight = (int)Math.Round(newWidth / aspectRatio);
            lblZoomFactor.Text = $"{sliderValue}%";
            if (_viewState == View.SmallIcon) lvFileExplore.Columns[0].Width = (newWidth * 3);

            ApplyThumbnailSize(newWidth, newHeight);
        }
        private void ToggleFilter(IconButton? btn)
        {
            switch (btn)
            {
                case IconButton _ when btn == btnFilterVideo:
                    _filterButtons[btn] = !_filterButtons[btn];
                    ListHandler.FilterVideoEnabled = _filterButtons[btn];
                    _filterButtons[btnFilterScript] = _filterButtons[btn] ? false : _filterButtons[btnFilterScript];
                    ListHandler.FilterScriptEnabled = _filterButtons[btnFilterScript];
                    break;
                case IconButton _ when btn == btnFilterImage:
                    _filterButtons[btn] = !_filterButtons[btn];
                    ListHandler.FilterImageEnabled = _filterButtons[btn];
                    _filterButtons[btnFilterScript] = _filterButtons[btn] ? false : _filterButtons[btnFilterScript];
                    ListHandler.FilterScriptEnabled = _filterButtons[btnFilterScript];
                    break;
                case IconButton _ when btn == btnFilterScript:
                    _filterButtons[btn] = !_filterButtons[btn];
                    ListHandler.FilterScriptEnabled = _filterButtons[btn];
                    _filterButtons[btnFilterVideo] = _filterButtons[btn] ? false : _filterButtons[btnFilterVideo];
                    ListHandler.FilterVideoEnabled = _filterButtons[btnFilterVideo];
                    _filterButtons[btnFilterImage] = _filterButtons[btn] ? false : _filterButtons[btnFilterImage];
                    ListHandler.FilterImageEnabled = _filterButtons[btnFilterImage];
                    break;
            }

            foreach (var button in _filterButtons)
            {
                SetHighlight(button.Key, button.Value);
            }
        }
        private void SetupTooltips()
        {
            toolTipInfo.SetToolTip(btnResetSize, "Restore tile size");
            toolTipInfo.SetToolTip(sliderZoom, "Change tile size");

            toolTipInfo.SetToolTip(btnViewList, "Change view to list");
            toolTipInfo.SetToolTip(btnViewSmallGrid, "Change view to grid");
            toolTipInfo.SetToolTip(btnViewLargeGrid, "Change view to tile");

            toolTipInfo.SetToolTip(btnBack, "MB4 | Go back one folder");
            toolTipInfo.SetToolTip(btnStart, "Use current folder to play from");
            toolTipInfo.SetToolTip(btnAddFav, "Add current folder to your list of favorites");
            toolTipInfo.SetToolTip(btnDeleteFav, "Delete selected folder from your list of favorites");

            toolTipInfo.SetToolTip(btnFilterVideo, "Use selected video extensions");
            toolTipInfo.SetToolTip(btnFilterImage, "Use selected image extensions");
            toolTipInfo.SetToolTip(btnFilterScript, "Play only videos that have a funscript available");

            toolTipInfo.SetToolTip(btnAddSelected, "Add all files and files from subfolders within selected items on the left");
            toolTipInfo.SetToolTip(btnAddAll, "Add all files and files from subfolders from current folder");
            toolTipInfo.SetToolTip(btnClearSelected, "Delete selected entries from list");
            toolTipInfo.SetToolTip(btnClearList, "Delete all entries from list");
            toolTipInfo.SetToolTip(btnMoveList, "Move all entries from list to a specified directory");
            toolTipInfo.SetToolTip(btnDelDuplicates, "Scan list for duplicate entries and remove those");
            toolTipInfo.SetToolTip(btnLoadList, "Load a saved list file");
            toolTipInfo.SetToolTip(btnSaveList, "Save current list to file");
            toolTipInfo.SetToolTip(btnAddFromPlaylist, "Add all entries from current Playlist queue to list");

            toolTipInfo.SetToolTip(cbFullPath, "Show full path in list");
        }
        private void UpdateListInfo()
        {
            lblEntries.Text = $"{_localCustomList.Count}";

            if (ListHandler.ListChanged)
            {
                lblLoadedList.Text = $"{ListHandler.ListNameTemp} (Unsaved changes)";
            }
            else
            {
                lblLoadedList.Text = $"{ListHandler.ListNameTemp}";

            }

            if (IsVerticalScrollBarVisible(lvCustomList))
            {
                roundedPanelCustomListTop.RadiusBottomRight = 0;
                roundedPanelCustomListBottom.RadiusTopRight = 0;
                roundedPanelCustomListTop.Invalidate();
                roundedPanelCustomListBottom.Invalidate();
            }
            else
            {
                roundedPanelCustomListTop.RadiusBottomRight = 14;
                roundedPanelCustomListBottom.RadiusTopRight = 14;
                roundedPanelCustomListTop.Invalidate();
                roundedPanelCustomListBottom.Invalidate();
            }
        }
        private void UpdateDPIScaling(Control root)
        {
            switch (root)
            {
                case Button btn:
                    btn.Font = DPI.GetFontScaled(btn.Font);
                    btn.Size = DPI.GetSizeScaled(btn.Size);
                    break;
                case CheckBox cb:
                    cb.Font = DPI.GetFontScaled(cb.Font);
                    cb.Size = DPI.GetSizeScaled(cb.Size);
                    break;
                case ListView lv:
                    lv.Font = DPI.GetFontScaled(lv.Font);
                    break;
                case Panel pnl:
                    pnl.Size = DPI.GetSizeScaled(pnl.Size);
                    break;
            }

            foreach (Control child in root.Controls)
            {
                UpdateDPIScaling(child);
            }
        }
        #endregion

        #region Filter context menus
        private void InitializeFilterContextMenus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(InitializeFilterContextMenus));
                return;
            }
            //Generate video extensions context menu
            contextVideoExtensions.Items.Clear();
            var listVideoItems = new List<ToolStripMenuItem>();

            foreach (var ext in ListHandler.VideoExtensions)
            {
                var item = new ToolStripMenuItem(ext)
                {
                    Font = new Font("Segoe UI", 9 / DPI.Scale)
                };
                item.Checked = _extensionFilter.Contains(ext);
                item.CheckOnClick = true;
                item.CheckedChanged += (s, _) =>
                {
                    var clickedItem = (ToolStripMenuItem)s;
                    if (clickedItem.Checked)
                    {
                        if (!_extensionFilter.Contains((string)clickedItem.Text))
                            _extensionFilter.Add((string)clickedItem.Text);
                    }
                    else
                    {
                        if (_extensionFilter.Contains((string)clickedItem.Text))
                            _extensionFilter.Remove((string)clickedItem.Text);
                    }
                    LoadFolder(_selectedPath);
                };
                listVideoItems.Add(item);
            }
            var headerVideoExt = new ToolStripMenuItem("Select video extensions")
            {
                Font = new Font("Segoe UI", 10 / DPI.Scale, FontStyle.Bold)
            };
            contextVideoExtensions.Items.Add(headerVideoExt);
            contextVideoExtensions.Items.Add(new ToolStripSeparator());
            contextVideoExtensions.Items.AddRange(listVideoItems.ToArray());

            //Generate image extensions context menu
            contextImageExtensions.Items.Clear();
            var listImageItems = new List<ToolStripMenuItem>();

            foreach (var ext in ListHandler.ImageExtensions)
            {
                var item = new ToolStripMenuItem(ext)
                {
                    Font = new Font("Segoe UI", 9 / DPI.Scale)
                };
                item.Checked = _extensionFilter.Contains(ext);
                item.CheckOnClick = true;
                item.CheckedChanged += (s, _) =>
                {
                    var clickedItem = (ToolStripMenuItem)s;
                    if (clickedItem.Checked)
                    {
                        if (!_extensionFilter.Contains((string)clickedItem.Text))
                            _extensionFilter.Add((string)clickedItem.Text);
                    }
                    else
                    {
                        if (_extensionFilter.Contains((string)clickedItem.Text))
                            _extensionFilter.Remove((string)clickedItem.Text);
                    }
                    LoadFolder(_selectedPath);
                };
                listImageItems.Add(item);
            }
            var headerImageExt = new ToolStripMenuItem("Select image extensions")
            {
                Font = new Font("Segoe UI", 10 / DPI.Scale, FontStyle.Bold)
            };
            contextImageExtensions.Items.Add(headerImageExt);
            contextImageExtensions.Items.Add(new ToolStripSeparator());
            contextImageExtensions.Items.AddRange(listImageItems.ToArray());
        }
        #endregion

        #region WndProc Code for clean style of the Form and regaining usability
        //Resizable Windows Form Spaghetti
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region CustomList
        private void FillCustomListFromSelection()
        {
            foreach (var item in GetSelectedEntries())
            {
                if (item.IsDirectory && Directory.Exists(item.Entry.FullName))
                {
                    FillCustomListFromDirectory(item.Entry.FullName);
                }
                else if (!item.IsDirectory && File.Exists(item.Entry.FullName))
                {
                    _localCustomList.AddRange(ListHandler.EnumerateEligibleVideo(item.Entry.FullName));
                }
            }
        }
        private void FillCustomListFromDirectory(string path)
        {
            var eligibleFiles = new List<string>();

            try
            {
                if (ListHandler.FilterScriptEnabled)
                {
                    eligibleFiles.AddRange(ListHandler.EnumerateEligibleVideosFromDirectory(path, true));
                }
                else
                {
                    eligibleFiles.AddRange(Directory.EnumerateFiles(path)
                        .Where(s => filteredExtensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant())));

                    foreach (var directory in Directory.EnumerateDirectories(path))
                    {
                        FillCustomListFromDirectory(directory);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Error.Log(ex, "Access denied to directory in LB");
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Unable to gather directory information in LB");
            }

            _localCustomList.AddRange(eligibleFiles);
        }
        private void DisplayCustomList()
        {
            lvCustomList.Items.Clear();

            foreach (string entry in _localCustomList)
            {
                var file = new FileInfo(entry);
                var item = new ListViewItem();
                item.Text = _showFullPathCustomList ? file.FullName : file.Name;
                item.Tag = file.FullName;
                item.ToolTipText = file.FullName;
                lvCustomList.Items.Add(item);
            }

            lvCustomList.Refresh();
        }

        private List<string> filteredExtensions
        {
            get
            {
                var newFilter = new List<string>();

                if (ListHandler.FilterImageEnabled)
                {
                    foreach (var extension in _extensionFilter)
                    {
                        if (ListHandler.ImageExtensions.Contains(extension))
                        {
                            newFilter.Add(extension);
                        }
                    }
                }
                if (ListHandler.FilterVideoEnabled)
                {
                    foreach (var extension in _extensionFilter)
                    {
                        if (ListHandler.VideoExtensions.Contains(extension))
                        {
                            newFilter.Add(extension);
                        }
                    }
                }
                if (ListHandler.FilterScriptEnabled)
                {
                    foreach (var extensions in ListHandler.VideoExtensions)
                    {
                        newFilter.Add(extensions);
                    }
                }

                return newFilter;
            }
        }

        #endregion

        #region File handling
        private void LoadFolder(string path)
        {
            if (!Directory.Exists(path))
                return;

            lvFileExplore.BeginUpdate();
            lvFileExplore.SelectedIndices.Clear();
            lvFileExplore.FocusedItem = null;

            _selectedPath = path;
            RenderBreadcrumbPath(path);
            _listItemFileExplorerEntries.Clear();

            var dir = new DirectoryInfo(path);
            _listItemFileExplorerEntries.AddRange(dir.EnumerateDirectories());

            if (ListHandler.FilterScriptEnabled)
            {
                var filteredEntries = ListHandler.EnumerateEligibleVideosFromDirectory(path, false)
                                                 .Select(p => new FileInfo(p));

                _listItemFileExplorerEntries.AddRange(filteredEntries);
            }
            else
            {
                _listItemFileExplorerEntries.AddRange(dir.EnumerateFiles()
                     .Where(f => IsAllowed(f.Extension, filteredExtensions.ToArray())));
            }


            ApplyVirtualListSize(_listItemFileExplorerEntries.Count);
            _cachedRange = (-1, -1);
            HighLightDrive(path);
            lvFileExplore.EndUpdate();
            lvFileExplore.Invalidate();
        }
        private bool IsAllowed(string extension, string[] allowedExtensions = null)
        {
            if (string.IsNullOrEmpty(extension))
                return true;

            if (extension.StartsWith(".", StringComparison.Ordinal))
                extension = extension[1..]; // remove leading dot

            if (allowedExtensions == null || allowedExtensions.Length == 0)
            {
                return ListHandler.CombinedExtensions.Contains(extension);
            }
            else
            {
                return allowedExtensions.Contains(extension);
            }
        }

        #endregion

        #region Path handling
        private void RenderBreadcrumbPath(string fullPath)
        {
            _segments.Clear();
            _segments.AddRange(BuildPathSegments(fullPath)); // fill _segments (root → leaf)

            var available = flowPanelPath.ClientSize.Width;
            var separatorWidth = TextRenderer.MeasureText("\\", flowPanelPath.Font).Width - 2;
            var ellipsisWidth = TextRenderer.MeasureText("…", flowPanelPath.Font).Width + separatorWidth;
            var visibleSegments = new Stack<BreadcrumbPathSegment>();
            int usedWidth = 10;

            for (int i = _segments.Count - 1; i >= 0; i--)
            {
                var segment = _segments[i];
                var tempLabel = CreatePathSegmentLabel(segment); // not added yet
                var width = tempLabel.TrueSize.Width;
                if (visibleSegments.Count > 0) width += separatorWidth;

                if (usedWidth + width > available - ellipsisWidth && i > 0)
                    break;

                visibleSegments.Push(segment);
                usedWidth += width;
            }

            flowPanelPath.SuspendLayout();
            flowPanelPath.Controls.Clear();

            if (visibleSegments.Count < _segments.Count)
            {
                var hidden = _segments.Take(_segments.Count - visibleSegments.Count).ToList();
                flowPanelPath.Controls.Add(CreatePathEllipsisLabel(hidden));
                flowPanelPath.Controls.Add(CreatePathSeparator());
            }

            while (visibleSegments.Count > 0)
            {
                flowPanelPath.Controls.Add(CreatePathSegmentLabel(visibleSegments.Pop()));
                if (visibleSegments.Count > 0) flowPanelPath.Controls.Add(CreatePathSeparator());
            }

            flowPanelPath.ResumeLayout();
        }

        private List<BreadcrumbPathSegment> BuildPathSegments(string fullPath)
        {
            var segments = new List<BreadcrumbPathSegment>();
            if (string.IsNullOrWhiteSpace(fullPath))
                return segments;

            var root = Path.GetPathRoot(fullPath) ?? string.Empty;
            var trimmedRoot = root.TrimEnd(Path.DirectorySeparatorChar);
            if (!string.IsNullOrEmpty(trimmedRoot))
                segments.Add(new BreadcrumbPathSegment(trimmedRoot, root));

            var relative = fullPath[root.Length..];
            var parts = relative.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            var current = root;

            foreach (var part in parts)
            {
                current = Path.Combine(current, part);
                segments.Add(new BreadcrumbPathSegment(part, current));
            }

            return segments;
        }
        private NoPaddingLabel CreatePathSegmentLabel(BreadcrumbPathSegment segment)
        {
            var lbl = new NoPaddingLabel
            {
                Text = segment.DisplayText,
                AutoSize = true,
                Cursor = Cursors.Hand,
                Tag = segment.FullPath,
                ForeColor = _textColor,
                Font = new Font("Segoe UI Semibold", 10 / DPI.Scale, FontStyle.Bold),
                Margin = new Padding(0)

            };

            lbl.Click += BreadcrumbPath_Click;
            lbl.MouseEnter += (s, e) => ((NoPaddingLabel)s).ForeColor = _highlightColorMain;
            lbl.MouseLeave += (s, e) => ((NoPaddingLabel)s).ForeColor = _textColor;
            lbl.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) ((NoPaddingLabel)s).ForeColor = _pressedColorMain; };
            lbl.MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) ((NoPaddingLabel)s).ForeColor = _highlightColorMain; };

            return lbl;
        }
        private NoPaddingLabel CreatePathSeparator()
        {
            var lbl = new NoPaddingLabel
            {
                Text = @"\",
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI Semibold", 10 / DPI.Scale, FontStyle.Bold),
                Margin = new Padding(2, 0, 2, 0)
            };
            return lbl;
        }
        private NoPaddingLabel CreatePathEllipsisLabel(List<BreadcrumbPathSegment> hiddenSegments)
        {
            var lbl = new NoPaddingLabel
            {
                Text = "…",
                AutoSize = true,
                Cursor = Cursors.Hand,
                Tag = hiddenSegments,
                ForeColor = _textColor,
                Font = new Font("Segoe UI Semibold", 10 / DPI.Scale, FontStyle.Bold),
                Margin = new Padding(0)
            };
            lbl.Click += EllipsisPath_Click;
            return lbl;
        }
        private void GoBack()
        {
            if (Directory.Exists(_selectedPath))
            {
                var parent = Directory.GetParent(_selectedPath);
                if (parent != null)
                {
                    LoadFolder(parent.FullName);
                }
            }
        }

        #endregion

        #region Directory list creation
        private void RenderDirectoryBreadcrumbs()
        {
            flowPanelDir.SuspendLayout();
            flowPanelDir.Controls.Clear();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (!drive.IsReady) continue;
                AddDirectorySegment(drive.Name + drive.VolumeLabel, drive.Name);
            }

            flowPanelDir.ResumeLayout();
        }

        private void AddDirectorySegment(string text, string absolutePath)
        {
            var lbl = new NoCopyLabel
            {
                Text = text,
                AutoSize = false,
                Width = flowPanelDir.Width,
                AutoEllipsis = true,
                Height = 18,
                ForeColor = _textColor,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = absolutePath,
                Margin = new Padding(0, 0, 0, 0),
                Padding = new Padding(0, 2, 0, 0)
            };

            lbl.DoubleClick += Directory_DoubleClick;
            lbl.MouseEnter += (s, e) => ((Label)s).ForeColor = _highlightColorMain;
            lbl.MouseLeave += (s, e) => ((Label)s).ForeColor = _textColor;
            lbl.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _pressedColorMain; };
            lbl.MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _highlightColorMain; };

            _dirLabels.Add(lbl);
            flowPanelDir.Controls.Add(lbl);
        }
        #endregion

        #region Favorite entry handling
        private void RenderFavoriteBreadcrumbs()
        {
            flowPanelFav.SuspendLayout();
            flowPanelFav.Controls.Clear();
            _favLabels.Clear();

            foreach (string str in _tempFavoritesList)
            {
                try
                {
                    if (!Directory.Exists(str)) continue;

                    var dir = new DirectoryInfo(str);
                    AddFavoriteSegment(dir.Name, dir.FullName);
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Unable to gather favorite folder in FileBrowser");
                    continue;
                }
            }

            flowPanelFav.ResumeLayout();
        }

        private void AddFavoriteSegment(string text, string absolutePath)
        {
            var lbl = new NoCopyLabel
            {
                Text = text,
                AutoSize = false,
                Width = flowPanelDir.Width,
                AutoEllipsis = true,                
                Height = 18,
                ForeColor = _textColor,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = absolutePath,
                Margin = new Padding(0, 0, 0, 0),
                Padding = new Padding(0, 2, 0, 0)
            };

            lbl.DoubleClick += Directory_DoubleClick;
            lbl.Click += Favorite_Click;
            lbl.MouseEnter += (s, e) => ((Label)s).ForeColor = _highlightColorMain;
            lbl.MouseLeave += (s, e) => ((Label)s).ForeColor = _textColor;
            lbl.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _pressedColorMain; };
            lbl.MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _highlightColorMain; };

            toolTipInfo.SetToolTip(lbl, absolutePath);

            _favLabels.Add(lbl);

            flowPanelFav.Controls.Add(lbl);
        }

        private void Favorite_Click(object? sender, EventArgs e)
        {
            var targetPath = (string)((Label)sender).Tag;
            HighLightFavorite(targetPath);
        }

        private void HighLightFavorite(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return;

            foreach (var favLbl in _favLabels)
            {
                if (favLbl.Tag.ToString() == path)
                {

                    favLbl.BackColor = lvFileExplore.BackColor;
                    _favoriteSelected = path;
                }
                else
                {
                    favLbl.BackColor = flowPanelFav.BackColor;
                }
            }
        }
        #endregion

        #region Image handling
        private void lvFileExplore_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var fsi = _listItemFileExplorerEntries[e.ItemIndex];
            var item = new ListViewItem(fsi.Name) { Tag = fsi };

            if (_imageIndexCache.TryGetValue(fsi.FullName, out int index))
            {
                item.ImageIndex = index;
            }
            else
            {
                int imageIndex = 0;
                if (fsi is DirectoryInfo)
                {
                    imageIndex = 0;
                }
                else if (IsAllowed(fsi.Extension, ListHandler.VideoExtensions.ToArray()))
                {
                    imageIndex = 1;
                }
                else if (IsAllowed(fsi.Extension, ListHandler.ImageExtensions.ToArray()))
                {
                    imageIndex = 2;
                }
                item.ImageIndex = imageIndex;
                QueueThumbnailLoad(fsi);
            }

            e.Item = item;
        }
        private void lvFileExplore_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (e.StartIndex == _cachedRange.Start && e.EndIndex == _cachedRange.End)
                return;

            _cachedRange = (e.StartIndex, e.EndIndex);

            for (int i = e.StartIndex; i <= e.EndIndex && i < _listItemFileExplorerEntries.Count; i++)
            {
                var fsi = _listItemFileExplorerEntries[i];
                if (!_imageIndexCache.ContainsKey(fsi.FullName))
                    QueueThumbnailLoad(fsi);
            }
        }
        private void QueueThumbnailLoad(FileSystemInfo fsi)
        {
            if (!_pendingThumbs.TryAdd(fsi.FullName, 0))
                return;

            _ = Task.Run(() =>
            {
                try
                {
                    using var raw = BuildThumbnail(fsi);
                    Invoke(new Action(() =>
                    {
                        int imageIndex = 0;
                        if (fsi is DirectoryInfo)
                        {
                            imageIndex = 0;
                        }
                        else if (_thumbPreviewEnabled)
                        {
                            imageIndex = _thumbs.Images.Count;
                        }
                        else if (IsAllowed(fsi.Extension, ListHandler.VideoExtensions.ToArray()))
                        {
                            imageIndex = 1;
                        }
                        else if (IsAllowed(fsi.Extension, ListHandler.ImageExtensions.ToArray()))
                        {
                            imageIndex = 2;
                        }
                        using var fitted = FitThumbnail(raw, _thumbSize, _backColorSideDark);
                        _thumbs.Images.Add((Image)fitted.Clone());
                        _imageIndexCache[fsi.FullName] = imageIndex;

                        int idx = _listItemFileExplorerEntries.FindIndex(info => info.FullName == fsi.FullName);
                        if (idx >= 0)
                        {
                            lvFileExplore.RedrawItems(idx, idx, false);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to create thumbnail");
                    // ignore bad thumbnails, keep fallback
                }
                finally
                {
                    _pendingThumbs.TryRemove(fsi.FullName, out _);
                }
            });
        }
        private static Image FitThumbnail(Image source, Size targetSize, Color backColor)
        {
            var canvas = new Bitmap(targetSize.Width, targetSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            using var g = Graphics.FromImage(canvas);
            g.Clear(backColor);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            float ratio = Math.Max(
                (float)targetSize.Width / source.Width,
                (float)targetSize.Height / source.Height);

            int drawWidth = (int)(source.Width * ratio);
            int drawHeight = (int)(source.Height * ratio);
            int offsetX = (targetSize.Width - drawWidth) / 2;
            int offsetY = (targetSize.Height - drawHeight) / 2;

            g.DrawImage(source, new Rectangle(offsetX, offsetY, drawWidth, drawHeight));
            return canvas;
        }

        private static Guid IID_IShellItemImageFactory = new("BCC18B79-BA16-442F-80C4-8A59C30C463B");
        private Image BuildThumbnail(FileSystemInfo fsi)
        {
            if (fsi is DirectoryInfo || _thumbPreviewEnabled == false)
                return SystemIcons.WinLogo.ToBitmap();

            IntPtr hBitmap = IntPtr.Zero;
            IShellItemImageFactory? factory = null;

            try
            {
                int hr = SHCreateItemFromParsingName(
                    fsi.FullName,
                    IntPtr.Zero,
                    ref IID_IShellItemImageFactory,
                    out factory);

                if (hr != 0 || factory == null)
                    return SystemIcons.Application.ToBitmap();

                var size = new SIZE { cx = _thumbSize.Width, cy = _thumbSize.Height };
                const SIIGBF flags = SIIGBF.SIIGBF_RESIZETOFIT | SIIGBF.SIIGBF_BIGGERSIZEOK;

                hr = factory.GetImage(size, flags, out hBitmap);
                if (hr != 0 || hBitmap == IntPtr.Zero)
                    return SystemIcons.Application.ToBitmap();

                var bitmap = Image.FromHbitmap(hBitmap);
                return bitmap;
            }
            catch
            {
                return SystemIcons.Application.ToBitmap();
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                    DeleteObject(hBitmap);
                if (factory != null)
                    Marshal.ReleaseComObject(factory);
            }
        }
        private void ApplyVirtualListSize(int newCount)
        {
            SendMessage(lvFileExplore.Handle, LVM_SETITEMCOUNT, newCount, 0);

            lvFileExplore.VirtualListSize = newCount;

            if (newCount > 0)
                SendMessage(lvFileExplore.Handle, LVM_ENSUREVISIBLE, 0, 0);
        }
        private void ApplyThumbnailSize(int width, int height, int padding = 32)
        {
            _thumbSize = new Size(width, height);

            _thumbs?.Dispose();
            _thumbs = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = _thumbSize
            };
            _thumbs.Images.Add("folder", SVGIcon(SVGTemplates.Foldericon, Color.FromArgb(249, 185, 27), Color.FromArgb(255, 222, 126)));
            _thumbs.Images.Add("video", SVGIcon(SVGTemplates.VideoIcon, _textColor, _backColorSideDark));
            _thumbs.Images.Add("image", SVGIcon(SVGTemplates.ImageIcon, _textColor, _backColorSideDark));

            lvFileExplore.LargeImageList = _thumbs;
            lvFileExplore.SmallImageList = _thumbs;
            lvFileExplore.TileSize = new Size(padding + 32, padding + 32);

            _imageIndexCache.Clear();
            _pendingThumbs.Clear();
            lvFileExplore.Invalidate();
        }
        private void EnsureBaselineIcons()
        {
            _thumbs.Images.Clear();
            _thumbs.Images.Add("folder", SVGIcon(SVGTemplates.Foldericon, Color.FromArgb(249, 185, 27), Color.FromArgb(255, 222, 126))); // index 0
            _thumbs.Images.Add("video", SVGIcon(SVGTemplates.VideoIcon, _textColor, _backColorSideDark)); // index 1
            _thumbs.Images.Add("image", SVGIcon(SVGTemplates.ImageIcon, _textColor, _backColorSideDark)); // index 2
        }

        private void ApplyIcon(Button target, string template, Color main, Color accent, int width = 20, int height = 20)
        {
            var svgMarkup = template
                .Replace("{{main}}", ColorTranslator.ToHtml(main))
                .Replace("{{accent}}", ColorTranslator.ToHtml(accent));

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svgMarkup));
            var svgDoc = SvgDocument.Open<SvgDocument>(stream); // SVG.NET
            using var bmp = svgDoc.Draw(width, height);

            target.Font = new Font("Segoe UI Semibold", 10 / DPI.Scale, FontStyle.Bold);
            target.Image?.Dispose();
            target.Image = (Bitmap)bmp.Clone();

        }

        private Image SVGIcon(string template, Color main, Color accent)
        {
            try
            {
                var svgMarkup = template
                    .Replace("{{main}}", ColorTranslator.ToHtml(main))
                    .Replace("{{accent}}", ColorTranslator.ToHtml(accent));

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svgMarkup));
                var svgDoc = SvgDocument.Open<SvgDocument>(stream); // SVG.NET
                using var bmp = svgDoc.Draw(_thumbSize.Width, _thumbSize.Height);
                return (Bitmap)bmp.Clone();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return SystemIcons.Warning.ToBitmap();
            }
        }

        private Color Lighten(Color baseColor, int delta, Color hColor)
        {
            return Color.FromArgb(baseColor.A,
                Math.Clamp(delta + hColor.R, 0, 255),
                Math.Clamp(delta + hColor.G, 0, 255),
                Math.Clamp(delta + hColor.B, 0, 255));
        }
        #endregion

        #region Shell sequence
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        private const int GWL_STYLE = -16;
        private const int WS_VSCROLL = 0x00200000;

        private bool IsVerticalScrollBarVisible(ListView lv)
        {
            int style = GetWindowLong(lv.Handle, GWL_STYLE);
            return (style & WS_VSCROLL) != 0;
        }


        private const int LVM_SETITEMCOUNT = 0x1000 + 47;
        private const int LVM_ENSUREVISIBLE = 0x1000 + 19;

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE { public int cx; public int cy; }

        [Flags]
        private enum SIIGBF
        {
            SIIGBF_RESIZETOFIT = 0x00,
            SIIGBF_BIGGERSIZEOK = 0x01,
            SIIGBF_MEMORYONLY = 0x02,
            SIIGBF_ICONONLY = 0x04,
            SIIGBF_THUMBNAILONLY = 0x08,
            SIIGBF_INCACHEONLY = 0x10
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("BCC18B79-BA16-442F-80C4-8A59C30C463B")]
        private interface IShellItemImageFactory
        {
            [PreserveSig]
            int GetImage(SIZE size, SIIGBF flags, out IntPtr phbm);
        }

        [DllImport("shell32", CharSet = CharSet.Unicode, PreserveSig = true)]
        private static extern int SHCreateItemFromParsingName(
            [MarshalAs(UnmanagedType.LPWStr)] string pszPath,
            IntPtr pbc,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItemImageFactory ppv);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        #endregion

        #region Generic
        private void ListBrowserV2View_Resize(object sender, EventArgs e)
        {
            formResize.AdjustForm(this);
        }

        private void ListBrowserV2View_ResizeEnd(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_selectedPath))
            {
                RenderBreadcrumbPath(_selectedPath);
            }
        }
        private void lvFileExplore_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.XButton1)
            {
                GoBack();
            }
            if (e.Button == MouseButtons.Left)
            {
                var hit = lvFileExplore.HitTest(e.Location);

                _dragCandidate = hit.Item?.Tag as FileSystemInfo;
                _dragStartPoint = e.Location;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
        private void lblTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveSettings();

            this.Close();
        }

        private void lvFileExplore_Resize(object sender, EventArgs e)
        {
            if (_viewState == View.Details)
                lvFileExplore.Columns[0].Width = lvFileExplore.Width - 34;
        }

        private void lvCustomList_Resize(object sender, EventArgs e)
        {
            lvCustomList.Columns[0].Width = lvCustomList.Width - 34;
        }
        #endregion

        #region Drag Drop
        private void lvCustomList_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DummyPayload) == true || e.Data.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvCustomList_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data?.GetDataPresent(DummyPayload) == true)
            {
                FillCustomListFromSelection();
                ListHandler.ListChanged = true;
            }
            else if(e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                var droppedExternalFiles = ((string[])e.Data.GetData(DataFormats.FileDrop));

                foreach(var path in droppedExternalFiles)
                {
                    if (Directory.Exists(path))
                    {
                        FillCustomListFromDirectory(path);
                    }
                    else if(File.Exists(path))
                    {
                        _localCustomList.AddRange(ListHandler.EnumerateEligibleVideo(path));
                    }
                }
                ListHandler.ListChanged = true;
            }
            DisplayCustomList();
            UpdateListInfo();
            lvCustomList.Refresh();
        }
        private void lvFileExplore_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragCandidate == null || e.Button != MouseButtons.Left)
                return;

            if (!DragWithinThreshold(_dragStartPoint, e.Location))
            {
                StartTileDrag();
                _dragCandidate = null;
            }
        }
        private void lvFileExplore_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _dragCandidate = null;
        }

        private void StartTileDrag()
        {
            if (lvFileExplore.SelectedIndices.Count == 0)
                return;

            var data = new DataObject();
            data.SetData(DummyPayload, true);
            lvFileExplore.DoDragDrop(data, DragDropEffects.Copy);
        }
        private static bool DragWithinThreshold(Point origin, Point current)
        {
            Rectangle dragRect = new Rectangle(
                origin.X - SystemInformation.DragSize.Width / 2,
                origin.Y - SystemInformation.DragSize.Height / 2,
                SystemInformation.DragSize.Width,
                SystemInformation.DragSize.Height);

            return dragRect.Contains(current);
        }
        #endregion



    }
}
