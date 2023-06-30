using SaaedCo.KeyMaker.Models;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SaaedCo.KeyMaker.Logic
{
    public class OpenSsl
    {
		const string OPENSSL_FILENAME = "openssl.exe";
		const string CMD_FILENAME = "cmd.exe";

        public string GetOpenSslPath()
        {
            switch (Settings.OpenSslMode)
            {
                case Enums.OpenSslModes.SystemPath:
                    return "";
                    
                case Enums.OpenSslModes.CustomPath:
                    return Settings.Path;

                case Enums.OpenSslModes.ExePath:
                default:
                    return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "OpenSSL");
            }
        }

		public int Execute(string arguments, out string output, bool includeErrorsInOutput = true)
		{
			var command = $@"/c {OPENSSL_FILENAME} {arguments}";
            var processHelper = new ProcessHelper(CMD_FILENAME, command, GetOpenSslPath());
			var exitCode = processHelper.Run(out output, includeErrorsInOutput);
			return exitCode;
        }

        public void GenerateCsrAndKeies(string outputPath, string configFileName, string privateKeyFileName, string publicKeyFileName, string csrFileName)
		{
            var configFullFileName = Path.Combine(outputPath, configFileName);
            var csrFullFileName = Path.Combine(outputPath, csrFileName);
            var privateKeyFullFileName = Path.Combine(outputPath, privateKeyFileName);
            var publicKeyFullFileName = Path.Combine(outputPath, publicKeyFileName);

            if (File.Exists(csrFullFileName)) File.Delete(csrFullFileName);
            if (File.Exists(privateKeyFullFileName)) File.Delete(privateKeyFullFileName);
            if (File.Exists(publicKeyFullFileName)) File.Delete(publicKeyFullFileName);

            var exitCode = Execute($@"req -new -utf8 -nameopt multiline,utf8 -config ""{configFullFileName}"" -newkey rsa:2048 -nodes -keyout ""{privateKeyFullFileName}"" -out ""{csrFullFileName}""", out var output);
            
            if (exitCode != 0)
            {
                throw new Exception($"Error in generating private key. OpenSSL exited with code: {exitCode}\r\n{output}");
            }

            if (!File.Exists(privateKeyFullFileName))
                throw new Exception($"Error in generating private key\r\n{output}");

            if (!File.Exists(csrFullFileName))
                throw new Exception($"Error in generating CSR file\r\n{output}");

            exitCode = Execute($@"rsa -in ""{privateKeyFullFileName}"" -pubout > ""{publicKeyFullFileName}""", out output);
            if (exitCode != 0)
            {
                throw new Exception($"Error in extracting public key. OpenSSL exited with code: {exitCode}\r\n{output}");
            }

            if (!File.Exists(publicKeyFullFileName))
                throw new Exception($"Error in extracting public key\r\n{output}");
        }

		public void GenerateCsrAndKeies(LegalPersonInfo personInfo, string outputPath, string privateKeyFileName, string publicKeyFileName, string csrFileName)
		{
            var config = Gica.GetConfig(personInfo);
            GenerateCsrAndKeiesUsingConfig(config, outputPath, privateKeyFileName, publicKeyFileName, csrFileName);
        }

        public void GenerateCsrAndKeies(RealPersonInfo personInfo, string outputPath, string privateKeyFileName, string publicKeyFileName, string csrFileName)
        {
            var config = Gica.GetConfig(personInfo);
            GenerateCsrAndKeiesUsingConfig(config, outputPath, privateKeyFileName, publicKeyFileName, csrFileName);
        }

        public void GenerateCsrAndKeiesUsingConfig(string config, string outputPath, string privateKeyFileName, string publicKeyFileName, string csrFileName)
        {
            var configFileName = $"{Guid.NewGuid():N}.config";
            var randomPrivateKeyFileName = $"{Guid.NewGuid():N}.txt";
            var randomPublicKeyFileName = $"{Guid.NewGuid():N}.txt";
            var randomCsrFileName = $"{Guid.NewGuid():N}.txt";

            var configPathAndName = Path.Combine(outputPath, configFileName);
            var randomPrivateKeyFilePathAndName = Path.Combine(outputPath, randomPrivateKeyFileName);
            var randomPublicKeyFilePathAndName = Path.Combine(outputPath, randomPublicKeyFileName);
            var randomCsrFilePathAndName = Path.Combine(outputPath, randomCsrFileName);
            var realPrivateKeyFilePathAndName = Path.Combine(outputPath, privateKeyFileName);
            var realPublicKeyFilePathAndName = Path.Combine(outputPath, publicKeyFileName);
            var realCsrFilePathAndName = Path.Combine(outputPath, csrFileName);

            File.WriteAllText(configPathAndName, config, Encoding.UTF8);

            try
            {
                DeleteFileIfExists(realPrivateKeyFilePathAndName);
                DeleteFileIfExists(realPublicKeyFilePathAndName);
                DeleteFileIfExists(realCsrFilePathAndName);

                GenerateCsrAndKeies(outputPath, configFileName, randomPrivateKeyFilePathAndName, randomPublicKeyFilePathAndName, randomCsrFilePathAndName);

                RenameRandomFileIfExists(randomPrivateKeyFilePathAndName, realPrivateKeyFilePathAndName);
                RenameRandomFileIfExists(randomPublicKeyFilePathAndName, realPublicKeyFilePathAndName);
                RenameRandomFileIfExists(randomCsrFilePathAndName, realCsrFilePathAndName);
            }
            finally
            {
                File.Delete(configPathAndName);
                DeleteFileIfExists(randomPrivateKeyFilePathAndName);
                DeleteFileIfExists(randomPublicKeyFilePathAndName);
                DeleteFileIfExists(randomCsrFilePathAndName);
            }
        }

        private void RenameRandomFileIfExists(string randomFilePathAndName, string realFileName)
        {
            if (File.Exists(randomFilePathAndName))
            {
                File.Move(randomFilePathAndName, Path.Combine(Path.GetDirectoryName(randomFilePathAndName), realFileName));
            }
        }

        private void DeleteFileIfExists(string filePathAndName)
        {
            if (File.Exists(filePathAndName))
                File.Delete(filePathAndName);
        }
    }
}
