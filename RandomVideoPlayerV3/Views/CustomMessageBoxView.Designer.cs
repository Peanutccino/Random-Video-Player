namespace RandomVideoPlayer.Views
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
            lblInfoText = new Label();
            cbOption = new Controls.CustomCheckBox();
            panelBody = new Panel();
            panelBody.SuspendLayout();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnYes.BackColor = SystemColors.GradientInactiveCaption;
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnYes.IconChar = FontAwesome.Sharp.IconChar.None;
            btnYes.IconColor = Color.Black;
            btnYes.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnYes.IconSize = 40;
            btnYes.ImageAlign = ContentAlignment.MiddleRight;
            btnYes.Location = new Point(3, 78);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(145, 40);
            btnYes.TabIndex = 0;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNo.BackColor = SystemColors.GradientInactiveCaption;
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNo.IconChar = FontAwesome.Sharp.IconChar.None;
            btnNo.IconColor = Color.Black;
            btnNo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNo.Location = new Point(216, 78);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(145, 40);
            btnNo.TabIndex = 1;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // lblInfoText
            // 
            lblInfoText.Dock = DockStyle.Top;
            lblInfoText.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfoText.Location = new Point(0, 0);
            lblInfoText.Name = "lblInfoText";
            lblInfoText.Padding = new Padding(15, 12, 10, 0);
            lblInfoText.Size = new Size(364, 58);
            lblInfoText.TabIndex = 3;
            lblInfoText.Text = "You're about to play from the file's current directory, should I also include all subdirectories?";
            lblInfoText.MouseDown += lblInfoText_MouseDown;
            // 
            // cbOption
            // 
            cbOption.AutoSize = true;
            cbOption.BoxSize = 13;
            cbOption.Checked = true;
            cbOption.CheckState = CheckState.Checked;
            cbOption.Dock = DockStyle.Top;
            cbOption.HoverColor = Color.Blue;
            cbOption.Location = new Point(0, 58);
            cbOption.Name = "cbOption";
            cbOption.PaddingLeft = 12;
            cbOption.Size = new Size(364, 19);
            cbOption.TabIndex = 4;
            cbOption.Text = "Always ask (Can change in settings)";
            cbOption.UseVisualStyleBackColor = true;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.AliceBlue;
            panelBody.Controls.Add(btnNo);
            panelBody.Controls.Add(cbOption);
            panelBody.Controls.Add(btnYes);
            panelBody.Controls.Add(lblInfoText);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 0);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(364, 121);
            panelBody.TabIndex = 5;
            // 
            // CustomMessageBoxView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepSkyBlue;
            ClientSize = new Size(364, 121);
            Controls.Add(panelBody);
            MinimumSize = new Size(380, 160);
            Name = "CustomMessageBoxView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomMessageBox";
            Resize += CustomMessageBoxView_Resize;
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnYes;
        private FontAwesome.Sharp.IconButton btnNo;
        private Label lblInfoText;
        private Controls.CustomCheckBox cbOption;
        private Panel panelBody;
    }
}