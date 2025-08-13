using RandomVideoPlayer.Model;
using System;
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

        public static int GetDivided(int value)
        {
            var scaledValue = (int)(value / Scale);
            return scaledValue;
        }

        public static Size GetSizeScaled(Size value)
        {
            var scaledValue = new Size(value.Width, value.Height);
            scaledValue.Width = (int)(scaledValue.Width / Scale);
            scaledValue.Height = (int)(scaledValue.Height / Scale);

            return scaledValue;
        }

        public static Font GetFontScaled(Font value)
        {
            var scaledValue = new Font(value.FontFamily, value.Size / Scale, value.Style);

            return scaledValue;
        }
    }
}
