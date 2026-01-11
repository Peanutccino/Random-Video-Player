
using RandomVideoPlayer.Functions;
using System.Runtime.InteropServices;

namespace RandomVideoPlayer.Views
{
    public partial class CustomMessageBoxView : Form
    {
        FormResize fR = new FormResize();
        public bool CheckboxChecked { get; private set; }
        public DialogResult Result { get; private set; }

        public CustomMessageBoxView(string title, string message, string checkboxText, bool checkboxDefaultState)
        {
            InitializeComponent();

            UpdateDPIScaling();

            this.Padding = new Padding(fR.BorderSize); //Border size
            this.BackColor = Color.DeepSkyBlue; //Border color

            this.Text = title;
            lblInfoText.Text = message;
            cbOption.Text = checkboxText;
            cbOption.Checked = checkboxDefaultState;

            ThemeManager.ApplyThemeLSView(this);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            CheckboxChecked = cbOption.Checked;
            Result = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            CheckboxChecked = cbOption.Checked;
            Result = DialogResult.No;
            this.Close();
        }

        private void lblInfoText_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CustomMessageBoxView_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this);
        }
        private void UpdateDPIScaling()
        {
            this.MinimumSize = DPI.GetSizeScaled(this.MinimumSize);
            this.Size = DPI.GetSizeScaled(this.Size);

            lblInfoText.Size = DPI.GetSizeScaled(lblInfoText.Size);
            lblInfoText.Font = DPI.GetFontScaled(lblInfoText.Font);

            cbOption.Size = DPI.GetSizeScaled(cbOption.Size);
            cbOption.Font = DPI.GetFontScaled(cbOption.Font);

            btnYes.Size = DPI.GetSizeScaled(btnYes.Size);
            btnYes.Font = DPI.GetFontScaled(btnYes.Font);
            btnYes.Location = new Point(3, panelBody.Height - btnYes.Height - 3);

            btnNo.Size = DPI.GetSizeScaled(btnNo.Size);
            btnNo.Font = DPI.GetFontScaled(btnNo.Font);
            btnNo.Location = new Point(panelBody.Width - btnNo.Width - 3, panelBody.Height - btnNo.Height - 3);
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
