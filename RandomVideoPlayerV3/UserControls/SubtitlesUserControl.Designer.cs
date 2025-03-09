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
            lblHeader = new Label();
            panel1 = new Panel();
            cbEnableSubtitles = new Controls.CustomCheckBox();
            lbl1 = new Label();
            panel2 = new Panel();
            btnRestoreDefaultsFont = new Button();
            btnPickColor = new Button();
            lblFontColor = new Label();
            lblBorderSize = new Label();
            inputBorderSize = new Controls.CustomNumericUpDown();
            comboFontType = new Controls.ButtonComboBox();
            lblFontType = new Label();
            inputFontSize = new Controls.CustomNumericUpDown();
            lblFontSize = new Label();
            lbl2 = new Label();
            panel3 = new Panel();
            lblPreview = new Controls.CustomLabel();
            lbl3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(515, 55);
            lblHeader.TabIndex = 3;
            lblHeader.Text = "Subtitles";
            // 
            // panel1
            // 
            panel1.Controls.Add(cbEnableSubtitles);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 67);
            panel1.TabIndex = 4;
            // 
            // cbEnableSubtitles
            // 
            cbEnableSubtitles.AutoSize = true;
            cbEnableSubtitles.BoxSize = 13;
            cbEnableSubtitles.Dock = DockStyle.Top;
            cbEnableSubtitles.HoverColor = Color.DeepSkyBlue;
            cbEnableSubtitles.Location = new Point(0, 25);
            cbEnableSubtitles.Name = "cbEnableSubtitles";
            cbEnableSubtitles.PaddingLeft = 9;
            cbEnableSubtitles.Size = new Size(515, 19);
            cbEnableSubtitles.TabIndex = 2;
            cbEnableSubtitles.Text = "Enable subtitles";
            cbEnableSubtitles.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(515, 25);
            lbl1.TabIndex = 0;
            lbl1.Text = "Activate subtitles:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnRestoreDefaultsFont);
            panel2.Controls.Add(btnPickColor);
            panel2.Controls.Add(lblFontColor);
            panel2.Controls.Add(lblBorderSize);
            panel2.Controls.Add(inputBorderSize);
            panel2.Controls.Add(comboFontType);
            panel2.Controls.Add(lblFontType);
            panel2.Controls.Add(inputFontSize);
            panel2.Controls.Add(lblFontSize);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 122);
            panel2.Name = "panel2";
            panel2.Size = new Size(515, 125);
            panel2.TabIndex = 5;
            // 
            // btnRestoreDefaultsFont
            // 
            btnRestoreDefaultsFont.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestoreDefaultsFont.BackColor = Color.Lavender;
            btnRestoreDefaultsFont.FlatAppearance.BorderSize = 0;
            btnRestoreDefaultsFont.FlatStyle = FlatStyle.Flat;
            btnRestoreDefaultsFont.Location = new Point(392, 102);
            btnRestoreDefaultsFont.Name = "btnRestoreDefaultsFont";
            btnRestoreDefaultsFont.Size = new Size(120, 23);
            btnRestoreDefaultsFont.TabIndex = 9;
            btnRestoreDefaultsFont.Text = "Restore defaults";
            btnRestoreDefaultsFont.UseVisualStyleBackColor = false;
            btnRestoreDefaultsFont.Click += btnRestoreDefaultsFont_Click;
            // 
            // btnPickColor
            // 
            btnPickColor.FlatStyle = FlatStyle.Flat;
            btnPickColor.Location = new Point(361, 54);
            btnPickColor.Name = "btnPickColor";
            btnPickColor.Size = new Size(76, 30);
            btnPickColor.TabIndex = 8;
            btnPickColor.UseVisualStyleBackColor = true;
            btnPickColor.Click += btnPickColor_Click;
            // 
            // lblFontColor
            // 
            lblFontColor.Location = new Point(276, 54);
            lblFontColor.Name = "lblFontColor";
            lblFontColor.Padding = new Padding(6, 0, 0, 0);
            lblFontColor.Size = new Size(79, 30);
            lblFontColor.TabIndex = 7;
            lblFontColor.Text = "Font color:";
            lblFontColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBorderSize
            // 
            lblBorderSize.Location = new Point(276, 23);
            lblBorderSize.Name = "lblBorderSize";
            lblBorderSize.Padding = new Padding(6, 0, 0, 0);
            lblBorderSize.Size = new Size(79, 19);
            lblBorderSize.TabIndex = 6;
            lblBorderSize.Text = "Border size:";
            lblBorderSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputBorderSize
            // 
            inputBorderSize.Location = new Point(361, 23);
            inputBorderSize.Maximum = 20;
            inputBorderSize.Minimum = 1;
            inputBorderSize.Name = "inputBorderSize";
            inputBorderSize.Size = new Size(76, 19);
            inputBorderSize.TabIndex = 5;
            inputBorderSize.Text = "customNumericUpDown1";
            inputBorderSize.Value = 3;
            // 
            // comboFontType
            // 
            comboFontType.BackColor = Color.GhostWhite;
            comboFontType.DrawMode = DrawMode.OwnerDrawFixed;
            comboFontType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFontType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboFontType.FormattingEnabled = true;
            comboFontType.Location = new Point(88, 54);
            comboFontType.Name = "comboFontType";
            comboFontType.Size = new Size(140, 30);
            comboFontType.TabIndex = 4;
            // 
            // lblFontType
            // 
            lblFontType.Location = new Point(3, 54);
            lblFontType.Name = "lblFontType";
            lblFontType.Padding = new Padding(6, 0, 0, 0);
            lblFontType.Size = new Size(79, 30);
            lblFontType.TabIndex = 3;
            lblFontType.Text = "Font type:";
            lblFontType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputFontSize
            // 
            inputFontSize.Location = new Point(88, 23);
            inputFontSize.Maximum = 100;
            inputFontSize.Minimum = 0;
            inputFontSize.Name = "inputFontSize";
            inputFontSize.Size = new Size(76, 19);
            inputFontSize.TabIndex = 2;
            inputFontSize.Text = "customNumericUpDown1";
            inputFontSize.Value = 55;
            // 
            // lblFontSize
            // 
            lblFontSize.Location = new Point(3, 23);
            lblFontSize.Name = "lblFontSize";
            lblFontSize.Padding = new Padding(6, 0, 0, 0);
            lblFontSize.Size = new Size(79, 19);
            lblFontSize.TabIndex = 1;
            lblFontSize.Text = "Font size:";
            lblFontSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(515, 23);
            lbl2.TabIndex = 0;
            lbl2.Text = "Change subtitle appearance:";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblPreview);
            panel3.Controls.Add(lbl3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 247);
            panel3.Name = "panel3";
            panel3.Size = new Size(515, 289);
            panel3.TabIndex = 6;
            // 
            // lblPreview
            // 
            lblPreview.Dock = DockStyle.Fill;
            lblPreview.Font = new Font("Arial", 54.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblPreview.ForeColor = Color.White;
            lblPreview.Location = new Point(0, 25);
            lblPreview.Name = "lblPreview";
            lblPreview.OutlineColor = Color.Black;
            lblPreview.OutlineThickness = 4;
            lblPreview.Size = new Size(515, 264);
            lblPreview.TabIndex = 2;
            lblPreview.Text = "Lorem Ipsum";
            lblPreview.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 0, 0, 0);
            lbl3.Size = new Size(515, 25);
            lbl3.TabIndex = 0;
            lbl3.Text = "Preview (Indicative):";
            // 
            // SubtitlesUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblHeader);
            Name = "SubtitlesUserControl";
            Size = new Size(515, 536);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Panel panel2;
        private Label lbl2;
        private Controls.CustomNumericUpDown inputFontSize;
        private Label lblFontSize;
        private Controls.ButtonComboBox comboFontType;
        private Label lblFontType;
        private Panel panel3;
        private Label lbl3;
        private Controls.CustomLabel lblPreview;
        private Label lblBorderSize;
        private Controls.CustomNumericUpDown inputBorderSize;
        private Button btnPickColor;
        private Label lblFontColor;
        private Button btnRestoreDefaultsFont;
        private Controls.CustomCheckBox cbEnableSubtitles;
    }
}
