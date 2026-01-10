using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class ThemeDefaults
    {
        public static Theme Light { get; } = new Theme
        {
            FormBackColor = ColorTranslator.FromHtml("#FD5392"),
            TextColor = ColorTranslator.FromHtml("#000000"),
            ButtonBackColor = ColorTranslator.FromHtml("#FD5392"),
            ButtonHighlightColor = ColorTranslator.FromHtml("#98FB98"),
            ButtonIconColor = ColorTranslator.FromHtml("#000000"),
            ToolMenuBackColor = ColorTranslator.FromHtml("#FF94B5"),
            ToolMenuHoverColor = ColorTranslator.FromHtml("#98FB98"),
            ProgressColor = ColorTranslator.FromHtml("#F86F64"),
            ProgressHoverColor = ColorTranslator.FromHtml("#FAA49E"),

            FbTextColor = ColorTranslator.FromHtml("#000000"),
            FbTextColorAccent = ColorTranslator.FromHtml("#000000"),
            FbBackColorLight = ColorTranslator.FromHtml("#FFFFB3"),
            FbBackColorDark = ColorTranslator.FromHtml("#F2F2AE"),
            FbAccentColor = ColorTranslator.FromHtml("#FFD700"),
            FbHighlightColor = ColorTranslator.FromHtml("#E1A71C"),

            LbTextColor = ColorTranslator.FromHtml("#000000"),
            LbTextColorMainAccent = ColorTranslator.FromHtml("#000000"),
            LbTextColorSideAccent = ColorTranslator.FromHtml("#000000"),

            LbBackColorMainLight = ColorTranslator.FromHtml("#FFE4E1"),
            LbBackColorMainDark = ColorTranslator.FromHtml("#FFE4E1"),
            LbAccentColorMain = ColorTranslator.FromHtml("#F08080"),

            LbBackColorSideLight = ColorTranslator.FromHtml("#F5FFFA"),
            LbBackColorSideDark = ColorTranslator.FromHtml("#F0FFF0"),
            LbAccentColorSide = ColorTranslator.FromHtml("#98FB98"),

            LbHighlightColorMain = ColorTranslator.FromHtml("#FF9000"),
            LbHighlightColorSide = ColorTranslator.FromHtml("#FF9000")
        };

        public static Theme Dark { get; } = new Theme
        {
            FormBackColor = ColorTranslator.FromHtml("#393059"),
            TextColor = ColorTranslator.FromHtml("#B0E0E6"),
            ButtonBackColor = ColorTranslator.FromHtml("#393059"),
            ButtonHighlightColor = ColorTranslator.FromHtml("#307BFD"),
            ButtonIconColor = ColorTranslator.FromHtml("#B0E0E6"),
            ToolMenuBackColor = ColorTranslator.FromHtml("#574988"),
            ToolMenuHoverColor = ColorTranslator.FromHtml("#307BFD"),
            ProgressColor = ColorTranslator.FromHtml("#64EEF8"),
            ProgressHoverColor = ColorTranslator.FromHtml("#7CE4EC"),

            FbTextColor = ColorTranslator.FromHtml("#FFFFFF"),
            FbTextColorAccent = ColorTranslator.FromHtml("#191919"),
            FbBackColorLight = ColorTranslator.FromHtml("#252525"),
            FbBackColorDark = ColorTranslator.FromHtml("#191919"),
            FbAccentColor = ColorTranslator.FromHtml("#FF9000"),
            FbHighlightColor = ColorTranslator.FromHtml("#FABA1A"),

            LbTextColor = ColorTranslator.FromHtml("#F4EEE0"),
            LbTextColorMainAccent = ColorTranslator.FromHtml("#F4EEE0"),
            LbTextColorSideAccent = ColorTranslator.FromHtml("#F4EEE0"),

            LbBackColorMainLight = ColorTranslator.FromHtml("#4F4557"),
            LbBackColorMainDark = ColorTranslator.FromHtml("#4F4557"),
            LbAccentColorMain = ColorTranslator.FromHtml("#433D8B"),

            LbBackColorSideLight = ColorTranslator.FromHtml("#6D5D6E"),
            LbBackColorSideDark = ColorTranslator.FromHtml("#4F4557"),
            LbAccentColorSide = ColorTranslator.FromHtml("#2E236C"),

            LbHighlightColorMain = ColorTranslator.FromHtml("#FF9000"),
            LbHighlightColorSide = ColorTranslator.FromHtml("#FF9000")
        };
    }
}
