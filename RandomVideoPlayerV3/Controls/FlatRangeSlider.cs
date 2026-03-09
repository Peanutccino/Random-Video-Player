using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class FlatRangeSlider : Control
    {
        public event EventHandler<RangeChangedEventArgs>? RangeChanged;

        private int minimum = 0;
        private int maximum = 100;

        private int startValue = 20;
        private int endValue = 80;

        private int minimumRange = 0;

        private SliderVisualState state = SliderVisualState.Normal;
        private bool isDragging;

        private enum ThumbKind { None, Start, End }
        private ThumbKind activeThumb = ThumbKind.None;

        [DefaultValue(0)]
        public int Minimum
        {
            get => minimum;
            set
            {
                minimum = value;
                if (maximum < minimum) maximum = minimum;
                CoerceRange(raiseEvent: true);
            }
        }

        [DefaultValue(100)]
        public int Maximum
        {
            get => maximum;
            set
            {
                maximum = Math.Max(value, minimum);
                CoerceRange(raiseEvent: true);
            }
        }

        /// <summary>
        /// Minimum distance between StartValue and EndValue (in value units).
        /// </summary>
        [DefaultValue(0)]
        public int MinimumRange
        {
            get => minimumRange;
            set
            {
                minimumRange = Math.Max(0, value);
                CoerceRange(raiseEvent: true);
            }
        }

        [DefaultValue(1)]
        public int SmallChange { get; set; } = 1;

        [DefaultValue(6)]
        public int BarThickness { get; set; } = 6;

        public Color ElapsedColor { get; set; } = Color.DeepSkyBlue;   // selected range (Normal)
        public Color RemainingColor { get; set; } = Color.Gray;
        public Color ThumbColor { get; set; } = Color.White;
        public Size ThumbSize { get; set; } = new Size(14, 14);
        public Color HighlightColor { get; set; } = Color.DodgerBlue;  // used for Hover/Pressed

        public int StartValue
        {
            get => startValue;
            set => SetRange(value, endValue, raiseEvent: true);
        }

        public int EndValue
        {
            get => endValue;
            set => SetRange(startValue, value, raiseEvent: true);
        }

        public FlatRangeSlider()
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
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle barRect = GetBarRect();

            int xStart = ValueToX(startValue, barRect);
            int xEnd = ValueToX(endValue, barRect);

            int leftX = Math.Min(xStart, xEnd);
            int rightX = Math.Max(xStart, xEnd);

            Rectangle selectedRect = new Rectangle(leftX, barRect.Top, Math.Max(0, rightX - leftX), barRect.Height);
            Rectangle remainingLeftRect = new Rectangle(barRect.Left, barRect.Top, Math.Max(0, leftX - barRect.Left), barRect.Height);
            Rectangle remainingRightRect = new Rectangle(rightX, barRect.Top, Math.Max(0, barRect.Right - rightX), barRect.Height);

            Color elapsedPaint = state switch
            {
                SliderVisualState.Hover => HighlightColor,
                SliderVisualState.Pressed => Blend(HighlightColor, Color.Black, 0.1f),
                _ => ElapsedColor
            };

            Color thumbPaint = state switch
            {
                SliderVisualState.Hover => HighlightColor,
                SliderVisualState.Pressed => Blend(HighlightColor, Color.Black, 0.1f),
                _ => ThumbColor
            };

            using (var remainingBrush = new SolidBrush(RemainingColor))
            using (var elapsedBrush = new SolidBrush(elapsedPaint))
            using (var thumbBrush = new SolidBrush(thumbPaint))
            {
                if (barRect.Width > 0 && barRect.Height > 0)
                    e.Graphics.FillRectangle(remainingBrush, remainingLeftRect);
                if (barRect.Width > 0 && barRect.Height > 0)
                    e.Graphics.FillRectangle(remainingBrush, remainingRightRect);

                if (selectedRect.Width > 0 && selectedRect.Height > 0)
                    e.Graphics.FillRectangle(elapsedBrush, selectedRect);

                Rectangle startThumbRect = GetThumbRect(xStart);
                Rectangle endThumbRect = GetThumbRect(xEnd);

                e.Graphics.FillEllipse(thumbBrush, startThumbRect);
                e.Graphics.FillEllipse(thumbBrush, endThumbRect);
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

            activeThumb = PickThumbForInteraction(e.X);
            SetActiveThumbFromMouse(e.X);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
                SetActiveThumbFromMouse(e.X);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (isDragging && e.Button == MouseButtons.Left)
            {
                isDragging = false;
                Capture = false;
                activeThumb = ThumbKind.None;
                state = ClientRectangle.Contains(e.Location) ? SliderVisualState.Hover : SliderVisualState.Normal;
                Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!Focused) Focus();

            int steps = e.Delta / SystemInformation.MouseWheelScrollDelta;
            if (steps == 0) return;

            // Keep your current behavior: wheel moves the nearer thumb.
            ThumbKind kind = PickThumbForInteraction(e.X);
            int delta = steps * SmallChange;

            if (kind == ThumbKind.Start) SetRange(startValue + delta, endValue, raiseEvent: true);
            else SetRange(startValue, endValue + delta, raiseEvent: true);
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

        private ThumbKind PickThumbForInteraction(int mouseX)
        {
            Rectangle barRect = GetBarRect();
            int xStart = ValueToX(startValue, barRect);
            int xEnd = ValueToX(endValue, barRect);

            // If clicked directly on a thumb, prefer that; otherwise nearest.
            if (GetThumbRect(xStart).Contains(mouseX, Height / 2)) return ThumbKind.Start;
            if (GetThumbRect(xEnd).Contains(mouseX, Height / 2)) return ThumbKind.End;

            return (Math.Abs(mouseX - xStart) <= Math.Abs(mouseX - xEnd)) ? ThumbKind.Start : ThumbKind.End;
        }

        private void SetActiveThumbFromMouse(int mouseX)
        {
            int v = XToValue(mouseX);

            if (activeThumb == ThumbKind.Start)
                SetRange(v, endValue, raiseEvent: true);
            else if (activeThumb == ThumbKind.End)
                SetRange(startValue, v, raiseEvent: true);
        }

        private void SetRange(int newStart, int newEnd, bool raiseEvent)
        {
            int oldStart = startValue;
            int oldEnd = endValue;

            newStart = Clamp(newStart, minimum, maximum);
            newEnd = Clamp(newEnd, minimum, maximum);

            if (newStart > newEnd)
            {
                int tmp = newStart;
                newStart = newEnd;
                newEnd = tmp;
            }

            int total = Math.Max(0, maximum - minimum);
            int effectiveMinRange = Math.Min(minimumRange, total);

            if (newEnd - newStart < effectiveMinRange)
            {
                if (activeThumb == ThumbKind.Start)
                {
                    newStart = Math.Min(newStart, maximum - effectiveMinRange);
                    newEnd = newStart + effectiveMinRange;
                }
                else if (activeThumb == ThumbKind.End)
                {
                    newEnd = Math.Max(newEnd, minimum + effectiveMinRange);
                    newStart = newEnd - effectiveMinRange;
                }
                else
                {
                    int desiredEnd = newStart + effectiveMinRange;
                    if (desiredEnd <= maximum) newEnd = desiredEnd;
                    else
                    {
                        newEnd = maximum;
                        newStart = maximum - effectiveMinRange;
                    }
                }
            }

            newStart = Clamp(newStart, minimum, maximum);
            newEnd = Clamp(newEnd, minimum, maximum);

            if (effectiveMinRange > 0 && newEnd - newStart < effectiveMinRange)
            {
                if (newStart + effectiveMinRange <= maximum) newEnd = newStart + effectiveMinRange;
                else if (newEnd - effectiveMinRange >= minimum) newStart = newEnd - effectiveMinRange;
            }

            startValue = newStart;
            endValue = newEnd;

            if (startValue != oldStart || endValue != oldEnd)
            {
                Invalidate();
                if (raiseEvent)
                    RangeChanged?.Invoke(this, new RangeChangedEventArgs(startValue, endValue));
            }
        }

        private void CoerceRange(bool raiseEvent) => SetRange(startValue, endValue, raiseEvent);

        private Rectangle GetBarRect()
        {
            int left = ThumbSize.Width / 2;
            int right = Width - ThumbSize.Width / 2;
            int barY = (Height - BarThickness) / 2;
            return new Rectangle(left, barY, Math.Max(0, right - left), BarThickness);
        }

        private Rectangle GetThumbRect(int centerX)
        {
            return new Rectangle(
                centerX - ThumbSize.Width / 2,
                (Height - ThumbSize.Height) / 2,
                ThumbSize.Width,
                ThumbSize.Height);
        }

        private int ValueToX(int v, Rectangle barRect)
        {
            if (maximum == minimum) return barRect.Left;

            float progress = (v - minimum) / (float)(maximum - minimum);
            return barRect.Left + (int)Math.Round(progress * barRect.Width);
        }

        private int XToValue(int x)
        {
            Rectangle barRect = GetBarRect();
            int usableWidth = Math.Max(1, barRect.Width);
            float ratio = (float)(x - barRect.Left) / usableWidth;
            int v = minimum + (int)Math.Round(ratio * (maximum - minimum));
            return Clamp(v, minimum, maximum);
        }

        private static int Clamp(int v, int min, int max) => Math.Max(min, Math.Min(max, v));

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

    public sealed class RangeChangedEventArgs : EventArgs
    {
        public int StartValue { get; }
        public int EndValue { get; }

        public RangeChangedEventArgs(int startValue, int endValue)
        {
            StartValue = startValue;
            EndValue = endValue;
        }
    }
}
