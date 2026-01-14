using RandomVideoPlayer.Model;
using System.Text.Json;

namespace RandomVideoPlayer.Functions
{
    public static class ThemeLoader
    {
        private static readonly string ThemeFolder =
            Path.Combine(AppContext.BaseDirectory, "Themes");

        public static IReadOnlyDictionary<string, Theme> LoadThemes()
        {
            Directory.CreateDirectory(ThemeFolder);
            var themes = new Dictionary<string, Theme>(StringComparer.OrdinalIgnoreCase);

            foreach (string file in Directory.GetFiles(ThemeFolder, "*.json"))
            {
                ThemeDto dto = JsonSerializer.Deserialize<ThemeDto>(File.ReadAllText(file));
                if (dto?.Name == null) continue;
                themes[dto.Name] = Map(dto);
            }
            return themes;
        }

        private static Theme Map(ThemeDto dto)
        {
            Theme defaults = GetFallbackTheme(dto.Name);

            return new Theme
            {
                FormBackColor = ParseColorOrDefault(dto.FormBackColor, defaults.FormBackColor),
                TextColor = ParseColorOrDefault(dto.TextColor, defaults.TextColor),
                ButtonHighlightColor = ParseColorOrDefault(dto.ButtonHighlightColor, defaults.ButtonHighlightColor),
                ButtonIconColor = ParseColorOrDefault(dto.ButtonIconColor, defaults.ButtonIconColor),
                ToolMenuTextColor = ParseColorOrDefault(dto.ToolMenuTextColor, defaults.ToolMenuTextColor),
                ToolMenuBackColor = ParseColorOrDefault(dto.ToolMenuBackColor, defaults.ToolMenuBackColor),
                ToolMenuHoverColor = ParseColorOrDefault(dto.ToolMenuHoverColor, defaults.ToolMenuHoverColor),
                ProgressColor = ParseColorOrDefault(dto.ProgressColor, defaults.ProgressColor),
                ProgressHoverColor = ParseColorOrDefault(dto.ProgressHoverColor, defaults.ProgressHoverColor),

                FbTextColor = ParseColorOrDefault(dto.FbTextColor, defaults.FbTextColor),
                FbTextColorAccent = ParseColorOrDefault(dto.FbTextColorAccent, defaults.FbTextColorAccent),
                FbBackColorLight = ParseColorOrDefault(dto.FbBackColorLight, defaults.FbBackColorLight),
                FbBackColorDark = ParseColorOrDefault(dto.FbBackColorDark, defaults.FbBackColorDark),
                FbAccentColor = ParseColorOrDefault(dto.FbAccentColor, defaults.FbAccentColor),
                FbHighlightColor = ParseColorOrDefault(dto.FbHighlightColor, defaults.FbHighlightColor),

                LbTextColor = ParseColorOrDefault(dto.LbTextColor, defaults.LbTextColor),
                LbTextColorMainAccent = ParseColorOrDefault(dto.LbTextColorMainAccent, defaults.LbTextColorMainAccent),
                LbTextColorSideAccent = ParseColorOrDefault(dto.LbTextColorSideAccent, defaults.LbTextColorSideAccent),

                LbBackColorMainLight = ParseColorOrDefault(dto.LbBackColorMainLight, defaults.LbBackColorMainLight),
                LbBackColorMainDark = ParseColorOrDefault(dto.LbBackColorMainDark, defaults.LbBackColorMainDark),
                LbAccentColorMain = ParseColorOrDefault(dto.LbAccentColorMain, defaults.LbAccentColorMain),

                LbBackColorSideLight = ParseColorOrDefault(dto.LbBackColorSideLight, defaults.LbBackColorSideLight),
                LbBackColorSideDark = ParseColorOrDefault(dto.LbBackColorSideDark, defaults.LbBackColorSideDark),
                LbAccentColorSide = ParseColorOrDefault(dto.LbAccentColorSide, defaults.LbAccentColorSide),
                LbHighlightColorMain = ParseColorOrDefault(dto.LbHighlightColorMain, defaults.LbHighlightColorMain),
                LbHighlightColorSide = ParseColorOrDefault(dto.LbHighlightColorSide, defaults.LbHighlightColorSide)
            };
        }

        private static Theme GetFallbackTheme(string name) =>
            name?.Equals("Dark", StringComparison.OrdinalIgnoreCase) == true
                ? ThemeDefaults.Dark
                : ThemeDefaults.Light;
        private static Color ParseColorOrDefault(string hex, Color fallback)
        {
            if (string.IsNullOrWhiteSpace(hex))
            {
                return fallback;
            }
            try
            {
                return ColorTranslator.FromHtml(hex);
            }
            catch (Exception ex) when (
                ex is ArgumentException ||
                ex is FormatException ||
                ex is NotSupportedException)
            {
                return fallback;
            }
        }
    }
}
