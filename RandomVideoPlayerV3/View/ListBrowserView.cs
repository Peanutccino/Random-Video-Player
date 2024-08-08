using Microsoft.VisualBasic;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Documents;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace RandomVideoPlayer.View
{
    public partial class ListBrowserView : Form
    {
        FormResize fR = new FormResize();

        List<string> TempList = new List<string>();
        List<string> TempFavList = new List<string>();

        private Size _tileSize;

        private bool _showIcons;
        private bool _showFullPath;
        private string _viewStateListFileExplore;
        private List<string> extensionFilter { get; set; }

        public ListBrowserView()
        {
            InitializeComponent();
            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.FromArgb(248, 111, 100);//Border color

            _showIcons = SettingsHandler.ShowIconsCustomLíst;
            _showFullPath = SettingsHandler.ShowFullPathCustomList;
            _viewStateListFileExplore = SettingsHandler.ViewStateListFileExplore;
            _tileSize = SettingsHandler.TileSizeFileExplore;


            extensionFilter = new List<string>(ListHandler.ExtensionFilterForList);

            InitializeFilterBoxes();
            InitializeCheckboxEvents();
        }

        private void ListBrowserView_Load(object sender, EventArgs e)
        {
            string tempPath = PathHandler.TempRecentFolder;
            string defaultPath = PathHandler.DefaultFolder;
            string fallbackPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (!string.IsNullOrWhiteSpace(tempPath) && Directory.Exists(tempPath))
            {
                tbPathView.Text = tempPath;
            }
            else if (!string.IsNullOrWhiteSpace(defaultPath) && Directory.Exists(defaultPath))
            {
                tbPathView.Text = defaultPath;
            }
            else
            {
                tbPathView.Text = fallbackPath;
            }


            cbShowIcons.Checked = _showIcons;
            cbFullPath.Checked = _showFullPath;

            PopulateSelected(tbPathView.Text);

            PopulateDrives();

            HighlightDriveInListBox(tbPathView.Text);

            lvCustomList.Columns[0].Width = lvCustomList.Width - 30;
            lvFileExplore.Columns[0].Width = lvFileExplore.Width - 30;

            ChangeViewFileExplore(_viewStateListFileExplore);

            if (ListHandler.CustomList?.Any() == true)
            {
                var strings = new List<string>();

                foreach (string str in ListHandler.CustomList)
                {
                    strings.Add(str);
                }
                TempList = strings;
                PopulateCustomList(TempList);
            }

            lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";

            PopulateFavoriteFolders();

            SetupTooltips();
        }
        private void ListBrowserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListHandler.ExtensionFilterForList = extensionFilter;
            SettingsHandler.ShowIconsCustomLíst = _showIcons;
            SettingsHandler.ShowFullPathCustomList = _showFullPath;
            SettingsHandler.ViewStateListFileExplore = _viewStateListFileExplore;
            SettingsHandler.TileSizeFileExplore = _tileSize;
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

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            var filteredPaths = new List<string>();
            var combinedExtensions = extensionFilter;

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
            PopulateCustomList(TempList);
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";
        }
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbPathView.Text))
            {
                GrabFromDirectory(tbPathView.Text);
                PopulateCustomList(TempList);
            }
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";
        }
        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            if (lvCustomList.SelectedIndices.Count > 0)
            {
                int firstItem = lvCustomList.SelectedIndices[0];
                int itemCount = firstItem + lvCustomList.SelectedIndices.Count;

                for (int i = firstItem; i < itemCount; i++)
                {
                    TempList.RemoveAt(firstItem);
                }
                PopulateCustomList(TempList);
            }
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lvCustomList.Items.Clear();
            TempList.Clear();
            ListHandler.ClearCustomList();
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";
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
                TempList = strings;
                PopulateCustomList(TempList);

                lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";
            }
        }
        private void btnSaveList_Click_1(object sender, EventArgs e)
        {
            SaveListView saveListView = new SaveListView();
            saveListView.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = saveListView.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    var pathToList = PathHandler.PathToListFolder + @"\" + saveListView.ListToSave + ".txt";
                    File.WriteAllLines(pathToList, TempList);
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to save list");
                    MessageBox.Show($"Failed to save list: {ex}");
                    throw;
                }
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
            PopulateCustomList(TempList);
            lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";
        }

        private void btnAddFromPlaylist_Click(object sender, EventArgs e)
        {
            TempList.AddRange(ListHandler.PlayList);
            PopulateCustomList(TempList);

            lblTitle.Text = $"RVP - ListBrowser - Entries: {lvCustomList.Items.Count.ToString()}";
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
                Error.Log(ex, "Error accessing selected folder - LB lvFE_ItemActivate");
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
        private void lvCustomList_Resize(object sender, EventArgs e)
        {
            lvCustomList.Columns[0].Width = lvCustomList.Width - 40;
        }

        private void cbShowIcons_CheckedChanged(object sender, EventArgs e)
        {
            _showIcons = cbShowIcons.Checked;
            PopulateCustomList(TempList);
        }

        private void cbFullPath_CheckedChanged(object sender, EventArgs e)
        {
            _showFullPath = cbFullPath.Checked;
            PopulateCustomList(TempList);
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


        private void ChangeViewFileExplore(string viewState)
        {
            if (viewState == "Grid")
            {
                btnViewGrid.IconColor = Color.Crimson;
                btnViewTile.IconColor = Color.Black;
                btnViewList.IconColor = Color.Black;
                _viewStateListFileExplore = "Grid";

                lvFileExplore.View = System.Windows.Forms.View.LargeIcon;
            }
            else if (viewState == "Tile")
            {
                btnViewGrid.IconColor = Color.Black;
                btnViewTile.IconColor = Color.Crimson;
                btnViewList.IconColor = Color.Black;
                _viewStateListFileExplore = "Tile";

                lvFileExplore.View = System.Windows.Forms.View.Tile;
                lvFileExplore.TileSize = _tileSize;
            }
            else if (viewState == "List")
            {
                btnViewGrid.IconColor = Color.Black;
                btnViewTile.IconColor = Color.Black;
                btnViewList.IconColor = Color.Crimson;
                _viewStateListFileExplore = "List";

                lvFileExplore.View = System.Windows.Forms.View.Details;
            }
            UpdateSizeButtons();
            PopulateSelected(tbPathView.Text);
            lvFileExplore.Refresh();
        }

        private void lvFileExplore_Resize(object sender, EventArgs e)
        {
            lvFileExplore.Columns[0].Width = lvFileExplore.Width - 30;
        }
        private void btnDecreaseSize_Click(object sender, EventArgs e)
        {
            if (_tileSize.Width <= 110) return;

            _tileSize = new Size(_tileSize.Width - 10, _tileSize.Height);

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

        private void btnResetSize_Click(object sender, EventArgs e)
        {
            _tileSize = new Size(150, 40);

            lvFileExplore.TileSize = _tileSize;

            PopulateSelected(tbPathView.Text);
            lvFileExplore.Refresh();
        }

        private void UpdateSizeButtons()
        {
            if (_viewStateListFileExplore == "Tile")
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

            toolTipInfo.SetToolTip(btnAddSelected, "Add all files and files from subfolders within selected items on the left");
            toolTipInfo.SetToolTip(btnAddAll, "Add all files and files from subfolders from current folder");
            toolTipInfo.SetToolTip(btnClearSelected, "Delete selected entries from list");
            toolTipInfo.SetToolTip(btnClearList, "Delete all entries from list");

            toolTipInfo.SetToolTip(btnDelDuplicates, "Scan list for duplicate entries and remove those");
            toolTipInfo.SetToolTip(btnLoadList, "Load a saved list file");
            toolTipInfo.SetToolTip(btnSaveList, "Save current list to file");
            toolTipInfo.SetToolTip(btnAddFromPlaylist, "Add all entries from current Playlist queue to list");
            toolTipInfo.SetToolTip(btnUseList, "Start playback with current list");

            toolTipInfo.SetToolTip(btnBack, "MB4 | Go back one folder");
            toolTipInfo.SetToolTip(btnAddFav, "Add current folder to your list of favorites");
            toolTipInfo.SetToolTip(btnDeleteFav, "Delete selected folder from your list of favorites");
        }

        #region Drag and Drop
        private void lvFileExplore_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<ListViewItem> selectedItems = new List<ListViewItem>();
            foreach (ListViewItem item in lvFileExplore.SelectedItems)
            {
                selectedItems.Add(item);
            }

            if (selectedItems.Count > 0)
            {
                lvFileExplore.DoDragDrop(selectedItems, DragDropEffects.Move);
            }
        }

        private void lvCustomList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)) || e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                lvCustomList.BackColor = Color.Honeydew;                
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvCustomList_DragDrop(object sender, DragEventArgs e)
        {
            //If dropped from lvFileExplore
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                try
                {
                    var filteredPaths = new List<string>();
                    var combinedExtensions = extensionFilter;

                    List<ListViewItem> items = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));

                    foreach (ListViewItem item in items)
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
                    PopulateCustomList(TempList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load dropped files: \n\n {ex}");
                    Error.Log(ex, "Failed to load dropped files from lvFileExplore");
                }

            }
            //If dropped from outside
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    string[] rawFilePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                    var combinedExtensions = extensionFilter;
                    var filteredPaths = new List<string>();

                    foreach (string filePath in rawFilePaths)
                    {
                        if (Directory.Exists(filePath))
                        {
                            GrabFromDirectory(filePath);
                        }
                        else if (File.Exists(filePath))
                        {
                            string currentFileExtension = Path.GetExtension(filePath).TrimStart('.').ToLower();
                            if (!combinedExtensions.Contains(currentFileExtension)) continue;

                            filteredPaths.Add(filePath);
                        }
                    }
                    TempList.AddRange(filteredPaths);
                    PopulateCustomList(TempList);
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to load dropped files from winExplorer");
                    MessageBox.Show($"Failed to load dropped files: \n\n {ex}");
                }
            }
            lvCustomList.BackColor = Color.MintCream;
        }

        private void lvCustomList_DragLeave(object sender, EventArgs e)
        {
            lvCustomList.BackColor = Color.MintCream;
        }
        #endregion

        #region Functions to grab directories and files from given path and fill listview
        //Fill the listView with Directories and Files
        private void PopulateSelected(string folderPath)
        {
            try
            {
                lvFileExplore.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(folderPath);
                var combinedExtensions = extensionFilter;

                foreach (DirectoryInfo subFolder in dir.EnumerateDirectories())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = subFolder.Name;
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
                    item.SubItems.Add(file.Extension.ToLower());
                    item.Tag = file.FullName;
                    item.ToolTipText = file.Name;
                    lvFileExplore.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Error populating lvFileExplore in LB");
                throw;
            }
        }
        private void PopulateCustomList(List<string> strings)
        {
            lvCustomList.Items.Clear();
            lvCustomList.SmallImageList = _showIcons ? imageListLarge : new ImageList();

            foreach (string entry in strings)
            {
                FileInfo file = new FileInfo(entry);
                string currentFileExtension = Path.GetExtension(file.Name).TrimStart('.').ToLower();
                ListViewItem item = new ListViewItem();
                item.Text = _showFullPath ? file.FullName : file.Name;
                if (_showIcons && extensionToImageIndex.TryGetValue(currentFileExtension, out int imageIndex))
                {
                    item.ImageIndex = imageIndex;
                }
                item.ToolTipText = file.FullName;
                lvCustomList.Items.Add(item);
            }

            lvCustomList.SmallImageList = _showIcons ? imageListLarge : null;
            lvCustomList.Refresh();
        }
        private void GrabFromDirectory(string folderPath)
        {
            var combinedExtensions = extensionFilter;
            try
            {
                //Get all Files from current Directory and return all Files filtered by Extensions
                TempList.AddRange(Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => combinedExtensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                        .ToArray());
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Unable to gather directory information in LB");
                MessageBox.Show($"Unable to gather directory information: {ex}");
                return;
            }
        }

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
                            TempFavList.Add(str);

                            var dir = new DirectoryInfo(str);
                            string folderName = FileManipulation.TrimText(dir.Name, 19, "...");

                            lbFavorites.Items.Add(folderName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, "Unable to gather favorite folders in LB");
                        continue;
                    }
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
        private void InitializeFilterBoxes()
        {
            foreach (Control control in panelFilterExt.Controls)
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
