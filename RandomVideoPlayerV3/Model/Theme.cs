using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public sealed class Theme
    {
        public static readonly Theme Light = new();
        public static readonly Theme Dark = new();

        #region Main
        public Color FormBackColor { get; init; }
        public Color TextColor { get; init; }
        public Color ButtonHighlightColor { get; init; }
        public Color ButtonIconColor { get; init; } 
        public Color ToolMenuTextColor { get; init; }
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
        public Color FbHighlightColor {  get; init; }
        #endregion

        #region ListBrowser
        public Color LbTextColor { get; init; }
        public Color LbTextColorMainAccent { get; init; }
        public Color LbTextColorSideAccent { get; init; }
        public Color LbBackColorMainLight { get; init; }
        public Color LbBackColorMainDark { get; init; }
        public Color LbAccentColorMain { get; init; }
        public Color LbBackColorSideLight { get; init; }
        public Color LbBackColorSideDark { get; init; }
        public Color LbAccentColorSide { get; init; }
        public Color LbHighlightColorMain { get; init; }
        public Color LbHighlightColorSide { get; init; }
        #endregion
    }
}
