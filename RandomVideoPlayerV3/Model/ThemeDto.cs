using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public sealed class ThemeDto
    {
        public string Name { get; set; }
        public string FormBackColor { get; set; }
        public string TextColor { get; set; }
        public string ButtonHighlightColor { get; set; }
        public string ButtonIconColor { get; set; }
        public string ToolMenuTextColor { get; set; }
        public string ToolMenuBackColor { get; set; }
        public string ToolMenuHoverColor { get; set; }
        public string ProgressColor { get; set; }
        public string ProgressHoverColor { get; set; }

        public string FbTextColor { get; set; }
        public string FbTextColorAccent { get; set; }
        public string FbBackColorLight { get; set; }
        public string FbBackColorDark { get; set; }
        public string FbAccentColor { get; set; }
        public string FbHighlightColor { get; set; }

        public string LbTextColor { get; set; }
        public string LbTextColorMainAccent { get; set; }
        public string LbTextColorSideAccent { get; set; }
        public string LbBackColorMainLight { get; set; }
        public string LbBackColorMainDark { get; set; }
        public string LbAccentColorMain { get; set; }
        public string LbBackColorSideLight { get; set; }
        public string LbBackColorSideDark { get; set; }
        public string LbAccentColorSide { get; set; }
        public string LbHighlightColorMain { get; set; }
        public string LbHighlightColorSide { get; set; }

        public string StTextColor { get; set; }
        public string StTextColorAccent { get; set; }
        public string StTextColorBack { get; set; }
        public string StTextColorHighlight { get; set; }
        public string StBackColor {  get; set; }
        public string StBackColorLight { get; set; }
        public string StBackColorDark { get; set; }
        public string StAccentColor {  get; set; }
        public string StHighlightColor { get; set; }

        public static ThemeDto FromTheme(string name, Theme theme) => new()
        {
            Name = name,
            FormBackColor = ToHex(theme.FormBackColor),
            TextColor = ToHex(theme.TextColor),
            ButtonHighlightColor = ToHex(theme.ButtonHighlightColor),
            ButtonIconColor = ToHex(theme.ButtonIconColor),
            ToolMenuTextColor = ToHex(theme.ToolMenuTextColor),
            ToolMenuBackColor = ToHex(theme.ToolMenuBackColor),
            ToolMenuHoverColor = ToHex(theme.ToolMenuHoverColor),
            ProgressColor = ToHex(theme.ProgressColor),
            ProgressHoverColor = ToHex(theme.ProgressHoverColor),

            FbTextColor = ToHex(theme.FbTextColor),
            FbTextColorAccent = ToHex(theme.FbTextColorAccent),
            FbBackColorLight = ToHex(theme.FbBackColorLight),
            FbBackColorDark = ToHex(theme.FbBackColorDark),
            FbAccentColor = ToHex(theme.FbAccentColor),
            FbHighlightColor = ToHex(theme.FbHighlightColor),
            LbTextColor = ToHex(theme.LbTextColor),

            LbTextColorMainAccent = ToHex(theme.LbTextColorMainAccent),
            LbTextColorSideAccent = ToHex(theme.LbTextColorSideAccent),
            LbBackColorMainLight = ToHex(theme.LbBackColorMainLight),
            LbBackColorMainDark = ToHex(theme.LbBackColorMainDark),
            LbAccentColorMain = ToHex(theme.LbAccentColorMain),
            LbBackColorSideLight = ToHex(theme.LbBackColorSideLight),
            LbBackColorSideDark = ToHex(theme.LbBackColorSideDark),
            LbAccentColorSide = ToHex(theme.LbAccentColorSide),
            LbHighlightColorMain = ToHex(theme.LbHighlightColorMain),
            LbHighlightColorSide = ToHex(theme.LbHighlightColorSide),

            StTextColor = ToHex(theme.StTextColor),
            StTextColorAccent = ToHex(theme.StTextColorAccent),
            StTextColorBack = ToHex(theme.StTextColorBack),
            StTextColorHighlight = ToHex(theme.StTextColorHighlight),
            StBackColor = ToHex(theme.StBackColor),
            StBackColorLight = ToHex(theme.StBackColorLight),
            StBackColorDark = ToHex(theme.StBackColorDark),
            StAccentColor = ToHex(theme.StAccentColor),
            StHighlightColor = ToHex(theme.StHighlightColor)
        };

        private static string ToHex(Color color) => ColorTranslator.ToHtml(color);
    }
}
