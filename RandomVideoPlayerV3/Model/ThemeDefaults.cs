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
            FbBackColorLight = ColorTranslator.FromHtml("#FFFFE0"),
            FbBackColorDark = ColorTranslator.FromHtml("#FAFAD2"),
            FbAccentColor = ColorTranslator.FromHtml("#FFD700"),
            LbTextColor = ColorTranslator.FromHtml("#000000"),
            LbTextColorSideAccent = ColorTranslator.FromHtml("#000000"),
            LbBackColorMain = ColorTranslator.FromHtml("#FFE4E1"),
            LbAccentColorMain = ColorTranslator.FromHtml("#F08080"),
            LbBackColorSide = ColorTranslator.FromHtml("#F5FFFA"),
            LbAccentColorSide = ColorTranslator.FromHtml("#98FB98")
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
            FbTextColor = ColorTranslator.FromHtml("#E0C097"),
            FbTextColorAccent = ColorTranslator.FromHtml("#E0C097"),
            FbBackColorLight = ColorTranslator.FromHtml("#352C2C"),
            FbBackColorDark = ColorTranslator.FromHtml("#2D2424"),
            FbAccentColor = ColorTranslator.FromHtml("#B85C38"),
            LbTextColor = ColorTranslator.FromHtml("#F4EEE0"),
            LbTextColorSideAccent = ColorTranslator.FromHtml("#F4EEE0"),
            LbBackColorMain = ColorTranslator.FromHtml("#4F4557"),
            LbAccentColorMain = ColorTranslator.FromHtml("#433D8B"),
            LbBackColorSide = ColorTranslator.FromHtml("#6D5D6E"),
            LbAccentColorSide = ColorTranslator.FromHtml("#2E236C")
        };
    }
}
