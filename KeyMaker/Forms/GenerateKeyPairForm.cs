using SaaedCo.KeyMaker.Enums;
using SaaedCo.KeyMaker.Logic;
using SaaedCo.KeyMaker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SaaedCo.KeyMaker.Forms
{
    public partial class GenerateKeyPairForm : Form
    {
        const string CSR_FILE_NAME = "CSR.txt";
        const string PRIVATE_KEY_FILE_NAME = "کلید خصوصی.txt";
        const string PUBLIC_KEY_FILE_NAME = "کلید عمومی.txt";

        private static GenerateKeyPairForm _instance = null;

        public static GenerateKeyPairForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GenerateKeyPairForm();

                return _instance;
            }
        }

        public GenerateKeyPairForm()
        {
            InitializeComponent();
        }

        private void GenerateKeyPairForm_Load(object sender, EventArgs e)
        {
            ShowProperGroupBox();
            RealPersonTypeComboBox.SelectedIndex = 0;
            LegalPersonTypeComboBox.SelectedIndex = 0;
        }

        private void ShowProperGroupBox()
        {
            RealGroupBox.Visible = RealPersonRadioButton.Checked;
            LegalGroupBox.Visible = LegalPersonRadioButton.Checked;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (!CheckExistingFiles())
                    return;

                if (GenerateCsrAndKeies())
                {
                    Process.Start(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private bool GenerateCsrAndKeies()
        {
            try
            {
                var openSsl = new OpenSsl();

                if (LegalPersonRadioButton.Checked)
                {
                    GenerateCsrAndKeiesForLegalPerson(openSsl);
                }
                else
                {
                    GenerateCsrAndKeiesForRealPerson(openSsl);
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GenerateCsrAndKeiesForRealPerson(OpenSsl openSsl)
        {
            var personInfo = new RealPersonInfo()
            {
                PersonType = (RealPersonTypes)RealPersonTypeComboBox.SelectedIndex,
                EnglishFirstName = EnglishFirstNameTextBox.Text,
                PersianFirstName = PersianFirstNameTextBox.Text,
                EnglishLastName = EnglishLastNameTextBox.Text,
                PersianLastName = PersianLastNameTextBox.Text,
                NationalCode = NationalCodeTextBox.Text,
                PersianProvinceName = ProvinceNameTextBox.Text,
                PersianCityName = CityNameTextBox.Text,
                Email = LegalEmailTextBox.Text,
                PersianOrgName = RealOrgNameTextBox.Text,
                OrgUnit1 = LegalOrgUnit1TextBox.Text,
                OrgUnit2 = LegalOrgUnit2TextBox.Text,
                OrgUnit3 = LegalOrgUnit3TextBox.Text,
                OrgRole  = RoleInOrgTextBox.Text
            };

            openSsl.GenerateCsrAndKeies(personInfo, folderBrowserDialog.SelectedPath, GetFileNameForPerson(PRIVATE_KEY_FILE_NAME), GetFileNameForPerson(PUBLIC_KEY_FILE_NAME), GetFileNameForPerson(CSR_FILE_NAME));
        }

        private void GenerateCsrAndKeiesForLegalPerson(OpenSsl openSsl)
        {
            var personInfo = new LegalPersonInfo()
            {
                PersonType = (LagalPersonTypes)LegalPersonTypeComboBox.SelectedIndex,
                EnglishName = LegalEnglishNameTextBox.Text,
                PersianName = LegalPersianNameTextBox.Text,
                NationalIdentity = NationalIdentityTextBox.Text,
                OrgUnit1 = LegalOrgUnit1TextBox.Text,
                OrgUnit2 = LegalOrgUnit2TextBox.Text,
                OrgUnit3 = LegalOrgUnit3TextBox.Text,
                Email = LegalEmailTextBox.Text,
                PersianProvinceName = LegalProvinceNameTextBox.Text,
                PersianCityName = LegalCityNameTextBox.Text
            };

           openSsl.GenerateCsrAndKeies(personInfo, folderBrowserDialog.SelectedPath, GetFileNameForPerson(PRIVATE_KEY_FILE_NAME), GetFileNameForPerson(PUBLIC_KEY_FILE_NAME), GetFileNameForPerson(CSR_FILE_NAME));
        }

        private bool CheckExistingFiles()
        {
            var existingFileNames = new List<string>();

            if (File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, GetFileNameForPerson(CSR_FILE_NAME))))
            {
                existingFileNames.Add(GetFileNameForPerson(CSR_FILE_NAME));
            }

            if (File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, GetFileNameForPerson(PRIVATE_KEY_FILE_NAME))))
            {
                existingFileNames.Add(GetFileNameForPerson(PRIVATE_KEY_FILE_NAME));
            }

            if (File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, GetFileNameForPerson(PUBLIC_KEY_FILE_NAME))))
            {
                existingFileNames.Add(GetFileNameForPerson(PUBLIC_KEY_FILE_NAME));
            }

            if (existingFileNames.Any())
            {
                string message;
                if (existingFileNames.Count == 1)
                {
                    message = $"فایل {existingFileNames[0]} در مسیر انتخاب شده وجود دارد. آیا مطمئنید که می‌خواهید محتوای آن را رونویسی کنید؟";
                }
                else
                {
                    message = $"فایل‌های زیر در مسیر انتخاب شده وجود دارند. آیا مطمئنید که می‌خواهید محتوای آن‌ها را رونویسی کنید؟\n" +
                        string.Join("\n", existingFileNames);
                }

                if (MessageBox.Show(message, "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.No)
                    return false;
            }

            return true;
        }

        private void PersonTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProperGroupBox();
        }

        private void RealPersonTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeRealPersonRequiredFields();
        }

        private void ChangeRealPersonRequiredFields()
        {
            if (RealPersonTypeComboBox.SelectedIndex == (int)RealPersonTypes.Unaffiliated)
            {
                RealOrgNameTextBox.Enabled = false;
                RealOrgUnit1TextBox.Enabled = false;
                RealOrgUnit2TextBox.Enabled = false;
                RealOrgUnit3TextBox.Enabled = false;
                RoleInOrgTextBox.Enabled = false;
            }
            else
            {
                RealOrgNameTextBox.Enabled = true;
                RealOrgUnit1TextBox.Enabled = true;
                RealOrgUnit2TextBox.Enabled = true;
                RealOrgUnit3TextBox.Enabled = true;
                RoleInOrgTextBox.Enabled = true;
            }
        }

        private bool ValidateForm()
        {
            if (LegalPersonRadioButton.Checked)
            {
                return ValidateLegalPerson();
            }
            else
            {
                return ValidateRealPerson();
            }
        }

        private bool ValidateLegalPerson()
        {
            bool isValid = true;

            isValid = CheckRequiredTextBox(LegalPersianNameTextBox, "نام") && isValid;
            isValid = CheckRequiredTextBox(LegalEnglishNameTextBox, "نام") && isValid;
            isValid = CheckRequiredTextBox(NationalIdentityTextBox, "شناسه‌ی ملی") && isValid;
            isValid = CheckRequiredTextBox(LegalProvinceNameTextBox, "نام استان") && isValid;
            isValid = CheckRequiredTextBox(LegalCityNameTextBox, "نام شهرستان") && isValid;

            if (!string.IsNullOrEmpty(NationalIdentityTextBox.Text) && !Regex.IsMatch(NationalIdentityTextBox.Text, @"\d{11}"))
            {
                errorProvider.SetError(NationalIdentityTextBox, "شناسه‌ی ملی باید عددی به طول 11 رقم باشد");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateRealPerson()
        {
            bool isValid = true;

            isValid = CheckRequiredTextBox(NationalCodeTextBox, "کد ملی") && isValid;
            isValid = CheckRequiredTextBox(PersianFirstNameTextBox, "نام") && isValid;
            isValid = CheckRequiredTextBox(EnglishFirstNameTextBox, "نام") && isValid;
            isValid = CheckRequiredTextBox(PersianLastNameTextBox, "نام خانوادگی") && isValid;
            isValid = CheckRequiredTextBox(EnglishLastNameTextBox, "نام خانوادگی") && isValid;
            isValid = CheckRequiredTextBox(ProvinceNameTextBox, "نام استان") && isValid;
            isValid = CheckRequiredTextBox(CityNameTextBox, "نام شهرستان") && isValid;

            if (RealPersonTypeComboBox.SelectedIndex != (int)RealPersonTypes.Unaffiliated)
            {
                isValid = CheckRequiredTextBox(RealOrgNameTextBox, "نام شرکت یا سازمان") && isValid;
                isValid = CheckRequiredTextBox(RoleInOrgTextBox, "سمت در شرکت یا سازمان") && isValid;
            }
            else
            {
                errorProvider.SetError(RealOrgNameTextBox, null);
                errorProvider.SetError(RoleInOrgTextBox, null);
            }

            return isValid;
        }

        private bool CheckRequiredTextBox(TextBox textBox, string title)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, $"{title} را وارد کنید");
                return false;
            }
            else
            {
                errorProvider.SetError(textBox, null);
                return true;
            }
        }

        private void PersonTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ShowProperGroupBox();
        }

        private void IranTaxLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(ConstantValues.IRAN_TAX_URL_IN_SAAED_WEBSITE);
        }

        private void MainMenuLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.Instance.Show();
            Hide();
        }

        private void LogoPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start(ConstantValues.SAAED_WEBSITE);
        }

        private void OpenSslSettingsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var openSslSettingsForm = new OpenSslSettingsForm();
            openSslSettingsForm.ShowDialog();
        }

        private string GetPersonName()
        {
            if (LegalPersonRadioButton.Checked)
                return LegalPersianNameTextBox.Text;
            else
                return $"{PersianFirstNameTextBox.Text} {PersianLastNameTextBox.Text}";
        }

        private string GetFileNameForPerson(string fileName)
        {
            return $"{GetPersonName()}-{fileName}";
        }
    }
}
