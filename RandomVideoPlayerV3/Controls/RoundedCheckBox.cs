using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class RoundedCheckBox : CheckBox
    {
        public Color CheckedBackColor { get; set; } = Color.LightGreen;
        public Color UncheckedBackColor { get; set; } = Color.LightGray;

        private bool isHovered = false;
        private bool isPressed = false;

        public RoundedCheckBox()
        {
            this.Appearance = Appearance.Button;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;

            this.MouseEnter += (s, e) => { isHovered = true; this.Invalidate(); };
            this.MouseLeave += (s, e) => { isHovered = false; this.Invalidate(); };
            this.MouseDown += (s, e) => { isPressed = true; this.Invalidate(); };
            this.MouseUp += (s, e) => { isPressed = false; this.Invalidate(); };
        }

        private Color LightenColor(Color color, float factor)
        {
            float red = Math.Min(color.R + color.R * factor, 255);
            float green = Math.Min(color.G + color.G * factor, 255);
            float blue = Math.Min(color.B + color.B * factor, 255);
            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        private Color DarkenColor(Color color, float factor)
        {
            float red = Math.Max(color.R - color.R * factor, 0);
            float green = Math.Max(color.G - color.G * factor, 0);
            float blue = Math.Max(color.B - color.B * factor, 0);
            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(this.Parent.BackColor);

            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-1, -1);

            GraphicsPath path = new GraphicsPath();
            int radius = rect.Height; 
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            Color baseColor = this.Checked ? CheckedBackColor : UncheckedBackColor;
            Color backColor = baseColor;

            if (isPressed)
            {
                backColor = LightenColor(baseColor, 0.06f);
            }
            else if (isHovered)
            {
                backColor = DarkenColor(baseColor, 0.06f);
            }

            using (Brush brush = new SolidBrush(backColor))
            {
                g.FillPath(brush, path);
            }

            TextRenderer.DrawText(g, this.Text, this.Font, rect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
