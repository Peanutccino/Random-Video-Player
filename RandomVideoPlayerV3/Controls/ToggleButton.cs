using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace RandomVideoPlayer
{
    public class ToggleButton : CheckBox
    {
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;
        private bool mouseOver = false;


        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }

        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { }
        }

        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            this.mouseOver = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.mouseOver = false;
            this.Invalidate();
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            if (this.Checked) //ON
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());

                if (this.mouseOver)
                {
                    pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                      new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                    pevent.Graphics.FillEllipse(new SolidBrush(onBackColor),
                      new Rectangle(this.Width - this.Height + 4, 5, toggleSize - 6, toggleSize - 6));
                }
                else
                {
                    pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                      new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                }
            }
            else //OFF
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());

                if (this.mouseOver)
                {
                    pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                      new Rectangle(2, 2, toggleSize, toggleSize));
                    pevent.Graphics.FillEllipse(new SolidBrush(offBackColor),
                      new Rectangle(5, 5, toggleSize - 6, toggleSize - 6));
                }
                else
                {
                    pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                      new Rectangle(2, 2, toggleSize, toggleSize));
                }
            }
        }
    }
}
