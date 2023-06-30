using SaaedCo.KeyMaker.Forms;
using System;
using System.Windows.Forms;

namespace KeyMaker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GenerateKeyPairForm.Instance);
        }
    }
}
