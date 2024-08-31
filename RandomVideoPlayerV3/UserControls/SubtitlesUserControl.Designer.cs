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
            label1 = new Label();
            panel1 = new Panel();
            cbEnableSubtitles = new CheckBox();
            label2 = new Label();
            panel2 = new Panel();
            btnPickColor = new Button();
            label8 = new Label();
            label7 = new Label();
            inputBorderSize = new Controls.CustomNumericUpDown();
            comboFontType = new Controls.ButtonComboBox();
            label5 = new Label();
            inputFontSize = new Controls.CustomNumericUpDown();
            label4 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblPreview = new Controls.CustomLabel();
            label6 = new Label();
            btnRestoreDefaultsFont = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 8);
            label1.Size = new Size(515, 55);
            label1.TabIndex = 3;
            label1.Text = "Subtitles";
            // 
            // panel1
            // 
            panel1.Controls.Add(cbEnableSubtitles);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 67);
            panel1.TabIndex = 4;
            // 
            // cbEnableSubtitles
            // 
            cbEnableSubtitles.AutoSize = true;
            cbEnableSubtitles.Location = new Point(3, 28);
            cbEnableSubtitles.Name = "cbEnableSubtitles";
            cbEnableSubtitles.Padding = new Padding(6, 0, 0, 0);
            cbEnableSubtitles.Size = new Size(114, 19);
            cbEnableSubtitles.TabIndex = 1;
            cbEnableSubtitles.Text = "Enable subtitles";
            cbEnableSubtitles.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 0, 0);
            label2.Size = new Size(515, 25);
            label2.TabIndex = 0;
            label2.Text = "Activate subtitles:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnRestoreDefaultsFont);
            panel2.Controls.Add(btnPickColor);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(inputBorderSize);
            panel2.Controls.Add(comboFontType);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(inputFontSize);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 122);
            panel2.Name = "panel2";
            panel2.Size = new Size(515, 125);
            panel2.TabIndex = 5;
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
            // label8
            // 
            label8.Location = new Point(276, 54);
            label8.Name = "label8";
            label8.Padding = new Padding(6, 0, 0, 0);
            label8.Size = new Size(79, 30);
            label8.TabIndex = 7;
            label8.Text = "Font color:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new Point(276, 23);
            label7.Name = "label7";
            label7.Padding = new Padding(6, 0, 0, 0);
            label7.Size = new Size(79, 19);
            label7.TabIndex = 6;
            label7.Text = "Border size:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
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
            // label5
            // 
            label5.Location = new Point(3, 54);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(79, 30);
            label5.TabIndex = 3;
            label5.Text = "Font type:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
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
            // label4
            // 
            label4.Location = new Point(3, 23);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 0, 0);
            label4.Size = new Size(79, 19);
            label4.TabIndex = 1;
            label4.Text = "Font size:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 0, 0);
            label3.Size = new Size(515, 23);
            label3.TabIndex = 0;
            label3.Text = "Change subtitle appearance:";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblPreview);
            panel3.Controls.Add(label6);
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
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(6, 0, 0, 0);
            label6.Size = new Size(515, 25);
            label6.TabIndex = 0;
            label6.Text = "Preview (Indicative):";
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
            // SubtitlesUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "SubtitlesUserControl";
            Size = new Size(515, 536);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private CheckBox cbEnableSubtitles;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Controls.CustomNumericUpDown inputFontSize;
        private Label label4;
        private Controls.ButtonComboBox comboFontType;
        private Label label5;
        private Panel panel3;
        private Label label6;
        private Controls.CustomLabel lblPreview;
        private Label label7;
        private Controls.CustomNumericUpDown inputBorderSize;
        private Button btnPickColor;
        private Label label8;
        private Button btnRestoreDefaultsFont;
    }
}
