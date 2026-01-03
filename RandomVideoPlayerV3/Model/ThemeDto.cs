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
        public string FormBackColorLight { get; set; }
        public string TextColor { get; set; }
        public string ButtonBackColor { get; set; }
        public string ButtonHighlightColor { get; set; }
        public string ButtonIconColor { get; set; }
        public string ToolMenuBackColor { get; set; }
        public string ToolMenuHoverColor { get; set; }
        public string ProgressColor { get; set; }
        public string ProgressHoverColor { get; set; }
        public string FbTextColor { get; set; }
        public string FbTextColorAccent { get; set; }
        public string FbBackColorLight { get; set; }
        public string FbBackColorDark { get; set; }
        public string FbAccentColor { get; set; }
        public string LbTextColor { get; set; }
        public string LbTextColorSideAccent { get; set; }
        public string LbBackColorMain { get; set; }
        public string LbAccentColorMain { get; set; }
        public string LbBackColorSide { get; set; }
        public string LbAccentColorSide { get; set; }

        public static ThemeDto FromTheme(string name, Theme theme) => new()
        {
            Name = name,
            FormBackColor = ToHex(theme.FormBackColor),
            TextColor = ToHex(theme.TextColor),
            ButtonBackColor = ToHex(theme.ButtonBackColor),
            ButtonHighlightColor = ToHex(theme.ButtonHighlightColor),
            ButtonIconColor = ToHex(theme.ButtonIconColor),
            ToolMenuBackColor = ToHex(theme.ToolMenuBackColor),
            ToolMenuHoverColor = ToHex(theme.ToolMenuHoverColor),
            ProgressColor = ToHex(theme.ProgressColor),
            ProgressHoverColor = ToHex(theme.ProgressHoverColor),
            FbTextColor = ToHex(theme.FbTextColor),
            FbBackColorLight = ToHex(theme.FbBackColorLight),
            FbBackColorDark = ToHex(theme.FbBackColorDark),
            FbAccentColor = ToHex(theme.FbAccentColor),
            LbTextColor = ToHex(theme.LbTextColor),
            LbTextColorSideAccent = ToHex(theme.LbTextColorSideAccent),
            LbBackColorMain = ToHex(theme.LbBackColorMain),
            LbAccentColorMain = ToHex(theme.LbAccentColorMain),
            LbBackColorSide = ToHex(theme.LbBackColorSide),
            LbAccentColorSide = ToHex(theme.LbAccentColorSide)
        };

        private static string ToHex(Color color) => ColorTranslator.ToHtml(color);
    }
}
