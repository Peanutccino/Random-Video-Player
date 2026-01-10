namespace RandomVideoPlayer.Views
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
            panelMain = new Panel();
            lvFileExplore = new ListView();
            columnHeader1 = new ColumnHeader();
            imageListMedium = new ImageList(components);
            panelHeaderListView = new Panel();
            panelToolbar = new RandomVideoPlayer.Controls.CustomPanel();
            cbEnableVideoFilter = new RandomVideoPlayer.Controls.RoundedImageCheckBox();
            cbEnableImageFilter = new RandomVideoPlayer.Controls.RoundedImageCheckBox();
            cbEnableScriptFilter = new RandomVideoPlayer.Controls.RoundedImageCheckBox();
            btnViewGrid = new FontAwesome.Sharp.IconButton();
            btnViewTile = new FontAwesome.Sharp.IconButton();
            btnViewList = new FontAwesome.Sharp.IconButton();
            cbUseRecent = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbIncludeSubfolders = new RandomVideoPlayer.Controls.RoundedCheckBox();
            btnIncreaseSize = new FontAwesome.Sharp.IconButton();
            btnResetSize = new FontAwesome.Sharp.IconButton();
            btnDecreaseSize = new FontAwesome.Sharp.IconButton();
            tbCount = new TextBox();
            btnFolderSelect = new FontAwesome.Sharp.IconButton();
            lblFavorites = new Label();
            lblNavigation = new Label();
            lbFavorites = new ListBox();
            lbDriveFolders = new ListBox();
            btnBack = new FontAwesome.Sharp.IconButton();
            tbPathView = new TextBox();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            btnAddFav = new FontAwesome.Sharp.IconButton();
            imageList = new ImageList(components);
            toolTipInfo = new ToolTip(components);
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            panelMain.SuspendLayout();
            panelHeaderListView.SuspendLayout();
            panelToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(255, 221, 26);
            panelTop.Controls.Add(btnClose);
            panelTop.Controls.Add(lblTitleBar);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1034, 20);
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
            btnClose.Location = new Point(1004, 0);
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
            lblTitleBar.Size = new Size(958, 20);
            lblTitleBar.TabIndex = 0;
            lblTitleBar.Text = "RVP - Folder Browser";
            lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
            lblTitleBar.MouseDown += lblTitleBar_MouseDown;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightYellow;
            panel1.Controls.Add(panelMain);
            panel1.Controls.Add(lblFavorites);
            panel1.Controls.Add(lblNavigation);
            panel1.Controls.Add(lbFavorites);
            panel1.Controls.Add(lbDriveFolders);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(tbPathView);
            panel1.Controls.Add(btnDeleteFav);
            panel1.Controls.Add(btnAddFav);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 541);
            panel1.TabIndex = 1;
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMain.BackColor = Color.LightYellow;
            panelMain.Controls.Add(lvFileExplore);
            panelMain.Controls.Add(panelHeaderListView);
            panelMain.Location = new Point(126, 36);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(905, 505);
            panelMain.TabIndex = 17;
            // 
            // lvFileExplore
            // 
            lvFileExplore.BackColor = Color.LightGoldenrodYellow;
            lvFileExplore.BorderStyle = BorderStyle.None;
            lvFileExplore.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvFileExplore.Dock = DockStyle.Fill;
            lvFileExplore.HeaderStyle = ColumnHeaderStyle.None;
            lvFileExplore.LargeImageList = imageListMedium;
            lvFileExplore.Location = new Point(0, 36);
            lvFileExplore.Name = "lvFileExplore";
            lvFileExplore.ShowItemToolTips = true;
            lvFileExplore.Size = new Size(905, 469);
            lvFileExplore.SmallImageList = imageListMedium;
            lvFileExplore.TabIndex = 2;
            lvFileExplore.UseCompatibleStateImageBehavior = false;
            lvFileExplore.View = System.Windows.Forms.View.Tile;
            lvFileExplore.ItemActivate += lvFileExplore_ItemActivate;
            lvFileExplore.MouseDown += lvFileExplore_MouseDown;
            lvFileExplore.Resize += lvFileExplore_Resize;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 250;
            // 
            // imageListMedium
            // 
            imageListMedium.ColorDepth = ColorDepth.Depth32Bit;
            imageListMedium.ImageStream = (ImageListStreamer)resources.GetObject("imageListMedium.ImageStream");
            imageListMedium.TransparentColor = Color.Transparent;
            imageListMedium.Images.SetKeyName(0, "folder.png");
            imageListMedium.Images.SetKeyName(1, "VideoIcon.png");
            imageListMedium.Images.SetKeyName(2, "ImageIcon.png");
            // 
            // panelHeaderListView
            // 
            panelHeaderListView.Controls.Add(panelToolbar);
            panelHeaderListView.Controls.Add(btnFolderSelect);
            panelHeaderListView.Dock = DockStyle.Top;
            panelHeaderListView.Location = new Point(0, 0);
            panelHeaderListView.Name = "panelHeaderListView";
            panelHeaderListView.Size = new Size(905, 36);
            panelHeaderListView.TabIndex = 3;
            // 
            // panelToolbar
            // 
            panelToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelToolbar.BackColor = Color.LightGoldenrodYellow;
            panelToolbar.BottomRightOffset = 0;
            panelToolbar.BottomRightXOffset = 0;
            panelToolbar.Controls.Add(cbEnableVideoFilter);
            panelToolbar.Controls.Add(cbEnableImageFilter);
            panelToolbar.Controls.Add(cbEnableScriptFilter);
            panelToolbar.Controls.Add(btnViewGrid);
            panelToolbar.Controls.Add(btnViewTile);
            panelToolbar.Controls.Add(btnViewList);
            panelToolbar.Controls.Add(cbUseRecent);
            panelToolbar.Controls.Add(cbIncludeSubfolders);
            panelToolbar.Controls.Add(btnIncreaseSize);
            panelToolbar.Controls.Add(btnResetSize);
            panelToolbar.Controls.Add(btnDecreaseSize);
            panelToolbar.Controls.Add(tbCount);
            panelToolbar.Location = new Point(0, 0);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(750, 36);
            panelToolbar.TabIndex = 14;
            panelToolbar.TopLeftXOffset = 0;
            panelToolbar.TopRightOffset = 0;
            panelToolbar.TopRightXOffset = 20;
            // 
            // cbEnableVideoFilter
            // 
            cbEnableVideoFilter.Appearance = Appearance.Button;
            cbEnableVideoFilter.BackColor = Color.Transparent;
            cbEnableVideoFilter.CheckedBackColor = Color.PaleGreen;
            cbEnableVideoFilter.FlatAppearance.BorderSize = 0;
            cbEnableVideoFilter.FlatStyle = FlatStyle.Flat;
            cbEnableVideoFilter.Image = (Image)resources.GetObject("cbEnableVideoFilter.Image");
            cbEnableVideoFilter.Location = new Point(276, 3);
            cbEnableVideoFilter.Name = "cbEnableVideoFilter";
            cbEnableVideoFilter.Size = new Size(30, 30);
            cbEnableVideoFilter.TabIndex = 22;
            cbEnableVideoFilter.Text = "roundedImageCheckBox3";
            cbEnableVideoFilter.UncheckedBackColor = Color.LightGoldenrodYellow;
            cbEnableVideoFilter.UseVisualStyleBackColor = false;
            cbEnableVideoFilter.CheckedChanged += cbEnableVideoFilter_CheckedChanged;
            // 
            // cbEnableImageFilter
            // 
            cbEnableImageFilter.Appearance = Appearance.Button;
            cbEnableImageFilter.BackColor = Color.Transparent;
            cbEnableImageFilter.CheckedBackColor = Color.LightCoral;
            cbEnableImageFilter.FlatAppearance.BorderSize = 0;
            cbEnableImageFilter.FlatStyle = FlatStyle.Flat;
            cbEnableImageFilter.Image = (Image)resources.GetObject("cbEnableImageFilter.Image");
            cbEnableImageFilter.Location = new Point(312, 3);
            cbEnableImageFilter.Name = "cbEnableImageFilter";
            cbEnableImageFilter.Size = new Size(30, 30);
            cbEnableImageFilter.TabIndex = 23;
            cbEnableImageFilter.Text = "roundedImageCheckBox2";
            cbEnableImageFilter.UncheckedBackColor = Color.LightGoldenrodYellow;
            cbEnableImageFilter.UseVisualStyleBackColor = false;
            cbEnableImageFilter.CheckedChanged += cbEnableImageFilter_CheckedChanged;
            // 
            // cbEnableScriptFilter
            // 
            cbEnableScriptFilter.Appearance = Appearance.Button;
            cbEnableScriptFilter.BackColor = Color.Transparent;
            cbEnableScriptFilter.CheckedBackColor = Color.DeepSkyBlue;
            cbEnableScriptFilter.FlatAppearance.BorderSize = 0;
            cbEnableScriptFilter.FlatStyle = FlatStyle.Flat;
            cbEnableScriptFilter.Image = (Image)resources.GetObject("cbEnableScriptFilter.Image");
            cbEnableScriptFilter.Location = new Point(348, 3);
            cbEnableScriptFilter.Name = "cbEnableScriptFilter";
            cbEnableScriptFilter.Size = new Size(30, 30);
            cbEnableScriptFilter.TabIndex = 24;
            cbEnableScriptFilter.Text = "roundedImageCheckBox1";
            cbEnableScriptFilter.UncheckedBackColor = Color.LightGoldenrodYellow;
            cbEnableScriptFilter.UseVisualStyleBackColor = false;
            cbEnableScriptFilter.CheckedChanged += cbEnableScriptFilter_CheckedChanged;
            // 
            // btnViewGrid
            // 
            btnViewGrid.FlatAppearance.BorderSize = 0;
            btnViewGrid.FlatStyle = FlatStyle.Flat;
            btnViewGrid.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewGrid.IconChar = FontAwesome.Sharp.IconChar.ThLarge;
            btnViewGrid.IconColor = Color.Black;
            btnViewGrid.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewGrid.IconSize = 30;
            btnViewGrid.Location = new Point(214, 3);
            btnViewGrid.Name = "btnViewGrid";
            btnViewGrid.Size = new Size(30, 30);
            btnViewGrid.TabIndex = 21;
            btnViewGrid.UseVisualStyleBackColor = true;
            btnViewGrid.Click += btnViewGrid_Click;
            // 
            // btnViewTile
            // 
            btnViewTile.FlatAppearance.BorderSize = 0;
            btnViewTile.FlatStyle = FlatStyle.Flat;
            btnViewTile.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewTile.IconChar = FontAwesome.Sharp.IconChar.TableCells;
            btnViewTile.IconColor = Color.Black;
            btnViewTile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewTile.IconSize = 30;
            btnViewTile.Location = new Point(178, 3);
            btnViewTile.Name = "btnViewTile";
            btnViewTile.Size = new Size(30, 30);
            btnViewTile.TabIndex = 20;
            btnViewTile.UseVisualStyleBackColor = true;
            btnViewTile.Click += btnViewTile_Click;
            // 
            // btnViewList
            // 
            btnViewList.FlatAppearance.BorderSize = 0;
            btnViewList.FlatStyle = FlatStyle.Flat;
            btnViewList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewList.IconChar = FontAwesome.Sharp.IconChar.TableList;
            btnViewList.IconColor = Color.Black;
            btnViewList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewList.IconSize = 30;
            btnViewList.Location = new Point(142, 3);
            btnViewList.Name = "btnViewList";
            btnViewList.Size = new Size(30, 30);
            btnViewList.TabIndex = 19;
            btnViewList.UseVisualStyleBackColor = true;
            btnViewList.Click += btnViewList_Click;
            // 
            // cbUseRecent
            // 
            cbUseRecent.Appearance = Appearance.Button;
            cbUseRecent.BackColor = Color.Transparent;
            cbUseRecent.CheckedBackColor = Color.Gold;
            cbUseRecent.FlatAppearance.BorderSize = 0;
            cbUseRecent.FlatStyle = FlatStyle.Flat;
            cbUseRecent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            cbUseRecent.Location = new Point(540, 5);
            cbUseRecent.Name = "cbUseRecent";
            cbUseRecent.Size = new Size(140, 25);
            cbUseRecent.TabIndex = 26;
            cbUseRecent.Text = "Only latest X files";
            cbUseRecent.UncheckedBackColor = Color.LightGoldenrodYellow;
            cbUseRecent.UncheckedForeColor = Color.Black;
            cbUseRecent.UseVisualStyleBackColor = false;
            // 
            // cbIncludeSubfolders
            // 
            cbIncludeSubfolders.Appearance = Appearance.Button;
            cbIncludeSubfolders.BackColor = Color.Transparent;
            cbIncludeSubfolders.CheckedBackColor = Color.Gold;
            cbIncludeSubfolders.FlatAppearance.BorderSize = 0;
            cbIncludeSubfolders.FlatStyle = FlatStyle.Flat;
            cbIncludeSubfolders.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            cbIncludeSubfolders.Location = new Point(404, 6);
            cbIncludeSubfolders.Name = "cbIncludeSubfolders";
            cbIncludeSubfolders.Size = new Size(130, 25);
            cbIncludeSubfolders.TabIndex = 25;
            cbIncludeSubfolders.Text = "Include Subfolders";
            cbIncludeSubfolders.UncheckedBackColor = Color.LightGoldenrodYellow;
            cbIncludeSubfolders.UncheckedForeColor = Color.Black;
            cbIncludeSubfolders.UseVisualStyleBackColor = false;
            // 
            // btnIncreaseSize
            // 
            btnIncreaseSize.FlatAppearance.BorderSize = 0;
            btnIncreaseSize.FlatStyle = FlatStyle.Flat;
            btnIncreaseSize.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            btnIncreaseSize.IconColor = Color.Black;
            btnIncreaseSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIncreaseSize.IconSize = 26;
            btnIncreaseSize.Location = new Point(82, 3);
            btnIncreaseSize.Name = "btnIncreaseSize";
            btnIncreaseSize.Size = new Size(30, 30);
            btnIncreaseSize.TabIndex = 16;
            btnIncreaseSize.UseVisualStyleBackColor = true;
            btnIncreaseSize.Click += btnIncreaseSize_Click;
            // 
            // btnResetSize
            // 
            btnResetSize.FlatAppearance.BorderSize = 0;
            btnResetSize.FlatStyle = FlatStyle.Flat;
            btnResetSize.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnResetSize.IconColor = Color.Black;
            btnResetSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnResetSize.IconSize = 26;
            btnResetSize.Location = new Point(46, 3);
            btnResetSize.Name = "btnResetSize";
            btnResetSize.Size = new Size(30, 30);
            btnResetSize.TabIndex = 15;
            btnResetSize.UseVisualStyleBackColor = true;
            btnResetSize.Click += btnResetSize_Click;
            // 
            // btnDecreaseSize
            // 
            btnDecreaseSize.FlatAppearance.BorderSize = 0;
            btnDecreaseSize.FlatStyle = FlatStyle.Flat;
            btnDecreaseSize.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassMinus;
            btnDecreaseSize.IconColor = Color.Black;
            btnDecreaseSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDecreaseSize.IconSize = 26;
            btnDecreaseSize.Location = new Point(10, 3);
            btnDecreaseSize.Name = "btnDecreaseSize";
            btnDecreaseSize.Size = new Size(30, 30);
            btnDecreaseSize.TabIndex = 14;
            btnDecreaseSize.UseVisualStyleBackColor = true;
            btnDecreaseSize.Click += btnDecreaseSize_Click;
            // 
            // tbCount
            // 
            tbCount.BackColor = Color.LightYellow;
            tbCount.BorderStyle = BorderStyle.FixedSingle;
            tbCount.Location = new Point(686, 7);
            tbCount.Name = "tbCount";
            tbCount.Size = new Size(32, 23);
            tbCount.TabIndex = 27;
            tbCount.Text = "50";
            tbCount.TextAlign = HorizontalAlignment.Center;
            tbCount.TextChanged += tbCount_TextChanged;
            // 
            // btnFolderSelect
            // 
            btnFolderSelect.BackColor = Color.Gold;
            btnFolderSelect.Dock = DockStyle.Right;
            btnFolderSelect.FlatAppearance.BorderSize = 0;
            btnFolderSelect.FlatStyle = FlatStyle.Flat;
            btnFolderSelect.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFolderSelect.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnFolderSelect.IconColor = Color.Black;
            btnFolderSelect.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFolderSelect.IconSize = 24;
            btnFolderSelect.ImageAlign = ContentAlignment.MiddleRight;
            btnFolderSelect.Location = new Point(724, 0);
            btnFolderSelect.Name = "btnFolderSelect";
            btnFolderSelect.Size = new Size(181, 36);
            btnFolderSelect.TabIndex = 7;
            btnFolderSelect.Text = "Play current Folder";
            btnFolderSelect.UseVisualStyleBackColor = false;
            btnFolderSelect.Click += btnFolderSelect_Click;
            // 
            // lblFavorites
            // 
            lblFavorites.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblFavorites.Location = new Point(0, 249);
            lblFavorites.Margin = new Padding(3);
            lblFavorites.Name = "lblFavorites";
            lblFavorites.Size = new Size(126, 36);
            lblFavorites.TabIndex = 16;
            lblFavorites.Text = "Favorites";
            lblFavorites.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNavigation
            // 
            lblNavigation.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblNavigation.Location = new Point(0, 36);
            lblNavigation.Margin = new Padding(3);
            lblNavigation.Name = "lblNavigation";
            lblNavigation.Size = new Size(126, 36);
            lblNavigation.TabIndex = 15;
            lblNavigation.Text = "Navigation";
            lblNavigation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbFavorites
            // 
            lbFavorites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbFavorites.BackColor = Color.LightYellow;
            lbFavorites.BorderStyle = BorderStyle.None;
            lbFavorites.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbFavorites.FormattingEnabled = true;
            lbFavorites.ItemHeight = 15;
            lbFavorites.Location = new Point(0, 321);
            lbFavorites.Name = "lbFavorites";
            lbFavorites.Size = new Size(126, 210);
            lbFavorites.TabIndex = 10;
            lbFavorites.DoubleClick += lbFavorites_DoubleClick;
            lbFavorites.MouseMove += lbFavorites_MouseMove;
            // 
            // lbDriveFolders
            // 
            lbDriveFolders.BackColor = Color.LightYellow;
            lbDriveFolders.BorderStyle = BorderStyle.None;
            lbDriveFolders.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbDriveFolders.FormattingEnabled = true;
            lbDriveFolders.ItemHeight = 15;
            lbDriveFolders.Location = new Point(0, 78);
            lbDriveFolders.Name = "lbDriveFolders";
            lbDriveFolders.Size = new Size(126, 165);
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
            // tbPathView
            // 
            tbPathView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPathView.BackColor = Color.LightYellow;
            tbPathView.BorderStyle = BorderStyle.FixedSingle;
            tbPathView.Location = new Point(40, 6);
            tbPathView.Name = "tbPathView";
            tbPathView.ReadOnly = true;
            tbPathView.Size = new Size(991, 23);
            tbPathView.TabIndex = 1;
            // 
            // btnDeleteFav
            // 
            btnDeleteFav.FlatAppearance.BorderSize = 0;
            btnDeleteFav.FlatStyle = FlatStyle.Flat;
            btnDeleteFav.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDeleteFav.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
            btnDeleteFav.IconColor = Color.Black;
            btnDeleteFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteFav.IconSize = 26;
            btnDeleteFav.Location = new Point(15, 285);
            btnDeleteFav.Margin = new Padding(15, 3, 3, 3);
            btnDeleteFav.Name = "btnDeleteFav";
            btnDeleteFav.Size = new Size(30, 30);
            btnDeleteFav.TabIndex = 12;
            btnDeleteFav.UseVisualStyleBackColor = true;
            btnDeleteFav.Click += btnDeleteFav_Click;
            // 
            // btnAddFav
            // 
            btnAddFav.FlatAppearance.BorderSize = 0;
            btnAddFav.FlatStyle = FlatStyle.Flat;
            btnAddFav.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddFav.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddFav.IconColor = Color.Black;
            btnAddFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddFav.IconSize = 26;
            btnAddFav.Location = new Point(78, 285);
            btnAddFav.Margin = new Padding(3, 3, 15, 3);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(30, 30);
            btnAddFav.TabIndex = 11;
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "folder.png");
            imageList.Images.SetKeyName(1, "film.png");
            imageList.Images.SetKeyName(2, "image-48.png");
            // 
            // FolderBrowserView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 561);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            MinimumSize = new Size(1050, 600);
            Name = "FolderBrowserView";
            Text = "FolderBrowserView";
            FormClosing += FolderBrowserView_FormClosing;
            Load += FolderBrowserView_Load;
            Resize += FolderBrowserView_Resize;
            panelTop.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelMain.ResumeLayout(false);
            panelHeaderListView.ResumeLayout(false);
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
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
        private TextBox tbCount;
        private FontAwesome.Sharp.IconButton btnFolderSelect;
        private ListBox lbFavorites;
        private FontAwesome.Sharp.IconButton btnDeleteFav;
        private FontAwesome.Sharp.IconButton btnAddFav;
        private ToolTip toolTipInfo;
        private Controls.CustomPanel panelToolbar;
        private ImageList imageListMedium;
        private FontAwesome.Sharp.IconButton btnDecreaseSize;
        private FontAwesome.Sharp.IconButton btnIncreaseSize;
        private FontAwesome.Sharp.IconButton btnResetSize;
        private Controls.RoundedCheckBox cbIncludeSubfolders;
        private Controls.RoundedCheckBox cbUseRecent;
        private Label lblNavigation;
        private Label lblFavorites;
        private Panel panelMain;
        private Panel panelHeaderListView;
        private FontAwesome.Sharp.IconButton btnViewList;
        private FontAwesome.Sharp.IconButton btnViewGrid;
        private FontAwesome.Sharp.IconButton btnViewTile;
        private ColumnHeader columnHeader1;
        private Controls.RoundedImageCheckBox cbEnableScriptFilter;
        private Controls.RoundedImageCheckBox cbEnableVideoFilter;
        private Controls.RoundedImageCheckBox cbEnableImageFilter;
    }
}