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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cbTimeCodeServer = new Controls.RoundedCheckBox();
            cbScriptGraph = new Controls.RoundedCheckBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label7 = new Label();
            cbUsingScriptPlayer = new CheckBox();
            cbHandleMultiAxis = new CheckBox();
            label6 = new Label();
            cbShowScriptPath = new CheckBox();
            lvDirectories = new ListView();
            btnAddLocal = new FontAwesome.Sharp.IconButton();
            btnAddFolder = new FontAwesome.Sharp.IconButton();
            btnItemDown = new FontAwesome.Sharp.IconButton();
            btnDeleteFolder = new FontAwesome.Sharp.IconButton();
            btnItemUp = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            label5 = new Label();
            toolTipInfo = new ToolTip(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(3, 3, 3, 10);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 8);
            label1.Size = new Size(453, 55);
            label1.TabIndex = 0;
            label1.Text = "Sync";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Indigo;
            label2.Location = new Point(0, 176);
            label2.Margin = new Padding(3, 6, 3, 3);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 6, 0);
            label2.Size = new Size(453, 25);
            label2.TabIndex = 3;
            label2.Text = "The video info gets synced locally via 'http://127.0.0.1:13579/variables.html'";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 201);
            label3.Margin = new Padding(3, 6, 3, 3);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 6, 9);
            label3.Size = new Size(453, 24);
            label3.TabIndex = 4;
            label3.Text = "Script graph is shown within the players progress bar and is only a visual indicator. ";
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
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(cbTimeCodeServer);
            panel1.Controls.Add(cbScriptGraph);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 225);
            panel1.Name = "panel1";
            panel1.Size = new Size(453, 345);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MintCream;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(cbUsingScriptPlayer);
            panel2.Controls.Add(cbHandleMultiAxis);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cbShowScriptPath);
            panel2.Controls.Add(lvDirectories);
            panel2.Controls.Add(btnAddLocal);
            panel2.Controls.Add(btnAddFolder);
            panel2.Controls.Add(btnItemDown);
            panel2.Controls.Add(btnDeleteFolder);
            panel2.Controls.Add(btnItemUp);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(453, 296);
            panel2.TabIndex = 15;
            // 
            // label7
            // 
            label7.ForeColor = Color.DarkOliveGreen;
            label7.Location = new Point(130, 265);
            label7.Name = "label7";
            label7.Size = new Size(282, 19);
            label7.TabIndex = 19;
            label7.Text = "Check this if you are (also) using ScriptPlayer";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbUsingScriptPlayer
            // 
            cbUsingScriptPlayer.AutoSize = true;
            cbUsingScriptPlayer.Location = new Point(6, 266);
            cbUsingScriptPlayer.Name = "cbUsingScriptPlayer";
            cbUsingScriptPlayer.Size = new Size(121, 19);
            cbUsingScriptPlayer.TabIndex = 18;
            cbUsingScriptPlayer.Text = "Using ScriptPlayer";
            cbUsingScriptPlayer.UseVisualStyleBackColor = true;
            // 
            // cbHandleMultiAxis
            // 
            cbHandleMultiAxis.AutoSize = true;
            cbHandleMultiAxis.Location = new Point(6, 241);
            cbHandleMultiAxis.Name = "cbHandleMultiAxis";
            cbHandleMultiAxis.Size = new Size(159, 19);
            cbHandleMultiAxis.TabIndex = 15;
            cbHandleMultiAxis.Text = "Handle Multi-Axis scripts";
            cbHandleMultiAxis.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(3, 8);
            label6.Margin = new Padding(3, 5, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(236, 15);
            label6.TabIndex = 10;
            label6.Text = "Directories to search for compatible scripts:";
            // 
            // cbShowScriptPath
            // 
            cbShowScriptPath.AutoSize = true;
            cbShowScriptPath.Location = new Point(6, 216);
            cbShowScriptPath.Name = "cbShowScriptPath";
            cbShowScriptPath.Size = new Size(243, 19);
            cbShowScriptPath.TabIndex = 14;
            cbShowScriptPath.Text = "Show full file path in script context menu";
            cbShowScriptPath.UseVisualStyleBackColor = true;
            // 
            // lvDirectories
            // 
            lvDirectories.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvDirectories.FullRowSelect = true;
            lvDirectories.Location = new Point(6, 26);
            lvDirectories.Margin = new Padding(6, 3, 3, 3);
            lvDirectories.Name = "lvDirectories";
            lvDirectories.Size = new Size(406, 184);
            lvDirectories.TabIndex = 7;
            lvDirectories.UseCompatibleStateImageBehavior = false;
            lvDirectories.View = System.Windows.Forms.View.List;
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
            btnAddLocal.Location = new Point(418, 178);
            btnAddLocal.Name = "btnAddLocal";
            btnAddLocal.Size = new Size(32, 32);
            btnAddLocal.TabIndex = 13;
            btnAddLocal.UseVisualStyleBackColor = true;
            btnAddLocal.Click += btnAddLocal_Click;
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
            btnAddFolder.Location = new Point(418, 26);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(32, 32);
            btnAddFolder.TabIndex = 8;
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Click += btnAddFolder_Click;
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
            btnItemDown.Location = new Point(418, 140);
            btnItemDown.Name = "btnItemDown";
            btnItemDown.Size = new Size(32, 32);
            btnItemDown.TabIndex = 12;
            btnItemDown.UseVisualStyleBackColor = true;
            btnItemDown.Click += btnItemDown_Click;
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
            btnDeleteFolder.Location = new Point(418, 64);
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
            btnItemUp.Location = new Point(418, 102);
            btnItemUp.Name = "btnItemUp";
            btnItemUp.Size = new Size(32, 32);
            btnItemUp.TabIndex = 11;
            btnItemUp.UseVisualStyleBackColor = true;
            btnItemUp.Click += btnItemUp_Click;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 55);
            label4.Margin = new Padding(3, 6, 3, 3);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 6, 0);
            label4.Size = new Size(453, 66);
            label4.TabIndex = 8;
            label4.Text = "Check Timecode Server, to activate syncing. (Only after settings are saved)\r\n\r\nCurrently these two can read RVP information and use them for their toy syncing method, here is how to set it up:";
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(0, 121);
            label5.Margin = new Padding(3, 6, 3, 3);
            label5.Name = "label5";
            label5.Padding = new Padding(10, 0, 6, 0);
            label5.Size = new Size(453, 55);
            label5.TabIndex = 9;
            label5.Text = "- In MultiFunPlayer, activate media source \"MPC-HC\". Either connect manually or activate auto-connect.\r\n- In ScriptPlayer, click \"Video Player\" and select \"MPC-HC\".\r\n";
            // 
            // SyncUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "SyncUserControl";
            Size = new Size(453, 570);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Controls.RoundedCheckBox cbTimeCodeServer;
        private Controls.RoundedCheckBox cbScriptGraph;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private FontAwesome.Sharp.IconButton btnDeleteFolder;
        private FontAwesome.Sharp.IconButton btnAddFolder;
        private ListView lvDirectories;
        private Label label6;
        private FontAwesome.Sharp.IconButton btnItemDown;
        private FontAwesome.Sharp.IconButton btnItemUp;
        private FontAwesome.Sharp.IconButton btnAddLocal;
        private CheckBox cbShowScriptPath;
        private ToolTip toolTipInfo;
        private Panel panel2;
        private CheckBox cbHandleMultiAxis;
        private CheckBox cbUsingScriptPlayer;
        private Label label7;
    }
}
