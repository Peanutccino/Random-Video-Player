
namespace RandomVideoPlayer.Controls
{
    public class CustomNumericUpDown : Control
    {
        private int _value;
        private int _minimum = 0;
        private int _maximum = 100;
        private TextBox textBox;

        public event EventHandler ValueChanged;

        public int Value
        {
            get => _value;
            set
            {
                if (value < _minimum || value > _maximum)
                    throw new ArgumentOutOfRangeException();

                if (_value != value)
                {
                    _value = value;
                    textBox.Text = _value.ToString();
                    Invalidate(); 
                    OnValueChanged(EventArgs.Empty); 
                }
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
            this.Size = new Size(100, 30);
            this.DoubleBuffered = true;

            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                TextAlign = HorizontalAlignment.Center,
                Location = new Point(20, 1),
                Width = this.Width - 65,
                Text = _value.ToString()
            };
            textBox.TextChanged += TextBox_TextChanged;
            textBox.KeyPress += TextBox_KeyPress;

            this.Controls.Add(textBox);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(SystemColors.Window);

            // Draw the left arrow
            Point[] leftArrow = {
            new Point(0, this.Height / 2),
            new Point(10, this.Height / 4),
            new Point(10, 3 * this.Height / 4)
        };
            e.Graphics.FillPolygon(Brushes.Indigo, leftArrow);

            // Draw the right arrow
            Point[] rightArrow = {
            new Point(this.Width, this.Height / 2),
            new Point(this.Width - 10, this.Height / 4),
            new Point(this.Width - 10, 3 * this.Height / 4)
        };
            e.Graphics.FillPolygon(Brushes.Indigo, rightArrow);
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
