namespace RandomVideoPlayer.UserControls
{
    partial class ExperimentalUserControl
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
            lblHeader = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnPanEffects = new FontAwesome.Sharp.IconButton();
            lbl6 = new Label();
            inputPanAmountValue = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            btnZoomEffects = new FontAwesome.Sharp.IconButton();
            lbl4 = new Label();
            inputZoomAmountValue = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            lbl3 = new Label();
            lbl5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cbKenBurnsEffect = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbFadeEffect = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl2 = new Label();
            lbl1 = new Label();
            panel2 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnRestore = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cbToggleZoomEffect = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbToggleMoveHorizontalEffect = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbToggleMoveVerticalEffect = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl7 = new Label();
            panel3 = new Panel();
            cbEnablePreviewSB = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbEnableThumbPreview = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl9 = new Label();
            cbEnableGraphPreviewSB = new RandomVideoPlayer.Controls.CustomCheckBox();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.Aquamarine;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 1);
            tableLayoutMain.Controls.Add(panel2, 0, 2);
            tableLayoutMain.Controls.Add(panel3, 0, 3);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 32F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.GhostWhite;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 21;
            lblHeader.Text = "Experimental";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SpringGreen;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(lbl2);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 184);
            panel1.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Moccasin;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.Controls.Add(btnPanEffects, 3, 1);
            tableLayoutPanel1.Controls.Add(lbl6, 2, 1);
            tableLayoutPanel1.Controls.Add(inputPanAmountValue, 1, 1);
            tableLayoutPanel1.Controls.Add(btnZoomEffects, 3, 0);
            tableLayoutPanel1.Controls.Add(lbl4, 2, 0);
            tableLayoutPanel1.Controls.Add(inputZoomAmountValue, 1, 0);
            tableLayoutPanel1.Controls.Add(lbl3, 0, 0);
            tableLayoutPanel1.Controls.Add(lbl5, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 115);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(518, 69);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // btnPanEffects
            // 
            btnPanEffects.BackColor = Color.LightSteelBlue;
            btnPanEffects.Dock = DockStyle.Fill;
            btnPanEffects.FlatAppearance.BorderSize = 0;
            btnPanEffects.FlatStyle = FlatStyle.Flat;
            btnPanEffects.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            btnPanEffects.IconColor = Color.Black;
            btnPanEffects.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPanEffects.IconSize = 20;
            btnPanEffects.ImageAlign = ContentAlignment.MiddleRight;
            btnPanEffects.Location = new Point(342, 40);
            btnPanEffects.Margin = new Padding(3, 6, 6, 6);
            btnPanEffects.Name = "btnPanEffects";
            btnPanEffects.Size = new Size(170, 23);
            btnPanEffects.TabIndex = 28;
            btnPanEffects.Text = "Ease In";
            btnPanEffects.TextAlign = ContentAlignment.MiddleLeft;
            btnPanEffects.UseVisualStyleBackColor = false;
            // 
            // lbl6
            // 
            lbl6.Dock = DockStyle.Fill;
            lbl6.Location = new Point(229, 37);
            lbl6.Margin = new Padding(3);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(107, 29);
            lbl6.TabIndex = 27;
            lbl6.Text = "Move animation:";
            lbl6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputPanAmountValue
            // 
            inputPanAmountValue.BackColor = Color.PaleGreen;
            inputPanAmountValue.Dock = DockStyle.Left;
            inputPanAmountValue.ForeColor = SystemColors.WindowText;
            inputPanAmountValue.IconColor = Color.Indigo;
            inputPanAmountValue.Location = new Point(116, 42);
            inputPanAmountValue.Margin = new Padding(3, 8, 3, 8);
            inputPanAmountValue.Maximum = 9;
            inputPanAmountValue.Minimum = 1;
            inputPanAmountValue.Name = "inputPanAmountValue";
            inputPanAmountValue.Size = new Size(76, 19);
            inputPanAmountValue.TabIndex = 26;
            inputPanAmountValue.Text = "customNumericUpDown2";
            inputPanAmountValue.Value = 2;
            // 
            // btnZoomEffects
            // 
            btnZoomEffects.BackColor = Color.LightSteelBlue;
            btnZoomEffects.Dock = DockStyle.Fill;
            btnZoomEffects.FlatAppearance.BorderSize = 0;
            btnZoomEffects.FlatStyle = FlatStyle.Flat;
            btnZoomEffects.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            btnZoomEffects.IconColor = Color.Black;
            btnZoomEffects.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnZoomEffects.IconSize = 20;
            btnZoomEffects.ImageAlign = ContentAlignment.MiddleRight;
            btnZoomEffects.Location = new Point(342, 6);
            btnZoomEffects.Margin = new Padding(3, 6, 6, 6);
            btnZoomEffects.Name = "btnZoomEffects";
            btnZoomEffects.Size = new Size(170, 22);
            btnZoomEffects.TabIndex = 24;
            btnZoomEffects.Text = "Ease In";
            btnZoomEffects.TextAlign = ContentAlignment.MiddleLeft;
            btnZoomEffects.UseVisualStyleBackColor = false;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Fill;
            lbl4.Location = new Point(229, 3);
            lbl4.Margin = new Padding(3);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(107, 28);
            lbl4.TabIndex = 23;
            lbl4.Text = "Zoom animation:";
            lbl4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputZoomAmountValue
            // 
            inputZoomAmountValue.BackColor = SystemColors.Window;
            inputZoomAmountValue.Dock = DockStyle.Left;
            inputZoomAmountValue.ForeColor = SystemColors.WindowText;
            inputZoomAmountValue.IconColor = Color.Indigo;
            inputZoomAmountValue.Location = new Point(116, 8);
            inputZoomAmountValue.Margin = new Padding(3, 8, 3, 8);
            inputZoomAmountValue.Maximum = 9;
            inputZoomAmountValue.Minimum = 1;
            inputZoomAmountValue.Name = "inputZoomAmountValue";
            inputZoomAmountValue.Size = new Size(76, 18);
            inputZoomAmountValue.TabIndex = 19;
            inputZoomAmountValue.Text = "customNumericUpDown1";
            inputZoomAmountValue.Value = 5;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Fill;
            lbl3.Location = new Point(3, 3);
            lbl3.Margin = new Padding(3);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(107, 28);
            lbl3.TabIndex = 18;
            lbl3.Text = "Zoom strength:";
            lbl3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl5
            // 
            lbl5.Dock = DockStyle.Fill;
            lbl5.Location = new Point(3, 37);
            lbl5.Margin = new Padding(3);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(107, 29);
            lbl5.TabIndex = 25;
            lbl5.Text = "Move strength:";
            lbl5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.LightSkyBlue;
            flowLayoutPanel1.Controls.Add(cbKenBurnsEffect);
            flowLayoutPanel1.Controls.Add(cbFadeEffect);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 85);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(518, 30);
            flowLayoutPanel1.TabIndex = 16;
            // 
            // cbKenBurnsEffect
            // 
            cbKenBurnsEffect.BoxSize = 13;
            cbKenBurnsEffect.HoverColor = Color.DeepSkyBlue;
            cbKenBurnsEffect.Location = new Point(3, 3);
            cbKenBurnsEffect.Name = "cbKenBurnsEffect";
            cbKenBurnsEffect.PaddingLeft = 12;
            cbKenBurnsEffect.Size = new Size(121, 19);
            cbKenBurnsEffect.TabIndex = 1;
            cbKenBurnsEffect.Text = "Enable effect";
            cbKenBurnsEffect.UseVisualStyleBackColor = true;
            // 
            // cbFadeEffect
            // 
            cbFadeEffect.BoxSize = 13;
            cbFadeEffect.HoverColor = Color.DeepSkyBlue;
            cbFadeEffect.Location = new Point(130, 3);
            cbFadeEffect.Name = "cbFadeEffect";
            cbFadeEffect.PaddingLeft = 0;
            cbFadeEffect.Size = new Size(223, 19);
            cbFadeEffect.TabIndex = 2;
            cbFadeEffect.Text = "Enable fade between images";
            cbFadeEffect.UseVisualStyleBackColor = true;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F);
            lbl2.Location = new Point(0, 24);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 61);
            lbl2.TabIndex = 15;
            lbl2.Text = "Activates random movements when playing images. Uses the automatic timer for duration (Best result 6-8 sec.).\r\nYou can fine adjust the values, though the outcome might not be great. ";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 24);
            lbl1.TabIndex = 1;
            lbl1.Text = "Ken Burns effect - for static images";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SandyBrown;
            panel2.Controls.Add(flowLayoutPanel3);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Controls.Add(lbl7);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 253);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 101);
            panel2.TabIndex = 23;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.DarkSalmon;
            flowLayoutPanel3.Controls.Add(btnRestore);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(0, 58);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel3.Size = new Size(518, 43);
            flowLayoutPanel3.TabIndex = 30;
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRestore.BackColor = Color.Lavender;
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Location = new Point(395, 3);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(120, 30);
            btnRestore.TabIndex = 19;
            btnRestore.Text = "Restore defaults";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestoreDefaults_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.LightSalmon;
            flowLayoutPanel2.Controls.Add(cbToggleZoomEffect);
            flowLayoutPanel2.Controls.Add(cbToggleMoveHorizontalEffect);
            flowLayoutPanel2.Controls.Add(cbToggleMoveVerticalEffect);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 24);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(518, 34);
            flowLayoutPanel2.TabIndex = 29;
            // 
            // cbToggleZoomEffect
            // 
            cbToggleZoomEffect.BoxSize = 13;
            cbToggleZoomEffect.HoverColor = Color.DeepSkyBlue;
            cbToggleZoomEffect.Location = new Point(3, 3);
            cbToggleZoomEffect.Name = "cbToggleZoomEffect";
            cbToggleZoomEffect.PaddingLeft = 12;
            cbToggleZoomEffect.Size = new Size(83, 24);
            cbToggleZoomEffect.TabIndex = 1;
            cbToggleZoomEffect.Text = "Zoom";
            cbToggleZoomEffect.UseVisualStyleBackColor = true;
            // 
            // cbToggleMoveHorizontalEffect
            // 
            cbToggleMoveHorizontalEffect.BoxSize = 13;
            cbToggleMoveHorizontalEffect.HoverColor = Color.DeepSkyBlue;
            cbToggleMoveHorizontalEffect.Location = new Point(92, 3);
            cbToggleMoveHorizontalEffect.Name = "cbToggleMoveHorizontalEffect";
            cbToggleMoveHorizontalEffect.PaddingLeft = 0;
            cbToggleMoveHorizontalEffect.Size = new Size(129, 24);
            cbToggleMoveHorizontalEffect.TabIndex = 2;
            cbToggleMoveHorizontalEffect.Text = "Move horizontal";
            cbToggleMoveHorizontalEffect.UseVisualStyleBackColor = true;
            // 
            // cbToggleMoveVerticalEffect
            // 
            cbToggleMoveVerticalEffect.BoxSize = 13;
            cbToggleMoveVerticalEffect.HoverColor = Color.DeepSkyBlue;
            cbToggleMoveVerticalEffect.Location = new Point(227, 3);
            cbToggleMoveVerticalEffect.Name = "cbToggleMoveVerticalEffect";
            cbToggleMoveVerticalEffect.PaddingLeft = 0;
            cbToggleMoveVerticalEffect.Size = new Size(156, 24);
            cbToggleMoveVerticalEffect.TabIndex = 3;
            cbToggleMoveVerticalEffect.Text = "Move vertical";
            cbToggleMoveVerticalEffect.UseVisualStyleBackColor = true;
            // 
            // lbl7
            // 
            lbl7.Dock = DockStyle.Top;
            lbl7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl7.Location = new Point(0, 0);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(518, 24);
            lbl7.TabIndex = 28;
            lbl7.Text = "Toggle effects:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.MistyRose;
            panel3.Controls.Add(cbEnableGraphPreviewSB);
            panel3.Controls.Add(cbEnablePreviewSB);
            panel3.Controls.Add(cbEnableThumbPreview);
            panel3.Controls.Add(lbl9);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 360);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 293);
            panel3.TabIndex = 24;
            // 
            // cbEnablePreviewSB
            // 
            cbEnablePreviewSB.BoxSize = 13;
            cbEnablePreviewSB.Dock = DockStyle.Top;
            cbEnablePreviewSB.HoverColor = Color.DeepSkyBlue;
            cbEnablePreviewSB.Location = new Point(0, 51);
            cbEnablePreviewSB.Name = "cbEnablePreviewSB";
            cbEnablePreviewSB.PaddingLeft = 12;
            cbEnablePreviewSB.Size = new Size(518, 27);
            cbEnablePreviewSB.TabIndex = 7;
            cbEnablePreviewSB.Text = "Enable preview in seekbar";
            cbEnablePreviewSB.UseVisualStyleBackColor = true;
            // 
            // cbEnableThumbPreview
            // 
            cbEnableThumbPreview.BoxSize = 13;
            cbEnableThumbPreview.Dock = DockStyle.Top;
            cbEnableThumbPreview.HoverColor = Color.DeepSkyBlue;
            cbEnableThumbPreview.Location = new Point(0, 24);
            cbEnableThumbPreview.Name = "cbEnableThumbPreview";
            cbEnableThumbPreview.PaddingLeft = 12;
            cbEnableThumbPreview.Size = new Size(518, 27);
            cbEnableThumbPreview.TabIndex = 6;
            cbEnableThumbPreview.Text = "Enable thumbnail preview in browsers";
            cbEnableThumbPreview.UseVisualStyleBackColor = true;
            // 
            // lbl9
            // 
            lbl9.Dock = DockStyle.Top;
            lbl9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl9.Location = new Point(0, 0);
            lbl9.Name = "lbl9";
            lbl9.Size = new Size(518, 24);
            lbl9.TabIndex = 2;
            lbl9.Text = "Enable thumbnail previews:";
            // 
            // cbEnableGraphPreviewSB
            // 
            cbEnableGraphPreviewSB.BoxSize = 13;
            cbEnableGraphPreviewSB.Dock = DockStyle.Top;
            cbEnableGraphPreviewSB.HoverColor = Color.DeepSkyBlue;
            cbEnableGraphPreviewSB.Location = new Point(0, 78);
            cbEnableGraphPreviewSB.Name = "cbEnableGraphPreviewSB";
            cbEnableGraphPreviewSB.PaddingLeft = 12;
            cbEnableGraphPreviewSB.Size = new Size(518, 27);
            cbEnableGraphPreviewSB.TabIndex = 8;
            cbEnableGraphPreviewSB.Text = "Enable graph preview in seekbar";
            cbEnableGraphPreviewSB.UseVisualStyleBackColor = true;
            // 
            // ExperimentalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "ExperimentalUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbl2;
        private Controls.CustomCheckBox cbKenBurnsEffect;
        private TableLayoutPanel tableLayoutPanel1;
        private Controls.CustomCheckBox cbFadeEffect;
        private Label lbl3;
        private Controls.CustomNumericUpDown inputZoomAmountValue;
        private Label lbl4;
        private FontAwesome.Sharp.IconButton btnZoomEffects;
        private Label lbl5;
        private Controls.CustomNumericUpDown inputPanAmountValue;
        private Label lbl6;
        private FontAwesome.Sharp.IconButton btnPanEffects;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lbl7;
        private Controls.CustomCheckBox cbToggleZoomEffect;
        private Controls.CustomCheckBox cbToggleMoveHorizontalEffect;
        private Controls.CustomCheckBox cbToggleMoveVerticalEffect;
        private Panel panel3;
        private Label lbl9;
        private Controls.CustomCheckBox cbEnableThumbPreview;
        private Controls.CustomCheckBox cbEnablePreviewSB;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnRestore;
        private Controls.CustomCheckBox cbEnableGraphPreviewSB;
    }
}
