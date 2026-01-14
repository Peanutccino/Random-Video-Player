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
            ButtonHighlightColor = ColorTranslator.FromHtml("#98FB98"),
            ButtonIconColor = ColorTranslator.FromHtml("#000000"),
            ToolMenuTextColor = ColorTranslator.FromHtml("#000000"),
            ToolMenuBackColor = ColorTranslator.FromHtml("#FF94B5"),
            ToolMenuHoverColor = ColorTranslator.FromHtml("#98FB98"),
            ProgressColor = ColorTranslator.FromHtml("#F86F64"),
            ProgressHoverColor = ColorTranslator.FromHtml("#FAA49E"),

            FbTextColor = ColorTranslator.FromHtml("#000000"),
            FbTextColorAccent = ColorTranslator.FromHtml("#000000"),
            FbBackColorLight = ColorTranslator.FromHtml("#FFFFB3"),
            FbBackColorDark = ColorTranslator.FromHtml("#F2F2AE"),
            FbAccentColor = ColorTranslator.FromHtml("#FFD700"),
            FbHighlightColor = ColorTranslator.FromHtml("#D47919"),

            LbTextColor = ColorTranslator.FromHtml("#000000"),
            LbTextColorMainAccent = ColorTranslator.FromHtml("#000000"),
            LbTextColorSideAccent = ColorTranslator.FromHtml("#000000"),

            LbBackColorMainLight = ColorTranslator.FromHtml("#FFE4E1"),
            LbBackColorMainDark = ColorTranslator.FromHtml("#E5CDCA"),
            LbAccentColorMain = ColorTranslator.FromHtml("#ED5151"),

            LbBackColorSideLight = ColorTranslator.FromHtml("#F0FFF0"),
            LbBackColorSideDark = ColorTranslator.FromHtml("#D8E5D8"),
            LbAccentColorSide = ColorTranslator.FromHtml("#98FB98"),

            LbHighlightColorMain = ColorTranslator.FromHtml("#BA5A30"),
            LbHighlightColorSide = ColorTranslator.FromHtml("#4C916C")
        };

        public static Theme Dark { get; } = new Theme
        {
            FormBackColor = ColorTranslator.FromHtml("#393059"),
            TextColor = ColorTranslator.FromHtml("#B0E0E6"),
            ButtonHighlightColor = ColorTranslator.FromHtml("#307BFD"),
            ButtonIconColor = ColorTranslator.FromHtml("#B0E0E6"),
            ToolMenuTextColor = ColorTranslator.FromHtml("#B0E0E6"),
            ToolMenuBackColor = ColorTranslator.FromHtml("#574988"),
            ToolMenuHoverColor = ColorTranslator.FromHtml("#307BFD"),
            ProgressColor = ColorTranslator.FromHtml("#64EEF8"),
            ProgressHoverColor = ColorTranslator.FromHtml("#7CE4EC"),

            FbTextColor = ColorTranslator.FromHtml("#FFFFFF"),
            FbTextColorAccent = ColorTranslator.FromHtml("#191919"),
            FbBackColorLight = ColorTranslator.FromHtml("#252525"),
            FbBackColorDark = ColorTranslator.FromHtml("#191919"),
            FbAccentColor = ColorTranslator.FromHtml("#FF9000"),
            FbHighlightColor = ColorTranslator.FromHtml("#EDBF18"),

            LbTextColor = ColorTranslator.FromHtml("#FFFFFF"),
            LbTextColorMainAccent = ColorTranslator.FromHtml("#191919"),
            LbTextColorSideAccent = ColorTranslator.FromHtml("#191919"),

            LbBackColorMainLight = ColorTranslator.FromHtml("#252525"),
            LbBackColorMainDark = ColorTranslator.FromHtml("#191919"),
            LbAccentColorMain = ColorTranslator.FromHtml("#00D176"),

            LbBackColorSideLight = ColorTranslator.FromHtml("#453D4D"),
            LbBackColorSideDark = ColorTranslator.FromHtml("#38323D"),
            LbAccentColorSide = ColorTranslator.FromHtml("#D464D9"),

            LbHighlightColorMain = ColorTranslator.FromHtml("#00CCA0"),
            LbHighlightColorSide = ColorTranslator.FromHtml("#D1005B")
        };
    }
}
