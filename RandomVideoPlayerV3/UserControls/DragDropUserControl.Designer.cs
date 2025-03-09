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
            lblHeader = new Label();
            panel1 = new Panel();
            rbDropQueue = new Controls.CustomRadioButton();
            rbDropPlay = new Controls.CustomRadioButton();
            lbl1 = new Label();
            panel2 = new Panel();
            cbAlwaysAddFilesToQueue = new Controls.CustomCheckBox();
            lbl3 = new Label();
            lbl2 = new Label();
            panel3 = new Panel();
            cbIncludeSubdirectories = new Controls.CustomCheckBox();
            lbl4 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.GhostWhite;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(482, 52);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Drag && Drop";
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 75);
            panel1.TabIndex = 2;
            // 
            // rbDropQueue
            // 
            rbDropQueue.CircleSize = 12;
            rbDropQueue.HoverColor = Color.DeepSkyBlue;
            rbDropQueue.Location = new Point(146, 3);
            rbDropQueue.Name = "rbDropQueue";
            rbDropQueue.PaddingLeft = 6;
            rbDropQueue.Size = new Size(137, 19);
            rbDropQueue.TabIndex = 4;
            rbDropQueue.TabStop = true;
            rbDropQueue.Text = "Add to queue";
            rbDropQueue.UseVisualStyleBackColor = true;
            // 
            // rbDropPlay
            // 
            rbDropPlay.CircleSize = 12;
            rbDropPlay.HoverColor = Color.DeepSkyBlue;
            rbDropPlay.Location = new Point(3, 3);
            rbDropPlay.Name = "rbDropPlay";
            rbDropPlay.PaddingLeft = 6;
            rbDropPlay.Size = new Size(137, 19);
            rbDropPlay.TabIndex = 3;
            rbDropPlay.TabStop = true;
            rbDropPlay.Text = "Play on drop";
            rbDropPlay.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(482, 30);
            lbl1.TabIndex = 0;
            lbl1.Text = "Change behaviour when videofile or folder is dragged and dropped onto the player:";
            // 
            // panel2
            // 
            panel2.Controls.Add(cbAlwaysAddFilesToQueue);
            panel2.Controls.Add(lbl3);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 127);
            panel2.Name = "panel2";
            panel2.Size = new Size(482, 110);
            panel2.TabIndex = 3;
            // 
            // cbAlwaysAddFilesToQueue
            // 
            cbAlwaysAddFilesToQueue.AutoSize = true;
            cbAlwaysAddFilesToQueue.BoxSize = 13;
            cbAlwaysAddFilesToQueue.Dock = DockStyle.Top;
            cbAlwaysAddFilesToQueue.HoverColor = Color.DeepSkyBlue;
            cbAlwaysAddFilesToQueue.Location = new Point(0, 65);
            cbAlwaysAddFilesToQueue.Name = "cbAlwaysAddFilesToQueue";
            cbAlwaysAddFilesToQueue.PaddingLeft = 6;
            cbAlwaysAddFilesToQueue.Size = new Size(482, 19);
            cbAlwaysAddFilesToQueue.TabIndex = 3;
            cbAlwaysAddFilesToQueue.Text = "Always add multiple dropped files directly to queue";
            cbAlwaysAddFilesToQueue.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.Location = new Point(0, 21);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 0, 0, 0);
            lbl3.Size = new Size(482, 44);
            lbl3.TabIndex = 1;
            lbl3.Text = "This only affects \"Play on drop\" which would normally play the first file when multiple files are dropped on the player.";
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(482, 21);
            lbl2.TabIndex = 0;
            lbl2.Text = "Check to always add files to queue if multiple files dropped onto the player.";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbIncludeSubdirectories);
            panel3.Controls.Add(lbl4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 237);
            panel3.Name = "panel3";
            panel3.Size = new Size(482, 62);
            panel3.TabIndex = 4;
            // 
            // cbIncludeSubdirectories
            // 
            cbIncludeSubdirectories.AutoSize = true;
            cbIncludeSubdirectories.BoxSize = 13;
            cbIncludeSubdirectories.Dock = DockStyle.Top;
            cbIncludeSubdirectories.HoverColor = Color.DeepSkyBlue;
            cbIncludeSubdirectories.Location = new Point(0, 26);
            cbIncludeSubdirectories.Name = "cbIncludeSubdirectories";
            cbIncludeSubdirectories.PaddingLeft = 6;
            cbIncludeSubdirectories.Size = new Size(482, 19);
            cbIncludeSubdirectories.TabIndex = 3;
            cbIncludeSubdirectories.Text = "Include subdirectories";
            cbIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Padding = new Padding(6, 0, 0, 0);
            lbl4.Size = new Size(482, 26);
            lbl4.TabIndex = 0;
            lbl4.Text = "Choose to include found subdirectories when dropping folders:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(rbDropPlay);
            flowLayoutPanel1.Controls.Add(rbDropQueue);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(482, 45);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // DragDropUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblHeader);
            Name = "DragDropUserControl";
            Size = new Size(482, 462);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Panel panel2;
        private Label lbl3;
        private Label lbl2;
        private Panel panel3;
        private Label lbl4;
        private Controls.CustomRadioButton rbDropPlay;
        private Controls.CustomRadioButton rbDropQueue;
        private Controls.CustomCheckBox cbAlwaysAddFilesToQueue;
        private Controls.CustomCheckBox cbIncludeSubdirectories;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
