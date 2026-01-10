namespace RandomVideoPlayer.Views
{
    partial class SaveListView
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
            lblTitle = new Label();
            lvListSelect = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnSaveList = new FontAwesome.Sharp.IconButton();
            btnCancel = new FontAwesome.Sharp.IconButton();
            panelBottom = new Panel();
            btnDelete = new FontAwesome.Sharp.IconButton();
            tbListName = new TextBox();
            panelTop = new Panel();
            lblEntries = new Label();
            lblFiles = new Label();
            toolTipInfo = new ToolTip(components);
            panelBottom.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Honeydew;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkOliveGreen;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(359, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Save List";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.MouseDown += lblTitle_MouseDown;
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
            lvListSelect.Size = new Size(359, 236);
            lvListSelect.TabIndex = 1;
            lvListSelect.UseCompatibleStateImageBehavior = false;
            lvListSelect.View = System.Windows.Forms.View.Details;
            lvListSelect.ItemSelectionChanged += lvListSelect_ItemSelectionChanged;
            lvListSelect.DoubleClick += lvListSelect_DoubleClick;
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
            // btnSaveList
            // 
            btnSaveList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveList.FlatAppearance.BorderSize = 0;
            btnSaveList.FlatStyle = FlatStyle.Flat;
            btnSaveList.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSaveList.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSaveList.IconColor = Color.Black;
            btnSaveList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveList.Location = new Point(3, 35);
            btnSaveList.Name = "btnSaveList";
            btnSaveList.Size = new Size(140, 37);
            btnSaveList.TabIndex = 2;
            btnSaveList.Text = "Save list";
            btnSaveList.UseVisualStyleBackColor = true;
            btnSaveList.Click += btnSaveList_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.Location = new Point(216, 35);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 37);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.Honeydew;
            panelBottom.Controls.Add(btnDelete);
            panelBottom.Controls.Add(tbListName);
            panelBottom.Controls.Add(btnSaveList);
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 306);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(359, 75);
            panelBottom.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashCan;
            btnDelete.IconColor = Color.Black;
            btnDelete.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnDelete.IconSize = 26;
            btnDelete.Location = new Point(164, 35);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(30, 37);
            btnDelete.TabIndex = 5;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbListName
            // 
            tbListName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbListName.BackColor = Color.MintCream;
            tbListName.BorderStyle = BorderStyle.FixedSingle;
            tbListName.Location = new Point(3, 6);
            tbListName.Name = "tbListName";
            tbListName.PlaceholderText = "Enter a name for your list";
            tbListName.Size = new Size(353, 23);
            tbListName.TabIndex = 4;
            tbListName.TextChanged += tbListName_TextChanged;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Honeydew;
            panelTop.Controls.Add(lblEntries);
            panelTop.Controls.Add(lblFiles);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(359, 70);
            panelTop.TabIndex = 5;
            // 
            // lblEntries
            // 
            lblEntries.Anchor = AnchorStyles.Right;
            lblEntries.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblEntries.Location = new Point(285, 40);
            lblEntries.Name = "lblEntries";
            lblEntries.Size = new Size(69, 30);
            lblEntries.TabIndex = 2;
            lblEntries.Text = "Entries";
            lblEntries.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFiles
            // 
            lblFiles.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblFiles.Location = new Point(2, 40);
            lblFiles.Name = "lblFiles";
            lblFiles.Size = new Size(97, 30);
            lblFiles.TabIndex = 1;
            lblFiles.Text = "Files";
            lblFiles.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SaveListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 381);
            Controls.Add(lvListSelect);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            KeyPreview = true;
            MinimumSize = new Size(375, 420);
            Name = "SaveListView";
            Text = "SaveListView";
            Load += SaveListView_Load;
            KeyDown += SaveListView_KeyDown;
            Resize += SaveListView_Resize;
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private ListView lvListSelect;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private FontAwesome.Sharp.IconButton btnSaveList;
        private FontAwesome.Sharp.IconButton btnCancel;
        private Panel panelBottom;
        private TextBox tbListName;
        private Panel panelTop;
        private Label lblEntries;
        private Label lblFiles;
        private ToolTip toolTipInfo;
        private FontAwesome.Sharp.IconButton btnDelete;
    }
}