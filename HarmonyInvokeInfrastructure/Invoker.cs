using System;
using System.Diagnostics;
using System.IO;

namespace HarmonyInvokeInfrastructure
{
    public static class Invoker
    {
        public const string exe = "HarmonyCart";
        public static string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string HarmonyPath = Path.Combine(BasePath, "Harmony");

        public static string RomsPath = Path.Combine(HarmonyPath, "ROMS");
        public static string ExePath = Path.Combine(HarmonyPath, exe);

        public static string Load(string rom, string bankswitchCode) {

            var arguments = $"-bs={bankswitchCode} \"{RomsPath}\\{rom}.BIN\"";
            var command = $"{ExePath}";

            var processInfo = new ProcessStartInfo(command, arguments);
            //}
            //    //RedirectStandardOutput = true,
            //    //RedirectStandardError = true,
            //    UseShellExecute = false,
            //    CreateNoWindow = true                
            //};
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            //var process = new Process() {
            //    //EnableRaisingEvents = true,
            //    StartInfo = processInfo,                
            //};

            var process = Process.Start(processInfo);

            string output = "";
            //process.OutputDataReceived += (sender, e) => { var outputX = e.Data; output = outputX; };

            //string error = "";
            //process.ErrorDataReceived += (sender, e) => { var errorX = e.Data; error = errorX; };

            //process.Start();

            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();

            process.WaitForExit();
            //process.Close();

            return output; // !string.IsNullOrWhiteSpace(error) ? error : output;
        }
    }
}
