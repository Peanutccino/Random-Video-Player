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
            tableLayoutMain = new TableLayoutPanel();
            lblHeader = new Label();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            rbDropPlay = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbDropQueue = new RandomVideoPlayer.Controls.CustomRadioButton();
            lbl1 = new Label();
            panel2 = new Panel();
            cbAlwaysAddFilesToQueue = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl3 = new Label();
            lbl2 = new Label();
            panel3 = new Panel();
            cbIncludeSubdirectories = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl4 = new Label();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.LightCoral;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 1);
            tableLayoutMain.Controls.Add(panel2, 0, 2);
            tableLayoutMain.Controls.Add(panel3, 0, 3);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.GhostWhite;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 6;
            lblHeader.Text = "Drag && Drop";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Bisque;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 113);
            panel1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(rbDropPlay);
            flowLayoutPanel1.Controls.Add(rbDropQueue);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(518, 36);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // rbDropPlay
            // 
            rbDropPlay.CircleSize = 12;
            rbDropPlay.HoverColor = Color.DeepSkyBlue;
            rbDropPlay.Location = new Point(3, 3);
            rbDropPlay.Name = "rbDropPlay";
            rbDropPlay.PaddingLeft = 6;
            rbDropPlay.Size = new Size(137, 19);
            rbDropPlay.TabIndex = 4;
            rbDropPlay.TabStop = true;
            rbDropPlay.Text = "Play on drop";
            rbDropPlay.UseVisualStyleBackColor = true;
            // 
            // rbDropQueue
            // 
            rbDropQueue.CircleSize = 12;
            rbDropQueue.HoverColor = Color.DeepSkyBlue;
            rbDropQueue.Location = new Point(146, 3);
            rbDropQueue.Name = "rbDropQueue";
            rbDropQueue.PaddingLeft = 6;
            rbDropQueue.Size = new Size(137, 19);
            rbDropQueue.TabIndex = 5;
            rbDropQueue.TabStop = true;
            rbDropQueue.Text = "Add to queue";
            rbDropQueue.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 30);
            lbl1.TabIndex = 1;
            lbl1.Text = "Change behaviour when videofile or folder is dragged and dropped onto the player:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LemonChiffon;
            panel2.Controls.Add(cbAlwaysAddFilesToQueue);
            panel2.Controls.Add(lbl3);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 182);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 113);
            panel2.TabIndex = 8;
            // 
            // cbAlwaysAddFilesToQueue
            // 
            cbAlwaysAddFilesToQueue.AutoSize = true;
            cbAlwaysAddFilesToQueue.BoxSize = 13;
            cbAlwaysAddFilesToQueue.Dock = DockStyle.Top;
            cbAlwaysAddFilesToQueue.HoverColor = Color.DeepSkyBlue;
            cbAlwaysAddFilesToQueue.Location = new Point(0, 62);
            cbAlwaysAddFilesToQueue.Name = "cbAlwaysAddFilesToQueue";
            cbAlwaysAddFilesToQueue.PaddingLeft = 12;
            cbAlwaysAddFilesToQueue.Size = new Size(518, 19);
            cbAlwaysAddFilesToQueue.TabIndex = 4;
            cbAlwaysAddFilesToQueue.Text = "Always add multiple dropped files directly to queue";
            cbAlwaysAddFilesToQueue.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl3.Location = new Point(0, 24);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 38);
            lbl3.TabIndex = 2;
            lbl3.Text = "This only affects \"Play on drop\" which would normally play the first file when multiple files are dropped on the player.";
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 1;
            lbl2.Text = "Check to always add files to queue if multiple files dropped onto the player.";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightCyan;
            panel3.Controls.Add(cbIncludeSubdirectories);
            panel3.Controls.Add(lbl4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 301);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 352);
            panel3.TabIndex = 9;
            // 
            // cbIncludeSubdirectories
            // 
            cbIncludeSubdirectories.AutoSize = true;
            cbIncludeSubdirectories.BoxSize = 13;
            cbIncludeSubdirectories.Dock = DockStyle.Top;
            cbIncludeSubdirectories.HoverColor = Color.DeepSkyBlue;
            cbIncludeSubdirectories.Location = new Point(0, 24);
            cbIncludeSubdirectories.Name = "cbIncludeSubdirectories";
            cbIncludeSubdirectories.PaddingLeft = 12;
            cbIncludeSubdirectories.Size = new Size(518, 19);
            cbIncludeSubdirectories.TabIndex = 4;
            cbIncludeSubdirectories.Text = "Include subdirectories";
            cbIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(518, 24);
            lbl4.TabIndex = 1;
            lbl4.Text = "Choose to include found subdirectories when dropping folders:";
            // 
            // DragDropUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "DragDropUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbl1;
        private Controls.CustomRadioButton rbDropPlay;
        private Controls.CustomRadioButton rbDropQueue;
        private Panel panel2;
        private Label lbl2;
        private Label lbl3;
        private Controls.CustomCheckBox cbAlwaysAddFilesToQueue;
        private Panel panel3;
        private Label lbl4;
        private Controls.CustomCheckBox cbIncludeSubdirectories;
    }
}
