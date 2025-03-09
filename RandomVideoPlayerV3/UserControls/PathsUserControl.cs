using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class PathsUserControl : UserControl
    {
        private SettingsModel settings;
        public PathsUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

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

        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);

            panelDefault.Size = DPI.GetSizeScaled(panelDefault.Size);

            sbtnDefaultPath.Size = DPI.GetSizeScaled(sbtnDefaultPath.Size);
            sbtnDefaultPath.Location = new Point(panelDefault.Width - sbtnDefaultPath.Width - 3, 3);

            tbDefaultPath.Location = new Point(9, 3);
            tbDefaultPath.Width = panelDefault.Width - sbtnDefaultPath.Width - 15;
            tbDefaultPath.Font = DPI.GetFontScaled(tbDefaultPath.Font);

            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);

            panelRemoval.Size = DPI.GetSizeScaled(panelRemoval.Size);

            sbtnRemovalPath.Size = DPI.GetSizeScaled(sbtnRemovalPath.Size);
            sbtnRemovalPath.Location = new Point(panelRemoval.Width - sbtnRemovalPath.Width - 3, 3);

            tbRemovalPath.Location = new Point(9, 3);
            tbRemovalPath.Width = panelRemoval.Width - sbtnRemovalPath.Width - 15;
            tbRemovalPath.Font = DPI.GetFontScaled(tbRemovalPath.Font);

            panel1.Size = DPI.GetSizeScaled(panel1.Size);
            cbDeleteToggle.Size = DPI.GetSizeScaled(cbDeleteToggle.Size);
            cbDeleteToggle.Font = DPI.GetFontScaled(cbDeleteToggle.Font);

            cbFileMoveCopyToggle.Size = DPI.GetSizeScaled(cbFileMoveCopyToggle.Size);
            cbFileMoveCopyToggle.Font = DPI.GetFontScaled(cbFileMoveCopyToggle.Font);


            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);

            panelList.Size = DPI.GetSizeScaled(panelList.Size);

            sbtnListPath.Size = DPI.GetSizeScaled(sbtnListPath.Size);
            sbtnListPath.Location = new Point(panelList.Width - sbtnListPath.Width - 3, 3);

            tbListPath.Location = new Point(9, 3);
            tbListPath.Width = panelList.Width - sbtnListPath.Width - 15;
            tbListPath.Font = DPI.GetFontScaled(tbListPath.Font);

            lbl4.Size = DPI.GetSizeScaled(lbl4.Size);
            lbl4.Font = DPI.GetFontScaled(lbl4.Font);

            panelMove.Size = DPI.GetSizeScaled(panelMove.Size);

            sbtnFileMovePath.Size = DPI.GetSizeScaled(sbtnFileMovePath.Size);
            sbtnFileMovePath.Location = new Point(panelMove.Width - sbtnFileMovePath.Width - 3, 3);

            tbFileMovePath.Location = new Point(9, 3);
            tbFileMovePath.Width = panelMove.Width - sbtnFileMovePath.Width - 15;
            tbFileMovePath.Font = DPI.GetFontScaled(tbFileMovePath.Font);

            cbIncludeScripts.Size = DPI.GetSizeScaled(cbIncludeScripts.Size);
            cbIncludeScripts.Font = DPI.GetFontScaled(cbIncludeScripts.Font);
        }
    }
}
