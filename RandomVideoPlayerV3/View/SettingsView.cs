using FontAwesome.Sharp;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using RandomVideoPlayer.UserControls;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RandomVideoPlayer.View
{
    public partial class SettingsView : Form
    {
        private SettingsModel settingsModel;

        private IconButton currentlySelectedButton;
        FormResize fR = new FormResize();
        public SettingsView()
        {
            InitializeComponent();

            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.FromArgb(179, 179, 255);//Border color

            settingsModel = new SettingsModel();

            InitializeNavigation();
            InitializeSettings();
            HighlightButton(sbtnPaths);
            LoadUserControl(new PathsUserControl(settingsModel));
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            SaveSettings();

            this.Close();
        }
        private void SettingsView_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this);
        }
        private void InitializeSettings()
        {
            settingsModel.IsTimeCodeServerEnabled = SettingsHandler.TimeCodeServer;
            settingsModel.IsGraphEnabled = SettingsHandler.GraphEnabled;

            settingsModel.DefaultPathText = PathHandler.DefaultFolder;
            settingsModel.RemovalPathText = PathHandler.RemoveFolder;
            settingsModel.ListPathText = PathHandler.PathToListFolder;
            settingsModel.DeleteFull = SettingsHandler.DeleteFull;
            settingsModel.IncludeScript = SettingsHandler.IncludeScripts;

            settingsModel.MemberWindowSize = fR.SaveLastSize;
            settingsModel.MemberPlayRecent = SettingsHandler.RecentCheckedSaved;
            settingsModel.MemberRecentCount = SettingsHandler.RecentCountSaved;
            settingsModel.MemberVolume = SettingsHandler.VolumeMember;
            settingsModel.StartupAlwaysAsk = SettingsHandler.StartupAlwaysAsk;
            settingsModel.StartupAllDirectories = SettingsHandler.StartupAllDirectories;

            settingsModel.SelectedExtensions = new List<string>(ListHandler.SelectedExtensions);
            settingsModel.FilterVideoEnabled = ListHandler.FilterVideoEnabled;
            settingsModel.FilterImageEnabled = ListHandler.FilterImageEnabled;
            settingsModel.FilterScriptEnabled = ListHandler.FilterScriptEnabled;
            settingsModel.ApplyFilterToList = SettingsHandler.ApplyFilterToList;

            settingsModel.AutoPlayMethod = SettingsHandler.AutoPlayMethod;
            settingsModel.AutoPlayTimerValueStartPoint = SettingsHandler.AutoPlayTimerValueStartPoint(false);
            settingsModel.AutoPlayTimerValueEndPoint = SettingsHandler.AutoPlayTimerValueEndPoint;
            settingsModel.AutoPlayTimerRangeEnabled = SettingsHandler.AutoPlayTimerRangeEnabled;
            settingsModel.ShufflePlaylist = ListHandler.DoShuffle;
            settingsModel.SortCreated = SettingsHandler.CreationDate;

            settingsModel.EnableSubtitles = SettingsHandler.SubtitlesEnabled;
            settingsModel.SubtitleSize = SettingsHandler.SubtitleFontSize;
            settingsModel.SubtitleBorderSize = SettingsHandler.SubtitleBorderSize;
            settingsModel.SubtitleFontType = SettingsHandler.SubtitleFontType;
            settingsModel.SubtitleFontColor = SettingsHandler.SubtitleFontColor;

            settingsModel.LeftMousePause = SettingsHandler.LeftMousePause;
            settingsModel.BurnsEffectEnabled = SettingsHandler.BurnsEffectEnabled;
            settingsModel.PanAmount = SettingsHandler.PanAmount;
            settingsModel.ZoomAmount = SettingsHandler.ZoomAmount;
            settingsModel.ZoomEasingFunction = SettingsHandler.ZoomEasingFunction;
            settingsModel.PanEasingFunction = SettingsHandler.PanEasingFunction;

            settingsModel.PlayOnDrop = SettingsHandler.PlayOnDrop;
            settingsModel.AlwaysAddFilesToQueue = SettingsHandler.AlwaysAddFilesToQueue;
            settingsModel.IncludeSubdirectoriesDnD = SettingsHandler.IncludeSubdirectoriesDnD;

            settingsModel.FileMovePath = PathHandler.FileMoveFolderPath;
            settingsModel.FileCopy = SettingsHandler.FileCopy;

            settingsModel.ButtonStates = SettingsHandler.ButtonStates;
            settingsModel.ButtonOrder = SettingsHandler.ButtonOrder;

            settingsModel.AlwaysCheckUpdate = SettingsHandler.AlwaysCheckUpdate;
        }
        private void InitializeNavigation()
        {
            sbtnPaths.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new PathsUserControl(settingsModel)); };
            sbtnPlayer.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new PlayerUserControl(settingsModel)); };
            sbtnFilterExtensions.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new FileExtensionsUserControl(settingsModel)); };
            sbtnRemember.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new RememberUserControl(settingsModel)); };
            sbtnInputs.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new InputsUserControl()); };
            sbtnSubtitles.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new SubtitlesUserControl(settingsModel)); };
            sbtnSync.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new SyncUserControl(settingsModel)); };
            sbtnInterface.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new InterfaceUserControl(settingsModel)); };
            sbtnDragDrop.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new DragDropUserControl(settingsModel)); };
            sbtnAbout.Click += (s, e) => { HighlightButton((IconButton)s); LoadUserControl(new AboutUserControl(settingsModel)); };
        }

        private void SaveSettings()
        {
            SettingsHandler.TimeCodeServer = settingsModel.IsTimeCodeServerEnabled;
            SettingsHandler.GraphEnabled = settingsModel.IsGraphEnabled;

            PathHandler.DefaultFolder = settingsModel.DefaultPathText;
            PathHandler.TempRecentFolder = PathHandler.DefaultFolder;
            PathHandler.RemoveFolder = settingsModel.RemovalPathText;
            PathHandler.PathToListFolder = settingsModel.ListPathText;
            SettingsHandler.DeleteFull = settingsModel.DeleteFull;
            SettingsHandler.IncludeScripts = settingsModel.IncludeScript;

            fR.SaveLastSize = settingsModel.MemberWindowSize;
            SettingsHandler.RecentCheckedSaved = settingsModel.MemberPlayRecent;
            SettingsHandler.RecentCountSaved = settingsModel.MemberRecentCount;
            SettingsHandler.VolumeMember = settingsModel.MemberVolume;
            SettingsHandler.StartupAlwaysAsk = settingsModel.StartupAlwaysAsk;
            SettingsHandler.StartupAllDirectories = settingsModel.StartupAllDirectories;

            SettingsHandler.AutoPlayMethod = settingsModel.AutoPlayMethod;
            SettingsHandler.SetAutoPlayTimerValueStartPoint(settingsModel.AutoPlayTimerValueStartPoint);
            SettingsHandler.AutoPlayTimerValueEndPoint = settingsModel.AutoPlayTimerValueEndPoint;
            SettingsHandler.AutoPlayTimerRangeEnabled = settingsModel.AutoPlayTimerRangeEnabled;
            ListHandler.DoShuffle = settingsModel.ShufflePlaylist;
            SettingsHandler.CreationDate = settingsModel.SortCreated;

            SettingsHandler.SubtitlesEnabled = settingsModel.EnableSubtitles;
            SettingsHandler.SubtitleFontSize = settingsModel.SubtitleSize;
            SettingsHandler.SubtitleBorderSize = settingsModel.SubtitleBorderSize;
            SettingsHandler.SubtitleFontType = settingsModel.SubtitleFontType;
            SettingsHandler.SubtitleFontColor = settingsModel.SubtitleFontColor;

            SettingsHandler.LeftMousePause = settingsModel.LeftMousePause;
            SettingsHandler.BurnsEffectEnabled = settingsModel.BurnsEffectEnabled;
            SettingsHandler.PanAmount = settingsModel.PanAmount;
            SettingsHandler.ZoomAmount = settingsModel.ZoomAmount;
            SettingsHandler.ZoomEasingFunction = settingsModel.ZoomEasingFunction;
            SettingsHandler.PanEasingFunction = settingsModel.PanEasingFunction;

            SettingsHandler.PlayOnDrop = settingsModel.PlayOnDrop;
            SettingsHandler.AlwaysAddFilesToQueue = settingsModel.AlwaysAddFilesToQueue;
            SettingsHandler.IncludeSubdirectoriesDnD = settingsModel.IncludeSubdirectoriesDnD;


            ListHandler.FilterVideoEnabled = settingsModel.FilterVideoEnabled;
            ListHandler.FilterImageEnabled = settingsModel.FilterImageEnabled;
            ListHandler.FilterScriptEnabled = settingsModel.FilterScriptEnabled;
            SettingsHandler.ApplyFilterToList = settingsModel.ApplyFilterToList;

            if (!ListHandler.SelectedExtensions.SequenceEqual(settingsModel.SelectedExtensions))
            {
                ListHandler.NeedsToPrepare = true;
                SettingsHandler.SettingChanged = true;
            }
            ListHandler.SelectedExtensions = settingsModel.SelectedExtensions;


            SetupFileMove();

            SettingsHandler.ButtonStates = settingsModel.ButtonStates;
            SettingsHandler.ButtonOrder = settingsModel.ButtonOrder;

            SettingsHandler.AlwaysCheckUpdate = settingsModel.AlwaysCheckUpdate;
        }

        private void HighlightButton(IconButton button)
        {
            if (currentlySelectedButton != null)
            {
                currentlySelectedButton.BackColor = Color.GhostWhite;
                currentlySelectedButton.ForeColor = Color.Black;
                currentlySelectedButton.IconColor = Color.Black;
            }
            button.BackColor = Color.Indigo;
            button.ForeColor = Color.White;
            button.IconColor = Color.White;
            currentlySelectedButton = button;
        }

        private void LoadUserControl(UserControl userControl)
        {
            splitUI.Panel2.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            splitUI.Panel2.Controls.Add(userControl);
        }

        private void SetupFileMove()
        {
            if (string.IsNullOrWhiteSpace(settingsModel.FileMovePath)) return;
            if (!Path.Exists(settingsModel.FileMovePath))
            {
                try
                {
                    Directory.CreateDirectory(settingsModel.FileMovePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"The path to store favorite videos is not valid! Error: {ex} Path: {settingsModel.FileMovePath}");
                    return;
                }
            }
            PathHandler.FileMoveFolderPath = settingsModel.FileMovePath;
            SettingsHandler.FileCopy = settingsModel.FileCopy;
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
