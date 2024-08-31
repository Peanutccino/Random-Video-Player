using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class RoundedImageCheckBox : CheckBox
    {
        public Color CheckedBackColor { get; set; } = Color.LightGreen;
        public Color UncheckedBackColor { get; set; } = Color.LightGray;
        private bool isHovered = false;
        private bool isPressed = false;

        private Image image;

        [Browsable(true)]
        [Editor(typeof(ImageEditor), typeof(UITypeEditor))]
        public Image Image
        {
            get { return image; }
            set { image = value; this.Invalidate(); }
        }

        public RoundedImageCheckBox()
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
            // Create a Graphics object
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(this.Parent.BackColor);

            // Determine the checkbox's rectangle
            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-1, -1);

            // Create a path for the rounded rectangle
            GraphicsPath path = new GraphicsPath();
            int radius = rect.Height; // Full height radius for pill shape
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Determine background color based on state
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

            // Draw the background with appropriate color
            using (Brush brush = new SolidBrush(backColor))
            {
                g.FillPath(brush, path);
            }

            // Draw the image if it is set
            if (this.Image != null)
            {
                // Calculate the image's position to center it
                int imageWidth = this.Image.Width;
                int imageHeight = this.Image.Height;

                // Scale the image if it is larger than the checkbox
                if (imageWidth > rect.Width || imageHeight > rect.Height)
                {
                    float scaleFactor = Math.Min(((float)rect.Width - 8) / imageWidth, ((float)rect.Height - 8) / imageHeight);
                    imageWidth = (int)(imageWidth * scaleFactor);
                    imageHeight = (int)(imageHeight * scaleFactor);
                }

                int imageX = (rect.Width - imageWidth) / 2;
                int imageY = (rect.Height - imageHeight) / 2;

                // Draw the image
                g.DrawImage(this.Image, new Rectangle(imageX + 2, imageY + 1, imageWidth, imageHeight));
            }
        }
    }
}
