using System.Diagnostics;
using System.Text;

namespace SaaedCo.KeyMaker.Logic
{
    public class ProcessHelper
    {
        public event DataReceivedEventHandler ErrorDataReceived;
        public event DataReceivedEventHandler OutputDataReceived;

        public string FileName { get; set; }
        public string Arguments { get; set; }
        public string WorkingDirectory { get; set; }

        public ProcessHelper()
        {

        }

        public ProcessHelper(string fileName)
        {
            FileName = fileName;
        }

        public ProcessHelper(string fileName, string arguments)
        {
            FileName = fileName;
            Arguments = arguments;
        }

        public ProcessHelper(string fileName, string arguments, string workingDirectory)
        {
            FileName = fileName;
            Arguments = arguments;
            WorkingDirectory = workingDirectory;
        }

        private ProcessStartInfo GetProcessStartInfo()
        {
            return new ProcessStartInfo()
            {
                WorkingDirectory = WorkingDirectory,
                FileName = FileName,
                Arguments = Arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                LoadUserProfile = true
            };
        }

        public int Run()
        {
            using (var process = new Process())
            {
                process.StartInfo = GetProcessStartInfo();
                process.ErrorDataReceived += ErrorDataReceived;
                process.OutputDataReceived += OutputDataReceived;
                process.EnableRaisingEvents = true;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();

                return process.ExitCode;
            }
        }

        public int Run(out string output, bool includeErrorsInOutput)
        {
            using (var process = new Process())
            {
                var result = new StringBuilder();

                void DataReceived(object sender, DataReceivedEventArgs e)
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        result.AppendLine(e.Data);
                }

                process.StartInfo = GetProcessStartInfo();
                process.OutputDataReceived += DataReceived;
                if (includeErrorsInOutput) process.ErrorDataReceived += DataReceived;
                process.EnableRaisingEvents = true;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();

                output = result.ToString();
                return process.ExitCode;
            }
        }
    }
}
