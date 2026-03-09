using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;

namespace RandomVideoPlayer.UserControls
{
    public partial class SkipUserControl : UserControl
    {
        private SettingsModel settings;
        public SkipUserControl(SettingsModel settings)
        {
            InitializeComponent();

            DPI.UpdateDPIScaling(this);

            this.settings = settings;
            InitializeUI();
            BindControls();
            LoadSettings();
        }
        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);
        }
        private void LoadSettings()
        {
            cbEnableSkip.Checked = settings.EnableAutoSkip;
            cbSkipVideoStart.Checked = settings.SkipVideoStart;
            cbSkipAlways.Checked = settings.SkipAlways;
            inputSkipGapLength.Value = settings.AutoSkipSeconds;
            cbRandomStartPoint.Checked = settings.EnableRandomVideoStartPoint;
            cbRandomVideoStartPointIgnoreScripts.Checked = settings.RandomVideoStartPointIgnoreScripts;
            cbIgnoreStartPointThreshold.Checked = settings.RandomVideoStartPointIgnoreShortVideos;
            inputThresholdStartPoint.Value = settings.RandomVideoStartPointShortVideoThreshold;
            sliderTimeRange.StartValue = settings.StartPointRangeStart;
            sliderTimeRange.EndValue = settings.StartPointRangeEnd;
        }
        private void BindControls()
        {
            cbEnableSkip.CheckedChanged += (s, e) =>
            {
                settings.EnableAutoSkip = cbEnableSkip.Checked;
            };
            cbSkipVideoStart.CheckedChanged += (s, e) =>
            {
                settings.SkipVideoStart = cbSkipVideoStart.Checked;
            };
            cbSkipAlways.CheckedChanged += (s, e) =>
            {
                settings.SkipAlways = cbSkipAlways.Checked;
            };
            inputSkipGapLength.ValueChanged += (s, e) =>
            {
                settings.AutoSkipSeconds = inputSkipGapLength.Value;
            };
            cbRandomStartPoint.CheckedChanged += (s, e) =>
            {
                settings.EnableRandomVideoStartPoint = cbRandomStartPoint.Checked;
            };
            cbRandomVideoStartPointIgnoreScripts.CheckedChanged += (s, e) =>
            {
                settings.RandomVideoStartPointIgnoreScripts = cbRandomVideoStartPointIgnoreScripts.Checked;
            };
            cbIgnoreStartPointThreshold.CheckedChanged += (s, e) =>
            {
                settings.RandomVideoStartPointIgnoreShortVideos = cbIgnoreStartPointThreshold.Checked;
            };
            inputThresholdStartPoint.ValueChanged += (s, e) =>
            {
                settings.RandomVideoStartPointShortVideoThreshold = inputThresholdStartPoint.Value;
            };
            sliderTimeRange.RangeChanged += (s, e) =>
            {
                lblStart.Text = $"{sliderTimeRange.StartValue} %";
                lblEnd.Text = $"{sliderTimeRange.EndValue} %";

                settings.StartPointRangeStart = sliderTimeRange.StartValue;
                settings.StartPointRangeEnd = sliderTimeRange.EndValue;
            };
        }
    }
}
