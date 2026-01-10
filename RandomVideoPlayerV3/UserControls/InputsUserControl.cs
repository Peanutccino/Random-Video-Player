using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using RandomVideoPlayer.Views;
using System.Timers;
using System.Windows.Forms;

namespace RandomVideoPlayer.UserControls
{
    public partial class InputsUserControl : UserControl
    {
        private HotkeySettings settings;
        private static System.Timers.Timer blinkTimer;
        private static int colorLight = 230;
        private static int colorDark = 179;
        private static int value = 230;
        private static bool increasing = false;
        public InputsUserControl()
        {
            InitializeComponent();

            UpdateDPIScaling();
            settings = HotkeyManager.LoadHotkeySettings();
            PopulateListView();
            PopulateFixedListView();
            blinkTimer = new System.Timers.Timer(20);
            blinkTimer.Elapsed += OnTimedEvent;
        }

        private void PopulateListView()
        {
            lvHotkeys.Items.Clear();
            foreach (var hotkey in settings.Hotkeys)
            {
                var item = new ListViewItem(hotkey.Action);
                item.SubItems.Add(GetKeyCombination(hotkey));
                lvHotkeys.Items.Add(item);
            }
        }
        private void PopulateFixedListView()
        {
            lvFixedHotkeys.Items.Clear();
            foreach (var shortcut in shortcuts)
            {
                var item = new ListViewItem(shortcut.Value);
                item.SubItems.Add(shortcut.Key);
                lvFixedHotkeys.Items.Add(item);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            HotkeyManager.SaveHotkeySettings(settings);
            blinkTimer.Stop();
            blinkTimer.Enabled = false;
            increasing = false;
            value = colorLight;
            btnSave.BackColor = Color.FromArgb(value, value, 255);
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            settings = HotkeyManager.GetDefaultHotkeySettings();
            HotkeyManager.SaveHotkeySettings(settings);
            PopulateListView();
            blinkTimer.Stop();
            blinkTimer.Enabled = false;
            increasing = false;
            value = colorLight;
            btnSave.BackColor = Color.FromArgb(value, value, 255);
        }
        private void listViewHotkeys_DoubleClick(object sender, EventArgs e)
        {
            if (lvHotkeys.SelectedItems.Count > 0)
            {
                var selectedItem = lvHotkeys.SelectedItems[0];
                var action = selectedItem.Text;
                var hotkeySetting = settings.Hotkeys.First(h => h.Action == action);
                using (var form = new HotkeyEditForm(hotkeySetting, settings))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        hotkeySetting.Key = form.SelectedKey;
                        hotkeySetting.Modifiers = form.SelectedModifiers;
                        PopulateListView();

                        blinkTimer.AutoReset = true;
                        blinkTimer.Enabled = true;
                    }
                }
            }
        }
        private string GetKeyCombination(HotkeySetting hotkey)
        {
            if (hotkey.Modifiers == Keys.None)
            {
                return $"{hotkey.Key}";
            }
            else
            {
                return $"{hotkey.Modifiers} + {hotkey.Key}";
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

            btnSave.BackColor = Color.FromArgb(value, value, 255);
        }

        private void timerBlink_Tick(object sender, EventArgs e)
        {
            int colorLight = 230;
            int colorDark = 179;
            int fadeDirection = 1;
            int colorSet;

            for (int i = colorLight; i <= colorDark; i++)
            {
                colorSet = i;
                btnSave.BackColor = Color.FromArgb(colorSet, colorSet, 255);
            }

        }

        Dictionary<string, string> shortcuts = new Dictionary<string, string>
        {
            {"MB4", "Previous Track" },
            {"MB5 & RMB", "Next Track" },
            {"Media Play/Pause", "Play/Pause" },
            {"Media Previous", "Previous Track" },
            {"Media Next", "Next Track" },
            {"Scroll player", "Seek forwards/backwards" },
            {"Scroll volume", "Change volume" },
            {"Double Click player", "Exclusive Fullscreen" },
            {"Escape", "Exit application" }
        };

        private void UpdateDPIScaling()
        {
            this.MinimumSize = DPI.GetSizeScaled(this.MinimumSize);
            this.Size = DPI.GetSizeScaled(this.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);

            lvHotkeys.Size = DPI.GetSizeScaled(lvHotkeys.Size);
            lvHotkeys.Font = DPI.GetFontScaled(lvHotkeys.Font);

            lvFixedHotkeys.Size = DPI.GetSizeScaled(lvFixedHotkeys.Size);
            lvFixedHotkeys.Font = DPI.GetFontScaled(lvFixedHotkeys.Font);

            btnRestore.Size = DPI.GetSizeScaled(btnRestore.Size);
            btnRestore.Font = DPI.GetFontScaled(btnRestore.Font);
            btnRestore.Location = new Point(3, panelBottom.Height - btnRestore.Height - 3);

            btnSave.Size = DPI.GetSizeScaled(btnSave.Size);
            btnSave.Font = DPI.GetFontScaled(btnSave.Font);
            btnSave.Location = new Point(panelBottom.Width - btnSave.Width - 3, btnRestore.Location.Y);

            panelBottom.Size = DPI.GetSizeScaled(panelBottom.Size);
            splitUI.Size = DPI.GetSizeScaled(splitUI.Size);
        }
    }
}
