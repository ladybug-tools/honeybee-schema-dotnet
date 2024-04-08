using System;
using System.Collections.Generic;
using System.IO;

namespace HoneybeeSchema.Helper
{
    public static class PythonCommand
    {
        public static bool ExePythonCommand(string argument, out string results)
        {
            results = string.Empty;
            var python = Path.GetFullPath(Path.Combine(Paths.PythonFolder, "python"));

            var stdout = new List<string>();
            var stdErr = new List<string>();
            using (var p = new System.Diagnostics.Process())
            {
                p.StartInfo.FileName = python;
                p.StartInfo.Arguments = argument;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.EnvironmentVariables["PYTHONHOME"] = "";
                p.Start();

                p.ErrorDataReceived += (s, m) => { if (m.Data != null) stdErr.Add(m.Data); };
                p.OutputDataReceived += (s, m) => { if (m.Data != null) stdout.Add(m.Data); };
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();

                p.WaitForExit();
                if (!p.HasExited)
                {
                    p.Kill();
                }

            }

            stdout.AddRange(stdErr);
            var msg = string.Join(System.Environment.NewLine, stdout);
            var cmd = $"Command:\n{python} {argument}";

            if (stdErr.Count > 0)
            {
                msg = $"{cmd}\n{msg}";
                throw new ArgumentException($"{cmd}\n{string.Join(System.Environment.NewLine, stdErr)}");
            }

            results = msg;
            return stdErr.Count == 0;
        }


    }
}