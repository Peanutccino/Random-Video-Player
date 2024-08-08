using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System.Runtime.InteropServices;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace RandomVideoPlayer.View
{
    public partial class FolderBrowserView : Form
    {
        FormResize fR = new FormResize();

        List<string> TempList = new List<string>();
        private Size _tileSize;

        private string _viewStateFolderFileExplore;
        public string selectedPath { get; set; }

        public FolderBrowserView()
        {
            InitializeComponent();
            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);
            this.BackColor = Color.FromArgb(255, 221, 26);

            _tileSize = SettingsHandler.TileSizeFileBrowser;
            _viewStateFolderFileExplore = SettingsHandler.ViewStateFolderFileExplore;
        }

        private void FolderBrowserView_Load(object sender, EventArgs e)
        {            
            //Keep recently browsed folders active for consistency
            if (!string.IsNullOrWhiteSpace(PathHandler.TempRecentFolder)) 
            { 
                tbPathView.Text = PathHandler.TempRecentFolder; 
            } 
            else if(string.IsNullOrWhiteSpace(PathHandler.DefaultFolder))
            {                
                tbPathView.Text = @"C:\"; 
            }
            else
            {
                tbPathView.Text = PathHandler.DefaultFolder;
            }

            PopulateSelected(tbPathView.Text);

            PopulateDrives();

            HighlightDriveInListBox(tbPathView.Text);

            lvFileExplore.Columns[0].Width = lvFileExplore.Width - 30;

            ChangeViewFileExplore(_viewStateFolderFileExplore);

            if (SettingsHandler.TempTriggered)
            {
                cbUseRecent.Checked = SettingsHandler.RecentCheckedTemp;
                tbCount.Text = SettingsHandler.RecentCountSavedTemp.ToString();
            }
            else
            {
                if (SettingsHandler.RecentCheckedSaved)
                {
                    cbUseRecent.Checked = SettingsHandler.RecentChecked;
                }
                if (SettingsHandler.RecentCountSaved)
                {
                    tbCount.Text = SettingsHandler.RecentCount.ToString();
                }
            }

            cbIncludeSubfolders.Checked = ListHandler.IncludeSubfolders;

            PopulateFavoriteFolders();

            SetupTooltips(); //Initialize ToolTips
        }

        private void FolderBrowserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsHandler.TileSizeFileBrowser = _tileSize;
            SettingsHandler.ViewStateFolderFileExplore = _viewStateFolderFileExplore;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveSettings();

            this.Close();
        }
        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            this.selectedPath = tbPathView.Text;
            this.DialogResult = DialogResult.OK;

            SaveSettings();

            this.Close();
        }

        private void btnAddFav_Click(object sender, EventArgs e)
        {
            TempList.Add(tbPathView.Text);

            lbFavorites.Items.Clear();

            if (TempList?.Any() == true)
            {
                foreach (string str in TempList)
                {
                    var dir = new DirectoryInfo(str);
                    string folderName = FileManipulation.TrimText(dir.Name, 19, "...");

                    lbFavorites.Items.Add(folderName);
                }
            }
        }

        private void btnDeleteFav_Click(object sender, EventArgs e)
        {
            DeleteFavFolder();
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
        private void lvFileExplore_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                var item = lvFileExplore.SelectedItems[0];
                var itemPath = item.Tag.ToString();

                if (Directory.Exists(itemPath))
                {
                    tbPathView.Text = itemPath;
                    PopulateSelected(itemPath);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Error accessing folder: {0}\n\nError:\n{1}", itemPath, ex), "FB lvFE_ItemActivate");
                return;
            }
        }

        private void lvFileExplore_Resize(object sender, EventArgs e)
        {
            lvFileExplore.Columns[0].Width = lvFileExplore.Width - 30;
        }

        private void lbDriveFolders_DoubleClick(object sender, EventArgs e)
        {
            if (lbDriveFolders.SelectedItems.Count > 0 && lbDriveFolders.SelectedIndex >= 0)
            {
                string driveLetter = FileManipulation.TrimText(lbDriveFolders.SelectedItem.ToString(), 3, "");
                tbPathView.Text = driveLetter;
                PopulateSelected(driveLetter);
            }
        }
        private void lbFavorites_DoubleClick(object sender, EventArgs e)
        {
            if (lbFavorites.SelectedItems.Count > 0 && lbFavorites.SelectedIndex >= 0)
            {
                string selectedPath = TempList[lbFavorites.SelectedIndex];

                if (Directory.Exists(selectedPath))
                {
                    tbPathView.Text = selectedPath;
                    PopulateSelected(selectedPath);
                    HighlightDriveInListBox(tbPathView.Text);
                }
                else
                {
                    DeleteFavFolder();
                }
            }
        }

        private void btnDecreaseSize_Click(object sender, EventArgs e)
        {
            if (_tileSize.Width <= 80) return;

            _tileSize = new Size(_tileSize.Width - 10, _tileSize.Height);

            lvFileExplore.TileSize = _tileSize;

            PopulateSelected(tbPathView.Text);
            lvFileExplore.Refresh();
        }

        private void btnResetSize_Click(object sender, EventArgs e)
        {
            _tileSize = new Size(120, 34);

            lvFileExplore.TileSize = _tileSize;

            PopulateSelected(tbPathView.Text);
            lvFileExplore.Refresh();
        }

        private void btnIncreaseSize_Click(object sender, EventArgs e)
        {
            if (_tileSize.Width >= 560) return;

            _tileSize = new Size(_tileSize.Width + 10, _tileSize.Height);

            lvFileExplore.TileSize = _tileSize;

            PopulateSelected(tbPathView.Text);
            lvFileExplore.Refresh();
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            ChangeViewFileExplore("List");
        }

        private void btnViewTile_Click(object sender, EventArgs e)
        {
            ChangeViewFileExplore("Tile");
        }

        private void btnViewGrid_Click(object sender, EventArgs e)
        {
            ChangeViewFileExplore("Grid");
        }


        private void tbCount_TextChanged(object sender, EventArgs e)
        {
            toolTipInfo.SetToolTip(cbUseRecent, $"Check to load only the latest {tbCount.Text} files chosen on the input to the right");
            cbUseRecent.Text = $"Only latest {tbCount.Text} files";
        }
        private void lbFavorites_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lbFavorites.IndexFromPoint(e.Location);

            if (index >= 0 && index < lbFavorites.Items.Count)
            {
                string itemText = TempList[index];

                // Check if the tooltip text is different than the item text (to avoid flickering)
                if (toolTipInfo.GetToolTip(lbFavorites) != itemText)
                {
                    toolTipInfo.SetToolTip(lbFavorites, itemText);
                }
            }
            else
            {
                toolTipInfo.SetToolTip(lbFavorites, "");
            }
        }

        #region functions
        private void PopulateDrives() //List all available drives for easier navigation
        {
            lbDriveFolders.Items.Clear();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    lbDriveFolders.Items.Add(drive.Name + " " + drive.VolumeLabel);
                }
            }
        }

        private void PopulateFavoriteFolders()
        {
            if (ListHandler.FavoriteFolderList?.Any() == true) //Load favorited folders
            {
                foreach (string str in ListHandler.FavoriteFolderList)
                {
                    try
                    {
                        if (!Directory.Exists(str))
                        {
                            continue;
                        }
                        else
                        {
                            TempList.Add(str);

                            var dir = new DirectoryInfo(str);
                            string folderName = FileManipulation.TrimText(dir.Name, 19, "...");

                            lbFavorites.Items.Add(folderName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, "Unable to gather favorite folders in FB");
                        continue;
                    }
                }
            }
        }

        private void PopulateSelected(string folderPath) //Get all files from selected and sub directories
        {
            try
            {
                lvFileExplore.Items.Clear();
                var dir = new DirectoryInfo(folderPath);
                var combinedExtensions = ListHandler.CombinedExtensions;

                foreach (DirectoryInfo subFolder in dir.EnumerateDirectories())
                {
                    var item = new ListViewItem();
                    item.Text = subFolder.Name;
                    item.ImageIndex = 0;
                    item.Tag = subFolder.FullName;
                    item.ToolTipText = subFolder.Name;
                    lvFileExplore.Items.Add(item);
                }
                foreach (FileInfo file in dir.EnumerateFiles())
                {
                    var currentFileExtension = Path.GetExtension(file.Name).TrimStart('.').ToLower();
                    if (!combinedExtensions.Contains(currentFileExtension)) continue;
                    var item = new ListViewItem();
                    item.Text = file.Name;
                    item.ImageIndex = ListHandler.VideoExtensions.Contains(currentFileExtension) ? 1 : 2;
                    item.Tag = file.FullName;
                    item.ToolTipText = file.Name;
                    lvFileExplore.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Error populating lvFileExplore in FB");
                return;
            }

        }

        private void HighlightDriveInListBox(string path) //Hightlight drive that is currently in use within listview
        {
            // Extract the drive letter and format (e.g., "G:\")
            string drive = path.Substring(0, 3);

            // Find and select the corresponding item in the listBox
            foreach (var item in lbDriveFolders.Items)
            {
                if (item.ToString().StartsWith(drive, StringComparison.OrdinalIgnoreCase))
                {
                    lbDriveFolders.SelectedItem = item;
                    break;
                }
            }
        }

        private void DeleteFavFolder()
        {
            int firstItem = lbFavorites.SelectedIndex;
            int itemCount = firstItem + lbFavorites.SelectedIndices.Count;

            for (int i = firstItem; i < itemCount; i++)
            {
                TempList.RemoveAt(firstItem);
                lbFavorites.Items.RemoveAt(firstItem);
            }
        }

        private void GoBack()
        {
            var currentDirectory = new DirectoryInfo(tbPathView.Text);
            var parentDirectory = currentDirectory.Parent;
            if (parentDirectory != null)
            {
                tbPathView.Text = parentDirectory.FullName;
                PopulateSelected(parentDirectory.FullName);
            }
        }

        private void SaveSettings()
        {
            if (TempList?.Any() == true)
                ListHandler.FavoriteFolderList = TempList;
            else
                ListHandler.ClearFavoriteFolderList();

            if (!string.IsNullOrWhiteSpace(tbPathView.Text))
            {
                PathHandler.TempRecentFolder = tbPathView.Text;
            }

            int recentCount;

            try
            {
                recentCount = Convert.ToInt32(tbCount.Text);
                if (recentCount <= 0) { recentCount = 0; }
            }
            catch (Exception)
            {
                recentCount = 0;
                MessageBox.Show("Count has to be a valid number");
            }

            if (SettingsHandler.RecentCheckedSaved)
            {
                SettingsHandler.RecentChecked = cbUseRecent.Checked;
            }
            if (SettingsHandler.RecentCountSaved)
            {
                SettingsHandler.RecentCount = recentCount;
            }

            SettingsHandler.RecentCheckedTemp = cbUseRecent.Checked;
            SettingsHandler.RecentCountSavedTemp = recentCount;
            SettingsHandler.TempTriggered = true;

            ListHandler.IncludeSubfolders = cbIncludeSubfolders.Checked;

            SettingsHandler.TileSizeFileBrowser = _tileSize;
        }
        private void ChangeViewFileExplore(string viewState)
        {
            if (viewState == "Grid")
            {
                btnViewGrid.IconColor = Color.Gold;
                btnViewTile.IconColor = Color.Black;
                btnViewList.IconColor = Color.Black;
                _viewStateFolderFileExplore = "Grid";

                lvFileExplore.View = System.Windows.Forms.View.LargeIcon;
            }
            else if (viewState == "Tile")
            {
                btnViewGrid.IconColor = Color.Black;
                btnViewTile.IconColor = Color.Gold;
                btnViewList.IconColor = Color.Black;
                _viewStateFolderFileExplore = "Tile";

                lvFileExplore.View = System.Windows.Forms.View.Tile;
                lvFileExplore.TileSize = _tileSize;
            }
            else if (viewState == "List")
            {
                btnViewGrid.IconColor = Color.Black;
                btnViewTile.IconColor = Color.Black;
                btnViewList.IconColor = Color.Gold;
                _viewStateFolderFileExplore = "List";

                lvFileExplore.View = System.Windows.Forms.View.Details;
            }

            UpdateSizeButtons();
            PopulateSelected(tbPathView.Text);
            lvFileExplore.Refresh();
        }

        private void UpdateSizeButtons()
        {
            if (_viewStateFolderFileExplore == "Tile")
            {
                btnDecreaseSize.Enabled = true;
                btnResetSize.Enabled = true;
                btnIncreaseSize.Enabled = true;
            }
            else
            {
                btnDecreaseSize.Enabled = false;
                btnResetSize.Enabled = false;
                btnIncreaseSize.Enabled = false;
            }
        }

        private void SetupTooltips()
        {
            toolTipInfo.SetToolTip(btnDecreaseSize, "Decrease tile size");
            toolTipInfo.SetToolTip(btnResetSize, "Restore tile size");
            toolTipInfo.SetToolTip(btnIncreaseSize, "Increase tile size");

            toolTipInfo.SetToolTip(btnViewList, "Change view to list");
            toolTipInfo.SetToolTip(btnViewTile, "Change view to tile");
            toolTipInfo.SetToolTip(btnViewGrid, "Change view to grid");

            toolTipInfo.SetToolTip(btnBack, "MB4 | Go back one folder");
            toolTipInfo.SetToolTip(btnFolderSelect, "Use current folder to play from");
            toolTipInfo.SetToolTip(btnAddFav, "Add current folder to your list of favorites");
            toolTipInfo.SetToolTip(btnDeleteFav, "Delete selected folder from your list of favorites");

            toolTipInfo.SetToolTip(cbUseRecent, $"Check to load only the latest {tbCount.Text} files chosen on the input to the right");
            toolTipInfo.SetToolTip(cbIncludeSubfolders, "Include all subdirectories of the current selected directory");
            cbUseRecent.Text = $"Only latest {tbCount.Text} files";
            toolTipInfo.SetToolTip(tbCount, "Input how many of the latest files are loaded into the playlist");
        }
        #endregion

        #region Form Controls

        private void FolderBrowserView_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this);
        }

        private void lblTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            //Needed to be able to drag the form and use windows aero peek functions
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region WndProc Code for clean style of the Form and regaining usabality
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

    }
}
