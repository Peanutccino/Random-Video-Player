namespace RandomVideoPlayer.View
{
    partial class CustomMessageBoxView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnYes = new FontAwesome.Sharp.IconButton();
            btnNo = new FontAwesome.Sharp.IconButton();
            cbOption = new CheckBox();
            lblInfoText = new Label();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.BackColor = Color.AliceBlue;
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnYes.IconChar = FontAwesome.Sharp.IconChar.None;
            btnYes.IconColor = Color.Black;
            btnYes.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnYes.IconSize = 40;
            btnYes.ImageAlign = ContentAlignment.MiddleRight;
            btnYes.Location = new Point(12, 89);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(145, 60);
            btnYes.TabIndex = 0;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.BackColor = Color.AliceBlue;
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNo.IconChar = FontAwesome.Sharp.IconChar.None;
            btnNo.IconColor = Color.Black;
            btnNo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNo.Location = new Point(207, 89);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(145, 60);
            btnNo.TabIndex = 1;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // cbOption
            // 
            cbOption.AutoSize = true;
            cbOption.Location = new Point(12, 64);
            cbOption.Name = "cbOption";
            cbOption.Size = new Size(214, 19);
            cbOption.TabIndex = 2;
            cbOption.Text = "Always ask (Can change in settings)";
            cbOption.UseVisualStyleBackColor = true;
            // 
            // lblInfoText
            // 
            lblInfoText.Dock = DockStyle.Top;
            lblInfoText.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblInfoText.Location = new Point(0, 0);
            lblInfoText.Name = "lblInfoText";
            lblInfoText.Padding = new Padding(15, 6, 10, 0);
            lblInfoText.Size = new Size(364, 61);
            lblInfoText.TabIndex = 3;
            lblInfoText.Text = "You're about to play from the file's current directory, should I also include all subdirectories?";
            // 
            // CustomMessageBoxView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(364, 161);
            Controls.Add(lblInfoText);
            Controls.Add(cbOption);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CustomMessageBoxView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomMessageBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnYes;
        private FontAwesome.Sharp.IconButton btnNo;
        private CheckBox cbOption;
        private Label lblInfoText;
    }
}