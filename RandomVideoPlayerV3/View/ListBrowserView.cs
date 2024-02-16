using RandomVideoPlayerV3.Functions;
using RandomVideoPlayerV3.Model;
using System.Runtime.InteropServices;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace RandomVideoPlayerV3.View
{
    public partial class ListBrowserView : Form
    {
        FormResize fR = new FormResize();
        PathHandler pH = new PathHandler();
        ListHandler lH = new ListHandler();

        List<string> TempList = new List<string>();
        List<string> TempFavList = new List<string>();

        public ListBrowserView()
        {
            InitializeComponent();

            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.FromArgb(248, 111, 100);//Border color
        }

        private void ListBrowserView_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pH.DefaultFolder)) { pH.DefaultFolder = pH.FallbackPath; } //If Folder is not set yet, default to Fallback

            tbPathView.Text = pH.DefaultFolder;

            PopulateSelected(pH.DefaultFolder);

            PopulateDrives();

            HighlightDriveInListBox(tbPathView.Text);

            if (lH.CustomList?.Any() == true)
            {
                List<string> strings = new List<string>();

                foreach (string str in lH.CustomList)
                {
                    strings.Add(str);
                    lbCustomList.Items.Add(str);
                }
                TempList = strings;
            }

            lblCount.Text = "Entries: " + lbCustomList.Items.Count.ToString();

            if (lH.FavoriteList?.Any() == true)
            {
                foreach (string str in lH.FavoriteList)
                {
                    TempFavList.Add(str);

                    DirectoryInfo dir = new DirectoryInfo(str);
                    string folderName = pH.TrimText(dir.Name, 19, "...");

                    lbFavorites.Items.Add(folderName);                    
                }
            }

            btnAddSelected.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            btnAddSelected.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnAddAll.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            btnAddAll.IconFont = FontAwesome.Sharp.IconFont.Solid;

            SetupTooltips(); //Initialize ToolTips
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(tbPathView.Text);
            DirectoryInfo parentDirectory = currentDirectory.Parent;
            if (parentDirectory != null)
            {
                tbPathView.Text = parentDirectory.FullName;
                PopulateSelected(parentDirectory.FullName);
            }
        }
        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            List<string> filteredPaths = new List<string>();

            lbCustomList.Items.Clear();

            foreach (ListViewItem item in lvFileExplore.SelectedItems)
            {
                string filePath = item.Tag.ToString();
                string fileType = item.SubItems[1].Text;
                if (lH.VidExtensions.Contains(fileType.TrimStart('.')))
                {
                    filteredPaths.Add(filePath);
                }
                if (fileType == "Folder")
                {
                    //Get all Files from current Directory and return all Files filtered by VidExtensions
                    TempList.AddRange(Directory.EnumerateFiles(filePath, "*.*", SearchOption.AllDirectories)
                            .Where(s => lH.VidExtensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                            .ToArray());
                }
            }
            TempList.AddRange(filteredPaths);
            lbCustomList.Items.AddRange(TempList.ToArray());
            lblCount.Text = "Entries: " + lbCustomList.Items.Count.ToString();
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (tbPathView.Text != null)
            {
                lbCustomList.Items.Clear();
                GrabFromDirectory(tbPathView.Text);
            }
            lblCount.Text = "Entries: " + lbCustomList.Items.Count.ToString();
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
            lblCount.Text = "Entries: " + lbCustomList.Items.Count.ToString();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lbCustomList.Items.Clear();
            TempList.Clear();
            lH.ClearCustomList();
            lblCount.Text = "Entries: " + lbCustomList.Items.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (TempList?.Any() == true) //If anything was modified, save the list
            {
                lH.CustomList = TempList;
            }

            if (TempFavList?.Any() == true)
            {
                lH.FavoriteList = TempFavList;
            }
            else if (TempFavList.Count == 0)
            {
                lH.ClearFavoriteList();
            }

            this.Close();
        }
        private void btnLoadList_Click_1(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = pH.FolderList;
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                lbCustomList.Items.Clear();
                //tbDefaultPath.Text = fbDialog.SelectedPath;
                List<string> strings = new List<string>();
                List<string> fromTXT = System.IO.File.ReadLines(openFileDialog.FileName).ToList();

                foreach (string str in fromTXT)
                {
                    strings.Add(str);
                    lbCustomList.Items.Add(str);
                }
                TempList = strings;
            }

            lblCount.Text = "Entries: " + lbCustomList.Items.Count.ToString();
        }
        private void btnSaveList_Click_1(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = pH.FolderList;
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog.FileName, TempList);
            }
        }
        private void btnDelDuplicates_Click(object sender, EventArgs e)
        {
            // Use LINQ to filter out duplicates based on the filename, keeping one entry for each filename
            var filteredList = TempList
                // Group by filename
                .GroupBy(path => Path.GetFileName(path))
                // Select one item per group (first by default)
                .Select(g => g.First())
                // Optionally, if you want to preserve the original list order as much as possible
                .OrderBy(path => TempList.IndexOf(path))
                .ToList();

            // Replace the original list with the filtered list (if desired)
            TempList = filteredList;

            lbCustomList.Items.Clear();
            // Output the result for demonstration
            foreach (var item in TempList)
            {
                lbCustomList.Items.Add(item);
            }
            lblCount.Text = "Entries: " + lbCustomList.Items.Count.ToString();
        }
        private void lvFileExplore_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = lvFileExplore.SelectedItems[0];
            string itemPath = item.Tag.ToString();
            if (Directory.Exists(itemPath))
            {
                tbPathView.Text = itemPath;
                PopulateSelected(itemPath);
            }
        }
        private void lbDriveFolders_DoubleClick(object sender, EventArgs e)
        {
            if (lbDriveFolders.SelectedItems != null)
            {
                string driveLetter = pH.TrimText(lbDriveFolders.SelectedItem.ToString(), 3, "");
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
                    DirectoryInfo dir = new DirectoryInfo(str);
                    string folderName = pH.TrimText(dir.Name, 19, "...");

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
                // Get the item text
                string itemText = lbCustomList.Items[index].ToString();

                // Check if the tooltip text is different than the item text (to avoid flickering)
                if (toolTipInfo.GetToolTip(lbCustomList) != itemText)
                {
                    // Show the tooltip with the item text
                    toolTipInfo.SetToolTip(lbCustomList, itemText);
                }
            }
            else
            {
                // Hide the tooltip if the mouse is not over an item
                toolTipInfo.SetToolTip(lbCustomList, "");
            }
        }  
        private void lbFavorites_DoubleClick(object sender, EventArgs e)
        {
            if (lbFavorites.SelectedItems != null)
            {
                string selectedPath = TempFavList[lbFavorites.SelectedIndex];
                tbPathView.Text = selectedPath;
                PopulateSelected(selectedPath);
                HighlightDriveInListBox(tbPathView.Text);
            }
        }
        private void lbFavorites_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lbFavorites.IndexFromPoint(e.Location);

            if (index >= 0 && index < lbFavorites.Items.Count)
            {
                // Get the item text
                string itemText = TempFavList[index]; 

                // Check if the tooltip text is different than the item text (to avoid flickering)
                if (toolTipInfo.GetToolTip(lbFavorites) != itemText)
                {
                    // Show the tooltip with the item text
                    toolTipInfo.SetToolTip(lbFavorites, itemText);
                }
            }
            else
            {
                // Hide the tooltip if the mouse is not over an item
                toolTipInfo.SetToolTip(lbFavorites, "");
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
            foreach (DirectoryInfo subFolder in dir.EnumerateDirectories())
            {
                ListViewItem item = new ListViewItem();
                item.Text = pH.TrimText(subFolder.Name, 13, "");
                item.ImageIndex = 0;
                item.SubItems.Add("Folder");
                item.Tag = subFolder.FullName;
                lvFileExplore.Items.Add(item);
            }
            foreach (FileInfo file in dir.EnumerateFiles())
            {
                ListViewItem item = new ListViewItem();
                item.Text = pH.TrimText(file.Name, 10, "...");
                item.ImageIndex = 1;
                item.SubItems.Add(file.Extension.ToLower());
                item.Tag = file.FullName;
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
                    // Set the found item as the selected item
                    lbDriveFolders.SelectedItem = item;
                    break; // Exit the loop once the item is found and selected
                }
            }
        }


        private void GrabFromDirectory(string folderPath)
        {
            //Get all Files from current Directory and return all Files filtered by VidExtensions
            TempList.AddRange(Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => lH.VidExtensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                    .ToArray());

            //Fill ListBox with Items 
            lbCustomList.Items.AddRange(TempList.ToArray());
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
