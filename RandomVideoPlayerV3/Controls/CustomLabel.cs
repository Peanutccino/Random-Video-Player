using System.Drawing.Drawing2D;

namespace RandomVideoPlayer.Controls
{
    public class CustomLabel : Label
    {
        private Color outlineColor = Color.Black;
        private int outlineThickness = 2;

        public Color OutlineColor
        {
            get { return outlineColor; }
            set
            {
                outlineColor = value;
                Invalidate(); 
            }
        }

        public int OutlineThickness
        {
            get { return outlineThickness; }
            set
            {
                outlineThickness = value;
                Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = GetHorizontalAlignment(this.TextAlign),
                    LineAlignment = GetVerticalAlignment(this.TextAlign)
                };

                path.AddString(
                    this.Text,
                    this.Font.FontFamily,
                    (int)this.Font.Style,
                    e.Graphics.DpiY * this.Font.SizeInPoints / 72,
                    this.ClientRectangle,
                    stringFormat);

                using (Pen pen = new Pen(OutlineColor, OutlineThickness)
                {
                    LineJoin = LineJoin.Round
                })
                {
                    e.Graphics.DrawPath(pen, path);
                }

                using (SolidBrush brush = new SolidBrush(this.ForeColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private StringAlignment GetHorizontalAlignment(ContentAlignment alignment)
        {
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    return StringAlignment.Near;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    return StringAlignment.Center;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    return StringAlignment.Far;
                default:
                    return StringAlignment.Near;
            }
        }

        private StringAlignment GetVerticalAlignment(ContentAlignment alignment)
        {
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    return StringAlignment.Near;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    return StringAlignment.Center;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    return StringAlignment.Far;
                default:
                    return StringAlignment.Near;
            }
        }
    }
}
