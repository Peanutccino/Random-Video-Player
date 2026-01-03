namespace RandomVideoPlayer.UserControls
{
    partial class ProfilesUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHeader = new Label();
            panel1 = new Panel();
            lblProfile = new Label();
            lbl2 = new Label();
            lbl1 = new Label();
            lbProfiles = new ListBox();
            panel2 = new Panel();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnDelete = new FontAwesome.Sharp.IconButton();
            btnRename = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSetProfile = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(509, 55);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Profiles";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblProfile);
            panel1.Controls.Add(lbl2);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(509, 92);
            panel1.TabIndex = 2;
            // 
            // lblProfile
            // 
            lblProfile.Dock = DockStyle.Fill;
            lblProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfile.ForeColor = Color.Indigo;
            lblProfile.Location = new Point(0, 40);
            lblProfile.Name = "lblProfile";
            lblProfile.Padding = new Padding(6, 10, 0, 0);
            lblProfile.Size = new Size(509, 52);
            lblProfile.TabIndex = 2;
            lblProfile.Text = "Default 1";
            lblProfile.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 15);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 10, 0, 0);
            lbl2.Size = new Size(119, 25);
            lbl2.TabIndex = 1;
            lbl2.Text = "Currently set profile:";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Dock = DockStyle.Top;
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(328, 15);
            lbl1.TabIndex = 0;
            lbl1.Text = "Add, delete or rename profiles used to save preferred scripts";
            // 
            // lbProfiles
            // 
            lbProfiles.Dock = DockStyle.Fill;
            lbProfiles.FormattingEnabled = true;
            lbProfiles.ItemHeight = 15;
            lbProfiles.Location = new Point(0, 0);
            lbProfiles.Name = "lbProfiles";
            lbProfiles.Size = new Size(509, 201);
            lbProfiles.TabIndex = 0;
            lbProfiles.SelectedIndexChanged += lbProfiles_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(lbProfiles);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 147);
            panel2.Name = "panel2";
            panel2.Size = new Size(509, 201);
            panel2.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 28;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
            btnDelete.IconColor = Color.Black;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.IconSize = 28;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(123, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 34);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRename
            // 
            btnRename.Dock = DockStyle.Fill;
            btnRename.Enabled = false;
            btnRename.FlatAppearance.BorderSize = 0;
            btnRename.FlatStyle = FlatStyle.Flat;
            btnRename.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRename.IconChar = FontAwesome.Sharp.IconChar.ICursor;
            btnRename.IconColor = Color.Black;
            btnRename.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRename.IconSize = 26;
            btnRename.ImageAlign = ContentAlignment.MiddleLeft;
            btnRename.Location = new Point(243, 3);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(114, 34);
            btnRename.TabIndex = 2;
            btnRename.Text = "Rename";
            btnRename.TextAlign = ContentAlignment.MiddleRight;
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5849056F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5849056F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5849056F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.2452831F));
            tableLayoutPanel1.Controls.Add(btnSetProfile, 3, 0);
            tableLayoutPanel1.Controls.Add(btnRename, 2, 0);
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(btnDelete, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 348);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(509, 40);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // btnSetProfile
            // 
            btnSetProfile.Dock = DockStyle.Fill;
            btnSetProfile.Enabled = false;
            btnSetProfile.FlatAppearance.BorderSize = 0;
            btnSetProfile.FlatStyle = FlatStyle.Flat;
            btnSetProfile.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSetProfile.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            btnSetProfile.IconColor = Color.Black;
            btnSetProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSetProfile.IconSize = 26;
            btnSetProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btnSetProfile.Location = new Point(363, 3);
            btnSetProfile.Name = "btnSetProfile";
            btnSetProfile.Size = new Size(143, 34);
            btnSetProfile.TabIndex = 3;
            btnSetProfile.Text = "Set profile";
            btnSetProfile.TextAlign = ContentAlignment.MiddleRight;
            btnSetProfile.UseVisualStyleBackColor = true;
            btnSetProfile.Click += btnSetProfile_Click;
            // 
            // ProfilesUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblHeader);
            Name = "ProfilesUserControl";
            Size = new Size(509, 609);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel panel1;
        private ListBox lbProfiles;
        private Panel panel2;
        private Label lblProfile;
        private Label lbl2;
        private Label lbl1;
        private FontAwesome.Sharp.IconButton btnRename;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnAdd;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnSetProfile;
    }
}
