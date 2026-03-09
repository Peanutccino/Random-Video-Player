using FontAwesome.Sharp;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomVideoPlayer.UserControls
{
    public partial class ProfilesUserControl : UserControl
    {

        private SettingsModel settings;
        private Color _textColor;
        private Color _backColorDark;
        private Color _highlightColor;

        private Color HoverColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 60);
        private Color PressedColor(IconButton btn) => ThemeHelper.Lighten(idleColors[btn], _highlightColor, 20);

        private readonly Dictionary<IconButton, Color> idleColors = new();
        public ProfilesUserControl(SettingsModel settings)
        {
            InitializeComponent();

            this.settings = settings;

            DPI.UpdateDPIScaling(this);
            InitializeUI();
            LoadSettings();
        }

        private void InitializeUI()
        {
            ThemeManager.ApplyThemeSettings(this);

            _textColor = ThemeManager.CurrentTheme.StTextColor;
            _backColorDark = ThemeManager.CurrentTheme.StBackColorDark;
            _highlightColor = ThemeManager.CurrentTheme.StHighlightColor;

            WireIconButton(btnAdd);
            WireIconButton(btnDelete);
            WireIconButton(btnRename);
            WireIconButton(btnSetProfile);
        }
        private void WireIconButton(IconButton btn)
        {
            btn.FlatAppearance.MouseOverBackColor = _backColorDark;
            btn.FlatAppearance.MouseDownBackColor = _backColorDark;
            btn.BackColor = _backColorDark;

            idleColors[btn] = _textColor;
            btn.IconColor = _textColor;
            btn.ForeColor = _textColor;

            btn.MouseEnter += (_, _) =>
            {
                btn.IconColor = HoverColor(btn);
                btn.ForeColor = HoverColor(btn);
            };
            btn.MouseLeave += (_, _) =>
            {
                btn.IconColor = idleColors[btn];
                btn.ForeColor = idleColors[btn];
            };
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    btn.IconColor = PressedColor(btn);
                    btn.ForeColor = PressedColor(btn);
                }                    
            };
            btn.MouseUp += (_, _) =>
            {
                btn.IconColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn)
                    : idleColors[btn];
                btn.ForeColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn)
                    : idleColors[btn];
            };
            btn.GotFocus += (_, _) =>
            {
                btn.IconColor = HoverColor(btn);
                btn.ForeColor = HoverColor(btn);
            };
            btn.LostFocus += (_, _) =>
            {
                btn.IconColor = idleColors[btn];
                btn.ForeColor = idleColors[btn];
            };
        }
        private void LoadSettings()
        {
            lblProfile.Text = settings.SelectedProfile;

            lbProfiles.Items.Clear();

            foreach (var profile in settings.ProfileList)
            {
                lbProfiles.Items.Add(profile);
            }

            ButtonStates();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var profileCount = lbProfiles.Items.Count;
            var newProfileName = "PreferredScripts_Profile-" + (profileCount + 1);

            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new profile name:", "Rename Profile", newProfileName);
            if (!string.IsNullOrWhiteSpace(input))
            {
                try
                {
                    File.Create(Path.Combine(PathHandler.PathToListFolder, input + ".json")).Close();
                }
                catch (Exception ex)
                {
                    Error.Log(ex, $"Couldn't create new profile file: {ex}", LogLevel.Error);
                }
            }

            settings.ProfileList = SettingsHandler.ScriptProfileList;

            LoadSettings();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbProfiles.SelectedItem != null)
            {
                var profileName = lbProfiles.SelectedItem.ToString();

                DialogResult resultConfirmation = MessageBox.Show("Do you really want to delete the profile '" + profileName + "'?", "Confirm deletion", MessageBoxButtons.YesNo);

                if (resultConfirmation == DialogResult.Yes)
                {
                    var profileFilePath = Path.Combine(PathHandler.PathToListFolder, profileName + ".json");
                    try
                    {
                        if (File.Exists(profileFilePath))
                        {
                            File.Delete(profileFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, $"Couldn't delete profile file: {ex}", LogLevel.Error);
                    }

                    if (profileName == settings.SelectedProfile)
                    {
                        if (settings.ProfileList.Count > 0)
                        {
                            settings.SelectedProfile = settings.ProfileList[0];
                        }
                        else
                        {
                            settings.SelectedProfile = string.Empty;
                        }
                    }
                }

                settings.ProfileList = SettingsHandler.ScriptProfileList;

                LoadSettings();
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (lbProfiles.SelectedItem != null)
            {
                var oldProfileName = lbProfiles.SelectedItem.ToString();
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new profile name:", "Rename Profile", oldProfileName);
                if (!string.IsNullOrWhiteSpace(input))
                {
                    var oldProfileFilePath = Path.Combine(PathHandler.PathToListFolder, oldProfileName + ".json");
                    var newProfileFilePath = Path.Combine(PathHandler.PathToListFolder, input + ".json");
                    try
                    {
                        if (File.Exists(oldProfileFilePath))
                        {
                            File.Move(oldProfileFilePath, newProfileFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, $"Couldn't rename profile file: {ex}", LogLevel.Error);
                    }
                }
                settings.ProfileList = SettingsHandler.ScriptProfileList;

                if (oldProfileName == settings.SelectedProfile)
                {
                    settings.SelectedProfile = input;
                }

                LoadSettings();
            }
        }

        private void btnSetProfile_Click(object sender, EventArgs e)
        {
            if (lbProfiles.SelectedItem != null)
            {
                var selectedProfile = lbProfiles.SelectedItem.ToString();
                settings.SelectedProfile = selectedProfile;
                lblProfile.Text = settings.SelectedProfile;
            }
        }

        private void lbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonStates();
        }
        private void ButtonStates()
        {
            if (lbProfiles.SelectedItem != null)
            {
                btnDelete.Enabled = true;
                btnRename.Enabled = true;
                btnSetProfile.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnRename.Enabled = false;
                btnSetProfile.Enabled = false;
            }
        }
    }
}
