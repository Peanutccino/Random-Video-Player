namespace RandomVideoPlayer.Views
{
    partial class HotkeyEditForm
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
            lblAction = new Label();
            lblSelectedKey = new Label();
            panelBody = new Panel();
            btnOK = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            lblInfo = new Label();
            panelBody.SuspendLayout();
            SuspendLayout();
            // 
            // lblAction
            // 
            lblAction.Dock = DockStyle.Top;
            lblAction.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblAction.ForeColor = Color.Indigo;
            lblAction.Location = new Point(0, 65);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(263, 58);
            lblAction.TabIndex = 2;
            lblAction.Text = "Hotkey Action";
            lblAction.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSelectedKey
            // 
            lblSelectedKey.Dock = DockStyle.Top;
            lblSelectedKey.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectedKey.ForeColor = Color.Indigo;
            lblSelectedKey.Location = new Point(0, 123);
            lblSelectedKey.Name = "lblSelectedKey";
            lblSelectedKey.Size = new Size(263, 54);
            lblSelectedKey.TabIndex = 1;
            lblSelectedKey.Text = "----";
            lblSelectedKey.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.FromArgb(179, 179, 255);
            panelBody.Controls.Add(btnOK);
            panelBody.Controls.Add(btnCancel);
            panelBody.Controls.Add(lblSelectedKey);
            panelBody.Controls.Add(lblAction);
            panelBody.Controls.Add(lblInfo);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 0);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(263, 216);
            panelBody.TabIndex = 3;
            panelBody.MouseDown += panel1_MouseDown;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOK.BackColor = Color.FromArgb(153, 153, 255);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnOK.IconChar = FontAwesome.Sharp.IconChar.None;
            btnOK.IconColor = Color.Black;
            btnOK.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnOK.IconSize = 34;
            btnOK.ImageAlign = ContentAlignment.MiddleRight;
            btnOK.Location = new Point(3, 171);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(112, 42);
            btnOK.TabIndex = 2;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(153, 153, 255);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 34;
            btnCancel.ImageAlign = ContentAlignment.MiddleRight;
            btnCancel.Location = new Point(148, 171);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 42);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblInfo
            // 
            lblInfo.Dock = DockStyle.Top;
            lblInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(263, 65);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Press a Key or Modifier + Key and Confirm";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.MouseDown += label1_MouseDown;
            // 
            // HotkeyEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 216);
            Controls.Add(panelBody);
            KeyPreview = true;
            MinimumSize = new Size(279, 255);
            Name = "HotkeyEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotkeyEditForm";
            Resize += HotkeyEditForm_Resize;
            panelBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblAction;
        private Label lblSelectedKey;
        private Panel panelBody;
        private FontAwesome.Sharp.IconButton btnOK;
        private Label lblInfo;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}