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
            label1 = new Label();
            listViewHotkeys = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnSave = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            btnRestore = new FontAwesome.Sharp.IconButton();
            lvFixedHotkeys = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            label1.Size = new Size(452, 52);
            label1.TabIndex = 0;
            label1.Text = "Inputs";
            // 
            // listViewHotkeys
            // 
            listViewHotkeys.BorderStyle = BorderStyle.None;
            listViewHotkeys.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewHotkeys.Dock = DockStyle.Fill;
            listViewHotkeys.FullRowSelect = true;
            listViewHotkeys.Location = new Point(0, 0);
            listViewHotkeys.Name = "listViewHotkeys";
            listViewHotkeys.Size = new Size(452, 215);
            listViewHotkeys.TabIndex = 1;
            listViewHotkeys.UseCompatibleStateImageBehavior = false;
            listViewHotkeys.View = System.Windows.Forms.View.Details;
            listViewHotkeys.DoubleClick += listViewHotkeys_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Function";
            columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Shortcut";
            columnHeader2.Width = 200;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(230, 230, 255);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(303, 436);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 27);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Shortcuts";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 52);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 0, 0);
            label2.Size = new Size(452, 22);
            label2.TabIndex = 3;
            label2.Text = "Double click a function to change (Below are fixed shortcuts) ";
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRestore.BackColor = Color.FromArgb(230, 230, 255);
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRestore.IconColor = Color.Black;
            btnRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestore.Location = new Point(3, 436);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(146, 27);
            btnRestore.TabIndex = 4;
            btnRestore.Text = "Restore Defaults";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // lvFixedHotkeys
            // 
            lvFixedHotkeys.BorderStyle = BorderStyle.None;
            lvFixedHotkeys.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            lvFixedHotkeys.Dock = DockStyle.Fill;
            lvFixedHotkeys.Enabled = false;
            lvFixedHotkeys.HeaderStyle = ColumnHeaderStyle.None;
            lvFixedHotkeys.Location = new Point(0, 0);
            lvFixedHotkeys.Name = "lvFixedHotkeys";
            lvFixedHotkeys.Size = new Size(452, 137);
            lvFixedHotkeys.TabIndex = 5;
            lvFixedHotkeys.UseCompatibleStateImageBehavior = false;
            lvFixedHotkeys.View = System.Windows.Forms.View.Details;
            lvFixedHotkeys.SelectedIndexChanged += lvFixedHotkeys_SelectedIndexChanged;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Function";
            columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Shortcut";
            columnHeader4.Width = 200;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 74);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listViewHotkeys);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lvFixedHotkeys);
            splitContainer1.Size = new Size(452, 356);
            splitContainer1.SplitterDistance = 215;
            splitContainer1.TabIndex = 6;
            // 
            // InputsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(splitContainer1);
            Controls.Add(btnRestore);
            Controls.Add(label2);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Name = "InputsUserControl";
            Size = new Size(452, 466);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ListView listViewHotkeys;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnRestore;
        private ListView lvFixedHotkeys;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private SplitContainer splitContainer1;
    }
}
