﻿using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System.Runtime.InteropServices;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace RandomVideoPlayer.View
{
    public partial class ListBrowserView : Form
    {
        FormResize fR = new FormResize();

        List<string> TempList = new List<string>();
        List<string> TempFavList = new List<string>();

        private List<string> extensionFilter { get; set; }

        public ListBrowserView()
        {
            InitializeComponent();
            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.FromArgb(248, 111, 100);//Border color

            extensionFilter = new List<string>(ListHandler.ExtensionFilterForList);

            InitializeFilterBoxes();
            InitializeCheckboxEvents();
        }

        private void ListBrowserView_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PathHandler.DefaultFolder)) { PathHandler.DefaultFolder = PathHandler.FallbackPath; } //If Folder is not set yet, default to Fallback

            if (!string.IsNullOrEmpty(PathHandler.TempRecentFolder)) { tbPathView.Text = PathHandler.TempRecentFolder; } //Keep recently browsed folders active for consistency
            else { tbPathView.Text = PathHandler.DefaultFolder; }

            PopulateSelected(tbPathView.Text);

            PopulateDrives();

            HighlightDriveInListBox(tbPathView.Text);

            if (ListHandler.CustomList?.Any() == true)
            {
                var strings = new List<string>();

                foreach (string str in ListHandler.CustomList)
                {
                    strings.Add(str);
                    lbCustomList.Items.Add(str);
                }
                TempList = strings;
            }

            lblTitle.Text = $"RVP - ListBrowser - Entries: {lbCustomList.Items.Count.ToString()}";

            if (ListHandler.FavoriteFolderList?.Any() == true)
            {
                foreach (string str in ListHandler.FavoriteFolderList)
                {
                    TempFavList.Add(str);

                    var dir = new DirectoryInfo(str);
                    string folderName = FileManipulation.TrimText(dir.Name, 19, "...");

                    lbFavorites.Items.Add(folderName);
                }
            }

            btnAddSelected.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            btnAddSelected.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnAddAll.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            btnAddAll.IconFont = FontAwesome.Sharp.IconFont.Solid;

            SetupTooltips();
        }       
        private void ListBrowserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListHandler.ExtensionFilterForList = extensionFilter;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            var currentDirectory = new DirectoryInfo(tbPathView.Text);
            var parentDirectory = currentDirectory.Parent;
            if (parentDirectory != null)
            {
                tbPathView.Text = parentDirectory.FullName;
                PopulateSelected(parentDirectory.FullName);
            }
        }
        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            var filteredPaths = new List<string>();
            var combinedExtensions = extensionFilter;
            lbCustomList.Items.Clear();

            foreach (ListViewItem item in lvFileExplore.SelectedItems)
            {
                var filePath = item.Tag.ToString();
                var fileType = item.SubItems[1].Text;
                if (combinedExtensions.Contains(fileType.TrimStart('.')))
                {
                    filteredPaths.Add(filePath);
                }
                if (fileType == "Folder")
                {
                    GrabFromDirectory(filePath);
                }
            }
            TempList.AddRange(filteredPaths);
            lbCustomList.Items.AddRange(TempList.ToArray());
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lbCustomList.Items.Count.ToString()}";
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbPathView.Text))
            {
                lbCustomList.Items.Clear();
                GrabFromDirectory(tbPathView.Text);
                lbCustomList.Items.AddRange(TempList.ToArray());
            }
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lbCustomList.Items.Count.ToString()}";
        }
        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            int firstItem = lbCustomList.SelectedIndex;
            int itemCount = firstItem + lbCustomList.SelectedIndices.Count;

            for (int i = firstItem; i < itemCount; i++)
            {
                TempList.RemoveAt(firstItem);
                lbCustomList.Items.RemoveAt(firstItem);
            }
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lbCustomList.Items.Count.ToString()}";
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lbCustomList.Items.Clear();
            TempList.Clear();
            ListHandler.ClearCustomList();
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lbCustomList.Items.Count.ToString()}";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (TempList?.Any() == true) //If anything was modified, save the list
            {
                ListHandler.CustomList = TempList;
            }

            if (TempFavList?.Any() == true)
            {
                ListHandler.FavoriteFolderList = TempFavList;
            }
            else if (TempFavList.Count == 0)
            {
                ListHandler.ClearFavoriteFolderList();
            }

            if (tbPathView.Text != null)
            {
                PathHandler.TempRecentFolder = tbPathView.Text;
            }

            this.Close();
        }
        private void btnLoadList_Click_1(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = PathHandler.FolderList;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lbCustomList.Items.Clear();
                var strings = new List<string>();
                var fromTXT = File.ReadLines(openFileDialog.FileName).ToList();

                foreach (string str in fromTXT)
                {
                    strings.Add(str);
                    lbCustomList.Items.Add(str);
                }
                TempList = strings;
            }

            lblTitle.Text = $"RVP - ListBrowser - Entries: {lbCustomList.Items.Count.ToString()}";
        }
        private void btnSaveList_Click_1(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = PathHandler.FolderList;
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog.FileName, TempList);
            }
        }
        private void btnUseList_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (TempList?.Any() == true) //If anything was modified, save the list
            {
                ListHandler.CustomList = TempList;
            }

            if (TempFavList?.Any() == true)
            {
                ListHandler.FavoriteFolderList = TempFavList;
            }
            else if (TempFavList.Count == 0)
            {
                ListHandler.ClearFavoriteFolderList();
            }

            if (tbPathView.Text != null)
            {
                PathHandler.TempRecentFolder = tbPathView.Text;
            }
            this.Close();
        }
        private void btnDelDuplicates_Click(object sender, EventArgs e)
        {
            // Use LINQ to filter out duplicates based on the filename, keeping one entry for each filename
            var filteredList = TempList
                .GroupBy(path => Path.GetFileName(path))
                .Select(g => g.First())
                .OrderBy(path => TempList.IndexOf(path))
                .ToList();

            TempList = filteredList;
            lbCustomList.Items.Clear();

            foreach (var item in TempList)
            {
                lbCustomList.Items.Add(item);
            }
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lbCustomList.Items.Count.ToString()}";
        }
        private void lvFileExplore_ItemActivate(object sender, EventArgs e)
        {
            var item = lvFileExplore.SelectedItems[0];
            var itemPath = item.Tag.ToString();
            try
            {
                if (Directory.Exists(itemPath))
                {
                    tbPathView.Text = itemPath;
                    PopulateSelected(itemPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Can't access folder: {0}\n\nError:\n{1}", itemPath, ex));
                return;
            }
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
        private void btnAddFav_Click(object sender, EventArgs e)
        {
            TempFavList.Add(tbPathView.Text);

            lbFavorites.Items.Clear();

            if (TempFavList?.Any() == true)
            {
                foreach (string str in TempFavList)
                {
                    var dir = new DirectoryInfo(str);
                    string folderName = FileManipulation.TrimText(dir.Name, 19, "...");

                    lbFavorites.Items.Add(folderName);
                }
            }
        }
        private void btnDeleteFav_Click(object sender, EventArgs e)
        {
            int firstItem = lbFavorites.SelectedIndex;
            int itemCount = firstItem + lbFavorites.SelectedIndices.Count;

            for (int i = firstItem; i < itemCount; i++)
            {
                TempFavList.RemoveAt(firstItem);
                lbFavorites.Items.RemoveAt(firstItem);
            }
        }
        private void lbCustomList_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lbCustomList.IndexFromPoint(e.Location);

            if (index >= 0 && index < lbCustomList.Items.Count)
            {
                string itemText = lbCustomList.Items[index].ToString();

                // Check if the tooltip text is different than the item text (to avoid flickering)
                if (toolTipInfo.GetToolTip(lbCustomList) != itemText)
                {
                    toolTipInfo.SetToolTip(lbCustomList, itemText);
                }
            }
            else
            {
                toolTipInfo.SetToolTip(lbCustomList, "");
            }
        }
        private void lbFavorites_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lbFavorites.IndexFromPoint(e.Location);

            if (index >= 0 && index < lbFavorites.Items.Count)
            {
                string itemText = TempFavList[index];

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
        private void lbFavorites_DoubleClick(object sender, EventArgs e)
        {
            if (lbFavorites.SelectedItems.Count > 0 && lbFavorites.SelectedIndex >= 0)
            {
                string selectedPath = TempFavList[lbFavorites.SelectedIndex];
                tbPathView.Text = selectedPath;
                PopulateSelected(selectedPath);
                HighlightDriveInListBox(tbPathView.Text);
            }
        }
        private void ListBrowserView_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this);
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            //Needed to be able to drag the form and use windows aero peek functions
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void SetupTooltips()
        {
            toolTipInfo.SetToolTip(btnAddSelected, "Add all files and files from subfolders within selected items on the left");
            toolTipInfo.SetToolTip(btnAddAll, "Add all files and files from subfolders from current folder");
            toolTipInfo.SetToolTip(btnClearSelected, "Delete selected entries from list");
            toolTipInfo.SetToolTip(btnClearList, "Delete all entries from list");

            toolTipInfo.SetToolTip(btnDelDuplicates, "Scan list for duplicate entries and remove those");
            toolTipInfo.SetToolTip(btnLoadList, "Load a saved list file");
            toolTipInfo.SetToolTip(btnSaveList, "Save current list to file");
            toolTipInfo.SetToolTip(btnUseList, "Start playback with current list");

            toolTipInfo.SetToolTip(btnBack, "Go back one folder");
            toolTipInfo.SetToolTip(btnAddFav, "Add current folder to your list of favorites");
            toolTipInfo.SetToolTip(btnDeleteFav, "Delete selected folder from your list of favorites");
        }

        #region Functions to grab directories and files from given path and fill listview
        //Fill the listView with Directories and Files
        private void PopulateSelected(string folderPath)
        {
            lvFileExplore.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            var combinedExtensions = extensionFilter;

            foreach (DirectoryInfo subFolder in dir.EnumerateDirectories())
            {
                ListViewItem item = new ListViewItem();
                item.Text = FileManipulation.TrimText(subFolder.Name, 33, "");
                item.ImageIndex = 0;
                item.SubItems.Add("Folder");
                item.Tag = subFolder.FullName;
                item.ToolTipText = subFolder.Name;
                lvFileExplore.Items.Add(item);
            }
            foreach (FileInfo file in dir.EnumerateFiles())
            {
                string currentFileExtension = Path.GetExtension(file.Name).TrimStart('.').ToLower();
                if (!combinedExtensions.Contains(currentFileExtension)) continue;
                ListViewItem item = new ListViewItem();
                item.Text = file.Name;
                if (extensionToImageIndex.TryGetValue(currentFileExtension, out int imageIndex))
                {
                    item.ImageIndex = imageIndex;
                }
                else
                {
                    item.ImageIndex = 0; 
                }
                item.SubItems.Add(file.Extension.ToLower());
                item.Tag = file.FullName;
                item.ToolTipText = file.Name;
                lvFileExplore.Items.Add(item);
            }
        }
        //Get all files from current and sub directories

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
        private void HighlightDriveInListBox(string path) //Hightlight drive that is currently in use within listview
        {
            // Extract the drive letter and format (e.g., "G:/")
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
        private void GrabFromDirectory(string folderPath)
        {
            var combinedExtensions = extensionFilter;
            //Get all Files from current Directory and return all Files filtered by Extensions
            TempList.AddRange(Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => combinedExtensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                    .ToArray());

        }
        private void InitializeFilterBoxes()
        {
            foreach (Control control in panelExtensionFilter.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = extensionFilter.Contains(checkBox.Text);
                }
            }
        }
        private void InitializeCheckboxEvents()
        {
            cbAVI.CheckedChanged += CheckBox_CheckedChanged;
            cbAVCHD.CheckedChanged += CheckBox_CheckedChanged;
            cbF4V.CheckedChanged += CheckBox_CheckedChanged;
            cbFLV.CheckedChanged += CheckBox_CheckedChanged;
            cbM4V.CheckedChanged += CheckBox_CheckedChanged;
            cbMKV.CheckedChanged += CheckBox_CheckedChanged;
            cbMOV.CheckedChanged += CheckBox_CheckedChanged;
            cbMP4.CheckedChanged += CheckBox_CheckedChanged;
            cbWEBM.CheckedChanged += CheckBox_CheckedChanged;
            cbWMV.CheckedChanged += CheckBox_CheckedChanged;

            cbJPG.CheckedChanged += CheckBox_CheckedChanged;
            cbJPEG.CheckedChanged += CheckBox_CheckedChanged;
            cbPNG.CheckedChanged += CheckBox_CheckedChanged;
            cbGIF.CheckedChanged += CheckBox_CheckedChanged;
            cbTIF.CheckedChanged += CheckBox_CheckedChanged;
            cbTIFF.CheckedChanged += CheckBox_CheckedChanged;
            cbBMP.CheckedChanged += CheckBox_CheckedChanged;
            cbWEBP.CheckedChanged += CheckBox_CheckedChanged;
            cbAVIF.CheckedChanged += CheckBox_CheckedChanged;
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                if (checkBox.Checked)
                {
                    if (!extensionFilter.Contains(checkBox.Text))
                    {
                        extensionFilter.Add(checkBox.Text);
                    }
                }
                else
                {
                    if (extensionFilter.Contains(checkBox.Text))
                    {
                        extensionFilter.Remove(checkBox.Text);
                    }
                }

                PopulateSelected(tbPathView.Text);
            }
        }
        Dictionary<string, int> extensionToImageIndex = new Dictionary<string, int>
        {
            { "avi", 1 },
            { "flv", 2 },
            { "m4v", 3 },
            { "mkv", 4 },
            { "mov", 5 },
            { "mp4", 6 },
            { "webm", 7 },
            { "wmv", 8 },
            { "f4v", 9 },
            { "avchd", 10 },
            { "jpg", 11 },
            { "jpeg", 12 },
            { "png", 13 },
            { "gif", 14 },
            { "tif", 15 },
            { "tiff", 16 },
            { "bmp", 17 },
            { "webp", 18 },
            { "avif", 19 }
        };

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
