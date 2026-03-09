
using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Controls
{
    public class CustomNumericUpDown : Control
    {
        private int _value;
        private int _minimum = 0;
        private int _maximum = 100;
        private Color _iconColor = Color.Indigo;
        private TextBox textBox;

        public event EventHandler ValueChanged;
        public Color IconColor
        {
            get => _iconColor;
            set
            {
                if (_iconColor == value)
                    return;

                _iconColor = value;
                Invalidate();
            }
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                if (base.BackColor == value)
                    return;

                base.BackColor = value;
                SyncTextBoxColors();
                Invalidate();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                if (base.ForeColor == value)
                    return;

                base.ForeColor = value;
                SyncTextBoxColors();
            }
        }
        public int Value
        {
            get => _value;
            set
            {
                var clamped = Math.Clamp(value, _minimum, _maximum);

                if (_value == clamped)
                    return;


                _value = clamped;
                textBox.Text = _value.ToString();
                Invalidate();
                OnValueChanged(EventArgs.Empty);

            }
        }

        public int Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                if (_value < _minimum)
                    _value = _minimum;
                textBox.Text = _value.ToString();
                Invalidate();
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                if (_value > _maximum)
                    _value = _maximum;
                textBox.Text = _value.ToString();
                Invalidate();
            }
        }

        public CustomNumericUpDown()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);

            Size = new Size(100, 30);
            DoubleBuffered = true;
            base.BackColor = SystemColors.Window;
            base.ForeColor = SystemColors.WindowText;

            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                TextAlign = HorizontalAlignment.Center,
                Location = new Point(DPI.GetDivided(20), 1),
                Width = DPI.GetDivided(Width - 65),
                BackColor = BackColor,
                Text = _value.ToString()
            };
            textBox.TextChanged += TextBox_TextChanged;
            textBox.KeyPress += TextBox_KeyPress;

            Controls.Add(textBox);
            SyncTextBoxColors();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox.Text, out int newValue))
            {
                if (newValue >= _minimum && newValue <= _maximum)
                {
                    _value = newValue;
                    Invalidate(); 
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, backspace, and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            SyncTextBoxColors();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            SyncTextBoxColors();
        }

        private void SyncTextBoxColors()
        {
            if (textBox == null)
                return;

            textBox.BackColor = BackColor;
            textBox.ForeColor = ForeColor;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var backBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(backBrush, ClientRectangle);
            }

            using (var iconBrush = new SolidBrush(IconColor))
            {
                Point[] leftArrow =
                {
                new Point(0, Height / 2),
                new Point(10, Height / 4),
                new Point(10, 3 * Height / 4)
            };
                e.Graphics.FillPolygon(iconBrush, leftArrow);

                Point[] rightArrow =
                {
                new Point(Width, Height / 2),
                new Point(Width - 10, Height / 4),
                new Point(Width - 10, 3 * Height / 4)
            };
                e.Graphics.FillPolygon(iconBrush, rightArrow);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.X < 20) // Click on the left arrow
            {
                if (_value > _minimum)
                {
                    Value--;
                }
            }
            else if (e.X > this.Width - 20) // Click on the right arrow
            {
                if (_value < _maximum)
                {
                    Value++;
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta > 0) // Scroll up
            {
                if (_value < _maximum)
                {
                    Value++;
                }
            }
            else if (e.Delta < 0) // Scroll down
            {
                if (_value > _minimum)
                {
                    Value--;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
