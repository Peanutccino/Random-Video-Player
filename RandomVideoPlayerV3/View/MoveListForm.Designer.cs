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
            panel2 = new Panel();
            btnCloseForm = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            btnFinish = new FontAwesome.Sharp.IconButton();
            btnStartCopyAction = new FontAwesome.Sharp.IconButton();
            pbMoveProgress = new FlatProgressBar();
            btnStartMoveAction = new FontAwesome.Sharp.IconButton();
            btnCancelMoveAction = new FontAwesome.Sharp.IconButton();
            btnBrowseFolder = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            tbDestinationPath = new TextBox();
            panelTitle.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.PaleGreen;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(panel2);
            panelTitle.Controls.Add(btnCloseForm);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(564, 20);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(26, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(512, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "RVP - Move list to directory";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseDown += lblTitle_MouseDown;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(26, 20);
            panel2.TabIndex = 2;
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
            btnCloseForm.Location = new Point(538, 0);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(26, 20);
            btnCloseForm.TabIndex = 0;
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MintCream;
            panel1.Controls.Add(btnFinish);
            panel1.Controls.Add(btnStartCopyAction);
            panel1.Controls.Add(pbMoveProgress);
            panel1.Controls.Add(btnStartMoveAction);
            panel1.Controls.Add(btnCancelMoveAction);
            panel1.Controls.Add(btnBrowseFolder);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tbDestinationPath);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(564, 66);
            panel1.TabIndex = 1;
            // 
            // btnFinish
            // 
            btnFinish.BackColor = Color.GreenYellow;
            btnFinish.FlatAppearance.BorderSize = 0;
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnStartCopyAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartCopyAction.IconChar = FontAwesome.Sharp.IconChar.None;
            btnStartCopyAction.IconColor = Color.Black;
            btnStartCopyAction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStartCopyAction.Location = new Point(98, 51);
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
            pbMoveProgress.Location = new Point(3, 80);
            pbMoveProgress.Maximum = 100;
            pbMoveProgress.Minimum = 0;
            pbMoveProgress.MouseoverBrush = Color.PaleGreen;
            pbMoveProgress.Name = "pbMoveProgress";
            pbMoveProgress.RemainingBrush = Color.MintCream;
            pbMoveProgress.RemainingGraphBrush = Color.Black;
            pbMoveProgress.ShowBorder = false;
            pbMoveProgress.Size = new Size(558, 18);
            pbMoveProgress.TabIndex = 5;
            pbMoveProgress.Text = "flatProgressBar1";
            pbMoveProgress.Value = 0;
            // 
            // btnStartMoveAction
            // 
            btnStartMoveAction.FlatAppearance.BorderSize = 0;
            btnStartMoveAction.FlatStyle = FlatStyle.Flat;
            btnStartMoveAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartMoveAction.IconChar = FontAwesome.Sharp.IconChar.None;
            btnStartMoveAction.IconColor = Color.Black;
            btnStartMoveAction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStartMoveAction.Location = new Point(12, 51);
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
            btnCancelMoveAction.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelMoveAction.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancelMoveAction.IconColor = Color.Black;
            btnCancelMoveAction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelMoveAction.Location = new Point(179, 51);
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
            btnBrowseFolder.Location = new Point(524, 22);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(37, 23);
            btnBrowseFolder.TabIndex = 2;
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(153, 15);
            label1.TabIndex = 1;
            label1.Text = "Select destination directory:";
            // 
            // tbDestinationPath
            // 
            tbDestinationPath.Location = new Point(3, 22);
            tbDestinationPath.Name = "tbDestinationPath";
            tbDestinationPath.ReadOnly = true;
            tbDestinationPath.Size = new Size(515, 23);
            tbDestinationPath.TabIndex = 0;
            // 
            // MoveListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 86);
            Controls.Add(panel1);
            Controls.Add(panelTitle);
            MaximumSize = new Size(580, 125);
            MinimumSize = new Size(580, 125);
            Name = "MoveListForm";
            Text = "MoveListForm";
            panelTitle.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTitle;
        private FontAwesome.Sharp.IconButton btnCloseForm;
        private Label lblTitle;
        private Panel panel1;
        private Panel panel2;
        private FlatProgressBar pbMoveProgress;
        private FontAwesome.Sharp.IconButton btnStartMoveAction;
        private FontAwesome.Sharp.IconButton btnCancelMoveAction;
        private FontAwesome.Sharp.IconButton btnBrowseFolder;
        private Label label1;
        private TextBox tbDestinationPath;
        private FontAwesome.Sharp.IconButton btnStartCopyAction;
        private FontAwesome.Sharp.IconButton btnFinish;
    }
}