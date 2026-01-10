namespace RandomVideoPlayer.Views
{
    partial class ListBrowserV2View
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
            tableLayoutMain = new TableLayoutPanel();
            panelMainRow1 = new Panel();
            panelPathContainer = new RandomVideoPlayer.Controls.RoundedPanel();
            flowPanelPath = new RandomVideoPlayer.Controls.BufferedFlowLayoutPanel();
            btnStart = new RandomVideoPlayer.Controls.RoundedButton();
            btnBack = new RandomVideoPlayer.Controls.RoundedButton();
            splitContainerMain = new SplitContainer();
            tableLayouMainSub1 = new TableLayoutPanel();
            tableLayoutSideBar = new TableLayoutPanel();
            label2 = new Label();
            flowPanelDir = new RandomVideoPlayer.Controls.BufferedFlowLayoutPanel();
            flowPanelFav = new RandomVideoPlayer.Controls.BufferedFlowLayoutPanel();
            tableLayoutFavButtons = new TableLayoutPanel();
            btnAddFav = new FontAwesome.Sharp.IconButton();
            btnDeleteFav = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panelFileExplore = new RandomVideoPlayer.Controls.RoundedPanel();
            lvFileExplore = new ListView();
            columnHeader1 = new ColumnHeader();
            tableToolBar = new TableLayoutPanel();
            panelToolbar3 = new Panel();
            btnFilterScript = new FontAwesome.Sharp.IconButton();
            btnFilterImage = new FontAwesome.Sharp.IconButton();
            btnFilterVideo = new FontAwesome.Sharp.IconButton();
            panelToolbar1 = new Panel();
            lblZoomFactor = new Label();
            sliderZoom = new RandomVideoPlayer.Controls.FlatSlider();
            btnResetSize = new FontAwesome.Sharp.IconButton();
            panelToolbar2 = new Panel();
            btnViewLargeGrid = new FontAwesome.Sharp.IconButton();
            btnViewSmallGrid = new FontAwesome.Sharp.IconButton();
            btnViewList = new FontAwesome.Sharp.IconButton();
            tableLayoutCustomPanel = new TableLayoutPanel();
            roundedPanelCustomList = new RandomVideoPlayer.Controls.RoundedPanel();
            lvCustomList = new ListView();
            columnHeader2 = new ColumnHeader();
            roundedPanelCustomListBottom = new RandomVideoPlayer.Controls.RoundedPanel();
            panelCustomListBottom = new Panel();
            lblEntries = new Label();
            lblSide4 = new Label();
            cbFullPath = new RandomVideoPlayer.Controls.RoundedCheckBox();
            lblSide3 = new Label();
            roundedPanelCustomListTop = new RandomVideoPlayer.Controls.RoundedPanel();
            lblLoadedList = new Label();
            lblSide2 = new Label();
            lblSide1 = new Label();
            panel1 = new Panel();
            roundedPanelSideBottom = new RandomVideoPlayer.Controls.RoundedPanel();
            roundedPanelSideCenter = new RandomVideoPlayer.Controls.RoundedPanel();
            btnMoveList = new FontAwesome.Sharp.IconButton();
            btnAddFromPlaylist = new FontAwesome.Sharp.IconButton();
            btnSaveList = new FontAwesome.Sharp.IconButton();
            btnLoadList = new FontAwesome.Sharp.IconButton();
            btnDelDuplicates = new FontAwesome.Sharp.IconButton();
            btnClearSelected = new FontAwesome.Sharp.IconButton();
            btnClearList = new FontAwesome.Sharp.IconButton();
            roundedPanelSideTop = new RandomVideoPlayer.Controls.RoundedPanel();
            btnAddAll = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            btnAddSelected = new FontAwesome.Sharp.IconButton();
            panelTop = new Panel();
            lblTitleBar = new Label();
            btnClose = new FontAwesome.Sharp.IconButton();
            tableLayoutMain.SuspendLayout();
            panelMainRow1.SuspendLayout();
            panelPathContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tableLayouMainSub1.SuspendLayout();
            tableLayoutSideBar.SuspendLayout();
            tableLayoutFavButtons.SuspendLayout();
            panelFileExplore.SuspendLayout();
            tableToolBar.SuspendLayout();
            panelToolbar3.SuspendLayout();
            panelToolbar1.SuspendLayout();
            panelToolbar2.SuspendLayout();
            tableLayoutCustomPanel.SuspendLayout();
            roundedPanelCustomList.SuspendLayout();
            roundedPanelCustomListBottom.SuspendLayout();
            panelCustomListBottom.SuspendLayout();
            roundedPanelCustomListTop.SuspendLayout();
            panel1.SuspendLayout();
            roundedPanelSideCenter.SuspendLayout();
            roundedPanelSideTop.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.LightGreen;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(panelMainRow1, 0, 0);
            tableLayoutMain.Controls.Add(splitContainerMain, 0, 1);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 20);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 2;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.Size = new Size(1339, 668);
            tableLayoutMain.TabIndex = 0;
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
            panelMainRow1.Size = new Size(1339, 44);
            panelMainRow1.TabIndex = 1;
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
            panelPathContainer.Padding = new Padding(3, 2, 6, 4);
            panelPathContainer.RadiusBottomLeft = 17;
            panelPathContainer.RadiusBottomRight = 17;
            panelPathContainer.RadiusTopLeft = 17;
            panelPathContainer.RadiusTopRight = 17;
            panelPathContainer.Size = new Size(1319, 34);
            panelPathContainer.TabIndex = 1;
            // 
            // flowPanelPath
            // 
            flowPanelPath.BackColor = Color.FromArgb(192, 64, 0);
            flowPanelPath.Dock = DockStyle.Fill;
            flowPanelPath.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowPanelPath.Location = new Point(31, 2);
            flowPanelPath.Name = "flowPanelPath";
            flowPanelPath.Padding = new Padding(5, 5, 0, 0);
            flowPanelPath.Size = new Size(1166, 28);
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
            btnStart.Location = new Point(1197, 2);
            btnStart.Name = "btnStart";
            btnStart.Padding = new Padding(12, 0, 8, 0);
            btnStart.Size = new Size(116, 28);
            btnStart.TabIndex = 3;
            btnStart.Text = "Play list";
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
            btnBack.Size = new Size(28, 28);
            btnBack.TabIndex = 2;
            btnBack.TextColor = Color.White;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.BackColor = Color.Aquamarine;
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(3, 47);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(tableLayouMainSub1);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(tableLayoutCustomPanel);
            splitContainerMain.Size = new Size(1333, 618);
            splitContainerMain.SplitterDistance = 716;
            splitContainerMain.TabIndex = 2;
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
            tableLayouMainSub1.Location = new Point(0, 0);
            tableLayouMainSub1.Margin = new Padding(0);
            tableLayouMainSub1.Name = "tableLayouMainSub1";
            tableLayouMainSub1.RowCount = 2;
            tableLayouMainSub1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayouMainSub1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayouMainSub1.Size = new Size(716, 618);
            tableLayouMainSub1.TabIndex = 2;
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
            tableLayoutSideBar.Size = new Size(140, 587);
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
            flowPanelFav.Size = new Size(140, 409);
            flowPanelFav.TabIndex = 3;
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
            // panelFileExplore
            // 
            panelFileExplore.BackColor = Color.IndianRed;
            panelFileExplore.Controls.Add(lvFileExplore);
            panelFileExplore.Dock = DockStyle.Fill;
            panelFileExplore.FillColor = Color.White;
            panelFileExplore.Location = new Point(140, 34);
            panelFileExplore.Margin = new Padding(0, 3, 0, 0);
            panelFileExplore.Name = "panelFileExplore";
            panelFileExplore.Padding = new Padding(6, 6, 2, 2);
            panelFileExplore.RadiusBottomLeft = 0;
            panelFileExplore.RadiusBottomRight = 0;
            panelFileExplore.RadiusTopLeft = 16;
            panelFileExplore.RadiusTopRight = 0;
            panelFileExplore.Size = new Size(576, 584);
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
            lvFileExplore.Location = new Point(6, 6);
            lvFileExplore.Name = "lvFileExplore";
            lvFileExplore.ShowItemToolTips = true;
            lvFileExplore.Size = new Size(568, 576);
            lvFileExplore.TabIndex = 0;
            lvFileExplore.UseCompatibleStateImageBehavior = false;
            lvFileExplore.VirtualMode = true;
            lvFileExplore.CacheVirtualItems += lvFileExplore_CacheVirtualItems;
            lvFileExplore.ItemActivate += lvFileExplore_ItemActivate;
            lvFileExplore.RetrieveVirtualItem += lvFileExplore_RetrieveVirtualItem;
            lvFileExplore.MouseDown += lvFileExplore_MouseDown;
            lvFileExplore.MouseMove += lvFileExplore_MouseMove;
            lvFileExplore.MouseUp += lvFileExplore_MouseUp;
            lvFileExplore.Resize += lvFileExplore_Resize;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            // 
            // tableToolBar
            // 
            tableToolBar.BackColor = Color.PaleGreen;
            tableToolBar.ColumnCount = 3;
            tableToolBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableToolBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableToolBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableToolBar.Controls.Add(panelToolbar3, 2, 0);
            tableToolBar.Controls.Add(panelToolbar1, 0, 0);
            tableToolBar.Controls.Add(panelToolbar2, 1, 0);
            tableToolBar.Dock = DockStyle.Fill;
            tableToolBar.Location = new Point(140, 0);
            tableToolBar.Margin = new Padding(0);
            tableToolBar.Name = "tableToolBar";
            tableToolBar.RowCount = 1;
            tableToolBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableToolBar.Size = new Size(576, 31);
            tableToolBar.TabIndex = 6;
            // 
            // panelToolbar3
            // 
            panelToolbar3.BackColor = Color.Olive;
            panelToolbar3.Controls.Add(btnFilterScript);
            panelToolbar3.Controls.Add(btnFilterImage);
            panelToolbar3.Controls.Add(btnFilterVideo);
            panelToolbar3.Dock = DockStyle.Fill;
            panelToolbar3.Location = new Point(431, 0);
            panelToolbar3.Margin = new Padding(0);
            panelToolbar3.Name = "panelToolbar3";
            panelToolbar3.Size = new Size(145, 31);
            panelToolbar3.TabIndex = 0;
            // 
            // btnFilterScript
            // 
            btnFilterScript.Dock = DockStyle.Left;
            btnFilterScript.FlatAppearance.BorderSize = 0;
            btnFilterScript.FlatStyle = FlatStyle.Flat;
            btnFilterScript.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilterScript.IconChar = FontAwesome.Sharp.IconChar.FileMedicalAlt;
            btnFilterScript.IconColor = Color.Black;
            btnFilterScript.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnFilterScript.IconSize = 24;
            btnFilterScript.Location = new Point(80, 0);
            btnFilterScript.Name = "btnFilterScript";
            btnFilterScript.Size = new Size(40, 31);
            btnFilterScript.TabIndex = 27;
            btnFilterScript.UseVisualStyleBackColor = true;
            btnFilterScript.MouseDown += btnFilterScript_MouseDown;
            // 
            // btnFilterImage
            // 
            btnFilterImage.Dock = DockStyle.Left;
            btnFilterImage.FlatAppearance.BorderSize = 0;
            btnFilterImage.FlatStyle = FlatStyle.Flat;
            btnFilterImage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilterImage.IconChar = FontAwesome.Sharp.IconChar.FileImage;
            btnFilterImage.IconColor = Color.Black;
            btnFilterImage.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnFilterImage.IconSize = 24;
            btnFilterImage.Location = new Point(40, 0);
            btnFilterImage.Name = "btnFilterImage";
            btnFilterImage.Size = new Size(40, 31);
            btnFilterImage.TabIndex = 26;
            btnFilterImage.UseVisualStyleBackColor = true;
            btnFilterImage.MouseDown += btnFilterImage_MouseDown;
            // 
            // btnFilterVideo
            // 
            btnFilterVideo.Dock = DockStyle.Left;
            btnFilterVideo.FlatAppearance.BorderSize = 0;
            btnFilterVideo.FlatStyle = FlatStyle.Flat;
            btnFilterVideo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFilterVideo.IconChar = FontAwesome.Sharp.IconChar.FileVideo;
            btnFilterVideo.IconColor = Color.Black;
            btnFilterVideo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnFilterVideo.IconSize = 24;
            btnFilterVideo.Location = new Point(0, 0);
            btnFilterVideo.Name = "btnFilterVideo";
            btnFilterVideo.Size = new Size(40, 31);
            btnFilterVideo.TabIndex = 25;
            btnFilterVideo.UseVisualStyleBackColor = true;
            btnFilterVideo.MouseDown += btnFilterVideo_MouseDown;
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
            panelToolbar1.Size = new Size(230, 31);
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
            panelToolbar2.Controls.Add(btnViewLargeGrid);
            panelToolbar2.Controls.Add(btnViewSmallGrid);
            panelToolbar2.Controls.Add(btnViewList);
            panelToolbar2.Dock = DockStyle.Fill;
            panelToolbar2.Location = new Point(230, 0);
            panelToolbar2.Margin = new Padding(0);
            panelToolbar2.Name = "panelToolbar2";
            panelToolbar2.Size = new Size(201, 31);
            panelToolbar2.TabIndex = 1;
            // 
            // btnViewLargeGrid
            // 
            btnViewLargeGrid.Dock = DockStyle.Left;
            btnViewLargeGrid.FlatAppearance.BorderSize = 0;
            btnViewLargeGrid.FlatStyle = FlatStyle.Flat;
            btnViewLargeGrid.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewLargeGrid.IconChar = FontAwesome.Sharp.IconChar.ThLarge;
            btnViewLargeGrid.IconColor = Color.Black;
            btnViewLargeGrid.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewLargeGrid.IconSize = 30;
            btnViewLargeGrid.Location = new Point(80, 0);
            btnViewLargeGrid.Name = "btnViewLargeGrid";
            btnViewLargeGrid.Size = new Size(40, 31);
            btnViewLargeGrid.TabIndex = 22;
            btnViewLargeGrid.UseVisualStyleBackColor = true;
            btnViewLargeGrid.Click += btnViewLargeGrid_Click;
            // 
            // btnViewSmallGrid
            // 
            btnViewSmallGrid.Dock = DockStyle.Left;
            btnViewSmallGrid.FlatAppearance.BorderSize = 0;
            btnViewSmallGrid.FlatStyle = FlatStyle.Flat;
            btnViewSmallGrid.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewSmallGrid.IconChar = FontAwesome.Sharp.IconChar.TableCells;
            btnViewSmallGrid.IconColor = Color.Black;
            btnViewSmallGrid.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnViewSmallGrid.IconSize = 30;
            btnViewSmallGrid.Location = new Point(40, 0);
            btnViewSmallGrid.Name = "btnViewSmallGrid";
            btnViewSmallGrid.Size = new Size(40, 31);
            btnViewSmallGrid.TabIndex = 21;
            btnViewSmallGrid.UseVisualStyleBackColor = true;
            btnViewSmallGrid.Click += btnViewSmallGrid_Click;
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
            // tableLayoutCustomPanel
            // 
            tableLayoutCustomPanel.BackColor = Color.SlateBlue;
            tableLayoutCustomPanel.ColumnCount = 2;
            tableLayoutCustomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutCustomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutCustomPanel.Controls.Add(roundedPanelCustomList, 1, 0);
            tableLayoutCustomPanel.Controls.Add(panel1, 0, 0);
            tableLayoutCustomPanel.Dock = DockStyle.Fill;
            tableLayoutCustomPanel.Location = new Point(0, 0);
            tableLayoutCustomPanel.Margin = new Padding(0);
            tableLayoutCustomPanel.Name = "tableLayoutCustomPanel";
            tableLayoutCustomPanel.RowCount = 1;
            tableLayoutCustomPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutCustomPanel.Size = new Size(613, 618);
            tableLayoutCustomPanel.TabIndex = 0;
            // 
            // roundedPanelCustomList
            // 
            roundedPanelCustomList.Controls.Add(lvCustomList);
            roundedPanelCustomList.Controls.Add(roundedPanelCustomListBottom);
            roundedPanelCustomList.Controls.Add(roundedPanelCustomListTop);
            roundedPanelCustomList.Dock = DockStyle.Fill;
            roundedPanelCustomList.FillColor = Color.YellowGreen;
            roundedPanelCustomList.Location = new Point(130, 0);
            roundedPanelCustomList.Margin = new Padding(0);
            roundedPanelCustomList.Name = "roundedPanelCustomList";
            roundedPanelCustomList.Padding = new Padding(6);
            roundedPanelCustomList.RadiusBottomLeft = 16;
            roundedPanelCustomList.RadiusBottomRight = 16;
            roundedPanelCustomList.RadiusTopLeft = 16;
            roundedPanelCustomList.RadiusTopRight = 16;
            roundedPanelCustomList.Size = new Size(483, 618);
            roundedPanelCustomList.TabIndex = 0;
            // 
            // lvCustomList
            // 
            lvCustomList.AllowDrop = true;
            lvCustomList.BackColor = Color.PaleGreen;
            lvCustomList.BorderStyle = BorderStyle.None;
            lvCustomList.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            lvCustomList.Dock = DockStyle.Fill;
            lvCustomList.FullRowSelect = true;
            lvCustomList.HeaderStyle = ColumnHeaderStyle.None;
            lvCustomList.Location = new Point(6, 32);
            lvCustomList.Name = "lvCustomList";
            lvCustomList.ShowItemToolTips = true;
            lvCustomList.Size = new Size(471, 554);
            lvCustomList.TabIndex = 20;
            lvCustomList.UseCompatibleStateImageBehavior = false;
            lvCustomList.View = View.Details;
            lvCustomList.DragDrop += lvCustomList_DragDrop;
            lvCustomList.DragEnter += lvCustomList_DragEnter;
            lvCustomList.Resize += lvCustomList_Resize;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Placeholder";
            columnHeader2.Width = 200;
            // 
            // roundedPanelCustomListBottom
            // 
            roundedPanelCustomListBottom.Controls.Add(panelCustomListBottom);
            roundedPanelCustomListBottom.Dock = DockStyle.Bottom;
            roundedPanelCustomListBottom.FillColor = Color.LightYellow;
            roundedPanelCustomListBottom.Location = new Point(6, 586);
            roundedPanelCustomListBottom.Name = "roundedPanelCustomListBottom";
            roundedPanelCustomListBottom.Padding = new Padding(8, 2, 6, 3);
            roundedPanelCustomListBottom.RadiusBottomLeft = 14;
            roundedPanelCustomListBottom.RadiusBottomRight = 14;
            roundedPanelCustomListBottom.RadiusTopLeft = 14;
            roundedPanelCustomListBottom.RadiusTopRight = 14;
            roundedPanelCustomListBottom.Size = new Size(471, 26);
            roundedPanelCustomListBottom.TabIndex = 1;
            // 
            // panelCustomListBottom
            // 
            panelCustomListBottom.Controls.Add(lblEntries);
            panelCustomListBottom.Controls.Add(lblSide4);
            panelCustomListBottom.Controls.Add(cbFullPath);
            panelCustomListBottom.Controls.Add(lblSide3);
            panelCustomListBottom.Dock = DockStyle.Fill;
            panelCustomListBottom.Location = new Point(8, 2);
            panelCustomListBottom.Margin = new Padding(0);
            panelCustomListBottom.Name = "panelCustomListBottom";
            panelCustomListBottom.Size = new Size(457, 21);
            panelCustomListBottom.TabIndex = 0;
            // 
            // lblEntries
            // 
            lblEntries.BackColor = Color.SandyBrown;
            lblEntries.Dock = DockStyle.Fill;
            lblEntries.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEntries.Location = new Point(59, 0);
            lblEntries.Name = "lblEntries";
            lblEntries.Padding = new Padding(0, 3, 0, 0);
            lblEntries.Size = new Size(294, 21);
            lblEntries.TabIndex = 22;
            lblEntries.Text = "100";
            // 
            // lblSide4
            // 
            lblSide4.BackColor = Color.SandyBrown;
            lblSide4.Dock = DockStyle.Left;
            lblSide4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSide4.Location = new Point(47, 0);
            lblSide4.Name = "lblSide4";
            lblSide4.Padding = new Padding(0, 2, 0, 0);
            lblSide4.Size = new Size(12, 21);
            lblSide4.TabIndex = 24;
            lblSide4.Text = "|";
            // 
            // cbFullPath
            // 
            cbFullPath.Appearance = Appearance.Button;
            cbFullPath.BackColor = Color.Yellow;
            cbFullPath.CheckedBackColor = Color.LightGreen;
            cbFullPath.Dock = DockStyle.Right;
            cbFullPath.FlatAppearance.BorderSize = 0;
            cbFullPath.FlatStyle = FlatStyle.Flat;
            cbFullPath.Location = new Point(353, 0);
            cbFullPath.Name = "cbFullPath";
            cbFullPath.Size = new Size(104, 21);
            cbFullPath.TabIndex = 23;
            cbFullPath.Text = "Show full path";
            cbFullPath.UncheckedBackColor = Color.Red;
            cbFullPath.UncheckedForeColor = Color.Black;
            cbFullPath.UseVisualStyleBackColor = false;
            cbFullPath.CheckedChanged += cbFullPath_CheckedChanged;
            // 
            // lblSide3
            // 
            lblSide3.BackColor = Color.SandyBrown;
            lblSide3.Dock = DockStyle.Left;
            lblSide3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSide3.Location = new Point(0, 0);
            lblSide3.Name = "lblSide3";
            lblSide3.Padding = new Padding(0, 3, 0, 0);
            lblSide3.Size = new Size(47, 21);
            lblSide3.TabIndex = 25;
            lblSide3.Text = "Entries";
            // 
            // roundedPanelCustomListTop
            // 
            roundedPanelCustomListTop.Controls.Add(lblLoadedList);
            roundedPanelCustomListTop.Controls.Add(lblSide2);
            roundedPanelCustomListTop.Controls.Add(lblSide1);
            roundedPanelCustomListTop.Dock = DockStyle.Top;
            roundedPanelCustomListTop.FillColor = Color.LightYellow;
            roundedPanelCustomListTop.Location = new Point(6, 6);
            roundedPanelCustomListTop.Name = "roundedPanelCustomListTop";
            roundedPanelCustomListTop.Padding = new Padding(8, 3, 8, 3);
            roundedPanelCustomListTop.RadiusBottomLeft = 14;
            roundedPanelCustomListTop.RadiusBottomRight = 14;
            roundedPanelCustomListTop.RadiusTopLeft = 14;
            roundedPanelCustomListTop.RadiusTopRight = 14;
            roundedPanelCustomListTop.Size = new Size(471, 26);
            roundedPanelCustomListTop.TabIndex = 0;
            // 
            // lblLoadedList
            // 
            lblLoadedList.BackColor = Color.SandyBrown;
            lblLoadedList.Dock = DockStyle.Fill;
            lblLoadedList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoadedList.Location = new Point(88, 3);
            lblLoadedList.Name = "lblLoadedList";
            lblLoadedList.Padding = new Padding(0, 2, 0, 0);
            lblLoadedList.Size = new Size(375, 20);
            lblLoadedList.TabIndex = 21;
            lblLoadedList.Text = "List Name";
            // 
            // lblSide2
            // 
            lblSide2.BackColor = Color.SandyBrown;
            lblSide2.Dock = DockStyle.Left;
            lblSide2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSide2.Location = new Point(76, 3);
            lblSide2.Name = "lblSide2";
            lblSide2.Padding = new Padding(0, 1, 0, 0);
            lblSide2.Size = new Size(12, 20);
            lblSide2.TabIndex = 23;
            lblSide2.Text = "|";
            // 
            // lblSide1
            // 
            lblSide1.BackColor = Color.SandyBrown;
            lblSide1.Dock = DockStyle.Left;
            lblSide1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSide1.Location = new Point(8, 3);
            lblSide1.Name = "lblSide1";
            lblSide1.Padding = new Padding(0, 2, 0, 0);
            lblSide1.Size = new Size(68, 20);
            lblSide1.TabIndex = 22;
            lblSide1.Text = "Loaded list";
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(roundedPanelSideBottom);
            panel1.Controls.Add(roundedPanelSideCenter);
            panel1.Controls.Add(roundedPanelSideTop);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(130, 618);
            panel1.TabIndex = 1;
            // 
            // roundedPanelSideBottom
            // 
            roundedPanelSideBottom.Dock = DockStyle.Fill;
            roundedPanelSideBottom.FillColor = Color.RosyBrown;
            roundedPanelSideBottom.Location = new Point(0, 351);
            roundedPanelSideBottom.Name = "roundedPanelSideBottom";
            roundedPanelSideBottom.RadiusBottomLeft = 0;
            roundedPanelSideBottom.RadiusBottomRight = 0;
            roundedPanelSideBottom.RadiusTopLeft = 0;
            roundedPanelSideBottom.RadiusTopRight = 16;
            roundedPanelSideBottom.Size = new Size(130, 267);
            roundedPanelSideBottom.TabIndex = 2;
            // 
            // roundedPanelSideCenter
            // 
            roundedPanelSideCenter.Controls.Add(btnMoveList);
            roundedPanelSideCenter.Controls.Add(btnAddFromPlaylist);
            roundedPanelSideCenter.Controls.Add(btnSaveList);
            roundedPanelSideCenter.Controls.Add(btnLoadList);
            roundedPanelSideCenter.Controls.Add(btnDelDuplicates);
            roundedPanelSideCenter.Controls.Add(btnClearSelected);
            roundedPanelSideCenter.Controls.Add(btnClearList);
            roundedPanelSideCenter.Dock = DockStyle.Top;
            roundedPanelSideCenter.FillColor = Color.GreenYellow;
            roundedPanelSideCenter.Location = new Point(0, 115);
            roundedPanelSideCenter.Name = "roundedPanelSideCenter";
            roundedPanelSideCenter.Padding = new Padding(6);
            roundedPanelSideCenter.RadiusBottomLeft = 16;
            roundedPanelSideCenter.RadiusBottomRight = 0;
            roundedPanelSideCenter.RadiusTopLeft = 16;
            roundedPanelSideCenter.RadiusTopRight = 0;
            roundedPanelSideCenter.Size = new Size(130, 236);
            roundedPanelSideCenter.TabIndex = 1;
            // 
            // btnMoveList
            // 
            btnMoveList.Dock = DockStyle.Top;
            btnMoveList.FlatAppearance.BorderSize = 0;
            btnMoveList.FlatStyle = FlatStyle.Flat;
            btnMoveList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnMoveList.IconChar = FontAwesome.Sharp.IconChar.SquareArrowUpRight;
            btnMoveList.IconColor = Color.Black;
            btnMoveList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnMoveList.IconSize = 26;
            btnMoveList.ImageAlign = ContentAlignment.MiddleRight;
            btnMoveList.Location = new Point(6, 198);
            btnMoveList.Name = "btnMoveList";
            btnMoveList.Size = new Size(118, 32);
            btnMoveList.TabIndex = 27;
            btnMoveList.Text = "Move List";
            btnMoveList.TextAlign = ContentAlignment.MiddleLeft;
            btnMoveList.UseVisualStyleBackColor = true;
            btnMoveList.Click += btnMoveList_Click;
            // 
            // btnAddFromPlaylist
            // 
            btnAddFromPlaylist.Dock = DockStyle.Top;
            btnAddFromPlaylist.FlatAppearance.BorderSize = 0;
            btnAddFromPlaylist.FlatStyle = FlatStyle.Flat;
            btnAddFromPlaylist.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddFromPlaylist.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnAddFromPlaylist.IconColor = Color.Black;
            btnAddFromPlaylist.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddFromPlaylist.IconSize = 26;
            btnAddFromPlaylist.ImageAlign = ContentAlignment.MiddleRight;
            btnAddFromPlaylist.Location = new Point(6, 166);
            btnAddFromPlaylist.Name = "btnAddFromPlaylist";
            btnAddFromPlaylist.Size = new Size(118, 32);
            btnAddFromPlaylist.TabIndex = 26;
            btnAddFromPlaylist.Text = "Add Queue";
            btnAddFromPlaylist.TextAlign = ContentAlignment.MiddleLeft;
            btnAddFromPlaylist.UseVisualStyleBackColor = true;
            btnAddFromPlaylist.Click += btnAddFromPlaylist_Click;
            // 
            // btnSaveList
            // 
            btnSaveList.Dock = DockStyle.Top;
            btnSaveList.FlatAppearance.BorderSize = 0;
            btnSaveList.FlatStyle = FlatStyle.Flat;
            btnSaveList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSaveList.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnSaveList.IconColor = Color.Black;
            btnSaveList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnSaveList.IconSize = 26;
            btnSaveList.ImageAlign = ContentAlignment.MiddleRight;
            btnSaveList.Location = new Point(6, 134);
            btnSaveList.Name = "btnSaveList";
            btnSaveList.Size = new Size(118, 32);
            btnSaveList.TabIndex = 25;
            btnSaveList.Text = "Save List";
            btnSaveList.TextAlign = ContentAlignment.MiddleLeft;
            btnSaveList.UseVisualStyleBackColor = true;
            btnSaveList.Click += btnSaveList_Click;
            // 
            // btnLoadList
            // 
            btnLoadList.Dock = DockStyle.Top;
            btnLoadList.FlatAppearance.BorderSize = 0;
            btnLoadList.FlatStyle = FlatStyle.Flat;
            btnLoadList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnLoadList.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnLoadList.IconColor = Color.Black;
            btnLoadList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLoadList.IconSize = 26;
            btnLoadList.ImageAlign = ContentAlignment.MiddleRight;
            btnLoadList.Location = new Point(6, 102);
            btnLoadList.Name = "btnLoadList";
            btnLoadList.Size = new Size(118, 32);
            btnLoadList.TabIndex = 24;
            btnLoadList.Text = "Load List";
            btnLoadList.TextAlign = ContentAlignment.MiddleLeft;
            btnLoadList.UseVisualStyleBackColor = true;
            btnLoadList.Click += btnLoadList_Click;
            // 
            // btnDelDuplicates
            // 
            btnDelDuplicates.Dock = DockStyle.Top;
            btnDelDuplicates.FlatAppearance.BorderSize = 0;
            btnDelDuplicates.FlatStyle = FlatStyle.Flat;
            btnDelDuplicates.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDelDuplicates.IconChar = FontAwesome.Sharp.IconChar.Clone;
            btnDelDuplicates.IconColor = Color.Black;
            btnDelDuplicates.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDelDuplicates.IconSize = 26;
            btnDelDuplicates.ImageAlign = ContentAlignment.MiddleRight;
            btnDelDuplicates.Location = new Point(6, 70);
            btnDelDuplicates.Name = "btnDelDuplicates";
            btnDelDuplicates.Size = new Size(118, 32);
            btnDelDuplicates.TabIndex = 23;
            btnDelDuplicates.Text = "Clear dups.";
            btnDelDuplicates.TextAlign = ContentAlignment.MiddleLeft;
            btnDelDuplicates.UseVisualStyleBackColor = true;
            btnDelDuplicates.Click += btnDelDuplicates_Click;
            // 
            // btnClearSelected
            // 
            btnClearSelected.Dock = DockStyle.Top;
            btnClearSelected.FlatAppearance.BorderSize = 0;
            btnClearSelected.FlatStyle = FlatStyle.Flat;
            btnClearSelected.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearSelected.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
            btnClearSelected.IconColor = Color.Black;
            btnClearSelected.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClearSelected.IconSize = 26;
            btnClearSelected.ImageAlign = ContentAlignment.MiddleRight;
            btnClearSelected.Location = new Point(6, 38);
            btnClearSelected.Name = "btnClearSelected";
            btnClearSelected.Size = new Size(118, 32);
            btnClearSelected.TabIndex = 22;
            btnClearSelected.Text = "Clear selected";
            btnClearSelected.TextAlign = ContentAlignment.MiddleLeft;
            btnClearSelected.UseVisualStyleBackColor = true;
            btnClearSelected.Click += btnClearSelected_Click;
            // 
            // btnClearList
            // 
            btnClearList.Dock = DockStyle.Top;
            btnClearList.FlatAppearance.BorderSize = 0;
            btnClearList.FlatStyle = FlatStyle.Flat;
            btnClearList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnClearList.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
            btnClearList.IconColor = Color.Black;
            btnClearList.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnClearList.IconSize = 26;
            btnClearList.ImageAlign = ContentAlignment.MiddleRight;
            btnClearList.Location = new Point(6, 6);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new Size(118, 32);
            btnClearList.TabIndex = 21;
            btnClearList.Text = "Clear all";
            btnClearList.TextAlign = ContentAlignment.MiddleLeft;
            btnClearList.UseVisualStyleBackColor = true;
            btnClearList.Click += btnClearList_Click;
            // 
            // roundedPanelSideTop
            // 
            roundedPanelSideTop.Controls.Add(btnAddAll);
            roundedPanelSideTop.Controls.Add(label3);
            roundedPanelSideTop.Controls.Add(btnAddSelected);
            roundedPanelSideTop.Dock = DockStyle.Top;
            roundedPanelSideTop.FillColor = Color.RosyBrown;
            roundedPanelSideTop.Location = new Point(0, 0);
            roundedPanelSideTop.Name = "roundedPanelSideTop";
            roundedPanelSideTop.Padding = new Padding(6, 0, 6, 6);
            roundedPanelSideTop.RadiusBottomLeft = 0;
            roundedPanelSideTop.RadiusBottomRight = 16;
            roundedPanelSideTop.RadiusTopLeft = 0;
            roundedPanelSideTop.RadiusTopRight = 0;
            roundedPanelSideTop.Size = new Size(130, 115);
            roundedPanelSideTop.TabIndex = 0;
            // 
            // btnAddAll
            // 
            btnAddAll.Dock = DockStyle.Bottom;
            btnAddAll.FlatAppearance.BorderSize = 0;
            btnAddAll.FlatStyle = FlatStyle.Flat;
            btnAddAll.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddAll.IconChar = FontAwesome.Sharp.IconChar.CircleRight;
            btnAddAll.IconColor = Color.Black;
            btnAddAll.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddAll.IconSize = 26;
            btnAddAll.ImageAlign = ContentAlignment.MiddleRight;
            btnAddAll.Location = new Point(6, 45);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new Size(118, 32);
            btnAddAll.TabIndex = 17;
            btnAddAll.Text = "Add all";
            btnAddAll.TextAlign = ContentAlignment.MiddleLeft;
            btnAddAll.UseVisualStyleBackColor = true;
            btnAddAll.Click += btnAddAll_Click;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 0);
            label3.Name = "label3";
            label3.Size = new Size(118, 31);
            label3.TabIndex = 1;
            label3.Text = "Functions";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddSelected
            // 
            btnAddSelected.Dock = DockStyle.Bottom;
            btnAddSelected.FlatAppearance.BorderSize = 0;
            btnAddSelected.FlatStyle = FlatStyle.Flat;
            btnAddSelected.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAddSelected.IconChar = FontAwesome.Sharp.IconChar.CircleRight;
            btnAddSelected.IconColor = Color.Black;
            btnAddSelected.IconFont = FontAwesome.Sharp.IconFont.Regular;
            btnAddSelected.IconSize = 26;
            btnAddSelected.ImageAlign = ContentAlignment.MiddleRight;
            btnAddSelected.Location = new Point(6, 77);
            btnAddSelected.Name = "btnAddSelected";
            btnAddSelected.Size = new Size(118, 32);
            btnAddSelected.TabIndex = 18;
            btnAddSelected.Text = "Add selected";
            btnAddSelected.TextAlign = ContentAlignment.MiddleLeft;
            btnAddSelected.UseVisualStyleBackColor = true;
            btnAddSelected.Click += btnAddSelected_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(247, 110, 100);
            panelTop.Controls.Add(lblTitleBar);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1339, 20);
            panelTop.TabIndex = 1;
            // 
            // lblTitleBar
            // 
            lblTitleBar.Dock = DockStyle.Fill;
            lblTitleBar.Location = new Point(0, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Padding = new Padding(30, 0, 0, 0);
            lblTitleBar.Size = new Size(1309, 20);
            lblTitleBar.TabIndex = 3;
            lblTitleBar.Text = "RVP - List Browser";
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
            btnClose.Location = new Point(1309, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 20);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ListBrowserV2View
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 688);
            Controls.Add(tableLayoutMain);
            Controls.Add(panelTop);
            Name = "ListBrowserV2View";
            Text = "ListBrowserV2View";
            Load += ListBrowserV2View_Load;
            ResizeEnd += ListBrowserV2View_ResizeEnd;
            Resize += ListBrowserV2View_Resize;
            tableLayoutMain.ResumeLayout(false);
            panelMainRow1.ResumeLayout(false);
            panelPathContainer.ResumeLayout(false);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tableLayouMainSub1.ResumeLayout(false);
            tableLayouMainSub1.PerformLayout();
            tableLayoutSideBar.ResumeLayout(false);
            tableLayoutSideBar.PerformLayout();
            tableLayoutFavButtons.ResumeLayout(false);
            panelFileExplore.ResumeLayout(false);
            tableToolBar.ResumeLayout(false);
            panelToolbar3.ResumeLayout(false);
            panelToolbar1.ResumeLayout(false);
            panelToolbar2.ResumeLayout(false);
            tableLayoutCustomPanel.ResumeLayout(false);
            roundedPanelCustomList.ResumeLayout(false);
            roundedPanelCustomListBottom.ResumeLayout(false);
            panelCustomListBottom.ResumeLayout(false);
            roundedPanelCustomListTop.ResumeLayout(false);
            panel1.ResumeLayout(false);
            roundedPanelSideCenter.ResumeLayout(false);
            roundedPanelSideTop.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Panel panelTop;
        private Label lblTitleBar;
        private FontAwesome.Sharp.IconButton btnClose;
        private Panel panelMainRow1;
        private Controls.RoundedPanel panelPathContainer;
        private Controls.BufferedFlowLayoutPanel flowPanelPath;
        private Controls.RoundedButton btnStart;
        private Controls.RoundedButton btnBack;
        private SplitContainer splitContainerMain;
        private TableLayoutPanel tableLayouMainSub1;
        private TableLayoutPanel tableLayoutSideBar;
        private Label label2;
        private Controls.BufferedFlowLayoutPanel flowPanelDir;
        private Controls.BufferedFlowLayoutPanel flowPanelFav;
        private TableLayoutPanel tableLayoutFavButtons;
        private FontAwesome.Sharp.IconButton btnAddFav;
        private FontAwesome.Sharp.IconButton btnDeleteFav;
        private Label label1;
        private Controls.RoundedPanel panelFileExplore;
        private ListView lvFileExplore;
        private ColumnHeader columnHeader1;
        private TableLayoutPanel tableToolBar;
        private Panel panelToolbar3;
        private FontAwesome.Sharp.IconButton btnFilterScript;
        private FontAwesome.Sharp.IconButton btnFilterImage;
        private FontAwesome.Sharp.IconButton btnFilterVideo;
        private Panel panelToolbar1;
        private Label lblZoomFactor;
        private Controls.FlatSlider sliderZoom;
        private FontAwesome.Sharp.IconButton btnResetSize;
        private Panel panelToolbar2;
        private FontAwesome.Sharp.IconButton btnViewLargeGrid;
        private FontAwesome.Sharp.IconButton btnViewSmallGrid;
        private FontAwesome.Sharp.IconButton btnViewList;
        private TableLayoutPanel tableLayoutCustomPanel;
        private Controls.RoundedPanel roundedPanelCustomList;
        private Controls.RoundedPanel roundedPanelCustomListBottom;
        private Label lblEntries;
        private Controls.RoundedPanel roundedPanelCustomListTop;
        private Label lblLoadedList;
        private Panel panel1;
        private Controls.RoundedPanel roundedPanelSideCenter;
        private Controls.RoundedPanel roundedPanelSideTop;
        private Controls.RoundedPanel roundedPanelSideBottom;
        private ListView lvCustomList;
        private ColumnHeader columnHeader2;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnAddAll;
        private FontAwesome.Sharp.IconButton btnAddSelected;
        private FontAwesome.Sharp.IconButton btnClearList;
        private FontAwesome.Sharp.IconButton btnClearSelected;
        private FontAwesome.Sharp.IconButton btnDelDuplicates;
        private FontAwesome.Sharp.IconButton btnLoadList;
        private FontAwesome.Sharp.IconButton btnSaveList;
        private FontAwesome.Sharp.IconButton btnAddFromPlaylist;
        private FontAwesome.Sharp.IconButton btnMoveList;
        private Controls.RoundedCheckBox cbFullPath;
        private Panel panelCustomListBottom;
        private Label lblSide4;
        private Label lblSide3;
        private Label lblSide2;
        private Label lblSide1;
    }
}