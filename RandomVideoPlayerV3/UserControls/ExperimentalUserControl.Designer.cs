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
            lblHeader = new Label();
            panel1 = new Panel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            cbToggleZoomEffect = new Controls.CustomCheckBox();
            cbToggleMoveHorizontalEffect = new Controls.CustomCheckBox();
            cbToggleMoveVerticalEffect = new Controls.CustomCheckBox();
            lbl7 = new Label();
            btnRestoreDefaults = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            lbl5 = new Label();
            inputPanAmountValue = new Controls.CustomNumericUpDown();
            lbl6 = new Label();
            comboPanEffects = new Controls.ButtonComboBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lbl3 = new Label();
            inputZoomAmountValue = new Controls.CustomNumericUpDown();
            lbl4 = new Label();
            comboZoomEffects = new Controls.ButtonComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cbKenBurnsEffect = new Controls.CustomCheckBox();
            cbFadeEffect = new Controls.CustomCheckBox();
            lbl2 = new Label();
            lbl1 = new Label();
            panel1.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            lblHeader.Size = new Size(507, 55);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Experimental";
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(flowLayoutPanel4);
            panel1.Controls.Add(lbl7);
            panel1.Controls.Add(btnRestoreDefaults);
            panel1.Controls.Add(flowLayoutPanel3);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(lbl2);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 294);
            panel1.TabIndex = 17;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(cbToggleZoomEffect);
            flowLayoutPanel4.Controls.Add(cbToggleMoveHorizontalEffect);
            flowLayoutPanel4.Controls.Add(cbToggleMoveVerticalEffect);
            flowLayoutPanel4.Dock = DockStyle.Top;
            flowLayoutPanel4.Location = new Point(0, 213);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(6, 0, 0, 0);
            flowLayoutPanel4.Size = new Size(507, 39);
            flowLayoutPanel4.TabIndex = 32;
            // 
            // cbToggleZoomEffect
            // 
            cbToggleZoomEffect.BoxSize = 13;
            cbToggleZoomEffect.HoverColor = Color.DeepSkyBlue;
            cbToggleZoomEffect.Location = new Point(9, 3);
            cbToggleZoomEffect.Name = "cbToggleZoomEffect";
            cbToggleZoomEffect.PaddingLeft = 0;
            cbToggleZoomEffect.Size = new Size(83, 24);
            cbToggleZoomEffect.TabIndex = 0;
            cbToggleZoomEffect.Text = "Zoom";
            cbToggleZoomEffect.UseVisualStyleBackColor = true;
            // 
            // cbToggleMoveHorizontalEffect
            // 
            cbToggleMoveHorizontalEffect.BoxSize = 13;
            cbToggleMoveHorizontalEffect.HoverColor = Color.DeepSkyBlue;
            cbToggleMoveHorizontalEffect.Location = new Point(98, 3);
            cbToggleMoveHorizontalEffect.Name = "cbToggleMoveHorizontalEffect";
            cbToggleMoveHorizontalEffect.PaddingLeft = 0;
            cbToggleMoveHorizontalEffect.Size = new Size(129, 24);
            cbToggleMoveHorizontalEffect.TabIndex = 1;
            cbToggleMoveHorizontalEffect.Text = "Move horizontal";
            cbToggleMoveHorizontalEffect.UseVisualStyleBackColor = true;
            // 
            // cbToggleMoveVerticalEffect
            // 
            cbToggleMoveVerticalEffect.BoxSize = 13;
            cbToggleMoveVerticalEffect.HoverColor = Color.DeepSkyBlue;
            cbToggleMoveVerticalEffect.Location = new Point(233, 3);
            cbToggleMoveVerticalEffect.Name = "cbToggleMoveVerticalEffect";
            cbToggleMoveVerticalEffect.PaddingLeft = 0;
            cbToggleMoveVerticalEffect.Size = new Size(156, 24);
            cbToggleMoveVerticalEffect.TabIndex = 2;
            cbToggleMoveVerticalEffect.Text = "Move vertical";
            cbToggleMoveVerticalEffect.UseVisualStyleBackColor = true;
            // 
            // lbl7
            // 
            lbl7.Dock = DockStyle.Top;
            lbl7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl7.Location = new Point(0, 189);
            lbl7.Name = "lbl7";
            lbl7.Padding = new Padding(6, 0, 0, 0);
            lbl7.Size = new Size(507, 24);
            lbl7.TabIndex = 27;
            lbl7.Text = "Toggle effects:";
            // 
            // btnRestoreDefaults
            // 
            btnRestoreDefaults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRestoreDefaults.BackColor = Color.Lavender;
            btnRestoreDefaults.FlatAppearance.BorderSize = 0;
            btnRestoreDefaults.FlatStyle = FlatStyle.Flat;
            btnRestoreDefaults.Location = new Point(384, 261);
            btnRestoreDefaults.Name = "btnRestoreDefaults";
            btnRestoreDefaults.Size = new Size(120, 30);
            btnRestoreDefaults.TabIndex = 19;
            btnRestoreDefaults.Text = "Restore defaults";
            btnRestoreDefaults.UseVisualStyleBackColor = false;
            btnRestoreDefaults.Click += btnRestoreDefaults_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(lbl5);
            flowLayoutPanel3.Controls.Add(inputPanAmountValue);
            flowLayoutPanel3.Controls.Add(lbl6);
            flowLayoutPanel3.Controls.Add(comboPanEffects);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Location = new Point(0, 153);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(6, 3, 0, 0);
            flowLayoutPanel3.Size = new Size(507, 36);
            flowLayoutPanel3.TabIndex = 31;
            // 
            // lbl5
            // 
            lbl5.Location = new Point(9, 3);
            lbl5.Margin = new Padding(3, 0, 3, 3);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(105, 25);
            lbl5.TabIndex = 18;
            lbl5.Text = "Move strength:";
            lbl5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputPanAmountValue
            // 
            inputPanAmountValue.Location = new Point(120, 6);
            inputPanAmountValue.Margin = new Padding(3, 3, 9, 3);
            inputPanAmountValue.Maximum = 9;
            inputPanAmountValue.Minimum = 1;
            inputPanAmountValue.Name = "inputPanAmountValue";
            inputPanAmountValue.Size = new Size(76, 19);
            inputPanAmountValue.TabIndex = 16;
            inputPanAmountValue.Text = "customNumericUpDown2";
            inputPanAmountValue.Value = 2;
            // 
            // lbl6
            // 
            lbl6.Location = new Point(214, 3);
            lbl6.Margin = new Padding(9, 0, 3, 0);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(105, 25);
            lbl6.TabIndex = 23;
            lbl6.Text = "Move animation:";
            lbl6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboPanEffects
            // 
            comboPanEffects.BackColor = Color.LightPink;
            comboPanEffects.DrawMode = DrawMode.OwnerDrawFixed;
            comboPanEffects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPanEffects.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboPanEffects.FormattingEnabled = true;
            comboPanEffects.ItemHeight = 16;
            comboPanEffects.Location = new Point(325, 6);
            comboPanEffects.Name = "comboPanEffects";
            comboPanEffects.Size = new Size(121, 22);
            comboPanEffects.TabIndex = 21;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lbl3);
            flowLayoutPanel2.Controls.Add(inputZoomAmountValue);
            flowLayoutPanel2.Controls.Add(lbl4);
            flowLayoutPanel2.Controls.Add(comboZoomEffects);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 119);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(6, 3, 0, 0);
            flowLayoutPanel2.Size = new Size(507, 34);
            flowLayoutPanel2.TabIndex = 30;
            // 
            // lbl3
            // 
            lbl3.Location = new Point(9, 3);
            lbl3.Margin = new Padding(3, 0, 3, 3);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(105, 25);
            lbl3.TabIndex = 17;
            lbl3.Text = "Zoom strength:";
            lbl3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputZoomAmountValue
            // 
            inputZoomAmountValue.Location = new Point(120, 6);
            inputZoomAmountValue.Margin = new Padding(3, 3, 9, 3);
            inputZoomAmountValue.Maximum = 9;
            inputZoomAmountValue.Minimum = 1;
            inputZoomAmountValue.Name = "inputZoomAmountValue";
            inputZoomAmountValue.Size = new Size(76, 19);
            inputZoomAmountValue.TabIndex = 15;
            inputZoomAmountValue.Text = "customNumericUpDown1";
            inputZoomAmountValue.Value = 5;
            // 
            // lbl4
            // 
            lbl4.Location = new Point(214, 3);
            lbl4.Margin = new Padding(9, 0, 3, 0);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(105, 25);
            lbl4.TabIndex = 22;
            lbl4.Text = "Zoom animation:";
            lbl4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboZoomEffects
            // 
            comboZoomEffects.BackColor = Color.LightPink;
            comboZoomEffects.DrawMode = DrawMode.OwnerDrawFixed;
            comboZoomEffects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboZoomEffects.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboZoomEffects.FormattingEnabled = true;
            comboZoomEffects.ItemHeight = 16;
            comboZoomEffects.Location = new Point(325, 6);
            comboZoomEffects.Name = "comboZoomEffects";
            comboZoomEffects.Size = new Size(121, 22);
            comboZoomEffects.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cbKenBurnsEffect);
            flowLayoutPanel1.Controls.Add(cbFadeEffect);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 85);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(6, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(507, 34);
            flowLayoutPanel1.TabIndex = 29;
            // 
            // cbKenBurnsEffect
            // 
            cbKenBurnsEffect.BoxSize = 13;
            cbKenBurnsEffect.HoverColor = Color.DeepSkyBlue;
            cbKenBurnsEffect.Location = new Point(9, 3);
            cbKenBurnsEffect.Name = "cbKenBurnsEffect";
            cbKenBurnsEffect.PaddingLeft = 0;
            cbKenBurnsEffect.Size = new Size(121, 19);
            cbKenBurnsEffect.TabIndex = 0;
            cbKenBurnsEffect.Text = "Enable effect";
            cbKenBurnsEffect.UseVisualStyleBackColor = true;
            // 
            // cbFadeEffect
            // 
            cbFadeEffect.BoxSize = 13;
            cbFadeEffect.HoverColor = Color.DeepSkyBlue;
            cbFadeEffect.Location = new Point(136, 3);
            cbFadeEffect.Name = "cbFadeEffect";
            cbFadeEffect.PaddingLeft = 0;
            cbFadeEffect.Size = new Size(223, 19);
            cbFadeEffect.TabIndex = 1;
            cbFadeEffect.Text = "Enable fade between images";
            cbFadeEffect.UseVisualStyleBackColor = true;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 24);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(507, 61);
            lbl2.TabIndex = 14;
            lbl2.Text = "Activates random movements when playing images. Uses the automatic timer for duration (Best result 6-8 sec.).\r\nYou can fine adjust the values, though the outcome might not be great. ";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(507, 24);
            lbl1.TabIndex = 0;
            lbl1.Text = "Ken Burns effect - for static images";
            // 
            // ExperimentalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(lblHeader);
            Name = "ExperimentalUserControl";
            Size = new Size(507, 609);
            panel1.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel panel1;
        private Label lbl7;
        private Label lbl6;
        private Label lbl4;
        private Controls.ButtonComboBox comboPanEffects;
        private Controls.ButtonComboBox comboZoomEffects;
        private Button btnRestoreDefaults;
        private Label lbl5;
        private Label lbl3;
        private Controls.CustomNumericUpDown inputPanAmountValue;
        private Controls.CustomNumericUpDown inputZoomAmountValue;
        private Label lbl2;
        private Label lbl1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.CustomCheckBox cbKenBurnsEffect;
        private Controls.CustomCheckBox cbFadeEffect;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private Controls.CustomCheckBox cbToggleZoomEffect;
        private Controls.CustomCheckBox cbToggleMoveHorizontalEffect;
        private Controls.CustomCheckBox cbToggleMoveVerticalEffect;
    }
}
