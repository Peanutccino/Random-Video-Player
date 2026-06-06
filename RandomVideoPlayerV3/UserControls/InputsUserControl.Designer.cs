namespace RandomVideoPlayer.UserControls
{
    partial class InputsUserControl
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
            lbl1 = new Label();
            lblHeader = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnRestore = new FontAwesome.Sharp.IconButton();
            splitContainerInput = new SplitContainer();
            lvHotkeys = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            lvFixedHotkeys = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            tableLayoutMain.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerInput).BeginInit();
            splitContainerInput.Panel1.SuspendLayout();
            splitContainerInput.Panel2.SuspendLayout();
            splitContainerInput.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.Thistle;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lbl1, 0, 1);
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutMain.Controls.Add(splitContainerInput, 0, 2);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Fill;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(3, 60);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(518, 24);
            lbl1.TabIndex = 10;
            lbl1.Text = "Double click a function to change (Below are fixed shortcuts) ";
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 9;
            lblHeader.Text = "Inputs";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnSave, 1, 0);
            tableLayoutPanel2.Controls.Add(btnRestore, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 623);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(518, 30);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(230, 230, 255);
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(369, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 24);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save Shortcuts";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.FromArgb(230, 230, 255);
            btnRestore.Dock = DockStyle.Left;
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRestore.IconColor = Color.Black;
            btnRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestore.Location = new Point(3, 3);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(146, 24);
            btnRestore.TabIndex = 5;
            btnRestore.Text = "Restore Defaults";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // splitContainerInput
            // 
            splitContainerInput.Dock = DockStyle.Fill;
            splitContainerInput.Location = new Point(3, 87);
            splitContainerInput.Name = "splitContainerInput";
            splitContainerInput.Orientation = Orientation.Horizontal;
            // 
            // splitContainerInput.Panel1
            // 
            splitContainerInput.Panel1.Controls.Add(lvHotkeys);
            // 
            // splitContainerInput.Panel2
            // 
            splitContainerInput.Panel2.Controls.Add(lvFixedHotkeys);
            splitContainerInput.Size = new Size(518, 530);
            splitContainerInput.SplitterDistance = 338;
            splitContainerInput.TabIndex = 14;
            // 
            // lvHotkeys
            // 
            lvHotkeys.BorderStyle = BorderStyle.None;
            lvHotkeys.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lvHotkeys.Dock = DockStyle.Fill;
            lvHotkeys.FullRowSelect = true;
            lvHotkeys.Location = new Point(0, 0);
            lvHotkeys.Name = "lvHotkeys";
            lvHotkeys.Size = new Size(518, 338);
            lvHotkeys.TabIndex = 2;
            lvHotkeys.UseCompatibleStateImageBehavior = false;
            lvHotkeys.View = View.Details;
            lvHotkeys.DoubleClick += listViewHotkeys_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Function";
            columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Shortcut";
            columnHeader2.Width = 210;
            // 
            // lvFixedHotkeys
            // 
            lvFixedHotkeys.BorderStyle = BorderStyle.None;
            lvFixedHotkeys.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            lvFixedHotkeys.Dock = DockStyle.Fill;
            lvFixedHotkeys.HeaderStyle = ColumnHeaderStyle.None;
            lvFixedHotkeys.Location = new Point(0, 0);
            lvFixedHotkeys.Name = "lvFixedHotkeys";
            lvFixedHotkeys.Size = new Size(518, 188);
            lvFixedHotkeys.TabIndex = 6;
            lvFixedHotkeys.UseCompatibleStateImageBehavior = false;
            lvFixedHotkeys.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Function";
            columnHeader3.Width = 240;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Shortcut";
            columnHeader4.Width = 180;
            // 
            // InputsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(tableLayoutMain);
            Name = "InputsUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            splitContainerInput.Panel1.ResumeLayout(false);
            splitContainerInput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerInput).EndInit();
            splitContainerInput.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Label lbl1;
        private TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnRestore;
        private FontAwesome.Sharp.IconButton btnSave;
        private SplitContainer splitContainerInput;
        private ListView lvHotkeys;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView lvFixedHotkeys;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}
