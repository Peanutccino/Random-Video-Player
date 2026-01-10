namespace RandomVideoPlayer.Views
{
    partial class MoveFilePathSelectorView
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
            panelTitleBar = new Panel();
            lblTitle = new Label();
            btnCloseForm = new FontAwesome.Sharp.IconButton();
            panelMain = new Panel();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnSavePath = new FontAwesome.Sharp.IconButton();
            tbDestinationPath = new TextBox();
            lblDestInfo = new Label();
            btnBrowseFolder = new FontAwesome.Sharp.IconButton();
            panelTitleBar.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.PaleGreen;
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Controls.Add(btnCloseForm);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(484, 20);
            panelTitleBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(458, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "RVP - Move/Copy File to directory";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseDown += lblTitle_MouseDown;
            // 
            // btnCloseForm
            // 
            btnCloseForm.Dock = DockStyle.Right;
            btnCloseForm.FlatAppearance.BorderSize = 0;
            btnCloseForm.FlatAppearance.MouseOverBackColor = Color.Red;
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            btnCloseForm.IconColor = Color.Black;
            btnCloseForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCloseForm.IconSize = 15;
            btnCloseForm.Location = new Point(458, 0);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(26, 20);
            btnCloseForm.TabIndex = 1;
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Honeydew;
            panelMain.Controls.Add(btnCancel);
            panelMain.Controls.Add(btnSavePath);
            panelMain.Controls.Add(tbDestinationPath);
            panelMain.Controls.Add(lblDestInfo);
            panelMain.Controls.Add(btnBrowseFolder);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 20);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(484, 102);
            panelMain.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.MistyRose;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.Location = new Point(12, 64);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 26);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSavePath
            // 
            btnSavePath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSavePath.BackColor = Color.PaleGreen;
            btnSavePath.FlatAppearance.BorderSize = 0;
            btnSavePath.FlatStyle = FlatStyle.Flat;
            btnSavePath.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSavePath.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSavePath.IconColor = Color.Black;
            btnSavePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSavePath.Location = new Point(332, 64);
            btnSavePath.Name = "btnSavePath";
            btnSavePath.Size = new Size(140, 26);
            btnSavePath.TabIndex = 8;
            btnSavePath.Text = "Use this path";
            btnSavePath.UseVisualStyleBackColor = false;
            btnSavePath.Click += btnSavePath_Click;
            // 
            // tbDestinationPath
            // 
            tbDestinationPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDestinationPath.BorderStyle = BorderStyle.FixedSingle;
            tbDestinationPath.Location = new Point(3, 26);
            tbDestinationPath.Name = "tbDestinationPath";
            tbDestinationPath.ReadOnly = true;
            tbDestinationPath.Size = new Size(426, 23);
            tbDestinationPath.TabIndex = 5;
            // 
            // lblDestInfo
            // 
            lblDestInfo.Dock = DockStyle.Top;
            lblDestInfo.Location = new Point(0, 0);
            lblDestInfo.Name = "lblDestInfo";
            lblDestInfo.Size = new Size(484, 23);
            lblDestInfo.TabIndex = 4;
            lblDestInfo.Text = "Select destination directory:";
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFolder.FlatAppearance.BorderSize = 0;
            btnBrowseFolder.FlatStyle = FlatStyle.Flat;
            btnBrowseFolder.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnBrowseFolder.IconColor = Color.Black;
            btnBrowseFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBrowseFolder.IconSize = 28;
            btnBrowseFolder.Location = new Point(435, 26);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(37, 23);
            btnBrowseFolder.TabIndex = 3;
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // MoveFilePathSelectorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 122);
            Controls.Add(panelMain);
            Controls.Add(panelTitleBar);
            MinimumSize = new Size(500, 120);
            Name = "MoveFilePathSelectorView";
            Text = "MoveFilePathSelectorView";
            Load += MoveFilePathSelectorView_Load;
            Resize += MoveFilePathSelectorView_Resize;
            panelTitleBar.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTitleBar;
        private FontAwesome.Sharp.IconButton btnCloseForm;
        private Label lblTitle;
        private Panel panelMain;
        private FontAwesome.Sharp.IconButton btnBrowseFolder;
        private Label lblDestInfo;
        private TextBox tbDestinationPath;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnSavePath;
    }
}