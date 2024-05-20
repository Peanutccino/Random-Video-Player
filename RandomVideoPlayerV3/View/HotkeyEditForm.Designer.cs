namespace RandomVideoPlayer.View
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
            panel1 = new Panel();
            btnOK = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panel1.SuspendLayout();
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(179, 179, 255);
            panel1.Controls.Add(btnOK);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(lblSelectedKey);
            panel1.Controls.Add(lblAction);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 216);
            panel1.TabIndex = 3;
            panel1.MouseDown += panel1_MouseDown;
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
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(263, 65);
            label1.TabIndex = 1;
            label1.Text = "Press a Key or Modifier + Key and Confirm";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseDown += label1_MouseDown;
            // 
            // HotkeyEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 216);
            Controls.Add(panel1);
            KeyPreview = true;
            Name = "HotkeyEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotkeyEditForm";
            Resize += HotkeyEditForm_Resize;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblAction;
        private Label lblSelectedKey;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnOK;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}