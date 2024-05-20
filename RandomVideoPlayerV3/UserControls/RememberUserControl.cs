using RandomVideoPlayer.Model;


namespace RandomVideoPlayer.UserControls
{
    public partial class RememberUserControl : UserControl
    {
        private SettingsModel settings;
        public RememberUserControl(SettingsModel settings)
        {
            InitializeComponent();
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
        }
    }
}
