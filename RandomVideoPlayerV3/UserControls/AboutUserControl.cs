using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Timers;

namespace RandomVideoPlayer.UserControls
{

    public partial class AboutUserControl : UserControl
    {
        private const string VersionHistoryUrl = "https://raw.githubusercontent.com/Peanutccino/Random-Video-Player/master/version_history.txt";

        private SettingsModel settings;
        private static System.Timers.Timer blinkTimer;
        private static int colorLight = 230;
        private static int colorDark = 179;
        private static int value = 230;
        private static bool increasing = false;

        private bool updateAvailable = false;
        private bool needToRestart = false;
        private bool gotCancelled = false;
        private string latestVersionSaved;
        private Dictionary<string, string> versionHistory;

        private TaskCompletionSource<bool> restartApplication;

        public AboutUserControl(SettingsModel settings)
        {
            InitializeComponent();

            rtbConsole.Font = new Font(FontFamily.GenericMonospace, 9);

            UpdateDPIScaling();

            this.settings = settings;

            string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string[] versionParts = currentVersion.ToString().Split('.');
            string truncatedVersion = string.Join(".", versionParts[0], versionParts[1]);

            lblCurrentVersion.Text = "Current Version:".PadRight(20) + truncatedVersion;
            lblLatestVersion.Text = "Latest Version: ".PadRight(22) + "-";

            blinkTimer = new System.Timers.Timer(20);
            blinkTimer.Elapsed += OnTimedEvent;


            BindControls();
            LoadSettings();
        }

        private void BindControls()
        {
            cbUpdateAlwaysCheck.CheckedChanged += (s, e) =>
            {
                settings.AlwaysCheckUpdate = cbUpdateAlwaysCheck.Checked;
            };
        }

