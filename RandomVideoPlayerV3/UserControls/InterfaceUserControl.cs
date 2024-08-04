using RandomVideoPlayer.Model;


namespace RandomVideoPlayer.UserControls
{
    public partial class InterfaceUserControl : UserControl
    {
        private SettingsModel settings;
        private List<CheckBox> checkboxes;
        private bool _switch = false;

        public InterfaceUserControl(SettingsModel settings)
        {
            InitializeComponent();
            this.settings = settings;

            checkboxes = new List<CheckBox> { cbDeleteButton, cbListRemoveButton, cbListAddButton, cbAddToFavButton, cbMoveToButton, cbShuffleButton, cbLoopButton, cbSourceSelector };

            LoadSettings();
            BindControls();
            RepositionButtons();

            InitializeDynamicButtons(checkboxes.Count);
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
            cbSourceSelector.Checked = settings.ButtonStates[7];
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
            cbSourceSelector.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
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
            settings.ButtonStates[7] = cbSourceSelector.Checked;
        }
        private void InitializeDynamicButtons(int buttonCount)
        {
            for (int i = 0; i < buttonCount; i++) //Button move up
            {
                FontAwesome.Sharp.IconButton button = new FontAwesome.Sharp.IconButton();
                button.IconChar = FontAwesome.Sharp.IconChar.CircleUp;
                button.IconFont = FontAwesome.Sharp.IconFont.Solid;
                button.IconSize = 28;
                button.IconColor = Color.Indigo;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Width = 24;
                button.Height = 24;

                button.Tag = i;

                button.Click += new EventHandler(ButtonUp_Click);
                this.flowPanel.Controls.Add(button);
            }
            for (int i = 0; i < buttonCount; i++) //Button move down
            {
                FontAwesome.Sharp.IconButton button = new FontAwesome.Sharp.IconButton();
                button.IconChar = FontAwesome.Sharp.IconChar.CircleDown;
                button.IconFont = FontAwesome.Sharp.IconFont.Solid;
                button.IconSize = 28;
                button.IconColor = Color.Indigo;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Width = 24;
                button.Height = 24;

                button.Tag = i;

                button.Click += new EventHandler(ButtonDown_Click);
                this.flowPanel.Controls.Add(button);
            }
        }
        private void ButtonUp_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int buttonIndex = (int)clickedButton.Tag;

            if (buttonIndex == 0) return;

            int buttonIndexEntry = settings.ButtonOrder[buttonIndex];
            settings.ButtonOrder.RemoveAt(buttonIndex);
            settings.ButtonOrder.Insert(buttonIndex - 1, buttonIndexEntry);

            RepositionButtons();
        }
        private void ButtonDown_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int buttonIndex = (int)clickedButton.Tag;

            if (buttonIndex == settings.ButtonStates.Length -1) return;

            int buttonIndexEntry = settings.ButtonOrder[buttonIndex];
            settings.ButtonOrder.RemoveAt(buttonIndex);
            settings.ButtonOrder.Insert(buttonIndex + 1, buttonIndexEntry);

            RepositionButtons();
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            settings.ButtonOrder.Clear();

            for (int i = 0; i < SettingsHandler.ButtonStates.Length; i++)
            {
                settings.ButtonOrder.Add(i);
            }

            RepositionButtons();
        }
        private void RepositionButtons()
        {
            int x = 12; //Startting x position
            int y = 1; //Startting Y position
            int margin = 5; //Spacing

            foreach (int index in settings.ButtonOrder)
            {
                CheckBox cbx = checkboxes[index];
                cbx.Location = new Point(x, y);
                y += cbx.Height + margin;
            }
        }


    }
}
