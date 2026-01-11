namespace RandomVideoPlayer.UserControls
{
    partial class InterfaceUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHeader = new Label();
            lbl1 = new Label();
            panel1 = new Panel();
            lbl2 = new Label();
            label3 = new Label();
            cbTouchButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbSkipButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbSourceSelector = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbListAddButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbMoveToButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbLoopButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbShuffleButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbAddToFavButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbDeleteButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            panelButtonPreview = new Panel();
            cbShowButtonToPlayFromCurrentFolder = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl3 = new Label();
            btnRestore = new FontAwesome.Sharp.IconButton();
            panelIcons = new Panel();
            iconListAdd_PB = new PictureBox();
            iconSourceSelector_PB = new PictureBox();
            iconTouch = new FontAwesome.Sharp.IconPictureBox();
            iconSkip = new FontAwesome.Sharp.IconPictureBox();
            iconLoop = new FontAwesome.Sharp.IconPictureBox();
            iconShuffle = new FontAwesome.Sharp.IconPictureBox();
            iconMoveTo = new FontAwesome.Sharp.IconPictureBox();
            iconAddToFav = new FontAwesome.Sharp.IconPictureBox();
            iconDelete = new FontAwesome.Sharp.IconPictureBox();
            panelVisibilityToggles = new Panel();
            panel3 = new Panel();
            flowPanel = new FlowLayoutPanel();
            panel2 = new Panel();
            lbl6 = new Label();
            comboThemes = new ComboBox();
            panel1.SuspendLayout();
            panelButtonPreview.SuspendLayout();
            panelIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconListAdd_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconSourceSelector_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconTouch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconSkip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconLoop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconShuffle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconMoveTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconAddToFav).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconDelete).BeginInit();
            panelVisibilityToggles.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.BackColor = SystemColors.Control;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(500, 55);
            lblHeader.TabIndex = 2;
            lblHeader.Text = "Interface";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl1.Location = new Point(0, 55);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(500, 62);
            lbl1.TabIndex = 3;
            lbl1.Text = "You can customize which buttons should be visible in the player and order them to your liking. \r\nNote: Does not affect shortcuts.";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Controls.Add(lbl2);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 117);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 41);
            panel1.TabIndex = 4;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Bottom;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl2.Location = new Point(0, 16);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(500, 25);
            lbl2.TabIndex = 13;
            lbl2.Text = "Drag and Drop the icons to rearrange them. Toggle visibility below.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(3, 364);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 12;
            label3.Text = "Preview:";
            // 
            // cbTouchButton
            // 
            cbTouchButton.Appearance = Appearance.Button;
            cbTouchButton.BackColor = Color.Transparent;
            cbTouchButton.CheckedBackColor = Color.PaleGreen;
            cbTouchButton.FlatAppearance.BorderSize = 0;
            cbTouchButton.FlatStyle = FlatStyle.Flat;
            cbTouchButton.Location = new Point(307, 3);
            cbTouchButton.Margin = new Padding(12, 3, 3, 3);
            cbTouchButton.Name = "cbTouchButton";
            cbTouchButton.Size = new Size(32, 22);
            cbTouchButton.TabIndex = 11;
            cbTouchButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbTouchButton.UncheckedForeColor = Color.Black;
            cbTouchButton.UseVisualStyleBackColor = false;
            // 
            // cbSkipButton
            // 
            cbSkipButton.Appearance = Appearance.Button;
            cbSkipButton.BackColor = Color.Transparent;
            cbSkipButton.CheckedBackColor = Color.PaleGreen;
            cbSkipButton.FlatAppearance.BorderSize = 0;
            cbSkipButton.FlatStyle = FlatStyle.Flat;
            cbSkipButton.Location = new Point(269, 3);
            cbSkipButton.Margin = new Padding(12, 3, 3, 3);
            cbSkipButton.Name = "cbSkipButton";
            cbSkipButton.Size = new Size(32, 22);
            cbSkipButton.TabIndex = 10;
            cbSkipButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbSkipButton.UncheckedForeColor = Color.Black;
            cbSkipButton.UseVisualStyleBackColor = false;
            // 
            // cbSourceSelector
            // 
            cbSourceSelector.Appearance = Appearance.Button;
            cbSourceSelector.BackColor = Color.Transparent;
            cbSourceSelector.CheckedBackColor = Color.PaleGreen;
            cbSourceSelector.FlatAppearance.BorderSize = 0;
            cbSourceSelector.FlatStyle = FlatStyle.Flat;
            cbSourceSelector.Location = new Point(231, 3);
            cbSourceSelector.Margin = new Padding(12, 3, 3, 3);
            cbSourceSelector.Name = "cbSourceSelector";
            cbSourceSelector.Size = new Size(32, 22);
            cbSourceSelector.TabIndex = 9;
            cbSourceSelector.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbSourceSelector.UncheckedForeColor = Color.Black;
            cbSourceSelector.UseVisualStyleBackColor = false;
            // 
            // cbListAddButton
            // 
            cbListAddButton.Appearance = Appearance.Button;
            cbListAddButton.BackColor = Color.Transparent;
            cbListAddButton.CheckedBackColor = Color.PaleGreen;
            cbListAddButton.FlatAppearance.BorderSize = 0;
            cbListAddButton.FlatStyle = FlatStyle.Flat;
            cbListAddButton.Location = new Point(41, 3);
            cbListAddButton.Margin = new Padding(12, 3, 3, 3);
            cbListAddButton.Name = "cbListAddButton";
            cbListAddButton.Size = new Size(32, 22);
            cbListAddButton.TabIndex = 6;
            cbListAddButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbListAddButton.UncheckedForeColor = Color.Black;
            cbListAddButton.UseVisualStyleBackColor = false;
            // 
            // cbMoveToButton
            // 
            cbMoveToButton.Appearance = Appearance.Button;
            cbMoveToButton.BackColor = Color.Transparent;
            cbMoveToButton.CheckedBackColor = Color.PaleGreen;
            cbMoveToButton.FlatAppearance.BorderSize = 0;
            cbMoveToButton.FlatStyle = FlatStyle.Flat;
            cbMoveToButton.Location = new Point(117, 3);
            cbMoveToButton.Margin = new Padding(12, 3, 3, 3);
            cbMoveToButton.Name = "cbMoveToButton";
            cbMoveToButton.Size = new Size(32, 22);
            cbMoveToButton.TabIndex = 5;
            cbMoveToButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbMoveToButton.UncheckedForeColor = Color.Black;
            cbMoveToButton.UseVisualStyleBackColor = false;
            // 
            // cbLoopButton
            // 
            cbLoopButton.Appearance = Appearance.Button;
            cbLoopButton.BackColor = Color.Transparent;
            cbLoopButton.CheckedBackColor = Color.PaleGreen;
            cbLoopButton.FlatAppearance.BorderSize = 0;
            cbLoopButton.FlatStyle = FlatStyle.Flat;
            cbLoopButton.Location = new Point(193, 3);
            cbLoopButton.Margin = new Padding(12, 3, 3, 3);
            cbLoopButton.Name = "cbLoopButton";
            cbLoopButton.Size = new Size(32, 22);
            cbLoopButton.TabIndex = 4;
            cbLoopButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbLoopButton.UncheckedForeColor = Color.Black;
            cbLoopButton.UseVisualStyleBackColor = false;
            // 
            // cbShuffleButton
            // 
            cbShuffleButton.Appearance = Appearance.Button;
            cbShuffleButton.BackColor = Color.Transparent;
            cbShuffleButton.CheckedBackColor = Color.PaleGreen;
            cbShuffleButton.FlatAppearance.BorderSize = 0;
            cbShuffleButton.FlatStyle = FlatStyle.Flat;
            cbShuffleButton.Location = new Point(155, 3);
            cbShuffleButton.Margin = new Padding(12, 3, 3, 3);
            cbShuffleButton.Name = "cbShuffleButton";
            cbShuffleButton.Size = new Size(32, 22);
            cbShuffleButton.TabIndex = 3;
            cbShuffleButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbShuffleButton.UncheckedForeColor = Color.Black;
            cbShuffleButton.UseVisualStyleBackColor = false;
            // 
            // cbAddToFavButton
            // 
            cbAddToFavButton.Appearance = Appearance.Button;
            cbAddToFavButton.BackColor = Color.Transparent;
            cbAddToFavButton.CheckedBackColor = Color.PaleGreen;
            cbAddToFavButton.FlatAppearance.BorderSize = 0;
            cbAddToFavButton.FlatStyle = FlatStyle.Flat;
            cbAddToFavButton.Location = new Point(79, 3);
            cbAddToFavButton.Margin = new Padding(12, 3, 3, 3);
            cbAddToFavButton.Name = "cbAddToFavButton";
            cbAddToFavButton.Size = new Size(32, 22);
            cbAddToFavButton.TabIndex = 2;
            cbAddToFavButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbAddToFavButton.UncheckedForeColor = Color.Black;
            cbAddToFavButton.UseVisualStyleBackColor = false;
            // 
            // cbDeleteButton
            // 
            cbDeleteButton.Appearance = Appearance.Button;
            cbDeleteButton.BackColor = Color.Transparent;
            cbDeleteButton.CheckedBackColor = Color.PaleGreen;
            cbDeleteButton.FlatAppearance.BorderSize = 0;
            cbDeleteButton.FlatStyle = FlatStyle.Flat;
            cbDeleteButton.Location = new Point(3, 3);
            cbDeleteButton.Margin = new Padding(12, 3, 3, 3);
            cbDeleteButton.Name = "cbDeleteButton";
            cbDeleteButton.Size = new Size(32, 22);
            cbDeleteButton.TabIndex = 0;
            cbDeleteButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbDeleteButton.UncheckedForeColor = Color.Black;
            cbDeleteButton.UseVisualStyleBackColor = false;
            // 
            // panelButtonPreview
            // 
            panelButtonPreview.Controls.Add(cbShowButtonToPlayFromCurrentFolder);
            panelButtonPreview.Controls.Add(lbl3);
            panelButtonPreview.Controls.Add(btnRestore);
            panelButtonPreview.Dock = DockStyle.Top;
            panelButtonPreview.Location = new Point(0, 309);
            panelButtonPreview.Name = "panelButtonPreview";
            panelButtonPreview.Padding = new Padding(6, 0, 6, 0);
            panelButtonPreview.Size = new Size(500, 87);
            panelButtonPreview.TabIndex = 5;
            // 
            // cbShowButtonToPlayFromCurrentFolder
            // 
            cbShowButtonToPlayFromCurrentFolder.AutoSize = true;
            cbShowButtonToPlayFromCurrentFolder.BoxSize = 13;
            cbShowButtonToPlayFromCurrentFolder.Dock = DockStyle.Top;
            cbShowButtonToPlayFromCurrentFolder.HoverColor = Color.DeepSkyBlue;
            cbShowButtonToPlayFromCurrentFolder.Location = new Point(6, 30);
            cbShowButtonToPlayFromCurrentFolder.Name = "cbShowButtonToPlayFromCurrentFolder";
            cbShowButtonToPlayFromCurrentFolder.PaddingLeft = 9;
            cbShowButtonToPlayFromCurrentFolder.Size = new Size(488, 19);
            cbShowButtonToPlayFromCurrentFolder.TabIndex = 8;
            cbShowButtonToPlayFromCurrentFolder.Text = "Enable \"Play from current folder\" button";
            cbShowButtonToPlayFromCurrentFolder.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl3.Location = new Point(6, 0);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(0, 6, 0, 0);
            lbl3.Size = new Size(488, 30);
            lbl3.TabIndex = 7;
            lbl3.Text = "Show button to play from current folder while playing random files:";
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRestore.BackColor = Color.FromArgb(230, 230, 255);
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRestore.IconColor = Color.Black;
            btnRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestore.Location = new Point(345, 57);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(146, 27);
            btnRestore.TabIndex = 5;
            btnRestore.Text = "Restore Defaults";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // panelIcons
            // 
            panelIcons.BackColor = Color.FromArgb(253, 83, 146);
            panelIcons.Controls.Add(iconListAdd_PB);
            panelIcons.Controls.Add(iconSourceSelector_PB);
            panelIcons.Controls.Add(iconTouch);
            panelIcons.Controls.Add(iconSkip);
            panelIcons.Controls.Add(iconLoop);
            panelIcons.Controls.Add(iconShuffle);
            panelIcons.Controls.Add(iconMoveTo);
            panelIcons.Controls.Add(iconAddToFav);
            panelIcons.Controls.Add(iconDelete);
            panelIcons.Dock = DockStyle.Top;
            panelIcons.Location = new Point(0, 158);
            panelIcons.Name = "panelIcons";
            panelIcons.Size = new Size(500, 38);
            panelIcons.TabIndex = 6;
            // 
            // iconListAdd_PB
            // 
            iconListAdd_PB.Location = new Point(41, 3);
            iconListAdd_PB.Name = "iconListAdd_PB";
            iconListAdd_PB.Padding = new Padding(0, 0, 0, 2);
            iconListAdd_PB.Size = new Size(32, 32);
            iconListAdd_PB.SizeMode = PictureBoxSizeMode.CenterImage;
            iconListAdd_PB.TabIndex = 10;
            iconListAdd_PB.TabStop = false;
            iconListAdd_PB.Tag = "1";
            iconListAdd_PB.MouseDown += icon_MouseDown;
            iconListAdd_PB.MouseMove += icon_MouseMove;
            iconListAdd_PB.MouseUp += icon_MouseUp;
            // 
            // iconSourceSelector_PB
            // 
            iconSourceSelector_PB.Location = new Point(231, 3);
            iconSourceSelector_PB.Name = "iconSourceSelector_PB";
            iconSourceSelector_PB.Padding = new Padding(0, 0, 0, 2);
            iconSourceSelector_PB.Size = new Size(32, 32);
            iconSourceSelector_PB.SizeMode = PictureBoxSizeMode.CenterImage;
            iconSourceSelector_PB.TabIndex = 9;
            iconSourceSelector_PB.TabStop = false;
            iconSourceSelector_PB.Tag = "6";
            iconSourceSelector_PB.MouseDown += icon_MouseDown;
            iconSourceSelector_PB.MouseMove += icon_MouseMove;
            iconSourceSelector_PB.MouseUp += icon_MouseUp;
            // 
            // iconTouch
            // 
            iconTouch.BackColor = Color.FromArgb(253, 83, 146);
            iconTouch.ForeColor = SystemColors.ControlText;
            iconTouch.IconChar = FontAwesome.Sharp.IconChar.LocationCrosshairs;
            iconTouch.IconColor = SystemColors.ControlText;
            iconTouch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconTouch.IconSize = 28;
            iconTouch.Location = new Point(307, 3);
            iconTouch.Name = "iconTouch";
            iconTouch.Size = new Size(32, 32);
            iconTouch.SizeMode = PictureBoxSizeMode.CenterImage;
            iconTouch.TabIndex = 8;
            iconTouch.TabStop = false;
            iconTouch.Tag = "8";
            iconTouch.MouseDown += icon_MouseDown;
            iconTouch.MouseMove += icon_MouseMove;
            iconTouch.MouseUp += icon_MouseUp;
            // 
            // iconSkip
            // 
            iconSkip.BackColor = Color.FromArgb(253, 83, 146);
            iconSkip.ForeColor = SystemColors.ControlText;
            iconSkip.IconChar = FontAwesome.Sharp.IconChar.Forward;
            iconSkip.IconColor = SystemColors.ControlText;
            iconSkip.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconSkip.IconSize = 28;
            iconSkip.Location = new Point(269, 3);
            iconSkip.Name = "iconSkip";
            iconSkip.Size = new Size(32, 32);
            iconSkip.SizeMode = PictureBoxSizeMode.CenterImage;
            iconSkip.TabIndex = 7;
            iconSkip.TabStop = false;
            iconSkip.Tag = "7";
            iconSkip.MouseDown += icon_MouseDown;
            iconSkip.MouseMove += icon_MouseMove;
            iconSkip.MouseUp += icon_MouseUp;
            // 
            // iconLoop
            // 
            iconLoop.BackColor = Color.FromArgb(253, 83, 146);
            iconLoop.ForeColor = SystemColors.ControlText;
            iconLoop.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            iconLoop.IconColor = SystemColors.ControlText;
            iconLoop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconLoop.IconSize = 28;
            iconLoop.Location = new Point(193, 3);
            iconLoop.Name = "iconLoop";
            iconLoop.Size = new Size(32, 32);
            iconLoop.SizeMode = PictureBoxSizeMode.CenterImage;
            iconLoop.TabIndex = 5;
            iconLoop.TabStop = false;
            iconLoop.Tag = "5";
            iconLoop.MouseDown += icon_MouseDown;
            iconLoop.MouseMove += icon_MouseMove;
            iconLoop.MouseUp += icon_MouseUp;
            // 
            // iconShuffle
            // 
            iconShuffle.BackColor = Color.FromArgb(253, 83, 146);
            iconShuffle.ForeColor = SystemColors.ControlText;
            iconShuffle.IconChar = FontAwesome.Sharp.IconChar.Shuffle;
            iconShuffle.IconColor = SystemColors.ControlText;
            iconShuffle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconShuffle.IconSize = 28;
            iconShuffle.Location = new Point(155, 3);
            iconShuffle.Name = "iconShuffle";
            iconShuffle.Size = new Size(32, 32);
            iconShuffle.SizeMode = PictureBoxSizeMode.CenterImage;
            iconShuffle.TabIndex = 4;
            iconShuffle.TabStop = false;
            iconShuffle.Tag = "4";
            iconShuffle.MouseDown += icon_MouseDown;
            iconShuffle.MouseMove += icon_MouseMove;
            iconShuffle.MouseUp += icon_MouseUp;
            // 
            // iconMoveTo
            // 
            iconMoveTo.BackColor = Color.FromArgb(253, 83, 146);
            iconMoveTo.ForeColor = SystemColors.ControlText;
            iconMoveTo.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromFile;
            iconMoveTo.IconColor = SystemColors.ControlText;
            iconMoveTo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconMoveTo.IconSize = 28;
            iconMoveTo.Location = new Point(117, 3);
            iconMoveTo.Name = "iconMoveTo";
            iconMoveTo.Size = new Size(32, 32);
            iconMoveTo.SizeMode = PictureBoxSizeMode.CenterImage;
            iconMoveTo.TabIndex = 3;
            iconMoveTo.TabStop = false;
            iconMoveTo.Tag = "3";
            iconMoveTo.MouseDown += icon_MouseDown;
            iconMoveTo.MouseMove += icon_MouseMove;
            iconMoveTo.MouseUp += icon_MouseUp;
            // 
            // iconAddToFav
            // 
            iconAddToFav.BackColor = Color.FromArgb(253, 83, 146);
            iconAddToFav.ForeColor = SystemColors.ControlText;
            iconAddToFav.IconChar = FontAwesome.Sharp.IconChar.Heart;
            iconAddToFav.IconColor = SystemColors.ControlText;
            iconAddToFav.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconAddToFav.IconSize = 28;
            iconAddToFav.Location = new Point(79, 3);
            iconAddToFav.Name = "iconAddToFav";
            iconAddToFav.Size = new Size(32, 32);
            iconAddToFav.SizeMode = PictureBoxSizeMode.CenterImage;
            iconAddToFav.TabIndex = 2;
            iconAddToFav.TabStop = false;
            iconAddToFav.Tag = "2";
            iconAddToFav.MouseDown += icon_MouseDown;
            iconAddToFav.MouseMove += icon_MouseMove;
            iconAddToFav.MouseUp += icon_MouseUp;
            // 
            // iconDelete
            // 
            iconDelete.BackColor = Color.FromArgb(253, 83, 146);
            iconDelete.ForeColor = SystemColors.ControlText;
            iconDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            iconDelete.IconColor = SystemColors.ControlText;
            iconDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconDelete.IconSize = 28;
            iconDelete.Location = new Point(3, 3);
            iconDelete.Name = "iconDelete";
            iconDelete.Size = new Size(32, 32);
            iconDelete.SizeMode = PictureBoxSizeMode.CenterImage;
            iconDelete.TabIndex = 0;
            iconDelete.TabStop = false;
            iconDelete.Tag = "0";
            iconDelete.MouseDown += icon_MouseDown;
            iconDelete.MouseMove += icon_MouseMove;
            iconDelete.MouseUp += icon_MouseUp;
            // 
            // panelVisibilityToggles
            // 
            panelVisibilityToggles.BackColor = Color.DarkSlateBlue;
            panelVisibilityToggles.Controls.Add(cbDeleteButton);
            panelVisibilityToggles.Controls.Add(cbTouchButton);
            panelVisibilityToggles.Controls.Add(cbListAddButton);
            panelVisibilityToggles.Controls.Add(cbSkipButton);
            panelVisibilityToggles.Controls.Add(cbAddToFavButton);
            panelVisibilityToggles.Controls.Add(cbSourceSelector);
            panelVisibilityToggles.Controls.Add(cbMoveToButton);
            panelVisibilityToggles.Controls.Add(cbShuffleButton);
            panelVisibilityToggles.Controls.Add(cbLoopButton);
            panelVisibilityToggles.Dock = DockStyle.Top;
            panelVisibilityToggles.Location = new Point(0, 196);
            panelVisibilityToggles.Name = "panelVisibilityToggles";
            panelVisibilityToggles.Size = new Size(500, 30);
            panelVisibilityToggles.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(flowPanel);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 226);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 83);
            panel3.TabIndex = 9;
            // 
            // flowPanel
            // 
            flowPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.Location = new Point(3, 61);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(70, 18);
            flowPanel.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboThemes);
            panel2.Controls.Add(lbl6);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 396);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(6, 0, 6, 0);
            panel2.Size = new Size(500, 100);
            panel2.TabIndex = 10;
            // 
            // lbl6
            // 
            lbl6.Dock = DockStyle.Top;
            lbl6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl6.Location = new Point(6, 0);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(488, 23);
            lbl6.TabIndex = 17;
            lbl6.Text = "Select a theme for RVP (Applies after Saving):";
            // 
            // comboThemes
            // 
            comboThemes.Dock = DockStyle.Top;
            comboThemes.FormattingEnabled = true;
            comboThemes.Location = new Point(6, 23);
            comboThemes.Name = "comboThemes";
            comboThemes.Size = new Size(488, 23);
            comboThemes.TabIndex = 26;
            // 
            // InterfaceUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel2);
            Controls.Add(panelButtonPreview);
            Controls.Add(panel3);
            Controls.Add(panelVisibilityToggles);
            Controls.Add(panelIcons);
            Controls.Add(panel1);
            Controls.Add(lbl1);
            Controls.Add(lblHeader);
            Name = "InterfaceUserControl";
            Size = new Size(500, 600);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelButtonPreview.ResumeLayout(false);
            panelButtonPreview.PerformLayout();
            panelIcons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconListAdd_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconSourceSelector_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconTouch).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconSkip).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconLoop).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconShuffle).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconMoveTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconAddToFav).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconDelete).EndInit();
            panelVisibilityToggles.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Label lbl1;
        private Panel panel1;
        private Controls.RoundedCheckBox cbDeleteButton;
        private Controls.RoundedCheckBox cbLoopButton;
        private Controls.RoundedCheckBox cbShuffleButton;
        private Controls.RoundedCheckBox cbAddToFavButton;
        private Panel panelButtonPreview;
        private Controls.RoundedCheckBox cbMoveToButton;
        private Controls.RoundedCheckBox cbListAddButton;
        private Controls.RoundedCheckBox cbSourceSelector;
        private FontAwesome.Sharp.IconButton btnRestore;
        private Controls.RoundedCheckBox cbSkipButton;
        private Label lbl3;
        private Controls.RoundedCheckBox cbTouchButton;
        private Panel panelIcons;
        private FontAwesome.Sharp.IconPictureBox iconDelete;
        private FontAwesome.Sharp.IconPictureBox iconTouch;
        private FontAwesome.Sharp.IconPictureBox iconSkip;
        private FontAwesome.Sharp.IconPictureBox iconLoop;
        private FontAwesome.Sharp.IconPictureBox iconShuffle;
        private FontAwesome.Sharp.IconPictureBox iconMoveTo;
        private FontAwesome.Sharp.IconPictureBox iconAddToFav;
        private Label label3;
        private PictureBox iconSourceSelector_PB;
        private PictureBox iconListAdd_PB;
        private Panel panelVisibilityToggles;
        private Label lbl2;
        private Panel panel3;
        private FlowLayoutPanel flowPanel;
        private Controls.CustomCheckBox cbShowButtonToPlayFromCurrentFolder;
        private Panel panel2;
        private Label lbl6;
        private ComboBox comboThemes;
    }
}
