namespace RandomVideoPlayer.UserControls
{
    partial class SyncUserControl
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
            components = new System.ComponentModel.Container();
            tableLayoutMain = new TableLayoutPanel();
            lblHeader = new Label();
            panel1 = new Panel();
            lbl4 = new Label();
            lbl3 = new Label();
            lbl2 = new Label();
            lbl1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            cbScriptGraph = new RandomVideoPlayer.Controls.RoundedCheckBox();
            cbTimeCodeServer = new RandomVideoPlayer.Controls.RoundedCheckBox();
            panel2 = new Panel();
            tableLayoutDirs = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAddFolder = new FontAwesome.Sharp.IconButton();
            btnDeleteFolder = new FontAwesome.Sharp.IconButton();
            btnItemUp = new FontAwesome.Sharp.IconButton();
            btnItemDown = new FontAwesome.Sharp.IconButton();
            btnAddLocal = new FontAwesome.Sharp.IconButton();
            lvDirectories = new ListView();
            lbl5 = new Label();
            panel3 = new Panel();
            cbIncludeSubdirectoriesForScriptLoad = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbUsingScriptPlayer = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbHandleMultiAxis = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbShowScriptPath = new RandomVideoPlayer.Controls.CustomCheckBox();
            toolTipInfo = new ToolTip(components);
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutDirs.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.Violet;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 1);
            tableLayoutMain.Controls.Add(tableLayoutPanel1, 0, 2);
            tableLayoutMain.Controls.Add(panel2, 0, 3);
            tableLayoutMain.Controls.Add(panel3, 0, 4);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 5;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 22F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 3);
            lblHeader.Margin = new Padding(3);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 54);
            lblHeader.TabIndex = 11;
            lblHeader.Text = "Sync";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Controls.Add(lbl4);
            panel1.Controls.Add(lbl3);
            panel1.Controls.Add(lbl2);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 207);
            panel1.TabIndex = 12;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl4.Location = new Point(0, 151);
            lbl4.Margin = new Padding(3, 6, 3, 3);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(518, 31);
            lbl4.TabIndex = 18;
            lbl4.Text = "Script graph is shown within the players progress bar and is only a visual indicator. ";
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI", 9F);
            lbl3.ForeColor = Color.Indigo;
            lbl3.Location = new Point(0, 126);
            lbl3.Margin = new Padding(3, 6, 3, 3);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 25);
            lbl3.TabIndex = 17;
            lbl3.Text = "The video info gets synced locally via 'http://127.0.0.1:13579/variables.html'";
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F);
            lbl2.Location = new Point(0, 66);
            lbl2.Margin = new Padding(3, 6, 3, 3);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 60);
            lbl2.TabIndex = 16;
            lbl2.Text = "- In MultiFunPlayer, activate media source \"MPC-HC\". Either connect manually or activate auto-connect.\r\n- In ScriptPlayer, click \"Video Player\" and select \"MPC-HC\".\r\n";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl1.Location = new Point(0, 0);
            lbl1.Margin = new Padding(3);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 66);
            lbl1.TabIndex = 15;
            lbl1.Text = "Check Timecode Server, to activate syncing. (Only after settings are saved)\r\n\r\nCurrently these two can read RVP information and use them for their toy syncing method, here is how to set it up:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.MediumSlateBlue;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(cbScriptGraph, 2, 0);
            tableLayoutPanel1.Controls.Add(cbTimeCodeServer, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 273);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(524, 34);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // cbScriptGraph
            // 
            cbScriptGraph.Appearance = Appearance.Button;
            cbScriptGraph.BackColor = Color.Transparent;
            cbScriptGraph.CheckedBackColor = Color.LightGreen;
            cbScriptGraph.Dock = DockStyle.Left;
            cbScriptGraph.FlatAppearance.BorderSize = 0;
            cbScriptGraph.FlatStyle = FlatStyle.Flat;
            cbScriptGraph.Location = new Point(272, 0);
            cbScriptGraph.Margin = new Padding(0);
            cbScriptGraph.Name = "cbScriptGraph";
            cbScriptGraph.Size = new Size(170, 34);
            cbScriptGraph.TabIndex = 8;
            cbScriptGraph.Text = "Show script graph";
            cbScriptGraph.UncheckedBackColor = Color.LightGray;
            cbScriptGraph.UncheckedForeColor = Color.Black;
            cbScriptGraph.UseVisualStyleBackColor = false;
            // 
            // cbTimeCodeServer
            // 
            cbTimeCodeServer.Appearance = Appearance.Button;
            cbTimeCodeServer.BackColor = Color.Transparent;
            cbTimeCodeServer.CheckedBackColor = Color.LightGreen;
            cbTimeCodeServer.Dock = DockStyle.Right;
            cbTimeCodeServer.FlatAppearance.BorderSize = 0;
            cbTimeCodeServer.FlatStyle = FlatStyle.Flat;
            cbTimeCodeServer.Location = new Point(82, 0);
            cbTimeCodeServer.Margin = new Padding(0);
            cbTimeCodeServer.Name = "cbTimeCodeServer";
            cbTimeCodeServer.Size = new Size(170, 34);
            cbTimeCodeServer.TabIndex = 6;
            cbTimeCodeServer.Text = "Start timecode server";
            cbTimeCodeServer.UncheckedBackColor = Color.LightGray;
            cbTimeCodeServer.UncheckedForeColor = Color.Black;
            cbTimeCodeServer.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.PowderBlue;
            panel2.Controls.Add(tableLayoutDirs);
            panel2.Controls.Add(lbl5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 310);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 218);
            panel2.TabIndex = 14;
            // 
            // tableLayoutDirs
            // 
            tableLayoutDirs.BackColor = Color.SpringGreen;
            tableLayoutDirs.ColumnCount = 2;
            tableLayoutDirs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutDirs.ColumnStyles.Add(new ColumnStyle());
            tableLayoutDirs.Controls.Add(flowLayoutPanel1, 1, 0);
            tableLayoutDirs.Controls.Add(lvDirectories, 0, 0);
            tableLayoutDirs.Dock = DockStyle.Fill;
            tableLayoutDirs.Location = new Point(0, 24);
            tableLayoutDirs.Name = "tableLayoutDirs";
            tableLayoutDirs.RowCount = 1;
            tableLayoutDirs.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutDirs.Size = new Size(518, 194);
            tableLayoutDirs.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnAddFolder);
            flowLayoutPanel1.Controls.Add(btnDeleteFolder);
            flowLayoutPanel1.Controls.Add(btnItemUp);
            flowLayoutPanel1.Controls.Add(btnItemDown);
            flowLayoutPanel1.Controls.Add(btnAddLocal);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(473, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(42, 188);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // btnAddFolder
            // 
            btnAddFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddFolder.FlatAppearance.BorderSize = 0;
            btnAddFolder.FlatStyle = FlatStyle.Flat;
            btnAddFolder.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnAddFolder.IconColor = Color.Black;
            btnAddFolder.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddFolder.IconSize = 33;
            btnAddFolder.Location = new Point(3, 0);
            btnAddFolder.Margin = new Padding(3, 0, 3, 4);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(32, 32);
            btnAddFolder.TabIndex = 8;
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // btnDeleteFolder
            // 
            btnDeleteFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteFolder.FlatAppearance.BorderSize = 0;
            btnDeleteFolder.FlatStyle = FlatStyle.Flat;
            btnDeleteFolder.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            btnDeleteFolder.IconColor = Color.Black;
            btnDeleteFolder.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnDeleteFolder.IconSize = 33;
            btnDeleteFolder.Location = new Point(3, 36);
            btnDeleteFolder.Margin = new Padding(3, 0, 3, 4);
            btnDeleteFolder.Name = "btnDeleteFolder";
            btnDeleteFolder.Size = new Size(32, 32);
            btnDeleteFolder.TabIndex = 9;
            btnDeleteFolder.UseVisualStyleBackColor = true;
            btnDeleteFolder.Click += btnDeleteFolder_Click;
            // 
            // btnItemUp
            // 
            btnItemUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnItemUp.FlatAppearance.BorderSize = 0;
            btnItemUp.FlatStyle = FlatStyle.Flat;
            btnItemUp.IconChar = FontAwesome.Sharp.IconChar.CircleArrowUp;
            btnItemUp.IconColor = Color.Black;
            btnItemUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnItemUp.IconSize = 33;
            btnItemUp.Location = new Point(3, 72);
            btnItemUp.Margin = new Padding(3, 0, 3, 4);
            btnItemUp.Name = "btnItemUp";
            btnItemUp.Size = new Size(32, 32);
            btnItemUp.TabIndex = 11;
            btnItemUp.UseVisualStyleBackColor = true;
            btnItemUp.Click += btnItemUp_Click;
            // 
            // btnItemDown
            // 
            btnItemDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnItemDown.FlatAppearance.BorderSize = 0;
            btnItemDown.FlatStyle = FlatStyle.Flat;
            btnItemDown.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleDown;
            btnItemDown.IconColor = Color.Black;
            btnItemDown.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnItemDown.IconSize = 33;
            btnItemDown.Location = new Point(3, 108);
            btnItemDown.Margin = new Padding(3, 0, 3, 4);
            btnItemDown.Name = "btnItemDown";
            btnItemDown.Size = new Size(32, 32);
            btnItemDown.TabIndex = 12;
            btnItemDown.UseVisualStyleBackColor = true;
            btnItemDown.Click += btnItemDown_Click;
            // 
            // btnAddLocal
            // 
            btnAddLocal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddLocal.FlatAppearance.BorderSize = 0;
            btnAddLocal.FlatStyle = FlatStyle.Flat;
            btnAddLocal.IconChar = FontAwesome.Sharp.IconChar.Location;
            btnAddLocal.IconColor = Color.Black;
            btnAddLocal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddLocal.IconSize = 33;
            btnAddLocal.Location = new Point(3, 144);
            btnAddLocal.Margin = new Padding(3, 0, 3, 4);
            btnAddLocal.Name = "btnAddLocal";
            btnAddLocal.Size = new Size(32, 32);
            btnAddLocal.TabIndex = 13;
            btnAddLocal.UseVisualStyleBackColor = true;
            btnAddLocal.Click += btnAddLocal_Click;
            // 
            // lvDirectories
            // 
            lvDirectories.Dock = DockStyle.Fill;
            lvDirectories.FullRowSelect = true;
            lvDirectories.Location = new Point(6, 3);
            lvDirectories.Margin = new Padding(6, 3, 3, 3);
            lvDirectories.Name = "lvDirectories";
            lvDirectories.Size = new Size(461, 188);
            lvDirectories.TabIndex = 8;
            lvDirectories.UseCompatibleStateImageBehavior = false;
            lvDirectories.View = View.List;
            // 
            // lbl5
            // 
            lbl5.Dock = DockStyle.Top;
            lbl5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl5.Location = new Point(0, 0);
            lbl5.Margin = new Padding(3, 5, 3, 0);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(518, 24);
            lbl5.TabIndex = 11;
            lbl5.Text = "Directories to search for compatible scripts:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.SlateBlue;
            panel3.Controls.Add(cbIncludeSubdirectoriesForScriptLoad);
            panel3.Controls.Add(cbUsingScriptPlayer);
            panel3.Controls.Add(cbHandleMultiAxis);
            panel3.Controls.Add(cbShowScriptPath);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 534);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 119);
            panel3.TabIndex = 15;
            // 
            // cbIncludeSubdirectoriesForScriptLoad
            // 
            cbIncludeSubdirectoriesForScriptLoad.BoxSize = 13;
            cbIncludeSubdirectoriesForScriptLoad.Dock = DockStyle.Top;
            cbIncludeSubdirectoriesForScriptLoad.HoverColor = Color.DeepSkyBlue;
            cbIncludeSubdirectoriesForScriptLoad.Location = new Point(0, 72);
            cbIncludeSubdirectoriesForScriptLoad.Name = "cbIncludeSubdirectoriesForScriptLoad";
            cbIncludeSubdirectoriesForScriptLoad.PaddingLeft = 12;
            cbIncludeSubdirectoriesForScriptLoad.Size = new Size(518, 24);
            cbIncludeSubdirectoriesForScriptLoad.TabIndex = 27;
            cbIncludeSubdirectoriesForScriptLoad.Text = "Include subdirectories to search for scripts";
            cbIncludeSubdirectoriesForScriptLoad.UseVisualStyleBackColor = true;
            // 
            // cbUsingScriptPlayer
            // 
            cbUsingScriptPlayer.BoxSize = 13;
            cbUsingScriptPlayer.Dock = DockStyle.Top;
            cbUsingScriptPlayer.HoverColor = Color.DeepSkyBlue;
            cbUsingScriptPlayer.Location = new Point(0, 48);
            cbUsingScriptPlayer.Margin = new Padding(0, 0, 3, 3);
            cbUsingScriptPlayer.Name = "cbUsingScriptPlayer";
            cbUsingScriptPlayer.PaddingLeft = 12;
            cbUsingScriptPlayer.Size = new Size(518, 24);
            cbUsingScriptPlayer.TabIndex = 26;
            cbUsingScriptPlayer.Text = "Enable ScriptPlayer compatibility";
            cbUsingScriptPlayer.UseVisualStyleBackColor = true;
            // 
            // cbHandleMultiAxis
            // 
            cbHandleMultiAxis.BoxSize = 13;
            cbHandleMultiAxis.Dock = DockStyle.Top;
            cbHandleMultiAxis.HoverColor = Color.DeepSkyBlue;
            cbHandleMultiAxis.Location = new Point(0, 24);
            cbHandleMultiAxis.Name = "cbHandleMultiAxis";
            cbHandleMultiAxis.PaddingLeft = 12;
            cbHandleMultiAxis.Size = new Size(518, 24);
            cbHandleMultiAxis.TabIndex = 25;
            cbHandleMultiAxis.Text = "Handle Multi-Axis scripts";
            cbHandleMultiAxis.UseVisualStyleBackColor = true;
            // 
            // cbShowScriptPath
            // 
            cbShowScriptPath.BoxSize = 13;
            cbShowScriptPath.Dock = DockStyle.Top;
            cbShowScriptPath.HoverColor = Color.DeepSkyBlue;
            cbShowScriptPath.Location = new Point(0, 0);
            cbShowScriptPath.Name = "cbShowScriptPath";
            cbShowScriptPath.PaddingLeft = 12;
            cbShowScriptPath.Size = new Size(518, 24);
            cbShowScriptPath.TabIndex = 24;
            cbShowScriptPath.Text = "Show full file path in script context menu";
            cbShowScriptPath.UseVisualStyleBackColor = true;
            // 
            // SyncUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(tableLayoutMain);
            Name = "SyncUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutDirs.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        private TableLayoutPanel tableLayoutPanel1;
        private Controls.RoundedCheckBox cbTimeCodeServer;
        private Controls.RoundedCheckBox cbScriptGraph;
        private Panel panel2;
        private Label lbl5;
        private TableLayoutPanel tableLayoutDirs;
        private ListView lvDirectories;
        private FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnAddFolder;
        private FontAwesome.Sharp.IconButton btnDeleteFolder;
        private FontAwesome.Sharp.IconButton btnItemUp;
        private FontAwesome.Sharp.IconButton btnItemDown;
        private FontAwesome.Sharp.IconButton btnAddLocal;
        private Panel panel3;
        private Controls.CustomCheckBox cbShowScriptPath;
        private Controls.CustomCheckBox cbHandleMultiAxis;
        private Controls.CustomCheckBox cbUsingScriptPlayer;
        private Controls.CustomCheckBox cbIncludeSubdirectoriesForScriptLoad;
        private ToolTip toolTipInfo;
    }
}
