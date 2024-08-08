namespace RandomVideoPlayer.UserControls
{
    partial class InterfaceUserControl
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
            label5 = new Label();
            panel1 = new Panel();
            cbSourceSelector = new Controls.RoundedCheckBox();
            flowPanel = new FlowLayoutPanel();
            cbListAddButton = new Controls.RoundedCheckBox();
            cbMoveToButton = new Controls.RoundedCheckBox();
            cbLoopButton = new Controls.RoundedCheckBox();
            cbShuffleButton = new Controls.RoundedCheckBox();
            cbAddToFavButton = new Controls.RoundedCheckBox();
            cbListRemoveButton = new Controls.RoundedCheckBox();
            cbDeleteButton = new Controls.RoundedCheckBox();
            panelButtonPreview = new Panel();
            btnRestore = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panelButtonPreview.SuspendLayout();
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
            label1.Size = new Size(440, 55);
            label1.TabIndex = 2;
            label1.Text = "Interface";
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 55);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(440, 62);
            label5.TabIndex = 3;
            label5.Text = "You can customize which buttons should be visible at all times. \r\nNote: Shortcuts will work regardless!";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Controls.Add(cbSourceSelector);
            panel1.Controls.Add(flowPanel);
            panel1.Controls.Add(cbListAddButton);
            panel1.Controls.Add(cbMoveToButton);
            panel1.Controls.Add(cbLoopButton);
            panel1.Controls.Add(cbShuffleButton);
            panel1.Controls.Add(cbAddToFavButton);
            panel1.Controls.Add(cbListRemoveButton);
            panel1.Controls.Add(cbDeleteButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 117);
            panel1.Name = "panel1";
            panel1.Size = new Size(440, 337);
            panel1.TabIndex = 4;
            // 
            // cbSourceSelector
            // 
            cbSourceSelector.Appearance = Appearance.Button;
            cbSourceSelector.BackColor = Color.Transparent;
            cbSourceSelector.CheckedBackColor = Color.PaleGreen;
            cbSourceSelector.FlatAppearance.BorderSize = 0;
            cbSourceSelector.FlatStyle = FlatStyle.Flat;
            cbSourceSelector.Location = new Point(12, 241);
            cbSourceSelector.Margin = new Padding(12, 3, 3, 3);
            cbSourceSelector.Name = "cbSourceSelector";
            cbSourceSelector.Size = new Size(168, 28);
            cbSourceSelector.TabIndex = 9;
            cbSourceSelector.Text = "Source Selector";
            cbSourceSelector.UncheckedBackColor = Color.LightGray;
            cbSourceSelector.UseVisualStyleBackColor = false;
            // 
            // flowPanel
            // 
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.Location = new Point(186, 0);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(117, 278);
            flowPanel.TabIndex = 8;
            // 
            // cbListAddButton
            // 
            cbListAddButton.Appearance = Appearance.Button;
            cbListAddButton.BackColor = Color.Transparent;
            cbListAddButton.CheckedBackColor = Color.PaleGreen;
            cbListAddButton.FlatAppearance.BorderSize = 0;
            cbListAddButton.FlatStyle = FlatStyle.Flat;
            cbListAddButton.Location = new Point(12, 71);
            cbListAddButton.Margin = new Padding(12, 3, 3, 3);
            cbListAddButton.Name = "cbListAddButton";
            cbListAddButton.Size = new Size(168, 28);
            cbListAddButton.TabIndex = 6;
            cbListAddButton.Text = "Add to list";
            cbListAddButton.UncheckedBackColor = Color.LightGray;
            cbListAddButton.UseVisualStyleBackColor = false;
            // 
            // cbMoveToButton
            // 
            cbMoveToButton.Appearance = Appearance.Button;
            cbMoveToButton.BackColor = Color.Transparent;
            cbMoveToButton.CheckedBackColor = Color.PaleGreen;
            cbMoveToButton.FlatAppearance.BorderSize = 0;
            cbMoveToButton.FlatStyle = FlatStyle.Flat;
            cbMoveToButton.Location = new Point(12, 139);
            cbMoveToButton.Margin = new Padding(12, 3, 3, 3);
            cbMoveToButton.Name = "cbMoveToButton";
            cbMoveToButton.Size = new Size(168, 28);
            cbMoveToButton.TabIndex = 5;
            cbMoveToButton.Text = "Move/Copy to folder";
            cbMoveToButton.UncheckedBackColor = Color.LightGray;
            cbMoveToButton.UseVisualStyleBackColor = false;
            // 
            // cbLoopButton
            // 
            cbLoopButton.Appearance = Appearance.Button;
            cbLoopButton.BackColor = Color.Transparent;
            cbLoopButton.CheckedBackColor = Color.PaleGreen;
            cbLoopButton.FlatAppearance.BorderSize = 0;
            cbLoopButton.FlatStyle = FlatStyle.Flat;
            cbLoopButton.Location = new Point(12, 207);
            cbLoopButton.Margin = new Padding(12, 3, 3, 3);
            cbLoopButton.Name = "cbLoopButton";
            cbLoopButton.Size = new Size(168, 28);
            cbLoopButton.TabIndex = 4;
            cbLoopButton.Text = "Toggle loop";
            cbLoopButton.UncheckedBackColor = Color.LightGray;
            cbLoopButton.UseVisualStyleBackColor = false;
            // 
            // cbShuffleButton
            // 
            cbShuffleButton.Appearance = Appearance.Button;
            cbShuffleButton.BackColor = Color.Transparent;
            cbShuffleButton.CheckedBackColor = Color.PaleGreen;
            cbShuffleButton.FlatAppearance.BorderSize = 0;
            cbShuffleButton.FlatStyle = FlatStyle.Flat;
            cbShuffleButton.Location = new Point(12, 173);
            cbShuffleButton.Margin = new Padding(12, 3, 3, 3);
            cbShuffleButton.Name = "cbShuffleButton";
            cbShuffleButton.Size = new Size(168, 28);
            cbShuffleButton.TabIndex = 3;
            cbShuffleButton.Text = "Toggle shuffle";
            cbShuffleButton.UncheckedBackColor = Color.LightGray;
            cbShuffleButton.UseVisualStyleBackColor = false;
            // 
            // cbAddToFavButton
            // 
            cbAddToFavButton.Appearance = Appearance.Button;
            cbAddToFavButton.BackColor = Color.Transparent;
            cbAddToFavButton.CheckedBackColor = Color.PaleGreen;
            cbAddToFavButton.FlatAppearance.BorderSize = 0;
            cbAddToFavButton.FlatStyle = FlatStyle.Flat;
            cbAddToFavButton.Location = new Point(12, 105);
            cbAddToFavButton.Margin = new Padding(12, 3, 3, 3);
            cbAddToFavButton.Name = "cbAddToFavButton";
            cbAddToFavButton.Size = new Size(168, 28);
            cbAddToFavButton.TabIndex = 2;
            cbAddToFavButton.Text = "Add to favorites";
            cbAddToFavButton.UncheckedBackColor = Color.LightGray;
            cbAddToFavButton.UseVisualStyleBackColor = false;
            // 
            // cbListRemoveButton
            // 
            cbListRemoveButton.Appearance = Appearance.Button;
            cbListRemoveButton.BackColor = Color.Transparent;
            cbListRemoveButton.CheckedBackColor = Color.PaleGreen;
            cbListRemoveButton.FlatAppearance.BorderSize = 0;
            cbListRemoveButton.FlatStyle = FlatStyle.Flat;
            cbListRemoveButton.Location = new Point(12, 37);
            cbListRemoveButton.Margin = new Padding(12, 3, 3, 3);
            cbListRemoveButton.Name = "cbListRemoveButton";
            cbListRemoveButton.Size = new Size(168, 28);
            cbListRemoveButton.TabIndex = 1;
            cbListRemoveButton.Text = "Remove from list";
            cbListRemoveButton.UncheckedBackColor = Color.LightGray;
            cbListRemoveButton.UseVisualStyleBackColor = false;
            // 
            // cbDeleteButton
            // 
            cbDeleteButton.Appearance = Appearance.Button;
            cbDeleteButton.BackColor = Color.Transparent;
            cbDeleteButton.CheckedBackColor = Color.PaleGreen;
            cbDeleteButton.FlatAppearance.BorderSize = 0;
            cbDeleteButton.FlatStyle = FlatStyle.Flat;
            cbDeleteButton.Location = new Point(12, 3);
            cbDeleteButton.Margin = new Padding(12, 3, 3, 3);
            cbDeleteButton.Name = "cbDeleteButton";
            cbDeleteButton.Size = new Size(168, 28);
            cbDeleteButton.TabIndex = 0;
            cbDeleteButton.Text = "Delete current file";
            cbDeleteButton.UncheckedBackColor = Color.LightGray;
            cbDeleteButton.UseVisualStyleBackColor = false;
            // 
            // panelButtonPreview
            // 
            panelButtonPreview.Controls.Add(btnRestore);
            panelButtonPreview.Dock = DockStyle.Fill;
            panelButtonPreview.Location = new Point(0, 454);
            panelButtonPreview.Name = "panelButtonPreview";
            panelButtonPreview.Size = new Size(440, 36);
            panelButtonPreview.TabIndex = 5;
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
            btnRestore.Location = new Point(3, 6);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(146, 27);
            btnRestore.TabIndex = 5;
            btnRestore.Text = "Restore Defaults";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // InterfaceUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelButtonPreview);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(label1);
            Name = "InterfaceUserControl";
            Size = new Size(440, 490);
            panel1.ResumeLayout(false);
            panelButtonPreview.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label5;
        private Panel panel1;
        private Controls.RoundedCheckBox cbDeleteButton;
        private Controls.RoundedCheckBox cbListRemoveButton;
        private Controls.RoundedCheckBox cbLoopButton;
        private Controls.RoundedCheckBox cbShuffleButton;
        private Controls.RoundedCheckBox cbAddToFavButton;
        private Panel panelButtonPreview;
        private Controls.RoundedCheckBox cbMoveToButton;
        private Controls.RoundedCheckBox cbListAddButton;
        private FlowLayoutPanel flowPanel;
        private Controls.RoundedCheckBox cbSourceSelector;
        private FontAwesome.Sharp.IconButton btnRestore;
    }
}
