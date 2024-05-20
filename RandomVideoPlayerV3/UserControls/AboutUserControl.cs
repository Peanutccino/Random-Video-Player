using Newtonsoft.Json.Linq;
using RandomVideoPlayer.Model;
using System.Diagnostics;
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
        public AboutUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;

            lblCurrentVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            blinkTimer = new System.Timers.Timer(20);
            blinkTimer.Elapsed += OnTimedEvent;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void btnGitHub_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Peanutccino/Random-Video-Player") { UseShellExecute = true });
        }
        private async void CheckForUpdates()
        {
            try
            {
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
                            lblLatestVersion.Text = latestVersion.ToString() + " - Update available! Check GitHub to download.";

                            blinkTimer.AutoReset = true;
                            blinkTimer.Enabled = true;
                        }
                        else
                        {
                            lblLatestVersion.Text = latestVersion.ToString() + " - You're using the latest version!";
                        }
                    }
                    else
                    {
                        lblLatestVersion.Text = "Error parsing the latest version number. Please check the version file format.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}", "Update Check Failed", MessageBoxButtons.OK);
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
    }
}
