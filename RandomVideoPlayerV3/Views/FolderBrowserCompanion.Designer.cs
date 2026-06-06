namespace RandomVideoPlayer.Views
{
    partial class FolderBrowserCompanion
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableBackground = new TableLayoutPanel();
            flowFolderList = new FlowLayoutPanel();
            btnDeleteAll = new RandomVideoPlayer.Controls.RoundedButton();
            tableBackground.SuspendLayout();
            SuspendLayout();
            // 
            // tableBackground
            // 
            tableBackground.BackColor = Color.PaleGreen;
            tableBackground.ColumnCount = 1;
            tableBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableBackground.Controls.Add(btnDeleteAll, 0, 1);
            tableBackground.Controls.Add(flowFolderList, 0, 0);
            tableBackground.Dock = DockStyle.Fill;
            tableBackground.Location = new Point(0, 0);
            tableBackground.Name = "tableBackground";
            tableBackground.RowCount = 2;
            tableBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableBackground.RowStyles.Add(new RowStyle());
            tableBackground.Size = new Size(270, 635);
            tableBackground.TabIndex = 0;
            // 
            // flowFolderList
            // 
            flowFolderList.AutoScroll = true;
            flowFolderList.BackColor = Color.Yellow;
            flowFolderList.Dock = DockStyle.Fill;
            flowFolderList.FlowDirection = FlowDirection.TopDown;
            flowFolderList.Location = new Point(2, 2);
            flowFolderList.Margin = new Padding(2, 2, 2, 0);
            flowFolderList.Name = "flowFolderList";
            flowFolderList.Padding = new Padding(15, 10, 0, 10);
            flowFolderList.Size = new Size(266, 599);
            flowFolderList.TabIndex = 1;
            flowFolderList.WrapContents = false;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.BackColor = Color.OrangeRed;
            btnDeleteAll.BackgroundColor = Color.PaleGreen;
            btnDeleteAll.BorderColor = Color.PaleVioletRed;
            btnDeleteAll.BorderRadius = 0;
            btnDeleteAll.BorderSize = 0;
            btnDeleteAll.Dock = DockStyle.Fill;
            btnDeleteAll.DynamicRadius = false;
            btnDeleteAll.FlatAppearance.BorderSize = 0;
            btnDeleteAll.FlatStyle = FlatStyle.Flat;
            btnDeleteAll.ForeColor = Color.White;
            btnDeleteAll.ImageAlign = ContentAlignment.MiddleRight;
            btnDeleteAll.Location = new Point(2, 601);
            btnDeleteAll.Margin = new Padding(2, 0, 2, 2);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Padding = new Padding(26, 0, 26, 0);
            btnDeleteAll.Size = new Size(266, 32);
            btnDeleteAll.TabIndex = 0;
            btnDeleteAll.Text = "Remove all folders";
            btnDeleteAll.TextAlign = ContentAlignment.MiddleLeft;
            btnDeleteAll.TextColor = Color.White;
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // FolderBrowserCompanion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(270, 635);
            Controls.Add(tableBackground);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FolderBrowserCompanion";
            Text = "FolderBrowserCompanion";
            tableBackground.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableBackground;
        private FlowLayoutPanel flowFolderList;
        private Controls.RoundedButton btnDeleteAll;
    }
}