using Mpv.NET.Player;

namespace RandomVideoPlayer.Functions
{
    public static class ThreadHelper
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl">Target control</param>
        /// <param name="text">Text value</param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
        /// <summary>
        /// Set tooltip for various controls
        /// </summary>
        /// <param name="control">Target control to attach tooltip on</param>
        /// <param name="toolTip">tooltip control</param>
        /// <param name="text">Text value</param>
        public static void SetToolTipSafe(Control control, ToolTip toolTip, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => SetToolTipSafe(control, toolTip, text)));
            }
            else
            {
                toolTip.SetToolTip(control, text);
            }
        }

        /// <summary>
        /// Set tooltip for various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="button">Target control</param>
        /// <param name="visible">Visibility status</param>
        public static void SetVisibility(Form form, Button button, bool visible)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new Action(() => SetVisibility(form, button, visible)));
            }
            else
            {
                button.Visible = visible;
            }
        }
    }
}
