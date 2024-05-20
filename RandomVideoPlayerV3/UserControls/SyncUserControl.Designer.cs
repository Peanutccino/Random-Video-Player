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
            cbTimeCodeServer = new CheckBox();
            cbScriptGraph = new CheckBox();
            label2 = new Label();
            label3 = new Label();
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
            label1.Size = new Size(390, 55);
            label1.TabIndex = 0;
            label1.Text = "Sync";
            // 
            // cbTimeCodeServer
            // 
            cbTimeCodeServer.AutoSize = true;
            cbTimeCodeServer.Dock = DockStyle.Top;
            cbTimeCodeServer.Location = new Point(0, 185);
            cbTimeCodeServer.Name = "cbTimeCodeServer";
            cbTimeCodeServer.Padding = new Padding(9, 0, 0, 9);
            cbTimeCodeServer.Size = new Size(390, 28);
            cbTimeCodeServer.TabIndex = 1;
            cbTimeCodeServer.Text = "Timecode Server";
            cbTimeCodeServer.UseVisualStyleBackColor = true;
            // 
            // cbScriptGraph
            // 
            cbScriptGraph.AutoSize = true;
            cbScriptGraph.Dock = DockStyle.Top;
            cbScriptGraph.Location = new Point(0, 213);
            cbScriptGraph.Name = "cbScriptGraph";
            cbScriptGraph.Padding = new Padding(9, 0, 0, 6);
            cbScriptGraph.Size = new Size(390, 25);
            cbScriptGraph.TabIndex = 2;
            cbScriptGraph.Text = "Show script graph";
            cbScriptGraph.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 55);
            label2.Margin = new Padding(3, 6, 3, 3);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 6, 0);
            label2.Size = new Size(390, 70);
            label2.TabIndex = 3;
            label2.Text = "Check Timecode Server, to activate syncing. Select MPC-HC as source in MultiFunPlayer. The video info gets synced locally via 'http://127.0.0.1:13579/variables.html'";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 125);
            label3.Margin = new Padding(3, 6, 3, 3);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 6, 9);
            label3.Size = new Size(390, 60);
            label3.TabIndex = 4;
            label3.Text = "Script graph is shown within the players progress bar and is only a visual indicator.";
            // 
            // SyncUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(cbScriptGraph);
            Controls.Add(cbTimeCodeServer);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SyncUserControl";
            Size = new Size(390, 363);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox cbTimeCodeServer;
        private CheckBox cbScriptGraph;
        private Label label2;
        private Label label3;
    }
}
