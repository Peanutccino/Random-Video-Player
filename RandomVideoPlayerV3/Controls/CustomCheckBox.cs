using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class CustomCheckBox : CheckBox
    {
        public int BoxSize { get; set; } = 13; 
        public int PaddingLeft { get; set; } = 0;
        public Color HoverColor { get; set; } = Color.DeepSkyBlue;

        private bool isHovered = false;
        public CustomCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.MouseEnter += (s, e) => { isHovered = true; this.Invalidate(); };
            this.MouseLeave += (s, e) => { isHovered = false; this.Invalidate(); };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            Rectangle boxRect = new Rectangle(PaddingLeft, (this.Height - BoxSize) / 2, BoxSize, BoxSize);

            using (Brush backgroundBrush = new SolidBrush(Color.White))
            {
                g.FillRectangle(backgroundBrush, boxRect);
            }

            Color borderColor = isHovered ? HoverColor : Color.Black; 
            using (Pen borderPen = new Pen(borderColor, 1)) 
            {
                g.DrawRectangle(borderPen, boxRect);
            }

            if (this.Checked)
            {
                Color arrowColor = isHovered ? HoverColor : Color.Black;
                using (Pen checkPen = new Pen(arrowColor, 1.52f)) 
                {
                    int padding = BoxSize / 5; 
                    Point p1 = new Point(boxRect.Left + padding, boxRect.Top + BoxSize / 2);
                    Point p2 = new Point(boxRect.Left + BoxSize / 2 - 1, boxRect.Bottom - padding - 2);
                    Point p3 = new Point(boxRect.Right - padding, boxRect.Top + padding + 1);

                    g.DrawLines(checkPen, new[] { p1, p2, p3 });
                }
            }

            using (Brush textBrush = new SolidBrush(this.ForeColor))
            {
                StringFormat sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                };

                Rectangle textRect = new Rectangle(PaddingLeft + BoxSize + 5, 0, this.Width - (PaddingLeft + BoxSize + 5), this.Height);
                g.DrawString(this.Text, this.Font, textBrush, textRect, sf);
            }
        }
    }
}
