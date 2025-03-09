using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class DragDropUserControl : UserControl
    {
        private SettingsModel settings;
        public DragDropUserControl(SettingsModel settings)
        {
            InitializeComponent();

            UpdateDPIScaling();

            this.settings = settings;
            LoadSettings();
            BindControls();
        }

        private void LoadSettings()
        {
            if (settings.PlayOnDrop)
            {
                rbDropPlay.Checked = true;
            }
            else
            {
                rbDropQueue.Checked = true;
            }

            cbAlwaysAddFilesToQueue.Checked = settings.AlwaysAddFilesToQueue;

            cbIncludeSubdirectories.Checked = settings.IncludeSubdirectoriesDnD;
        }

        private void BindControls()
        {
            rbDropPlay.CheckedChanged += (s, e) =>
            {
                settings.PlayOnDrop = rbDropPlay.Checked;
            };

            cbAlwaysAddFilesToQueue.CheckedChanged += (s, e) =>
            {
                settings.AlwaysAddFilesToQueue = cbAlwaysAddFilesToQueue.Checked;
            };

            cbIncludeSubdirectories.CheckedChanged += (s, e) =>
            {
                settings.IncludeSubdirectoriesDnD = cbIncludeSubdirectories.Checked;
            };
        }

        private void UpdateDPIScaling()
        {
            this.MinimumSize = DPI.GetSizeScaled(this.MinimumSize);
            this.Size = DPI.GetSizeScaled(this.Size);

            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);
            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);

            panel1.Size = DPI.GetSizeScaled(panel1.Size);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);

            rbDropPlay.Size = DPI.GetSizeScaled(rbDropPlay.Size);
            rbDropPlay.Font = DPI.GetFontScaled(rbDropPlay.Font);


            rbDropQueue.Size = DPI.GetSizeScaled(rbDropQueue.Size);
            rbDropQueue.Font = DPI.GetFontScaled(rbDropQueue.Font);

            panel2.Size = DPI.GetSizeScaled(panel2.Size);

            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);

            lbl3.Size = DPI.GetSizeScaled(lbl3.Size);
            lbl3.Font = DPI.GetFontScaled(lbl3.Font);

            cbAlwaysAddFilesToQueue.Size = DPI.GetSizeScaled(cbAlwaysAddFilesToQueue.Size);
            cbAlwaysAddFilesToQueue.Font = DPI.GetFontScaled(cbAlwaysAddFilesToQueue.Font);

            panel3.Size = DPI.GetSizeScaled(panel3.Size);

            lbl4.Size = DPI.GetSizeScaled(lbl4.Size);
            lbl4.Font = DPI.GetFontScaled(lbl4.Font);

            cbIncludeSubdirectories.Size = DPI.GetSizeScaled(cbIncludeSubdirectories.Size);
            cbIncludeSubdirectories.Font = DPI.GetFontScaled(cbIncludeSubdirectories.Font);
        }

    }
}
