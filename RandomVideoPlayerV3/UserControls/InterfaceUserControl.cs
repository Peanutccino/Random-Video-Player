using RandomVideoPlayer.Model;


namespace RandomVideoPlayer.UserControls
{
    public partial class InterfaceUserControl : UserControl
    {
        private SettingsModel settings;
        public InterfaceUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;
            LoadSettings();
            BindControls();
        }

        private void LoadSettings()
        {
            cbDeleteButton.Checked = settings.ButtonStates[0];
            cbListRemoveButton.Checked = settings.ButtonStates[1];
            cbListAddButton.Checked = settings.ButtonStates[2];
            cbAddToFavButton.Checked = settings.ButtonStates[3];
            cbMoveToButton.Checked = settings.ButtonStates[4]; 
            cbShuffleButton.Checked = settings.ButtonStates[5]; 
            cbLoopButton.Checked = settings.ButtonStates[6];
        }
        private void BindControls()
        {
            cbDeleteButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbListRemoveButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbListAddButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbAddToFavButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbMoveToButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbShuffleButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbLoopButton.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.ButtonStates[0] = cbDeleteButton.Checked;
            settings.ButtonStates[1] = cbListRemoveButton.Checked;
            settings.ButtonStates[2] = cbListAddButton.Checked;
            settings.ButtonStates[3] = cbAddToFavButton.Checked;
            settings.ButtonStates[4] = cbMoveToButton.Checked;
            settings.ButtonStates[5] = cbShuffleButton.Checked;
            settings.ButtonStates[6] = cbLoopButton.Checked;
        }
    }
}
