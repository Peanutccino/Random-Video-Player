namespace RandomVideoPlayerV3.View
{
    partial class FolderBrowserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderBrowserView));
            panelTop = new Panel();
            btnClose = new FontAwesome.Sharp.IconButton();
            lblTitleBar = new Label();
            panel1 = new Panel();
            cbIncludeSubfolders = new CheckBox();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            btnAddFav = new FontAwesome.Sharp.IconButton();
            lbFavorites = new ListBox();
            label2 = new Label();
            label1 = new Label();
            btnFolderSelect = new FontAwesome.Sharp.IconButton();
            cbUseRecent = new CheckBox();
            tbCount = new TextBox();
            lbDriveFolders = new ListBox();
            btnBack = new FontAwesome.Sharp.IconButton();
            lvFileExplore = new ListView();
            imageList = new ImageList(components);
            tbPathView = new TextBox();
            toolTipInfo = new ToolTip(components);
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.PaleGreen;
            panelTop.Controls.Add(btnClose);
            panelTop.Controls.Add(lblTitleBar);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(924, 20);
            panelTop.TabIndex = 0;
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
            btnClose.Location = new Point(894, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitleBar
            // 
            lblTitleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleBar.Location = new Point(40, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Size = new Size(848, 20);
            lblTitleBar.TabIndex = 0;
            lblTitleBar.Text = "RVP - Folder Browser";
            lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
            lblTitleBar.MouseDown += lblTitleBar_MouseDown;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Honeydew;
            panel1.Controls.Add(cbIncludeSubfolders);
            panel1.Controls.Add(btnDeleteFav);
            panel1.Controls.Add(btnAddFav);
            panel1.Controls.Add(lbFavorites);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnFolderSelect);
            panel1.Controls.Add(cbUseRecent);
            panel1.Controls.Add(tbCount);
            panel1.Controls.Add(lbDriveFolders);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(lvFileExplore);
            panel1.Controls.Add(tbPathView);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(924, 541);
            panel1.TabIndex = 1;
            // 
            // cbIncludeSubfolders
            // 
            cbIncludeSubfolders.AutoSize = true;
            cbIncludeSubfolders.CheckAlign = ContentAlignment.MiddleRight;
            cbIncludeSubfolders.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbIncludeSubfolders.Location = new Point(496, 10);
            cbIncludeSubfolders.Name = "cbIncludeSubfolders";
            cbIncludeSubfolders.Size = new Size(120, 17);
            cbIncludeSubfolders.TabIndex = 13;
            cbIncludeSubfolders.Text = "Include Subfolders";
            cbIncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFav
            // 
            btnDeleteFav.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteFav.FlatAppearance.BorderSize = 0;
            btnDeleteFav.FlatStyle = FlatStyle.Flat;
            btnDeleteFav.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteFav.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
            btnDeleteFav.IconColor = Color.Black;
            btnDeleteFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteFav.IconSize = 24;
            btnDeleteFav.Location = new Point(72, 513);
            btnDeleteFav.Name = "btnDeleteFav";
            btnDeleteFav.Size = new Size(50, 25);
            btnDeleteFav.TabIndex = 12;
            btnDeleteFav.UseVisualStyleBackColor = true;
            btnDeleteFav.Click += btnDeleteFav_Click;
            // 
            // btnAddFav
            // 
            btnAddFav.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddFav.FlatAppearance.BorderSize = 0;
            btnAddFav.FlatStyle = FlatStyle.Flat;
            btnAddFav.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddFav.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddFav.IconColor = Color.Black;
            btnAddFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddFav.IconSize = 24;
            btnAddFav.Location = new Point(3, 513);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(50, 25);
            btnAddFav.TabIndex = 11;
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // lbFavorites
            // 
            lbFavorites.BackColor = Color.Honeydew;
            lbFavorites.BorderStyle = BorderStyle.None;
            lbFavorites.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbFavorites.FormattingEnabled = true;
            lbFavorites.ItemHeight = 15;
            lbFavorites.Location = new Point(0, 266);
            lbFavorites.Name = "lbFavorites";
            lbFavorites.Size = new Size(126, 240);
            lbFavorites.TabIndex = 10;
            lbFavorites.DoubleClick += lbFavorites_DoubleClick;
            lbFavorites.MouseMove += lbFavorites_MouseMove;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(-2, 248);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 9;
            label2.Text = "Favorites:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(-2, 35);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 8;
            label1.Text = "Available Drives:";
            // 
            // btnFolderSelect
            // 
            btnFolderSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFolderSelect.FlatAppearance.BorderSize = 0;
            btnFolderSelect.FlatAppearance.MouseOverBackColor = Color.GreenYellow;
            btnFolderSelect.FlatStyle = FlatStyle.Flat;
            btnFolderSelect.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnFolderSelect.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            btnFolderSelect.IconColor = Color.Black;
            btnFolderSelect.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFolderSelect.IconSize = 24;
            btnFolderSelect.ImageAlign = ContentAlignment.MiddleRight;
            btnFolderSelect.Location = new Point(789, 5);
            btnFolderSelect.Name = "btnFolderSelect";
            btnFolderSelect.Size = new Size(135, 25);
            btnFolderSelect.TabIndex = 7;
            btnFolderSelect.Text = "Use current Folder";
            btnFolderSelect.TextAlign = ContentAlignment.MiddleLeft;
            btnFolderSelect.UseVisualStyleBackColor = true;
            btnFolderSelect.Click += btnFolderSelect_Click;
            // 
            // cbUseRecent
            // 
            cbUseRecent.AutoSize = true;
            cbUseRecent.CheckAlign = ContentAlignment.MiddleRight;
            cbUseRecent.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbUseRecent.Location = new Point(622, 9);
            cbUseRecent.Name = "cbUseRecent";
            cbUseRecent.Size = new Size(114, 17);
            cbUseRecent.TabIndex = 6;
            cbUseRecent.Text = "Only latest X files";
            cbUseRecent.UseVisualStyleBackColor = true;
            // 
            // tbCount
            // 
            tbCount.BackColor = Color.MintCream;
            tbCount.Location = new Point(751, 6);
            tbCount.Name = "tbCount";
            tbCount.Size = new Size(32, 23);
            tbCount.TabIndex = 5;
            tbCount.Text = "50";
            tbCount.TextAlign = HorizontalAlignment.Center;
            tbCount.TextChanged += tbCount_TextChanged;
            // 
            // lbDriveFolders
            // 
            lbDriveFolders.BackColor = Color.Honeydew;
            lbDriveFolders.BorderStyle = BorderStyle.None;
            lbDriveFolders.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbDriveFolders.FormattingEnabled = true;
            lbDriveFolders.ItemHeight = 15;
            lbDriveFolders.Location = new Point(0, 53);
            lbDriveFolders.Name = "lbDriveFolders";
            lbDriveFolders.Size = new Size(126, 195);
            lbDriveFolders.TabIndex = 4;
            lbDriveFolders.DoubleClick += lbDriveFolders_DoubleClick;
            // 
            // btnBack
            // 
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            btnBack.IconColor = Color.Black;
            btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBack.IconSize = 24;
            btnBack.Location = new Point(3, 6);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(30, 23);
            btnBack.TabIndex = 3;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lvFileExplore
            // 
            lvFileExplore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvFileExplore.BackColor = Color.MintCream;
            lvFileExplore.LargeImageList = imageList;
            lvFileExplore.Location = new Point(126, 35);
            lvFileExplore.Name = "lvFileExplore";
            lvFileExplore.Size = new Size(798, 506);
            lvFileExplore.SmallImageList = imageList;
            lvFileExplore.TabIndex = 2;
            lvFileExplore.UseCompatibleStateImageBehavior = false;
            lvFileExplore.View = System.Windows.Forms.View.SmallIcon;
            lvFileExplore.ItemActivate += lvFileExplore_ItemActivate;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "folder.png");
            imageList.Images.SetKeyName(1, "film.png");
            // 
            // tbPathView
            // 
            tbPathView.BackColor = Color.MintCream;
            tbPathView.Location = new Point(40, 6);
            tbPathView.Name = "tbPathView";
            tbPathView.ReadOnly = true;
            tbPathView.Size = new Size(450, 23);
            tbPathView.TabIndex = 1;
            // 
            // FolderBrowserView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 561);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            MinimumSize = new Size(940, 600);
            Name = "FolderBrowserView";
            Text = "FolderBrowserView";
            Load += FolderBrowserView_Load;
            Resize += FolderBrowserView_Resize;
            panelTop.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Panel panel1;
        private Label lblTitleBar;
        private FontAwesome.Sharp.IconButton btnClose;
        private TextBox tbPathView;
        private ListView lvFileExplore;
        private FontAwesome.Sharp.IconButton btnBack;
        private ImageList imageList;
        private ListBox lbDriveFolders;
        private CheckBox cbUseRecent;
        private TextBox tbCount;
        private FontAwesome.Sharp.IconButton btnFolderSelect;
        private ListBox lbFavorites;
        private Label label2;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnDeleteFav;
        private FontAwesome.Sharp.IconButton btnAddFav;
        private ToolTip toolTipInfo;
        private CheckBox cbIncludeSubfolders;
    }
}