using FontAwesome.Sharp;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using Svg;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;

namespace RandomVideoPlayer.Views
{
    public partial class FolderBrowserV2View : Form
    {
        #region Variables
        FormResize formResize = new FormResize();

        private readonly List<FileSystemInfo> _listItemEntries = new();

        private readonly Dictionary<string, int> _imageIndexCache = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<string, byte> _pendingThumbs = new();
        private (int Start, int End) _cachedRange = (-1, -1);
        private ImageList _thumbs = new();
        private Size _thumbSize = new(110, 82);
        private bool _thumbPreviewEnabled = false;
        readonly float aspectRatio = 110f / 82f;
        private const int ThumbMin = 48;
        private const int ThumbMax = 256;
        private const int SliderDefault = 5;

        private ContextMenuStrip contextHiddenPath;

        private Color _textColor = Color.Black;
        private Color _textColorAccent = Color.Black;
        private Color _backColorLight = Color.White;
        private Color _backColorDark = Color.Gray;
        private Color _accentColor = Color.Pink;
        private Color _highlightColor = Color.OrangeRed;
        private Color _pressedColor => Lighten(_highlightColor, -30);
        private Color _hoverColor => Lighten(_highlightColor, 50);

        private Color HoverColor(IconButton btn) => Lighten(idleColors[btn], 60);
        private Color PressedColor(IconButton btn) => Lighten(idleColors[btn], 20);

        private readonly Dictionary<IconButton, Color> idleColors = new();
        private readonly HashSet<IconButton> highlightedButtons = new();

        private readonly List<BreadcrumbPathSegment> _segments = new();
        private sealed record BreadcrumbPathSegment(string DisplayText, string FullPath);
        private List<Label> _dirLabels = new List<Label>();
        private List<Label> _favLabels = new List<Label>();
        public string SelectedPath { get; set; }
        private string _selectedPath { get; set; }
        private View _viewState { get; set; } = View.SmallIcon;
        private List<string> _tempFavoritesList = new();
        private string _favoriteSelected;
        private Dictionary<IconButton, bool> _filterButtons = new();

        private ToolTip toolTipInfo;
        #endregion

        public FolderBrowserV2View()
        {
            InitializeComponent();

            this.Padding = new Padding(formResize.BorderSize);
            this.BackColor = Color.FromArgb(255, 221, 26);

            InitializeUI();
            LoadSettings();
        }

        private void FolderBrowserV2View_Load(object sender, EventArgs e)
        {
            SwitchView(_viewState);
            RenderDirectoryBreadcrumbs();
            RenderFavoriteBreadcrumbs();
            LoadFolder(_selectedPath);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveSettings();

            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void lvFileExplore_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.XButton1)
            {
                GoBack();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SelectedPath = _selectedPath;
            if (!string.IsNullOrWhiteSpace(SelectedPath)) this.DialogResult = DialogResult.OK;

            SaveSettings();

            this.Close();
        }

        private void btnFilterVideo_Click(object sender, EventArgs e)
        {
            ToggleFilter(sender as IconButton);
        }

        private void btnFilterImage_Click(object sender, EventArgs e)
        {
            ToggleFilter(sender as IconButton);
        }

        private void btnFilterScript_Click(object sender, EventArgs e)
        {
            ToggleFilter(sender as IconButton);
        }

        private void btnResetSize_Click(object sender, EventArgs e)
        {
            sliderZoom.Value = SliderDefault;
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

        private void sliderZoom_ValueChanged(object sender, EventArgs e)
        {
            ResizeTileFromSlider(sliderZoom.Value);
        }

        private void sliderLatestCount_ValueChanged(object sender, EventArgs e)
        {
            cbUseRecent.Text = $"Latest {sliderLatestCount.Value} files";
        }

        private void lvFileExplore_ItemActivate(object sender, EventArgs e)
        {
            if (lvFileExplore.SelectedIndices.Count == 0)
                return;

            var fsi = _listItemEntries[lvFileExplore.SelectedIndices[0]];
            if (fsi is DirectoryInfo dir)
                LoadFolder(dir.FullName);
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
        private void lblTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FolderBrowserV2View_Resize(object sender, EventArgs e)
        {
            formResize.AdjustForm(this);
        }
        private void FolderBrowserV2View_ResizeEnd(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_selectedPath))
            {
                RenderBreadcrumbPath(_selectedPath);
            }
            if(_viewState == View.Details)
                lvFileExplore.Columns[0].Width = lvFileExplore.Width - 30;
        }

