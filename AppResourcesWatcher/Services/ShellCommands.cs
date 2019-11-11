using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AppResourcesWatcher.Services
{
    public class ShellCommands
    {
        public string ExecuteLinuxCommand(string fileCommand, string args)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileCommand,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return result;
        }
    }
}
