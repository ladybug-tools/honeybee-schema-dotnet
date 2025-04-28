extern alias LBTNewtonSoft; using System;
using System.IO;

namespace HoneybeeSchema.Helper
{
    public static class PythonCommand
    {
        public static bool ExePythonCommand(string argument, bool silentMode, out string results)
        {
            if (ExeCommandHandler == null)
                throw new ArgumentNullException("Set PythonCommand.ExeCommandHandler first!");
            var python = Path.GetFullPath(Path.Combine(Paths.PythonFolder, "python"));

            return ExeCommandHandler(python, argument, silentMode, out results);
        }

        public delegate bool ExeCommandFunc(string program, string arg, bool silentMode, out string results);

        public static ExeCommandFunc ExeCommandHandler = null;

    }
}