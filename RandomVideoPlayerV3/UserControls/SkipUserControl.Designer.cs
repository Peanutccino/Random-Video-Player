namespace RandomVideoPlayer.UserControls
{
    partial class SkipUserControl
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
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            cbEnableSkip = new CheckBox();
            label3 = new Label();
            panel3 = new Panel();
            cbSkipAlways = new CheckBox();
            cbSkipVideoStart = new CheckBox();
            label4 = new Label();
            panel4 = new Panel();
            label6 = new Label();
            inputSkipGapLength = new Controls.CustomNumericUpDown();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
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
            label1.Size = new Size(475, 55);
            label1.TabIndex = 1;
            label1.Text = "Skip";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 48);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 0, 0);
            label2.Size = new Size(475, 24);
            label2.TabIndex = 0;
            label2.Text = "This function is used to automatically skip gaps in a funscript video.";
            // 
            // panel2
            // 
            panel2.Controls.Add(cbEnableSkip);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(475, 81);
            panel2.TabIndex = 3;
            // 
            // cbEnableSkip
            // 
            cbEnableSkip.AutoSize = true;
            cbEnableSkip.Location = new Point(3, 27);
            cbEnableSkip.Name = "cbEnableSkip";
            cbEnableSkip.Padding = new Padding(6, 0, 0, 0);
            cbEnableSkip.Size = new Size(118, 19);
            cbEnableSkip.TabIndex = 2;
            cbEnableSkip.Text = "Enable auto skip";
            cbEnableSkip.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 0, 0);
            label3.Size = new Size(475, 24);
            label3.TabIndex = 1;
            label3.Text = "Activate auto skip:";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbSkipAlways);
            panel3.Controls.Add(cbSkipVideoStart);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 184);
            panel3.Name = "panel3";
            panel3.Size = new Size(475, 100);
            panel3.TabIndex = 4;
            // 
            // cbSkipAlways
            // 
            cbSkipAlways.AutoSize = true;
            cbSkipAlways.Location = new Point(3, 52);
            cbSkipAlways.Name = "cbSkipAlways";
            cbSkipAlways.Padding = new Padding(6, 0, 0, 0);
            cbSkipAlways.Size = new Size(225, 19);
            cbSkipAlways.TabIndex = 4;
            cbSkipAlways.Text = "Skip every gap greater than specified";
            cbSkipAlways.UseVisualStyleBackColor = true;
            // 
            // cbSkipVideoStart
            // 
            cbSkipVideoStart.AutoSize = true;
            cbSkipVideoStart.Location = new Point(3, 27);
            cbSkipVideoStart.Name = "cbSkipVideoStart";
            cbSkipVideoStart.Padding = new Padding(6, 0, 0, 0);
            cbSkipVideoStart.Size = new Size(152, 19);
            cbSkipVideoStart.TabIndex = 3;
            cbSkipVideoStart.Text = "Skip gap on video start";
            cbSkipVideoStart.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 0, 0);
            label4.Size = new Size(475, 24);
            label4.TabIndex = 2;
            label4.Text = "Change behaviour:";
            // 
            // panel4
            // 
            panel4.Controls.Add(label6);
            panel4.Controls.Add(inputSkipGapLength);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 284);
            panel4.Name = "panel4";
            panel4.Size = new Size(475, 100);
            panel4.TabIndex = 5;
            // 
            // label6
            // 
            label6.Location = new Point(97, 27);
            label6.Name = "label6";
            label6.Size = new Size(100, 19);
            label6.TabIndex = 5;
            label6.Text = "seconds";
            // 
            // inputSkipGapLength
            // 
            inputSkipGapLength.Location = new Point(15, 27);
            inputSkipGapLength.Maximum = 1000;
            inputSkipGapLength.Minimum = 1;
            inputSkipGapLength.Name = "inputSkipGapLength";
            inputSkipGapLength.Size = new Size(76, 19);
            inputSkipGapLength.TabIndex = 4;
            inputSkipGapLength.Text = "customNumericUpDown1";
            inputSkipGapLength.Value = 1;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(475, 24);
            label5.TabIndex = 3;
            label5.Text = "Specify minimum length of gaps that should be skipped:";
            // 
            // SkipUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "SkipUserControl";
            Size = new Size(475, 603);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private CheckBox cbEnableSkip;
        private Label label3;
        private Panel panel3;
        private Label label4;
        private Panel panel4;
        private Label label5;
        private Controls.CustomNumericUpDown inputSkipGapLength;
        private CheckBox cbSkipAlways;
        private CheckBox cbSkipVideoStart;
        private Label label6;
    }
}
