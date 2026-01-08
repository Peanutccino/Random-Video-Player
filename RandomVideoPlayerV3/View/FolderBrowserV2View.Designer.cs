namespace RandomVideoPlayer.View
{
    partial class FolderBrowserV2View
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
            panelTop = new Panel();
            lblTitleBar = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelPathContainer = new RandomVideoPlayer.Controls.RoundedPanel();
            flowPanelPath = new RandomVideoPlayer.Controls.BufferedFlowLayoutPanel();
            btnStart = new RandomVideoPlayer.Controls.RoundedButton();
            btnBack = new RandomVideoPlayer.Controls.RoundedButton();
            flowPanelDir = new RandomVideoPlayer.Controls.BufferedFlowLayoutPanel();
            flowPanelFav = new RandomVideoPlayer.Controls.BufferedFlowLayoutPanel();
            tableLayoutSideBar = new TableLayoutPanel();
            label2 = new Label();
            tableLayoutFavButtons = new TableLayoutPanel();
            btnAddFav = new FontAwesome.Sharp.IconButton();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            tableLayoutMain = new TableLayoutPanel();
            panelMainRow1 = new Panel();
            tableLayouMainSub1 = new TableLayoutPanel();
            panelFileExplore = new RandomVideoPlayer.Controls.RoundedPanel();
            lvFileExplore = new ListView();
            columnHeader1 = new ColumnHeader();
            tableToolBar = new TableLayoutPanel();
            panelToolbar3 = new Panel();
            btnFilterVideo = new FontAwesome.Sharp.IconButton();
            btnFilterImage = new FontAwesome.Sharp.IconButton();
            btnFilterScript = new FontAwesome.Sharp.IconButton();
            panelToolbar1 = new Panel();
            lblZoomFactor = new Label();
            sliderZoom = new RandomVideoPlayer.Controls.FlatSlider();
            btnResetSize = new FontAwesome.Sharp.IconButton();
            panelToolbar2 = new Panel();
            btnViewTile = new FontAwesome.Sharp.IconButton();
            btnViewList = new FontAwesome.Sharp.IconButton();
            panelToolbar4 = new Panel();
            cbIncludeSubfolders = new RandomVideoPlayer.Controls.RoundedCheckBox();
            labelPlacerholder1 = new Label();
            cbUseRecent = new RandomVideoPlayer.Controls.RoundedCheckBox();
            sliderLatestCount = new RandomVideoPlayer.Controls.FlatSlider();
            panelTop.SuspendLayout();
            panelPathContainer.SuspendLayout();
            tableLayoutSideBar.SuspendLayout();
            tableLayoutFavButtons.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            panelMainRow1.SuspendLayout();
            tableLayouMainSub1.SuspendLayout();
            panelFileExplore.SuspendLayout();
            tableToolBar.SuspendLayout();
            panelToolbar3.SuspendLayout();
            panelToolbar1.SuspendLayout();
            panelToolbar2.SuspendLayout();
            panelToolbar4.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(247, 110, 100);
            panelTop.Controls.Add(lblTitleBar);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1079, 20);
            panelTop.TabIndex = 0;
            // 
            // lblTitleBar
            // 
            lblTitleBar.Dock = DockStyle.Fill;
            lblTitleBar.Location = new Point(0, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Padding = new Padding(30, 0, 0, 0);
            lblTitleBar.Size = new Size(1049, 20);
            lblTitleBar.TabIndex = 3;
            lblTitleBar.Text = "RVP - Folder Browser";
            lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
            lblTitleBar.MouseDown += lblTitleBar_MouseDown;
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
            btnClose.Location = new Point(1049, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panelPathContainer
            // 
            panelPathContainer.Controls.Add(flowPanelPath);
            panelPathContainer.Controls.Add(btnStart);
            panelPathContainer.Controls.Add(btnBack);
            panelPathContainer.Dock = DockStyle.Top;
            panelPathContainer.FillColor = Color.Fuchsia;
            panelPathContainer.Location = new Point(10, 5);
            panelPathContainer.Margin = new Padding(3, 2, 3, 3);
            panelPathContainer.Name = "panelPathContainer";
            panelPathContainer.Padding = new Padding(3, 2, 6, 5);
            panelPathContainer.RadiusBottomLeft = 17;
            panelPathContainer.RadiusBottomRight = 17;
            panelPathContainer.RadiusTopLeft = 17;
            panelPathContainer.RadiusTopRight = 17;
            panelPathContainer.Size = new Size(1059, 34);
            panelPathContainer.TabIndex = 1;
            // 
            // flowPanelPath
            // 
            flowPanelPath.BackColor = Color.FromArgb(192, 64, 0);
            flowPanelPath.Dock = DockStyle.Fill;
            flowPanelPath.Font = new Font("Inter", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowPanelPath.Location = new Point(31, 2);
            flowPanelPath.Name = "flowPanelPath";
            flowPanelPath.Padding = new Padding(5, 5, 0, 0);
            flowPanelPath.Size = new Size(876, 27);
            flowPanelPath.TabIndex = 4;
            flowPanelPath.WrapContents = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(247, 110, 100);
            btnStart.BackgroundColor = Color.FromArgb(209, 159, 156);
            btnStart.BorderColor = Color.PaleVioletRed;
            btnStart.BorderRadius = 14;
            btnStart.BorderSize = 0;
            btnStart.Dock = DockStyle.Right;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.Black;
            btnStart.ImageAlign = ContentAlignment.MiddleRight;
            btnStart.Location = new Point(907, 2);
            btnStart.Name = "btnStart";
            btnStart.Padding = new Padding(8, 0, 8, 0);
            btnStart.Size = new Size(146, 27);
            btnStart.TabIndex = 3;
            btnStart.Text = "Play selected";
            btnStart.TextAlign = ContentAlignment.MiddleLeft;
            btnStart.TextColor = Color.Black;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(247, 110, 100);
            btnBack.BackgroundColor = Color.FromArgb(209, 159, 156);
            btnBack.BorderColor = Color.PaleVioletRed;
            btnBack.BorderRadius = 14;
            btnBack.BorderSize = 0;
            btnBack.Dock = DockStyle.Left;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(28, 27);
            btnBack.TabIndex = 2;
            btnBack.TextColor = Color.White;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // flowPanelDir
            // 
            flowPanelDir.AutoSize = true;
            flowPanelDir.BackColor = Color.Khaki;
            flowPanelDir.Dock = DockStyle.Fill;
            flowPanelDir.FlowDirection = FlowDirection.TopDown;
            flowPanelDir.Location = new Point(0, 18);
            flowPanelDir.Margin = new Padding(0, 18, 0, 0);
            flowPanelDir.MinimumSize = new Size(0, 100);
            flowPanelDir.Name = "flowPanelDir";
            flowPanelDir.Size = new Size(140, 100);
            flowPanelDir.TabIndex = 2;
            // 
            // flowPanelFav
            // 
            flowPanelFav.BackColor = Color.Khaki;
            flowPanelFav.Dock = DockStyle.Fill;
            flowPanelFav.FlowDirection = FlowDirection.TopDown;
            flowPanelFav.Location = new Point(0, 178);
            flowPanelFav.Margin = new Padding(0);
            flowPanelFav.Name = "flowPanelFav";
            flowPanelFav.Size = new Size(140, 288);
            flowPanelFav.TabIndex = 3;
            // 
            // tableLayoutSideBar
            // 
            tableLayoutSideBar.BackColor = Color.Gold;
            tableLayoutSideBar.ColumnCount = 1;
            tableLayoutSideBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutSideBar.Controls.Add(label2, 0, 1);
            tableLayoutSideBar.Controls.Add(flowPanelDir, 0, 0);
            tableLayoutSideBar.Controls.Add(flowPanelFav, 0, 3);
            tableLayoutSideBar.Controls.Add(tableLayoutFavButtons, 0, 2);
            tableLayoutSideBar.Dock = DockStyle.Fill;
            tableLayoutSideBar.Location = new Point(0, 31);
            tableLayoutSideBar.Margin = new Padding(0);
            tableLayoutSideBar.Name = "tableLayoutSideBar";
            tableLayoutSideBar.RowCount = 4;
            tableLayoutSideBar.RowStyles.Add(new RowStyle());
            tableLayoutSideBar.RowStyles.Add(new RowStyle());
            tableLayoutSideBar.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutSideBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutSideBar.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutSideBar.Size = new Size(140, 466);
            tableLayoutSideBar.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 118);
            label2.Name = "label2";
            label2.Size = new Size(134, 30);
            label2.TabIndex = 3;
            label2.Text = "Favorites";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutFavButtons
            // 
            tableLayoutFavButtons.ColumnCount = 2;
            tableLayoutFavButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutFavButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutFavButtons.Controls.Add(btnAddFav, 1, 0);
            tableLayoutFavButtons.Controls.Add(btnDeleteFav, 0, 0);
            tableLayoutFavButtons.Dock = DockStyle.Fill;
            tableLayoutFavButtons.Location = new Point(3, 151);
            tableLayoutFavButtons.Name = "tableLayoutFavButtons";
            tableLayoutFavButtons.RowCount = 1;
            tableLayoutFavButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutFavButtons.Size = new Size(134, 24);
            tableLayoutFavButtons.TabIndex = 4;
            // 
            // btnAddFav
            // 
            btnAddFav.Dock = DockStyle.Fill;
            btnAddFav.FlatAppearance.BorderSize = 0;
            btnAddFav.FlatStyle = FlatStyle.Flat;
            btnAddFav.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddFav.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnAddFav.IconColor = Color.Black;
            btnAddFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddFav.IconSize = 26;
            btnAddFav.Location = new Point(67, 0);
            btnAddFav.Margin = new Padding(0);
            btnAddFav.Name = "btnAddFav";
            btnAddFav.Size = new Size(67, 24);
            btnAddFav.TabIndex = 14;
            btnAddFav.UseVisualStyleBackColor = true;
            btnAddFav.Click += btnAddFav_Click;
            // 
            // btnDeleteFav
            // 
            btnDeleteFav.Dock = DockStyle.Fill;
            btnDeleteFav.FlatAppearance.BorderSize = 0;
            btnDeleteFav.FlatStyle = FlatStyle.Flat;
            btnDeleteFav.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDeleteFav.IconChar = FontAwesome.Sharp.IconChar.FolderMinus;
            btnDeleteFav.IconColor = Color.Black;
            btnDeleteFav.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteFav.IconSize = 26;
            btnDeleteFav.Location = new Point(0, 0);
            btnDeleteFav.Margin = new Padding(0);
            btnDeleteFav.Name = "btnDeleteFav";
            btnDeleteFav.Size = new Size(67, 24);
            btnDeleteFav.TabIndex = 13;
            btnDeleteFav.UseVisualStyleBackColor = true;
            btnDeleteFav.Click += btnDeleteFav_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 31);
            label1.TabIndex = 0;
            label1.Text = "Directories";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.FromArgb(128, 255, 128);
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(panelMainRow1, 0, 0);
            tableLayoutMain.Controls.Add(tableLayouMainSub1, 0, 1);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 20);
            tableLayoutMain.Margin = new Padding(0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 2;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.Size = new Size(1079, 541);
            tableLayoutMain.TabIndex = 7;
            // 
            // panelMainRow1
            // 
            panelMainRow1.BackColor = Color.FromArgb(128, 255, 255);
            panelMainRow1.Controls.Add(panelPathContainer);
            panelMainRow1.Dock = DockStyle.Fill;
            panelMainRow1.Location = new Point(0, 0);
            panelMainRow1.Margin = new Padding(0);
            panelMainRow1.Name = "panelMainRow1";
            panelMainRow1.Padding = new Padding(10, 5, 10, 0);
            panelMainRow1.Size = new Size(1079, 44);
            panelMainRow1.TabIndex = 0;
            // 
            // tableLayouMainSub1
            // 
            tableLayouMainSub1.BackColor = Color.Yellow;
            tableLayouMainSub1.ColumnCount = 2;
            tableLayouMainSub1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayouMainSub1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayouMainSub1.Controls.Add(tableLayoutSideBar, 0, 1);
            tableLayouMainSub1.Controls.Add(label1, 0, 0);
            tableLayouMainSub1.Controls.Add(panelFileExplore, 1, 1);
            tableLayouMainSub1.Controls.Add(tableToolBar, 1, 0);
            tableLayouMainSub1.Dock = DockStyle.Fill;
            tableLayouMainSub1.Location = new Point(0, 44);
            tableLayouMainSub1.Margin = new Padding(0);
            tableLayouMainSub1.Name = "tableLayouMainSub1";
            tableLayouMainSub1.RowCount = 2;
            tableLayouMainSub1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayouMainSub1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayouMainSub1.Size = new Size(1079, 497);
            tableLayouMainSub1.TabIndex = 1;
            // 
            // panelFileExplore
            // 
            panelFileExplore.BackColor = Color.IndianRed;
            panelFileExplore.Controls.Add(lvFileExplore);
            panelFileExplore.Dock = DockStyle.Fill;
            panelFileExplore.FillColor = Color.White;
            panelFileExplore.Location = new Point(140, 34);
            panelFileExplore.Margin = new Padding(0, 3, 0, 0);
            panelFileExplore.Name = "panelFileExplore";
            panelFileExplore.Padding = new Padding(5, 8, 3, 3);
            panelFileExplore.RadiusBottomLeft = 0;
            panelFileExplore.RadiusBottomRight = 0;
            panelFileExplore.RadiusTopLeft = 16;
            panelFileExplore.RadiusTopRight = 0;
            panelFileExplore.Size = new Size(939, 463);
            panelFileExplore.TabIndex = 5;
            // 
            // lvFileExplore
            // 
            lvFileExplore.BackColor = SystemColors.ScrollBar;
            lvFileExplore.BorderStyle = BorderStyle.None;
            lvFileExplore.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvFileExplore.Dock = DockStyle.Fill;
            lvFileExplore.FullRowSelect = true;
            lvFileExplore.HeaderStyle = ColumnHeaderStyle.None;
            lvFileExplore.Location = new Point(5, 8);
            lvFileExplore.Name = "lvFileExplore";
            lvFileExplore.Size = new Size(931, 452);
            lvFileExplore.TabIndex = 0;
            lvFileExplore.UseCompatibleStateImageBehavior = false;
            lvFileExplore.VirtualMode = true;
            lvFileExplore.CacheVirtualItems += lvFileExplore_CacheVirtualItems;
            lvFileExplore.ItemActivate += lvFileExplore_ItemActivate;
            lvFileExplore.RetrieveVirtualItem += lvFileExplore_RetrieveVirtualItem;
            lvFileExplore.MouseDown += lvFileExplore_MouseDown;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            // 
            // tableToolBar
            // 
            tableToolBar.BackColor = Color.PaleGreen;
            tableToolBar.ColumnCount = 4;
            tableToolBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            tableToolBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            tableToolBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableToolBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableToolBar.Controls.Add(panelToolbar3, 2, 0);
            tableToolBar.Controls.Add(panelToolbar1, 0, 0);
            tableToolBar.Controls.Add(panelToolbar2, 1, 0);
            tableToolBar.Controls.Add(panelToolbar4, 3, 0);
            tableToolBar.Dock = DockStyle.Fill;
            tableToolBar.Location = new Point(140, 0);
            tableToolBar.Margin = new Padding(0);
            tableToolBar.Name = "tableToolBar";
            tableToolBar.RowCount = 1;
            tableToolBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableToolBar.Size = new Size(939, 31);
            tableToolBar.TabIndex = 6;
            // 
            // panelToolbar3
            // 
            panelToolbar3.BackColor = Color.Olive;
            panelToolbar3.Controls.Add(btnFilterVideo);
            panelToolbar3.Controls.Add(btnFilterImage);
            panelToolbar3.Controls.Add(btnFilterScript);
            panelToolbar3.Dock = DockStyle.Fill;
            panelToolbar3.Location = new Point(346, 0);
            panelToolbar3.Margin = new Padding(0);
            panelToolbar3.Name = "panelToolbar3";
            panelToolbar3.Size = new Size(140, 31);
            panelToolbar3.TabIndex = 0;
            // 
            // btnFilterVideo
            // 
            btnFilterVideo.Dock = DockStyle.Right;
            btnFilterVideo.FlatAppearance.BorderSize = 0;
            btnFilterVideo.FlatStyle = FlatStyle.Flat;
            btnFilterVideo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilterVideo.IconChar = FontAwesome.Sharp.IconChar.FileVideo;
            btnFilterVideo.IconColor = Color.Black;
            btnFilterVideo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnFilterVideo.IconSize = 24;
            btnFilterVideo.Location = new Point(20, 0);
            btnFilterVideo.Name = "btnFilterVideo";
            btnFilterVideo.Size = new Size(40, 31);
            btnFilterVideo.TabIndex = 25;
            btnFilterVideo.UseVisualStyleBackColor = true;
            btnFilterVideo.Click += btnFilterVideo_Click;
            // 
            // btnFilterImage
            // 
            btnFilterImage.Dock = DockStyle.Right;
            btnFilterImage.FlatAppearance.BorderSize = 0;
            btnFilterImage.FlatStyle = FlatStyle.Flat;
            btnFilterImage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilterImage.IconChar = FontAwesome.Sharp.IconChar.FileImage;
            btnFilterImage.IconColor = Color.Black;
            btnFilterImage.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnFilterImage.IconSize = 24;
            btnFilterImage.Location = new Point(60, 0);
            btnFilterImage.Name = "btnFilterImage";
            btnFilterImage.Size = new Size(40, 31);
            btnFilterImage.TabIndex = 26;
            btnFilterImage.UseVisualStyleBackColor = true;
            btnFilterImage.Click += btnFilterImage_Click;
            // 
            // btnFilterScript
            // 
            btnFilterScript.Dock = DockStyle.Right;
            btnFilterScript.FlatAppearance.BorderSize = 0;
            btnFilterScript.FlatStyle = FlatStyle.Flat;
            btnFilterScript.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilterScript.IconChar = FontAwesome.Sharp.IconChar.FileMedicalAlt;
            btnFilterScript.IconColor = Color.Black;
            btnFilterScript.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnFilterScript.IconSize = 24;
            btnFilterScript.Location = new Point(100, 0);
            btnFilterScript.Name = "btnFilterScript";
            btnFilterScript.Size = new Size(40, 31);
            btnFilterScript.TabIndex = 27;
            btnFilterScript.UseVisualStyleBackColor = true;
            btnFilterScript.Click += btnFilterScript_Click;
            // 
            // panelToolbar1
            // 
            panelToolbar1.Controls.Add(lblZoomFactor);
            panelToolbar1.Controls.Add(sliderZoom);
            panelToolbar1.Controls.Add(btnResetSize);
            panelToolbar1.Dock = DockStyle.Fill;
            panelToolbar1.Location = new Point(0, 0);
            panelToolbar1.Margin = new Padding(0);
            panelToolbar1.Name = "panelToolbar1";
            panelToolbar1.Padding = new Padding(10, 0, 0, 0);
            panelToolbar1.Size = new Size(215, 31);
            panelToolbar1.TabIndex = 0;
            // 
            // lblZoomFactor
            // 
            lblZoomFactor.Dock = DockStyle.Left;
            lblZoomFactor.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblZoomFactor.Location = new Point(140, 0);
            lblZoomFactor.Name = "lblZoomFactor";
            lblZoomFactor.Size = new Size(46, 31);
            lblZoomFactor.TabIndex = 22;
            lblZoomFactor.Text = "30%";
            lblZoomFactor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sliderZoom
            // 
            sliderZoom.Dock = DockStyle.Left;
            sliderZoom.ElapsedColor = Color.FromArgb(247, 110, 100);
            sliderZoom.HighlightColor = Color.PaleGreen;
            sliderZoom.Location = new Point(40, 0);
            sliderZoom.Maximum = 100;
            sliderZoom.Minimum = 0;
            sliderZoom.Name = "sliderZoom";
            sliderZoom.RemainingColor = Color.FromArgb(209, 159, 156);
            sliderZoom.Size = new Size(100, 31);
            sliderZoom.SmallChange = 5;
            sliderZoom.TabIndex = 17;
            sliderZoom.Text = "flatSlider1";
            sliderZoom.ThumbColor = Color.FromArgb(247, 110, 100);
            sliderZoom.ThumbSize = new Size(14, 14);
            sliderZoom.Value = 30;
            sliderZoom.ValueChanged += sliderZoom_ValueChanged;
            // 
            // btnResetSize
            // 
            btnResetSize.Dock = DockStyle.Left;
            btnResetSize.FlatAppearance.BorderSize = 0;
            btnResetSize.FlatStyle = FlatStyle.Flat;
            btnResetSize.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnResetSize.IconColor = Color.Black;
            btnResetSize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnResetSize.IconSize = 26;
            btnResetSize.Location = new Point(10, 0);
            btnResetSize.Name = "btnResetSize";
            btnResetSize.Size = new Size(30, 31);
            btnResetSize.TabIndex = 16;
            btnResetSize.UseVisualStyleBackColor = true;
            btnResetSize.Click += btnResetSize_Click;
            // 
            // panelToolbar2
            // 
            panelToolbar2.BackColor = Color.LimeGreen;
            panelToolbar2.Controls.Add(btnViewTile);
            panelToolbar2.Controls.Add(btnViewList);
            panelToolbar2.Dock = DockStyle.Fill;
            panelToolbar2.Location = new Point(215, 0);
            panelToolbar2.Margin = new Padding(0);
            panelToolbar2.Name = "panelToolbar2";
            panelToolbar2.Size = new Size(131, 31);
            panelToolbar2.TabIndex = 1;
            // 
            // btnViewTile
            // 
            btnViewTile.Dock = DockStyle.Left;
            btnViewTile.FlatAppearance.BorderSize = 0;
            btnViewTile.FlatStyle = FlatStyle.Flat;
            btnViewTile.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewTile.IconChar = FontAwesome.Sharp.IconChar.TableCells;
            btnViewTile.IconColor = Color.Black;
            btnViewTile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewTile.IconSize = 30;
            btnViewTile.Location = new Point(40, 0);
            btnViewTile.Name = "btnViewTile";
            btnViewTile.Size = new Size(40, 31);
            btnViewTile.TabIndex = 21;
            btnViewTile.UseVisualStyleBackColor = true;
            btnViewTile.Click += btnViewTile_Click;
            // 
            // btnViewList
            // 
            btnViewList.Dock = DockStyle.Left;
            btnViewList.FlatAppearance.BorderSize = 0;
            btnViewList.FlatStyle = FlatStyle.Flat;
            btnViewList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewList.IconChar = FontAwesome.Sharp.IconChar.TableList;
            btnViewList.IconColor = Color.Black;
            btnViewList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewList.IconSize = 30;
            btnViewList.Location = new Point(0, 0);
            btnViewList.Name = "btnViewList";
            btnViewList.Size = new Size(40, 31);
            btnViewList.TabIndex = 20;
            btnViewList.UseVisualStyleBackColor = true;
            btnViewList.Click += btnViewList_Click;
            // 
            // panelToolbar4
            // 
            panelToolbar4.BackColor = Color.Wheat;
            panelToolbar4.Controls.Add(cbIncludeSubfolders);
            panelToolbar4.Controls.Add(labelPlacerholder1);
            panelToolbar4.Controls.Add(cbUseRecent);
            panelToolbar4.Controls.Add(sliderLatestCount);
            panelToolbar4.Dock = DockStyle.Fill;
            panelToolbar4.Location = new Point(486, 2);
            panelToolbar4.Margin = new Padding(0, 2, 0, 2);
            panelToolbar4.Name = "panelToolbar4";
            panelToolbar4.Size = new Size(453, 27);
            panelToolbar4.TabIndex = 2;
            // 
            // cbIncludeSubfolders
            // 
            cbIncludeSubfolders.Appearance = Appearance.Button;
            cbIncludeSubfolders.BackColor = Color.Transparent;
            cbIncludeSubfolders.Checked = true;
            cbIncludeSubfolders.CheckedBackColor = Color.FromArgb(247, 110, 100);
            cbIncludeSubfolders.CheckState = CheckState.Checked;
            cbIncludeSubfolders.Dock = DockStyle.Right;
            cbIncludeSubfolders.FlatAppearance.BorderSize = 0;
            cbIncludeSubfolders.FlatStyle = FlatStyle.Flat;
            cbIncludeSubfolders.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbIncludeSubfolders.Location = new Point(87, 0);
            cbIncludeSubfolders.Name = "cbIncludeSubfolders";
            cbIncludeSubfolders.Size = new Size(124, 27);
            cbIncludeSubfolders.TabIndex = 29;
            cbIncludeSubfolders.Text = "Subdirectories";
            cbIncludeSubfolders.UncheckedBackColor = Color.FromArgb(209, 159, 156);
            cbIncludeSubfolders.UncheckedForeColor = Color.White;
            cbIncludeSubfolders.UseVisualStyleBackColor = false;
            // 
            // labelPlacerholder1
            // 
            labelPlacerholder1.Dock = DockStyle.Right;
            labelPlacerholder1.Location = new Point(211, 0);
            labelPlacerholder1.Name = "labelPlacerholder1";
            labelPlacerholder1.Size = new Size(12, 27);
            labelPlacerholder1.TabIndex = 33;
            // 
            // cbUseRecent
            // 
            cbUseRecent.Appearance = Appearance.Button;
            cbUseRecent.BackColor = Color.Transparent;
            cbUseRecent.CheckedBackColor = Color.FromArgb(247, 110, 100);
            cbUseRecent.Dock = DockStyle.Right;
            cbUseRecent.FlatAppearance.BorderSize = 0;
            cbUseRecent.FlatStyle = FlatStyle.Flat;
            cbUseRecent.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbUseRecent.Location = new Point(223, 0);
            cbUseRecent.Name = "cbUseRecent";
            cbUseRecent.Size = new Size(130, 27);
            cbUseRecent.TabIndex = 31;
            cbUseRecent.Text = "Latest 100 files";
            cbUseRecent.UncheckedBackColor = Color.FromArgb(209, 159, 156);
            cbUseRecent.UncheckedForeColor = Color.White;
            cbUseRecent.UseVisualStyleBackColor = false;
            // 
            // sliderLatestCount
            // 
            sliderLatestCount.Dock = DockStyle.Right;
            sliderLatestCount.ElapsedColor = Color.FromArgb(247, 110, 100);
            sliderLatestCount.HighlightColor = Color.PaleGreen;
            sliderLatestCount.Location = new Point(353, 0);
            sliderLatestCount.Maximum = 100;
            sliderLatestCount.Minimum = 10;
            sliderLatestCount.Name = "sliderLatestCount";
            sliderLatestCount.RemainingColor = Color.FromArgb(209, 159, 156);
            sliderLatestCount.Size = new Size(100, 27);
            sliderLatestCount.SmallChange = 5;
            sliderLatestCount.TabIndex = 32;
            sliderLatestCount.Text = "flatSlider1";
            sliderLatestCount.ThumbColor = Color.FromArgb(247, 110, 100);
            sliderLatestCount.ThumbSize = new Size(14, 14);
            sliderLatestCount.Value = 50;
            sliderLatestCount.ValueChanged += sliderLatestCount_ValueChanged;
            // 
            // FolderBrowserV2View
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(195, 129, 125);
            ClientSize = new Size(1079, 561);
            Controls.Add(tableLayoutMain);
            Controls.Add(panelTop);
            MinimumSize = new Size(1090, 600);
            Name = "FolderBrowserV2View";
            Text = "FolderBrowserV2View";
            Load += FolderBrowserV2View_Load;
            ResizeEnd += FolderBrowserV2View_ResizeEnd;
            Resize += FolderBrowserV2View_Resize;
            panelTop.ResumeLayout(false);
            panelPathContainer.ResumeLayout(false);
            tableLayoutSideBar.ResumeLayout(false);
            tableLayoutSideBar.PerformLayout();
            tableLayoutFavButtons.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            panelMainRow1.ResumeLayout(false);
            tableLayouMainSub1.ResumeLayout(false);
            tableLayouMainSub1.PerformLayout();
            panelFileExplore.ResumeLayout(false);
            tableToolBar.ResumeLayout(false);
            panelToolbar3.ResumeLayout(false);
            panelToolbar1.ResumeLayout(false);
            panelToolbar2.ResumeLayout(false);
            panelToolbar4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private FontAwesome.Sharp.IconButton btnClose;
        private Label lblTitleBar;
        private Controls.RoundedPanel panelPathContainer;
        private Controls.RoundedButton btnBack;
        private Controls.RoundedButton btnStart;
        private Controls.BufferedFlowLayoutPanel flowPanelDir;
        private Controls.BufferedFlowLayoutPanel flowPanelFav;
        private TableLayoutPanel tableLayoutSideBar;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutFavButtons;
        private FontAwesome.Sharp.IconButton btnDeleteFav;
        private FontAwesome.Sharp.IconButton btnAddFav;
        private TableLayoutPanel tableLayoutMain;
        private Panel panelMainRow1;
        private TableLayoutPanel tableLayouMainSub1;
        private Controls.RoundedPanel panelFileExplore;
        private Controls.FlatSlider sliderZoom;
        private FontAwesome.Sharp.IconButton btnResetSize;
        private FontAwesome.Sharp.IconButton btnViewList;
        private FontAwesome.Sharp.IconButton btnViewTile;
        private Label lblZoomFactor;
        private FontAwesome.Sharp.IconButton btnFilterVideo;
        private Label labelPlaceholder3;
        private FontAwesome.Sharp.IconButton btnFilterScript;
        private FontAwesome.Sharp.IconButton btnFilterImage;
        private Controls.RoundedCheckBox cbIncludeSubfolders;
        private Controls.RoundedCheckBox cbUseRecent;
        private Label labelPlaceholder4;
        private Controls.FlatSlider sliderLatestCount;
        private ListView lvFileExplore;
        private Controls.BufferedFlowLayoutPanel flowPanelPath;
        private Label labelPlacerholder1;
        private ColumnHeader columnHeader1;
        private TableLayoutPanel tableToolBar;
        private Panel panelToolbar3;
        private Panel panelToolbar1;
        private Panel panelToolbar2;
        private Panel panelToolbar4;
    }
}