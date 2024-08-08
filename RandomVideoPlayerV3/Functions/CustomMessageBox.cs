using RandomVideoPlayer.View;

namespace RandomVideoPlayer.Functions
{
    public static class CustomMessageBox
    {
        public static (DialogResult result, bool isChecked) Show(string title, string message, string checkboxText, bool checkboxDefaultState)
        {
            using (var form = new CustomMessageBoxView(title, message, checkboxText, checkboxDefaultState))
            {
                form.ShowDialog();
                return (form.Result, form.CheckboxChecked);
            }
        }
    }
}
