namespace RandomVideoPlayer.View
{
    partial class ListBrowserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListBrowserView));
            panelTop = new Panel();
            lblTitle = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelBody = new Panel();
            label2 = new Label();
            label1 = new Label();
            lbFavorites = new ListBox();
            splitContainerBody = new SplitContainer();
            lvFileExplore = new ListView();
            columnHeader2 = new ColumnHeader();
            imageListLarge = new ImageList(components);
            panel2 = new Panel();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            btnAddFav = new FontAwesome.Sharp.IconButton();
            btnViewList = new FontAwesome.Sharp.IconButton();
            btnViewTile = new FontAwesome.Sharp.IconButton();
            btnIncreaseSize = new FontAwesome.Sharp.IconButton();
            btnViewGrid = new FontAwesome.Sharp.IconButton();
            btnResetSize = new FontAwesome.Sharp.IconButton();
            btnDecreaseSize = new FontAwesome.Sharp.IconButton();
            btnAddFromPlaylist = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            panelCustomListToolbar = new Controls.CustomPanel();
            cbShowIcons = new Controls.RoundedCheckBox();
            cbFullPath = new Controls.RoundedCheckBox();
            customPanel2 = new Controls.CustomPanel();
            label4 = new Label();
            btnUseList = new FontAwesome.Sharp.IconButton();
            customPanel1 = new Controls.CustomPanel();
            btnAddAll = new FontAwesome.Sharp.IconButton();
            btnAddSelected = new FontAwesome.Sharp.IconButton();
            panelFilterExt = new Controls.CustomPanel();
            cbAVIF = new Controls.RoundedCheckBox();
            cbWEBP = new Controls.RoundedCheckBox();
            cbTIFF = new Controls.RoundedCheckBox();
            cbTIF = new Controls.RoundedCheckBox();
            cbBMP = new Controls.RoundedCheckBox();
            cbGIF = new Controls.RoundedCheckBox();
            cbPNG = new Controls.RoundedCheckBox();
            cbJPEG = new Controls.RoundedCheckBox();
            cbJPG = new Controls.RoundedCheckBox();
            cbAVCHD = new Controls.RoundedCheckBox();
            cbWEBM = new Controls.RoundedCheckBox();
            cbMP4 = new Controls.RoundedCheckBox();
            cbF4V = new Controls.RoundedCheckBox();
            cbFLV = new Controls.RoundedCheckBox();
            cbWMV = new Controls.RoundedCheckBox();
            cbM4V = new Controls.RoundedCheckBox();
            cbMKV = new Controls.RoundedCheckBox();
            cbMOV = new Controls.RoundedCheckBox();
            cbAVI = new Controls.RoundedCheckBox();
            label3 = new Label();
            lvCustomList = new ListView();
            columnHeader1 = new ColumnHeader();
            btnSaveList = new FontAwesome.Sharp.IconButton();
            btnClearList = new FontAwesome.Sharp.IconButton();
            btnDelDuplicates = new FontAwesome.Sharp.IconButton();
            btnClearSelected = new FontAwesome.Sharp.IconButton();
            btnLoadList = new FontAwesome.Sharp.IconButton();
            tbPathView = new TextBox();
            btnBack = new FontAwesome.Sharp.IconButton();
            lbDriveFolders = new ListBox();
            imageListSmall = new ImageList(components);
            fbDialog = new FolderBrowserDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            toolTipInfo = new ToolTip(components);
            panelTop.SuspendLayout();
            panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerBody).BeginInit();
            splitContainerBody.Panel1.SuspendLayout();
            splitContainerBody.Panel2.SuspendLayout();
            splitContainerBody.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelCustomListToolbar.SuspendLayout();
            customPanel2.SuspendLayout();
            customPanel1.SuspendLayout();
            panelFilterExt.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(248, 111, 100);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1199, 20);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(33, 1);
            lblTitle.Margin = new Padding(33, 0, 3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1130, 19);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "RVP - ListBrowser";
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
            btnClose.Location = new Point(1169, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.MistyRose;
            panelBody.Controls.Add(label2);
            panelBody.Controls.Add(label1);
            panelBody.Controls.Add(lbFavorites);
            panelBody.Controls.Add(splitContainerBody);
            panelBody.Controls.Add(tbPathView);
            panelBody.Controls.Add(btnBack);
            panelBody.Controls.Add(lbDriveFolders);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 20);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1199, 701);
            panelBody.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 278);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(125, 36);
            label2.TabIndex = 22;
            label2.Text = "Favorites";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 35);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(125, 36);
            label1.TabIndex = 21;
            label1.Text = "Navigation";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbFavorites
            // 
            lbFavorites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbFavorites.BackColor = Color.MistyRose;
            lbFavorites.BorderStyle = BorderStyle.None;
            lbFavorites.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbFavorites.FormattingEnabled = true;
            lbFavorites.ItemHeight = 15;
            lbFavorites.Location = new Point(-1, 320);
            lbFavorites.Name = "lbFavorites";
            lbFavorites.Size = new Size(126, 375);
            lbFavorites.TabIndex = 20;
            lbFavorites.DoubleClick += lbFavorites_DoubleClick;
            lbFavorites.MouseMove += lbFavorites_MouseMove;
            // 
            // splitContainerBody
            // 
            splitContainerBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerBody.Location = new Point(126, 35);
            splitContainerBody.Name = "splitContainerBody";
            // 
            // splitContainerBody.Panel1
            // 
            splitContainerBody.Panel1.Controls.Add(lvFileExplore);
            splitContainerBody.Panel1.Controls.Add(panel2);
            // 
            // splitContainerBody.Panel2
            // 
            splitContainerBody.Panel2.BackColor = Color.MintCream;
            splitContainerBody.Panel2.Controls.Add(btnAddFromPlaylist);
            splitContainerBody.Panel2.Controls.Add(panel1);
            splitContainerBody.Panel2.Controls.Add(customPanel1);
            splitContainerBody.Panel2.Controls.Add(panelFilterExt);
            splitContainerBody.Panel2.Controls.Add(lvCustomList);
            splitContainerBody.Panel2.Controls.Add(btnSaveList);
            splitContainerBody.Panel2.Controls.Add(btnClearList);
            splitContainerBody.Panel2.Controls.Add(btnDelDuplicates);
            splitContainerBody.Panel2.Controls.Add(btnClearSelected);
            splitContainerBody.Panel2.Controls.Add(btnLoadList);
            splitContainerBody.Size = new Size(1070, 666);
            splitContainerBody.SplitterDistance = 468;
            splitContainerBody.TabIndex = 6;
            // 
            // lvFileExplore
            // 
            lvFileExplore.BackColor = Color.MistyRose;
            lvFileExplore.BorderStyle = BorderStyle.None;
            lvFileExplore.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            lvFileExplore.Dock = DockStyle.Fill;
            lvFileExplore.HeaderStyle = ColumnHeaderStyle.None;
            lvFileExplore.LargeImageList = imageListLarge;
            lvFileExplore.Location = new Point(0, 36);
            lvFileExplore.Name = "lvFileExplore";
            lvFileExplore.ShowItemToolTips = true;
            lvFileExplore.Size = new Size(468, 630);
            lvFileExplore.SmallImageList = imageListLarge;
            lvFileExplore.TabIndex = 0;
            lvFileExplore.UseCompatibleStateImageBehavior = false;
            lvFileExplore.ItemActivate += lvFileExplore_ItemActivate;
            lvFileExplore.ItemDrag += lvFileExplore_ItemDrag;
            lvFileExplore.MouseDown += lvFileExplore_MouseDown;
            lvFileExplore.Resize += lvFileExplore_Resize;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Dummy";
            columnHeader2.Width = 250;
            // 
            // imageListLarge
            // 
            imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
            imageListLarge.ImageStream = (ImageListStreamer)resources.GetObject("imageListLarge.ImageStream");
            imageListLarge.TransparentColor = Color.Transparent;
            imageListLarge.Images.SetKeyName(0, "folder.png");
            imageListLarge.Images.SetKeyName(1, "avi.png");
            imageListLarge.Images.SetKeyName(2, "flv.png");
            imageListLarge.Images.SetKeyName(3, "m4v.png");
            imageListLarge.Images.SetKeyName(4, "mkv.png");
            imageListLarge.Images.SetKeyName(5, "mov.png");
            imageListLarge.Images.SetKeyName(6, "mp4.png");
            imageListLarge.Images.SetKeyName(7, "webm.png");
            imageListLarge.Images.SetKeyName(8, "wmv.png");
            imageListLarge.Images.SetKeyName(9, "f4v.png");
            imageListLarge.Images.SetKeyName(10, "avchd.png");
            imageListLarge.Images.SetKeyName(11, "jpg.png");
            imageListLarge.Images.SetKeyName(12, "jpeg.png");
            imageListLarge.Images.SetKeyName(13, "png.png");
            imageListLarge.Images.SetKeyName(14, "gif.png");
            imageListLarge.Images.SetKeyName(15, "tif.png");
            imageListLarge.Images.SetKeyName(16, "tiff.png");
            imageListLarge.Images.SetKeyName(17, "bmp.png");
            imageListLarge.Images.SetKeyName(18, "webp.png");
            imageListLarge.Images.SetKeyName(19, "avif.png");
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDeleteFav);
            panel2.Controls.Add(btnAddFav);
            panel2.Controls.Add(btnViewList);
            panel2.Controls.Add(btnViewTile);
            panel2.Controls.Add(btnIncreaseSize);
            panel2.Controls.Add(btnViewGrid);
            panel2.Controls.Add(btnResetSize);
            panel2.Controls.Add(btnDecreaseSize);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(468, 36);
            panel2.TabIndex = 1;
            // 
            // btnDeleteFav
            // 
            btnDeleteFav.FlatAppearance.BorderSize = 0;
            btnDeleteFav.FlatStyle = FlatStyle.Flat;
            btnDeleteFav.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
            btnDeleteFav.IconColor = Color.Black;
            btnDeleteFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteFav.IconSize = 26;
            btnDeleteFav.Location = new Point(172, 3);
            btnDeleteFav.Name = "btnDeleteFav";
            btnDeleteFav.Size = new Size(30, 30);
            btnDeleteFav.TabIndex = 22;
            btnDeleteFav.UseVisualStyleBackColor = true;
            btnDeleteFav.Click += btnDeleteFav_Click;
            // 
            // btnAddFav
            // 
            btnAddFav.FlatAppearance.BorderSize = 0;
            btnAddFav.FlatStyle = FlatStyle.Flat;
            btnAddFav.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddFav.IconColor = Color.Black;
            btnAddFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddFav.IconSize = 26;
            btnAddFav.Location = new Point(218, 3);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(30, 30);
            btnAddFav.TabIndex = 21;
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // btnViewList
            // 
            btnViewList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewList.FlatAppearance.BorderSize = 0;
            btnViewList.FlatStyle = FlatStyle.Flat;
            btnViewList.IconChar = FontAwesome.Sharp.IconChar.TableList;
            btnViewList.IconColor = Color.Black;
            btnViewList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewList.IconSize = 30;
            btnViewList.Location = new Point(363, 3);
            btnViewList.Name = "btnViewList";
            btnViewList.Size = new Size(30, 30);
            btnViewList.TabIndex = 0;
            btnViewList.UseVisualStyleBackColor = true;
            btnViewList.Click += btnViewList_Click;
            // 
            // btnViewTile
            // 
            btnViewTile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewTile.FlatAppearance.BorderSize = 0;
            btnViewTile.FlatStyle = FlatStyle.Flat;
            btnViewTile.IconChar = FontAwesome.Sharp.IconChar.TableCells;
            btnViewTile.IconColor = Color.Black;
            btnViewTile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewTile.IconSize = 30;
            btnViewTile.Location = new Point(399, 3);
            btnViewTile.Name = "btnViewTile";
            btnViewTile.Size = new Size(30, 30);
            btnViewTile.TabIndex = 2;
            btnViewTile.UseVisualStyleBackColor = true;
            btnViewTile.Click += btnViewTile_Click;
            // 
            // btnIncreaseSize
            // 
            btnIncreaseSize.FlatAppearance.BorderSize = 0;
            btnIncreaseSize.FlatStyle = FlatStyle.Flat;
            btnIncreaseSize.IconChar = FontAwesome.Sharp.IconChar.SearchPlus;
            btnIncreaseSize.IconColor = Color.Black;
            btnIncreaseSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIncreaseSize.IconSize = 26;
            btnIncreaseSize.Location = new Point(78, 3);
            btnIncreaseSize.Name = "btnIncreaseSize";
            btnIncreaseSize.Size = new Size(30, 30);
            btnIncreaseSize.TabIndex = 4;
            btnIncreaseSize.UseVisualStyleBackColor = true;
            btnIncreaseSize.Click += btnIncreaseSize_Click;
            // 
            // btnViewGrid
            // 
            btnViewGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewGrid.FlatAppearance.BorderSize = 0;
            btnViewGrid.FlatStyle = FlatStyle.Flat;
            btnViewGrid.IconChar = FontAwesome.Sharp.IconChar.TableCellsLarge;
            btnViewGrid.IconColor = Color.Black;
            btnViewGrid.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewGrid.IconSize = 30;
            btnViewGrid.Location = new Point(435, 3);
            btnViewGrid.Name = "btnViewGrid";
            btnViewGrid.Size = new Size(30, 30);
            btnViewGrid.TabIndex = 1;
            btnViewGrid.UseVisualStyleBackColor = true;
            btnViewGrid.Click += btnViewGrid_Click;
            // 
            // btnResetSize
            // 
            btnResetSize.FlatAppearance.BorderSize = 0;
            btnResetSize.FlatStyle = FlatStyle.Flat;
            btnResetSize.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnResetSize.IconColor = Color.Black;
            btnResetSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnResetSize.IconSize = 26;
            btnResetSize.Location = new Point(42, 3);
            btnResetSize.Name = "btnResetSize";
            btnResetSize.Size = new Size(30, 30);
            btnResetSize.TabIndex = 5;
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
            btnDecreaseSize.Location = new Point(6, 3);
            btnDecreaseSize.Name = "btnDecreaseSize";
            btnDecreaseSize.Size = new Size(30, 30);
            btnDecreaseSize.TabIndex = 3;
            btnDecreaseSize.UseVisualStyleBackColor = true;
            btnDecreaseSize.Click += btnDecreaseSize_Click;
            // 
            // btnAddFromPlaylist
            // 
            btnAddFromPlaylist.FlatAppearance.BorderSize = 0;
            btnAddFromPlaylist.FlatStyle = FlatStyle.Flat;
            btnAddFromPlaylist.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddFromPlaylist.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnAddFromPlaylist.IconColor = Color.Black;
            btnAddFromPlaylist.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddFromPlaylist.IconSize = 26;
            btnAddFromPlaylist.ImageAlign = ContentAlignment.MiddleRight;
            btnAddFromPlaylist.Location = new Point(4, 273);
            btnAddFromPlaylist.Name = "btnAddFromPlaylist";
            btnAddFromPlaylist.Size = new Size(117, 30);
            btnAddFromPlaylist.TabIndex = 23;
            btnAddFromPlaylist.Text = "Add Queue";
            btnAddFromPlaylist.TextAlign = ContentAlignment.MiddleLeft;
            btnAddFromPlaylist.UseVisualStyleBackColor = true;
            btnAddFromPlaylist.Click += btnAddFromPlaylist_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MistyRose;
            panel1.Controls.Add(panelCustomListToolbar);
            panel1.Controls.Add(btnUseList);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(598, 36);
            panel1.TabIndex = 22;
            // 
            // panelCustomListToolbar
            // 
            panelCustomListToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCustomListToolbar.BackColor = Color.MintCream;
            panelCustomListToolbar.BottomRightOffset = 0;
            panelCustomListToolbar.BottomRightXOffset = 0;
            panelCustomListToolbar.Controls.Add(cbShowIcons);
            panelCustomListToolbar.Controls.Add(cbFullPath);
            panelCustomListToolbar.Controls.Add(customPanel2);
            panelCustomListToolbar.Location = new Point(0, 0);
            panelCustomListToolbar.Name = "panelCustomListToolbar";
            panelCustomListToolbar.Size = new Size(493, 36);
            panelCustomListToolbar.TabIndex = 0;
            panelCustomListToolbar.TopLeftXOffset = 0;
            panelCustomListToolbar.TopRightOffset = 0;
            panelCustomListToolbar.TopRightXOffset = 20;
            // 
            // cbShowIcons
            // 
            cbShowIcons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbShowIcons.Appearance = Appearance.Button;
            cbShowIcons.BackColor = Color.Transparent;
            cbShowIcons.CheckedBackColor = Color.PaleGreen;
            cbShowIcons.FlatAppearance.BorderSize = 0;
            cbShowIcons.FlatStyle = FlatStyle.Flat;
            cbShowIcons.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbShowIcons.Location = new Point(326, 4);
            cbShowIcons.Name = "cbShowIcons";
            cbShowIcons.Size = new Size(120, 26);
            cbShowIcons.TabIndex = 28;
            cbShowIcons.Text = "Show icons";
            cbShowIcons.UncheckedBackColor = Color.MintCream;
            cbShowIcons.UseVisualStyleBackColor = false;
            cbShowIcons.CheckedChanged += cbShowIcons_CheckedChanged;
            // 
            // cbFullPath
            // 
            cbFullPath.Appearance = Appearance.Button;
            cbFullPath.BackColor = Color.Transparent;
            cbFullPath.CheckedBackColor = Color.PaleGreen;
            cbFullPath.FlatAppearance.BorderSize = 0;
            cbFullPath.FlatStyle = FlatStyle.Flat;
            cbFullPath.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbFullPath.Location = new Point(151, 4);
            cbFullPath.Name = "cbFullPath";
            cbFullPath.Size = new Size(120, 26);
            cbFullPath.TabIndex = 27;
            cbFullPath.Text = "Show full path";
            cbFullPath.UncheckedBackColor = Color.MintCream;
            cbFullPath.UseVisualStyleBackColor = false;
            cbFullPath.CheckedChanged += cbFullPath_CheckedChanged;
            // 
            // customPanel2
            // 
            customPanel2.BackColor = Color.MistyRose;
            customPanel2.BottomRightOffset = 0;
            customPanel2.BottomRightXOffset = 0;
            customPanel2.Controls.Add(label4);
            customPanel2.Dock = DockStyle.Left;
            customPanel2.Location = new Point(0, 0);
            customPanel2.Name = "customPanel2";
            customPanel2.Size = new Size(126, 36);
            customPanel2.TabIndex = 26;
            customPanel2.TopLeftXOffset = 0;
            customPanel2.TopRightOffset = 0;
            customPanel2.TopRightXOffset = 0;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(3);
            label4.Name = "label4";
            label4.Size = new Size(126, 36);
            label4.TabIndex = 40;
            label4.Text = "Functions";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUseList
            // 
            btnUseList.BackColor = Color.PaleGreen;
            btnUseList.Dock = DockStyle.Right;
            btnUseList.FlatAppearance.BorderSize = 0;
            btnUseList.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnUseList.FlatStyle = FlatStyle.Flat;
            btnUseList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUseList.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnUseList.IconColor = Color.Black;
            btnUseList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnUseList.IconSize = 24;
            btnUseList.ImageAlign = ContentAlignment.MiddleRight;
            btnUseList.Location = new Point(452, 0);
            btnUseList.Name = "btnUseList";
            btnUseList.Size = new Size(146, 36);
            btnUseList.TabIndex = 23;
            btnUseList.Text = "Start List";
            btnUseList.UseVisualStyleBackColor = false;
            btnUseList.Click += btnUseList_Click;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.MistyRose;
            customPanel1.BottomRightOffset = 0;
            customPanel1.BottomRightXOffset = 0;
            customPanel1.Controls.Add(btnAddAll);
            customPanel1.Controls.Add(btnAddSelected);
            customPanel1.Location = new Point(0, 36);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(126, 70);
            customPanel1.TabIndex = 20;
            customPanel1.TopLeftXOffset = 0;
            customPanel1.TopRightOffset = 0;
            customPanel1.TopRightXOffset = 0;
            // 
            // btnAddAll
            // 
            btnAddAll.FlatAppearance.BorderSize = 0;
            btnAddAll.FlatStyle = FlatStyle.Flat;
            btnAddAll.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddAll.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            btnAddAll.IconColor = Color.Black;
            btnAddAll.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddAll.IconSize = 26;
            btnAddAll.ImageAlign = ContentAlignment.MiddleRight;
            btnAddAll.Location = new Point(4, 5);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new Size(117, 30);
            btnAddAll.TabIndex = 16;
            btnAddAll.Text = "Add all";
            btnAddAll.TextAlign = ContentAlignment.MiddleLeft;
            btnAddAll.UseVisualStyleBackColor = true;
            btnAddAll.Click += btnAddAll_Click;
            // 
            // btnAddSelected
            // 
            btnAddSelected.FlatAppearance.BorderSize = 0;
            btnAddSelected.FlatStyle = FlatStyle.Flat;
            btnAddSelected.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddSelected.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            btnAddSelected.IconColor = Color.Black;
            btnAddSelected.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnAddSelected.IconSize = 26;
            btnAddSelected.ImageAlign = ContentAlignment.MiddleRight;
            btnAddSelected.Location = new Point(4, 38);
            btnAddSelected.Name = "btnAddSelected";
            btnAddSelected.Size = new Size(117, 30);
            btnAddSelected.TabIndex = 15;
            btnAddSelected.Text = "Add selected";
            btnAddSelected.TextAlign = ContentAlignment.MiddleLeft;
            btnAddSelected.UseVisualStyleBackColor = true;
            btnAddSelected.Click += btnAddSelected_Click;
            // 
            // panelFilterExt
            // 
            panelFilterExt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelFilterExt.BackColor = Color.MistyRose;
            panelFilterExt.BottomRightOffset = 0;
            panelFilterExt.BottomRightXOffset = 0;
            panelFilterExt.Controls.Add(cbAVIF);
            panelFilterExt.Controls.Add(cbWEBP);
            panelFilterExt.Controls.Add(cbTIFF);
            panelFilterExt.Controls.Add(cbTIF);
            panelFilterExt.Controls.Add(cbBMP);
            panelFilterExt.Controls.Add(cbGIF);
            panelFilterExt.Controls.Add(cbPNG);
            panelFilterExt.Controls.Add(cbJPEG);
            panelFilterExt.Controls.Add(cbJPG);
            panelFilterExt.Controls.Add(cbAVCHD);
            panelFilterExt.Controls.Add(cbWEBM);
            panelFilterExt.Controls.Add(cbMP4);
            panelFilterExt.Controls.Add(cbF4V);
            panelFilterExt.Controls.Add(cbFLV);
            panelFilterExt.Controls.Add(cbWMV);
            panelFilterExt.Controls.Add(cbM4V);
            panelFilterExt.Controls.Add(cbMKV);
            panelFilterExt.Controls.Add(cbMOV);
            panelFilterExt.Controls.Add(cbAVI);
            panelFilterExt.Controls.Add(label3);
            panelFilterExt.Location = new Point(-6, 309);
            panelFilterExt.Name = "panelFilterExt";
            panelFilterExt.Size = new Size(132, 357);
            panelFilterExt.TabIndex = 21;
            panelFilterExt.TopLeftXOffset = 0;
            panelFilterExt.TopRightOffset = 0;
            panelFilterExt.TopRightXOffset = 0;
            // 
            // cbAVIF
            // 
            cbAVIF.Appearance = Appearance.Button;
            cbAVIF.BackColor = Color.Transparent;
            cbAVIF.CheckedBackColor = Color.LightPink;
            cbAVIF.FlatAppearance.BorderSize = 0;
            cbAVIF.FlatStyle = FlatStyle.Flat;
            cbAVIF.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbAVIF.Location = new Point(14, 329);
            cbAVIF.Name = "cbAVIF";
            cbAVIF.Size = new Size(48, 25);
            cbAVIF.TabIndex = 39;
            cbAVIF.Text = "avif";
            cbAVIF.TextAlign = ContentAlignment.MiddleCenter;
            cbAVIF.UncheckedBackColor = Color.MistyRose;
            cbAVIF.UseVisualStyleBackColor = true;
            // 
            // cbWEBP
            // 
            cbWEBP.Appearance = Appearance.Button;
            cbWEBP.BackColor = Color.Transparent;
            cbWEBP.CheckedBackColor = Color.LightPink;
            cbWEBP.FlatAppearance.BorderSize = 0;
            cbWEBP.FlatStyle = FlatStyle.Flat;
            cbWEBP.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbWEBP.Location = new Point(68, 298);
            cbWEBP.Name = "cbWEBP";
            cbWEBP.Size = new Size(48, 25);
            cbWEBP.TabIndex = 38;
            cbWEBP.Text = "webp";
            cbWEBP.TextAlign = ContentAlignment.MiddleCenter;
            cbWEBP.UncheckedBackColor = Color.MistyRose;
            cbWEBP.UseVisualStyleBackColor = true;
            // 
            // cbTIFF
            // 
            cbTIFF.Appearance = Appearance.Button;
            cbTIFF.BackColor = Color.Transparent;
            cbTIFF.CheckedBackColor = Color.LightPink;
            cbTIFF.FlatAppearance.BorderSize = 0;
            cbTIFF.FlatStyle = FlatStyle.Flat;
            cbTIFF.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbTIFF.Location = new Point(14, 298);
            cbTIFF.Name = "cbTIFF";
            cbTIFF.Size = new Size(48, 25);
            cbTIFF.TabIndex = 37;
            cbTIFF.Text = "tiff";
            cbTIFF.TextAlign = ContentAlignment.MiddleCenter;
            cbTIFF.UncheckedBackColor = Color.MistyRose;
            cbTIFF.UseVisualStyleBackColor = true;
            // 
            // cbTIF
            // 
            cbTIF.Appearance = Appearance.Button;
            cbTIF.BackColor = Color.Transparent;
            cbTIF.CheckedBackColor = Color.LightPink;
            cbTIF.FlatAppearance.BorderSize = 0;
            cbTIF.FlatStyle = FlatStyle.Flat;
            cbTIF.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbTIF.Location = new Point(68, 267);
            cbTIF.Name = "cbTIF";
            cbTIF.Size = new Size(48, 25);
            cbTIF.TabIndex = 36;
            cbTIF.Text = "tif";
            cbTIF.TextAlign = ContentAlignment.MiddleCenter;
            cbTIF.UncheckedBackColor = Color.MistyRose;
            cbTIF.UseVisualStyleBackColor = true;
            // 
            // cbBMP
            // 
            cbBMP.Appearance = Appearance.Button;
            cbBMP.BackColor = Color.Transparent;
            cbBMP.CheckedBackColor = Color.LightPink;
            cbBMP.FlatAppearance.BorderSize = 0;
            cbBMP.FlatStyle = FlatStyle.Flat;
            cbBMP.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbBMP.Location = new Point(14, 267);
            cbBMP.Name = "cbBMP";
            cbBMP.Size = new Size(48, 25);
            cbBMP.TabIndex = 35;
            cbBMP.Text = "bmp";
            cbBMP.TextAlign = ContentAlignment.MiddleCenter;
            cbBMP.UncheckedBackColor = Color.MistyRose;
            cbBMP.UseVisualStyleBackColor = true;
            // 
            // cbGIF
            // 
            cbGIF.Appearance = Appearance.Button;
            cbGIF.BackColor = Color.Transparent;
            cbGIF.CheckedBackColor = Color.LightPink;
            cbGIF.FlatAppearance.BorderSize = 0;
            cbGIF.FlatStyle = FlatStyle.Flat;
            cbGIF.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbGIF.Location = new Point(68, 236);
            cbGIF.Name = "cbGIF";
            cbGIF.Size = new Size(48, 25);
            cbGIF.TabIndex = 34;
            cbGIF.Text = "gif";
            cbGIF.TextAlign = ContentAlignment.MiddleCenter;
            cbGIF.UncheckedBackColor = Color.MistyRose;
            cbGIF.UseVisualStyleBackColor = true;
            // 
            // cbPNG
            // 
            cbPNG.Appearance = Appearance.Button;
            cbPNG.BackColor = Color.Transparent;
            cbPNG.CheckedBackColor = Color.LightPink;
            cbPNG.FlatAppearance.BorderSize = 0;
            cbPNG.FlatStyle = FlatStyle.Flat;
            cbPNG.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbPNG.Location = new Point(14, 236);
            cbPNG.Name = "cbPNG";
            cbPNG.Size = new Size(48, 25);
            cbPNG.TabIndex = 33;
            cbPNG.Text = "png";
            cbPNG.TextAlign = ContentAlignment.MiddleCenter;
            cbPNG.UncheckedBackColor = Color.MistyRose;
            cbPNG.UseVisualStyleBackColor = true;
            // 
            // cbJPEG
            // 
            cbJPEG.Appearance = Appearance.Button;
            cbJPEG.BackColor = Color.Transparent;
            cbJPEG.CheckedBackColor = Color.LightPink;
            cbJPEG.FlatAppearance.BorderSize = 0;
            cbJPEG.FlatStyle = FlatStyle.Flat;
            cbJPEG.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbJPEG.Location = new Point(68, 205);
            cbJPEG.Name = "cbJPEG";
            cbJPEG.Size = new Size(48, 25);
            cbJPEG.TabIndex = 32;
            cbJPEG.Text = "jpeg";
            cbJPEG.TextAlign = ContentAlignment.MiddleCenter;
            cbJPEG.UncheckedBackColor = Color.MistyRose;
            cbJPEG.UseVisualStyleBackColor = true;
            // 
            // cbJPG
            // 
            cbJPG.Appearance = Appearance.Button;
            cbJPG.BackColor = Color.Transparent;
            cbJPG.CheckedBackColor = Color.LightPink;
            cbJPG.FlatAppearance.BorderSize = 0;
            cbJPG.FlatStyle = FlatStyle.Flat;
            cbJPG.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbJPG.Location = new Point(14, 205);
            cbJPG.Name = "cbJPG";
            cbJPG.Size = new Size(48, 25);
            cbJPG.TabIndex = 31;
            cbJPG.Text = "jpg";
            cbJPG.TextAlign = ContentAlignment.MiddleCenter;
            cbJPG.UncheckedBackColor = Color.MistyRose;
            cbJPG.UseVisualStyleBackColor = true;
            // 
            // cbAVCHD
            // 
            cbAVCHD.Appearance = Appearance.Button;
            cbAVCHD.BackColor = Color.Transparent;
            cbAVCHD.CheckedBackColor = Color.LightPink;
            cbAVCHD.FlatAppearance.BorderSize = 0;
            cbAVCHD.FlatStyle = FlatStyle.Flat;
            cbAVCHD.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbAVCHD.Location = new Point(68, 160);
            cbAVCHD.Name = "cbAVCHD";
            cbAVCHD.Size = new Size(48, 25);
            cbAVCHD.TabIndex = 30;
            cbAVCHD.Text = "avchd";
            cbAVCHD.TextAlign = ContentAlignment.MiddleCenter;
            cbAVCHD.UncheckedBackColor = Color.MistyRose;
            cbAVCHD.UseVisualStyleBackColor = true;
            // 
            // cbWEBM
            // 
            cbWEBM.Appearance = Appearance.Button;
            cbWEBM.BackColor = Color.Transparent;
            cbWEBM.CheckedBackColor = Color.LightPink;
            cbWEBM.FlatAppearance.BorderSize = 0;
            cbWEBM.FlatStyle = FlatStyle.Flat;
            cbWEBM.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbWEBM.Location = new Point(14, 160);
            cbWEBM.Name = "cbWEBM";
            cbWEBM.Size = new Size(48, 25);
            cbWEBM.TabIndex = 29;
            cbWEBM.Text = "webm";
            cbWEBM.TextAlign = ContentAlignment.MiddleCenter;
            cbWEBM.UncheckedBackColor = Color.MistyRose;
            cbWEBM.UseVisualStyleBackColor = true;
            // 
            // cbMP4
            // 
            cbMP4.Appearance = Appearance.Button;
            cbMP4.BackColor = Color.Transparent;
            cbMP4.CheckedBackColor = Color.LightPink;
            cbMP4.FlatAppearance.BorderSize = 0;
            cbMP4.FlatStyle = FlatStyle.Flat;
            cbMP4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbMP4.Location = new Point(68, 129);
            cbMP4.Name = "cbMP4";
            cbMP4.Size = new Size(48, 25);
            cbMP4.TabIndex = 28;
            cbMP4.Text = "mp4";
            cbMP4.TextAlign = ContentAlignment.MiddleCenter;
            cbMP4.UncheckedBackColor = Color.MistyRose;
            cbMP4.UseVisualStyleBackColor = true;
            // 
            // cbF4V
            // 
            cbF4V.Appearance = Appearance.Button;
            cbF4V.BackColor = Color.Transparent;
            cbF4V.CheckedBackColor = Color.LightPink;
            cbF4V.FlatAppearance.BorderSize = 0;
            cbF4V.FlatStyle = FlatStyle.Flat;
            cbF4V.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbF4V.Location = new Point(14, 129);
            cbF4V.Name = "cbF4V";
            cbF4V.Size = new Size(48, 25);
            cbF4V.TabIndex = 27;
            cbF4V.Text = "f4v";
            cbF4V.TextAlign = ContentAlignment.MiddleCenter;
            cbF4V.UncheckedBackColor = Color.MistyRose;
            cbF4V.UseVisualStyleBackColor = true;
            // 
            // cbFLV
            // 
            cbFLV.Appearance = Appearance.Button;
            cbFLV.BackColor = Color.Transparent;
            cbFLV.CheckedBackColor = Color.LightPink;
            cbFLV.FlatAppearance.BorderSize = 0;
            cbFLV.FlatStyle = FlatStyle.Flat;
            cbFLV.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbFLV.Location = new Point(68, 98);
            cbFLV.Name = "cbFLV";
            cbFLV.Size = new Size(48, 25);
            cbFLV.TabIndex = 26;
            cbFLV.Text = "flv";
            cbFLV.TextAlign = ContentAlignment.MiddleCenter;
            cbFLV.UncheckedBackColor = Color.MistyRose;
            cbFLV.UseVisualStyleBackColor = true;
            // 
            // cbWMV
            // 
            cbWMV.Appearance = Appearance.Button;
            cbWMV.BackColor = Color.Transparent;
            cbWMV.CheckedBackColor = Color.LightPink;
            cbWMV.FlatAppearance.BorderSize = 0;
            cbWMV.FlatStyle = FlatStyle.Flat;
            cbWMV.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbWMV.Location = new Point(14, 98);
            cbWMV.Name = "cbWMV";
            cbWMV.Size = new Size(48, 25);
            cbWMV.TabIndex = 25;
            cbWMV.Text = "wmv";
            cbWMV.TextAlign = ContentAlignment.MiddleCenter;
            cbWMV.UncheckedBackColor = Color.MistyRose;
            cbWMV.UseVisualStyleBackColor = true;
            // 
            // cbM4V
            // 
            cbM4V.Appearance = Appearance.Button;
            cbM4V.BackColor = Color.Transparent;
            cbM4V.CheckedBackColor = Color.LightPink;
            cbM4V.FlatAppearance.BorderSize = 0;
            cbM4V.FlatStyle = FlatStyle.Flat;
            cbM4V.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbM4V.Location = new Point(68, 67);
            cbM4V.Name = "cbM4V";
            cbM4V.Size = new Size(48, 25);
            cbM4V.TabIndex = 24;
            cbM4V.Text = "m4v";
            cbM4V.TextAlign = ContentAlignment.MiddleCenter;
            cbM4V.UncheckedBackColor = Color.MistyRose;
            cbM4V.UseVisualStyleBackColor = true;
            // 
            // cbMKV
            // 
            cbMKV.Appearance = Appearance.Button;
            cbMKV.BackColor = Color.Transparent;
            cbMKV.CheckedBackColor = Color.LightPink;
            cbMKV.FlatAppearance.BorderSize = 0;
            cbMKV.FlatStyle = FlatStyle.Flat;
            cbMKV.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbMKV.Location = new Point(14, 67);
            cbMKV.Name = "cbMKV";
            cbMKV.Size = new Size(48, 25);
            cbMKV.TabIndex = 23;
            cbMKV.Text = "mkv";
            cbMKV.TextAlign = ContentAlignment.MiddleCenter;
            cbMKV.UncheckedBackColor = Color.MistyRose;
            cbMKV.UseVisualStyleBackColor = true;
            // 
            // cbMOV
            // 
            cbMOV.Appearance = Appearance.Button;
            cbMOV.BackColor = Color.Transparent;
            cbMOV.CheckedBackColor = Color.LightPink;
            cbMOV.FlatAppearance.BorderSize = 0;
            cbMOV.FlatStyle = FlatStyle.Flat;
            cbMOV.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbMOV.Location = new Point(68, 36);
            cbMOV.Name = "cbMOV";
            cbMOV.Size = new Size(48, 25);
            cbMOV.TabIndex = 22;
            cbMOV.Text = "mov";
            cbMOV.TextAlign = ContentAlignment.MiddleCenter;
            cbMOV.UncheckedBackColor = Color.MistyRose;
            cbMOV.UseVisualStyleBackColor = true;
            // 
            // cbAVI
            // 
            cbAVI.Appearance = Appearance.Button;
            cbAVI.BackColor = Color.Transparent;
            cbAVI.CheckedBackColor = Color.LightPink;
            cbAVI.FlatAppearance.BorderSize = 0;
            cbAVI.FlatStyle = FlatStyle.Flat;
            cbAVI.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbAVI.Location = new Point(14, 36);
            cbAVI.Name = "cbAVI";
            cbAVI.Size = new Size(48, 25);
            cbAVI.TabIndex = 21;
            cbAVI.Text = "avi";
            cbAVI.TextAlign = ContentAlignment.MiddleCenter;
            cbAVI.UncheckedBackColor = Color.MistyRose;
            cbAVI.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 0;
            label3.Text = "Filter";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lvCustomList
            // 
            lvCustomList.AllowDrop = true;
            lvCustomList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvCustomList.BackColor = Color.MintCream;
            lvCustomList.BorderStyle = BorderStyle.None;
            lvCustomList.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvCustomList.FullRowSelect = true;
            lvCustomList.HeaderStyle = ColumnHeaderStyle.None;
            lvCustomList.Location = new Point(127, 39);
            lvCustomList.Name = "lvCustomList";
            lvCustomList.ShowItemToolTips = true;
            lvCustomList.Size = new Size(468, 627);
            lvCustomList.TabIndex = 19;
            lvCustomList.UseCompatibleStateImageBehavior = false;
            lvCustomList.View = System.Windows.Forms.View.Details;
            lvCustomList.DragDrop += lvCustomList_DragDrop;
            lvCustomList.DragEnter += lvCustomList_DragEnter;
            lvCustomList.DragLeave += lvCustomList_DragLeave;
            lvCustomList.Resize += lvCustomList_Resize;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Placeholder";
            columnHeader1.Width = 200;
            // 
            // btnSaveList
            // 
            btnSaveList.FlatAppearance.BorderSize = 0;
            btnSaveList.FlatStyle = FlatStyle.Flat;
            btnSaveList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveList.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnSaveList.IconColor = Color.Black;
            btnSaveList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnSaveList.IconSize = 26;
            btnSaveList.ImageAlign = ContentAlignment.MiddleRight;
            btnSaveList.Location = new Point(4, 240);
            btnSaveList.Name = "btnSaveList";
            btnSaveList.Size = new Size(117, 30);
            btnSaveList.TabIndex = 14;
            btnSaveList.Text = "Save List";
            btnSaveList.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveList.UseVisualStyleBackColor = true;
            btnSaveList.Click += btnSaveList_Click_1;
            // 
            // btnClearList
            // 
            btnClearList.FlatAppearance.BorderSize = 0;
            btnClearList.FlatStyle = FlatStyle.Flat;
            btnClearList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnClearList.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            btnClearList.IconColor = Color.Black;
            btnClearList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnClearList.IconSize = 26;
            btnClearList.ImageAlign = ContentAlignment.MiddleRight;
            btnClearList.Location = new Point(4, 108);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new Size(117, 30);
            btnClearList.TabIndex = 18;
            btnClearList.Text = "Clear all";
            btnClearList.TextAlign = ContentAlignment.MiddleLeft;
            btnClearList.UseVisualStyleBackColor = true;
            btnClearList.Click += btnClearList_Click;
            // 
            // btnDelDuplicates
            // 
            btnDelDuplicates.FlatAppearance.BorderSize = 0;
            btnDelDuplicates.FlatStyle = FlatStyle.Flat;
            btnDelDuplicates.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelDuplicates.IconChar = FontAwesome.Sharp.IconChar.Clone;
            btnDelDuplicates.IconColor = Color.Black;
            btnDelDuplicates.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelDuplicates.IconSize = 26;
            btnDelDuplicates.ImageAlign = ContentAlignment.MiddleRight;
            btnDelDuplicates.Location = new Point(4, 174);
            btnDelDuplicates.Name = "btnDelDuplicates";
            btnDelDuplicates.Size = new Size(117, 30);
            btnDelDuplicates.TabIndex = 15;
            btnDelDuplicates.Text = "Clear dups.";
            btnDelDuplicates.TextAlign = ContentAlignment.MiddleLeft;
            btnDelDuplicates.UseVisualStyleBackColor = true;
            btnDelDuplicates.Click += btnDelDuplicates_Click;
            // 
            // btnClearSelected
            // 
            btnClearSelected.FlatAppearance.BorderSize = 0;
            btnClearSelected.FlatStyle = FlatStyle.Flat;
            btnClearSelected.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnClearSelected.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            btnClearSelected.IconColor = Color.Black;
            btnClearSelected.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClearSelected.IconSize = 26;
            btnClearSelected.ImageAlign = ContentAlignment.MiddleRight;
            btnClearSelected.Location = new Point(4, 141);
            btnClearSelected.Name = "btnClearSelected";
            btnClearSelected.Size = new Size(117, 30);
            btnClearSelected.TabIndex = 17;
            btnClearSelected.Text = "Clear selected";
            btnClearSelected.TextAlign = ContentAlignment.MiddleLeft;
            btnClearSelected.UseVisualStyleBackColor = true;
            btnClearSelected.Click += btnClearSelected_Click;
            // 
            // btnLoadList
            // 
            btnLoadList.FlatAppearance.BorderSize = 0;
            btnLoadList.FlatStyle = FlatStyle.Flat;
            btnLoadList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadList.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnLoadList.IconColor = Color.Black;
            btnLoadList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLoadList.IconSize = 26;
            btnLoadList.ImageAlign = ContentAlignment.MiddleRight;
            btnLoadList.Location = new Point(4, 207);
            btnLoadList.Name = "btnLoadList";
            btnLoadList.Size = new Size(117, 30);
            btnLoadList.TabIndex = 13;
            btnLoadList.Text = "Load List";
            btnLoadList.TextAlign = ContentAlignment.MiddleLeft;
            btnLoadList.UseVisualStyleBackColor = true;
            btnLoadList.Click += btnLoadList_Click_1;
            // 
            // tbPathView
            // 
            tbPathView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPathView.BackColor = Color.FromArgb(254, 232, 231);
            tbPathView.Location = new Point(39, 6);
            tbPathView.Name = "tbPathView";
            tbPathView.ReadOnly = true;
            tbPathView.Size = new Size(1154, 23);
            tbPathView.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.IconChar = FontAwesome.Sharp.IconChar.ChevronCircleLeft;
            btnBack.IconColor = Color.Black;
            btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBack.IconSize = 24;
            btnBack.Location = new Point(3, 7);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(30, 23);
            btnBack.TabIndex = 0;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lbDriveFolders
            // 
            lbDriveFolders.BackColor = Color.MistyRose;
            lbDriveFolders.BorderStyle = BorderStyle.None;
            lbDriveFolders.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbDriveFolders.FormattingEnabled = true;
            lbDriveFolders.ItemHeight = 15;
            lbDriveFolders.Location = new Point(-1, 77);
            lbDriveFolders.Name = "lbDriveFolders";
            lbDriveFolders.Size = new Size(126, 195);
            lbDriveFolders.TabIndex = 11;
            lbDriveFolders.DoubleClick += lbDriveFolders_DoubleClick;
            // 
            // imageListSmall
            // 
            imageListSmall.ColorDepth = ColorDepth.Depth32Bit;
            imageListSmall.ImageStream = (ImageListStreamer)resources.GetObject("imageListSmall.ImageStream");
            imageListSmall.TransparentColor = Color.Transparent;
            imageListSmall.Images.SetKeyName(0, "folder.png");
            imageListSmall.Images.SetKeyName(1, "avi.png");
            imageListSmall.Images.SetKeyName(2, "flv.png");
            imageListSmall.Images.SetKeyName(3, "m4v.png");
            imageListSmall.Images.SetKeyName(4, "mkv.png");
            imageListSmall.Images.SetKeyName(5, "mov.png");
            imageListSmall.Images.SetKeyName(6, "mp4.png");
            imageListSmall.Images.SetKeyName(7, "webm.png");
            imageListSmall.Images.SetKeyName(8, "wmv.png");
            imageListSmall.Images.SetKeyName(9, "f4v.png");
            imageListSmall.Images.SetKeyName(10, "avchd.png");
            imageListSmall.Images.SetKeyName(11, "jpg.png");
            imageListSmall.Images.SetKeyName(12, "jpeg.png");
            imageListSmall.Images.SetKeyName(13, "png.png");
            imageListSmall.Images.SetKeyName(14, "gif.png");
            imageListSmall.Images.SetKeyName(15, "tif.png");
            imageListSmall.Images.SetKeyName(16, "tiff.png");
            imageListSmall.Images.SetKeyName(17, "bmp.png");
            imageListSmall.Images.SetKeyName(18, "webp.png");
            imageListSmall.Images.SetKeyName(19, "avif.png");
            // 
            // saveFileDialog
            // 
            saveFileDialog.Title = "Choose where you want to store your current list:";
            // 
            // openFileDialog
            // 
            openFileDialog.Title = "Load one of your own lists:";
            // 
            // ListBrowserView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 721);
            Controls.Add(panelBody);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1215, 760);
            Name = "ListBrowserView";
            Text = "ListBrowserView";
            FormClosing += ListBrowserView_FormClosing;
            Load += ListBrowserView_Load;
            Resize += ListBrowserView_Resize;
            panelTop.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            splitContainerBody.Panel1.ResumeLayout(false);
            splitContainerBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerBody).EndInit();
            splitContainerBody.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelCustomListToolbar.ResumeLayout(false);
            customPanel2.ResumeLayout(false);
            customPanel1.ResumeLayout(false);
            panelFilterExt.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private FontAwesome.Sharp.IconButton btnClose;
        private Panel panelBody;
        private SplitContainer splitContainerBody;
        private ListView lvFileExplore;
        private TextBox tbPathView;
        private FontAwesome.Sharp.IconButton btnBack;
        private FolderBrowserDialog fbDialog;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ImageList imageListSmall;
        private ListBox lbDriveFolders;
        private FontAwesome.Sharp.IconButton btnLoadList;
        private FontAwesome.Sharp.IconButton btnSaveList;
        private FontAwesome.Sharp.IconButton btnAddSelected;
        private FontAwesome.Sharp.IconButton btnClearList;
        private FontAwesome.Sharp.IconButton btnClearSelected;
        private FontAwesome.Sharp.IconButton btnAddAll;
        private FontAwesome.Sharp.IconButton btnDelDuplicates;
        private ToolTip toolTipInfo;
        private ListBox lbFavorites;
        private FontAwesome.Sharp.IconButton btnDeleteFav;
        private FontAwesome.Sharp.IconButton btnAddFav;
        private FontAwesome.Sharp.IconButton btnUseList;
        private Label label3;
        private ImageList imageListLarge;
        private Controls.CustomPanel customPanel1;
        private ListView lvCustomList;
        private ColumnHeader columnHeader1;
        private Controls.CustomPanel panelFilterExt;
        private ColumnHeader columnHeader2;
        private FontAwesome.Sharp.IconButton btnViewGrid;
        private FontAwesome.Sharp.IconButton btnViewList;
        private FontAwesome.Sharp.IconButton btnViewTile;
        private FontAwesome.Sharp.IconButton btnDecreaseSize;
        private FontAwesome.Sharp.IconButton btnIncreaseSize;
        private FontAwesome.Sharp.IconButton btnResetSize;
        private Controls.CustomPanel panelCustomListToolbar;
        private Panel panel1;
        private Panel panel2;
        private Controls.CustomPanel customPanel2;
        private Controls.RoundedCheckBox cbAVI;
        private Controls.RoundedCheckBox cbAVCHD;
        private Controls.RoundedCheckBox cbWEBM;
        private Controls.RoundedCheckBox cbMP4;
        private Controls.RoundedCheckBox cbF4V;
        private Controls.RoundedCheckBox cbFLV;
        private Controls.RoundedCheckBox cbWMV;
        private Controls.RoundedCheckBox cbM4V;
        private Controls.RoundedCheckBox cbMKV;
        private Controls.RoundedCheckBox cbMOV;
        private Controls.RoundedCheckBox cbAVIF;
        private Controls.RoundedCheckBox cbWEBP;
        private Controls.RoundedCheckBox cbTIFF;
        private Controls.RoundedCheckBox cbTIF;
        private Controls.RoundedCheckBox cbBMP;
        private Controls.RoundedCheckBox cbGIF;
        private Controls.RoundedCheckBox cbPNG;
        private Controls.RoundedCheckBox cbJPEG;
        private Controls.RoundedCheckBox cbJPG;
        private Controls.RoundedCheckBox cbFullPath;
        private Controls.RoundedCheckBox cbShowIcons;
        private Label label2;
        private Label label1;
        private Label label4;
        private FontAwesome.Sharp.IconButton btnAddFromPlaylist;
    }
}