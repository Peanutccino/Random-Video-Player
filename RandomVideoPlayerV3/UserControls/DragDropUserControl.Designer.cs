namespace RandomVideoPlayer.UserControls
{
    partial class DragDropUserControl
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
            rbDropQueue = new RadioButton();
            rbDropPlay = new RadioButton();
            label2 = new Label();
            panel2 = new Panel();
            cbAlwaysAddFilesToQueue = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            cbIncludeSubdirectories = new CheckBox();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.GhostWhite;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 8);
            label1.Size = new Size(482, 52);
            label1.TabIndex = 1;
            label1.Text = "Drag && Drop";
            // 
            // panel1
            // 
            panel1.Controls.Add(rbDropQueue);
            panel1.Controls.Add(rbDropPlay);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 75);
            panel1.TabIndex = 2;
            // 
            // rbDropQueue
            // 
            rbDropQueue.AutoSize = true;
            rbDropQueue.Location = new Point(182, 33);
            rbDropQueue.Name = "rbDropQueue";
            rbDropQueue.Size = new Size(99, 19);
            rbDropQueue.TabIndex = 2;
            rbDropQueue.TabStop = true;
            rbDropQueue.Text = "Add to Queue";
            rbDropQueue.UseVisualStyleBackColor = true;
            // 
            // rbDropPlay
            // 
            rbDropPlay.AutoSize = true;
            rbDropPlay.Location = new Point(3, 33);
            rbDropPlay.Name = "rbDropPlay";
            rbDropPlay.Padding = new Padding(6, 0, 0, 0);
            rbDropPlay.Size = new Size(98, 19);
            rbDropPlay.TabIndex = 1;
            rbDropPlay.TabStop = true;
            rbDropPlay.Text = "Play on drop";
            rbDropPlay.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 0, 0);
            label2.Size = new Size(482, 30);
            label2.TabIndex = 0;
            label2.Text = "Change behaviour when videofile or folder is dragged and dropped onto the player:";
            // 
            // panel2
            // 
            panel2.Controls.Add(cbAlwaysAddFilesToQueue);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 127);
            panel2.Name = "panel2";
            panel2.Size = new Size(482, 110);
            panel2.TabIndex = 3;
            // 
            // cbAlwaysAddFilesToQueue
            // 
            cbAlwaysAddFilesToQueue.AutoSize = true;
            cbAlwaysAddFilesToQueue.Location = new Point(3, 68);
            cbAlwaysAddFilesToQueue.Name = "cbAlwaysAddFilesToQueue";
            cbAlwaysAddFilesToQueue.Padding = new Padding(6, 0, 0, 0);
            cbAlwaysAddFilesToQueue.Size = new Size(303, 19);
            cbAlwaysAddFilesToQueue.TabIndex = 2;
            cbAlwaysAddFilesToQueue.Text = "Always add multiple dropped files directly to queue";
            cbAlwaysAddFilesToQueue.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 21);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 0, 0);
            label4.Size = new Size(482, 44);
            label4.TabIndex = 1;
            label4.Text = "This only affects \"Play on drop\" which would normally play the first file when multiple files are dropped on the player.";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 0, 0);
            label3.Size = new Size(482, 21);
            label3.TabIndex = 0;
            label3.Text = "Check to always add files to queue if multiple files dropped onto the player.";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbIncludeSubdirectories);
            panel3.Controls.Add(label6);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 237);
            panel3.Name = "panel3";
            panel3.Size = new Size(482, 62);
            panel3.TabIndex = 4;
            // 
            // cbIncludeSubdirectories
            // 
            cbIncludeSubdirectories.AutoSize = true;
            cbIncludeSubdirectories.Location = new Point(3, 29);
            cbIncludeSubdirectories.Name = "cbIncludeSubdirectories";
            cbIncludeSubdirectories.Padding = new Padding(6, 0, 0, 0);
            cbIncludeSubdirectories.Size = new Size(148, 19);
            cbIncludeSubdirectories.TabIndex = 2;
            cbIncludeSubdirectories.Text = "Include subdirectories";
            cbIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(6, 0, 0, 0);
            label6.Size = new Size(482, 26);
            label6.TabIndex = 0;
            label6.Text = "Choose to include found subdirectories when dropping folders:";
            // 
            // DragDropUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "DragDropUserControl";
            Size = new Size(482, 462);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private RadioButton rbDropPlay;
        private RadioButton rbDropQueue;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private CheckBox cbAlwaysAddFilesToQueue;
        private Panel panel3;
        private CheckBox cbIncludeSubdirectories;
        private Label label6;
    }
}
