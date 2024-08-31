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
        private static readonly string SettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotkeys.json");

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
                    new HotkeySetting { Action = "AddCurrentToList", Key = Keys.Insert, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "Favorite", Key = Keys.F, Modifiers = Keys.None },
                    new HotkeySetting { Action = "MoveCopyFile", Key = Keys.C, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ToggleShuffle", Key = Keys.S, Modifiers = Keys.None },
                    new HotkeySetting { Action = "SwitchPlaybackBehavior", Key = Keys.L, Modifiers = Keys.None },
                    new HotkeySetting { Action = "MutePlayer", Key = Keys.M, Modifiers = Keys.None },
                    new HotkeySetting { Action = "VolumeIncrease", Key = Keys.Up, Modifiers = Keys.None },
                    new HotkeySetting { Action = "VolumeDecrease", Key = Keys.Down, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ToggleExclusiveFullscreen", Key = Keys.F11, Modifiers = Keys.None },
                    new HotkeySetting { Action = "SeekForward", Key = Keys.Right, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "SeekBackward", Key = Keys.Left, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "SpeedIncrease", Key = Keys.Up, Modifiers = Keys.Control },
                    new HotkeySetting { Action = "SpeedDecrease", Key = Keys.Down, Modifiers = Keys.Control },
                    new HotkeySetting { Action = "SpeedReset", Key = Keys.R, Modifiers = Keys.Control },
                    new HotkeySetting { Action = "ZoomIn", Key = Keys.NumPad9, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ZoomOut", Key = Keys.NumPad7, Modifiers = Keys.None },
                    new HotkeySetting { Action = "PanLeft", Key = Keys.NumPad4, Modifiers = Keys.Control },
                    new HotkeySetting { Action = "PanRight", Key = Keys.NumPad6, Modifiers = Keys.Control },
                    new HotkeySetting { Action = "PanUp", Key = Keys.NumPad8, Modifiers = Keys.Control },
                    new HotkeySetting { Action = "PanDown", Key = Keys.NumPad2, Modifiers = Keys.Control },
                    new HotkeySetting { Action = "FitHorizontal", Key = Keys.NumPad3, Modifiers = Keys.None },
                    new HotkeySetting { Action = "FitVertical", Key = Keys.NumPad1, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ScaleWidthUp", Key = Keys.NumPad6, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ScaleWidthDown", Key = Keys.NumPad4, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ScaleHeightUp", Key = Keys.NumPad8, Modifiers = Keys.None },
                    new HotkeySetting { Action = "ScaleHeightDown", Key = Keys.NumPad2, Modifiers = Keys.None },
                    new HotkeySetting { Action = "RotateClockwise", Key = Keys.NumPad3, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "Rotate180", Key = Keys.NumPad2, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "RotateCounterClockwise", Key = Keys.NumPad1, Modifiers = Keys.Alt },
                    new HotkeySetting { Action = "ResetVideoManipulation", Key = Keys.NumPad5, Modifiers = Keys.None }
                }
            };
        }
        public static HotkeySettings LoadHotkeySettings()
        {
            var defaultSettings = GetDefaultHotkeySettings();

            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    var json = File.ReadAllText(SettingsFilePath);
                    var userSettings = JsonSerializer.Deserialize<HotkeySettings>(json);

                    foreach (var defaultHotkey in defaultSettings.Hotkeys)
                    {
                        if (!userSettings.Hotkeys.Any(h => h.Action == defaultHotkey.Action))
                        {
                            userSettings.Hotkeys.Add(defaultHotkey);
                        }
                    }

                    SaveHotkeySettings(userSettings);

                    return userSettings;
                }
                else
                {
                    SaveHotkeySettings(defaultSettings);
                    return defaultSettings;
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Failed to load hotkeySettings");
                return defaultSettings;
            }


        }

        public static void SaveHotkeySettings(HotkeySettings settings)
        {
            try
            {
                var json = JsonSerializer.Serialize(settings);
                File.WriteAllText(SettingsFilePath, json);
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Couldn't save hotkeys.json");
            }

        }
    }
}
