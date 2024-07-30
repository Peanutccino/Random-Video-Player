using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System.Data;
using System.Runtime.InteropServices;

namespace RandomVideoPlayer.View
{
    public partial class SaveListView : Form
    {
        FormResize fR = new FormResize();

        public string ListToSave;
        private List<string> _allNamesInList = new List<string>();
        private char[] _invalidChars = Path.GetInvalidFileNameChars();

        private string _textboxContent;
        public SaveListView()
        {
            InitializeComponent();
            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.PaleGreen;//Border color
        }

        private void SaveListView_Load(object sender, EventArgs e)
        {
            PopulateList();
            SetupTooltips();
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            SaveList();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvListSelect.SelectedItems.Count == 0) return;

            var fileName = lvListSelect.SelectedItems[0].Text;
            var pathToFile = lvListSelect.SelectedItems[0].Tag.ToString();
            DialogResult resultConfirmation = MessageBox.Show("Do you really want to delete the list '" + fileName + "'?", "Confirm deletion", MessageBoxButtons.YesNo);

            if (resultConfirmation == DialogResult.Yes)
            {
                try
                {
                    File.Delete(pathToFile);
                    PopulateList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete file {ex}");
                    throw;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbListName_TextChanged(object sender, EventArgs e)
        {
            _textboxContent = tbListName.Text;

            if (_textboxContent.Any(ch => _invalidChars.Contains(ch)))
            {
                btnSaveList.Text = "Invalid Characters";
                toolTipInfo.SetToolTip(btnSaveList, "Click to remove all invalid characters");
                return;
            }

            if (_allNamesInList.Contains(_textboxContent, StringComparer.OrdinalIgnoreCase))
            {
                btnSaveList.Text = "Overwrite list";
                toolTipInfo.SetToolTip(btnSaveList, "Overwrite selected list");
            }
            else
            {
                btnSaveList.Text = "Save list";
                toolTipInfo.SetToolTip(btnSaveList, "Save list under chosen name");
            }
        }

        private void lvListSelect_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvListSelect.SelectedItems.Count == 0) return;

            tbListName.Text = lvListSelect.SelectedItems[0].Text;
            tbListName.HideSelection = false;

            tbListName.SelectAll();
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void SaveListView_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this);
        }
        private void lvListSelect_Resize(object sender, EventArgs e)
        {
            lvListSelect.Columns[0].Width = lvListSelect.Width - 72;
        }
        private void lvListSelect_DoubleClick(object sender, EventArgs e)
        {
            SaveList();
        }
        private void SaveListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SaveList();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }

            if (e.KeyCode == Keys.Return)
            {
                SaveList();
            }
        }
        private void PopulateList()
        {
            lvListSelect.Items.Clear();

            var _pathToListDir = PathHandler.PathToListFolder;
            DirectoryInfo dir = new DirectoryInfo(_pathToListDir);
            foreach (FileInfo file in dir.EnumerateFiles())
            {
                string currentFileExtension = Path.GetExtension(file.Name).TrimStart('.').ToLower();
                if (!currentFileExtension.Contains("txt")) continue;

                ListViewItem item = new ListViewItem();
                var entryCount = FileManipulation.CountRowsInFile(file.FullName);

                item.Text = file.Name.Replace(".txt", "");
                item.Tag = file.FullName;

                item.SubItems.Add($"{entryCount}");

                _allNamesInList.Add(item.Text);
                lvListSelect.Items.Add(item);
            }
        }

        private void SaveList()
        {
            if (string.IsNullOrWhiteSpace(_textboxContent)) return;

            if (btnSaveList.Text == "Invalid Characters")
            {
                tbListName.Text = new string(_textboxContent.Where(ch => !_invalidChars.Contains(ch)).ToArray());
            }
            else if (btnSaveList.Text == "Overwrite list")
            {
                DialogResult resultConfirmation = MessageBox.Show($"Do you really want to overwrite the list '{tbListName.Text}'?", "Confirm deletion", MessageBoxButtons.YesNo);
                if (resultConfirmation == DialogResult.Yes)
                {
                    ListToSave = _textboxContent;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                ListToSave = _textboxContent;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void SetupTooltips()
        {
            toolTipInfo.SetToolTip(btnSaveList, "Save list under chosen name");
            toolTipInfo.SetToolTip(btnDelete, "Delete selected list");
            toolTipInfo.SetToolTip(btnCancel, "Close without saving");
            toolTipInfo.SetToolTip(lblFiles, "Available lists | Can be overwritten");
            toolTipInfo.SetToolTip(lblEntries, "Amount of files within the list");
        }

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
