using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class DragDropUserControl : UserControl
    {
        private SettingsModel settings;
        public DragDropUserControl(SettingsModel settings)
        {
            InitializeComponent();

            DPI.UpdateDPIScaling(this);

            this.settings = settings;
            InitializeUI();
            LoadSettings();
            BindControls();
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);
        }

        private void LoadSettings()
        {
            if (settings.PlayOnDrop)
            {
                rbDropPlay.Checked = true;
            }
            else
            {
                rbDropQueue.Checked = true;
            }

            cbAlwaysAddFilesToQueue.Checked = settings.AlwaysAddFilesToQueue;

            cbIncludeSubdirectories.Checked = settings.IncludeSubdirectoriesDnD;
        }

        private void BindControls()
        {
            rbDropPlay.CheckedChanged += (s, e) =>
            {
                settings.PlayOnDrop = rbDropPlay.Checked;
            };

            cbAlwaysAddFilesToQueue.CheckedChanged += (s, e) =>
            {
                settings.AlwaysAddFilesToQueue = cbAlwaysAddFilesToQueue.Checked;
            };

            cbIncludeSubdirectories.CheckedChanged += (s, e) =>
            {
                settings.IncludeSubdirectoriesDnD = cbIncludeSubdirectories.Checked;
            };
        }
    }
}
