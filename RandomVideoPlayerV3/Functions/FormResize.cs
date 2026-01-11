using RandomVideoPlayer.Model;
using System.Drawing.Printing;

namespace RandomVideoPlayer.Functions
{
    public class FormResize
    {
        private int _borderSize = 2;
        private bool _windowExclusiveFullscreen = false;

        public Size FormSizeSaved
        {
            get 
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.formSizeMainSaved; 
            }
            set 
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.formSizeMainSaved = value;
                _settingsInstance.Save();
            }
        }

        public Size FormSizeFbSaved
        {
            get 
            {                 
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.formSizeFbSaved;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.formSizeFbSaved = value;
                _settingsInstance.Save();
            }
        }
        public Size FormSizeLbSaved
        {
            get 
            {                 
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.formSizeLbSaved;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.formSizeLbSaved = value;
                _settingsInstance.Save();
            }
        }

        public Size TempSizeMain { get; set; }
        public Size TempSizeFb { get; set; }
        public Size TempSizeLb { get; set; }

        public bool SaveLastSizeMain
        {
            get 
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.saveLastSizeMain; 
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.saveLastSizeMain = value;
                _settingsInstance.Save();
            }
        }

        public bool SaveLastSizeFb
        {
            get 
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.saveLastSizeFb; 
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.saveLastSizeFb = value;
                _settingsInstance.Save();
            }
        }

        public bool SaveLastSizeLb
        {
            get 
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.saveLastSizeLb; 
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.saveLastSizeLb = value;
                _settingsInstance.Save();
            }
        }

        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; }
        }
        public bool WindowExclusiveFullscreen 
        { 
            get { return _windowExclusiveFullscreen; }
        } 
        public void AdjustForm(Form f) //Correct padding due to WndProc
        {
            switch (f.WindowState)
            {
                case FormWindowState.Maximized:
                    f.Padding = new Padding(6, 8, 6, 8);
                    break;
                case FormWindowState.Normal:
                    if (f.Padding.Top != _borderSize)
                        f.Padding = new Padding(_borderSize);
                    break;
            }
        }

        public void MaximizeForm(Form f) //Trigger window maximized
        {
            switch(f.WindowState)
            {
                case FormWindowState.Normal:
                    f.WindowState = FormWindowState.Maximized;
                    break;
                case FormWindowState.Maximized:
                    f.WindowState = FormWindowState.Normal;
                    break;
            }
        }

        public void MinimizeForm(Form f) //Trigger window minimized
        {
            f.WindowState = FormWindowState.Minimized;
        }

        public void PlayerIsWindowSize(Form f, Panel top, Panel bottom, Panel player) //Logic to align panels automatically in window mode
        {
            player.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            player.Location = new Point(_borderSize, top.Height + _borderSize);
            player.Size = new Size(f.Width - (_borderSize * 2), f.Height - top.Height - bottom.Height - (_borderSize * 2));
            

            bottom.Dock = DockStyle.Bottom;
            bottom.Location = new Point(0, 286);
            bottom.Visible = true;

            top.Dock = DockStyle.Top;
            top.Location = new Point(2, 2);
            top.Visible = true;

            _windowExclusiveFullscreen = false;
        }
        public void UpdateFullscreenSize(Form f, Panel top, Panel bottom, Panel player)
        {
            PlayerIsFullscreenSize(f, top, bottom, player);
        }
        private void PlayerIsFullscreenSize(Form f, Panel top, Panel bottom, Panel player) //Logic to set up panels for exclusive Fullscreen mode
        {
            int buttonWidth = 30;
            int margin = 20;
            int newFormSize = 1018;
            int minimumFormSize = 800;

            foreach(bool state in SettingsHandler.ButtonStates)
            {
                if (!state)
                {
                    newFormSize = newFormSize - buttonWidth - margin;
                }
            }

            player.Anchor = AnchorStyles.None;
            player.Location = new Point(0, 0); 
            player.Size = new Size(f.Width, f.Height);

            bottom.Dock = DockStyle.None;
            bottom.Width = newFormSize <= minimumFormSize ? minimumFormSize : newFormSize;
            bottom.Location = new Point((f.Width / 2) - (bottom.Width / 2), f.Height - bottom.Height);
            bottom.Visible = false;

            top.Dock = DockStyle.None;
            top.Width = f.Width;
            top.Location = new Point(0, 0);
            top.Visible = false;

            _windowExclusiveFullscreen = true;
        }

        public void PlayerToExclusiveFullscreen(Form f, Panel top, Panel bottom, Panel player) //Trigger exclusive Fullscreen mode
        {
            if (f.FormBorderStyle == FormBorderStyle.None)
            {
                // Exiting fullscreen mode
                f.FormBorderStyle = FormBorderStyle.Sizable;
                f.WindowState = FormWindowState.Normal;
                PlayerIsWindowSize(f, top, bottom, player);
            }
            else
            {
                // Entering fullscreen mode
                f.FormBorderStyle = FormBorderStyle.None;
                f.WindowState = FormWindowState.Maximized;
                var currentScreen = Screen.FromControl(f);
                var bounds = currentScreen.Bounds;
                f.Bounds = bounds;
                PlayerIsFullscreenSize(f, top, bottom, player);
            }
        }
    }
}
