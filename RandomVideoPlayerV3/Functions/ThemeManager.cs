using FontAwesome.Sharp;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class ThemeManager
    {
        public static Theme CurrentTheme { get; private set; } = Theme.Light;
        public static event EventHandler ThemeChanged;

        public static void SetTheme(Theme theme)
        {
            if (theme == CurrentTheme) return;
            CurrentTheme = theme;
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void ApplyTheme(Control root)
        {
            root.BackColor = CurrentTheme.FormBackColor;
            root.ForeColor = CurrentTheme.TextColor;

            switch (root)
            {
                case IconButton btnExit when btnExit.Name == "btnExitForm":
                    btnExit.BackColor = CurrentTheme.FormBackColor;
                    btnExit.ForeColor = CurrentTheme.TextColor;
                    btnExit.IconColor = CurrentTheme.ButtonIconColor;
                    btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
                    break;
                case IconButton iconBtn:
                    iconBtn.BackColor = CurrentTheme.FormBackColor;
                    iconBtn.ForeColor = CurrentTheme.TextColor;
                    iconBtn.IconColor = CurrentTheme.ButtonIconColor;
                    iconBtn.FlatAppearance.MouseOverBackColor = CurrentTheme.ButtonBackColor;
                    iconBtn.FlatAppearance.MouseDownBackColor = CurrentTheme.ButtonBackColor;
                    break;                
                case Button btn:
                    btn.BackColor = CurrentTheme.ButtonBackColor;
                    btn.ForeColor = CurrentTheme.TextColor;
                    btn.FlatAppearance.MouseOverBackColor = CurrentTheme.ButtonBackColor;
                    btn.FlatAppearance.MouseDownBackColor = CurrentTheme.ButtonBackColor;
                    break;

                case FlatProgressBar pb when pb.Name == "pbVolume":
                    pb.RemainingBrush = CurrentTheme.FormBackColor;
                    pb.CompletedBrush = CurrentTheme.TextColor;                    
                    pb.MouseoverBrush = CurrentTheme.TextColor;
                    pb.BorderColor = CurrentTheme.TextColor;
                    break;
                case FlatProgressBar pb when pb.Name == "pbPlayerProgress":
                    pb.CompletedBrush = CurrentTheme.ProgressColor;                    
                    pb.MouseoverBrush = CurrentTheme.ProgressHoverColor;
                    break;
            }

            foreach (Control child in root.Controls)
            {
                ApplyTheme(child);
            }
        }

        public static void ApplyThemeFB(Control root)
        {
            root.BackColor = CurrentTheme.FbAccentColor;
            root.ForeColor = CurrentTheme.FbTextColor;

            switch (root)
            {
                case IconButton btnExit when btnExit.Name == "btnClose":
                    btnExit.BackColor = CurrentTheme.FbAccentColor;
                    btnExit.ForeColor = CurrentTheme.FbTextColorAccent;
                    btnExit.IconColor = CurrentTheme.FbTextColorAccent;
                    btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnFolderSelect":
                    iconBtn.BackColor = CurrentTheme.FbAccentColor;
                    iconBtn.ForeColor = CurrentTheme.FbTextColorAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnBack":
                    iconBtn.BackColor = CurrentTheme.FbBackColorLight;
                    iconBtn.IconColor = CurrentTheme.FbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnAddFav":
                    iconBtn.BackColor = CurrentTheme.FbBackColorLight;
                    iconBtn.IconColor = CurrentTheme.FbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnDeleteFav":
                    iconBtn.BackColor = CurrentTheme.FbBackColorLight;
                    iconBtn.IconColor = CurrentTheme.FbTextColor;
                    break;
                case IconButton iconBtn:
                    iconBtn.BackColor = CurrentTheme.FbBackColorDark;
                    iconBtn.ForeColor = CurrentTheme.FbTextColor;
                    iconBtn.IconColor = CurrentTheme.FbTextColor;
                    break;
                case Button btn:
                    btn.BackColor = CurrentTheme.ButtonBackColor;
                    btn.ForeColor = CurrentTheme.FbTextColor;
                    break;
                case Panel pnlTop when pnlTop.Name == "panelTop":
                    pnlTop.BackColor = CurrentTheme.FbAccentColor;
                    break;
                case Panel pnlToolBar when pnlToolBar.Name == "panelToolbar":
                    pnlToolBar.BackColor = CurrentTheme.FbBackColorDark;
                    break;
                case Panel pnl:
                    pnl.BackColor = CurrentTheme.FbBackColorLight;
                    break;
                case RoundedCheckBox cb:
                    cb.BackColor = CurrentTheme.FbBackColorDark;
                    cb.ForeColor = CurrentTheme.FbTextColorAccent;
                    cb.UncheckedBackColor = CurrentTheme.FbBackColorDark;
                    cb.CheckedBackColor = CurrentTheme.FbAccentColor;
                    break;
                case ListView lv:
                    lv.BackColor = CurrentTheme.FbBackColorDark;
                    break;
                case ListBox lb:
                    lb.BackColor = CurrentTheme.FbBackColorLight;
                    break;
                case Label lbl when lbl.Name != "lblTitleBar":
                    lbl.BackColor = CurrentTheme.FbBackColorLight;
                    break;
                case Label lbl when lbl.Name == "lblTitleBar":
                    lbl.ForeColor = CurrentTheme.FbTextColorAccent;
                    break;
                case TextBox tb:
                    tb.BackColor = CurrentTheme.FbBackColorLight;  
                    tb.ForeColor = CurrentTheme.FbTextColor;
                    break;
            }

            foreach (Control child in root.Controls)
            {
                ApplyThemeFB(child);
            }
        }

        public static void ApplyThemeLB(Control root)
        {
            root.BackColor = CurrentTheme.LbAccentColorMain;
            root.ForeColor = CurrentTheme.LbTextColor;

            switch (root)
            {
                case IconButton btnExit when btnExit.Name == "btnClose":
                    btnExit.BackColor = CurrentTheme.LbAccentColorMain;
                    btnExit.ForeColor = CurrentTheme.LbTextColor;
                    btnExit.IconColor = CurrentTheme.LbTextColor;
                    btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
                    break;
                case IconButton btnUseList when btnUseList.Name == "btnUseList":
                    btnUseList.BackColor = CurrentTheme.LbAccentColorSide;
                    btnUseList.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    btnUseList.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnClearList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSide;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;        
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnClearSelected":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSide;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnDelDuplicates":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSide;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnLoadList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSide;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnSaveList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSide;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnAddFromPlaylist":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSide;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnMoveList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSide;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn:
                    iconBtn.BackColor = CurrentTheme.LbBackColorMain;
                    iconBtn.ForeColor = CurrentTheme.LbTextColor;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case Panel pnlCustomList when pnlCustomList.Name == "panelCustomListToolbar":
                    pnlCustomList.BackColor = CurrentTheme.LbBackColorSide;
                    break;
                case Panel pnlTop when pnlTop.Name == "panelTop":
                    pnlTop.BackColor = CurrentTheme.LbAccentColorMain;
                    break;
                case Panel pnl:
                    pnl.BackColor = CurrentTheme.LbBackColorMain;
                    break;
                case ListView lv when lv.Name == "lvFileExplore":
                    lv.BackColor = CurrentTheme.LbBackColorMain;
                    break;
                case ListView lv:
                    lv.BackColor = CurrentTheme.LbBackColorSide;
                    lv.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case TextBox tb:
                    tb.BackColor = CurrentTheme.LbBackColorMain;
                    tb.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case Label lbl when lbl.Name != "lblTitleBar":
                    lbl.BackColor = CurrentTheme.LbBackColorMain;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case ListBox lb:
                    lb.BackColor = CurrentTheme.LbBackColorMain;
                    break;
                case SplitContainer sc:
                    sc.BackColor = CurrentTheme.LbBackColorMain;
                    break;
                case RoundedCheckBox rcb:
                    rcb.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    rcb.BackColor = CurrentTheme.LbBackColorSide;
                    rcb.UncheckedBackColor = CurrentTheme.LbBackColorSide;
                    rcb.CheckedBackColor = CurrentTheme.LbAccentColorSide;
                    break;
            }

            foreach (Control child in root.Controls)
            {
                ApplyThemeLB(child);
            }
        }
    }
}
