using RandomVideoPlayerV3.Functions;
using RandomVideoPlayerV3.Model;
using System.Runtime.InteropServices;

namespace RandomVideoPlayerV3.View
{
    public partial class SettingsView : Form
    {
        FormResize fR = new FormResize();
        PathHandler pH = new PathHandler();
        SettingsHandler sH = new SettingsHandler();
        public SettingsView()
        {
            InitializeComponent();

            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.FromArgb(242, 141, 238);//Border color
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void SettingsView_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this);
        }
        private void SettingsView_Load(object sender, EventArgs e)
        {
            if (pH.DefaultFolder == null)
            {
                pH.DefaultFolder = pH.FallbackPath;
            }
            tbRemovalPath.Text = pH.RemoveFolder;
            tbDefaultPath.Text = pH.DefaultFolder;
            cbRemembersize.Checked = fR.SaveLastSize;
            tbListfolderPath.Text = pH.FolderList;
            cbDeleteToggle.Checked = sH.DeleteFull;
            cbLoopPlayer.Checked = sH.LoopPlayer;
            cbtimeCodeServer.Checked = sH.TimeCodeServer;


            if (sH.CreationDate)
            {
                rbCreationDate.Checked = true;
            }
            else if (!sH.CreationDate)
            {
                rbModifiedDate.Checked = true;
            }

            SetupTooltips(); //Initialize Tooltips

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            fbDialog.InitialDirectory = pH.DefaultFolder;

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbDefaultPath.Text = fbDialog.SelectedPath;
            }
        }
        private void btnFileBrowseRemove_Click(object sender, EventArgs e)
        {
            fbDialog.InitialDirectory = pH.DefaultFolder;

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbRemovalPath.Text = fbDialog.SelectedPath;
            }
        }
        private void btnFileBrowseList_Click(object sender, EventArgs e)
        {
            fbDialog.InitialDirectory = pH.FolderList;

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbListfolderPath.Text = fbDialog.SelectedPath;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            pH.DefaultFolder = tbDefaultPath.Text;
            pH.RemoveFolder = tbRemovalPath.Text;
            pH.FolderList = tbListfolderPath.Text;
            fR.SaveLastSize = cbRemembersize.Checked;
            sH.DeleteFull = cbDeleteToggle.Checked;
            sH.LoopPlayer = cbLoopPlayer.Checked;
            sH.TimeCodeServer = cbtimeCodeServer.Checked;

            if (rbCreationDate.Checked)
            {
                sH.CreationDate = true;
            }
            else if (rbModifiedDate.Checked)
            {
                sH.CreationDate = false;
            }

            this.Close();
        }
        private void SetupTooltips()
        {
            toolTipInfo.SetToolTip(btnFileBrowse, "Choose folder that opens by default on program start");
            toolTipInfo.SetToolTip(btnFileBrowseRemove, "Choose folder where files are moved to when 'Delete' is not checked");
            toolTipInfo.SetToolTip(btnFileBrowseList, "Choose default folder for saving and loading lists");
            toolTipInfo.SetToolTip(btnClose, "Close without saving");
            toolTipInfo.SetToolTip(cbRemembersize, "Saves current window size for next startup");
            toolTipInfo.SetToolTip(cbDeleteToggle, "Choose whether to delete files completely or move them to chosen folder when using the delete button from the player");
            toolTipInfo.SetToolTip(cbtimeCodeServer, "Activate timecode server to synchronize with MultiFunPlayer by choosing MPC-HC as the target there");
        }

        #region WndProc Code for clean style of the Form and regaining usabality
        //Resizable Windows Form Spaghetti
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
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
