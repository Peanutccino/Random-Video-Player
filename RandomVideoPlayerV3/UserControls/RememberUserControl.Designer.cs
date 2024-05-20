namespace RandomVideoPlayer.UserControls
{
    partial class RememberUserControl
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
            cbWindowSize = new CheckBox();
            cbPlayRecent = new CheckBox();
            cbRecentCount = new CheckBox();
            cbVolume = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 8);
            label1.Size = new Size(319, 55);
            label1.TabIndex = 0;
            label1.Text = "Remember";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 55);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 0, 8);
            label2.Size = new Size(319, 33);
            label2.TabIndex = 1;
            label2.Text = "Check to remember state for next application start:";
            // 
            // cbWindowSize
            // 
            cbWindowSize.AutoSize = true;
            cbWindowSize.Dock = DockStyle.Top;
            cbWindowSize.Location = new Point(0, 88);
            cbWindowSize.Name = "cbWindowSize";
            cbWindowSize.Padding = new Padding(9, 0, 0, 8);
            cbWindowSize.Size = new Size(319, 27);
            cbWindowSize.TabIndex = 2;
            cbWindowSize.Text = "Window size";
            cbWindowSize.UseVisualStyleBackColor = true;
            // 
            // cbPlayRecent
            // 
            cbPlayRecent.AutoSize = true;
            cbPlayRecent.Dock = DockStyle.Top;
            cbPlayRecent.Location = new Point(0, 115);
            cbPlayRecent.Name = "cbPlayRecent";
            cbPlayRecent.Padding = new Padding(9, 0, 0, 8);
            cbPlayRecent.Size = new Size(319, 27);
            cbPlayRecent.TabIndex = 3;
            cbPlayRecent.Text = "Play only latest files setting";
            cbPlayRecent.UseVisualStyleBackColor = true;
            // 
            // cbRecentCount
            // 
            cbRecentCount.AutoSize = true;
            cbRecentCount.Dock = DockStyle.Top;
            cbRecentCount.Location = new Point(0, 142);
            cbRecentCount.Name = "cbRecentCount";
            cbRecentCount.Padding = new Padding(9, 0, 0, 8);
            cbRecentCount.Size = new Size(319, 27);
            cbRecentCount.TabIndex = 4;
            cbRecentCount.Text = "Recent count number";
            cbRecentCount.UseVisualStyleBackColor = true;
            // 
            // cbVolume
            // 
            cbVolume.AutoSize = true;
            cbVolume.Dock = DockStyle.Top;
            cbVolume.Location = new Point(0, 169);
            cbVolume.Name = "cbVolume";
            cbVolume.Padding = new Padding(9, 0, 0, 8);
            cbVolume.Size = new Size(319, 27);
            cbVolume.TabIndex = 5;
            cbVolume.Text = "Volume";
            cbVolume.UseVisualStyleBackColor = true;
            // 
            // RememberUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(cbVolume);
            Controls.Add(cbRecentCount);
            Controls.Add(cbPlayRecent);
            Controls.Add(cbWindowSize);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RememberUserControl";
            Size = new Size(319, 268);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox cbWindowSize;
        private CheckBox cbPlayRecent;
        private CheckBox cbRecentCount;
        private CheckBox cbVolume;
    }
}
