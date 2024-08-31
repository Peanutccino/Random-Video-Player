using System.Drawing.Text;

namespace RandomVideoPlayer.Controls
{
    public class ButtonComboBox : ComboBox
    {
        private Dictionary<string, Font> fontDictionary;
        public ButtonComboBox()
        {
            SetStyle(ControlStyles.UserPaint, true);
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;

            fontDictionary = new Dictionary<string, Font>();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x00200000; // CBS_HASSTRINGS
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            string selectedText = Text;
            Font selectedFont = Font;

            if (fontDictionary.ContainsKey(selectedText))
            {
                selectedFont = fontDictionary[selectedText];
            }

            TextRenderer.DrawText(e.Graphics, selectedText, selectedFont, ClientRectangle, ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            if (Items.Count > 0)
            {
                string text = Items[e.Index].ToString();
                Font itemFont = Font;

                if (fontDictionary.ContainsKey(text))
                {
                    itemFont = fontDictionary[text];
                }

                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(text, itemFont, brush, e.Bounds);
                }
            }

            base.OnDrawItem(e);
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }

        public void SetFontTypes(List<string> fontTypes)
        {
            fontDictionary.Clear();
            foreach (var fontName in fontTypes)
            {
                try
                {

                    Font font = new Font(fontName, this.Font.Size);
                    fontDictionary[fontName] = font;
                }
                catch
                {
                   
                }
            }

            this.DataSource = fontTypes;
        }

        public void LoadAllAvailableFonts()
        {
            fontDictionary.Clear();

            InstalledFontCollection installedFonts = new InstalledFontCollection();
            List<string> fontNames = new List<string>();

            foreach (FontFamily fontFamily in installedFonts.Families)
            {
                string fontName = fontFamily.Name;
                fontNames.Add(fontName);

                try
                {
                    Font font = new Font(fontName, this.Font.Size);
                    fontDictionary[fontName] = font;
                }
                catch
                {

                }
            }

            this.DataSource = fontNames;
        }
    }
}
