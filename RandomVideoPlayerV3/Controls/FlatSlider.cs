using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class FlatSlider : Control
    {
        public event EventHandler ValueChanged;

        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;

        public int Minimum
        {
            get => minimum;
            set
            {
                minimum = value;
                if (maximum < minimum) maximum = minimum;
                Value = Value;
            }
        }

        public int Maximum
        {
            get => maximum;
            set
            {
                maximum = Math.Max(value, minimum);
                Value = Value;
            }
        }

        public int Value
        {
            get => this.value;
            set
            {
                int clamped = Math.Max(minimum, Math.Min(maximum, value));
                if (this.value != clamped)
                {
                    this.value = clamped;
                    Invalidate();
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        [DefaultValue(1)]
        public int SmallChange { get; set; } = 1;

        [DefaultValue(6)]
        public int BarThickness { get; set; } = 6;
        public Color ElapsedColor { get; set; } = Color.DeepSkyBlue;
        public Color RemainingColor { get; set; } = Color.Gray;
        public Color ThumbColor { get; set; } = Color.White;
        public Size ThumbSize { get; set; } = new Size(14, 14);
        public Color HighlightColor { get; set; } = Color.DodgerBlue;

        private SliderVisualState state = SliderVisualState.Normal;
        private bool isDragging;

        public FlatSlider()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.Selectable, true);
            TabStop = true;
            Height = Math.Max(ThumbSize.Height, BarThickness + 8);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int left = ThumbSize.Width / 2;
            int right = Width - ThumbSize.Width / 2;
            int barY = (Height - BarThickness) / 2;
            Rectangle barRect = new Rectangle(left, barY, Math.Max(0, right - left), BarThickness);

            float progress = (maximum == minimum)
                ? 0f
                : (Value - minimum) / (float)(maximum - minimum);
            int thumbX = barRect.Left + (int)(progress * barRect.Width);

            Rectangle elapsedRect = new Rectangle(barRect.Left, barRect.Top, Math.Max(0, thumbX - barRect.Left), BarThickness);
            Rectangle remainingRect = new Rectangle(thumbX, barRect.Top, Math.Max(0, barRect.Right - thumbX), BarThickness);

            Color elapsedPaint = state switch
            {
                SliderVisualState.Hover => HighlightColor,
                SliderVisualState.Pressed => Blend(HighlightColor, Color.Black, 0.1f),
                _ => ElapsedColor
            };

            using (var elapsedBrush = new SolidBrush(elapsedPaint))
            using (var remainingBrush = new SolidBrush(RemainingColor))
            {
                if (elapsedRect.Width > 0) e.Graphics.FillRectangle(elapsedBrush, elapsedRect);
                if (remainingRect.Width > 0) e.Graphics.FillRectangle(remainingBrush, remainingRect);
            }

            Color thumbPaint = state switch
            {
                SliderVisualState.Hover => HighlightColor,
                SliderVisualState.Pressed => Blend(HighlightColor, Color.Black, 0.1f),
                _ => ThumbColor
            };

            Rectangle thumbRect = new Rectangle(
                thumbX - ThumbSize.Width / 2,
                (Height - ThumbSize.Height) / 2,
                ThumbSize.Width,
                ThumbSize.Height);

            using (var thumbBrush = new SolidBrush(thumbPaint))
            {
                e.Graphics.FillEllipse(thumbBrush, thumbRect);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!isDragging)
            {
                state = SliderVisualState.Hover;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!isDragging)
            {
                state = SliderVisualState.Normal;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;

            Focus();
            isDragging = true;
            state = SliderVisualState.Pressed;
            Capture = true;
            SetValueFromMouse(e.X);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                SetValueFromMouse(e.X);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (isDragging && e.Button == MouseButtons.Left)
            {
                isDragging = false;
                Capture = false;
                state = ClientRectangle.Contains(e.Location) ? SliderVisualState.Hover : SliderVisualState.Normal;
                Invalidate();
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!Focused) Focus();

            int steps = e.Delta / SystemInformation.MouseWheelScrollDelta;
            if (steps != 0)
            {
                Value = Value + steps * SmallChange;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!isDragging)
            {
                state = SliderVisualState.Hover;
                Invalidate();
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!isDragging)
            {
                state = SliderVisualState.Normal;
                Invalidate();
            }
        }
        private void SetValueFromMouse(int x)
        {
            int left = ThumbSize.Width / 2;
            int right = Width - ThumbSize.Width / 2;
            int usableWidth = Math.Max(1, right - left);
            float ratio = (float)(x - left) / usableWidth;
            Value = minimum + (int)Math.Round(ratio * (maximum - minimum));
        }

        private static Color Blend(Color baseColor, Color mixColor, float blendAmount)
        {
            blendAmount = Math.Max(0f, Math.Min(1f, blendAmount));
            int r = (int)(baseColor.R + (mixColor.R - baseColor.R) * blendAmount);
            int g = (int)(baseColor.G + (mixColor.G - baseColor.G) * blendAmount);
            int b = (int)(baseColor.B + (mixColor.B - baseColor.B) * blendAmount);
            int a = (int)(baseColor.A + (mixColor.A - baseColor.A) * blendAmount);
            return Color.FromArgb(a, r, g, b);
        }

        private enum SliderVisualState
        {
            Normal,
            Hover,
            Pressed
        }
    }
}
