namespace RandomVideoPlayer.View
{
    partial class SettingsView
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
            components = new System.ComponentModel.Container();
            panelTop = new Panel();
            btnHelp = new FontAwesome.Sharp.IconButton();
            lblTitle = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelBody = new Panel();
            groupBox4 = new GroupBox();
            cbPlayImages = new CheckBox();
            cbPlayVideos = new CheckBox();
            cbtimeCodeServer = new CheckBox();
            cbLoopPlayer = new CheckBox();
            groupBox3 = new GroupBox();
            rbModifiedDate = new RadioButton();
            rbCreationDate = new RadioButton();
            groupBox2 = new GroupBox();
            tbListfolderPath = new TextBox();
            btnFileBrowseList = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            cbIncludeScripts = new CheckBox();
            cbDeleteToggle = new CheckBox();
            tbRemovalPath = new TextBox();
            btnFileBrowseRemove = new FontAwesome.Sharp.IconButton();
            groupWindow = new GroupBox();
            cbRemembersize = new CheckBox();
            groupDefaultPath = new GroupBox();
            tbDefaultPath = new TextBox();
            btnFileBrowse = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            fbDialog = new FolderBrowserDialog();
            toolTipInfo = new ToolTip(components);
            panelTop.SuspendLayout();
            panelBody.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupWindow.SuspendLayout();
            groupDefaultPath.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(242, 141, 238);
            panelTop.Controls.Add(btnHelp);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(324, 20);
            panelTop.TabIndex = 0;
            // 
            // btnHelp
            // 
            btnHelp.Dock = DockStyle.Right;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.IconChar = FontAwesome.Sharp.IconChar.QuestionCircle;
            btnHelp.IconColor = Color.Black;
            btnHelp.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnHelp.IconSize = 15;
            btnHelp.Location = new Point(264, 0);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(30, 20);
            btnHelp.TabIndex = 2;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(33, 0, 3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(263, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "                    RVP - Settings";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseDown += lblTitle_MouseDown;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Red;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            btnClose.IconColor = Color.Black;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 15;
            btnClose.Location = new Point(294, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.FromArgb(255, 226, 255);
            panelBody.Controls.Add(groupBox4);
            panelBody.Controls.Add(groupBox3);
            panelBody.Controls.Add(groupBox2);
            panelBody.Controls.Add(groupBox1);
            panelBody.Controls.Add(groupWindow);
            panelBody.Controls.Add(groupDefaultPath);
            panelBody.Controls.Add(btnSave);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 20);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(324, 446);
            panelBody.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(cbPlayImages);
            groupBox4.Controls.Add(cbPlayVideos);
            groupBox4.Controls.Add(cbtimeCodeServer);
            groupBox4.Controls.Add(cbLoopPlayer);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.Location = new Point(3, 365);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(318, 81);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Player behavior";
            // 
            // cbPlayImages
            // 
            cbPlayImages.AutoSize = true;
            cbPlayImages.Location = new Point(168, 47);
            cbPlayImages.Name = "cbPlayImages";
            cbPlayImages.Size = new Size(107, 19);
            cbPlayImages.TabIndex = 3;
            cbPlayImages.Text = "Include images";
            cbPlayImages.UseVisualStyleBackColor = true;
            // 
            // cbPlayVideos
            // 
            cbPlayVideos.AutoSize = true;
            cbPlayVideos.Location = new Point(9, 47);
            cbPlayVideos.Name = "cbPlayVideos";
            cbPlayVideos.Size = new Size(103, 19);
            cbPlayVideos.TabIndex = 2;
            cbPlayVideos.Text = "Include videos";
            cbPlayVideos.UseVisualStyleBackColor = true;
            // 
            // cbtimeCodeServer
            // 
            cbtimeCodeServer.AutoSize = true;
            cbtimeCodeServer.Location = new Point(168, 22);
            cbtimeCodeServer.Name = "cbtimeCodeServer";
            cbtimeCodeServer.Size = new Size(115, 19);
            cbtimeCodeServer.TabIndex = 1;
            cbtimeCodeServer.Text = "Timecode Server";
            cbtimeCodeServer.UseVisualStyleBackColor = true;
            // 
            // cbLoopPlayer
            // 
            cbLoopPlayer.AutoSize = true;
            cbLoopPlayer.Location = new Point(9, 22);
            cbLoopPlayer.Name = "cbLoopPlayer";
            cbLoopPlayer.Size = new Size(141, 19);
            cbLoopPlayer.TabIndex = 0;
            cbLoopPlayer.Text = "Loop currently played";
            cbLoopPlayer.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(rbModifiedDate);
            groupBox3.Controls.Add(rbCreationDate);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(3, 300);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(318, 59);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Latest filter behavior:";
            // 
            // rbModifiedDate
            // 
            rbModifiedDate.AutoSize = true;
            rbModifiedDate.Location = new Point(168, 22);
            rbModifiedDate.Name = "rbModifiedDate";
            rbModifiedDate.Size = new Size(140, 19);
            rbModifiedDate.TabIndex = 1;
            rbModifiedDate.TabStop = true;
            rbModifiedDate.Text = "Sort by date modified";
            rbModifiedDate.UseVisualStyleBackColor = true;
            // 
            // rbCreationDate
            // 
            rbCreationDate.AutoSize = true;
            rbCreationDate.Location = new Point(9, 22);
            rbCreationDate.Name = "rbCreationDate";
            rbCreationDate.Size = new Size(131, 19);
            rbCreationDate.TabIndex = 0;
            rbCreationDate.TabStop = true;
            rbCreationDate.Text = "Sort by date created";
            rbCreationDate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(tbListfolderPath);
            groupBox2.Controls.Add(btnFileBrowseList);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(6, 237);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(318, 57);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Set List Folderpath:";
            // 
            // tbListfolderPath
            // 
            tbListfolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbListfolderPath.BackColor = Color.FromArgb(252, 232, 252);
            tbListfolderPath.Location = new Point(6, 22);
            tbListfolderPath.Name = "tbListfolderPath";
            tbListfolderPath.ReadOnly = true;
            tbListfolderPath.Size = new Size(270, 23);
            tbListfolderPath.TabIndex = 0;
            // 
            // btnFileBrowseList
            // 
            btnFileBrowseList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFileBrowseList.FlatAppearance.BorderSize = 0;
            btnFileBrowseList.FlatStyle = FlatStyle.Flat;
            btnFileBrowseList.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnFileBrowseList.IconColor = Color.Black;
            btnFileBrowseList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileBrowseList.IconSize = 25;
            btnFileBrowseList.Location = new Point(282, 22);
            btnFileBrowseList.Name = "btnFileBrowseList";
            btnFileBrowseList.Size = new Size(30, 23);
            btnFileBrowseList.TabIndex = 2;
            btnFileBrowseList.UseVisualStyleBackColor = true;
            btnFileBrowseList.Click += btnFileBrowseList_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cbIncludeScripts);
            groupBox1.Controls.Add(cbDeleteToggle);
            groupBox1.Controls.Add(tbRemovalPath);
            groupBox1.Controls.Add(btnFileBrowseRemove);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(3, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(318, 106);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Set removal folder:";
            // 
            // cbIncludeScripts
            // 
            cbIncludeScripts.AutoSize = true;
            cbIncludeScripts.Location = new Point(9, 76);
            cbIncludeScripts.Name = "cbIncludeScripts";
            cbIncludeScripts.Size = new Size(182, 19);
            cbIncludeScripts.TabIndex = 6;
            cbIncludeScripts.Text = "Include associated .funscripts";
            cbIncludeScripts.UseVisualStyleBackColor = true;
            // 
            // cbDeleteToggle
            // 
            cbDeleteToggle.AutoSize = true;
            cbDeleteToggle.Location = new Point(9, 51);
            cbDeleteToggle.Name = "cbDeleteToggle";
            cbDeleteToggle.Size = new Size(207, 19);
            cbDeleteToggle.TabIndex = 5;
            cbDeleteToggle.Text = "Delete instead of moving to folder";
            cbDeleteToggle.UseVisualStyleBackColor = true;
            // 
            // tbRemovalPath
            // 
            tbRemovalPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbRemovalPath.BackColor = Color.FromArgb(252, 232, 252);
            tbRemovalPath.Location = new Point(6, 22);
            tbRemovalPath.Name = "tbRemovalPath";
            tbRemovalPath.ReadOnly = true;
            tbRemovalPath.Size = new Size(270, 23);
            tbRemovalPath.TabIndex = 0;
            // 
            // btnFileBrowseRemove
            // 
            btnFileBrowseRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFileBrowseRemove.FlatAppearance.BorderSize = 0;
            btnFileBrowseRemove.FlatStyle = FlatStyle.Flat;
            btnFileBrowseRemove.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnFileBrowseRemove.IconColor = Color.Black;
            btnFileBrowseRemove.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileBrowseRemove.IconSize = 25;
            btnFileBrowseRemove.Location = new Point(282, 22);
            btnFileBrowseRemove.Name = "btnFileBrowseRemove";
            btnFileBrowseRemove.Size = new Size(30, 23);
            btnFileBrowseRemove.TabIndex = 2;
            btnFileBrowseRemove.UseVisualStyleBackColor = true;
            btnFileBrowseRemove.Click += btnFileBrowseRemove_Click;
            // 
            // groupWindow
            // 
            groupWindow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupWindow.Controls.Add(cbRemembersize);
            groupWindow.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupWindow.Location = new Point(3, 69);
            groupWindow.Name = "groupWindow";
            groupWindow.Size = new Size(318, 50);
            groupWindow.TabIndex = 6;
            groupWindow.TabStop = false;
            groupWindow.Text = "Window Size";
            // 
            // cbRemembersize
            // 
            cbRemembersize.AutoSize = true;
            cbRemembersize.Location = new Point(9, 22);
            cbRemembersize.Name = "cbRemembersize";
            cbRemembersize.Size = new Size(157, 19);
            cbRemembersize.TabIndex = 4;
            cbRemembersize.Text = "Remember Window Size";
            cbRemembersize.UseVisualStyleBackColor = true;
            // 
            // groupDefaultPath
            // 
            groupDefaultPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupDefaultPath.Controls.Add(tbDefaultPath);
            groupDefaultPath.Controls.Add(btnFileBrowse);
            groupDefaultPath.FlatStyle = FlatStyle.System;
            groupDefaultPath.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupDefaultPath.Location = new Point(3, 6);
            groupDefaultPath.Name = "groupDefaultPath";
            groupDefaultPath.Size = new Size(318, 57);
            groupDefaultPath.TabIndex = 5;
            groupDefaultPath.TabStop = false;
            groupDefaultPath.Text = "Set default path:";
            // 
            // tbDefaultPath
            // 
            tbDefaultPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDefaultPath.BackColor = Color.FromArgb(252, 232, 252);
            tbDefaultPath.Location = new Point(6, 22);
            tbDefaultPath.Name = "tbDefaultPath";
            tbDefaultPath.ReadOnly = true;
            tbDefaultPath.Size = new Size(270, 23);
            tbDefaultPath.TabIndex = 0;
            // 
            // btnFileBrowse
            // 
            btnFileBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFileBrowse.FlatAppearance.BorderSize = 0;
            btnFileBrowse.FlatStyle = FlatStyle.Flat;
            btnFileBrowse.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnFileBrowse.IconColor = Color.Black;
            btnFileBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileBrowse.IconSize = 25;
            btnFileBrowse.Location = new Point(282, 22);
            btnFileBrowse.Name = "btnFileBrowse";
            btnFileBrowse.Size = new Size(30, 23);
            btnFileBrowse.TabIndex = 2;
            btnFileBrowse.UseVisualStyleBackColor = true;
            btnFileBrowse.Click += btnFileBrowse_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(242, 141, 238);
            btnSave.Dock = DockStyle.Bottom;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnSave.IconSize = 25;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(0, 416);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(324, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save and Close";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // SettingsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 466);
            Controls.Add(panelBody);
            Controls.Add(panelTop);
            MinimumSize = new Size(340, 505);
            Name = "SettingsView";
            Text = "SettingsView";
            Load += SettingsView_Load;
            Resize += SettingsView_Resize;
            panelTop.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupWindow.ResumeLayout(false);
            groupWindow.PerformLayout();
            groupDefaultPath.ResumeLayout(false);
            groupDefaultPath.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private FontAwesome.Sharp.IconButton btnClose;
        private Panel panelBody;
        private TextBox tbDefaultPath;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnFileBrowse;
        private FolderBrowserDialog fbDialog;
        private Label lblTitle;
        private GroupBox groupDefaultPath;
        private CheckBox cbRemembersize;
        private GroupBox groupWindow;
        private GroupBox groupBox1;
        private CheckBox cbDeleteToggle;
        private TextBox tbRemovalPath;
        private FontAwesome.Sharp.IconButton btnFileBrowseRemove;
        private GroupBox groupBox2;
        private TextBox tbListfolderPath;
        private FontAwesome.Sharp.IconButton btnFileBrowseList;
        private ToolTip toolTipInfo;
        private GroupBox groupBox3;
        private RadioButton rbModifiedDate;
        private RadioButton rbCreationDate;
        private GroupBox groupBox4;
        private CheckBox cbLoopPlayer;
        private CheckBox cbtimeCodeServer;
        private FontAwesome.Sharp.IconButton btnHelp;
        private CheckBox cbPlayImages;
        private CheckBox cbPlayVideos;
        private CheckBox cbIncludeScripts;
    }
}