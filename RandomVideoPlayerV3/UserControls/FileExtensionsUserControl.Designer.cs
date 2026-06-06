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
            toolTipInfo = new ToolTip(components);
            tableLayoutMain = new TableLayoutPanel();
            label4 = new Label();
            lblHeader = new Label();
            panel1 = new Panel();
            tableLayoutVideoExt = new TableLayoutPanel();
            flowPanelVideoCheckboxes = new FlowLayoutPanel();
            panel2 = new Panel();
            btnDeselectVideoExt = new FontAwesome.Sharp.IconButton();
            btnSelectVideoExt = new FontAwesome.Sharp.IconButton();
            lbl1 = new Label();
            panel3 = new Panel();
            tableLayoutImageExt = new TableLayoutPanel();
            flowPanelImageCheckboxes = new FlowLayoutPanel();
            panel4 = new Panel();
            btnDeselectImageExt = new FontAwesome.Sharp.IconButton();
            btnSelectImageExt = new FontAwesome.Sharp.IconButton();
            lbl2 = new Label();
            panel5 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cbEnableVideoFilter = new RandomVideoPlayer.Controls.RoundedImageCheckBox();
            cbEnableImageFilter = new RandomVideoPlayer.Controls.RoundedImageCheckBox();
            cbEnableScriptFilter = new RandomVideoPlayer.Controls.RoundedImageCheckBox();
            lbl3 = new Label();
            cbFilterApply = new RandomVideoPlayer.Controls.CustomCheckBox();
            panel6 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            rbDateCreated = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbDateModified = new RandomVideoPlayer.Controls.CustomRadioButton();
            lbl4 = new Label();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutVideoExt.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutImageExt.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = SystemColors.Info;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(label4, 0, 1);
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 2);
            tableLayoutMain.Controls.Add(panel3, 0, 3);
            tableLayoutMain.Controls.Add(panel5, 0, 4);
            tableLayoutMain.Controls.Add(panel6, 0, 5);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 6;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 60);
            label4.Name = "label4";
            label4.Size = new Size(518, 24);
            label4.TabIndex = 28;
            label4.Text = "Choose which file types will be used for playback:";
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(518, 55);
            lblHeader.TabIndex = 25;
            lblHeader.Text = "Filter Extensions";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(tableLayoutVideoExt);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 137);
            panel1.TabIndex = 26;
            // 
            // tableLayoutVideoExt
            // 
            tableLayoutVideoExt.BackColor = SystemColors.InactiveBorder;
            tableLayoutVideoExt.ColumnCount = 2;
            tableLayoutVideoExt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutVideoExt.ColumnStyles.Add(new ColumnStyle());
            tableLayoutVideoExt.Controls.Add(flowPanelVideoCheckboxes, 0, 0);
            tableLayoutVideoExt.Controls.Add(panel2, 1, 0);
            tableLayoutVideoExt.Dock = DockStyle.Fill;
            tableLayoutVideoExt.Location = new Point(0, 24);
            tableLayoutVideoExt.Name = "tableLayoutVideoExt";
            tableLayoutVideoExt.RowCount = 1;
            tableLayoutVideoExt.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutVideoExt.Size = new Size(518, 113);
            tableLayoutVideoExt.TabIndex = 28;
            // 
            // flowPanelVideoCheckboxes
            // 
            flowPanelVideoCheckboxes.Dock = DockStyle.Fill;
            flowPanelVideoCheckboxes.Location = new Point(0, 0);
            flowPanelVideoCheckboxes.Margin = new Padding(0);
            flowPanelVideoCheckboxes.Name = "flowPanelVideoCheckboxes";
            flowPanelVideoCheckboxes.Padding = new Padding(6, 4, 0, 0);
            flowPanelVideoCheckboxes.Size = new Size(412, 113);
            flowPanelVideoCheckboxes.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MistyRose;
            panel2.Controls.Add(btnDeselectVideoExt);
            panel2.Controls.Add(btnSelectVideoExt);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(415, 0);
            panel2.Margin = new Padding(3, 0, 3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(100, 113);
            panel2.TabIndex = 10;
            // 
            // btnDeselectVideoExt
            // 
            btnDeselectVideoExt.BackColor = Color.Lavender;
            btnDeselectVideoExt.Dock = DockStyle.Bottom;
            btnDeselectVideoExt.FlatAppearance.BorderSize = 0;
            btnDeselectVideoExt.FlatStyle = FlatStyle.Flat;
            btnDeselectVideoExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDeselectVideoExt.IconColor = Color.Black;
            btnDeselectVideoExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeselectVideoExt.Location = new Point(0, 81);
            btnDeselectVideoExt.Name = "btnDeselectVideoExt";
            btnDeselectVideoExt.Size = new Size(100, 32);
            btnDeselectVideoExt.TabIndex = 13;
            btnDeselectVideoExt.Text = "Deselect all";
            btnDeselectVideoExt.UseVisualStyleBackColor = false;
            btnDeselectVideoExt.Click += btnDeselectVideoExt_Click;
            // 
            // btnSelectVideoExt
            // 
            btnSelectVideoExt.BackColor = Color.Lavender;
            btnSelectVideoExt.Dock = DockStyle.Top;
            btnSelectVideoExt.FlatAppearance.BorderSize = 0;
            btnSelectVideoExt.FlatStyle = FlatStyle.Flat;
            btnSelectVideoExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSelectVideoExt.IconColor = Color.Black;
            btnSelectVideoExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectVideoExt.Location = new Point(0, 0);
            btnSelectVideoExt.Name = "btnSelectVideoExt";
            btnSelectVideoExt.Size = new Size(100, 32);
            btnSelectVideoExt.TabIndex = 12;
            btnSelectVideoExt.Text = "Select all";
            btnSelectVideoExt.UseVisualStyleBackColor = false;
            btnSelectVideoExt.Click += btnSelectVideoExt_Click;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 24);
            lbl1.TabIndex = 27;
            lbl1.Text = "Video extensions:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Linen;
            panel3.Controls.Add(tableLayoutImageExt);
            panel3.Controls.Add(lbl2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 230);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 137);
            panel3.TabIndex = 27;
            // 
            // tableLayoutImageExt
            // 
            tableLayoutImageExt.BackColor = Color.Bisque;
            tableLayoutImageExt.ColumnCount = 2;
            tableLayoutImageExt.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutImageExt.ColumnStyles.Add(new ColumnStyle());
            tableLayoutImageExt.Controls.Add(flowPanelImageCheckboxes, 0, 0);
            tableLayoutImageExt.Controls.Add(panel4, 1, 0);
            tableLayoutImageExt.Dock = DockStyle.Fill;
            tableLayoutImageExt.Location = new Point(0, 24);
            tableLayoutImageExt.Name = "tableLayoutImageExt";
            tableLayoutImageExt.RowCount = 1;
            tableLayoutImageExt.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutImageExt.Size = new Size(518, 113);
            tableLayoutImageExt.TabIndex = 30;
            // 
            // flowPanelImageCheckboxes
            // 
            flowPanelImageCheckboxes.Dock = DockStyle.Fill;
            flowPanelImageCheckboxes.Location = new Point(0, 0);
            flowPanelImageCheckboxes.Margin = new Padding(0);
            flowPanelImageCheckboxes.Name = "flowPanelImageCheckboxes";
            flowPanelImageCheckboxes.Padding = new Padding(6, 4, 0, 0);
            flowPanelImageCheckboxes.Size = new Size(412, 113);
            flowPanelImageCheckboxes.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Orange;
            panel4.Controls.Add(btnDeselectImageExt);
            panel4.Controls.Add(btnSelectImageExt);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(415, 0);
            panel4.Margin = new Padding(3, 0, 3, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(100, 113);
            panel4.TabIndex = 2;
            // 
            // btnDeselectImageExt
            // 
            btnDeselectImageExt.BackColor = Color.Lavender;
            btnDeselectImageExt.Dock = DockStyle.Bottom;
            btnDeselectImageExt.FlatAppearance.BorderSize = 0;
            btnDeselectImageExt.FlatStyle = FlatStyle.Flat;
            btnDeselectImageExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDeselectImageExt.IconColor = Color.Black;
            btnDeselectImageExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeselectImageExt.Location = new Point(0, 81);
            btnDeselectImageExt.Name = "btnDeselectImageExt";
            btnDeselectImageExt.Size = new Size(100, 32);
            btnDeselectImageExt.TabIndex = 15;
            btnDeselectImageExt.Text = "Deselect all";
            btnDeselectImageExt.UseVisualStyleBackColor = false;
            btnDeselectImageExt.Click += btnDeselectImageExt_Click;
            // 
            // btnSelectImageExt
            // 
            btnSelectImageExt.BackColor = Color.Lavender;
            btnSelectImageExt.Dock = DockStyle.Top;
            btnSelectImageExt.FlatAppearance.BorderSize = 0;
            btnSelectImageExt.FlatStyle = FlatStyle.Flat;
            btnSelectImageExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSelectImageExt.IconColor = Color.Black;
            btnSelectImageExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectImageExt.Location = new Point(0, 0);
            btnSelectImageExt.Name = "btnSelectImageExt";
            btnSelectImageExt.Size = new Size(100, 32);
            btnSelectImageExt.TabIndex = 14;
            btnSelectImageExt.Text = "Select all";
            btnSelectImageExt.UseVisualStyleBackColor = false;
            btnSelectImageExt.Click += btnSelectImageExt_Click;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 29;
            lbl2.Text = "Image extensions:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightCyan;
            panel5.Controls.Add(flowLayoutPanel1);
            panel5.Controls.Add(lbl3);
            panel5.Controls.Add(cbFilterApply);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 373);
            panel5.Name = "panel5";
            panel5.Size = new Size(518, 137);
            panel5.TabIndex = 29;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cbEnableVideoFilter);
            flowLayoutPanel1.Controls.Add(cbEnableImageFilter);
            flowLayoutPanel1.Controls.Add(cbEnableScriptFilter);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 59);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(6, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(518, 78);
            flowLayoutPanel1.TabIndex = 36;
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
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(0, 34);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 25);
            lbl3.TabIndex = 35;
            lbl3.Text = "Toggle which filters to use:";
            // 
            // cbFilterApply
            // 
            cbFilterApply.AutoSize = true;
            cbFilterApply.BoxSize = 13;
            cbFilterApply.Dock = DockStyle.Top;
            cbFilterApply.HoverColor = Color.DeepSkyBlue;
            cbFilterApply.Location = new Point(0, 0);
            cbFilterApply.Name = "cbFilterApply";
            cbFilterApply.Padding = new Padding(3, 3, 3, 12);
            cbFilterApply.PaddingLeft = 12;
            cbFilterApply.Size = new Size(518, 34);
            cbFilterApply.TabIndex = 34;
            cbFilterApply.Text = "Also apply filter to custom list playback";
            cbFilterApply.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Salmon;
            panel6.Controls.Add(flowLayoutPanel2);
            panel6.Controls.Add(lbl4);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 516);
            panel6.Name = "panel6";
            panel6.Size = new Size(518, 137);
            panel6.TabIndex = 30;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(rbDateCreated);
            flowLayoutPanel2.Controls.Add(rbDateModified);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 18);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(6, 0, 0, 0);
            flowLayoutPanel2.Size = new Size(518, 119);
            flowLayoutPanel2.TabIndex = 33;
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
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(518, 18);
            lbl4.TabIndex = 32;
            lbl4.Text = "Change the behavior of the recent filter:";
            // 
            // FileExtensionsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "FileExtensionsUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutVideoExt.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutImageExt.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTipInfo;
        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private TableLayoutPanel tableLayoutVideoExt;
        private Label lbl1;
        private FlowLayoutPanel flowPanelVideoCheckboxes;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnSelectVideoExt;
        private FontAwesome.Sharp.IconButton btnDeselectVideoExt;
        private Panel panel3;
        private TableLayoutPanel tableLayoutImageExt;
        private Label lbl2;
        private FlowLayoutPanel flowPanelImageCheckboxes;
        private Panel panel4;
        private FontAwesome.Sharp.IconButton btnSelectImageExt;
        private Label label4;
        private FontAwesome.Sharp.IconButton btnDeselectImageExt;
        private Panel panel5;
        private Controls.CustomCheckBox cbFilterApply;
        private Label lbl3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.RoundedImageCheckBox cbEnableVideoFilter;
        private Controls.RoundedImageCheckBox cbEnableImageFilter;
        private Controls.RoundedImageCheckBox cbEnableScriptFilter;
        private Panel panel6;
        private Label lbl4;
        private FlowLayoutPanel flowLayoutPanel2;
        private Controls.CustomRadioButton rbDateCreated;
        private Controls.CustomRadioButton rbDateModified;
    }
}
