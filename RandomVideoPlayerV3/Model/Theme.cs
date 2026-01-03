using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public sealed class Theme
    {
        public static readonly Theme Light = new()
        {
            FormBackColor = Color.FromArgb(253, 83, 146),
            TextColor = Color.Black,
            ButtonBackColor = Color.FromArgb(253, 83, 146),
            ButtonHighlightColor = Color.FromArgb(152, 251, 152),
            ButtonIconColor = Color.Black,
            ToolMenuBackColor = Color.FromArgb(255, 148, 181),
            ToolMenuHoverColor = Color.FromArgb(152, 251, 152),
            ProgressColor = Color.FromArgb(248, 111, 100),
            ProgressHoverColor = Color.FromArgb(250, 164, 158),
            FbTextColor = Color.Black,
            FbTextColorAccent = Color.Black,
            FbBackColorLight = Color.FromArgb(255, 255, 224),
            FbBackColorDark = Color.FromArgb(250, 250, 210),
            FbAccentColor = Color.FromArgb(255, 215, 0),
            LbTextColor = Color.Black,
            LbTextColorSideAccent = Color.Black,
            LbBackColorMain = Color.FromArgb(255, 228, 225),
            LbAccentColorMain = Color.FromArgb(240, 128, 128),
            LbBackColorSide = Color.FromArgb(245, 255, 250),
            LbAccentColorSide = Color.FromArgb(152, 251, 152)
        };
        public static readonly Theme Dark = new()
        {
            FormBackColor = Color.FromArgb(57, 48, 89),
            TextColor = Color.PowderBlue, 
            ButtonBackColor = Color.FromArgb(57, 48, 89),
            ButtonHighlightColor = Color.FromArgb(48, 123, 253),
            ButtonIconColor = Color.PowderBlue,
            ToolMenuBackColor = Color.FromArgb(87, 73, 136),
            ToolMenuHoverColor = Color.FromArgb(48, 123, 253),
            ProgressColor = Color.FromArgb(100, 238, 248),
            ProgressHoverColor = Color.FromArgb(124, 228, 236),
            FbTextColor = Color.FromArgb(250, 250, 210),
            FbTextColorAccent = Color.Black,
            FbBackColorLight = Color.FromArgb(60, 60, 60),
            FbBackColorDark = Color.FromArgb(44, 44, 44),
            FbAccentColor = Color.FromArgb(179, 151, 23),
            LbTextColor = Color.FromArgb(244, 238, 224),
            LbTextColorSideAccent = Color.FromArgb(244, 238, 224),
            LbBackColorMain = Color.FromArgb(79, 69, 87),
            LbAccentColorMain = Color.FromArgb(67, 61, 139),
            LbBackColorSide = Color.FromArgb(109, 93, 110),
            LbAccentColorSide = Color.FromArgb(46, 35, 108)
        };

        #region Main
        public Color FormBackColor { get; init; }
        public Color TextColor { get; init; }
        public Color ButtonBackColor { get; init; }
        public Color ButtonHighlightColor { get; init; }
        public Color ButtonIconColor { get; init; }
        public Color ToolMenuBackColor { get; init; }
        public Color ToolMenuHoverColor { get; init; }
        public Color ProgressColor { get; init; }
        public Color ProgressHoverColor { get; init; }
        #endregion

        #region FolderBrowser
        public Color FbTextColor { get; init; }
        public Color FbTextColorAccent { get; init; }
        public Color FbBackColorLight { get; init; }
        public Color FbBackColorDark { get; init; }
        public Color FbAccentColor { get; init; }
        #endregion

        #region ListBrowser
        public Color LbTextColor { get; init; }
        public Color LbTextColorSideAccent { get; init; }
        public Color LbBackColorMain { get; init; }
        public Color LbAccentColorMain { get; init; }
        public Color LbBackColorSide { get; init; }
        public Color LbAccentColorSide{ get; init; }
        #endregion
    }
}
