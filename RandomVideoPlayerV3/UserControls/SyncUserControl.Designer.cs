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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cbTimeCodeServer = new Controls.RoundedCheckBox();
            cbScriptGraph = new Controls.RoundedCheckBox();
            panel1 = new Panel();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
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
            label2.Size = new Size(453, 34);
            label2.TabIndex = 3;
            label2.Text = "The video info gets synced locally via 'http://127.0.0.1:13579/variables.html'";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 210);
            label3.Margin = new Padding(3, 6, 3, 3);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 6, 9);
            label3.Size = new Size(453, 58);
            label3.TabIndex = 4;
            label3.Text = "Script graph is shown within the players progress bar and is only a visual indicator. \r\n(Disable it if not needed, as it costs some performance)";
            // 
            // cbTimeCodeServer
            // 
            cbTimeCodeServer.Anchor = AnchorStyles.None;
            cbTimeCodeServer.Appearance = Appearance.Button;
            cbTimeCodeServer.BackColor = Color.Transparent;
            cbTimeCodeServer.CheckedBackColor = Color.LightGreen;
            cbTimeCodeServer.FlatAppearance.BorderSize = 0;
            cbTimeCodeServer.FlatStyle = FlatStyle.Flat;
            cbTimeCodeServer.Location = new Point(141, 95);
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
            cbScriptGraph.Anchor = AnchorStyles.None;
            cbScriptGraph.Appearance = Appearance.Button;
            cbScriptGraph.BackColor = Color.Transparent;
            cbScriptGraph.CheckedBackColor = Color.LightGreen;
            cbScriptGraph.FlatAppearance.BorderSize = 0;
            cbScriptGraph.FlatStyle = FlatStyle.Flat;
            cbScriptGraph.Location = new Point(141, 49);
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
            panel1.Controls.Add(cbTimeCodeServer);
            panel1.Controls.Add(cbScriptGraph);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 268);
            panel1.Name = "panel1";
            panel1.Size = new Size(453, 230);
            panel1.TabIndex = 7;
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
            Size = new Size(453, 498);
            panel1.ResumeLayout(false);
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
    }
}
