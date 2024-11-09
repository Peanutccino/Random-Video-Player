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
            lblTitle = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            fbDialog = new FolderBrowserDialog();
            toolTipInfo = new ToolTip(components);
            splitUI = new SplitContainer();
            panel1 = new Panel();
            sbtnAbout = new FontAwesome.Sharp.IconButton();
            sbtnDragDrop = new FontAwesome.Sharp.IconButton();
            sbtnInterface = new FontAwesome.Sharp.IconButton();
            sbtnSubtitles = new FontAwesome.Sharp.IconButton();
            sbtnInputs = new FontAwesome.Sharp.IconButton();
            sbtnSync = new FontAwesome.Sharp.IconButton();
            sbtnRemember = new FontAwesome.Sharp.IconButton();
            sbtnFilterExtensions = new FontAwesome.Sharp.IconButton();
            sbtnPlayer = new FontAwesome.Sharp.IconButton();
            sbtnPaths = new FontAwesome.Sharp.IconButton();
            sbtnSkip = new FontAwesome.Sharp.IconButton();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitUI).BeginInit();
            splitUI.Panel1.SuspendLayout();
            splitUI.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(179, 179, 255);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(654, 20);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(33, 0, 3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(617, 20);
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
            btnClose.Location = new Point(624, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(179, 179, 255);
            btnSave.Dock = DockStyle.Bottom;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnSave.IconSize = 25;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(0, 546);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(172, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save and Close";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // splitUI
            // 
            splitUI.Dock = DockStyle.Fill;
            splitUI.Location = new Point(0, 20);
            splitUI.Name = "splitUI";
            // 
            // splitUI.Panel1
            // 
            splitUI.Panel1.Controls.Add(panel1);
            // 
            // splitUI.Panel2
            // 
            splitUI.Panel2.AllowDrop = true;
            splitUI.Panel2.BackColor = Color.GhostWhite;
            splitUI.Size = new Size(654, 576);
            splitUI.SplitterDistance = 172;
            splitUI.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(sbtnAbout);
            panel1.Controls.Add(sbtnDragDrop);
            panel1.Controls.Add(sbtnInterface);
            panel1.Controls.Add(sbtnSubtitles);
            panel1.Controls.Add(sbtnInputs);
            panel1.Controls.Add(sbtnSkip);
            panel1.Controls.Add(sbtnSync);
            panel1.Controls.Add(sbtnRemember);
            panel1.Controls.Add(sbtnFilterExtensions);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(sbtnPlayer);
            panel1.Controls.Add(sbtnPaths);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 576);
            panel1.TabIndex = 0;
            // 
            // sbtnAbout
            // 
            sbtnAbout.Dock = DockStyle.Top;
            sbtnAbout.FlatAppearance.BorderSize = 0;
            sbtnAbout.FlatStyle = FlatStyle.Flat;
            sbtnAbout.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnAbout.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            sbtnAbout.IconColor = Color.Black;
            sbtnAbout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnAbout.IconSize = 30;
            sbtnAbout.ImageAlign = ContentAlignment.MiddleRight;
            sbtnAbout.Location = new Point(0, 400);
            sbtnAbout.Name = "sbtnAbout";
            sbtnAbout.Size = new Size(172, 40);
            sbtnAbout.TabIndex = 5;
            sbtnAbout.Text = "About";
            sbtnAbout.TextAlign = ContentAlignment.TopLeft;
            sbtnAbout.UseVisualStyleBackColor = true;
            // 
            // sbtnDragDrop
            // 
            sbtnDragDrop.Dock = DockStyle.Top;
            sbtnDragDrop.FlatAppearance.BorderSize = 0;
            sbtnDragDrop.FlatStyle = FlatStyle.Flat;
            sbtnDragDrop.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnDragDrop.IconChar = FontAwesome.Sharp.IconChar.Meteor;
            sbtnDragDrop.IconColor = Color.Black;
            sbtnDragDrop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnDragDrop.IconSize = 30;
            sbtnDragDrop.ImageAlign = ContentAlignment.MiddleRight;
            sbtnDragDrop.Location = new Point(0, 360);
            sbtnDragDrop.Name = "sbtnDragDrop";
            sbtnDragDrop.Size = new Size(172, 40);
            sbtnDragDrop.TabIndex = 8;
            sbtnDragDrop.Text = "Drag && Drop";
            sbtnDragDrop.TextAlign = ContentAlignment.TopLeft;
            sbtnDragDrop.UseVisualStyleBackColor = true;
            // 
            // sbtnInterface
            // 
            sbtnInterface.Dock = DockStyle.Top;
            sbtnInterface.FlatAppearance.BorderSize = 0;
            sbtnInterface.FlatStyle = FlatStyle.Flat;
            sbtnInterface.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnInterface.IconChar = FontAwesome.Sharp.IconChar.Uikit;
            sbtnInterface.IconColor = Color.Black;
            sbtnInterface.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnInterface.IconSize = 30;
            sbtnInterface.ImageAlign = ContentAlignment.MiddleRight;
            sbtnInterface.Location = new Point(0, 320);
            sbtnInterface.Name = "sbtnInterface";
            sbtnInterface.Size = new Size(172, 40);
            sbtnInterface.TabIndex = 7;
            sbtnInterface.Text = "Interface";
            sbtnInterface.TextAlign = ContentAlignment.TopLeft;
            sbtnInterface.UseVisualStyleBackColor = true;
            // 
            // sbtnSubtitles
            // 
            sbtnSubtitles.Dock = DockStyle.Top;
            sbtnSubtitles.FlatAppearance.BorderSize = 0;
            sbtnSubtitles.FlatStyle = FlatStyle.Flat;
            sbtnSubtitles.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnSubtitles.IconChar = FontAwesome.Sharp.IconChar.ClosedCaptioning;
            sbtnSubtitles.IconColor = Color.Black;
            sbtnSubtitles.IconFont = FontAwesome.Sharp.IconFont.Solid;
            sbtnSubtitles.IconSize = 30;
            sbtnSubtitles.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSubtitles.Location = new Point(0, 280);
            sbtnSubtitles.Name = "sbtnSubtitles";
            sbtnSubtitles.Size = new Size(172, 40);
            sbtnSubtitles.TabIndex = 10;
            sbtnSubtitles.Text = "Subtitles";
            sbtnSubtitles.TextAlign = ContentAlignment.TopLeft;
            sbtnSubtitles.UseVisualStyleBackColor = true;
            // 
            // sbtnInputs
            // 
            sbtnInputs.Dock = DockStyle.Top;
            sbtnInputs.FlatAppearance.BorderSize = 0;
            sbtnInputs.FlatStyle = FlatStyle.Flat;
            sbtnInputs.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnInputs.IconChar = FontAwesome.Sharp.IconChar.Keyboard;
            sbtnInputs.IconColor = Color.Black;
            sbtnInputs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnInputs.IconSize = 30;
            sbtnInputs.ImageAlign = ContentAlignment.MiddleRight;
            sbtnInputs.Location = new Point(0, 240);
            sbtnInputs.Name = "sbtnInputs";
            sbtnInputs.Size = new Size(172, 40);
            sbtnInputs.TabIndex = 4;
            sbtnInputs.Text = "Inputs";
            sbtnInputs.TextAlign = ContentAlignment.TopLeft;
            sbtnInputs.UseVisualStyleBackColor = true;
            // 
            // sbtnSync
            // 
            sbtnSync.Dock = DockStyle.Top;
            sbtnSync.FlatAppearance.BorderSize = 0;
            sbtnSync.FlatStyle = FlatStyle.Flat;
            sbtnSync.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnSync.IconChar = FontAwesome.Sharp.IconChar.Sync;
            sbtnSync.IconColor = Color.Black;
            sbtnSync.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnSync.IconSize = 28;
            sbtnSync.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSync.Location = new Point(0, 160);
            sbtnSync.Name = "sbtnSync";
            sbtnSync.Padding = new Padding(0, 0, 1, 0);
            sbtnSync.Size = new Size(172, 40);
            sbtnSync.TabIndex = 3;
            sbtnSync.Text = "Sync";
            sbtnSync.TextAlign = ContentAlignment.TopLeft;
            sbtnSync.UseVisualStyleBackColor = true;
            // 
            // sbtnRemember
            // 
            sbtnRemember.Dock = DockStyle.Top;
            sbtnRemember.FlatAppearance.BorderSize = 0;
            sbtnRemember.FlatStyle = FlatStyle.Flat;
            sbtnRemember.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnRemember.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            sbtnRemember.IconColor = Color.Black;
            sbtnRemember.IconFont = FontAwesome.Sharp.IconFont.Solid;
            sbtnRemember.IconSize = 22;
            sbtnRemember.ImageAlign = ContentAlignment.MiddleRight;
            sbtnRemember.Location = new Point(0, 120);
            sbtnRemember.Name = "sbtnRemember";
            sbtnRemember.Padding = new Padding(0, 0, 3, 0);
            sbtnRemember.Size = new Size(172, 40);
            sbtnRemember.TabIndex = 2;
            sbtnRemember.Text = "Remember";
            sbtnRemember.TextAlign = ContentAlignment.TopLeft;
            sbtnRemember.UseVisualStyleBackColor = true;
            // 
            // sbtnFilterExtensions
            // 
            sbtnFilterExtensions.Dock = DockStyle.Top;
            sbtnFilterExtensions.FlatAppearance.BorderSize = 0;
            sbtnFilterExtensions.FlatStyle = FlatStyle.Flat;
            sbtnFilterExtensions.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnFilterExtensions.IconChar = FontAwesome.Sharp.IconChar.Filter;
            sbtnFilterExtensions.IconColor = Color.Black;
            sbtnFilterExtensions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnFilterExtensions.IconSize = 26;
            sbtnFilterExtensions.ImageAlign = ContentAlignment.MiddleRight;
            sbtnFilterExtensions.Location = new Point(0, 80);
            sbtnFilterExtensions.Name = "sbtnFilterExtensions";
            sbtnFilterExtensions.Size = new Size(172, 40);
            sbtnFilterExtensions.TabIndex = 9;
            sbtnFilterExtensions.Text = "Filter";
            sbtnFilterExtensions.TextAlign = ContentAlignment.TopLeft;
            sbtnFilterExtensions.UseVisualStyleBackColor = true;
            // 
            // sbtnPlayer
            // 
            sbtnPlayer.Dock = DockStyle.Top;
            sbtnPlayer.FlatAppearance.BorderSize = 0;
            sbtnPlayer.FlatStyle = FlatStyle.Flat;
            sbtnPlayer.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnPlayer.IconChar = FontAwesome.Sharp.IconChar.SlidersH;
            sbtnPlayer.IconColor = Color.Black;
            sbtnPlayer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPlayer.IconSize = 26;
            sbtnPlayer.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPlayer.Location = new Point(0, 40);
            sbtnPlayer.Name = "sbtnPlayer";
            sbtnPlayer.Size = new Size(172, 40);
            sbtnPlayer.TabIndex = 1;
            sbtnPlayer.Text = "Player";
            sbtnPlayer.TextAlign = ContentAlignment.TopLeft;
            sbtnPlayer.UseVisualStyleBackColor = true;
            // 
            // sbtnPaths
            // 
            sbtnPaths.Dock = DockStyle.Top;
            sbtnPaths.FlatAppearance.BorderSize = 0;
            sbtnPaths.FlatStyle = FlatStyle.Flat;
            sbtnPaths.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnPaths.IconChar = FontAwesome.Sharp.IconChar.FolderTree;
            sbtnPaths.IconColor = Color.Black;
            sbtnPaths.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnPaths.IconSize = 24;
            sbtnPaths.ImageAlign = ContentAlignment.MiddleRight;
            sbtnPaths.Location = new Point(0, 0);
            sbtnPaths.Name = "sbtnPaths";
            sbtnPaths.Size = new Size(172, 40);
            sbtnPaths.TabIndex = 0;
            sbtnPaths.Text = "Paths";
            sbtnPaths.TextAlign = ContentAlignment.TopLeft;
            sbtnPaths.UseVisualStyleBackColor = true;
            // 
            // sbtnSkip
            // 
            sbtnSkip.Dock = DockStyle.Top;
            sbtnSkip.FlatAppearance.BorderSize = 0;
            sbtnSkip.FlatStyle = FlatStyle.Flat;
            sbtnSkip.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            sbtnSkip.IconChar = FontAwesome.Sharp.IconChar.Forward;
            sbtnSkip.IconColor = Color.Black;
            sbtnSkip.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnSkip.IconSize = 28;
            sbtnSkip.ImageAlign = ContentAlignment.MiddleRight;
            sbtnSkip.Location = new Point(0, 200);
            sbtnSkip.Name = "sbtnSkip";
            sbtnSkip.Padding = new Padding(0, 0, 1, 0);
            sbtnSkip.Size = new Size(172, 40);
            sbtnSkip.TabIndex = 11;
            sbtnSkip.Text = "Auto Skip";
            sbtnSkip.TextAlign = ContentAlignment.TopLeft;
            sbtnSkip.UseVisualStyleBackColor = true;
            // 
            // SettingsView
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(654, 596);
            Controls.Add(splitUI);
            Controls.Add(panelTop);
            MinimumSize = new Size(670, 635);
            Name = "SettingsView";
            Text = "SettingsView";
            Resize += SettingsView_Resize;
            panelTop.ResumeLayout(false);
            splitUI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitUI).EndInit();
            splitUI.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnSave;
        private FolderBrowserDialog fbDialog;
        private Label lblTitle;
        private ToolTip toolTipInfo;
        private SplitContainer splitUI;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton sbtnPaths;
        private FontAwesome.Sharp.IconButton sbtnInputs;
        private FontAwesome.Sharp.IconButton sbtnSync;
        private FontAwesome.Sharp.IconButton sbtnRemember;
        private FontAwesome.Sharp.IconButton sbtnPlayer;
        private FontAwesome.Sharp.IconButton sbtnAbout;
        private FontAwesome.Sharp.IconButton sbtnInterface;
        private FontAwesome.Sharp.IconButton sbtnDragDrop;
        private FontAwesome.Sharp.IconButton sbtnFilterExtensions;
        private FontAwesome.Sharp.IconButton sbtnSubtitles;
        private FontAwesome.Sharp.IconButton sbtnSkip;
    }
}