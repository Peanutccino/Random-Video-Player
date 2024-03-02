namespace RandomVideoPlayer.View
{
    partial class ShortcutsView
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
            panelTop = new Panel();
            btnClose = new FontAwesome.Sharp.IconButton();
            lblTitle = new Label();
            panelBody = new Panel();
            lvShortcuts = new ListView();
            cH1 = new ColumnHeader();
            cH2 = new ColumnHeader();
            panelTop.SuspendLayout();
            panelBody.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(128, 0, 255);
            panelTop.Controls.Add(btnClose);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(434, 40);
            panelTop.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            btnClose.IconColor = Color.AliceBlue;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 20;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(404, 7);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(25, 25);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = SystemColors.ButtonHighlight;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(398, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "RVP | Shortcut list";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.MouseDown += lblTitle_MouseDown;
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.Lavender;
            panelBody.Controls.Add(lvShortcuts);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 40);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(434, 371);
            panelBody.TabIndex = 1;
            // 
            // lvShortcuts
            // 
            lvShortcuts.BackColor = Color.AliceBlue;
            lvShortcuts.Columns.AddRange(new ColumnHeader[] { cH1, cH2 });
            lvShortcuts.Dock = DockStyle.Fill;
            lvShortcuts.FullRowSelect = true;
            lvShortcuts.GridLines = true;
            lvShortcuts.Location = new Point(0, 0);
            lvShortcuts.Name = "lvShortcuts";
            lvShortcuts.Size = new Size(434, 371);
            lvShortcuts.TabIndex = 0;
            lvShortcuts.UseCompatibleStateImageBehavior = false;
            lvShortcuts.View = System.Windows.Forms.View.Details;
            // 
            // cH1
            // 
            cH1.Text = "Key";
            cH1.Width = 220;
            // 
            // cH2
            // 
            cH2.Text = "Function";
            cH2.Width = 200;
            // 
            // ShortcutsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 411);
            Controls.Add(panelBody);
            Controls.Add(panelTop);
            MaximumSize = new Size(450, 450);
            MinimumSize = new Size(450, 450);
            Name = "ShortcutsView";
            Text = "ShortcutsView";
            Load += ShortcutsView_Load;
            Resize += ShortcutsView_Resize;
            panelTop.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Panel panelBody;
        private ListView lvShortcuts;
        private ColumnHeader cH1;
        private ColumnHeader cH2;
        private Label lblTitle;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}