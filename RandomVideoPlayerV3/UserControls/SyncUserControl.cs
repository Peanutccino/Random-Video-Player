using RandomVideoPlayer.Model;


namespace RandomVideoPlayer.UserControls
{
    public partial class SyncUserControl : UserControl
    {
        private SettingsModel settings;
        public SyncUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;

            BindControls();
            LoadSettings();
        }

        private void LoadSettings()
        {
            cbTimeCodeServer.Checked = settings.IsTimeCodeServerEnabled;
            cbScriptGraph.Checked = settings.IsGraphEnabled;
        }

        private void BindControls()
        {          
            cbTimeCodeServer.CheckedChanged += (s, e) =>
            {
                settings.IsTimeCodeServerEnabled = cbTimeCodeServer.Checked;
            };

            cbScriptGraph.CheckedChanged += (s, e) =>
            {
                settings.IsGraphEnabled = cbScriptGraph.Checked;
            };
        }
    }
}
