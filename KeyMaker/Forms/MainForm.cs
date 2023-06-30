using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SaaedCo.KeyMaker.Forms
{
    public partial class MainForm : Form
    {
        private static MainForm _instance = null;

        public static MainForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainForm();

                return _instance;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void GenerateKeyPairAndCsrButtonButton_Click(object sender, EventArgs e)
        {
            GenerateKeyPairForm.Instance.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GenerateKeyPairForm.Instance.Close();
        }

        private void IranTaxButton_Click(object sender, EventArgs e)
        {
            Process.Start(ConstantValues.IRAN_TAX_URL_IN_SAAED_WEBSITE);
        }
    }
}