        #region Settings
        private void LoadSettings()
        {
            _selectedPath = FileManipulation.GetFirstExistingPath(
                          () => PathHandler.TempRecentFolder,
                          () => PathHandler.DefaultFolder,
                          () => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            _tempFavoritesList.AddRange(ListHandler.FavoriteFolderList);

            cbUseRecent.Checked = SettingsHandler.TempTriggered
                                ? SettingsHandler.RecentChecked
                                : (SettingsHandler.RecentCheckedSaved ? SettingsHandler.RecentChecked : cbUseRecent.Checked);

            sliderLatestCount.Value = SettingsHandler.TempTriggered
                                    ? SettingsHandler.RecentCountSavedTemp
                                    : (SettingsHandler.RecentCountSaved ? SettingsHandler.RecentCount : sliderLatestCount.Value);
            cbUseRecent.Text = $"Latest {sliderLatestCount.Value} files";
            cbIncludeSubfolders.Checked = ListHandler.IncludeSubfolders;

            _thumbPreviewEnabled = SettingsHandler.ThumbnailPreviewEnabled;
        }

        private void SaveSettings()
        {
            if (_tempFavoritesList?.Any() == true)
                ListHandler.FavoriteFolderList = _tempFavoritesList;
            else
                ListHandler.ClearFavoriteFolderList();


            if (SettingsHandler.RecentCheckedSaved) SettingsHandler.RecentChecked = cbUseRecent.Checked;
            if (SettingsHandler.RecentCountSaved) SettingsHandler.RecentCount = sliderLatestCount.Value;
            SettingsHandler.RecentCheckedTemp = cbUseRecent.Checked;
            SettingsHandler.RecentCountSavedTemp = sliderLatestCount.Value;
            SettingsHandler.TempTriggered = true;

            ListHandler.IncludeSubfolders = cbIncludeSubfolders.Checked;

            SettingsHandler.ThumbSizeFactorFolderBrowser = sliderZoom.Value;
            SettingsHandler.FileBrowserViewState = _viewState;

            PathHandler.TempRecentFolder = _selectedPath;
        }
        #endregion

        #region Themepark
        private void InitializeUI()
        {
            ThemeManager.ApplyThemeFBV2(this);

            _thumbs.ColorDepth = ColorDepth.Depth32Bit;
            _thumbs.ImageSize = _thumbSize;

            lvFileExplore.LargeImageList = _thumbs;
            lvFileExplore.SmallImageList = _thumbs;
            _textColor = ThemeManager.CurrentTheme.FbTextColor;
            _textColorAccent = ThemeManager.CurrentTheme.FbTextColorAccent;
            _backColorLight = ThemeManager.CurrentTheme.FbBackColorLight;
            _backColorDark = ThemeManager.CurrentTheme.FbBackColorDark;
            _accentColor = ThemeManager.CurrentTheme.FbAccentColor;
            _highlightColor = ThemeManager.CurrentTheme.FbHighlightColor;

            sliderZoom.Value = SettingsHandler.ThumbSizeFactorFolderBrowser;
            _viewState = SettingsHandler.FileBrowserViewState;

            var renderer = new CustomRenderer()
            {
                BackgroundColor = _backColorLight,
                TextColor = _textColor,
                HighlightColor = _highlightColor,
            };
            renderer.ApplyColors();
            contextHiddenPath = new ContextMenuStrip()
            {
                ShowImageMargin = false,
                ShowCheckMargin = false,
                Renderer = renderer,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };

            EnsureBaselineIcons();
            WireIconButton(btnResetSize);
            WireIconButton(btnViewList);
            WireIconButton(btnViewSmallGrid);
            WireIconButton(btnViewLargeGrid);
            WireIconButton(btnFilterVideo);
            WireIconButton(btnFilterImage);
            WireIconButton(btnFilterScript);
            WireIconButton(btnAddFav);
            WireIconButton(btnDeleteFav);
            _filterButtons.Add(btnFilterVideo, ListHandler.FilterVideoEnabled);
            _filterButtons.Add(btnFilterImage, ListHandler.FilterImageEnabled);
            _filterButtons.Add(btnFilterScript, ListHandler.FilterScriptEnabled);
            ToggleFilter(null);

            ApplyIcon(btnStart, SVGTemplates.PlayIcon, _textColorAccent, _hoverColor);
            ApplyIcon(btnBack, SVGTemplates.BackIcon, _textColorAccent, _hoverColor, 24, 24);

            toolTipInfo = new ToolTip()
            {
                BackColor = _backColorLight,
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
        private void WireIconButton(IconButton btn)
        {
            btn.FlatAppearance.MouseOverBackColor = _backColorLight;
            btn.FlatAppearance.MouseDownBackColor = _backColorLight;

            idleColors[btn] = ThemeManager.CurrentTheme.FbTextColor;
            btn.IconColor = ThemeManager.CurrentTheme.FbTextColor;

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

        private void SetHighlight(IconButton btn, bool highlight, Color? customColor = null)
        {
            if (highlight)
                highlightedButtons.Add(btn);
            else
                highlightedButtons.Remove(btn);

            var color = customColor ?? _highlightColor;

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

            toolTipInfo.SetToolTip(cbUseRecent, $"Check to load only the latest files chosen on the input to the right");
            toolTipInfo.SetToolTip(cbIncludeSubfolders, "Include all subdirectories of the current selected directory");
            toolTipInfo.SetToolTip(sliderLatestCount, "Change how many of the latest files are loaded into the playlist");

            toolTipInfo.SetToolTip(btnFilterVideo, "Use selected video extensions");
            toolTipInfo.SetToolTip(btnFilterImage, "Use selected image extensions");
            toolTipInfo.SetToolTip(btnFilterScript, "Play only videos that have a funscript available");
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
            _listItemEntries.Clear();

            var dir = new DirectoryInfo(path);
            _listItemEntries.AddRange(dir.EnumerateDirectories());

            _listItemEntries.AddRange(dir.EnumerateFiles()
                                 .Where(f => IsAllowed(f.Extension)));

            ApplyVirtualListSize(_listItemEntries.Count);
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
            lbl.MouseEnter += (s, e) => ((NoPaddingLabel)s).ForeColor = _highlightColor;
            lbl.MouseLeave += (s, e) => ((NoPaddingLabel)s).ForeColor = _textColor;
            lbl.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) ((NoPaddingLabel)s).ForeColor = _pressedColor; };
            lbl.MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) ((NoPaddingLabel)s).ForeColor = _highlightColor; };

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
            lbl.MouseEnter += (s, e) => ((Label)s).ForeColor = _highlightColor;
            lbl.MouseLeave += (s, e) => ((Label)s).ForeColor = _textColor;
            lbl.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _pressedColor; };
            lbl.MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _highlightColor; };

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
            lbl.MouseEnter += (s, e) => ((Label)s).ForeColor = _highlightColor;
            lbl.MouseLeave += (s, e) => ((Label)s).ForeColor = _textColor;
            lbl.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _pressedColor; };
            lbl.MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) ((Label)s).ForeColor = _highlightColor; };

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
            var fsi = _listItemEntries[e.ItemIndex];
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

            for (int i = e.StartIndex; i <= e.EndIndex && i < _listItemEntries.Count; i++)
            {
                var fsi = _listItemEntries[i];
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
                        using var fitted = FitThumbnail(raw, _thumbSize, _backColorDark);
                        _thumbs.Images.Add((Image)fitted.Clone());
                        _imageIndexCache[fsi.FullName] = imageIndex;

                        int idx = _listItemEntries.FindIndex(info => info.FullName == fsi.FullName);
                        if (idx >= 0)
                        {
                            lvFileExplore.RedrawItems(idx, idx, false);
                        }
                    }));
                }
                catch(Exception ex)
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
            _thumbs.Images.Add("video", SVGIcon(SVGTemplates.VideoIcon, _textColor, _backColorDark));
            _thumbs.Images.Add("image", SVGIcon(SVGTemplates.ImageIcon, _textColor, _backColorDark));

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
            _thumbs.Images.Add("video", SVGIcon(SVGTemplates.VideoIcon, _textColor, _backColorDark)); // index 1
            _thumbs.Images.Add("image", SVGIcon(SVGTemplates.ImageIcon, _textColor, _backColorDark)); // index 2
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

        private Color Lighten(Color baseColor, int delta)
        {
            var hColor = _highlightColor;

            return Color.FromArgb(baseColor.A,
                Math.Clamp(delta + hColor.R, 0, 255),
                Math.Clamp(delta + hColor.G, 0, 255),
                Math.Clamp(delta + hColor.B, 0, 255));
        }

        #region Shell sequence

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
        #endregion

    }
}
