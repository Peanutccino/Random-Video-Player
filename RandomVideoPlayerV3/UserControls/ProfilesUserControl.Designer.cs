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
            tableLayoutMain = new TableLayoutPanel();
            lbProfiles = new ListBox();
            lblProfile = new Label();
            lblHeader = new Label();
            panel1 = new Panel();
            lbl2 = new Label();
            lbl1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSetProfile = new FontAwesome.Sharp.IconButton();
            btnRename = new FontAwesome.Sharp.IconButton();
            btnDelete = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.MistyRose;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lbProfiles, 0, 3);
            tableLayoutMain.Controls.Add(lblProfile, 0, 2);
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 1);
            tableLayoutMain.Controls.Add(tableLayoutPanel1, 0, 4);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 5;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // lbProfiles
            // 
            lbProfiles.Dock = DockStyle.Fill;
            lbProfiles.FormattingEnabled = true;
            lbProfiles.ItemHeight = 15;
            lbProfiles.Location = new Point(3, 181);
            lbProfiles.Name = "lbProfiles";
            lbProfiles.Size = new Size(518, 280);
            lbProfiles.TabIndex = 10;
            lbProfiles.SelectedIndexChanged += lbProfiles_SelectedIndexChanged;
            // 
            // lblProfile
            // 
            lblProfile.Dock = DockStyle.Fill;
            lblProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfile.ForeColor = Color.Indigo;
            lblProfile.Location = new Point(3, 126);
            lblProfile.Name = "lblProfile";
            lblProfile.Padding = new Padding(6, 10, 0, 0);
            lblProfile.Size = new Size(518, 52);
            lblProfile.TabIndex = 9;
            lblProfile.Text = "Default 1";
            lblProfile.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 7;
            lblHeader.Text = "Profiles";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCoral;
            panel1.Controls.Add(lbl2);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 60);
            panel1.TabIndex = 8;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 24);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 2;
            lbl2.Text = "Currently set profile:";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 24);
            lbl1.TabIndex = 1;
            lbl1.Text = "Add, delete or rename profiles used to save preferred scripts";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnSetProfile, 3, 0);
            tableLayoutPanel1.Controls.Add(btnRename, 2, 0);
            tableLayoutPanel1.Controls.Add(btnDelete, 1, 0);
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 467);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(518, 46);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // btnSetProfile
            // 
            btnSetProfile.Dock = DockStyle.Fill;
            btnSetProfile.Enabled = false;
            btnSetProfile.FlatAppearance.BorderSize = 0;
            btnSetProfile.FlatStyle = FlatStyle.Flat;
            btnSetProfile.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSetProfile.IconChar = FontAwesome.Sharp.IconChar.UserLarge;
            btnSetProfile.IconColor = Color.Black;
            btnSetProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSetProfile.IconSize = 26;
            btnSetProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btnSetProfile.Location = new Point(393, 6);
            btnSetProfile.Margin = new Padding(6);
            btnSetProfile.Name = "btnSetProfile";
            btnSetProfile.Size = new Size(119, 34);
            btnSetProfile.TabIndex = 4;
            btnSetProfile.Text = "Set profile";
            btnSetProfile.TextAlign = ContentAlignment.MiddleRight;
            btnSetProfile.UseVisualStyleBackColor = true;
            btnSetProfile.Click += btnSetProfile_Click;
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
            btnRename.Location = new Point(264, 6);
            btnRename.Margin = new Padding(6);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(117, 34);
            btnRename.TabIndex = 3;
            btnRename.Text = "Rename";
            btnRename.TextAlign = ContentAlignment.MiddleRight;
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.Subtract;
            btnDelete.IconColor = Color.Black;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelete.IconSize = 28;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(135, 6);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(117, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 28;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(6, 6);
            btnAdd.Margin = new Padding(6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 34);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ProfilesUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "ProfilesUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Label lbl2;
        private Label lblProfile;
        private ListBox lbProfiles;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnRename;
        private FontAwesome.Sharp.IconButton btnSetProfile;
    }
}