        private void LoadSettings()
        {
            cbUpdateAlwaysCheck.Checked = settings.AlwaysCheckUpdate;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            rtbConsole.Visible = true;
            if (gotCancelled) rtbConsole.Clear();
            CheckForUpdates();
        }
        private void btnGitHub_Click(object sender, EventArgs e)
        {
            if (updateAvailable && !needToRestart)
            {
                UpdateApplication();
            }
            else if (updateAvailable && needToRestart)
            {
                restartApplication.TrySetResult(true);
            }
            else
            {
                Process.Start(new ProcessStartInfo("https://github.com/Peanutccino/Random-Video-Player") { UseShellExecute = true });
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(restartApplication != null)
                restartApplication.TrySetResult(false);
        }
        private void AboutUserControl_Leave(object sender, EventArgs e)
        {
            if(restartApplication != null)
                restartApplication.TrySetResult(false);
            blinkTimer.Dispose();
        }
        private async void UpdateApplication()
        {
            try
            {
                if (gotCancelled) rtbConsole.Clear();
                btnGitHub.Enabled = false;
                UpdateProgress("Looking for update files...");

                string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                var versionsToUpdate = versionHistory
                    .Where(v => new Version(v.Key) > new Version(currentVersion))
                    .ToList();

                List<string> zipPaths = new();
                string extractPath = Path.Combine(Path.GetTempPath(), "update");

                foreach (var version in versionsToUpdate) 
                {
                    string versionNumber = version.Key;
                    string updateUrl = version.Value;
                    Uri uri = new Uri(updateUrl);
                    string fileName = Path.GetFileName(uri.LocalPath);

                    string tempZipPath = Path.Combine(Path.GetTempPath(), $"{fileName}");
                    zipPaths.Add(tempZipPath);

                    try
                    {
                        DownloadUpdate(updateUrl, tempZipPath);
                        ExtractUpdate(tempZipPath, extractPath);

                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, "Error during download/extraction");
                        btnGitHub.Enabled = true;
                        return;
                    }
                }
                UpdateProgress("Extraction complete, waiting for user input...");

                string batchFilePath = Path.Combine(Path.GetTempPath(), "update.bat");
                string batchScript = UpdateFunctions.CreateBatchScript(extractPath, zipPaths);

                File.WriteAllText(batchFilePath, batchScript);

                needToRestart = true;
                btnGitHub.Enabled = true;
                btnCancel.Visible = true;
                btnGitHub.Text = "Restart";
                btnGitHub.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateRight;

                UpdateProgress("Press 'Restart' to install or abort with 'Cancel'");

                restartApplication = new TaskCompletionSource<bool>();
                bool? result = await restartApplication.Task;

                btnGitHub.Enabled = false;


                if (result == true)
                {
                    UpdateProgress("Launching updater...");

                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = batchFilePath,
                        UseShellExecute = true,
                        Verb = "runas"
                    };

                    try
                    {
                        Process.Start(processInfo);
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        UpdateProgress("Updater requires elevated privileges, but the user refused");
                        return;
                    }
                    UpdateProgress("Closing up...");
                    UpdateProgress("See you soon!");

                    Application.Exit();
                }
                else if (result == false)
                {
                    UpdateProgress("Update cancelled");

                    try
                    {
                        UpdateProgress("Cleaning downloaded files...");
                        if (Directory.Exists(extractPath))
                        {
                            Directory.Delete(extractPath, true);                          
                        }
                        UpdateProgress("Deleting downloaded package...");
                        foreach(var file in zipPaths)
                        {
                            if (File.Exists(file))
                            {
                                File.Delete(file);
                            }
                        }
                        UpdateProgress("Deleting updater...");
                        if (File.Exists(batchFilePath))
                        {
                            File.Delete(batchFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, "Couldn't delete downloaded files after update was cancelled!");
                        UpdateProgress("Failed to delete downloaded files...");
                        UpdateProgress("You can delete them manually under:");
                        UpdateProgress($"{extractPath}");
                        foreach(var file in zipPaths)
                        {
                            UpdateProgress($"{file}");
                        }
                        UpdateProgress($"{batchFilePath}");
                    }
                    finally
                    {
                        UpdateProgress("Reverting back to normal...");
                        btnGitHub.IconChar = FontAwesome.Sharp.IconChar.CloudArrowDown;
                        btnGitHub.Text = "Update";
                        needToRestart = false;
                        btnCancel.Visible = false;
                        btnGitHub.Enabled = true;
                        UpdateProgress("Done without updating!");
                        gotCancelled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateProgress($"An error occurred and I couldn't finish the update: {ex.Message}");
                Error.Log(ex, "Error during update");
                btnGitHub.Enabled = true;
            }
        }

        private async void CheckForUpdates()
        {
            try
            {
                UpdateProgress("Checking for updates...");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true
                    };

                    versionHistory = await UpdateFunctions.GetVersionHistory(VersionHistoryUrl);

                    if (versionHistory.Count == 0)
                    {
                        UpdateProgress("Couldn't fetch version history, aborting update...");
                        btnGitHub.Enabled = true;
                        return;
                    }

                    string latestVersionString = versionHistory.Last().Key;

                    if (Version.TryParse(latestVersionString, out Version latestVersion))
                    {
                        Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                        if (latestVersion > currentVersion)
                        {
                            UpdateProgress("Found a new version: " + latestVersion.ToString());
                            lblLatestVersion.Text = latestVersion.ToString() + " - Update available!";

                            blinkTimer.AutoReset = true;
                            blinkTimer.Enabled = true;

                            updateAvailable = true;

                            btnGitHub.IconChar = FontAwesome.Sharp.IconChar.CloudArrowDown;
                            btnGitHub.Text = "Update";

                            string[] versionParts = latestVersion.ToString().Split('.');

                            string truncatedVersion = string.Join(".", versionParts[0], versionParts[1]);

                            latestVersionSaved = truncatedVersion;
                            UpdateProgress("Press 'Update' to download!");
                        }
                        else
                        {
                            updateAvailable = false;

                            UpdateProgress("You're using the latest version!");                          

                            lblLatestVersion.Text = "Latest Version: ".PadRight(22) + latestVersion.ToString() + " - You're using the latest version!";
                        }
                    }
                    else
                    {
                        UpdateProgress("Error parsing the latest version number");
                        lblLatestVersion.Text = "Latest Version: ".PadRight(22) + "Error parsing the latest version number. Please check the version file format.";
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Error checking for updates");
                UpdateProgress($"Error checking for updates: {ex.Message}");
            }
        }
        public void DownloadUpdate(string url, string destinationPath)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    long totalBytes = response.ContentLength;
                    long downloadedBytes = 0;
                    int progressBarLength = 20;

                    using (Stream responseStream = response.GetResponseStream())
                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                       //UpdateProgress("Downloading...");

                        while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                            downloadedBytes += bytesRead;

                            int progressPercentage = (int)((double)downloadedBytes / totalBytes * 100);
                            int progressBlocks = (int)((double)downloadedBytes / totalBytes * progressBarLength);

                            string progressBar = new string('▋', progressBlocks).PadRight(progressBarLength, '-');
                            string progressMessage = $"[{progressBar}] {progressPercentage}%";

                            UpdateProgressLastLine($"Downloading: {progressMessage}");

                            Application.DoEvents();
                        }
                    }
                    UpdateProgress("", false);
                }
                catch (Exception ex)
                {
                    UpdateProgress($"Error starting download: {ex.Message}");
                    Error.Log(ex, "Error when starting download");

                    if(File.Exists(destinationPath))
                    {
                        UpdateProgress("Found incomplete download...");
                        try
                        {
                            File.Delete(destinationPath);
                            UpdateProgress("Deleted incompleted download.");
                        }
                        catch (Exception deleteEx)
                        {
                            UpdateProgress($"Failed to delete incomplete file: {deleteEx.Message}");
                            Error.Log(deleteEx, "Failed to deleted downloaded file.");
                        }
                    }

                    throw;
                }
            }
        }
        public void ExtractUpdate(string zipPath, string extractPath)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                int totalFiles = archive.Entries.Count;

                int progressBarLength = 20;
                int extractedFiles = 0;

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string destinationPath = Path.Combine(extractPath, entry.FullName);

                    if (entry.FullName.EndsWith("/"))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }
                    else
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        entry.ExtractToFile(destinationPath, true);
                    }

                    extractedFiles++;
                    int value = extractedFiles;

                    int progressPercentage = (int)((double)extractedFiles / totalFiles * 100);                    
                    int progressBlocks = progressPercentage / (100 / progressBarLength);
                    string progressBar = new string('▋', progressBlocks).PadRight(progressBarLength, '-');
                    string progressMessage = $"[{progressBar}] {progressPercentage}%";

                    UpdateProgressLastLine($"Extracting: {progressMessage}");

                    Application.DoEvents();
                }
                UpdateProgress("", false);
            }
        }

        private void UpdateProgress(string message, bool timeStamp = true)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, bool>(UpdateProgress), new object[] { message, timeStamp });
                return;
            }

            DateTime now = DateTime.Now;
            string timeString = $"[{now.ToString("HH:mm:ss")}] ";

            if (timeStamp)
            {
                rtbConsole.AppendText(timeString + message + Environment.NewLine);
            }
            else
            {
                rtbConsole.AppendText(message + Environment.NewLine);
            }
        }

        private void UpdateProgressLastLine(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateProgressLastLine), new object[] { message });
                return;
            }

            DateTime now = DateTime.Now;
            string timeString = $"[{now.ToString("HH:mm:ss")}] ";
            string formattedMessage = timeString + message;

            var lines = rtbConsole.Lines;

            if (lines.Length > 0)
            {
                // Remove the last line
                
                lines[lines.Length - 1] = formattedMessage;
                rtbConsole.Lines = lines;
                
            }
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (increasing)
            {
                value++;
                if (value >= colorLight)
                {
                    increasing = false;
                }
            }
            else
            {
                value--;
                if (value <= colorDark)
                {
                    increasing = true;
                }
            }

            btnGitHub.BackColor = Color.FromArgb(value, value, 255);
        }


        private void UpdateDPIScaling()
        {
            this.MinimumSize = DPI.GetSizeScaled(this.MinimumSize);
            this.Size = DPI.GetSizeScaled(this.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lblTitle.Font = DPI.GetFontScaled(lblTitle.Font);
            lblSubtitle.Font = DPI.GetFontScaled(lblSubtitle.Font);

            panelVersion.Height = DPI.GetDivided(panelVersion.Height);

            lblCurrentVersion.Size = DPI.GetSizeScaled(lblCurrentVersion.Size);
            lblCurrentVersion.Font = DPI.GetFontScaled(lblCurrentVersion.Font);

            lblLatestVersion.Size = DPI.GetSizeScaled(lblLatestVersion.Size);
            lblLatestVersion.Font = DPI.GetFontScaled(lblLatestVersion.Font);

            btnSync.Size = DPI.GetSizeScaled(btnSync.Size);

            panelBody.Height = DPI.GetDivided(panelBody.Height);

            cbUpdateAlwaysCheck.Size = DPI.GetSizeScaled(cbUpdateAlwaysCheck.Size);
            cbUpdateAlwaysCheck.Font = DPI.GetFontScaled(cbUpdateAlwaysCheck.Font);

            btnGitHub.Size = DPI.GetSizeScaled(btnGitHub.Size);
            btnGitHub.Font = DPI.GetFontScaled(btnGitHub.Font);
            btnGitHub.Location = new Point((panelBody.Width / 2) - (btnGitHub.Width / 2), cbUpdateAlwaysCheck.Location.Y + cbUpdateAlwaysCheck.Height + 3);

            btnCancel.Size = DPI.GetSizeScaled(btnCancel.Size);
            btnCancel.Font = DPI.GetFontScaled(btnCancel.Font);
            btnCancel.Location = new Point((panelBody.Width / 2) - (btnCancel.Width / 2), btnGitHub.Location.Y + btnGitHub.Height + 3);

            rtbConsole.Size = DPI.GetSizeScaled(rtbConsole.Size);
            rtbConsole.Font = DPI.GetFontScaled(rtbConsole.Font);
            rtbConsole.Location = new Point(3, btnCancel.Location.Y + btnCancel.Height + 3);
            rtbConsole.Height = panelBody.Height - rtbConsole.Location.Y - 3;
            rtbConsole.Width = panelBody.Width - 6;
        }
    }
}
