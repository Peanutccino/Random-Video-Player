using FontAwesome.Sharp;
using Mpv.NET.Player;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class DPI
    {
        public static float Scale { get; private set; }

        public static void SetScalingFactor()
        {
            if (SettingsHandler.EnableCustomScaling)
            {
                Scale = SettingsHandler.CustomScaling;
            }
            else
            {
                using (Graphics graphics = Graphics.FromHwnd(nint.Zero))
                {
                    float dpiX = graphics.DpiX;
                    Scale = dpiX / 96.0f;
                }
            }
        }
        public static void UpdateDPIScaling(Control root)
        {
            switch (root)
            {
                case ProgressBar pb:
                    pb.Height = GetDivided(pb.Height);
                    break;
                case Panel pnl when pnl.Name != "panelPlayerMPV":
                    pnl.Height = GetDivided(pnl.Height);
                    break;
                case IconButton ibtn:
                    ibtn.IconSize = GetDivided(ibtn.IconSize);
                    ibtn.Size = GetSizeScaled(ibtn.Size);
                    ibtn.Font = GetFontScaled(ibtn.Font);
                    break;
                case Button btn:
                    btn.Size = GetSizeScaled(btn.Size);
                    btn.Font = GetFontScaled(btn.Font);
                    break;
                case Label lbl:
                    lbl.Height = GetDivided(lbl.Height);
                    lbl.Font = GetFontScaled(lbl.Font);
                    break;
                case ComboBox combo:
                    combo.Size = GetSizeScaled(combo.Size);
                    break;
                case TextBox tb when tb.Parent is not CustomNumericUpDown:
                    tb.Height = GetDivided(tb.Height);
                    tb.Font = GetFontScaled(tb.Font);
                    break;
                case CheckBox cb:
                    cb.Size = GetSizeScaled(cb.Size);
                    cb.Font = GetFontScaled(cb.Font);
                    break;
                case RadioButton rb:
                    rb.Font = GetFontScaled(rb.Font);
                    rb.Size = GetSizeScaled(rb.Size);
                    break;
                case TableLayoutPanel tbl:
                    tbl.Size = GetSizeScaled(tbl.Size);
                    break;
                case CustomNumericUpDown numUD:
                    numUD.Size = GetSizeScaled(numUD.Size);
                    numUD.Font = GetFontScaled(numUD.Font);
                    break;
                case PictureBox pic:
                    pic.Size = GetSizeScaled(pic.Size); 
                    break;
                case ListView lv:
                    lv.Font = GetFontScaled(lv.Font);
                    break;
            }

            foreach(Control child in root.Controls)
            {
                UpdateDPIScaling(child);
            }
        }

        public static int GetDivided(int value)
        {
            var scaledValue = (int)(value / Scale);
            return scaledValue;
        }

        public static float GetDivided(float value)
        {
            var scaledValue = (float)(value / Scale);
            return scaledValue;
        }

        public static Size GetSizeScaled(Size value)
        {
            var scaledValue = new Size(value.Width, value.Height);
            scaledValue.Width = (int)(scaledValue.Width / Scale);
            scaledValue.Height = (int)(scaledValue.Height / Scale);

            return scaledValue;
        }

        public static Size RevertSize(Size value)
        {
            var scaledValue = new Size(value.Width, value.Height);
            scaledValue.Width = (int)(scaledValue.Width * Scale);
            scaledValue.Height = (int)(scaledValue.Height * Scale);

            return scaledValue;
        }

        public static Font GetFontScaled(Font value)
        {
            var scaledValue = new Font(value.FontFamily, value.Size / Scale, value.Style);

            return scaledValue;
        }
    }
}
