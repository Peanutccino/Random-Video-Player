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
            tableLayoutMain = new TableLayoutPanel();
            panel4 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnThemeSelector = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            lblHeader = new Label();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnRestoreDefaults = new FontAwesome.Sharp.IconButton();
            panelVisibilityToggles = new Panel();
            cbTimerButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbDeleteButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbTouchButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbListAddButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbSkipButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbAddToFavButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbSourceSelector = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbMoveToButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbShuffleButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbLoopButton = new RandomVideoPlayer.Controls.RoundedCheckBox();
            panelIcons = new Panel();
            iconTimer = new FontAwesome.Sharp.IconPictureBox();
            iconListAdd_PB = new PictureBox();
            iconSourceSelector_PB = new PictureBox();
            iconTouch = new FontAwesome.Sharp.IconPictureBox();
            iconSkip = new FontAwesome.Sharp.IconPictureBox();
            iconLoop = new FontAwesome.Sharp.IconPictureBox();
            iconShuffle = new FontAwesome.Sharp.IconPictureBox();
            iconMoveTo = new FontAwesome.Sharp.IconPictureBox();
            iconAddToFav = new FontAwesome.Sharp.IconPictureBox();
            iconDelete = new FontAwesome.Sharp.IconPictureBox();
            lbl2 = new Label();
            lbl1 = new Label();
            panel2 = new Panel();
            cbShowButtonToPlayFromCurrentFolder = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl3 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnScalingSelector = new FontAwesome.Sharp.IconButton();
            cbEnableCustomScaling = new RandomVideoPlayer.Controls.CustomCheckBox();
            label2 = new Label();
            tableLayoutMain.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelVisibilityToggles.SuspendLayout();
            panelIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconTimer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconListAdd_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconSourceSelector_PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconTouch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconSkip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconLoop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconShuffle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconMoveTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconAddToFav).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconDelete).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.YellowGreen;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(panel4, 0, 1);
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 2);
            tableLayoutMain.Controls.Add(panel2, 0, 3);
            tableLayoutMain.Controls.Add(tableLayoutPanel1, 0, 4);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 5;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MistyRose;
            panel4.Controls.Add(tableLayoutPanel2);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 63);
            panel4.Name = "panel4";
            panel4.Size = new Size(518, 113);
            panel4.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.PeachPuff;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnThemeSelector, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 24);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(518, 42);
            tableLayoutPanel2.TabIndex = 30;
            // 
            // btnThemeSelector
            // 
            btnThemeSelector.BackColor = Color.LightSteelBlue;
            btnThemeSelector.Dock = DockStyle.Fill;
            btnThemeSelector.FlatAppearance.BorderSize = 0;
            btnThemeSelector.FlatStyle = FlatStyle.Flat;
            btnThemeSelector.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            btnThemeSelector.IconColor = Color.Black;
            btnThemeSelector.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnThemeSelector.IconSize = 20;
            btnThemeSelector.ImageAlign = ContentAlignment.MiddleRight;
            btnThemeSelector.Location = new Point(8, 8);
            btnThemeSelector.Margin = new Padding(8);
            btnThemeSelector.Name = "btnThemeSelector";
            btnThemeSelector.Size = new Size(502, 26);
            btnThemeSelector.TabIndex = 29;
            btnThemeSelector.Text = "Light";
            btnThemeSelector.TextAlign = ContentAlignment.MiddleLeft;
            btnThemeSelector.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(518, 24);
            label1.TabIndex = 18;
            label1.Text = "Select a theme for RVP (Applies after Saving):";
            // 
            // lblHeader
            // 
            lblHeader.BackColor = SystemColors.Control;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 12;
            lblHeader.Text = "Interface";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Yellow;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(panelVisibilityToggles);
            panel1.Controls.Add(panelIcons);
            panel1.Controls.Add(lbl2);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 182);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 172);
            panel1.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.SpringGreen;
            flowLayoutPanel1.Controls.Add(btnRestoreDefaults);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel1.Location = new Point(0, 136);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel1.Size = new Size(518, 36);
            flowLayoutPanel1.TabIndex = 18;
            // 
            // btnRestoreDefaults
            // 
            btnRestoreDefaults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRestoreDefaults.BackColor = Color.FromArgb(230, 230, 255);
            btnRestoreDefaults.FlatAppearance.BorderSize = 0;
            btnRestoreDefaults.FlatStyle = FlatStyle.Flat;
            btnRestoreDefaults.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRestoreDefaults.IconColor = Color.Black;
            btnRestoreDefaults.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestoreDefaults.Location = new Point(369, 6);
            btnRestoreDefaults.Name = "btnRestoreDefaults";
            btnRestoreDefaults.Size = new Size(146, 27);
            btnRestoreDefaults.TabIndex = 5;
            btnRestoreDefaults.Text = "Restore Defaults";
            btnRestoreDefaults.UseVisualStyleBackColor = false;
            btnRestoreDefaults.Click += btnRestore_Click;
            // 
            // panelVisibilityToggles
            // 
            panelVisibilityToggles.BackColor = Color.DarkSlateBlue;
            panelVisibilityToggles.Controls.Add(cbTimerButton);
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
            panelVisibilityToggles.Location = new Point(0, 106);
            panelVisibilityToggles.Name = "panelVisibilityToggles";
            panelVisibilityToggles.Size = new Size(518, 30);
            panelVisibilityToggles.TabIndex = 17;
            // 
            // cbTimerButton
            // 
            cbTimerButton.Appearance = Appearance.Button;
            cbTimerButton.BackColor = Color.Transparent;
            cbTimerButton.CheckedBackColor = Color.PaleGreen;
            cbTimerButton.FlatAppearance.BorderSize = 0;
            cbTimerButton.FlatStyle = FlatStyle.Flat;
            cbTimerButton.Location = new Point(269, 3);
            cbTimerButton.Margin = new Padding(12, 3, 3, 3);
            cbTimerButton.Name = "cbTimerButton";
            cbTimerButton.Size = new Size(32, 22);
            cbTimerButton.TabIndex = 12;
            cbTimerButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbTimerButton.UncheckedForeColor = Color.Black;
            cbTimerButton.UseVisualStyleBackColor = false;
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
            // cbTouchButton
            // 
            cbTouchButton.Appearance = Appearance.Button;
            cbTouchButton.BackColor = Color.Transparent;
            cbTouchButton.CheckedBackColor = Color.PaleGreen;
            cbTouchButton.FlatAppearance.BorderSize = 0;
            cbTouchButton.FlatStyle = FlatStyle.Flat;
            cbTouchButton.Location = new Point(345, 3);
            cbTouchButton.Margin = new Padding(12, 3, 3, 3);
            cbTouchButton.Name = "cbTouchButton";
            cbTouchButton.Size = new Size(32, 22);
            cbTouchButton.TabIndex = 11;
            cbTouchButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbTouchButton.UncheckedForeColor = Color.Black;
            cbTouchButton.UseVisualStyleBackColor = false;
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
            // cbSkipButton
            // 
            cbSkipButton.Appearance = Appearance.Button;
            cbSkipButton.BackColor = Color.Transparent;
            cbSkipButton.CheckedBackColor = Color.PaleGreen;
            cbSkipButton.FlatAppearance.BorderSize = 0;
            cbSkipButton.FlatStyle = FlatStyle.Flat;
            cbSkipButton.Location = new Point(307, 3);
            cbSkipButton.Margin = new Padding(12, 3, 3, 3);
            cbSkipButton.Name = "cbSkipButton";
            cbSkipButton.Size = new Size(32, 22);
            cbSkipButton.TabIndex = 10;
            cbSkipButton.UncheckedBackColor = Color.FromArgb(255, 128, 128);
            cbSkipButton.UncheckedForeColor = Color.Black;
            cbSkipButton.UseVisualStyleBackColor = false;
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
            // panelIcons
            // 
            panelIcons.BackColor = Color.FromArgb(253, 83, 146);
            panelIcons.Controls.Add(iconTimer);
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
            panelIcons.Location = new Point(0, 68);
            panelIcons.Name = "panelIcons";
            panelIcons.Size = new Size(518, 38);
            panelIcons.TabIndex = 16;
            // 
            // iconTimer
            // 
            iconTimer.BackColor = Color.FromArgb(253, 83, 146);
            iconTimer.ForeColor = SystemColors.ControlText;
            iconTimer.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            iconTimer.IconColor = SystemColors.ControlText;
            iconTimer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconTimer.IconSize = 28;
            iconTimer.Location = new Point(269, 3);
            iconTimer.Name = "iconTimer";
            iconTimer.Size = new Size(32, 32);
            iconTimer.SizeMode = PictureBoxSizeMode.CenterImage;
            iconTimer.TabIndex = 11;
            iconTimer.TabStop = false;
            iconTimer.Tag = "7";
            iconTimer.MouseDown += icon_MouseDown;
            iconTimer.MouseMove += icon_MouseMove;
            iconTimer.MouseUp += icon_MouseUp;
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
            iconTouch.IconChar = FontAwesome.Sharp.IconChar.Location;
            iconTouch.IconColor = SystemColors.ControlText;
            iconTouch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconTouch.IconSize = 28;
            iconTouch.Location = new Point(345, 3);
            iconTouch.Name = "iconTouch";
            iconTouch.Size = new Size(32, 32);
            iconTouch.SizeMode = PictureBoxSizeMode.CenterImage;
            iconTouch.TabIndex = 8;
            iconTouch.TabStop = false;
            iconTouch.Tag = "9";
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
            iconSkip.Location = new Point(307, 3);
            iconSkip.Name = "iconSkip";
            iconSkip.Size = new Size(32, 32);
            iconSkip.SizeMode = PictureBoxSizeMode.CenterImage;
            iconSkip.TabIndex = 7;
            iconSkip.TabStop = false;
            iconSkip.Tag = "8";
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
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl2.Location = new Point(0, 44);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 14;
            lbl2.Text = "Drag and Drop the icons to rearrange them. Toggle visibility below.";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 44);
            lbl1.TabIndex = 13;
            lbl1.Text = "You can customize which buttons should be visible in the player and order them to your liking. \r\nNote: Does not affect shortcuts.";
            // 
            // panel2
            // 
            panel2.BackColor = Color.PaleGreen;
            panel2.Controls.Add(cbShowButtonToPlayFromCurrentFolder);
            panel2.Controls.Add(lbl3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 360);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 93);
            panel2.TabIndex = 14;
            // 
            // cbShowButtonToPlayFromCurrentFolder
            // 
            cbShowButtonToPlayFromCurrentFolder.AutoSize = true;
            cbShowButtonToPlayFromCurrentFolder.BoxSize = 13;
            cbShowButtonToPlayFromCurrentFolder.Dock = DockStyle.Top;
            cbShowButtonToPlayFromCurrentFolder.HoverColor = Color.DeepSkyBlue;
            cbShowButtonToPlayFromCurrentFolder.Location = new Point(0, 24);
            cbShowButtonToPlayFromCurrentFolder.Name = "cbShowButtonToPlayFromCurrentFolder";
            cbShowButtonToPlayFromCurrentFolder.PaddingLeft = 12;
            cbShowButtonToPlayFromCurrentFolder.Size = new Size(518, 19);
            cbShowButtonToPlayFromCurrentFolder.TabIndex = 9;
            cbShowButtonToPlayFromCurrentFolder.Text = "Enable \"Play from current folder\" button";
            cbShowButtonToPlayFromCurrentFolder.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 24);
            lbl3.TabIndex = 8;
            lbl3.Text = "Show button to play from current folder while playing random files:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.NavajoWhite;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnScalingSelector, 0, 2);
            tableLayoutPanel1.Controls.Add(cbEnableCustomScaling, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 459);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(518, 194);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // btnScalingSelector
            // 
            btnScalingSelector.BackColor = Color.LightSteelBlue;
            btnScalingSelector.Dock = DockStyle.Fill;
            btnScalingSelector.FlatAppearance.BorderSize = 0;
            btnScalingSelector.FlatStyle = FlatStyle.Flat;
            btnScalingSelector.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            btnScalingSelector.IconColor = Color.Black;
            btnScalingSelector.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnScalingSelector.IconSize = 20;
            btnScalingSelector.ImageAlign = ContentAlignment.MiddleRight;
            btnScalingSelector.Location = new Point(8, 57);
            btnScalingSelector.Margin = new Padding(8);
            btnScalingSelector.Name = "btnScalingSelector";
            btnScalingSelector.Size = new Size(502, 26);
            btnScalingSelector.TabIndex = 30;
            btnScalingSelector.Text = "100%";
            btnScalingSelector.TextAlign = ContentAlignment.MiddleLeft;
            btnScalingSelector.UseVisualStyleBackColor = false;
            // 
            // cbEnableCustomScaling
            // 
            cbEnableCustomScaling.AutoSize = true;
            cbEnableCustomScaling.BoxSize = 13;
            cbEnableCustomScaling.Dock = DockStyle.Top;
            cbEnableCustomScaling.HoverColor = Color.DeepSkyBlue;
            cbEnableCustomScaling.Location = new Point(3, 27);
            cbEnableCustomScaling.Name = "cbEnableCustomScaling";
            cbEnableCustomScaling.PaddingLeft = 12;
            cbEnableCustomScaling.Size = new Size(512, 19);
            cbEnableCustomScaling.TabIndex = 10;
            cbEnableCustomScaling.Text = "Enable custom scaling";
            cbEnableCustomScaling.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(512, 24);
            label2.TabIndex = 9;
            label2.Text = "Enable and choose a custom scaling for the entire UI. (Applies after restart)";
            // 
            // InterfaceUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(tableLayoutMain);
            Name = "InterfaceUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panelVisibilityToggles.ResumeLayout(false);
            panelIcons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconTimer).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconListAdd_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconSourceSelector_PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconTouch).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconSkip).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconLoop).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconShuffle).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconMoveTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconAddToFav).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconDelete).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Label lbl2;
        private Panel panelIcons;
        private PictureBox iconListAdd_PB;
        private PictureBox iconSourceSelector_PB;
        private FontAwesome.Sharp.IconPictureBox iconTouch;
        private FontAwesome.Sharp.IconPictureBox iconSkip;
        private FontAwesome.Sharp.IconPictureBox iconLoop;
        private FontAwesome.Sharp.IconPictureBox iconShuffle;
        private FontAwesome.Sharp.IconPictureBox iconMoveTo;
        private FontAwesome.Sharp.IconPictureBox iconAddToFav;
        private FontAwesome.Sharp.IconPictureBox iconDelete;
        private Panel panelVisibilityToggles;
        private Controls.RoundedCheckBox cbDeleteButton;
        private Controls.RoundedCheckBox cbTouchButton;
        private Controls.RoundedCheckBox cbListAddButton;
        private Controls.RoundedCheckBox cbSkipButton;
        private Controls.RoundedCheckBox cbAddToFavButton;
        private Controls.RoundedCheckBox cbSourceSelector;
        private Controls.RoundedCheckBox cbMoveToButton;
        private Controls.RoundedCheckBox cbShuffleButton;
        private Controls.RoundedCheckBox cbLoopButton;
        private Panel panel2;
        private Label lbl3;
        private Controls.CustomCheckBox cbShowButtonToPlayFromCurrentFolder;
        private FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnRestoreDefaults;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnThemeSelector;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnScalingSelector;
        private Controls.CustomCheckBox cbEnableCustomScaling;
        private FontAwesome.Sharp.IconPictureBox iconTimer;
        private Controls.RoundedCheckBox cbTimerButton;
    }
}
