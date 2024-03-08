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
        /// <param name="form">The calling form</param>
        /// <param name="ctrl">Target control</param>
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
    }
}
