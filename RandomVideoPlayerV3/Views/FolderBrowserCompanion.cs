using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomVideoPlayer.Views
{
    public partial class FolderBrowserCompanion : Form
    {
        public event EventHandler<string>? DeleteFolderRequested;
        public event EventHandler? DeleteAllRequested;

        private Color _textColor = Color.Black;
        private Color _textColorAccent = Color.Black;
        private Color _backColorLight = Color.White;
        private Color _backColorDark = Color.Gray;
        private Color _accentColor = Color.Pink;
        private Color _highlightColor = Color.OrangeRed;

        public FolderBrowserCompanion()
        {
            InitializeComponent();

            InitializeUI();
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAllRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetFolders(IEnumerable<string> folders)
        {
            flowFolderList.SuspendLayout();
            flowFolderList.Controls.Clear();

            foreach (string folder in folders)
            {
                Control item = CreateFolderItem(folder);
                flowFolderList.Controls.Add(item);
            }
            flowFolderList.ResumeLayout();

            bool vScroll = flowFolderList.VerticalScroll.Visible;
            flowFolderList.Padding = vScroll ? new Padding(5, 10, 0, 10) : new Padding(15, 10, 0, 10);
        }

        private Control CreateFolderItem(string folderPath)
        {
            bool vScroll = flowFolderList.VerticalScroll.Visible;

            var button = new RoundedButton
            {
                Text = Path.GetFileName(folderPath),
                Tag = folderPath,
                AutoEllipsis = true,
                Margin = new Padding(0, 5, 0, 8),
                Height = 32,
                Width = btnDeleteAll.Width - 30,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(5, 0, 5, 0),
                BackColor = _accentColor,
                ForeColor = _textColorAccent,
                BackgroundColor = _backColorLight,
                Font = new Font("Segoe UI Semibold", 9 / DPI.Scale, FontStyle.Bold)
            };

            ApplyIcon(button, SVGTemplates.DeleteLeftIcon, _textColorAccent, _textColorAccent);

            button.Click += (s, e) =>
            {
                DeleteFolderRequested?.Invoke(this, folderPath);
            };

            return button;
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeFBV2(this);

            _textColor = ThemeManager.CurrentTheme.FbTextColor;
            _textColorAccent = ThemeManager.CurrentTheme.FbTextColorAccent;
            _backColorLight = ThemeManager.CurrentTheme.FbBackColorLight;
            _backColorDark = ThemeManager.CurrentTheme.FbBackColorDark;
            _accentColor = ThemeManager.CurrentTheme.FbAccentColor;
            _highlightColor = ThemeManager.CurrentTheme.FbHighlightColor;

            ApplyIcon(btnDeleteAll, SVGTemplates.TrashIcon, Color.Black, _textColorAccent);

            tableBackground.BackColor = _accentColor;
            flowFolderList.BackColor = _backColorDark;

            DPI.UpdateDPIScaling(this);
        }

        private void ApplyIcon(Button target, string template, Color main, Color accent, int width = 20, int height = 20)
        {
            try
            {
                var svgMarkup = template
                    .Replace("{{main}}", ColorTranslator.ToHtml(main))
                    .Replace("{{accent}}", ColorTranslator.ToHtml(accent));

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svgMarkup));
                var svgDoc = SvgDocument.Open<SvgDocument>(stream); // SVG.NET
                using var bmp = svgDoc.Draw(width, height);

                target.Font = new Font("Segoe UI Semibold", 10 / DPI.Scale, FontStyle.Bold);
                target.Image?.Dispose();
                target.Image = (Bitmap)bmp.Clone();
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Failed to render SVG icon for button", LogLevel.Error);
                target.Image = SystemIcons.Warning.ToBitmap();
            }


        }
    }
}
