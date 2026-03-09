using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class PathEllipsis
    {
        public static string EllipsizeMiddle(string text, Font font, int maxWidth)
        {
            if (string.IsNullOrEmpty(text) || maxWidth <= 0)
                return string.Empty;

            if (TextRenderer.MeasureText(text, font, new Size(int.MaxValue, int.MaxValue),
                    TextFormatFlags.NoPadding).Width <= maxWidth)
                return text;

            const string ell = "...";

            if (TextRenderer.MeasureText(ell, font, new Size(int.MaxValue, int.MaxValue),
                    TextFormatFlags.NoPadding).Width > maxWidth)
                return string.Empty;

            int left = 0;
            int right = text.Length;

            int lo = 0, hi = text.Length;
            string best = ell;

            while (lo <= hi)
            {
                int keep = (lo + hi) / 2; 
                int keepLeft = keep / 2;
                int keepRight = keep - keepLeft;

                string candidate = text.Substring(0, keepLeft) + ell + text.Substring(text.Length - keepRight);

                int w = TextRenderer.MeasureText(candidate, font, new Size(int.MaxValue, int.MaxValue),
                    TextFormatFlags.NoPadding).Width;

                if (w <= maxWidth)
                {
                    best = candidate;
                    lo = keep + 1;
                }
                else
                {
                    hi = keep - 1;
                }
            }

            return best;
        }
    }
}
