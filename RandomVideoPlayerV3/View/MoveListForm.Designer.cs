namespace RandomVideoPlayer.View
{
    partial class MoveListForm
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
            panelTitle = new Panel();
            lblTitle = new Label();
            panelPlaceholder = new Panel();
            btnCloseForm = new FontAwesome.Sharp.IconButton();
            panelBody = new Panel();
            cbMoveFunscripts = new RandomVideoPlayer.Controls.CustomCheckBox();
            lblInfo = new Label();
            comboScriptDirectories = new RandomVideoPlayer.Controls.ButtonComboBox();
            btnFinish = new FontAwesome.Sharp.IconButton();
            btnStartCopyAction = new FontAwesome.Sharp.IconButton();
            pbMoveProgress = new FlatProgressBar();
            btnStartMoveAction = new FontAwesome.Sharp.IconButton();
            btnCancelMoveAction = new FontAwesome.Sharp.IconButton();
            btnBrowseFolder = new FontAwesome.Sharp.IconButton();
            tbDestinationPath = new TextBox();
            lblDestinationInfo = new Label();
            panelTitle.SuspendLayout();
            panelBody.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.PaleGreen;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(panelPlaceholder);
            panelTitle.Controls.Add(btnCloseForm);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(560, 20);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(26, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(508, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "RVP - Move list to directory";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseDown += lblTitle_MouseDown;
            // 
            // panelPlaceholder
            // 
            panelPlaceholder.Dock = DockStyle.Left;
            panelPlaceholder.Location = new Point(0, 0);
            panelPlaceholder.Name = "panelPlaceholder";
            panelPlaceholder.Size = new Size(26, 20);
            panelPlaceholder.TabIndex = 2;
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
            btnCloseForm.Location = new Point(534, 0);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(26, 20);
            btnCloseForm.TabIndex = 0;
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.MintCream;
            panelBody.Controls.Add(cbMoveFunscripts);
            panelBody.Controls.Add(lblInfo);
            panelBody.Controls.Add(comboScriptDirectories);
            panelBody.Controls.Add(btnFinish);
            panelBody.Controls.Add(btnStartCopyAction);
            panelBody.Controls.Add(pbMoveProgress);
            panelBody.Controls.Add(btnStartMoveAction);
            panelBody.Controls.Add(btnCancelMoveAction);
            panelBody.Controls.Add(btnBrowseFolder);
            panelBody.Controls.Add(tbDestinationPath);
            panelBody.Controls.Add(lblDestinationInfo);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 20);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(560, 147);
            panelBody.TabIndex = 1;
            // 
            // cbMoveFunscripts
            // 
            cbMoveFunscripts.BoxSize = 13;
            cbMoveFunscripts.Checked = true;
            cbMoveFunscripts.CheckState = CheckState.Checked;
            cbMoveFunscripts.HoverColor = Color.Blue;
            cbMoveFunscripts.Location = new Point(0, 80);
            cbMoveFunscripts.Name = "cbMoveFunscripts";
            cbMoveFunscripts.PaddingLeft = 6;
            cbMoveFunscripts.Size = new Size(559, 19);
            cbMoveFunscripts.TabIndex = 11;
            cbMoveFunscripts.Text = "Move .funscripts with the file or to specified directory";
            cbMoveFunscripts.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblInfo.Location = new Point(3, 108);
            lblInfo.Margin = new Padding(3, 6, 3, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Padding = new Padding(3, 0, 0, 0);
            lblInfo.Size = new Size(443, 15);
            lblInfo.TabIndex = 10;
            lblInfo.Text = "Moved with file when choosing 'local' or move scripts to specified script directory:";
            // 
            // comboScriptDirectories
            // 
            comboScriptDirectories.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboScriptDirectories.BackColor = Color.LightCyan;
            comboScriptDirectories.DrawMode = DrawMode.OwnerDrawFixed;
            comboScriptDirectories.DropDownStyle = ComboBoxStyle.DropDownList;
            comboScriptDirectories.FormattingEnabled = true;
            comboScriptDirectories.Location = new Point(3, 138);
            comboScriptDirectories.Name = "comboScriptDirectories";
            comboScriptDirectories.Size = new Size(553, 24);
            comboScriptDirectories.TabIndex = 8;
            // 
            // btnFinish
            // 
            btnFinish.BackColor = Color.GreenYellow;
            btnFinish.FlatAppearance.BorderSize = 0;
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFinish.IconChar = FontAwesome.Sharp.IconChar.None;
            btnFinish.IconColor = Color.Black;
            btnFinish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFinish.Location = new Point(456, 51);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(105, 23);
            btnFinish.TabIndex = 7;
            btnFinish.Text = "Finish";
            btnFinish.UseVisualStyleBackColor = false;
            btnFinish.Visible = false;
            btnFinish.Click += btnFinish_Click;
            // 
            // btnStartCopyAction
            // 
            btnStartCopyAction.FlatAppearance.BorderSize = 0;
            btnStartCopyAction.FlatStyle = FlatStyle.Flat;
            btnStartCopyAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnStartCopyAction.IconChar = FontAwesome.Sharp.IconChar.None;
            btnStartCopyAction.IconColor = Color.Black;
            btnStartCopyAction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStartCopyAction.Location = new Point(84, 51);
            btnStartCopyAction.Name = "btnStartCopyAction";
            btnStartCopyAction.Size = new Size(75, 23);
            btnStartCopyAction.TabIndex = 6;
            btnStartCopyAction.Text = "Copy files";
            btnStartCopyAction.UseVisualStyleBackColor = true;
            btnStartCopyAction.Click += btnStartCopyAction_Click;
            // 
            // pbMoveProgress
            // 
            pbMoveProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbMoveProgress.BorderColor = Color.ForestGreen;
            pbMoveProgress.BorderThickness = 1;
            pbMoveProgress.CompletedBrush = Color.PaleGreen;
            pbMoveProgress.CompletedGraphBrush = Color.White;
            pbMoveProgress.ForeColor = Color.MintCream;
            pbMoveProgress.GraphThickness = 1;
            pbMoveProgress.Location = new Point(3, 168);
            pbMoveProgress.Maximum = 100;
            pbMoveProgress.Minimum = 0;
            pbMoveProgress.MouseoverBrush = Color.PaleGreen;
            pbMoveProgress.Name = "pbMoveProgress";
            pbMoveProgress.RemainingBrush = Color.MintCream;
            pbMoveProgress.RemainingGraphBrush = Color.Black;
            pbMoveProgress.ShowBorder = false;
            pbMoveProgress.Size = new Size(554, 24);
            pbMoveProgress.TabIndex = 5;
            pbMoveProgress.Text = "flatProgressBar1";
            pbMoveProgress.Value = 0;
            // 
            // btnStartMoveAction
            // 
            btnStartMoveAction.FlatAppearance.BorderSize = 0;
            btnStartMoveAction.FlatStyle = FlatStyle.Flat;
            btnStartMoveAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnStartMoveAction.IconChar = FontAwesome.Sharp.IconChar.None;
            btnStartMoveAction.IconColor = Color.Black;
            btnStartMoveAction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStartMoveAction.Location = new Point(3, 51);
            btnStartMoveAction.Name = "btnStartMoveAction";
            btnStartMoveAction.Size = new Size(75, 23);
            btnStartMoveAction.TabIndex = 4;
            btnStartMoveAction.Text = "Move files";
            btnStartMoveAction.UseVisualStyleBackColor = true;
            btnStartMoveAction.Click += btnStartMoveAction_Click;
            // 
            // btnCancelMoveAction
            // 
            btnCancelMoveAction.BackColor = Color.MistyRose;
            btnCancelMoveAction.FlatAppearance.BorderSize = 0;
            btnCancelMoveAction.FlatStyle = FlatStyle.Flat;
            btnCancelMoveAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCancelMoveAction.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancelMoveAction.IconColor = Color.Black;
            btnCancelMoveAction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelMoveAction.Location = new Point(375, 51);
            btnCancelMoveAction.Name = "btnCancelMoveAction";
            btnCancelMoveAction.Size = new Size(75, 23);
            btnCancelMoveAction.TabIndex = 3;
            btnCancelMoveAction.Text = "Cancel";
            btnCancelMoveAction.UseVisualStyleBackColor = false;
            btnCancelMoveAction.Visible = false;
            btnCancelMoveAction.Click += btnCancelMoveAction_Click;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.FlatAppearance.BorderSize = 0;
            btnBrowseFolder.FlatStyle = FlatStyle.Flat;
            btnBrowseFolder.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnBrowseFolder.IconColor = Color.Black;
            btnBrowseFolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBrowseFolder.IconSize = 28;
            btnBrowseFolder.Location = new Point(524, 24);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(32, 23);
            btnBrowseFolder.TabIndex = 2;
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // tbDestinationPath
            // 
            tbDestinationPath.BorderStyle = BorderStyle.FixedSingle;
            tbDestinationPath.Location = new Point(3, 24);
            tbDestinationPath.Name = "tbDestinationPath";
            tbDestinationPath.ReadOnly = true;
            tbDestinationPath.Size = new Size(515, 23);
            tbDestinationPath.TabIndex = 0;
            // 
            // lblDestinationInfo
            // 
            lblDestinationInfo.AutoSize = true;
            lblDestinationInfo.Dock = DockStyle.Top;
            lblDestinationInfo.Location = new Point(0, 0);
            lblDestinationInfo.Name = "lblDestinationInfo";
            lblDestinationInfo.Padding = new Padding(3);
            lblDestinationInfo.Size = new Size(159, 21);
            lblDestinationInfo.TabIndex = 1;
            lblDestinationInfo.Text = "Select destination directory:";
            // 
            // MoveListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 167);
            Controls.Add(panelBody);
            Controls.Add(panelTitle);
            MaximumSize = new Size(576, 206);
            MinimumSize = new Size(576, 206);
            Name = "MoveListForm";
            Text = "MoveListForm";
            Load += MoveListForm_Load;
            panelTitle.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTitle;
        private FontAwesome.Sharp.IconButton btnCloseForm;
        private Label lblTitle;
        private Panel panelBody;
        private Panel panelPlaceholder;
        private FlatProgressBar pbMoveProgress;
        private FontAwesome.Sharp.IconButton btnStartMoveAction;
        private FontAwesome.Sharp.IconButton btnCancelMoveAction;
        private FontAwesome.Sharp.IconButton btnBrowseFolder;
        private Label lblDestinationInfo;
        private TextBox tbDestinationPath;
        private FontAwesome.Sharp.IconButton btnStartCopyAction;
        private FontAwesome.Sharp.IconButton btnFinish;
        private Controls.ButtonComboBox comboScriptDirectories;
        private Label lblInfo;
        private Controls.CustomCheckBox cbMoveFunscripts;
    }
}