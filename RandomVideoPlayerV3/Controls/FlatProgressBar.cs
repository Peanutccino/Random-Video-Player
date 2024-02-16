

namespace RandomVideoPlayerV3
{
    public class FlatProgressBar : Control
    {
        private int _value = 0;
        private int _minimum = 0;
        private int _maximum = 100;
        private int _borderThickness = 1;
        private bool mouseOver = false;
        private bool _showBorder = false;
        private Color _completedBrush = Color.DodgerBlue;
        private Color _remainingBrush = Color.Black;
        private Color _mousehoverBrush = Color.DeepSkyBlue;
        private Color _borderColor = Color.Black;

        public FlatProgressBar()
        {
            DoubleBuffered = true;
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (value > Maximum)
                {
                    value = Maximum;
                }
                else if (value < Minimum)
                {
                    value = Minimum;
                }
                _value = value;
                Invalidate();
            }
        }
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Invalidate();
            }
        }

        public Color CompletedBrush
        {
            get { return _completedBrush; }
            set
            {
                _completedBrush = value;
                Invalidate();
            }
        }

        public Color RemainingBrush
        {
            get { return _remainingBrush; }
            set
            {
                _remainingBrush = value;
                Invalidate();
            }
        }

        public Color MouseoverBrush
        {
            get { return _mousehoverBrush; }
            set
            {
                _mousehoverBrush = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value;
                Invalidate();
            }
        }

        public bool ShowBorder
        {
            get { return _showBorder; }
            set
            {
                _showBorder = value;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            mouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            mouseOver = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var percent = (float)Value / Maximum;
            var width = (int)(percent * Width);

            if (mouseOver)
            {
                e.Graphics.FillRectangle(new SolidBrush(_remainingBrush), 0, 0, Width, Height);
                e.Graphics.FillRectangle(new SolidBrush(_mousehoverBrush), 0, 0, width, Height);

                // Draw border if ShowBorder is true
                if (ShowBorder)
                {
                    var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                    var pen = new Pen(_borderColor, BorderThickness);
                    e.Graphics.DrawRectangle(pen, borderRect);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(_remainingBrush), 0, 0, Width, Height);
                e.Graphics.FillRectangle(new SolidBrush(_completedBrush), 0, 0, width, Height);

                // Draw border if ShowBorder is true
                if (ShowBorder)
                {
                    var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                    var pen = new Pen(_borderColor, BorderThickness);
                    e.Graphics.DrawRectangle(pen, borderRect);
                }
            }
        }
    }
}
