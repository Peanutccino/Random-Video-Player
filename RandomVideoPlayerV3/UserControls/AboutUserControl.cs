using Newtonsoft.Json.Linq;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System;
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
        private const string VersionUrl = "https://raw.githubusercontent.com/Peanutccino/Random-Video-Player/master/version.txt";

        private SettingsModel settings;
        private static System.Timers.Timer blinkTimer;
        private static int colorLight = 230;
        private static int colorDark = 179;
        private static int value = 230;
        private static bool increasing = false;

        private bool updateAvailable = false;
        private bool needToRestart = false;
        private string latestVersionSaved;

        private bool restartNow = false;
        private TaskCompletionSource<bool> restartApplication;
        public AboutUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;

            lblCurrentVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            blinkTimer = new System.Timers.Timer(20);
            blinkTimer.Elapsed += OnTimedEvent;

            rtbConsole.Font = new Font(FontFamily.GenericMonospace, 9);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            rtbConsole.Visible = true;
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
                btnGitHub.Enabled = false;
                UpdateProgress("Looking for update files...");

                string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string latestVersion = latestVersionSaved;


                string zipUrl = $"https://github.com/Peanutccino/Random-Video-Player/releases/download/v{latestVersion}/RVP-v{latestVersion}_UpdateOnly.zip";
                string tempZipPath = Path.Combine(Path.GetTempPath(), $"RVP-v{latestVersion}_UpdateOnly.zip");
                string extractPath = Path.Combine(Path.GetTempPath(), "update");

                try
                {
                    DownloadUpdate(zipUrl, tempZipPath);
                    UpdateProgress("Extracting files...");

                    ExtractUpdate(tempZipPath, extractPath);
                    UpdateProgress("Extraction complete, waiting for user input...");
                }
                catch (Exception ex)
                {
                    UpdateProgress($"An error occurred during the update: {ex.Message}");
                    Error.Log(ex,"Error during download/extraction");
                    btnGitHub.Enabled = true;
                    return;
                }



                //Batch content
                string batchScript = $@"
@echo off
echo Waiting for application to exit...
:loop
tasklist /fi ""imagename eq RandomVideoPlayer.exe"" | find /i ""RandomVideoPlayer.exe"" >nul 2>&1
if not errorlevel 1 (
    timeout /t 1 /nobreak >nul
    goto loop
)
echo Copy new files...
timeout /t 2 /nobreak >nul
xcopy /s /e /y ""{extractPath}"" ""{Application.StartupPath}""
echo Delete update files...
rd /s /q ""{extractPath}""
echo Delete download package...
del ""{tempZipPath}""
echo Restart application...
timeout /t 3 /nobreak >nul
start """" ""{Application.StartupPath}RandomVideoPlayer.exe""
echo All done!
echo Deleting myself...
del ""%~f0"" & exit
";

                string batchFilePath = Path.Combine(Path.GetTempPath(), "update.bat");

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
                    UpdateProgress("Cleaning downloaded files...");
                    try
                    {
                        if (Directory.Exists(extractPath))
                        {
                            foreach (var file in Directory.GetFiles(extractPath))
                            {
                                File.Delete(file);
                            }                            
                        }
                        UpdateProgress("Done.");
                        UpdateProgress("Deleting downloaded package...");
                        if (File.Exists(tempZipPath))
                        {
                            File.Delete(tempZipPath);
                        }
                        UpdateProgress("Done.");
                        UpdateProgress("Deleting updater...");
                        if (File.Exists(batchFilePath))
                        {
                            File.Delete(batchFilePath);
                        }
                        UpdateProgress("Done.");
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, "Couldn't delete downloaded files after update was cancelled!");
                        UpdateProgress("Failed to delete downloaded files...");
                        UpdateProgress("You can delete them manually under:");
                        UpdateProgress($"{extractPath}");
                        UpdateProgress($"{tempZipPath}");
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

                    var response = await client.GetStringAsync(VersionUrl);
                    string latestVersionString = response.Trim();

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
                            lblLatestVersion.Text = latestVersion.ToString() + " - You're using the latest version!";
                        }
                    }
                    else
                    {
                        UpdateProgress("Error parsing the latest version number");
                        lblLatestVersion.Text = "Error parsing the latest version number. Please check the version file format.";
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Error checking for updates");
                UpdateProgress($"Error checking for updates: {ex.Message}");
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

            if(timeStamp)
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

            if (rtbConsole.Lines.Length > 0)
            {
                // Remove the last line
                var lines = rtbConsole.Lines;
                lines[lines.Length - 1] = formattedMessage;
                rtbConsole.Lines = lines;
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
                        UpdateProgress("Downloading...");
                        while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                            downloadedBytes += bytesRead;

                            int progressPercentage = (int)((double)downloadedBytes / totalBytes * 100);
                            int progressBlocks = (int)((double)downloadedBytes / totalBytes * progressBarLength);

                            string progressBar = new string('▋', progressBlocks).PadRight(progressBarLength, '-');
                            string progressMessage = $"[{progressBar}] {progressPercentage}%";

                            UpdateProgressLastLine($"{progressMessage}");

                            Application.DoEvents();
                        }
                    }
                    UpdateProgress("", false);
                    UpdateProgress("Download complete.");
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
            ZipFile.ExtractToDirectory(zipPath, extractPath, true);
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
    }
}
