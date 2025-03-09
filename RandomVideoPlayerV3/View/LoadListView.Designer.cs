namespace RandomVideoPlayer.View
{
    partial class LoadListView
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
            components = new System.ComponentModel.Container();
            lvListSelect = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            lblTitle = new Label();
            btnLoadList = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            panelTop = new Panel();
            lblFiles = new Label();
            lblEntries = new Label();
            panelBottom = new Panel();
            btnDelete = new FontAwesome.Sharp.IconButton();
            toolTipInfo = new ToolTip(components);
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // lvListSelect
            // 
            lvListSelect.BackColor = Color.MintCream;
            lvListSelect.BorderStyle = BorderStyle.None;
            lvListSelect.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lvListSelect.Dock = DockStyle.Fill;
            lvListSelect.FullRowSelect = true;
            lvListSelect.HeaderStyle = ColumnHeaderStyle.None;
            lvListSelect.Location = new Point(0, 70);
            lvListSelect.Name = "lvListSelect";
            lvListSelect.Size = new Size(359, 261);
            lvListSelect.TabIndex = 0;
            lvListSelect.UseCompatibleStateImageBehavior = false;
            lvListSelect.View = System.Windows.Forms.View.Details;
            lvListSelect.MouseDoubleClick += lvListSelect_MouseDoubleClick;
            lvListSelect.Resize += lvListSelect_Resize;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "File";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Entries";
            columnHeader2.Width = 55;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.DarkOliveGreen;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(359, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Load List";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseDown += lblTitle_MouseDown;
            // 
            // btnLoadList
            // 
            btnLoadList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLoadList.FlatAppearance.BorderSize = 0;
            btnLoadList.FlatStyle = FlatStyle.Flat;
            btnLoadList.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadList.IconChar = FontAwesome.Sharp.IconChar.None;
            btnLoadList.IconColor = Color.Black;
            btnLoadList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLoadList.Location = new Point(3, 10);
            btnLoadList.Name = "btnLoadList";
            btnLoadList.Size = new Size(140, 37);
            btnLoadList.TabIndex = 2;
            btnLoadList.Text = "Load List";
            btnLoadList.UseVisualStyleBackColor = true;
            btnLoadList.Click += btnLoadList_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.Location = new Point(216, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 37);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Honeydew;
            panelTop.Controls.Add(lblFiles);
            panelTop.Controls.Add(lblEntries);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(359, 70);
            panelTop.TabIndex = 4;
            // 
            // lblFiles
            // 
            lblFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFiles.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblFiles.Location = new Point(0, 40);
            lblFiles.Name = "lblFiles";
            lblFiles.Size = new Size(69, 30);
            lblFiles.TabIndex = 3;
            lblFiles.Text = "Files";
            lblFiles.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEntries
            // 
            lblEntries.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblEntries.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblEntries.Location = new Point(285, 40);
            lblEntries.Name = "lblEntries";
            lblEntries.Size = new Size(69, 30);
            lblEntries.TabIndex = 2;
            lblEntries.Text = "Entries";
            lblEntries.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.Honeydew;
            panelBottom.Controls.Add(btnDelete);
            panelBottom.Controls.Add(btnLoadList);
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 331);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(359, 50);
            panelBottom.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnDelete.IconColor = Color.Black;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnDelete.IconSize = 26;
            btnDelete.Location = new Point(164, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(30, 37);
            btnDelete.TabIndex = 4;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // LoadListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 381);
            Controls.Add(lvListSelect);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            KeyPreview = true;
            MinimumSize = new Size(375, 420);
            Name = "LoadListView";
            Text = "LoadListView";
            Load += LoadListView_Load;
            KeyDown += LoadListView_KeyDown;
            Resize += LoadListView_Resize;
            panelTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView lvListSelect;
        private Label lblTitle;
        private FontAwesome.Sharp.IconButton btnLoadList;
        private FontAwesome.Sharp.IconButton btnCancel;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Panel panelTop;
        private Panel panelBottom;
        private Label lblEntries;
        private Label lblFiles;
        private ToolTip toolTipInfo;
        private FontAwesome.Sharp.IconButton btnDelete;
    }
}