namespace RandomVideoPlayer.UserControls
{
    partial class SubtitlesUserControl
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
            btnRestoreDefaultsFont = new Button();
            lblPreview = new RandomVideoPlayer.Controls.CustomLabel();
            lbl3 = new Label();
            lblHeader = new Label();
            panel1 = new Panel();
            cbEnableSubtitles = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl1 = new Label();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnPickColor = new Button();
            lblFontColor = new Label();
            comboFontType = new RandomVideoPlayer.Controls.ButtonComboBox();
            lblFontType = new Label();
            inputBorderSize = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            lblBorderSize = new Label();
            inputFontSize = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            lblFontSize = new Label();
            lbl2 = new Label();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.MistyRose;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(btnRestoreDefaultsFont, 0, 5);
            tableLayoutMain.Controls.Add(lblPreview, 0, 4);
            tableLayoutMain.Controls.Add(lbl3, 0, 3);
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 1);
            tableLayoutMain.Controls.Add(panel2, 0, 2);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 6;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // btnRestoreDefaultsFont
            // 
            btnRestoreDefaultsFont.BackColor = Color.Lavender;
            btnRestoreDefaultsFont.Dock = DockStyle.Right;
            btnRestoreDefaultsFont.FlatAppearance.BorderSize = 0;
            btnRestoreDefaultsFont.FlatStyle = FlatStyle.Flat;
            btnRestoreDefaultsFont.Location = new Point(401, 628);
            btnRestoreDefaultsFont.Name = "btnRestoreDefaultsFont";
            btnRestoreDefaultsFont.Size = new Size(120, 25);
            btnRestoreDefaultsFont.TabIndex = 13;
            btnRestoreDefaultsFont.Text = "Restore defaults";
            btnRestoreDefaultsFont.UseVisualStyleBackColor = false;
            btnRestoreDefaultsFont.Click += btnRestoreDefaultsFont_Click;
            // 
            // lblPreview
            // 
            lblPreview.Dock = DockStyle.Fill;
            lblPreview.Font = new Font("Arial", 54.75F);
            lblPreview.ForeColor = Color.White;
            lblPreview.Location = new Point(3, 252);
            lblPreview.Name = "lblPreview";
            lblPreview.OutlineColor = Color.Black;
            lblPreview.OutlineThickness = 4;
            lblPreview.Size = new Size(518, 373);
            lblPreview.TabIndex = 12;
            lblPreview.Text = "Lorem Ipsum";
            lblPreview.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl3.Location = new Point(3, 228);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 24);
            lbl3.TabIndex = 11;
            lbl3.Text = "Preview (Indicative):";
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 8;
            lblHeader.Text = "Subtitles";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSalmon;
            panel1.Controls.Add(cbEnableSubtitles);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 60);
            panel1.TabIndex = 9;
            // 
            // cbEnableSubtitles
            // 
            cbEnableSubtitles.AutoSize = true;
            cbEnableSubtitles.BoxSize = 13;
            cbEnableSubtitles.Dock = DockStyle.Top;
            cbEnableSubtitles.HoverColor = Color.DeepSkyBlue;
            cbEnableSubtitles.Location = new Point(0, 24);
            cbEnableSubtitles.Name = "cbEnableSubtitles";
            cbEnableSubtitles.PaddingLeft = 12;
            cbEnableSubtitles.Size = new Size(518, 19);
            cbEnableSubtitles.TabIndex = 3;
            cbEnableSubtitles.Text = "Enable subtitles";
            cbEnableSubtitles.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 24);
            lbl1.TabIndex = 1;
            lbl1.Text = "Activate subtitles:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Khaki;
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 129);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 96);
            panel2.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Goldenrod;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.36364F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.636364F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.363636F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.636364F));
            tableLayoutPanel2.Controls.Add(btnPickColor, 3, 1);
            tableLayoutPanel2.Controls.Add(lblFontColor, 2, 1);
            tableLayoutPanel2.Controls.Add(comboFontType, 1, 1);
            tableLayoutPanel2.Controls.Add(lblFontType, 0, 1);
            tableLayoutPanel2.Controls.Add(inputBorderSize, 3, 0);
            tableLayoutPanel2.Controls.Add(lblBorderSize, 2, 0);
            tableLayoutPanel2.Controls.Add(inputFontSize, 1, 0);
            tableLayoutPanel2.Controls.Add(lblFontSize, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 24);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(518, 72);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // btnPickColor
            // 
            btnPickColor.Dock = DockStyle.Left;
            btnPickColor.FlatStyle = FlatStyle.Flat;
            btnPickColor.Location = new Point(345, 39);
            btnPickColor.Name = "btnPickColor";
            btnPickColor.Size = new Size(76, 30);
            btnPickColor.TabIndex = 12;
            btnPickColor.UseVisualStyleBackColor = true;
            btnPickColor.Click += btnPickColor_Click;
            // 
            // lblFontColor
            // 
            lblFontColor.Dock = DockStyle.Fill;
            lblFontColor.Location = new Point(261, 39);
            lblFontColor.Margin = new Padding(3);
            lblFontColor.Name = "lblFontColor";
            lblFontColor.Padding = new Padding(6, 0, 0, 0);
            lblFontColor.Size = new Size(78, 30);
            lblFontColor.TabIndex = 11;
            lblFontColor.Text = "Font color:";
            lblFontColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboFontType
            // 
            comboFontType.BackColor = Color.GhostWhite;
            comboFontType.Dock = DockStyle.Left;
            comboFontType.DrawMode = DrawMode.OwnerDrawFixed;
            comboFontType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFontType.Font = new Font("Segoe UI", 12F);
            comboFontType.FormattingEnabled = true;
            comboFontType.Location = new Point(87, 39);
            comboFontType.Name = "comboFontType";
            comboFontType.Size = new Size(140, 30);
            comboFontType.TabIndex = 10;
            // 
            // lblFontType
            // 
            lblFontType.Dock = DockStyle.Fill;
            lblFontType.Location = new Point(3, 39);
            lblFontType.Margin = new Padding(3);
            lblFontType.Name = "lblFontType";
            lblFontType.Size = new Size(78, 30);
            lblFontType.TabIndex = 9;
            lblFontType.Text = "Font type:";
            lblFontType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputBorderSize
            // 
            inputBorderSize.BackColor = SystemColors.Window;
            inputBorderSize.Dock = DockStyle.Left;
            inputBorderSize.ForeColor = SystemColors.WindowText;
            inputBorderSize.IconColor = Color.Indigo;
            inputBorderSize.Location = new Point(345, 8);
            inputBorderSize.Margin = new Padding(3, 8, 3, 8);
            inputBorderSize.Maximum = 20;
            inputBorderSize.Minimum = 1;
            inputBorderSize.Name = "inputBorderSize";
            inputBorderSize.Size = new Size(76, 20);
            inputBorderSize.TabIndex = 8;
            inputBorderSize.Text = "customNumericUpDown1";
            inputBorderSize.Value = 3;
            // 
            // lblBorderSize
            // 
            lblBorderSize.Dock = DockStyle.Fill;
            lblBorderSize.Location = new Point(261, 3);
            lblBorderSize.Margin = new Padding(3);
            lblBorderSize.Name = "lblBorderSize";
            lblBorderSize.Padding = new Padding(6, 0, 0, 0);
            lblBorderSize.Size = new Size(78, 30);
            lblBorderSize.TabIndex = 7;
            lblBorderSize.Text = "Border size:";
            lblBorderSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputFontSize
            // 
            inputFontSize.BackColor = SystemColors.Window;
            inputFontSize.Dock = DockStyle.Left;
            inputFontSize.ForeColor = SystemColors.WindowText;
            inputFontSize.IconColor = Color.Indigo;
            inputFontSize.Location = new Point(87, 8);
            inputFontSize.Margin = new Padding(3, 8, 3, 8);
            inputFontSize.Maximum = 100;
            inputFontSize.Minimum = 0;
            inputFontSize.Name = "inputFontSize";
            inputFontSize.Size = new Size(76, 20);
            inputFontSize.TabIndex = 3;
            inputFontSize.Text = "customNumericUpDown1";
            inputFontSize.Value = 55;
            // 
            // lblFontSize
            // 
            lblFontSize.Dock = DockStyle.Fill;
            lblFontSize.Location = new Point(3, 3);
            lblFontSize.Margin = new Padding(3);
            lblFontSize.Name = "lblFontSize";
            lblFontSize.Size = new Size(78, 30);
            lblFontSize.TabIndex = 2;
            lblFontSize.Text = "Font size:";
            lblFontSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 1;
            lbl2.Text = "Change subtitle appearance:";
            // 
            // SubtitlesUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "SubtitlesUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Controls.CustomCheckBox cbEnableSubtitles;
        private Panel panel2;
        private Label lbl2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblFontSize;
        private Controls.CustomNumericUpDown inputFontSize;
        private Label lblBorderSize;
        private Controls.CustomNumericUpDown inputBorderSize;
        private Label lblFontType;
        private Controls.ButtonComboBox comboFontType;
        private Label lblFontColor;
        private Button btnPickColor;
        private Label lbl3;
        private Controls.CustomLabel lblPreview;
        private Button btnRestoreDefaultsFont;
    }
}
