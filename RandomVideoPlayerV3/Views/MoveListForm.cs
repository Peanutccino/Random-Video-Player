using RandomVideoPlayer.Functions;
using System.Runtime.InteropServices;
using RandomVideoPlayer.Model;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace RandomVideoPlayer.Views
{
    public partial class MoveListForm : Form
    {
        private FormResize fR = new FormResize();
        public List<string> movedFilePaths = new List<string>();
        private List<string> filePathsForMoving;
        private CancellationTokenSource cancellationTokenSource;
        private string targetDirectory;
        private bool sameDirectory = false;
        private bool deleteAfterCopy = false;
        private bool fileMoveSuccess = false;
        private bool gotCancelled = false;

        private static List<string> multiAxis = new List<string>
        {  ".surge", ".sway", ".suck", ".twist", ".roll", ".pitch", ".vib", ".pump", ".raw" };
        public MoveListForm(List<string> fileList)
        {
            InitializeComponent();

            this.MinimumSize = DPI.GetSizeScaled(this.MinimumSize);
            this.MaximumSize = DPI.GetSizeScaled(this.MaximumSize);
            this.Size = DPI.GetSizeScaled(this.Size);


            UpdateDPIScaling();

            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.FromArgb(152, 251, 152);//Border color

            filePathsForMoving = fileList;

            ThemeManager.ApplyThemeLSView(this);
        }

        private void MoveListForm_Load(object sender, EventArgs e)
        {
            var scriptDirectories = ListHandler.ScriptDirectories.ToList();
            int index = scriptDirectories.IndexOf("local");

            comboScriptDirectories.DataSource = scriptDirectories;
            comboScriptDirectories.SelectedIndex = index >= 0 ? index : 0;
        }
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private async void btnStartMoveAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDestinationPath.Text))
            {
                MessageBox.Show("Please select a destination path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sameDirectory = AreFilesInSameDrive(targetDirectory, filePathsForMoving);

            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            pbMoveProgress.Value = 0;
            pbMoveProgress.Maximum = filePathsForMoving.Count;

            btnStartMoveAction.Enabled = false;
            btnStartCopyAction.Enabled = false;
            btnCloseForm.Enabled = false;
            cbMoveFunscripts.Enabled = false;
            comboScriptDirectories.Enabled = false;
            btnCancelMoveAction.Visible = true;

            if (sameDirectory)
            {
                await MoveFilesToDirectoryAsync(filePathsForMoving, targetDirectory, token, false);

            }
            else
            {
                btnCancelMoveAction.Enabled = true;
                deleteAfterCopy = true;

                await MoveFilesToDirectoryAsync(filePathsForMoving, targetDirectory, token, true);
            }

            if (fileMoveSuccess)
            {
                btnStartMoveAction.Enabled = false;
                btnStartCopyAction.Enabled = false;
                btnCloseForm.Enabled = true;
                btnCancelMoveAction.Visible = false;
                btnFinish.Visible = true;
            }
            else
            {
                btnStartMoveAction.Enabled = true;
                btnStartCopyAction.Enabled = true;
                btnCloseForm.Enabled = true;
                cbMoveFunscripts.Enabled = true;
                comboScriptDirectories.Enabled = true;
                btnCancelMoveAction.Visible = false;
                btnFinish.Visible = false;
            }

        }

        private async void btnStartCopyAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDestinationPath.Text))
            {
                MessageBox.Show("Please select a destination path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            pbMoveProgress.Value = 0;
            pbMoveProgress.Maximum = filePathsForMoving.Count;

            btnStartMoveAction.Enabled = false;
            btnStartCopyAction.Enabled = false;
            btnCloseForm.Enabled = false;
            btnCancelMoveAction.Visible = true;

            deleteAfterCopy = false;

            await MoveFilesToDirectoryAsync(filePathsForMoving, targetDirectory, token, true);

            if (fileMoveSuccess)
            {
                btnStartMoveAction.Enabled = false;
                btnStartCopyAction.Enabled = false;
                btnCloseForm.Enabled = true;
                btnCancelMoveAction.Visible = false;
                btnFinish.Visible = true;
            }
            else
            {
                btnStartMoveAction.Enabled = true;
                btnStartCopyAction.Enabled = true;
                btnCloseForm.Enabled = true;
                btnCancelMoveAction.Visible = false;
                btnFinish.Visible = false;
            }


        }

        private void btnCancelMoveAction_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.InitialDirectory = PathHandler.DefaultFolder;
            folderBrowser.Description = "Select the folder to move the files to";
            folderBrowser.UseDescriptionForTitle = true;

            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbDestinationPath.Text = folderBrowser.SelectedPath;
                targetDirectory = folderBrowser.SelectedPath;
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (fileMoveSuccess)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (gotCancelled)
            {
                var result = MessageBox.Show("You cancelled the action before, which could lead to a messed up list.\nPlease make sure to finish action!\nDo you still want to quit?", "Cancel confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (fileMoveSuccess)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private async Task MoveFilesToDirectoryAsync(List<string> filePathsList, string targetDirectory, CancellationToken token, bool copy)
        {
            List<string> newFilePaths = new List<string>();
            List<string> sourceFilePaths = new List<string>(filePathsList);
            List<(string Source, string Destination)> movedFiles = new List<(string, string)>();
            int filesMoved = 0;

            var scriptDirectory = comboScriptDirectories.SelectedItem.ToString();
            List<string> scriptFilesFound = new List<string>();

            try
            {
                foreach (string sourceFilePath in sourceFilePaths)
                {
                    if (token.IsCancellationRequested)
                    {
                        var result = MessageBox.Show("Operation was interrupted.\nDo you want to continue?", "Cancel Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            cancellationTokenSource = new CancellationTokenSource();
                            token = cancellationTokenSource.Token;
                            continue;
                        }
                        else if (result == DialogResult.No)
                        {
                            lblTitle.Text = "RVP - Moving files cancelled!";
                            fileMoveSuccess = false;
                            gotCancelled = true;
                            await UndoMovedFilesAsync(movedFiles, true);
                            break;
                        }
                    }

                    try
                    {
                        string fileName = Path.GetFileName(sourceFilePath);
                        string directory = Path.GetDirectoryName(sourceFilePath);
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFilePath);
                        string scriptFilePath = Path.Combine(directory, fileNameWithoutExtension + ".funscript");
                        string destFilePath = Path.Combine(targetDirectory, fileName);


                        if (!File.Exists(sourceFilePath))
                        {
                            filesMoved++;

                            pbMoveProgress.Value = filesMoved;
                            lblTitle.Text = $"RVP - Moving file {filesMoved} of {filePathsList.Count}";

                            continue;
                        }

                        if (cbMoveFunscripts.Checked)
                        {
                            if (File.Exists(scriptFilePath))
                            {
                                scriptFilesFound.Add(scriptFilePath);

                                foreach(var multiScriptType in multiAxis)
                                {
                                    var matchingFiles = Directory.GetFiles(directory, "*.funscript", System.IO.SearchOption.TopDirectoryOnly)
                                    .Where(file => Path.GetFileName(file).StartsWith(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase) &&
                                    Path.GetFileName(file).EndsWith(multiScriptType + ".funscript", StringComparison.OrdinalIgnoreCase))
                                    .ToList();

                                    foreach (var file in matchingFiles)
                                    {
                                        scriptFilesFound.Add(file);
                                    }
                                }     
                            }
                        }

                        if (copy)
                        {
                            await Task.Run(() => File.Copy(sourceFilePath, destFilePath, true));

                            foreach(var file in scriptFilesFound)
                            {
                                string scriptFileName = Path.GetFileName(file);
                                string scriptDestFilePath = "";

                                if(scriptDirectory == "local")
                                {
                                    scriptDestFilePath = Path.Combine(targetDirectory, scriptFileName);
                                }
                                else
                                {
                                    scriptDestFilePath = Path.Combine(scriptDirectory, scriptFileName);
                                }

                                await Task.Run(() => File.Copy(file, scriptDestFilePath, true));
                            }
                        }
                        else
                        {
                            await Task.Run(() => File.Move(sourceFilePath, destFilePath, true));

                            foreach (var file in scriptFilesFound)
                            {
                                string scriptFileName = Path.GetFileName(file);
                                string scriptDestFilePath = "";

                                if (scriptDirectory == "local")
                                {
                                    scriptDestFilePath = Path.Combine(targetDirectory, scriptFileName);
                                }
                                else
                                {
                                    scriptDestFilePath = Path.Combine(scriptDirectory, scriptFileName);
                                }

                                await Task.Run(() => File.Move(file, scriptDestFilePath, true));
                            }
                        }


                        newFilePaths.Add(destFilePath);
                        movedFiles.Add((sourceFilePath, destFilePath));

                        scriptFilesFound.Clear();

                        filesMoved++;

                        pbMoveProgress.Value = filesMoved;
                        lblTitle.Text = $"RVP - Moving file {filesMoved} of {filePathsList.Count}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error moving file '{sourceFilePath}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Error.Log(ex, "Error moving file list");
                        lblTitle.Text = "RVP - Error moving files!";
                        fileMoveSuccess = false;
                    }
                }

                sourceFilePaths.Clear();
                List<string> movedFilePathsWithoutDuplicates = newFilePaths.Distinct().ToList();
                movedFilePaths.AddRange(movedFilePathsWithoutDuplicates);


                if (!token.IsCancellationRequested)
                {
                    lblTitle.Text = "RVP - Files have been moved successfully!";
                    fileMoveSuccess = true;
                    gotCancelled = false;

                    if (copy && deleteAfterCopy)
                    {
                        await UndoMovedFilesAsync(movedFiles, false);
                    }

                    deleteAfterCopy = false;


                }
            }
            finally
            {
                pbMoveProgress.Value = 0;
                cancellationTokenSource = null;
                scriptFilesFound.Clear();
            }
        }

        private async Task UndoMovedFilesAsync(List<(string Source, string Destination)> movedFiles, bool Destination)
        {
            foreach (var (source, destination) in movedFiles)
            {
                try
                {
                    if (Destination)
                    {
                        await Task.Run(() => File.Delete(destination));
                    }
                    else
                    {
                        await Task.Run(() => File.Delete(source));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error undoing file '{destination}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Error.Log(ex, "Error undoing file list");
                }
            }
        }
        private static bool AreFilesInSameDrive(string targetDirectory, List<string> filePathsForMoving)
        {
            string targetRoot = Path.GetPathRoot(targetDirectory);

            return filePathsForMoving.All(filePath => Path.GetPathRoot(filePath) == targetRoot);
        }


        private void UpdateDPIScaling()
        {
            panelTitle.Height = DPI.GetDivided(panelTitle.Height);
            lblTitle.Font = DPI.GetFontScaled(lblTitle.Font);
            btnCloseForm.Size = DPI.GetSizeScaled(btnCloseForm.Size);

            lblDestinationInfo.Size = DPI.GetSizeScaled(lblDestinationInfo.Size);
            lblDestinationInfo.Font = DPI.GetFontScaled(lblDestinationInfo.Font);

            tbDestinationPath.Height = DPI.GetDivided(tbDestinationPath.Height);
            tbDestinationPath.Font = DPI.GetFontScaled(tbDestinationPath.Font);
            tbDestinationPath.Location = new Point(3, lblDestinationInfo.Height + 3);

            btnBrowseFolder.Size = DPI.GetSizeScaled(btnBrowseFolder.Size);
            btnBrowseFolder.Location = new Point(panelBody.Width - btnBrowseFolder.Width, tbDestinationPath.Location.Y);
            tbDestinationPath.Width = panelBody.Width - btnBrowseFolder.Width - 6;

            btnStartMoveAction.Size = DPI.GetSizeScaled(btnStartMoveAction.Size);
            btnStartMoveAction.Font = DPI.GetFontScaled(btnStartMoveAction.Font);
            btnStartMoveAction.Location = new Point(3, tbDestinationPath.Location.Y + tbDestinationPath.Height + 3);

            btnStartCopyAction.Size = DPI.GetSizeScaled(btnStartCopyAction.Size);
            btnStartCopyAction.Font = DPI.GetFontScaled(btnStartCopyAction.Font);
            btnStartCopyAction.Location = new Point(btnStartMoveAction.Location.X + btnStartMoveAction.Width + 3, btnStartMoveAction.Location.Y);

            btnFinish.Size = DPI.GetSizeScaled(btnFinish.Size);
            btnFinish.Font = DPI.GetFontScaled(btnFinish.Font);
            btnFinish.Location = new Point(panelBody.Width - btnFinish.Width, btnStartMoveAction.Location.Y);

            btnCancelMoveAction.Size = DPI.GetSizeScaled(btnCancelMoveAction.Size);
            btnCancelMoveAction.Font = DPI.GetFontScaled(btnCancelMoveAction.Font);
            btnCancelMoveAction.Location = new Point(btnFinish.Location.X - btnCancelMoveAction.Width - 3, btnStartMoveAction.Location.Y);

            cbMoveFunscripts.Size = DPI.GetSizeScaled(cbMoveFunscripts.Size);
            cbMoveFunscripts.Font = DPI.GetFontScaled(cbMoveFunscripts.Font);
            cbMoveFunscripts.Location = new Point(3, btnStartMoveAction.Location.Y + btnStartMoveAction.Height + 3);
            cbMoveFunscripts.Width = panelBody.Width - 6;

            lblInfo.Size = DPI.GetSizeScaled(lblInfo.Size);
            lblInfo.Font = DPI.GetFontScaled(lblInfo.Font);
            lblInfo.Location = new Point(3, cbMoveFunscripts.Location.Y + cbMoveFunscripts.Height + 9);

            comboScriptDirectories.Size = DPI.GetSizeScaled(comboScriptDirectories.Size);
            comboScriptDirectories.Font = DPI.GetFontScaled(comboScriptDirectories.Font);
            comboScriptDirectories.Location = new Point(3, lblInfo.Location.Y + lblInfo.Height + 3);
            comboScriptDirectories.Width = panelBody.Width - 6;
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
