using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class RememberUserControl : UserControl
    {
        private SettingsModel settings;
        public RememberUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

            this.settings = settings;
            BindControls();
            LoadSettings();
        }
        private void LoadSettings()
        {
            cbWindowSize.Checked = settings.MemberWindowSize;
            cbPlayRecent.Checked = settings.MemberPlayRecent;
            cbRecentCount.Checked = settings.MemberRecentCount;
            cbVolume.Checked = settings.MemberVolume;

            cbAlwaysAsk.Checked = settings.StartupAlwaysAsk;

            if (settings.StartupAllDirectories)
            {
                rbAllDirectories.Checked = true;
            }
            else
            {
                rbSingleDirectory.Checked = true;
            }
        }

        private void BindControls()
        {
            cbWindowSize.CheckedChanged += (s, e) =>
            {
                settings.MemberWindowSize = cbWindowSize.Checked;
            };

            cbPlayRecent.CheckedChanged += (s, e) =>
            {
                settings.MemberPlayRecent = cbPlayRecent.Checked;
            };

            cbRecentCount.CheckedChanged += (s, e) =>
            {
                settings.MemberRecentCount = cbRecentCount.Checked;
            };

            cbVolume.CheckedChanged += (s, e) =>
            {
                settings.MemberVolume = cbVolume.Checked;
            };

            cbAlwaysAsk.CheckedChanged += (s, e) =>
            {
                settings.StartupAlwaysAsk = cbAlwaysAsk.Checked;
            };

            rbAllDirectories.CheckedChanged += (s, e) =>
            {
                settings.StartupAllDirectories = rbAllDirectories.Checked;
            };
        }

        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);

            panel1.Size = DPI.GetSizeScaled(panel1.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);
            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);
            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);

            cbWindowSize.Size = DPI.GetSizeScaled(cbWindowSize.Size);
            cbWindowSize.Font = DPI.GetFontScaled(cbWindowSize.Font);
            cbPlayRecent.Size = DPI.GetSizeScaled(cbPlayRecent.Size);
            cbPlayRecent.Font = DPI.GetFontScaled(cbPlayRecent.Font);
            cbRecentCount.Size = DPI.GetSizeScaled(cbRecentCount.Size);
            cbRecentCount.Font = DPI.GetFontScaled(cbRecentCount.Font);
            cbVolume.Size = DPI.GetSizeScaled(cbVolume.Size);
            cbVolume.Font = DPI.GetFontScaled(cbVolume.Font);
            cbAlwaysAsk.Size = DPI.GetSizeScaled(cbAlwaysAsk.Size);
            cbAlwaysAsk.Font = DPI.GetFontScaled(cbAlwaysAsk.Font);

            rbSingleDirectory.Size = DPI.GetSizeScaled(rbSingleDirectory.Size);
            rbSingleDirectory.Font = DPI.GetFontScaled(rbSingleDirectory.Font);
            rbAllDirectories.Size = DPI.GetSizeScaled(rbAllDirectories.Size);
            rbAllDirectories.Font = DPI.GetFontScaled(rbAllDirectories.Font);
        }

    }
}
