using FontAwesome.Sharp;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Views
{
    public enum RVPMessageBoxButtons
    {
        Ok,
        YesNo
    }

    public class RVPMessageBox : Form
    {
        private IconPictureBox iconBox;
        private Label lblTitle;
        private Label lblMessage;
        private CheckBox chkOption;
        private FlowLayoutPanel buttonPanel;

        private Color _textColor;
        private Color _backColorLight;
        private Color _backColorDark;
        private Color _accentColor;
        private Color _textColorAccent;
        private Color _highlightColor;

        public bool IsChecked => chkOption.Checked;

        private RVPMessageBox(string message, string title, RVPMessageBoxButtons buttons, IconChar icon, string checkBoxText)
        {
            _textColor = ThemeManager.CurrentTheme.FbTextColor;
            _backColorLight = ThemeManager.CurrentTheme.FbBackColorLight;
            _backColorDark = ThemeManager.CurrentTheme.FbBackColorDark;
            _accentColor = ThemeManager.CurrentTheme.FbAccentColor;
            _textColorAccent = ThemeManager.CurrentTheme.FbTextColorAccent;
            _highlightColor = ThemeManager.CurrentTheme.FbHighlightColor;

            InitializeLayout(message, title, buttons, icon, checkBoxText);

            DPI.UpdateDPIScaling(this);
        }

        private void InitializeLayout(string message, string title, RVPMessageBoxButtons buttons, IconChar icon, string checkBoxText)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = _backColorDark; 
            ForeColor = _textColor;
            Padding = new Padding(1); 
            Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, ClientRectangle, _accentColor, ButtonBorderStyle.Solid);

            bool hasIcon = icon != IconChar.None;

            const int rightMargin = 20;
            const int topMargin = 10;
            const int formWidth = 420;
            int leftMargin = hasIcon ? 85 : 20;
            int contentWidth = formWidth - leftMargin - rightMargin;

            int iconBottom = 0;
            if (hasIcon)
            {
                iconBox = new IconPictureBox
                {
                    IconChar = icon,
                    IconColor = _highlightColor,
                    IconSize = 48,
                    Size = new Size(48, 48),
                    Location = new Point(20, 25),
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.CenterImage
                };
                Controls.Add(iconBox);
                iconBottom = iconBox.Bottom;
            }

            lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11f / DPI.Scale, FontStyle.Bold),
                ForeColor = _textColor,
                AutoSize = true,
                Location = new Point(leftMargin, topMargin)
            };
            lblTitle.MouseDown += DragOnMouseDown;
            Controls.Add(lblTitle);

            lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 9.5f / DPI.Scale),
                ForeColor = _textColor,
                Location = new Point(leftMargin, lblTitle.Bottom + 10),
                MaximumSize = new Size(contentWidth, 0),   
                AutoSize = true
            };
            lblMessage.MouseDown += DragOnMouseDown;
            Controls.Add(lblMessage);

            int currentY = lblMessage.Bottom + 15;

            bool showCheck = buttons == RVPMessageBoxButtons.YesNo && !string.IsNullOrWhiteSpace(checkBoxText);
            chkOption = new CustomCheckBox
            {
                Text = checkBoxText ?? "",
                ForeColor = _textColor,
                HoverColor = _highlightColor,
                AutoSize = true,
                MaximumSize = new Size(contentWidth, 0),
                Location = new Point(leftMargin, currentY),
                Visible = showCheck,
                Checked = true
            };
            Controls.Add(chkOption);

            if (showCheck)
                currentY = chkOption.Bottom + 15;

            buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(0, 8, 12, 0),
                BackColor = _backColorLight
            };
            Controls.Add(buttonPanel);

            if (buttons == RVPMessageBoxButtons.Ok)
            {
                buttonPanel.Controls.Add(CreateButton("OK", DialogResult.OK));
            }
            else // YesNo
            {
                buttonPanel.Controls.Add(CreateButton("No", DialogResult.No));
                buttonPanel.Controls.Add(CreateButton("Yes", DialogResult.Yes));
            }

            int contentBottom = Math.Max(currentY, iconBottom == 0 ? 0 : iconBottom + 15);
            ClientSize = new Size(formWidth, contentBottom + buttonPanel.Height);
            this.MouseDown += DragOnMouseDown;
        }

        private Button CreateButton(string text, DialogResult result)
        {
            var btn = new Button
            {
                Text = text,
                DialogResult = result,
                Size = new Size(90, 32),
                Font = new Font("Segoe UI Semibold", 10f / DPI.Scale, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                ForeColor = _textColorAccent,
                BackColor = _accentColor,
                Margin = new Padding(10, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => { DialogResult = result; Close(); };
            return btn;
        }

        public static DialogResult Show(string message, string title = "", IconChar icon = IconChar.None)
        {
            using var box = new RVPMessageBox(message, title,
                RVPMessageBoxButtons.Ok, icon, null);
            return box.ShowDialog();
        }

        public static DialogResult ShowYesNo(string message, string title = "", IconChar icon = IconChar.None)
        {
            using var box = new RVPMessageBox(message, title,
                RVPMessageBoxButtons.YesNo, icon, null);
            return box.ShowDialog();
        }

        public static DialogResult ShowYesNo(string message, string title, string checkBoxText, out bool isChecked, IconChar icon = IconChar.None)
        {
            using var box = new RVPMessageBox(message, title,
                RVPMessageBoxButtons.YesNo, icon, checkBoxText);
            var result = box.ShowDialog();
            isChecked = box.IsChecked;
            return result;
        }

        private void DragOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
