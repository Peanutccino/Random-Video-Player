using FontAwesome.Sharp;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class PathsUserControl : UserControl
    {
        private SettingsModel settings;
        private Color _textColor;
        private Color _backColorDark;
        private Color _highlightColor;

        private Color HoverColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 60);
        private Color PressedColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 20);

        private readonly Dictionary<IconButton, Color> idleColors = new();
        public PathsUserControl(SettingsModel settings)
        {
            InitializeComponent();

            DPI.UpdateDPIScaling(this);
            this.settings = settings;
            InitializeUI();
            BindControls();
            LoadSettings();
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);

            _textColor = ThemeManager.CurrentTheme.StTextColor;
            _backColorDark = ThemeManager.CurrentTheme.StBackColorDark;
            _highlightColor = ThemeManager.CurrentTheme.StHighlightColor;

            WireIconButton(sbtnDefaultPath);
            WireIconButton(sbtnFileMovePath);
            WireIconButton(sbtnListPath);
            WireIconButton(sbtnRemovalPath);
        }
        private void WireIconButton(IconButton btn)
        {
            btn.FlatAppearance.MouseOverBackColor = _backColorDark;
            btn.FlatAppearance.MouseDownBackColor = _backColorDark;
            btn.BackColor = _backColorDark;

            idleColors[btn] = _textColor;
            btn.IconColor = _textColor;

            btn.MouseEnter += (_, _) => btn.IconColor = HoverColor(btn);
            btn.MouseLeave += (_, _) => btn.IconColor = idleColors[btn];
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    btn.IconColor = PressedColor(btn);
            };
            btn.MouseUp += (_, _) =>
            {
                btn.IconColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn)
                    : idleColors[btn];
            };
            btn.GotFocus += (_, _) => btn.IconColor = HoverColor(btn);
            btn.LostFocus += (_, _) => btn.IconColor = idleColors[btn];
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
