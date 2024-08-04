namespace RandomVideoPlayer.View
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
            panel2 = new Panel();
            lvFileExplore = new ListView();
            columnHeader1 = new ColumnHeader();
            imageListMedium = new ImageList(components);
            panel3 = new Panel();
            customPanel1 = new Controls.CustomPanel();
            btnViewGrid = new FontAwesome.Sharp.IconButton();
            btnViewTile = new FontAwesome.Sharp.IconButton();
            btnViewList = new FontAwesome.Sharp.IconButton();
            cbUseRecent = new Controls.RoundedCheckBox();
            cbIncludeSubfolders = new Controls.RoundedCheckBox();
            btnIncreaseSize = new FontAwesome.Sharp.IconButton();
            btnResetSize = new FontAwesome.Sharp.IconButton();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            btnDecreaseSize = new FontAwesome.Sharp.IconButton();
            btnAddFav = new FontAwesome.Sharp.IconButton();
            tbCount = new TextBox();
            btnFolderSelect = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label3 = new Label();
            lbFavorites = new ListBox();
            lbDriveFolders = new ListBox();
            btnBack = new FontAwesome.Sharp.IconButton();
            tbPathView = new TextBox();
            imageList = new ImageList(components);
            toolTipInfo = new ToolTip(components);
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            customPanel1.SuspendLayout();
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
            panelTop.Size = new Size(984, 20);
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
            btnClose.Location = new Point(954, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitleBar
            // 
            lblTitleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleBar.BackColor = Color.FromArgb(255, 221, 26);
            lblTitleBar.Location = new Point(40, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Size = new Size(908, 20);
            lblTitleBar.TabIndex = 0;
            lblTitleBar.Text = "RVP - Folder Browser";
            lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
            lblTitleBar.MouseDown += lblTitleBar_MouseDown;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightYellow;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lbFavorites);
            panel1.Controls.Add(lbDriveFolders);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(tbPathView);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 541);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(lvFileExplore);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(126, 36);
            panel2.Name = "panel2";
            panel2.Size = new Size(855, 505);
            panel2.TabIndex = 17;
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
            lvFileExplore.Size = new Size(855, 469);
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
            // panel3
            // 
            panel3.Controls.Add(customPanel1);
            panel3.Controls.Add(btnFolderSelect);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(855, 36);
            panel3.TabIndex = 3;
            // 
            // customPanel1
            // 
            customPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            customPanel1.BackColor = Color.LightGoldenrodYellow;
            customPanel1.BottomRightOffset = 0;
            customPanel1.BottomRightXOffset = 0;
            customPanel1.Controls.Add(btnViewGrid);
            customPanel1.Controls.Add(btnViewTile);
            customPanel1.Controls.Add(btnViewList);
            customPanel1.Controls.Add(cbUseRecent);
            customPanel1.Controls.Add(cbIncludeSubfolders);
            customPanel1.Controls.Add(btnIncreaseSize);
            customPanel1.Controls.Add(btnResetSize);
            customPanel1.Controls.Add(btnDeleteFav);
            customPanel1.Controls.Add(btnDecreaseSize);
            customPanel1.Controls.Add(btnAddFav);
            customPanel1.Controls.Add(tbCount);
            customPanel1.Location = new Point(0, 0);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(700, 36);
            customPanel1.TabIndex = 14;
            customPanel1.TopLeftXOffset = 20;
            customPanel1.TopRightOffset = 0;
            customPanel1.TopRightXOffset = 20;
            // 
            // btnViewGrid
            // 
            btnViewGrid.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewGrid.FlatAppearance.BorderSize = 0;
            btnViewGrid.FlatStyle = FlatStyle.Flat;
            btnViewGrid.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewGrid.IconChar = FontAwesome.Sharp.IconChar.TableCellsLarge;
            btnViewGrid.IconColor = Color.Black;
            btnViewGrid.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewGrid.IconSize = 30;
            btnViewGrid.Location = new Point(318, 3);
            btnViewGrid.Name = "btnViewGrid";
            btnViewGrid.Size = new Size(30, 30);
            btnViewGrid.TabIndex = 21;
            btnViewGrid.UseVisualStyleBackColor = true;
            btnViewGrid.Click += btnViewGrid_Click;
            // 
            // btnViewTile
            // 
            btnViewTile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewTile.FlatAppearance.BorderSize = 0;
            btnViewTile.FlatStyle = FlatStyle.Flat;
            btnViewTile.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewTile.IconChar = FontAwesome.Sharp.IconChar.TableCells;
            btnViewTile.IconColor = Color.Black;
            btnViewTile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewTile.IconSize = 30;
            btnViewTile.Location = new Point(282, 3);
            btnViewTile.Name = "btnViewTile";
            btnViewTile.Size = new Size(30, 30);
            btnViewTile.TabIndex = 20;
            btnViewTile.UseVisualStyleBackColor = true;
            btnViewTile.Click += btnViewTile_Click;
            // 
            // btnViewList
            // 
            btnViewList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewList.FlatAppearance.BorderSize = 0;
            btnViewList.FlatStyle = FlatStyle.Flat;
            btnViewList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewList.IconChar = FontAwesome.Sharp.IconChar.TableList;
            btnViewList.IconColor = Color.Black;
            btnViewList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewList.IconSize = 30;
            btnViewList.Location = new Point(246, 3);
            btnViewList.Name = "btnViewList";
            btnViewList.Size = new Size(30, 30);
            btnViewList.TabIndex = 19;
            btnViewList.UseVisualStyleBackColor = true;
            btnViewList.Click += btnViewList_Click;
            // 
            // cbUseRecent
            // 
            cbUseRecent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbUseRecent.Appearance = Appearance.Button;
            cbUseRecent.BackColor = Color.Transparent;
            cbUseRecent.CheckedBackColor = Color.Gold;
            cbUseRecent.FlatAppearance.BorderSize = 0;
            cbUseRecent.FlatStyle = FlatStyle.Flat;
            cbUseRecent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbUseRecent.Location = new Point(490, 5);
            cbUseRecent.Name = "cbUseRecent";
            cbUseRecent.Size = new Size(140, 25);
            cbUseRecent.TabIndex = 18;
            cbUseRecent.Text = "Only latest X files";
            cbUseRecent.UncheckedBackColor = Color.LightGoldenrodYellow;
            cbUseRecent.UseVisualStyleBackColor = false;
            // 
            // cbIncludeSubfolders
            // 
            cbIncludeSubfolders.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbIncludeSubfolders.Appearance = Appearance.Button;
            cbIncludeSubfolders.BackColor = Color.Transparent;
            cbIncludeSubfolders.CheckedBackColor = Color.Gold;
            cbIncludeSubfolders.FlatAppearance.BorderSize = 0;
            cbIncludeSubfolders.FlatStyle = FlatStyle.Flat;
            cbIncludeSubfolders.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbIncludeSubfolders.Location = new Point(354, 6);
            cbIncludeSubfolders.Name = "cbIncludeSubfolders";
            cbIncludeSubfolders.Size = new Size(130, 25);
            cbIncludeSubfolders.TabIndex = 17;
            cbIncludeSubfolders.Text = "Include Subfolders";
            cbIncludeSubfolders.UncheckedBackColor = Color.LightGoldenrodYellow;
            cbIncludeSubfolders.UseVisualStyleBackColor = false;
            // 
            // btnIncreaseSize
            // 
            btnIncreaseSize.FlatAppearance.BorderSize = 0;
            btnIncreaseSize.FlatStyle = FlatStyle.Flat;
            btnIncreaseSize.IconChar = FontAwesome.Sharp.IconChar.SearchPlus;
            btnIncreaseSize.IconColor = Color.Black;
            btnIncreaseSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIncreaseSize.IconSize = 26;
            btnIncreaseSize.Location = new Point(96, 3);
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
            btnResetSize.Location = new Point(60, 3);
            btnResetSize.Name = "btnResetSize";
            btnResetSize.Size = new Size(30, 30);
            btnResetSize.TabIndex = 15;
            btnResetSize.UseVisualStyleBackColor = true;
            btnResetSize.Click += btnResetSize_Click;
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
            btnDeleteFav.IconSize = 26;
            btnDeleteFav.Location = new Point(154, 3);
            btnDeleteFav.Name = "btnDeleteFav";
            btnDeleteFav.Size = new Size(30, 30);
            btnDeleteFav.TabIndex = 12;
            btnDeleteFav.UseVisualStyleBackColor = true;
            btnDeleteFav.Click += btnDeleteFav_Click;
            // 
            // btnDecreaseSize
            // 
            btnDecreaseSize.FlatAppearance.BorderSize = 0;
            btnDecreaseSize.FlatStyle = FlatStyle.Flat;
            btnDecreaseSize.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassMinus;
            btnDecreaseSize.IconColor = Color.Black;
            btnDecreaseSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDecreaseSize.IconSize = 26;
            btnDecreaseSize.Location = new Point(24, 3);
            btnDecreaseSize.Name = "btnDecreaseSize";
            btnDecreaseSize.Size = new Size(30, 30);
            btnDecreaseSize.TabIndex = 14;
            btnDecreaseSize.UseVisualStyleBackColor = true;
            btnDecreaseSize.Click += btnDecreaseSize_Click;
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
            btnAddFav.IconSize = 26;
            btnAddFav.Location = new Point(190, 3);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(30, 30);
            btnAddFav.TabIndex = 11;
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // tbCount
            // 
            tbCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbCount.BackColor = Color.LightYellow;
            tbCount.Location = new Point(636, 7);
            tbCount.Name = "tbCount";
            tbCount.Size = new Size(32, 23);
            tbCount.TabIndex = 5;
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
            btnFolderSelect.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnFolderSelect.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnFolderSelect.IconColor = Color.Black;
            btnFolderSelect.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFolderSelect.IconSize = 24;
            btnFolderSelect.ImageAlign = ContentAlignment.MiddleRight;
            btnFolderSelect.Location = new Point(674, 0);
            btnFolderSelect.Name = "btnFolderSelect";
            btnFolderSelect.Size = new Size(181, 36);
            btnFolderSelect.TabIndex = 7;
            btnFolderSelect.Text = "Play current Folder";
            btnFolderSelect.UseVisualStyleBackColor = false;
            btnFolderSelect.Click += btnFolderSelect_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 249);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(126, 36);
            label1.TabIndex = 16;
            label1.Text = "Favorites";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 36);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(126, 36);
            label3.TabIndex = 15;
            label3.Text = "Navigation";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbFavorites
            // 
            lbFavorites.BackColor = Color.LightYellow;
            lbFavorites.BorderStyle = BorderStyle.None;
            lbFavorites.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbFavorites.FormattingEnabled = true;
            lbFavorites.ItemHeight = 15;
            lbFavorites.Location = new Point(0, 291);
            lbFavorites.Name = "lbFavorites";
            lbFavorites.Size = new Size(126, 240);
            lbFavorites.TabIndex = 10;
            lbFavorites.DoubleClick += lbFavorites_DoubleClick;
            lbFavorites.MouseMove += lbFavorites_MouseMove;
            // 
            // lbDriveFolders
            // 
            lbDriveFolders.BackColor = Color.LightYellow;
            lbDriveFolders.BorderStyle = BorderStyle.None;
            lbDriveFolders.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            tbPathView.Location = new Point(40, 6);
            tbPathView.Name = "tbPathView";
            tbPathView.ReadOnly = true;
            tbPathView.Size = new Size(941, 23);
            tbPathView.TabIndex = 1;
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
            ClientSize = new Size(984, 561);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            MinimumSize = new Size(1000, 600);
            Name = "FolderBrowserView";
            Text = "FolderBrowserView";
            FormClosing += FolderBrowserView_FormClosing;
            Load += FolderBrowserView_Load;
            Resize += FolderBrowserView_Resize;
            panelTop.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            customPanel1.ResumeLayout(false);
            customPanel1.PerformLayout();
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
        private Controls.CustomPanel customPanel1;
        private ImageList imageListMedium;
        private FontAwesome.Sharp.IconButton btnDecreaseSize;
        private FontAwesome.Sharp.IconButton btnIncreaseSize;
        private FontAwesome.Sharp.IconButton btnResetSize;
        private Controls.RoundedCheckBox cbIncludeSubfolders;
        private Controls.RoundedCheckBox cbUseRecent;
        private Label label3;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton btnViewList;
        private FontAwesome.Sharp.IconButton btnViewGrid;
        private FontAwesome.Sharp.IconButton btnViewTile;
        private ColumnHeader columnHeader1;
    }
}