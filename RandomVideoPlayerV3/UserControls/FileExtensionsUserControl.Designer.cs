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
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            flowPanelVideoCheckboxes = new FlowLayoutPanel();
            btnSelectVideoExt = new FontAwesome.Sharp.IconButton();
            btnDeselectVideoExt = new FontAwesome.Sharp.IconButton();
            panelVideoExtensionContainer = new Panel();
            label6 = new Label();
            panelImageExtensionContainer = new Panel();
            btnDeselectImageExt = new FontAwesome.Sharp.IconButton();
            btnSelectImageExt = new FontAwesome.Sharp.IconButton();
            flowPanelImageCheckboxes = new FlowLayoutPanel();
            cbFilterApply = new CheckBox();
            cbEnableScriptFilter = new Controls.RoundedImageCheckBox();
            cbEnableImageFilter = new Controls.RoundedImageCheckBox();
            cbEnableVideoFilter = new Controls.RoundedImageCheckBox();
            panel1 = new Panel();
            label2 = new Label();
            toolTipInfo = new ToolTip(components);
            panelVideoExtensionContainer.SuspendLayout();
            panelImageExtensionContainer.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(500, 55);
            label1.TabIndex = 1;
            label1.Text = "Filter Extensions";
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
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 81);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(500, 23);
            label5.TabIndex = 7;
            label5.Text = "Video extensions:";
            // 
            // flowPanelVideoCheckboxes
            // 
            flowPanelVideoCheckboxes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(0, 200);
            label6.Name = "label6";
            label6.Padding = new Padding(6, 0, 0, 0);
            label6.Size = new Size(500, 23);
            label6.TabIndex = 14;
            label6.Text = "Image extensions:";
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
            flowPanelImageCheckboxes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowPanelImageCheckboxes.Location = new Point(0, 0);
            flowPanelImageCheckboxes.Margin = new Padding(3, 3, 12, 3);
            flowPanelImageCheckboxes.Name = "flowPanelImageCheckboxes";
            flowPanelImageCheckboxes.Padding = new Padding(6, 4, 0, 0);
            flowPanelImageCheckboxes.Size = new Size(380, 96);
            flowPanelImageCheckboxes.TabIndex = 0;
            // 
            // cbFilterApply
            // 
            cbFilterApply.AutoSize = true;
            cbFilterApply.Dock = DockStyle.Top;
            cbFilterApply.Location = new Point(0, 319);
            cbFilterApply.Name = "cbFilterApply";
            cbFilterApply.Padding = new Padding(9, 6, 0, 8);
            cbFilterApply.Size = new Size(500, 33);
            cbFilterApply.TabIndex = 16;
            cbFilterApply.Text = "Also apply filter to custom list playback";
            cbFilterApply.UseVisualStyleBackColor = true;
            // 
            // cbEnableScriptFilter
            // 
            cbEnableScriptFilter.Appearance = Appearance.Button;
            cbEnableScriptFilter.BackColor = Color.Transparent;
            cbEnableScriptFilter.CheckedBackColor = Color.DeepSkyBlue;
            cbEnableScriptFilter.FlatAppearance.BorderSize = 0;
            cbEnableScriptFilter.FlatStyle = FlatStyle.Flat;
            cbEnableScriptFilter.Image = (Image)resources.GetObject("cbEnableScriptFilter.Image");
            cbEnableScriptFilter.Location = new Point(86, 28);
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
            cbEnableImageFilter.Location = new Point(50, 28);
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
            cbEnableVideoFilter.Location = new Point(14, 28);
            cbEnableVideoFilter.Name = "cbEnableVideoFilter";
            cbEnableVideoFilter.Size = new Size(30, 30);
            cbEnableVideoFilter.TabIndex = 19;
            cbEnableVideoFilter.Text = "roundedImageCheckBox3";
            cbEnableVideoFilter.UncheckedBackColor = Color.GhostWhite;
            cbEnableVideoFilter.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbEnableScriptFilter);
            panel1.Controls.Add(cbEnableVideoFilter);
            panel1.Controls.Add(cbEnableImageFilter);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 352);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 94);
            panel1.TabIndex = 20;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 0, 0);
            label2.Size = new Size(500, 25);
            label2.TabIndex = 20;
            label2.Text = "Toggle which filters to use:";
            // 
            // FileExtensionsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(cbFilterApply);
            Controls.Add(panelImageExtensionContainer);
            Controls.Add(label6);
            Controls.Add(panelVideoExtensionContainer);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "FileExtensionsUserControl";
            Size = new Size(500, 542);
            panelVideoExtensionContainer.ResumeLayout(false);
            panelImageExtensionContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label5;
        private FlowLayoutPanel flowPanelVideoCheckboxes;
        private FontAwesome.Sharp.IconButton btnSelectVideoExt;
        private FontAwesome.Sharp.IconButton btnDeselectVideoExt;
        private Panel panelVideoExtensionContainer;
        private Label label6;
        private Panel panelImageExtensionContainer;
        private FontAwesome.Sharp.IconButton btnDeselectImageExt;
        private FontAwesome.Sharp.IconButton btnSelectImageExt;
        private FlowLayoutPanel flowPanelImageCheckboxes;
        private CheckBox cbFilterApply;
        private Controls.RoundedImageCheckBox cbEnableScriptFilter;
        private Controls.RoundedImageCheckBox cbEnableImageFilter;
        private Controls.RoundedImageCheckBox cbEnableVideoFilter;
        private Panel panel1;
        private Label label2;
        private ToolTip toolTipInfo;
    }
}
