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

        private static Theme Map(ThemeDto dto) => new Theme
        {
            FormBackColor = ColorTranslator.FromHtml(dto.FormBackColor),
            TextColor = ColorTranslator.FromHtml(dto.TextColor),
            ButtonBackColor = ColorTranslator.FromHtml(dto.ButtonBackColor),
            ButtonHighlightColor = ColorTranslator.FromHtml(dto.ButtonHighlightColor),
            ButtonIconColor = ColorTranslator.FromHtml(dto.ButtonIconColor),
            ToolMenuBackColor = ColorTranslator.FromHtml(dto.ToolMenuBackColor),
            ToolMenuHoverColor = ColorTranslator.FromHtml(dto.ToolMenuHoverColor),
            ProgressColor = ColorTranslator.FromHtml(dto.ProgressColor),
            ProgressHoverColor = ColorTranslator.FromHtml(dto.ProgressHoverColor),

            FbTextColor = ColorTranslator.FromHtml(dto.FbTextColor),
            FbTextColorAccent = ColorTranslator.FromHtml(dto.FbTextColorAccent),
            FbBackColorLight = ColorTranslator.FromHtml(dto.FbBackColorLight),
            FbBackColorDark = ColorTranslator.FromHtml(dto.FbBackColorDark),
            FbAccentColor = ColorTranslator.FromHtml(dto.FbAccentColor),
            FbHighlightColor = ColorTranslator.FromHtml(dto.FbHightlightColor),

            LbTextColor = ColorTranslator.FromHtml(dto.LbTextColor),
            LbTextColorMainAccent = ColorTranslator.FromHtml(dto.LbTextColorMainAccent),
            LbTextColorSideAccent = ColorTranslator.FromHtml(dto.LbTextColorSideAccent),

            LbBackColorMainLight = ColorTranslator.FromHtml(dto.LbBackColorMainLight),
            LbBackColorMainDark = ColorTranslator.FromHtml(dto.LbBackColorMainDark),
            LbAccentColorMain = ColorTranslator.FromHtml(dto.LbAccentColorMain),

            LbBackColorSideLight = ColorTranslator.FromHtml(dto.LbBackColorSideLight),
            LbBackColorSideDark = ColorTranslator.FromHtml(dto.LbBackColorSideDark),
            LbAccentColorSide = ColorTranslator.FromHtml(dto.LbAccentColorSide),
            LbHighlightColorMain = ColorTranslator.FromHtml(dto.LbHighlightColorMain),
            LbHighlightColorSide = ColorTranslator.FromHtml(dto.LbHighlightColorSide)
        };
    }
}
