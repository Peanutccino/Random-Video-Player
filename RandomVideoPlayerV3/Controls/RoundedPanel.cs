using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class RoundedPanel : Panel
    {
        public int RadiusTopLeft { get; set; } = 16;
        public int RadiusTopRight { get; set; } = 16;
        public int RadiusBottomRight { get; set; } = 16;
        public int RadiusBottomLeft { get; set; } = 16;
        public Color FillColor { get; set; } = Color.White;

        public RoundedPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = BuildPath(rect,
                RadiusTopLeft, RadiusTopRight,
                RadiusBottomRight, RadiusBottomLeft);
            using var brush = new SolidBrush(FillColor);

            g.FillPath(brush, path);
        }

        private static GraphicsPath BuildPath(Rectangle bounds, int tl, int tr, int br, int bl)
        {
            var path = new GraphicsPath();
            int x = bounds.X - 1;
            int y = bounds.Y - 1;
            int w = bounds.Width + 2;
            int h = bounds.Height + 2;

            // Clamp radii so they fit inside the side lengths
            tl = Math.Min(tl, Math.Min(w, h));
            tr = Math.Min(tr, Math.Min(w, h));
            br = Math.Min(br, Math.Min(w, h));
            bl = Math.Min(bl, Math.Min(w, h));

            path.StartFigure();

            // Top-left corner
            if (tl > 0)
                path.AddArc(x, y, tl * 2, tl * 2, 180, 90);
            else
                path.AddLine(x, y, x, y); // noop anchor

            // Top edge + top-right
            path.AddLine(x + tl, y, x + w - tr, y);
            if (tr > 0)
                path.AddArc(x + w - tr * 2, y, tr * 2, tr * 2, 270, 90);
            else
                path.AddLine(x + w, y, x + w, y);

            // Right edge + bottom-right
            path.AddLine(x + w, y + tr, x + w, y + h - br);
            if (br > 0)
                path.AddArc(x + w - br * 2, y + h - br * 2, br * 2, br * 2, 0, 90);
            else
                path.AddLine(x + w, y + h, x + w, y + h);

            // Bottom edge + bottom-left
            path.AddLine(x + w - br, y + h, x + bl, y + h);
            if (bl > 0)
                path.AddArc(x, y + h - bl * 2, bl * 2, bl * 2, 90, 90);
            else
                path.AddLine(x, y + h, x, y + h);

            // Left edge back to top
            path.AddLine(x, y + h - bl, x, y + tl);
            path.CloseFigure();

            return path;
        }
    }
}
