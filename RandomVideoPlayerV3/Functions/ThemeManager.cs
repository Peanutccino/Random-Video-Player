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
        public static void ApplyThemeFBV2(Control root)
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
                case IconButton iconBtn when iconBtn.Name == "btnAddFav":
                    iconBtn.BackColor = CurrentTheme.FbBackColorLight;
                    iconBtn.IconColor = CurrentTheme.FbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnDeleteFav":
                    iconBtn.BackColor = CurrentTheme.FbBackColorLight;
                    iconBtn.IconColor = CurrentTheme.FbTextColor;
                    break;
                case IconButton iconBtn:
                    iconBtn.BackColor = CurrentTheme.FbBackColorLight;
                    iconBtn.ForeColor = CurrentTheme.FbTextColor;
                    iconBtn.IconColor = CurrentTheme.FbTextColor;
                    break;
                case FlowLayoutPanel flowp when flowp.Name == "flowPanelPath":
                    flowp.BackColor = CurrentTheme.FbBackColorDark;
                    break;
                case FlowLayoutPanel flowp:
                    flowp.BackColor = CurrentTheme.FbBackColorLight;
                    break;
                case RoundedButton rbtn when rbtn.Name == "btnStart":
                    rbtn.BackColor = CurrentTheme.FbAccentColor;
                    rbtn.ForeColor = CurrentTheme.FbTextColorAccent;
                    rbtn.BackgroundColor = CurrentTheme.FbBackColorDark;                    
                    break;
                case RoundedButton rbtn when rbtn.Name == "btnBack":
                    rbtn.BackColor = CurrentTheme.FbAccentColor;
                    rbtn.ForeColor = CurrentTheme.FbTextColor;
                    rbtn.BackgroundColor = CurrentTheme.FbBackColorDark;
                    break;
                case Button btn:
                    btn.BackColor = CurrentTheme.FbBackColorLight;
                    btn.ForeColor = CurrentTheme.FbTextColor;
                    break;
                case RoundedPanel rpnl:
                    rpnl.BackColor = CurrentTheme.FbBackColorLight;
                    rpnl.FillColor = CurrentTheme.FbBackColorDark;
                    break;
                case Panel pnlTop when pnlTop.Name == "panelTop":
                    pnlTop.BackColor = CurrentTheme.FbAccentColor;
                    break;
                case Panel pnl:
                    pnl.BackColor = CurrentTheme.FbBackColorLight;
                    break;
                case RoundedCheckBox cb:
                    cb.BackColor = CurrentTheme.FbBackColorDark;
                    cb.ForeColor = CurrentTheme.FbTextColorAccent;
                    cb.UncheckedBackColor = CurrentTheme.FbBackColorDark;
                    cb.CheckedBackColor = CurrentTheme.FbAccentColor;
                    cb.UncheckedForeColor = CurrentTheme.FbTextColor;
                    break;
                case ListView lv:
                    lv.BackColor = CurrentTheme.FbBackColorDark;
                    break;
                case Label lbl when lbl.Name == "lblTitleBar":
                    lbl.BackColor = CurrentTheme.FbAccentColor;
                    lbl.ForeColor = CurrentTheme.FbTextColorAccent;
                    break;
                case Label lbl:
                    lbl.BackColor = CurrentTheme.FbBackColorLight;
                    lbl.ForeColor = CurrentTheme.FbTextColor;
                    break;
                case FlatSlider slider:
                    slider.BackColor = CurrentTheme.FbBackColorLight;
                    slider.ElapsedColor = CurrentTheme.FbAccentColor;
                    slider.ThumbColor = CurrentTheme.FbAccentColor;
                    slider.RemainingColor = CurrentTheme.FbTextColor;
                    slider.HighlightColor = CurrentTheme.FbHighlightColor;
                    break;
            }

            foreach (Control child in root.Controls)
            {
                ApplyThemeFBV2(child);
            }
        }
        public static void ApplyThemeLBV2(Control root)
        {
            root.BackColor = CurrentTheme.LbAccentColorMain;
            root.ForeColor = CurrentTheme.LbTextColor;

            switch (root)
            {
                case IconButton btnExit when btnExit.Name == "btnClose":
                    btnExit.BackColor = CurrentTheme.LbAccentColorMain;
                    btnExit.ForeColor = CurrentTheme.LbTextColorMainAccent;
                    btnExit.IconColor = CurrentTheme.LbTextColorMainAccent;
                    btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnAddFav":
                    iconBtn.BackColor = CurrentTheme.LbBackColorMainLight;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnDeleteFav":
                    iconBtn.BackColor = CurrentTheme.LbBackColorMainLight;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnClearList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnClearSelected":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnDelDuplicates":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnLoadList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnSaveList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnAddFromPlaylist":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnMoveList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn:
                    iconBtn.BackColor = CurrentTheme.LbBackColorMainLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColor;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case FlowLayoutPanel flowp when flowp.Name == "flowPanelPath":
                    flowp.BackColor = CurrentTheme.LbBackColorMainDark;
                    break;
                case FlowLayoutPanel flowp:
                    flowp.BackColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case RoundedButton rbtn when rbtn.Name == "btnStart":
                    rbtn.BackColor = CurrentTheme.LbAccentColorMain;
                    rbtn.ForeColor = CurrentTheme.LbTextColorMainAccent;
                    rbtn.BackgroundColor = CurrentTheme.LbBackColorMainDark;
                    break;
                case RoundedButton rbtn when rbtn.Name == "btnBack":
                    rbtn.BackColor = CurrentTheme.LbAccentColorMain;
                    rbtn.ForeColor = CurrentTheme.LbTextColor;
                    rbtn.BackgroundColor = CurrentTheme.LbBackColorMainDark;
                    break;
                case Button btn:
                    btn.BackColor = CurrentTheme.LbBackColorMainLight;
                    btn.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case RoundedPanel rpnl when rpnl.Name == "roundedPanelSideTop":
                    rpnl.BackColor = CurrentTheme.LbBackColorSideDark;
                    rpnl.FillColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case RoundedPanel rpnl when rpnl.Name == "roundedPanelSideBottom":
                    rpnl.BackColor = CurrentTheme.LbBackColorSideDark;
                    rpnl.FillColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case RoundedPanel rpnl when rpnl.Name == "roundedPanelSideCenter":
                    rpnl.BackColor = CurrentTheme.LbBackColorMainLight;
                    rpnl.FillColor = CurrentTheme.LbBackColorSideDark;
                    break;
                case RoundedPanel rpnl when rpnl.Name == "roundedPanelCustomList":
                    rpnl.BackColor = CurrentTheme.LbBackColorMainLight;
                    rpnl.FillColor = CurrentTheme.LbBackColorSideDark;
                    break;
                case RoundedPanel rpnl when rpnl.Name == "roundedPanelCustomListTop":
                    rpnl.BackColor = CurrentTheme.LbBackColorSideDark;
                    rpnl.FillColor = CurrentTheme.LbBackColorSideLight;
                    break;
                case RoundedPanel rpnl when rpnl.Name == "roundedPanelCustomListBottom":
                    rpnl.BackColor = CurrentTheme.LbBackColorSideDark;
                    rpnl.FillColor = CurrentTheme.LbBackColorSideLight;
                    break;
                case RoundedPanel rpnl:
                    rpnl.BackColor = CurrentTheme.LbBackColorMainLight;
                    rpnl.FillColor = CurrentTheme.LbBackColorMainDark;
                    break;
                case Panel pnl when pnl.Name == "panelCustomListBottom":
                    pnl.BackColor = CurrentTheme.LbBackColorSideLight;
                    break;
                case Panel pnl when pnl.Name == "panelTop":
                    pnl.BackColor = CurrentTheme.LbAccentColorMain;
                    break;
                case Panel pnl:
                    pnl.BackColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case RoundedCheckBox cb:
                    cb.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    cb.UncheckedBackColor = CurrentTheme.LbBackColorSideDark;
                    cb.CheckedBackColor = CurrentTheme.LbAccentColorSide;
                    cb.UncheckedForeColor = CurrentTheme.LbTextColor;
                    break;
                case ListView lv when lv.Name == "lvCustomList":
                    lv.BackColor = CurrentTheme.LbBackColorSideDark;
                    break;
                case ListView lv:
                    lv.BackColor = CurrentTheme.LbBackColorMainDark;
                    break;
                case Label lbl when lbl.Name == "lblTitleBar":
                    lbl.BackColor = CurrentTheme.LbAccentColorMain;
                    lbl.ForeColor = CurrentTheme.LbTextColorMainAccent;
                    break;
                case Label lbl when lbl.Name == "lblSide1":
                    lbl.BackColor = CurrentTheme.LbBackColorSideLight;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case Label lbl when lbl.Name == "lblSide2":
                    lbl.BackColor = CurrentTheme.LbBackColorSideLight;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case Label lbl when lbl.Name == "lblLoadedList":
                    lbl.BackColor = CurrentTheme.LbBackColorSideLight;
                    lbl.ForeColor = CurrentTheme.LbHighlightColorSide;
                    break;
                case Label lbl when lbl.Name == "lblSide3":
                    lbl.BackColor = CurrentTheme.LbBackColorSideLight;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case Label lbl when lbl.Name == "lblSide4":
                    lbl.BackColor = CurrentTheme.LbBackColorSideLight;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case Label lbl when lbl.Name == "lblEntries":
                    lbl.BackColor = CurrentTheme.LbBackColorSideLight;
                    lbl.ForeColor = CurrentTheme.LbHighlightColorSide;
                    break;
                case Label lbl:
                    lbl.BackColor = CurrentTheme.LbBackColorMainLight;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case FlatSlider slider:
                    slider.BackColor = CurrentTheme.LbBackColorMainLight;
                    slider.ElapsedColor = CurrentTheme.LbAccentColorMain;
                    slider.ThumbColor = CurrentTheme.LbAccentColorMain;
                    slider.RemainingColor = CurrentTheme.LbTextColor;
                    slider.HighlightColor = CurrentTheme.LbHighlightColorMain;
                    break;
                case SplitContainer sc:
                    sc.BackColor = CurrentTheme.LbBackColorMainLight;
                    break;
            }

            foreach (Control child in root.Controls)
            {
                ApplyThemeLBV2(child);
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
                    cb.UncheckedForeColor = CurrentTheme.FbTextColor;
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
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;        
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnClearSelected":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnDelDuplicates":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnLoadList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnSaveList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnAddFromPlaylist":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn when iconBtn.Name == "btnMoveList":
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    iconBtn.IconColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case IconButton iconBtn:
                    iconBtn.BackColor = CurrentTheme.LbBackColorMainLight;
                    iconBtn.ForeColor = CurrentTheme.LbTextColor;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case Panel pnlCustomList when pnlCustomList.Name == "panelCustomListToolbar":
                    pnlCustomList.BackColor = CurrentTheme.LbBackColorSideLight;
                    break;
                case Panel pnlTop when pnlTop.Name == "panelTop":
                    pnlTop.BackColor = CurrentTheme.LbAccentColorMain;
                    break;
                case Panel pnl:
                    pnl.BackColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case ListView lv when lv.Name == "lvFileExplore":
                    lv.BackColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case ListView lv:
                    lv.BackColor = CurrentTheme.LbBackColorSideLight;
                    lv.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    break;
                case TextBox tb:
                    tb.BackColor = CurrentTheme.LbBackColorMainLight;
                    tb.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case Label lbl when lbl.Name != "lblTitleBar":
                    lbl.BackColor = CurrentTheme.LbBackColorMainLight;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case ListBox lb:
                    lb.BackColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case SplitContainer sc:
                    sc.BackColor = CurrentTheme.LbBackColorMainLight;
                    break;
                case RoundedCheckBox rcb:
                    rcb.ForeColor = CurrentTheme.LbTextColorSideAccent;
                    rcb.UncheckedBackColor = CurrentTheme.LbBackColorSideDark;
                    rcb.CheckedBackColor = CurrentTheme.LbAccentColorSide;
                    rcb.UncheckedForeColor = CurrentTheme.LbTextColor;
                    break;
            }

            foreach (Control child in root.Controls)
            {
                ApplyThemeLB(child);
            }
        }
        public static void ApplyThemeLSView(Control root)
        {
            root.BackColor = CurrentTheme.LbAccentColorSide;
            root.ForeColor = CurrentTheme.LbTextColor;

            switch (root)
            {
                case Panel pnl:
                    pnl.BackColor = CurrentTheme.LbBackColorSideDark;
                    break;
                case ListView lv:
                    lv.BackColor = CurrentTheme.LbBackColorSideLight;
                    lv.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case TextBox tb:
                    tb.BackColor = CurrentTheme.LbBackColorSideLight;
                    tb.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case Label lbl:
                    lbl.BackColor = CurrentTheme.LbBackColorSideDark;
                    lbl.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case CheckBox cb:
                    cb.BackColor = CurrentTheme.LbBackColorSideDark;
                    cb.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case IconButton iconBtn:
                    iconBtn.BackColor = CurrentTheme.LbBackColorSideDark;
                    iconBtn.ForeColor = CurrentTheme.LbTextColor;
                    iconBtn.IconColor = CurrentTheme.LbTextColor;
                    break;
                case ComboBox comboBox:
                    comboBox.BackColor = CurrentTheme.LbBackColorSideLight;
                    comboBox.ForeColor = CurrentTheme.LbTextColor;
                    break;
                case FlatProgressBar pb:
                    pb.BackColor = CurrentTheme.LbBackColorSideDark;
                    pb.CompletedBrush = CurrentTheme.LbAccentColorSide;
                    pb.RemainingBrush = CurrentTheme.LbBackColorMainLight;
                    pb.BorderColor = CurrentTheme.LbBackColorMainDark;
                    break;
            }

            foreach (Control child in root.Controls)
            {
                ApplyThemeLSView(child);
            }
        }
    }
}
