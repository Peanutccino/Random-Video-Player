
namespace RandomVideoPlayer.View
{
    public partial class CustomMessageBoxView : Form
    {
        public bool CheckboxChecked { get; private set; }
        public DialogResult Result { get; private set; }

        public CustomMessageBoxView(string title, string message, string checkboxText, bool checkboxDefaultState)
        {
            InitializeComponent();

            this.Text = title;
            lblInfoText.Text = message;
            cbOption.Text = checkboxText;
            cbOption.Checked = checkboxDefaultState;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            CheckboxChecked = cbOption.Checked;
            Result = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            CheckboxChecked = cbOption.Checked;
            Result = DialogResult.No;
            this.Close();
        }
    }

}
