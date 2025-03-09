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
            lblTitleBar = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelBody = new Panel();
            btnAddFav = new FontAwesome.Sharp.IconButton();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            lblFavorites = new Label();
            lblNavigation = new Label();
            lbFavorites = new ListBox();
            splitContainerBody = new SplitContainer();
            lvFileExplore = new ListView();
            columnHeader2 = new ColumnHeader();
            imageListLarge = new ImageList(components);
            panelToolBar = new Panel();
            cbEnableScriptFilter = new Controls.RoundedImageCheckBox();
            cbEnableVideoFilter = new Controls.RoundedImageCheckBox();
            cbEnableImageFilter = new Controls.RoundedImageCheckBox();
            btnViewList = new FontAwesome.Sharp.IconButton();
            btnViewTile = new FontAwesome.Sharp.IconButton();
            btnIncreaseSize = new FontAwesome.Sharp.IconButton();
            btnViewGrid = new FontAwesome.Sharp.IconButton();
            btnResetSize = new FontAwesome.Sharp.IconButton();
            btnDecreaseSize = new FontAwesome.Sharp.IconButton();
            btnMoveList = new FontAwesome.Sharp.IconButton();
            btnAddFromPlaylist = new FontAwesome.Sharp.IconButton();
            panelHeaderRightside = new Panel();
            panelCustomListToolbar = new Controls.CustomPanel();
            lblFunctions = new Label();
            cbShowIcons = new Controls.RoundedCheckBox();
            cbFullPath = new Controls.RoundedCheckBox();
            btnUseList = new FontAwesome.Sharp.IconButton();
            panelFunctions = new Controls.CustomPanel();
            btnAddAll = new FontAwesome.Sharp.IconButton();
            btnAddSelected = new FontAwesome.Sharp.IconButton();
            panelFilterExt = new Controls.CustomPanel();
            flowPanelImageCheckboxes = new FlowLayoutPanel();
            btnImageExtensions = new FontAwesome.Sharp.IconButton();
            flowPanelVideoCheckboxes = new FlowLayoutPanel();
            btnVideoExtensions = new FontAwesome.Sharp.IconButton();
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
            panelToolBar.SuspendLayout();
            panelHeaderRightside.SuspendLayout();
            panelCustomListToolbar.SuspendLayout();
            panelFunctions.SuspendLayout();
            panelFilterExt.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(248, 111, 100);
            panelTop.Controls.Add(lblTitleBar);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1713, 33);
            panelTop.TabIndex = 0;
            // 
            // lblTitleBar
            // 
            lblTitleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleBar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitleBar.Location = new Point(47, 2);
            lblTitleBar.Margin = new Padding(47, 0, 4, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Size = new Size(1614, 32);
            lblTitleBar.TabIndex = 1;
            lblTitleBar.Text = "RVP - ListBrowser";
            lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
            lblTitleBar.MouseDown += lblTitle_MouseDown;
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
            btnClose.Location = new Point(1670, 0);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(43, 33);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.MistyRose;
            panelBody.Controls.Add(btnAddFav);
            panelBody.Controls.Add(btnDeleteFav);
            panelBody.Controls.Add(lblFavorites);
            panelBody.Controls.Add(lblNavigation);
            panelBody.Controls.Add(lbFavorites);
            panelBody.Controls.Add(splitContainerBody);
            panelBody.Controls.Add(tbPathView);
            panelBody.Controls.Add(btnBack);
            panelBody.Controls.Add(lbDriveFolders);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 33);
            panelBody.Margin = new Padding(4, 5, 4, 5);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1713, 1169);
            panelBody.TabIndex = 1;
            // 
            // btnAddFav
            // 
            btnAddFav.FlatAppearance.BorderSize = 0;
            btnAddFav.FlatStyle = FlatStyle.Flat;
            btnAddFav.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddFav.IconColor = Color.Black;
            btnAddFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddFav.IconSize = 26;
            btnAddFav.Location = new Point(111, 533);
            btnAddFav.Margin = new Padding(4, 5, 21, 5);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(43, 50);
            btnAddFav.TabIndex = 21;
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // btnDeleteFav
            // 
            btnDeleteFav.FlatAppearance.BorderSize = 0;
            btnDeleteFav.FlatStyle = FlatStyle.Flat;
            btnDeleteFav.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
            btnDeleteFav.IconColor = Color.Black;
            btnDeleteFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteFav.IconSize = 26;
            btnDeleteFav.Location = new Point(21, 533);
            btnDeleteFav.Margin = new Padding(21, 5, 4, 5);
            btnDeleteFav.Name = "btnDeleteFav";
            btnDeleteFav.Size = new Size(43, 50);
            btnDeleteFav.TabIndex = 22;
            btnDeleteFav.UseVisualStyleBackColor = true;
            btnDeleteFav.Click += btnDeleteFav_Click;
            // 
            // lblFavorites
            // 
            lblFavorites.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblFavorites.Location = new Point(0, 463);
            lblFavorites.Margin = new Padding(4, 5, 4, 5);
            lblFavorites.Name = "lblFavorites";
            lblFavorites.Size = new Size(179, 60);
            lblFavorites.TabIndex = 22;
            lblFavorites.Text = "Favorites";
            lblFavorites.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNavigation
            // 
            lblNavigation.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNavigation.Location = new Point(0, 58);
            lblNavigation.Margin = new Padding(4, 5, 4, 5);
            lblNavigation.Name = "lblNavigation";
            lblNavigation.Size = new Size(179, 60);
            lblNavigation.TabIndex = 21;
            lblNavigation.Text = "Navigation";
            lblNavigation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbFavorites
            // 
            lbFavorites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbFavorites.BackColor = Color.MistyRose;
            lbFavorites.BorderStyle = BorderStyle.None;
            lbFavorites.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbFavorites.FormattingEnabled = true;
            lbFavorites.ItemHeight = 25;
            lbFavorites.Location = new Point(-1, 583);
            lbFavorites.Margin = new Padding(4, 5, 4, 5);
            lbFavorites.Name = "lbFavorites";
            lbFavorites.Size = new Size(180, 575);
            lbFavorites.TabIndex = 20;
            lbFavorites.DoubleClick += lbFavorites_DoubleClick;
            lbFavorites.MouseMove += lbFavorites_MouseMove;
            // 
            // splitContainerBody
            // 
            splitContainerBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerBody.Location = new Point(180, 58);
            splitContainerBody.Margin = new Padding(4, 5, 4, 5);
            splitContainerBody.Name = "splitContainerBody";
            // 
            // splitContainerBody.Panel1
            // 
            splitContainerBody.Panel1.Controls.Add(lvFileExplore);
            splitContainerBody.Panel1.Controls.Add(panelToolBar);
            // 
            // splitContainerBody.Panel2
            // 
            splitContainerBody.Panel2.BackColor = Color.MintCream;
            splitContainerBody.Panel2.Controls.Add(btnMoveList);
            splitContainerBody.Panel2.Controls.Add(btnAddFromPlaylist);
            splitContainerBody.Panel2.Controls.Add(panelHeaderRightside);
            splitContainerBody.Panel2.Controls.Add(panelFunctions);
            splitContainerBody.Panel2.Controls.Add(panelFilterExt);
            splitContainerBody.Panel2.Controls.Add(lvCustomList);
            splitContainerBody.Panel2.Controls.Add(btnSaveList);
            splitContainerBody.Panel2.Controls.Add(btnClearList);
            splitContainerBody.Panel2.Controls.Add(btnDelDuplicates);
            splitContainerBody.Panel2.Controls.Add(btnClearSelected);
            splitContainerBody.Panel2.Controls.Add(btnLoadList);
            splitContainerBody.Size = new Size(1529, 1114);
            splitContainerBody.SplitterDistance = 667;
            splitContainerBody.SplitterWidth = 6;
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
            lvFileExplore.Location = new Point(0, 60);
            lvFileExplore.Margin = new Padding(4, 5, 4, 5);
            lvFileExplore.Name = "lvFileExplore";
            lvFileExplore.ShowItemToolTips = true;
            lvFileExplore.Size = new Size(667, 1054);
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
            // panelToolBar
            // 
            panelToolBar.Controls.Add(cbEnableScriptFilter);
            panelToolBar.Controls.Add(cbEnableVideoFilter);
            panelToolBar.Controls.Add(cbEnableImageFilter);
            panelToolBar.Controls.Add(btnViewList);
            panelToolBar.Controls.Add(btnViewTile);
            panelToolBar.Controls.Add(btnIncreaseSize);
            panelToolBar.Controls.Add(btnViewGrid);
            panelToolBar.Controls.Add(btnResetSize);
            panelToolBar.Controls.Add(btnDecreaseSize);
            panelToolBar.Dock = DockStyle.Top;
            panelToolBar.Location = new Point(0, 0);
            panelToolBar.Margin = new Padding(4, 5, 4, 5);
            panelToolBar.Name = "panelToolBar";
            panelToolBar.Size = new Size(667, 60);
            panelToolBar.TabIndex = 1;
            // 
            // cbEnableScriptFilter
            // 
            cbEnableScriptFilter.Appearance = Appearance.Button;
            cbEnableScriptFilter.BackColor = Color.Transparent;
            cbEnableScriptFilter.CheckedBackColor = Color.DeepSkyBlue;
            cbEnableScriptFilter.FlatAppearance.BorderSize = 0;
            cbEnableScriptFilter.FlatStyle = FlatStyle.Flat;
            cbEnableScriptFilter.Image = (Image)resources.GetObject("cbEnableScriptFilter.Image");
            cbEnableScriptFilter.Location = new Point(623, 5);
            cbEnableScriptFilter.Margin = new Padding(4, 5, 4, 5);
            cbEnableScriptFilter.Name = "cbEnableScriptFilter";
            cbEnableScriptFilter.Size = new Size(43, 50);
            cbEnableScriptFilter.TabIndex = 11;
            cbEnableScriptFilter.Text = "roundedImageCheckBox1";
            cbEnableScriptFilter.UncheckedBackColor = Color.MistyRose;
            cbEnableScriptFilter.UseVisualStyleBackColor = false;
            cbEnableScriptFilter.CheckedChanged += cbEnableScriptFilter_CheckedChanged;
            // 
            // cbEnableVideoFilter
            // 
            cbEnableVideoFilter.Appearance = Appearance.Button;
            cbEnableVideoFilter.BackColor = Color.Transparent;
            cbEnableVideoFilter.CheckedBackColor = Color.PaleGreen;
            cbEnableVideoFilter.FlatAppearance.BorderSize = 0;
            cbEnableVideoFilter.FlatStyle = FlatStyle.Flat;
            cbEnableVideoFilter.Image = (Image)resources.GetObject("cbEnableVideoFilter.Image");
            cbEnableVideoFilter.Location = new Point(520, 5);
            cbEnableVideoFilter.Margin = new Padding(4, 5, 4, 5);
            cbEnableVideoFilter.Name = "cbEnableVideoFilter";
            cbEnableVideoFilter.Size = new Size(43, 50);
            cbEnableVideoFilter.TabIndex = 9;
            cbEnableVideoFilter.Text = "roundedImageCheckBox3";
            cbEnableVideoFilter.UncheckedBackColor = Color.MistyRose;
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
            cbEnableImageFilter.Location = new Point(571, 5);
            cbEnableImageFilter.Margin = new Padding(4, 5, 4, 5);
            cbEnableImageFilter.Name = "cbEnableImageFilter";
            cbEnableImageFilter.Size = new Size(43, 50);
            cbEnableImageFilter.TabIndex = 10;
            cbEnableImageFilter.Text = "roundedImageCheckBox2";
            cbEnableImageFilter.UncheckedBackColor = Color.MistyRose;
            cbEnableImageFilter.UseVisualStyleBackColor = false;
            cbEnableImageFilter.CheckedChanged += cbEnableImageFilter_CheckedChanged;
            // 
            // btnViewList
            // 
            btnViewList.FlatAppearance.BorderSize = 0;
            btnViewList.FlatStyle = FlatStyle.Flat;
            btnViewList.IconChar = FontAwesome.Sharp.IconChar.TableList;
            btnViewList.IconColor = Color.Black;
            btnViewList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewList.IconSize = 30;
            btnViewList.Location = new Point(284, 5);
            btnViewList.Margin = new Padding(4, 5, 4, 5);
            btnViewList.Name = "btnViewList";
            btnViewList.Size = new Size(43, 50);
            btnViewList.TabIndex = 6;
            btnViewList.UseVisualStyleBackColor = true;
            btnViewList.Click += btnViewList_Click;
            // 
            // btnViewTile
            // 
            btnViewTile.FlatAppearance.BorderSize = 0;
            btnViewTile.FlatStyle = FlatStyle.Flat;
            btnViewTile.IconChar = FontAwesome.Sharp.IconChar.TableCells;
            btnViewTile.IconColor = Color.Black;
            btnViewTile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewTile.IconSize = 30;
            btnViewTile.Location = new Point(336, 5);
            btnViewTile.Margin = new Padding(4, 5, 4, 5);
            btnViewTile.Name = "btnViewTile";
            btnViewTile.Size = new Size(43, 50);
            btnViewTile.TabIndex = 7;
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
            btnIncreaseSize.Location = new Point(111, 5);
            btnIncreaseSize.Margin = new Padding(4, 5, 4, 5);
            btnIncreaseSize.Name = "btnIncreaseSize";
            btnIncreaseSize.Size = new Size(43, 50);
            btnIncreaseSize.TabIndex = 5;
            btnIncreaseSize.UseVisualStyleBackColor = true;
            btnIncreaseSize.Click += btnIncreaseSize_Click;
            // 
            // btnViewGrid
            // 
            btnViewGrid.BackColor = Color.MistyRose;
            btnViewGrid.FlatAppearance.BorderSize = 0;
            btnViewGrid.FlatStyle = FlatStyle.Flat;
            btnViewGrid.IconChar = FontAwesome.Sharp.IconChar.TableCellsLarge;
            btnViewGrid.IconColor = Color.Black;
            btnViewGrid.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewGrid.IconSize = 30;
            btnViewGrid.Location = new Point(387, 5);
            btnViewGrid.Margin = new Padding(4, 5, 4, 5);
            btnViewGrid.Name = "btnViewGrid";
            btnViewGrid.Size = new Size(43, 50);
            btnViewGrid.TabIndex = 8;
            btnViewGrid.UseVisualStyleBackColor = false;
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
            btnResetSize.Location = new Point(60, 5);
            btnResetSize.Margin = new Padding(4, 5, 4, 5);
            btnResetSize.Name = "btnResetSize";
            btnResetSize.Size = new Size(43, 50);
            btnResetSize.TabIndex = 4;
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
            btnDecreaseSize.Location = new Point(9, 5);
            btnDecreaseSize.Margin = new Padding(4, 5, 4, 5);
            btnDecreaseSize.Name = "btnDecreaseSize";
            btnDecreaseSize.Size = new Size(43, 50);
            btnDecreaseSize.TabIndex = 3;
            btnDecreaseSize.UseVisualStyleBackColor = true;
            btnDecreaseSize.Click += btnDecreaseSize_Click;
            // 
            // btnMoveList
            // 
            btnMoveList.FlatAppearance.BorderSize = 0;
            btnMoveList.FlatStyle = FlatStyle.Flat;
            btnMoveList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnMoveList.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkSquare;
            btnMoveList.IconColor = Color.Black;
            btnMoveList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnMoveList.IconSize = 26;
            btnMoveList.ImageAlign = ContentAlignment.MiddleRight;
            btnMoveList.Location = new Point(6, 512);
            btnMoveList.Margin = new Padding(4, 5, 4, 5);
            btnMoveList.Name = "btnMoveList";
            btnMoveList.Size = new Size(167, 50);
            btnMoveList.TabIndex = 26;
            btnMoveList.Text = "Move List";
            btnMoveList.TextAlign = ContentAlignment.MiddleLeft;
            btnMoveList.UseVisualStyleBackColor = true;
            btnMoveList.Click += btnMoveList_Click;
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
            btnAddFromPlaylist.Location = new Point(6, 458);
            btnAddFromPlaylist.Margin = new Padding(4, 5, 4, 5);
            btnAddFromPlaylist.Name = "btnAddFromPlaylist";
            btnAddFromPlaylist.Size = new Size(167, 50);
            btnAddFromPlaylist.TabIndex = 25;
            btnAddFromPlaylist.Text = "Add Queue";
            btnAddFromPlaylist.TextAlign = ContentAlignment.MiddleLeft;
            btnAddFromPlaylist.UseVisualStyleBackColor = true;
            btnAddFromPlaylist.Click += btnAddFromPlaylist_Click;
            // 
            // panelHeaderRightside
            // 
            panelHeaderRightside.BackColor = Color.MistyRose;
            panelHeaderRightside.Controls.Add(panelCustomListToolbar);
            panelHeaderRightside.Controls.Add(btnUseList);
            panelHeaderRightside.Dock = DockStyle.Top;
            panelHeaderRightside.Location = new Point(0, 0);
            panelHeaderRightside.Margin = new Padding(4, 5, 4, 5);
            panelHeaderRightside.Name = "panelHeaderRightside";
            panelHeaderRightside.Size = new Size(856, 60);
            panelHeaderRightside.TabIndex = 22;
            // 
            // panelCustomListToolbar
            // 
            panelCustomListToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCustomListToolbar.BackColor = Color.MintCream;
            panelCustomListToolbar.BottomRightOffset = 0;
            panelCustomListToolbar.BottomRightXOffset = 0;
            panelCustomListToolbar.Controls.Add(lblFunctions);
            panelCustomListToolbar.Controls.Add(cbShowIcons);
            panelCustomListToolbar.Controls.Add(cbFullPath);
            panelCustomListToolbar.Location = new Point(0, 0);
            panelCustomListToolbar.Margin = new Padding(4, 5, 4, 5);
            panelCustomListToolbar.Name = "panelCustomListToolbar";
            panelCustomListToolbar.Size = new Size(707, 60);
            panelCustomListToolbar.TabIndex = 0;
            panelCustomListToolbar.TopLeftXOffset = 0;
            panelCustomListToolbar.TopRightOffset = 0;
            panelCustomListToolbar.TopRightXOffset = 20;
            // 
            // lblFunctions
            // 
            lblFunctions.BackColor = Color.MistyRose;
            lblFunctions.Dock = DockStyle.Left;
            lblFunctions.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblFunctions.Location = new Point(0, 0);
            lblFunctions.Margin = new Padding(4, 5, 4, 5);
            lblFunctions.Name = "lblFunctions";
            lblFunctions.Size = new Size(180, 60);
            lblFunctions.TabIndex = 40;
            lblFunctions.Text = "Functions";
            lblFunctions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbShowIcons
            // 
            cbShowIcons.Appearance = Appearance.Button;
            cbShowIcons.BackColor = Color.Transparent;
            cbShowIcons.CheckedBackColor = Color.PaleGreen;
            cbShowIcons.FlatAppearance.BorderSize = 0;
            cbShowIcons.FlatStyle = FlatStyle.Flat;
            cbShowIcons.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cbShowIcons.Location = new Point(467, 7);
            cbShowIcons.Margin = new Padding(4, 5, 4, 5);
            cbShowIcons.Name = "cbShowIcons";
            cbShowIcons.Size = new Size(171, 43);
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
            cbFullPath.Location = new Point(216, 7);
            cbFullPath.Margin = new Padding(4, 5, 4, 5);
            cbFullPath.Name = "cbFullPath";
            cbFullPath.Size = new Size(171, 43);
            cbFullPath.TabIndex = 27;
            cbFullPath.Text = "Show full path";
            cbFullPath.UncheckedBackColor = Color.MintCream;
            cbFullPath.UseVisualStyleBackColor = false;
            cbFullPath.CheckedChanged += cbFullPath_CheckedChanged;
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
            btnUseList.Location = new Point(647, 0);
            btnUseList.Margin = new Padding(4, 5, 4, 5);
            btnUseList.Name = "btnUseList";
            btnUseList.Size = new Size(209, 60);
            btnUseList.TabIndex = 23;
            btnUseList.Text = "Start List";
            btnUseList.UseVisualStyleBackColor = false;
            btnUseList.Click += btnUseList_Click;
            // 
            // panelFunctions
            // 
            panelFunctions.BackColor = Color.MistyRose;
            panelFunctions.BottomRightOffset = 0;
            panelFunctions.BottomRightXOffset = 0;
            panelFunctions.Controls.Add(btnAddAll);
            panelFunctions.Controls.Add(btnAddSelected);
            panelFunctions.Location = new Point(0, 60);
            panelFunctions.Margin = new Padding(4, 5, 4, 5);
            panelFunctions.Name = "panelFunctions";
            panelFunctions.Size = new Size(180, 117);
            panelFunctions.TabIndex = 20;
            panelFunctions.TopLeftXOffset = 0;
            panelFunctions.TopRightOffset = 0;
            panelFunctions.TopRightXOffset = 0;
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
            btnAddAll.Location = new Point(6, 8);
            btnAddAll.Margin = new Padding(4, 5, 4, 5);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new Size(167, 50);
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
            btnAddSelected.Location = new Point(6, 63);
            btnAddSelected.Margin = new Padding(4, 5, 4, 5);
            btnAddSelected.Name = "btnAddSelected";
            btnAddSelected.Size = new Size(167, 50);
            btnAddSelected.TabIndex = 15;
            btnAddSelected.Text = "Add selected";
            btnAddSelected.TextAlign = ContentAlignment.MiddleLeft;
            btnAddSelected.UseVisualStyleBackColor = true;
            btnAddSelected.Click += btnAddSelected_Click;
            // 
            // panelFilterExt
            // 
            panelFilterExt.BackColor = Color.MistyRose;
            panelFilterExt.BottomRightOffset = 0;
            panelFilterExt.BottomRightXOffset = 0;
            panelFilterExt.Controls.Add(flowPanelImageCheckboxes);
            panelFilterExt.Controls.Add(btnImageExtensions);
            panelFilterExt.Controls.Add(flowPanelVideoCheckboxes);
            panelFilterExt.Controls.Add(btnVideoExtensions);
            panelFilterExt.Location = new Point(-9, 568);
            panelFilterExt.Margin = new Padding(4, 5, 4, 5);
            panelFilterExt.Name = "panelFilterExt";
            panelFilterExt.Size = new Size(189, 544);
            panelFilterExt.TabIndex = 21;
            panelFilterExt.TopLeftXOffset = 0;
            panelFilterExt.TopRightOffset = 0;
            panelFilterExt.TopRightXOffset = 0;
            // 
            // flowPanelImageCheckboxes
            // 
            flowPanelImageCheckboxes.Dock = DockStyle.Top;
            flowPanelImageCheckboxes.Location = new Point(0, 420);
            flowPanelImageCheckboxes.Margin = new Padding(4, 5, 4, 5);
            flowPanelImageCheckboxes.Name = "flowPanelImageCheckboxes";
            flowPanelImageCheckboxes.Padding = new Padding(9, 0, 0, 0);
            flowPanelImageCheckboxes.Size = new Size(189, 17);
            flowPanelImageCheckboxes.TabIndex = 3;
            flowPanelImageCheckboxes.Visible = false;
            // 
            // btnImageExtensions
            // 
            btnImageExtensions.Dock = DockStyle.Top;
            btnImageExtensions.FlatAppearance.BorderSize = 0;
            btnImageExtensions.FlatStyle = FlatStyle.Flat;
            btnImageExtensions.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnImageExtensions.IconChar = FontAwesome.Sharp.IconChar.None;
            btnImageExtensions.IconColor = Color.Black;
            btnImageExtensions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnImageExtensions.Location = new Point(0, 360);
            btnImageExtensions.Margin = new Padding(4, 5, 4, 5);
            btnImageExtensions.Name = "btnImageExtensions";
            btnImageExtensions.Size = new Size(189, 60);
            btnImageExtensions.TabIndex = 2;
            btnImageExtensions.Text = "Image ext";
            btnImageExtensions.UseVisualStyleBackColor = true;
            btnImageExtensions.Click += btnImageExtensions_Click;
            // 
            // flowPanelVideoCheckboxes
            // 
            flowPanelVideoCheckboxes.Dock = DockStyle.Top;
            flowPanelVideoCheckboxes.Location = new Point(0, 60);
            flowPanelVideoCheckboxes.Margin = new Padding(4, 5, 4, 5);
            flowPanelVideoCheckboxes.Name = "flowPanelVideoCheckboxes";
            flowPanelVideoCheckboxes.Padding = new Padding(9, 0, 0, 0);
            flowPanelVideoCheckboxes.Size = new Size(189, 300);
            flowPanelVideoCheckboxes.TabIndex = 1;
            // 
            // btnVideoExtensions
            // 
            btnVideoExtensions.Dock = DockStyle.Top;
            btnVideoExtensions.FlatAppearance.BorderSize = 0;
            btnVideoExtensions.FlatStyle = FlatStyle.Flat;
            btnVideoExtensions.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnVideoExtensions.IconChar = FontAwesome.Sharp.IconChar.None;
            btnVideoExtensions.IconColor = Color.Black;
            btnVideoExtensions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVideoExtensions.Location = new Point(0, 0);
            btnVideoExtensions.Margin = new Padding(4, 5, 4, 5);
            btnVideoExtensions.Name = "btnVideoExtensions";
            btnVideoExtensions.Size = new Size(189, 60);
            btnVideoExtensions.TabIndex = 0;
            btnVideoExtensions.Text = "Video ext";
            btnVideoExtensions.UseVisualStyleBackColor = true;
            btnVideoExtensions.Click += btnVideoExtensions_Click;
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
            lvCustomList.Location = new Point(181, 65);
            lvCustomList.Margin = new Padding(4, 5, 4, 5);
            lvCustomList.Name = "lvCustomList";
            lvCustomList.ShowItemToolTips = true;
            lvCustomList.Size = new Size(665, 1049);
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
            btnSaveList.Location = new Point(6, 403);
            btnSaveList.Margin = new Padding(4, 5, 4, 5);
            btnSaveList.Name = "btnSaveList";
            btnSaveList.Size = new Size(167, 50);
            btnSaveList.TabIndex = 24;
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
            btnClearList.Location = new Point(6, 183);
            btnClearList.Margin = new Padding(4, 5, 4, 5);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new Size(167, 50);
            btnClearList.TabIndex = 20;
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
            btnDelDuplicates.Location = new Point(6, 293);
            btnDelDuplicates.Margin = new Padding(4, 5, 4, 5);
            btnDelDuplicates.Name = "btnDelDuplicates";
            btnDelDuplicates.Size = new Size(167, 50);
            btnDelDuplicates.TabIndex = 22;
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
            btnClearSelected.Location = new Point(6, 238);
            btnClearSelected.Margin = new Padding(4, 5, 4, 5);
            btnClearSelected.Name = "btnClearSelected";
            btnClearSelected.Size = new Size(167, 50);
            btnClearSelected.TabIndex = 21;
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
            btnLoadList.Location = new Point(6, 348);
            btnLoadList.Margin = new Padding(4, 5, 4, 5);
            btnLoadList.Name = "btnLoadList";
            btnLoadList.Size = new Size(167, 50);
            btnLoadList.TabIndex = 23;
            btnLoadList.Text = "Load List";
            btnLoadList.TextAlign = ContentAlignment.MiddleLeft;
            btnLoadList.UseVisualStyleBackColor = true;
            btnLoadList.Click += btnLoadList_Click_1;
            // 
            // tbPathView
            // 
            tbPathView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPathView.BackColor = Color.FromArgb(254, 232, 231);
            tbPathView.Location = new Point(57, 10);
            tbPathView.Margin = new Padding(4, 5, 4, 5);
            tbPathView.Name = "tbPathView";
            tbPathView.ReadOnly = true;
            tbPathView.Size = new Size(1650, 31);
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
            btnBack.Location = new Point(4, 10);
            btnBack.Margin = new Padding(4, 5, 4, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(43, 38);
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
            lbDriveFolders.ItemHeight = 25;
            lbDriveFolders.Location = new Point(-1, 128);
            lbDriveFolders.Margin = new Padding(4, 5, 4, 5);
            lbDriveFolders.Name = "lbDriveFolders";
            lbDriveFolders.Size = new Size(180, 325);
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
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1713, 1202);
            Controls.Add(panelBody);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1719, 1194);
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
            panelToolBar.ResumeLayout(false);
            panelHeaderRightside.ResumeLayout(false);
            panelCustomListToolbar.ResumeLayout(false);
            panelFunctions.ResumeLayout(false);
            panelFilterExt.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitleBar;
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
        private ImageList imageListLarge;
        private Controls.CustomPanel panelFunctions;
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
        private Panel panelHeaderRightside;
        private Panel panelToolBar;
        private Controls.RoundedCheckBox cbFullPath;
        private Controls.RoundedCheckBox cbShowIcons;
        private Label lblFavorites;
        private Label lblNavigation;
        private Label lblFunctions;
        private FontAwesome.Sharp.IconButton btnAddFromPlaylist;
        private FontAwesome.Sharp.IconButton btnVideoExtensions;
        private FlowLayoutPanel flowPanelImageCheckboxes;
        private FontAwesome.Sharp.IconButton btnImageExtensions;
        private FlowLayoutPanel flowPanelVideoCheckboxes;
        private Controls.RoundedImageCheckBox cbEnableVideoFilter;
        private Controls.RoundedImageCheckBox cbEnableImageFilter;
        private Controls.RoundedImageCheckBox cbEnableScriptFilter;
        private FontAwesome.Sharp.IconButton btnMoveList;
    }
}