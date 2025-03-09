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
            lblHeader = new Label();
            lbl3 = new Label();
            lbl4 = new Label();
            cbTimeCodeServer = new Controls.RoundedCheckBox();
            cbScriptGraph = new Controls.RoundedCheckBox();
            panelMain = new Panel();
            panel2 = new Panel();
            cbIncludeSubdirectoriesForScriptLoad = new Controls.CustomCheckBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cbUsingScriptPlayer = new Controls.CustomCheckBox();
            lbl6 = new Label();
            cbHandleMultiAxis = new Controls.CustomCheckBox();
            cbShowScriptPath = new Controls.CustomCheckBox();
            panelDirectories = new Panel();
            lvDirectories = new ListView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAddFolder = new FontAwesome.Sharp.IconButton();
            btnDeleteFolder = new FontAwesome.Sharp.IconButton();
            btnItemUp = new FontAwesome.Sharp.IconButton();
            btnItemDown = new FontAwesome.Sharp.IconButton();
            btnAddLocal = new FontAwesome.Sharp.IconButton();
            lbl5 = new Label();
            lbl1 = new Label();
            lbl2 = new Label();
            toolTipInfo = new ToolTip(components);
            panelMain.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panelDirectories.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Margin = new Padding(3, 3, 3, 10);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(475, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Sync";
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl3.ForeColor = Color.Indigo;
            lbl3.Location = new Point(0, 176);
            lbl3.Margin = new Padding(3, 6, 3, 3);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 0, 6, 0);
            lbl3.Size = new Size(475, 25);
            lbl3.TabIndex = 3;
            lbl3.Text = "The video info gets synced locally via 'http://127.0.0.1:13579/variables.html'";
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl4.Location = new Point(0, 201);
            lbl4.Margin = new Padding(3, 6, 3, 3);
            lbl4.Name = "lbl4";
            lbl4.Padding = new Padding(6, 0, 6, 9);
            lbl4.Size = new Size(475, 31);
            lbl4.TabIndex = 4;
            lbl4.Text = "Script graph is shown within the players progress bar and is only a visual indicator. ";
            // 
            // cbTimeCodeServer
            // 
            cbTimeCodeServer.Appearance = Appearance.Button;
            cbTimeCodeServer.BackColor = Color.Transparent;
            cbTimeCodeServer.CheckedBackColor = Color.LightGreen;
            cbTimeCodeServer.FlatAppearance.BorderSize = 0;
            cbTimeCodeServer.FlatStyle = FlatStyle.Flat;
            cbTimeCodeServer.Location = new Point(70, 8);
            cbTimeCodeServer.Margin = new Padding(3, 8, 3, 3);
            cbTimeCodeServer.Name = "cbTimeCodeServer";
            cbTimeCodeServer.Size = new Size(170, 35);
            cbTimeCodeServer.TabIndex = 5;
            cbTimeCodeServer.Text = "Start timecode server";
            cbTimeCodeServer.UncheckedBackColor = Color.LightGray;
            cbTimeCodeServer.UseVisualStyleBackColor = false;
            // 
            // cbScriptGraph
            // 
            cbScriptGraph.Appearance = Appearance.Button;
            cbScriptGraph.BackColor = Color.Transparent;
            cbScriptGraph.CheckedBackColor = Color.LightGreen;
            cbScriptGraph.FlatAppearance.BorderSize = 0;
            cbScriptGraph.FlatStyle = FlatStyle.Flat;
            cbScriptGraph.Location = new Point(246, 8);
            cbScriptGraph.Margin = new Padding(3, 8, 3, 3);
            cbScriptGraph.Name = "cbScriptGraph";
            cbScriptGraph.Size = new Size(170, 35);
            cbScriptGraph.TabIndex = 6;
            cbScriptGraph.Text = "Show script graph";
            cbScriptGraph.UncheckedBackColor = Color.LightGray;
            cbScriptGraph.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panel2);
            panelMain.Controls.Add(cbTimeCodeServer);
            panelMain.Controls.Add(cbScriptGraph);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 232);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(475, 371);
            panelMain.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MintCream;
            panel2.Controls.Add(cbIncludeSubdirectoriesForScriptLoad);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Controls.Add(cbHandleMultiAxis);
            panel2.Controls.Add(cbShowScriptPath);
            panel2.Controls.Add(panelDirectories);
            panel2.Controls.Add(lbl5);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(475, 317);
            panel2.TabIndex = 15;
            // 
            // cbIncludeSubdirectoriesForScriptLoad
            // 
            cbIncludeSubdirectoriesForScriptLoad.BoxSize = 13;
            cbIncludeSubdirectoriesForScriptLoad.Dock = DockStyle.Top;
            cbIncludeSubdirectoriesForScriptLoad.HoverColor = Color.DeepSkyBlue;
            cbIncludeSubdirectoriesForScriptLoad.Location = new Point(0, 264);
            cbIncludeSubdirectoriesForScriptLoad.Name = "cbIncludeSubdirectoriesForScriptLoad";
            cbIncludeSubdirectoriesForScriptLoad.PaddingLeft = 9;
            cbIncludeSubdirectoriesForScriptLoad.Size = new Size(475, 19);
            cbIncludeSubdirectoriesForScriptLoad.TabIndex = 26;
            cbIncludeSubdirectoriesForScriptLoad.Text = "Include subdirectories to search for scripts";
            cbIncludeSubdirectoriesForScriptLoad.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(cbUsingScriptPlayer);
            flowLayoutPanel2.Controls.Add(lbl6);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 245);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(475, 19);
            flowLayoutPanel2.TabIndex = 22;
            // 
            // cbUsingScriptPlayer
            // 
            cbUsingScriptPlayer.BoxSize = 13;
            cbUsingScriptPlayer.HoverColor = Color.DeepSkyBlue;
            cbUsingScriptPlayer.Location = new Point(0, 0);
            cbUsingScriptPlayer.Margin = new Padding(0, 0, 3, 3);
            cbUsingScriptPlayer.Name = "cbUsingScriptPlayer";
            cbUsingScriptPlayer.PaddingLeft = 9;
            cbUsingScriptPlayer.Size = new Size(160, 19);
            cbUsingScriptPlayer.TabIndex = 25;
            cbUsingScriptPlayer.Text = "Using ScriptPlayer";
            cbUsingScriptPlayer.UseVisualStyleBackColor = true;
            // 
            // lbl6
            // 
            lbl6.ForeColor = Color.DarkOliveGreen;
            lbl6.Location = new Point(166, 0);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(282, 19);
            lbl6.TabIndex = 19;
            lbl6.Text = "Check this if you are (also) using ScriptPlayer";
            lbl6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbHandleMultiAxis
            // 
            cbHandleMultiAxis.BoxSize = 13;
            cbHandleMultiAxis.Dock = DockStyle.Top;
            cbHandleMultiAxis.HoverColor = Color.DeepSkyBlue;
            cbHandleMultiAxis.Location = new Point(0, 226);
            cbHandleMultiAxis.Name = "cbHandleMultiAxis";
            cbHandleMultiAxis.PaddingLeft = 9;
            cbHandleMultiAxis.Size = new Size(475, 19);
            cbHandleMultiAxis.TabIndex = 24;
            cbHandleMultiAxis.Text = "Handle Multi-Axis scripts";
            cbHandleMultiAxis.UseVisualStyleBackColor = true;
            // 
            // cbShowScriptPath
            // 
            cbShowScriptPath.BoxSize = 13;
            cbShowScriptPath.Dock = DockStyle.Top;
            cbShowScriptPath.HoverColor = Color.DeepSkyBlue;
            cbShowScriptPath.Location = new Point(0, 207);
            cbShowScriptPath.Name = "cbShowScriptPath";
            cbShowScriptPath.PaddingLeft = 9;
            cbShowScriptPath.Size = new Size(475, 19);
            cbShowScriptPath.TabIndex = 23;
            cbShowScriptPath.Text = "Show full file path in script context menu";
            cbShowScriptPath.UseVisualStyleBackColor = true;
            // 
            // panelDirectories
            // 
            panelDirectories.Controls.Add(lvDirectories);
            panelDirectories.Controls.Add(flowLayoutPanel1);
            panelDirectories.Dock = DockStyle.Top;
            panelDirectories.Location = new Point(0, 23);
            panelDirectories.Name = "panelDirectories";
            panelDirectories.Size = new Size(475, 184);
            panelDirectories.TabIndex = 21;
            // 
            // lvDirectories
            // 
            lvDirectories.Dock = DockStyle.Fill;
            lvDirectories.FullRowSelect = true;
            lvDirectories.Location = new Point(0, 0);
            lvDirectories.Margin = new Padding(6, 3, 3, 3);
            lvDirectories.Name = "lvDirectories";
            lvDirectories.Size = new Size(433, 184);
            lvDirectories.TabIndex = 7;
            lvDirectories.UseCompatibleStateImageBehavior = false;
            lvDirectories.View = System.Windows.Forms.View.List;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnAddFolder);
            flowLayoutPanel1.Controls.Add(btnDeleteFolder);
            flowLayoutPanel1.Controls.Add(btnItemUp);
            flowLayoutPanel1.Controls.Add(btnItemDown);
            flowLayoutPanel1.Controls.Add(btnAddLocal);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.Location = new Point(433, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(42, 184);
            flowLayoutPanel1.TabIndex = 8;
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
            btnDeleteFolder.IconChar = FontAwesome.Sharp.IconChar.CircleMinus;
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
            btnItemUp.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleUp;
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
            // lbl5
            // 
            lbl5.Dock = DockStyle.Top;
            lbl5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl5.Location = new Point(0, 0);
            lbl5.Margin = new Padding(3, 5, 3, 0);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(475, 23);
            lbl5.TabIndex = 10;
            lbl5.Text = "Directories to search for compatible scripts:";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 55);
            lbl1.Margin = new Padding(3, 6, 3, 3);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 6, 0);
            lbl1.Size = new Size(475, 66);
            lbl1.TabIndex = 8;
            lbl1.Text = "Check Timecode Server, to activate syncing. (Only after settings are saved)\r\n\r\nCurrently these two can read RVP information and use them for their toy syncing method, here is how to set it up:";
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 121);
            lbl2.Margin = new Padding(3, 6, 3, 3);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(10, 0, 6, 0);
            lbl2.Size = new Size(475, 55);
            lbl2.TabIndex = 9;
            lbl2.Text = "- In MultiFunPlayer, activate media source \"MPC-HC\". Either connect manually or activate auto-connect.\r\n- In ScriptPlayer, click \"Video Player\" and select \"MPC-HC\".\r\n";
            // 
            // SyncUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panelMain);
            Controls.Add(lbl4);
            Controls.Add(lbl3);
            Controls.Add(lbl2);
            Controls.Add(lbl1);
            Controls.Add(lblHeader);
            Name = "SyncUserControl";
            Size = new Size(475, 603);
            panelMain.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            panelDirectories.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Label lbl3;
        private Label lbl4;
        private Controls.RoundedCheckBox cbTimeCodeServer;
        private Controls.RoundedCheckBox cbScriptGraph;
        private Panel panelMain;
        private Label lbl1;
        private Label lbl2;
        private FontAwesome.Sharp.IconButton btnDeleteFolder;
        private FontAwesome.Sharp.IconButton btnAddFolder;
        private ListView lvDirectories;
        private Label lbl5;
        private FontAwesome.Sharp.IconButton btnItemDown;
        private FontAwesome.Sharp.IconButton btnItemUp;
        private FontAwesome.Sharp.IconButton btnAddLocal;
        private ToolTip toolTipInfo;
        private Panel panel2;
        private Label lbl6;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panelDirectories;
        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.CustomCheckBox cbHandleMultiAxis;
        private Controls.CustomCheckBox cbShowScriptPath;
        private Controls.CustomCheckBox cbIncludeSubdirectoriesForScriptLoad;
        private Controls.CustomCheckBox cbUsingScriptPlayer;
    }
}
