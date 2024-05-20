﻿namespace RandomVideoPlayer.View
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
            btnAddFav = new FontAwesome.Sharp.IconButton();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            btnUseList = new FontAwesome.Sharp.IconButton();
            btnSaveList = new FontAwesome.Sharp.IconButton();
            btnDelDuplicates = new FontAwesome.Sharp.IconButton();
            btnLoadList = new FontAwesome.Sharp.IconButton();
            lbFavorites = new ListBox();
            label2 = new Label();
            splitBody = new SplitContainer();
            lvFileExplore = new ListView();
            imageList2 = new ImageList(components);
            panelExtensionFilter = new Panel();
            cbAVIF = new CheckBox();
            cbWEBP = new CheckBox();
            cbTIFF = new CheckBox();
            cbTIF = new CheckBox();
            cbBMP = new CheckBox();
            cbGIF = new CheckBox();
            cbPNG = new CheckBox();
            cbJPEG = new CheckBox();
            cbJPG = new CheckBox();
            cbMOV = new CheckBox();
            cbF4V = new CheckBox();
            cbWMV = new CheckBox();
            cbMP4 = new CheckBox();
            cbWEBM = new CheckBox();
            cbAVCHD = new CheckBox();
            cbFLV = new CheckBox();
            cbM4V = new CheckBox();
            cbMKV = new CheckBox();
            cbAVI = new CheckBox();
            label3 = new Label();
            lbCustomList = new ListBox();
            btnClearList = new FontAwesome.Sharp.IconButton();
            btnClearSelected = new FontAwesome.Sharp.IconButton();
            btnAddSelected = new FontAwesome.Sharp.IconButton();
            btnAddAll = new FontAwesome.Sharp.IconButton();
            tbPathView = new TextBox();
            btnBack = new FontAwesome.Sharp.IconButton();
            lbDriveFolders = new ListBox();
            label1 = new Label();
            imageList1 = new ImageList(components);
            fbDialog = new FolderBrowserDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            toolTipInfo = new ToolTip(components);
            panelTop.SuspendLayout();
            panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitBody).BeginInit();
            splitBody.Panel1.SuspendLayout();
            splitBody.Panel2.SuspendLayout();
            splitBody.SuspendLayout();
            panelExtensionFilter.SuspendLayout();
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
            panelTop.Size = new Size(1124, 20);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(33, 1);
            lblTitle.Margin = new Padding(33, 0, 3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1055, 19);
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
            btnClose.Location = new Point(1094, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.MistyRose;
            panelBody.Controls.Add(btnAddFav);
            panelBody.Controls.Add(btnDeleteFav);
            panelBody.Controls.Add(btnUseList);
            panelBody.Controls.Add(btnSaveList);
            panelBody.Controls.Add(btnDelDuplicates);
            panelBody.Controls.Add(btnLoadList);
            panelBody.Controls.Add(lbFavorites);
            panelBody.Controls.Add(label2);
            panelBody.Controls.Add(splitBody);
            panelBody.Controls.Add(tbPathView);
            panelBody.Controls.Add(btnBack);
            panelBody.Controls.Add(lbDriveFolders);
            panelBody.Controls.Add(label1);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 20);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1124, 551);
            panelBody.TabIndex = 1;
            // 
            // btnAddFav
            // 
            btnAddFav.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddFav.FlatAppearance.BorderSize = 0;
            btnAddFav.FlatStyle = FlatStyle.Flat;
            btnAddFav.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddFav.IconColor = Color.Black;
            btnAddFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddFav.IconSize = 24;
            btnAddFav.Location = new Point(0, 525);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(50, 25);
            btnAddFav.TabIndex = 21;
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // btnDeleteFav
            // 
            btnDeleteFav.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteFav.FlatAppearance.BorderSize = 0;
            btnDeleteFav.FlatStyle = FlatStyle.Flat;
            btnDeleteFav.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
            btnDeleteFav.IconColor = Color.Black;
            btnDeleteFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteFav.IconSize = 24;
            btnDeleteFav.Location = new Point(76, 525);
            btnDeleteFav.Name = "btnDeleteFav";
            btnDeleteFav.Size = new Size(50, 25);
            btnDeleteFav.TabIndex = 22;
            btnDeleteFav.UseVisualStyleBackColor = true;
            btnDeleteFav.Click += btnDeleteFav_Click;
            // 
            // btnUseList
            // 
            btnUseList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUseList.FlatAppearance.BorderSize = 0;
            btnUseList.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            btnUseList.FlatStyle = FlatStyle.Flat;
            btnUseList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUseList.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            btnUseList.IconColor = Color.Black;
            btnUseList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnUseList.IconSize = 24;
            btnUseList.ImageAlign = ContentAlignment.MiddleRight;
            btnUseList.Location = new Point(1037, 7);
            btnUseList.Name = "btnUseList";
            btnUseList.Size = new Size(84, 23);
            btnUseList.TabIndex = 23;
            btnUseList.Text = "Use List";
            btnUseList.TextAlign = ContentAlignment.MiddleLeft;
            btnUseList.UseVisualStyleBackColor = true;
            btnUseList.Click += btnUseList_Click;
            // 
            // btnSaveList
            // 
            btnSaveList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveList.FlatAppearance.BorderSize = 0;
            btnSaveList.FlatStyle = FlatStyle.Flat;
            btnSaveList.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnSaveList.IconColor = Color.Black;
            btnSaveList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnSaveList.IconSize = 24;
            btnSaveList.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaveList.Location = new Point(943, 7);
            btnSaveList.Name = "btnSaveList";
            btnSaveList.Size = new Size(88, 23);
            btnSaveList.TabIndex = 14;
            btnSaveList.Text = "Save List";
            btnSaveList.TextAlign = ContentAlignment.MiddleRight;
            btnSaveList.UseVisualStyleBackColor = true;
            btnSaveList.Click += btnSaveList_Click_1;
            // 
            // btnDelDuplicates
            // 
            btnDelDuplicates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelDuplicates.FlatAppearance.BorderSize = 0;
            btnDelDuplicates.FlatStyle = FlatStyle.Flat;
            btnDelDuplicates.IconChar = FontAwesome.Sharp.IconChar.FilterCircleXmark;
            btnDelDuplicates.IconColor = Color.Black;
            btnDelDuplicates.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelDuplicates.IconSize = 24;
            btnDelDuplicates.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelDuplicates.Location = new Point(728, 7);
            btnDelDuplicates.Name = "btnDelDuplicates";
            btnDelDuplicates.Size = new Size(112, 23);
            btnDelDuplicates.TabIndex = 15;
            btnDelDuplicates.Text = "Del Duplicates";
            btnDelDuplicates.TextAlign = ContentAlignment.MiddleRight;
            btnDelDuplicates.UseVisualStyleBackColor = true;
            btnDelDuplicates.Click += btnDelDuplicates_Click;
            // 
            // btnLoadList
            // 
            btnLoadList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoadList.FlatAppearance.BorderSize = 0;
            btnLoadList.FlatStyle = FlatStyle.Flat;
            btnLoadList.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnLoadList.IconColor = Color.Black;
            btnLoadList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLoadList.IconSize = 24;
            btnLoadList.ImageAlign = ContentAlignment.MiddleLeft;
            btnLoadList.Location = new Point(846, 7);
            btnLoadList.Name = "btnLoadList";
            btnLoadList.Size = new Size(88, 23);
            btnLoadList.TabIndex = 13;
            btnLoadList.Text = "Load List";
            btnLoadList.TextAlign = ContentAlignment.MiddleRight;
            btnLoadList.UseVisualStyleBackColor = true;
            btnLoadList.Click += btnLoadList_Click_1;
            // 
            // lbFavorites
            // 
            lbFavorites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbFavorites.BackColor = Color.MistyRose;
            lbFavorites.BorderStyle = BorderStyle.None;
            lbFavorites.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbFavorites.FormattingEnabled = true;
            lbFavorites.ItemHeight = 15;
            lbFavorites.Location = new Point(0, 265);
            lbFavorites.Name = "lbFavorites";
            lbFavorites.Size = new Size(126, 255);
            lbFavorites.TabIndex = 20;
            lbFavorites.DoubleClick += lbFavorites_DoubleClick;
            lbFavorites.MouseMove += lbFavorites_MouseMove;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(-1, 249);
            label2.Name = "label2";
            label2.Size = new Size(91, 13);
            label2.TabIndex = 19;
            label2.Text = "Favorite folders:";
            // 
            // splitBody
            // 
            splitBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitBody.Location = new Point(126, 35);
            splitBody.Name = "splitBody";
            // 
            // splitBody.Panel1
            // 
            splitBody.Panel1.Controls.Add(lvFileExplore);
            splitBody.Panel1.Controls.Add(panelExtensionFilter);
            // 
            // splitBody.Panel2
            // 
            splitBody.Panel2.Controls.Add(lbCustomList);
            splitBody.Panel2.Controls.Add(btnClearList);
            splitBody.Panel2.Controls.Add(btnClearSelected);
            splitBody.Panel2.Controls.Add(btnAddSelected);
            splitBody.Panel2.Controls.Add(btnAddAll);
            splitBody.Size = new Size(995, 516);
            splitBody.SplitterDistance = 606;
            splitBody.TabIndex = 6;
            // 
            // lvFileExplore
            // 
            lvFileExplore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvFileExplore.BackColor = Color.SeaShell;
            lvFileExplore.LargeImageList = imageList2;
            lvFileExplore.Location = new Point(0, 0);
            lvFileExplore.Name = "lvFileExplore";
            lvFileExplore.ShowItemToolTips = true;
            lvFileExplore.Size = new Size(606, 468);
            lvFileExplore.SmallImageList = imageList2;
            lvFileExplore.TabIndex = 0;
            lvFileExplore.UseCompatibleStateImageBehavior = false;
            lvFileExplore.ItemActivate += lvFileExplore_ItemActivate;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "folder.png");
            imageList2.Images.SetKeyName(1, "avi.png");
            imageList2.Images.SetKeyName(2, "flv.png");
            imageList2.Images.SetKeyName(3, "m4v.png");
            imageList2.Images.SetKeyName(4, "mkv.png");
            imageList2.Images.SetKeyName(5, "mov.png");
            imageList2.Images.SetKeyName(6, "mp4.png");
            imageList2.Images.SetKeyName(7, "webm.png");
            imageList2.Images.SetKeyName(8, "wmv.png");
            imageList2.Images.SetKeyName(9, "f4v.png");
            imageList2.Images.SetKeyName(10, "avchd.png");
            imageList2.Images.SetKeyName(11, "jpg.png");
            imageList2.Images.SetKeyName(12, "jpeg.png");
            imageList2.Images.SetKeyName(13, "png.png");
            imageList2.Images.SetKeyName(14, "gif.png");
            imageList2.Images.SetKeyName(15, "tif.png");
            imageList2.Images.SetKeyName(16, "tiff.png");
            imageList2.Images.SetKeyName(17, "bmp.png");
            imageList2.Images.SetKeyName(18, "webp.png");
            imageList2.Images.SetKeyName(19, "avif.png");
            // 
            // panelExtensionFilter
            // 
            panelExtensionFilter.Controls.Add(cbAVIF);
            panelExtensionFilter.Controls.Add(cbWEBP);
            panelExtensionFilter.Controls.Add(cbTIFF);
            panelExtensionFilter.Controls.Add(cbTIF);
            panelExtensionFilter.Controls.Add(cbBMP);
            panelExtensionFilter.Controls.Add(cbGIF);
            panelExtensionFilter.Controls.Add(cbPNG);
            panelExtensionFilter.Controls.Add(cbJPEG);
            panelExtensionFilter.Controls.Add(cbJPG);
            panelExtensionFilter.Controls.Add(cbMOV);
            panelExtensionFilter.Controls.Add(cbF4V);
            panelExtensionFilter.Controls.Add(cbWMV);
            panelExtensionFilter.Controls.Add(cbMP4);
            panelExtensionFilter.Controls.Add(cbWEBM);
            panelExtensionFilter.Controls.Add(cbAVCHD);
            panelExtensionFilter.Controls.Add(cbFLV);
            panelExtensionFilter.Controls.Add(cbM4V);
            panelExtensionFilter.Controls.Add(cbMKV);
            panelExtensionFilter.Controls.Add(cbAVI);
            panelExtensionFilter.Controls.Add(label3);
            panelExtensionFilter.Dock = DockStyle.Fill;
            panelExtensionFilter.Location = new Point(0, 0);
            panelExtensionFilter.Name = "panelExtensionFilter";
            panelExtensionFilter.Size = new Size(606, 516);
            panelExtensionFilter.TabIndex = 1;
            // 
            // cbAVIF
            // 
            cbAVIF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbAVIF.AutoSize = true;
            cbAVIF.Location = new Point(476, 496);
            cbAVIF.Name = "cbAVIF";
            cbAVIF.Size = new Size(45, 19);
            cbAVIF.TabIndex = 20;
            cbAVIF.Text = "avif";
            cbAVIF.UseVisualStyleBackColor = true;
            // 
            // cbWEBP
            // 
            cbWEBP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbWEBP.AutoSize = true;
            cbWEBP.Location = new Point(415, 496);
            cbWEBP.Name = "cbWEBP";
            cbWEBP.Size = new Size(55, 19);
            cbWEBP.TabIndex = 19;
            cbWEBP.Text = "webp";
            cbWEBP.UseVisualStyleBackColor = true;
            // 
            // cbTIFF
            // 
            cbTIFF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbTIFF.AutoSize = true;
            cbTIFF.Location = new Point(368, 496);
            cbTIFF.Name = "cbTIFF";
            cbTIFF.Size = new Size(41, 19);
            cbTIFF.TabIndex = 18;
            cbTIFF.Text = "tiff";
            cbTIFF.UseVisualStyleBackColor = true;
            // 
            // cbTIF
            // 
            cbTIF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbTIF.AutoSize = true;
            cbTIF.Location = new Point(325, 496);
            cbTIF.Name = "cbTIF";
            cbTIF.Size = new Size(37, 19);
            cbTIF.TabIndex = 17;
            cbTIF.Text = "tif";
            cbTIF.UseVisualStyleBackColor = true;
            // 
            // cbBMP
            // 
            cbBMP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbBMP.AutoSize = true;
            cbBMP.Location = new Point(268, 496);
            cbBMP.Name = "cbBMP";
            cbBMP.Size = new Size(51, 19);
            cbBMP.TabIndex = 16;
            cbBMP.Text = "bmp";
            cbBMP.UseVisualStyleBackColor = true;
            // 
            // cbGIF
            // 
            cbGIF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbGIF.AutoSize = true;
            cbGIF.Location = new Point(222, 496);
            cbGIF.Name = "cbGIF";
            cbGIF.Size = new Size(40, 19);
            cbGIF.TabIndex = 15;
            cbGIF.Text = "gif";
            cbGIF.UseVisualStyleBackColor = true;
            // 
            // cbPNG
            // 
            cbPNG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbPNG.AutoSize = true;
            cbPNG.Location = new Point(169, 496);
            cbPNG.Name = "cbPNG";
            cbPNG.Size = new Size(47, 19);
            cbPNG.TabIndex = 14;
            cbPNG.Text = "png";
            cbPNG.UseVisualStyleBackColor = true;
            // 
            // cbJPEG
            // 
            cbJPEG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbJPEG.AutoSize = true;
            cbJPEG.Location = new Point(114, 496);
            cbJPEG.Name = "cbJPEG";
            cbJPEG.Size = new Size(49, 19);
            cbJPEG.TabIndex = 13;
            cbJPEG.Text = "jpeg";
            cbJPEG.UseVisualStyleBackColor = true;
            // 
            // cbJPG
            // 
            cbJPG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbJPG.AutoSize = true;
            cbJPG.Location = new Point(65, 496);
            cbJPG.Name = "cbJPG";
            cbJPG.Size = new Size(43, 19);
            cbJPG.TabIndex = 12;
            cbJPG.Text = "jpg";
            cbJPG.UseVisualStyleBackColor = true;
            // 
            // cbMOV
            // 
            cbMOV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbMOV.AutoSize = true;
            cbMOV.Location = new Point(114, 472);
            cbMOV.Name = "cbMOV";
            cbMOV.Size = new Size(50, 19);
            cbMOV.TabIndex = 11;
            cbMOV.Text = "mov";
            cbMOV.UseVisualStyleBackColor = true;
            // 
            // cbF4V
            // 
            cbF4V.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbF4V.AutoSize = true;
            cbF4V.Location = new Point(368, 472);
            cbF4V.Name = "cbF4V";
            cbF4V.Size = new Size(42, 19);
            cbF4V.TabIndex = 10;
            cbF4V.Text = "f4v";
            cbF4V.UseVisualStyleBackColor = true;
            // 
            // cbWMV
            // 
            cbWMV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbWMV.AutoSize = true;
            cbWMV.Location = new Point(268, 472);
            cbWMV.Name = "cbWMV";
            cbWMV.Size = new Size(52, 19);
            cbWMV.TabIndex = 9;
            cbWMV.Text = "wmv";
            cbWMV.UseVisualStyleBackColor = true;
            // 
            // cbMP4
            // 
            cbMP4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbMP4.AutoSize = true;
            cbMP4.Location = new Point(415, 472);
            cbMP4.Name = "cbMP4";
            cbMP4.Size = new Size(50, 19);
            cbMP4.TabIndex = 8;
            cbMP4.Text = "mp4";
            cbMP4.UseVisualStyleBackColor = true;
            // 
            // cbWEBM
            // 
            cbWEBM.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbWEBM.AutoSize = true;
            cbWEBM.Location = new Point(476, 472);
            cbWEBM.Name = "cbWEBM";
            cbWEBM.Size = new Size(59, 19);
            cbWEBM.TabIndex = 7;
            cbWEBM.Text = "webm";
            cbWEBM.UseVisualStyleBackColor = true;
            // 
            // cbAVCHD
            // 
            cbAVCHD.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbAVCHD.AutoSize = true;
            cbAVCHD.Location = new Point(541, 472);
            cbAVCHD.Name = "cbAVCHD";
            cbAVCHD.Size = new Size(58, 19);
            cbAVCHD.TabIndex = 6;
            cbAVCHD.Text = "avchd";
            cbAVCHD.UseVisualStyleBackColor = true;
            // 
            // cbFLV
            // 
            cbFLV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbFLV.AutoSize = true;
            cbFLV.Location = new Point(325, 472);
            cbFLV.Name = "cbFLV";
            cbFLV.Size = new Size(39, 19);
            cbFLV.TabIndex = 5;
            cbFLV.Text = "flv";
            cbFLV.UseVisualStyleBackColor = true;
            // 
            // cbM4V
            // 
            cbM4V.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbM4V.AutoSize = true;
            cbM4V.Location = new Point(222, 472);
            cbM4V.Name = "cbM4V";
            cbM4V.Size = new Size(49, 19);
            cbM4V.TabIndex = 4;
            cbM4V.Text = "m4v";
            cbM4V.UseVisualStyleBackColor = true;
            // 
            // cbMKV
            // 
            cbMKV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbMKV.AutoSize = true;
            cbMKV.Location = new Point(169, 472);
            cbMKV.Name = "cbMKV";
            cbMKV.Size = new Size(49, 19);
            cbMKV.TabIndex = 3;
            cbMKV.Text = "mkv";
            cbMKV.UseVisualStyleBackColor = true;
            // 
            // cbAVI
            // 
            cbAVI.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbAVI.AutoSize = true;
            cbAVI.Location = new Point(65, 472);
            cbAVI.Name = "cbAVI";
            cbAVI.Size = new Size(41, 19);
            cbAVI.TabIndex = 2;
            cbAVI.Text = "avi";
            cbAVI.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 467);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(59, 43);
            label3.TabIndex = 0;
            label3.Text = "Filters:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCustomList
            // 
            lbCustomList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbCustomList.BackColor = Color.SeaShell;
            lbCustomList.FormattingEnabled = true;
            lbCustomList.ItemHeight = 15;
            lbCustomList.Location = new Point(0, 0);
            lbCustomList.Name = "lbCustomList";
            lbCustomList.SelectionMode = SelectionMode.MultiExtended;
            lbCustomList.Size = new Size(385, 484);
            lbCustomList.TabIndex = 0;
            lbCustomList.MouseMove += lbCustomList_MouseMove;
            // 
            // btnClearList
            // 
            btnClearList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearList.FlatAppearance.BorderSize = 0;
            btnClearList.FlatStyle = FlatStyle.Flat;
            btnClearList.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            btnClearList.IconColor = Color.Black;
            btnClearList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnClearList.IconSize = 24;
            btnClearList.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearList.Location = new Point(298, 488);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new Size(84, 25);
            btnClearList.TabIndex = 18;
            btnClearList.Text = "Clear All";
            btnClearList.TextAlign = ContentAlignment.MiddleRight;
            btnClearList.UseVisualStyleBackColor = true;
            btnClearList.Click += btnClearList_Click;
            // 
            // btnClearSelected
            // 
            btnClearSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearSelected.FlatAppearance.BorderSize = 0;
            btnClearSelected.FlatStyle = FlatStyle.Flat;
            btnClearSelected.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            btnClearSelected.IconColor = Color.Black;
            btnClearSelected.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClearSelected.IconSize = 24;
            btnClearSelected.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearSelected.Location = new Point(183, 488);
            btnClearSelected.Name = "btnClearSelected";
            btnClearSelected.Size = new Size(109, 25);
            btnClearSelected.TabIndex = 17;
            btnClearSelected.Text = "Clear Selected";
            btnClearSelected.TextAlign = ContentAlignment.MiddleRight;
            btnClearSelected.UseVisualStyleBackColor = true;
            btnClearSelected.Click += btnClearSelected_Click;
            // 
            // btnAddSelected
            // 
            btnAddSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddSelected.FlatAppearance.BorderSize = 0;
            btnAddSelected.FlatStyle = FlatStyle.Flat;
            btnAddSelected.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            btnAddSelected.IconColor = Color.Black;
            btnAddSelected.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddSelected.IconSize = 24;
            btnAddSelected.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddSelected.Location = new Point(-5, 488);
            btnAddSelected.Name = "btnAddSelected";
            btnAddSelected.Size = new Size(105, 25);
            btnAddSelected.TabIndex = 15;
            btnAddSelected.Text = "Add Selected";
            btnAddSelected.TextAlign = ContentAlignment.MiddleRight;
            btnAddSelected.UseVisualStyleBackColor = true;
            btnAddSelected.Click += btnAddSelected_Click;
            // 
            // btnAddAll
            // 
            btnAddAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddAll.FlatAppearance.BorderSize = 0;
            btnAddAll.FlatStyle = FlatStyle.Flat;
            btnAddAll.IconChar = FontAwesome.Sharp.IconChar.SquareMinus;
            btnAddAll.IconColor = Color.Black;
            btnAddAll.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddAll.IconSize = 24;
            btnAddAll.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddAll.Location = new Point(97, 488);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new Size(80, 25);
            btnAddAll.TabIndex = 16;
            btnAddAll.Text = "Add All";
            btnAddAll.TextAlign = ContentAlignment.MiddleRight;
            btnAddAll.UseVisualStyleBackColor = true;
            btnAddAll.Click += btnAddAll_Click;
            // 
            // tbPathView
            // 
            tbPathView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPathView.BackColor = Color.FromArgb(254, 232, 231);
            tbPathView.Location = new Point(39, 6);
            tbPathView.Name = "tbPathView";
            tbPathView.ReadOnly = true;
            tbPathView.Size = new Size(687, 23);
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
            lbDriveFolders.Location = new Point(0, 51);
            lbDriveFolders.Name = "lbDriveFolders";
            lbDriveFolders.Size = new Size(126, 195);
            lbDriveFolders.TabIndex = 11;
            lbDriveFolders.DoubleClick += lbDriveFolders_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(-1, 33);
            label1.Name = "label1";
            label1.Size = new Size(93, 13);
            label1.TabIndex = 12;
            label1.Text = "Available Drives:";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "folder.png");
            imageList1.Images.SetKeyName(1, "film.png");
            imageList1.Images.SetKeyName(2, "image-48.png");
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
            ClientSize = new Size(1124, 571);
            Controls.Add(panelBody);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1020, 550);
            Name = "ListBrowserView";
            Text = "ListBrowserView";
            FormClosing += ListBrowserView_FormClosing;
            Load += ListBrowserView_Load;
            Resize += ListBrowserView_Resize;
            panelTop.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            splitBody.Panel1.ResumeLayout(false);
            splitBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitBody).EndInit();
            splitBody.ResumeLayout(false);
            panelExtensionFilter.ResumeLayout(false);
            panelExtensionFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private FontAwesome.Sharp.IconButton btnClose;
        private Panel panelBody;
        private SplitContainer splitBody;
        private ListView lvFileExplore;
        private ListBox lbCustomList;
        private TextBox tbPathView;
        private FontAwesome.Sharp.IconButton btnBack;
        private FolderBrowserDialog fbDialog;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ImageList imageList1;
        private Label label1;
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
        private Label label2;
        private FontAwesome.Sharp.IconButton btnDeleteFav;
        private FontAwesome.Sharp.IconButton btnAddFav;
        private FontAwesome.Sharp.IconButton btnUseList;
        private Panel panelExtensionFilter;
        private Label label3;
        private CheckBox cbJPG;
        private CheckBox cbMOV;
        private CheckBox cbF4V;
        private CheckBox cbWMV;
        private CheckBox cbMP4;
        private CheckBox cbWEBM;
        private CheckBox cbAVCHD;
        private CheckBox cbFLV;
        private CheckBox cbM4V;
        private CheckBox cbMKV;
        private CheckBox cbAVI;
        private CheckBox cbAVIF;
        private CheckBox cbWEBP;
        private CheckBox cbTIFF;
        private CheckBox cbTIF;
        private CheckBox cbBMP;
        private CheckBox cbGIF;
        private CheckBox cbPNG;
        private CheckBox cbJPEG;
        private ImageList imageList2;
    }
}