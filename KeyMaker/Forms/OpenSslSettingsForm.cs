using SaaedCo.KeyMaker.Logic;
using System;
using System.IO;
using System.Windows.Forms;

namespace SaaedCo.KeyMaker.Forms
{
    public partial class OpenSslSettingsForm : Form
    {
        private string selectedPath;
        private bool fireCustomPathRadioButtonClickEvent = false;

        public OpenSslSettingsForm()
        {
            InitializeComponent();
        }

        private void OpenSslSettingsForm_Load(object sender, EventArgs e)
        {
            ShowCurrentSettings();
        }

        private void ShowCurrentSettings()
        {
            CustomPathLabel.Text = Settings.Path;
            selectedPath = Settings.Path;
            SelectProperOpenSslModeRadioButtonBasedOnSettings();

            fireCustomPathRadioButtonClickEvent = true;
        }

        private void SelectProperOpenSslModeRadioButtonBasedOnSettings()
        {
            switch (Settings.OpenSslMode)
            {
                case Enums.OpenSslModes.SystemPath:
                    SystemPathRadioButton.Checked = true;
                    break;

                case Enums.OpenSslModes.CustomPath:
                    CustomPathRadioButton.Checked = true;
                    break;

                case Enums.OpenSslModes.ExePath:
                default:
                    ExePathRadioButton.Checked = true;
                    break;
            }
        }

        private void CustomPathRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fireCustomPathRadioButtonClickEvent && CustomPathRadioButton.Checked)
            {
                if (!string.IsNullOrWhiteSpace(selectedPath))
                {
                    openFileDialog.FileName = Path.Combine(selectedPath, "openssl.exe");
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = Path.GetDirectoryName(openFileDialog.FileName);
                    CustomPathLabel.Text = selectedPath;
                }
                else
                {
                    SelectProperOpenSslModeRadioButtonBasedOnSettings();
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (SystemPathRadioButton.Checked)
            {
                selectedPath = null;
                Settings.OpenSslMode = Enums.OpenSslModes.SystemPath;
            }
            else if (ExePathRadioButton.Checked)
            {
                selectedPath = null;
                Settings.OpenSslMode = Enums.OpenSslModes.ExePath;
            }
            else
            {
                Settings.OpenSslMode = Enums.OpenSslModes.CustomPath;
            }

            Settings.Path = selectedPath;

            Settings.Save();
            Close();
        }

        private void CancelChangesButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
