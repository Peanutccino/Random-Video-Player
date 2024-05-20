using System.Text.Json;

namespace RandomVideoPlayer.Functions
{
    public class HotkeySetting
    {
        public string Action { get; set; }
        public Keys Key { get; set; }
        public Keys Modifiers { get; set; }
    }
    public class HotkeySettings
    {
        public List<HotkeySetting> Hotkeys { get; set; } = new List<HotkeySetting>();
    }
    public static class HotkeyManager
    {
        private static readonly string SettingsFilePath = "hotkeys.json";

        public static HotkeySettings GetDefaultHotkeySettings()
        {
            return new HotkeySettings
            {
                Hotkeys = new List<HotkeySetting>
                {
                    new HotkeySetting { Action = "PlayPrevious", Key = Keys.Left, Modifiers = Keys.None },
                    new HotkeySetting { Action = "PlayNext", Key = Keys.Right, Modifiers = Keys.None },
                    new HotkeySetting { Action = "PlayPauseToggle", Key = Keys.Space, Modifiers = Keys.None },
                    new HotkeySetting { Action = "Close", Key = Keys.Escape, Modifiers = Keys.None },
                    new HotkeySetting { Action = "DeleteCurrent", Key = Keys.Delete, Modifiers = Keys.None },
                    new HotkeySetting { Action = "DeleteCurrentFromList", Key = Keys.Delete, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "Favorite", Key = Keys.F, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ToggleShuffle", Key = Keys.S, Modifiers = Keys.None },
                    new HotkeySetting { Action = "MutePlayer", Key = Keys.M, Modifiers = Keys.None },
                    new HotkeySetting { Action = "VolumeIncrease", Key = Keys.Up, Modifiers = Keys.None },
                    new HotkeySetting { Action = "VolumeDecrease", Key = Keys.Down, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ToggleExclusiveFullscreen", Key = Keys.F11, Modifiers = Keys.None },
                    new HotkeySetting { Action = "SeekForward", Key = Keys.Right, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "SeekBackward", Key = Keys.Left, Modifiers = Keys.Alt }
                }
            };
        }
        public static HotkeySettings LoadHotkeySettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                var json = File.ReadAllText(SettingsFilePath);
                return JsonSerializer.Deserialize<HotkeySettings>(json);
            }
            return GetDefaultHotkeySettings();
        }

        public static void SaveHotkeySettings(HotkeySettings settings)
        {
            var json = JsonSerializer.Serialize(settings);
            File.WriteAllText(SettingsFilePath, json);
        }
    }
}
