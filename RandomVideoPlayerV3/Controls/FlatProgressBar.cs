using Newtonsoft.Json.Linq;
using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer
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
        private Color _mouseOverColor = Color.Black;

        private int? _seekValue = null;
        private int _seekIndicatorAlpha = 80;

        public FlatProgressBar()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
        }

        public int Value
        {
            get => _value;
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
            get => _minimum;
            set
            {
                _minimum = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                Invalidate();
            }
        }

        public Color CompletedBrush
        {
            get => _completedBrush;
            set
            {
                _completedBrush = value;
                Invalidate();
            }
        }

        public Color RemainingBrush
        {
            get => _remainingBrush;
            set
            {
                _remainingBrush = value;
                Invalidate();
            }
        }
        public Color MouseoverBrush
        {
            get => _mousehoverBrush;
            set
            {
                _mousehoverBrush = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public int BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                Invalidate();
            }
        }

        public bool ShowBorder
        {
            get => _showBorder; 
            set
            {
                _showBorder = value;
                Invalidate();
            }
        }

        public int? SeekValue
        {
            get => _seekValue;
            set
            {
                if (value.HasValue)
                {
                    int v = value.Value;
                    if (v > Maximum) v = Maximum;
                    else if (v < Minimum) v = Minimum;
                    _seekValue = v;
                }
                else
                {
                    _seekValue = null;
                }
                Invalidate();
            }
        }

        public int SeekIndicatorAlpha
        {
            get => _seekIndicatorAlpha;
            set { _seekIndicatorAlpha = Math.Max(0, Math.Min(255, value)); Invalidate(); }
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
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            float progressPercentage = (float)Value / Maximum;
            int progressWidth = (int)(progressPercentage * Width);

            _mouseOverColor = mouseOver ? _mousehoverBrush : _completedBrush;

            using (var remaining = new SolidBrush(_remainingBrush))
                g.FillRectangle(remaining, 0, 0, Width, Height);

            using (var completed = new SolidBrush(_mouseOverColor))
                g.FillRectangle(completed, 0, 0, progressWidth, Height);

            //Seek preview indicator
            if (_seekValue.HasValue)
            {
                float seekPercentage = (float)_seekValue.Value / Maximum;
                int seekX = (int)(seekPercentage * Width);

                int left = Math.Min(progressWidth, seekX);
                int right = Math.Max(progressWidth, seekX);
                int bandWidth = Math.Max(right - left, 1);

                bool seekingForward = seekX >= progressWidth;
                Color bandColor = seekingForward ? _mousehoverBrush : _remainingBrush;
                Color markerColor = seekingForward ? _completedBrush : _remainingBrush;

                using (var band = new SolidBrush(Color.FromArgb(_seekIndicatorAlpha, bandColor)))
                    g.FillRectangle(band, left, 0, bandWidth, Height);

                // Indicator
                using (var marker = new Pen(Color.FromArgb(230, markerColor), 2))
                    g.DrawLine(marker, seekX, 0, seekX, Height);
            }

            if (ShowBorder)
            {
                var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                using (var pen = new Pen(_borderColor, BorderThickness))
                    g.DrawRectangle(pen, borderRect);
            }
        }
    }

}
