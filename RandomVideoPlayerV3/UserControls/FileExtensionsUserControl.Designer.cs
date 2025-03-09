namespace RandomVideoPlayer.UserControls
{
    partial class FileExtensionsUserControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExtensionsUserControl));
            lblHeader = new Label();
            label4 = new Label();
            lbl1 = new Label();
            flowPanelVideoCheckboxes = new FlowLayoutPanel();
            btnSelectVideoExt = new FontAwesome.Sharp.IconButton();
            btnDeselectVideoExt = new FontAwesome.Sharp.IconButton();
            panelVideoExtensionContainer = new Panel();
            lbl2 = new Label();
            panelImageExtensionContainer = new Panel();
            btnDeselectImageExt = new FontAwesome.Sharp.IconButton();
            btnSelectImageExt = new FontAwesome.Sharp.IconButton();
            flowPanelImageCheckboxes = new FlowLayoutPanel();
            cbEnableScriptFilter = new Controls.RoundedImageCheckBox();
            cbEnableImageFilter = new Controls.RoundedImageCheckBox();
            cbEnableVideoFilter = new Controls.RoundedImageCheckBox();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbl3 = new Label();
            toolTipInfo = new ToolTip(components);
            lbl4 = new Label();
            panel2 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            rbDateCreated = new Controls.CustomRadioButton();
            rbDateModified = new Controls.CustomRadioButton();
            cbFilterApply = new Controls.CustomCheckBox();
            panelVideoExtensionContainer.SuspendLayout();
            panelImageExtensionContainer.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(500, 55);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Filter Extensions";
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 55);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 0, 0);
            label4.Size = new Size(500, 26);
            label4.TabIndex = 6;
            label4.Text = "Choose which file types will be used for playback:";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 81);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(500, 23);
            lbl1.TabIndex = 7;
            lbl1.Text = "Video extensions:";
            // 
            // flowPanelVideoCheckboxes
            // 
            flowPanelVideoCheckboxes.Dock = DockStyle.Left;
            flowPanelVideoCheckboxes.Location = new Point(0, 0);
            flowPanelVideoCheckboxes.Margin = new Padding(3, 3, 12, 3);
            flowPanelVideoCheckboxes.Name = "flowPanelVideoCheckboxes";
            flowPanelVideoCheckboxes.Padding = new Padding(6, 4, 0, 0);
            flowPanelVideoCheckboxes.Size = new Size(380, 96);
            flowPanelVideoCheckboxes.TabIndex = 8;
            // 
            // btnSelectVideoExt
            // 
            btnSelectVideoExt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectVideoExt.BackColor = Color.Lavender;
            btnSelectVideoExt.FlatAppearance.BorderSize = 0;
            btnSelectVideoExt.FlatStyle = FlatStyle.Flat;
            btnSelectVideoExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSelectVideoExt.IconColor = Color.Black;
            btnSelectVideoExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectVideoExt.Location = new Point(395, 3);
            btnSelectVideoExt.Name = "btnSelectVideoExt";
            btnSelectVideoExt.Size = new Size(102, 32);
            btnSelectVideoExt.TabIndex = 11;
            btnSelectVideoExt.Text = "Select all";
            btnSelectVideoExt.UseVisualStyleBackColor = false;
            btnSelectVideoExt.Click += btnSelectVideoExt_Click;
            // 
            // btnDeselectVideoExt
            // 
            btnDeselectVideoExt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeselectVideoExt.BackColor = Color.Lavender;
            btnDeselectVideoExt.FlatAppearance.BorderSize = 0;
            btnDeselectVideoExt.FlatStyle = FlatStyle.Flat;
            btnDeselectVideoExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDeselectVideoExt.IconColor = Color.Black;
            btnDeselectVideoExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeselectVideoExt.Location = new Point(395, 61);
            btnDeselectVideoExt.Name = "btnDeselectVideoExt";
            btnDeselectVideoExt.Size = new Size(102, 32);
            btnDeselectVideoExt.TabIndex = 12;
            btnDeselectVideoExt.Text = "Deselect all";
            btnDeselectVideoExt.UseVisualStyleBackColor = false;
            btnDeselectVideoExt.Click += btnDeselectVideoExt_Click;
            // 
            // panelVideoExtensionContainer
            // 
            panelVideoExtensionContainer.Controls.Add(flowPanelVideoCheckboxes);
            panelVideoExtensionContainer.Controls.Add(btnDeselectVideoExt);
            panelVideoExtensionContainer.Controls.Add(btnSelectVideoExt);
            panelVideoExtensionContainer.Dock = DockStyle.Top;
            panelVideoExtensionContainer.Location = new Point(0, 104);
            panelVideoExtensionContainer.Name = "panelVideoExtensionContainer";
            panelVideoExtensionContainer.Size = new Size(500, 96);
            panelVideoExtensionContainer.TabIndex = 13;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 200);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(500, 23);
            lbl2.TabIndex = 14;
            lbl2.Text = "Image extensions:";
            // 
            // panelImageExtensionContainer
            // 
            panelImageExtensionContainer.Controls.Add(btnDeselectImageExt);
            panelImageExtensionContainer.Controls.Add(btnSelectImageExt);
            panelImageExtensionContainer.Controls.Add(flowPanelImageCheckboxes);
            panelImageExtensionContainer.Dock = DockStyle.Top;
            panelImageExtensionContainer.Location = new Point(0, 223);
            panelImageExtensionContainer.Name = "panelImageExtensionContainer";
            panelImageExtensionContainer.Size = new Size(500, 96);
            panelImageExtensionContainer.TabIndex = 15;
            // 
            // btnDeselectImageExt
            // 
            btnDeselectImageExt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeselectImageExt.BackColor = Color.Lavender;
            btnDeselectImageExt.FlatAppearance.BorderSize = 0;
            btnDeselectImageExt.FlatStyle = FlatStyle.Flat;
            btnDeselectImageExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDeselectImageExt.IconColor = Color.Black;
            btnDeselectImageExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeselectImageExt.Location = new Point(395, 61);
            btnDeselectImageExt.Name = "btnDeselectImageExt";
            btnDeselectImageExt.Size = new Size(102, 32);
            btnDeselectImageExt.TabIndex = 13;
            btnDeselectImageExt.Text = "Deselect all";
            btnDeselectImageExt.UseVisualStyleBackColor = false;
            btnDeselectImageExt.Click += btnDeselectImageExt_Click;
            // 
            // btnSelectImageExt
            // 
            btnSelectImageExt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectImageExt.BackColor = Color.Lavender;
            btnSelectImageExt.FlatAppearance.BorderSize = 0;
            btnSelectImageExt.FlatStyle = FlatStyle.Flat;
            btnSelectImageExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSelectImageExt.IconColor = Color.Black;
            btnSelectImageExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectImageExt.Location = new Point(395, 3);
            btnSelectImageExt.Name = "btnSelectImageExt";
            btnSelectImageExt.Size = new Size(102, 32);
            btnSelectImageExt.TabIndex = 13;
            btnSelectImageExt.Text = "Select all";
            btnSelectImageExt.UseVisualStyleBackColor = false;
            btnSelectImageExt.Click += btnSelectImageExt_Click;
            // 
            // flowPanelImageCheckboxes
            // 
            flowPanelImageCheckboxes.Dock = DockStyle.Left;
            flowPanelImageCheckboxes.Location = new Point(0, 0);
            flowPanelImageCheckboxes.Margin = new Padding(3, 3, 12, 3);
            flowPanelImageCheckboxes.Name = "flowPanelImageCheckboxes";
            flowPanelImageCheckboxes.Padding = new Padding(6, 4, 0, 0);
            flowPanelImageCheckboxes.Size = new Size(380, 96);
            flowPanelImageCheckboxes.TabIndex = 0;
            // 
            // cbEnableScriptFilter
            // 
            cbEnableScriptFilter.Appearance = Appearance.Button;
            cbEnableScriptFilter.BackColor = Color.Transparent;
            cbEnableScriptFilter.CheckedBackColor = Color.DeepSkyBlue;
            cbEnableScriptFilter.FlatAppearance.BorderSize = 0;
            cbEnableScriptFilter.FlatStyle = FlatStyle.Flat;
            cbEnableScriptFilter.Image = (Image)resources.GetObject("cbEnableScriptFilter.Image");
            cbEnableScriptFilter.Location = new Point(81, 3);
            cbEnableScriptFilter.Name = "cbEnableScriptFilter";
            cbEnableScriptFilter.Size = new Size(30, 30);
            cbEnableScriptFilter.TabIndex = 17;
            cbEnableScriptFilter.Text = "roundedImageCheckBox1";
            cbEnableScriptFilter.UncheckedBackColor = Color.GhostWhite;
            cbEnableScriptFilter.UseVisualStyleBackColor = false;
            // 
            // cbEnableImageFilter
            // 
            cbEnableImageFilter.Appearance = Appearance.Button;
            cbEnableImageFilter.BackColor = Color.Transparent;
            cbEnableImageFilter.CheckedBackColor = Color.LightCoral;
            cbEnableImageFilter.FlatAppearance.BorderSize = 0;
            cbEnableImageFilter.FlatStyle = FlatStyle.Flat;
            cbEnableImageFilter.Image = (Image)resources.GetObject("cbEnableImageFilter.Image");
            cbEnableImageFilter.Location = new Point(45, 3);
            cbEnableImageFilter.Name = "cbEnableImageFilter";
            cbEnableImageFilter.Size = new Size(30, 30);
            cbEnableImageFilter.TabIndex = 18;
            cbEnableImageFilter.Text = "roundedImageCheckBox2";
            cbEnableImageFilter.UncheckedBackColor = Color.GhostWhite;
            cbEnableImageFilter.UseVisualStyleBackColor = false;
            // 
            // cbEnableVideoFilter
            // 
            cbEnableVideoFilter.Appearance = Appearance.Button;
            cbEnableVideoFilter.BackColor = Color.Transparent;
            cbEnableVideoFilter.CheckedBackColor = Color.PaleGreen;
            cbEnableVideoFilter.FlatAppearance.BorderSize = 0;
            cbEnableVideoFilter.FlatStyle = FlatStyle.Flat;
            cbEnableVideoFilter.Image = (Image)resources.GetObject("cbEnableVideoFilter.Image");
            cbEnableVideoFilter.Location = new Point(9, 3);
            cbEnableVideoFilter.Name = "cbEnableVideoFilter";
            cbEnableVideoFilter.Size = new Size(30, 30);
            cbEnableVideoFilter.TabIndex = 19;
            cbEnableVideoFilter.Text = "roundedImageCheckBox3";
            cbEnableVideoFilter.UncheckedBackColor = Color.GhostWhite;
            cbEnableVideoFilter.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(lbl3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 353);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 72);
            panel1.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cbEnableVideoFilter);
            flowLayoutPanel1.Controls.Add(cbEnableImageFilter);
            flowLayoutPanel1.Controls.Add(cbEnableScriptFilter);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(6, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(500, 47);
            flowLayoutPanel1.TabIndex = 21;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 0, 0, 0);
            lbl3.Size = new Size(500, 25);
            lbl3.TabIndex = 20;
            lbl3.Text = "Toggle which filters to use:";
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl4.Location = new Point(0, 425);
            lbl4.Name = "lbl4";
            lbl4.Padding = new Padding(6, 0, 0, 0);
            lbl4.Size = new Size(500, 18);
            lbl4.TabIndex = 21;
            lbl4.Text = "Change the behavior of the recent filter:";
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 443);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 41);
            panel2.TabIndex = 22;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(rbDateCreated);
            flowLayoutPanel2.Controls.Add(rbDateModified);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(6, 0, 0, 0);
            flowLayoutPanel2.Size = new Size(500, 41);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // rbDateCreated
            // 
            rbDateCreated.CircleSize = 12;
            rbDateCreated.HoverColor = Color.DeepSkyBlue;
            rbDateCreated.Location = new Point(9, 3);
            rbDateCreated.Name = "rbDateCreated";
            rbDateCreated.PaddingLeft = 0;
            rbDateCreated.Size = new Size(151, 19);
            rbDateCreated.TabIndex = 24;
            rbDateCreated.TabStop = true;
            rbDateCreated.Text = "Sort by date created";
            rbDateCreated.UseVisualStyleBackColor = true;
            // 
            // rbDateModified
            // 
            rbDateModified.CircleSize = 12;
            rbDateModified.HoverColor = Color.DeepSkyBlue;
            rbDateModified.Location = new Point(166, 3);
            rbDateModified.Name = "rbDateModified";
            rbDateModified.PaddingLeft = 0;
            rbDateModified.Size = new Size(162, 19);
            rbDateModified.TabIndex = 25;
            rbDateModified.TabStop = true;
            rbDateModified.Text = "Sort by date modified";
            rbDateModified.UseVisualStyleBackColor = true;
            // 
            // cbFilterApply
            // 
            cbFilterApply.AutoSize = true;
            cbFilterApply.BoxSize = 13;
            cbFilterApply.Dock = DockStyle.Top;
            cbFilterApply.HoverColor = Color.DeepSkyBlue;
            cbFilterApply.Location = new Point(0, 319);
            cbFilterApply.Name = "cbFilterApply";
            cbFilterApply.Padding = new Padding(3, 3, 3, 12);
            cbFilterApply.PaddingLeft = 12;
            cbFilterApply.Size = new Size(500, 34);
            cbFilterApply.TabIndex = 23;
            cbFilterApply.Text = "Also apply filter to custom list playback";
            cbFilterApply.UseVisualStyleBackColor = true;
            // 
            // FileExtensionsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(lbl4);
            Controls.Add(panel1);
            Controls.Add(cbFilterApply);
            Controls.Add(panelImageExtensionContainer);
            Controls.Add(lbl2);
            Controls.Add(panelVideoExtensionContainer);
            Controls.Add(lbl1);
            Controls.Add(label4);
            Controls.Add(lblHeader);
            Name = "FileExtensionsUserControl";
            Size = new Size(500, 542);
            panelVideoExtensionContainer.ResumeLayout(false);
            panelImageExtensionContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private Label label4;
        private Label lbl1;
        private FlowLayoutPanel flowPanelVideoCheckboxes;
        private FontAwesome.Sharp.IconButton btnSelectVideoExt;
        private FontAwesome.Sharp.IconButton btnDeselectVideoExt;
        private Panel panelVideoExtensionContainer;
        private Label lbl2;
        private Panel panelImageExtensionContainer;
        private FontAwesome.Sharp.IconButton btnDeselectImageExt;
        private FontAwesome.Sharp.IconButton btnSelectImageExt;
        private FlowLayoutPanel flowPanelImageCheckboxes;
        private Controls.RoundedImageCheckBox cbEnableScriptFilter;
        private Controls.RoundedImageCheckBox cbEnableImageFilter;
        private Controls.RoundedImageCheckBox cbEnableVideoFilter;
        private Panel panel1;
        private Label lbl3;
        private ToolTip toolTipInfo;
        private Label lbl4;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Controls.CustomCheckBox cbFilterApply;
        private Controls.CustomRadioButton rbDateCreated;
        private Controls.CustomRadioButton rbDateModified;
    }
}
