using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class CustomRadioButton : RadioButton
    {
        public int CircleSize { get; set; } = 12;
        public int PaddingLeft { get; set; } = 0;
        public Color HoverColor { get; set; } = Color.DeepSkyBlue;

        private bool isHovered = false;

        public CustomRadioButton()
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

            Rectangle circleRect = new Rectangle(PaddingLeft, (this.Height - CircleSize) / 2, CircleSize, CircleSize);

            Color borderColor = isHovered ? HoverColor : Color.Black; 
            using (Pen borderPen = new Pen(borderColor, 1)) 
            {
                g.DrawEllipse(borderPen, circleRect);
            }

            if (this.Checked)
            {
                int innerPadding = CircleSize / 4; 
                Rectangle innerCircleRect = new Rectangle(
                    circleRect.Left + innerPadding,
                    circleRect.Top + innerPadding,
                    CircleSize - 2 * innerPadding,
                    CircleSize - 2 * innerPadding
                );

                Color circleColor = isHovered ? HoverColor : Color.Black; 
                using (Brush innerCircleBrush = new SolidBrush(circleColor))
                {
                    g.FillEllipse(innerCircleBrush, innerCircleRect);
                }
            }

            using (Brush textBrush = new SolidBrush(this.ForeColor))
            {
                StringFormat sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center, 
                    Alignment = StringAlignment.Near       
                };

                RectangleF textRect = new RectangleF(
                    PaddingLeft + CircleSize + 5, 
                    0,                            
                    this.Width - (PaddingLeft + CircleSize + 5), 
                    this.Height                   
                );

                g.DrawString(this.Text, this.Font, textBrush, textRect, sf);
            }
        }
    }
}
