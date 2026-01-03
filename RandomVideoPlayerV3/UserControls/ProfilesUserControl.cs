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
        public ProfilesUserControl(SettingsModel settings)
        {
            InitializeComponent();

            this.settings = settings;

            UpdateDPIScaling();

            LoadSettings();
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
                    Error.Log(ex, $"Couldn't create new profile file: {ex}");
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
                        Error.Log(ex, $"Couldn't delete profile file: {ex}");
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
                        Error.Log(ex, $"Couldn't rename profile file: {ex}");
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
        private void UpdateDPIScaling()
        {
            this.Size = DPI.GetSizeScaled(this.Size);

            panel1.Size = DPI.GetSizeScaled(panel1.Size);
            panel2.Size = DPI.GetSizeScaled(panel2.Size);

            lblHeader.Font = DPI.GetFontScaled(lblHeader.Font);
            lblHeader.Size = DPI.GetSizeScaled(lblHeader.Size);

            lbl1.Size = DPI.GetSizeScaled(lbl1.Size);
            lbl1.Font = DPI.GetFontScaled(lbl1.Font);
            lbl2.Size = DPI.GetSizeScaled(lbl2.Size);
            lbl2.Font = DPI.GetFontScaled(lbl2.Font);
            lblProfile.Size = DPI.GetSizeScaled(lblProfile.Size);
            lblProfile.Font = DPI.GetFontScaled(lblProfile.Font);

            lbProfiles.Font = DPI.GetFontScaled(lbProfiles.Font);

            btnAdd.Size = DPI.GetSizeScaled(btnAdd.Size);
            btnAdd.Font = DPI.GetFontScaled(btnAdd.Font);
            btnDelete.Size = DPI.GetSizeScaled(btnDelete.Size);
            btnDelete.Font = DPI.GetFontScaled(btnDelete.Font);
            btnRename.Size = DPI.GetSizeScaled(btnRename.Size);
            btnRename.Font = DPI.GetFontScaled(btnRename.Font);
            btnSetProfile.Size = DPI.GetSizeScaled(btnSetProfile.Size);
            btnSetProfile.Font = DPI.GetFontScaled(btnSetProfile.Font);
        }
    }
}
