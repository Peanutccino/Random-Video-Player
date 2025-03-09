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
            lblHeader = new Label();
            lvHotkeys = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnSave = new FontAwesome.Sharp.IconButton();
            lbl1 = new Label();
            btnRestore = new FontAwesome.Sharp.IconButton();
            lvFixedHotkeys = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            splitUI = new SplitContainer();
            panelBottom = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitUI).BeginInit();
            splitUI.Panel1.SuspendLayout();
            splitUI.Panel2.SuspendLayout();
            splitUI.SuspendLayout();
            panelBottom.SuspendLayout();
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
            lblHeader.Size = new Size(452, 52);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Inputs";
            // 
            // lvHotkeys
            // 
            lvHotkeys.BorderStyle = BorderStyle.None;
            lvHotkeys.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lvHotkeys.Dock = DockStyle.Fill;
            lvHotkeys.FullRowSelect = true;
            lvHotkeys.Location = new Point(0, 0);
            lvHotkeys.Name = "lvHotkeys";
            lvHotkeys.Size = new Size(452, 215);
            lvHotkeys.TabIndex = 1;
            lvHotkeys.UseCompatibleStateImageBehavior = false;
            lvHotkeys.View = System.Windows.Forms.View.Details;
            lvHotkeys.DoubleClick += listViewHotkeys_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Function";
            columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Shortcut";
            columnHeader2.Width = 180;
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
            btnSave.Location = new Point(306, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 27);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Shortcuts";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 52);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(452, 22);
            lbl1.TabIndex = 3;
            lbl1.Text = "Double click a function to change (Below are fixed shortcuts) ";
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
            btnRestore.Location = new Point(0, 4);
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
            lvFixedHotkeys.Size = new Size(452, 139);
            lvFixedHotkeys.TabIndex = 5;
            lvFixedHotkeys.UseCompatibleStateImageBehavior = false;
            lvFixedHotkeys.View = System.Windows.Forms.View.Details;
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
            // splitUI
            // 
            splitUI.Dock = DockStyle.Fill;
            splitUI.Location = new Point(0, 74);
            splitUI.Name = "splitUI";
            splitUI.Orientation = Orientation.Horizontal;
            // 
            // splitUI.Panel1
            // 
            splitUI.Panel1.Controls.Add(lvHotkeys);
            // 
            // splitUI.Panel2
            // 
            splitUI.Panel2.Controls.Add(lvFixedHotkeys);
            splitUI.Size = new Size(452, 358);
            splitUI.SplitterDistance = 215;
            splitUI.TabIndex = 6;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnRestore);
            panelBottom.Controls.Add(btnSave);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 432);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(452, 34);
            panelBottom.TabIndex = 7;
            // 
            // InputsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(splitUI);
            Controls.Add(lbl1);
            Controls.Add(lblHeader);
            Controls.Add(panelBottom);
            Name = "InputsUserControl";
            Size = new Size(452, 466);
            splitUI.Panel1.ResumeLayout(false);
            splitUI.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitUI).EndInit();
            splitUI.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private ListView lvHotkeys;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label lbl1;
        private FontAwesome.Sharp.IconButton btnRestore;
        private ListView lvFixedHotkeys;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private SplitContainer splitUI;
        private Panel panelBottom;
    }
}
