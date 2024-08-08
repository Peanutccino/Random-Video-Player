using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class PathsUserControl : UserControl
    {
        private SettingsModel settings;
        public PathsUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;
            BindControls();
            LoadSettings();
        }


        private void sbtnDefaultPath_Click(object sender, EventArgs e)
        {
            fbDialog.InitialDirectory = PathHandler.DefaultFolder;

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbDefaultPath.Text = fbDialog.SelectedPath;
                settings.DefaultPathText = tbDefaultPath.Text;
            }
        }

        private void sbtnRemovalPath_Click(object sender, EventArgs e)
        {
            fbDialog.InitialDirectory = PathHandler.DefaultFolder;

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbRemovalPath.Text = fbDialog.SelectedPath;
                settings.RemovalPathText = tbRemovalPath.Text;
            }
        }

        private void sbtnListPath_Click(object sender, EventArgs e)
        {
            fbDialog.InitialDirectory = PathHandler.PathToListFolder;

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbListPath.Text = fbDialog.SelectedPath;
                settings.ListPathText = tbListPath.Text;
            }
        }
        private void sbtnFileMovePath_Click(object sender, EventArgs e)
        {
            fbDialog.InitialDirectory = PathHandler.DefaultFolder;

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbFileMovePath.Text = fbDialog.SelectedPath;
                settings.FileMovePath = tbFileMovePath.Text;
            }
        }

        private void LoadSettings()
        {
            tbDefaultPath.Text = settings.DefaultPathText;
            tbRemovalPath.Text = settings.RemovalPathText;
            tbListPath.Text = settings.ListPathText;
            cbDeleteToggle.Checked = settings.DeleteFull;
            cbIncludeScripts.Checked = settings.IncludeScript;
            tbFileMovePath.Text = settings.FileMovePath;
            cbFileMoveCopyToggle.Checked = settings.FileCopy;
        }
        private void BindControls()
        {
            cbDeleteToggle.CheckedChanged += (s, e) =>
            {
                settings.DeleteFull = cbDeleteToggle.Checked;
            };

            cbIncludeScripts.CheckedChanged += (s, e) =>
            {
                settings.IncludeScript = cbIncludeScripts.Checked;
            };

            cbFileMoveCopyToggle.CheckedChanged += (s, e) =>
            {
                settings.FileCopy = cbFileMoveCopyToggle.Checked;
            };
        }


    }
}
