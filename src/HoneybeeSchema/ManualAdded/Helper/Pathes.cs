using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HoneybeeSchema.Helper
{
    public static class Pathes
    {
        public static bool IsMac => System.Environment.OSVersion.Platform == PlatformID.Unix;
        public static string ApplicationRoot => IsMac ?
          Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(typeof(SettingConfig).Assembly.Location))))) :
          Path.GetDirectoryName(typeof(SettingConfig).Assembly.Location);

        public static string UserAppData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ladybug_tools");
        public static string UserAppDataDotnet => Path.Combine(UserAppData, "dotnet");

        public static string SettingPath 
        { 
            get 
            {
                var file = Path.Combine(ApplicationRoot, "settings.txt");
                if (File.Exists(file))
                    return file;
                else // doesn't exist,
                {
                    //  check if directory is writable first
                    if (IsWriteable(file))
                    {
                        return file;
                    }
                    else
                    {
                        // if it is not writable then return user appdata folder
                        var podir = UserAppDataDotnet;
                        if (!Directory.Exists(podir))
                            Directory.CreateDirectory(podir);
                        file = Path.Combine(podir, "settings.txt");
                        return file;
                    }
                }
               

            } 
        } 

        private static string _ladybugToolsRootFolder = string.Empty;
        /// <summary>
        /// This will return the top main folder path of where ladybug_tools is.
        /// </summary>
        public static string LadybugToolsRootFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_ladybugToolsRootFolder))
                    _ladybugToolsRootFolder = GetLadybugToolsInstallationPath();
                return _ladybugToolsRootFolder;
            }
        }

        public static string PythonFolder => Path.Combine(LadybugToolsRootFolder, "python");

        /// <summary>
        /// This returns ladybug_tools/resources/standards/
        /// </summary>
        public static string ResourcesStandardsFolder => Path.Combine(LadybugToolsRootFolder, "resources", "standards");
        /// <summary>
        /// This returns ladybug_tools/resources/standards/honeybee_standards.
        /// </summary>
        public static string DefaultStandardsFolder => Path.Combine(ResourcesStandardsFolder, "honeybee_standards");

        internal static List<string> _DefaultLibJsons => new List<string>()
        {
            Path.Combine(DefaultStandardsFolder,"energy_default.json"),
            Path.Combine(DefaultStandardsFolder,"radiance_default.json")
        };

        public static string EnergyStandardsFolder => Path.Combine(ResourcesStandardsFolder, "honeybee_energy_standards");
        public static string BuildingVintagesFolder => Path.Combine(EnergyStandardsFolder, "programtypes_registry");
        public static string BuildingProgramTypesFolder => Path.Combine(EnergyStandardsFolder, "programtypes");
        public static string ConstructionsFolder => Path.Combine(EnergyStandardsFolder, "constructions");
        public static string ConstructionSetFolder => Path.Combine(EnergyStandardsFolder, "constructionsets");
        public static string ScheduleFolder => Path.Combine(EnergyStandardsFolder, "schedules");


        //BuildingVintages 2004, 2007, 2010, 2013, etc..
        private static IEnumerable<string> _buildingVintages;
        public static IEnumerable<string> BuildingVintages
        {
            get
            {
                _buildingVintages = _buildingVintages ?? Directory.GetFiles(BuildingVintagesFolder, "*.json");
                return _buildingVintages;
            }
        }


        // ladybug_tools\resources\standards\honeybee_energy_standards\programtypes\2013_data.json
        private static IEnumerable<string> _buildingTypeJsonFilePaths;
        public static IEnumerable<string> BuildingTypeJsonFilePaths
        {
            get
            {
                _buildingTypeJsonFilePaths = _buildingTypeJsonFilePaths ?? Directory.GetFiles(BuildingProgramTypesFolder, "*.json");
                return _buildingTypeJsonFilePaths;
            }
        }


        // ladybug_tools\resources\standards\honeybee_energy_standards\\constructionsets\2013_data.json
        private static IEnumerable<string> _constructionsetJsonFilePaths;
        public static IEnumerable<string> ConstructionsetJsonFilePaths
        {
            get
            {
                _constructionsetJsonFilePaths = _constructionsetJsonFilePaths ?? Directory.GetFiles(ConstructionSetFolder, "*.json");
                return _constructionsetJsonFilePaths;
            }
        }

        private static string GetLadybugToolsInstallationPath()
        {
            // Mac
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
            {
                // this only looking for Rhino 6 for now
                var args = $"defaults read com.mcneel.rhinoceros User.PlugInRegistry.6.8b32d89c-3455-4c21-8fd7-7364c32a6feb.PlugIn.FileName";

                var startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "/bin/bash";
                startInfo.Arguments = $"-c \"{args}\"";
                startInfo.RedirectStandardOutput = true;

                using (var exeProcess = new System.Diagnostics.Process())
                {
                    exeProcess.StartInfo = startInfo;
                    exeProcess.Start();
                    exeProcess.WaitForExit();
                    string outputs = exeProcess.StandardOutput.ReadToEnd().Trim();

                    if (string.IsNullOrEmpty(outputs))
                        throw new ArgumentException("Ladybug Tools is not installed on this machine!");

                    // "/Users/mingbo/ladybug_tools2/rhino/HoneybeeRhino.PlugIn.Mac.rhp"
                    outputs = outputs.Split(new[] { "rhino" }, StringSplitOptions.RemoveEmptyEntries).First();

                    if (!Directory.Exists(outputs))
                        throw new ArgumentException("Ladybug Tools is not installed on this machine!");

                    return outputs;
                }

            }
            else
            {
                // windows
                // check if there is a config in the folder
                var foundPath = SettingConfig.GetSavedSettings()?.LBTRootFolder;

                // find it from registry
                if (string.IsNullOrEmpty(foundPath) || !Directory.Exists(foundPath))
                    foundPath = GetLBTRootFromRegistry();

                // create a new ladybug_tools folder under ProgramFiles
                if (string.IsNullOrEmpty(foundPath) || !Directory.Exists(foundPath))
                {
                    var programFile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                    foundPath = Directory.GetDirectories(programFile, "*ladybug_tools*", SearchOption.TopDirectoryOnly).FirstOrDefault();
                    if (!Directory.Exists(foundPath))
                    {
                        foundPath = Path.Combine(programFile, "ladybug_tools");
                        Directory.CreateDirectory(foundPath);
                    }

                }

                if (!Directory.Exists(foundPath))
                    throw new ArgumentException($"Ladybug Tools is not installed on this machine! ({foundPath})");

                return foundPath;
            }



        }

        private static string GetLBTRootFromRegistry()
        {

            // windows
            var foundPath = string.Empty;
            var scr = @"/C REG QUERY HKEY_LOCAL_MACHINE\SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\UNINSTALL /s /v InstallLocation" + " | findstr \"ladybug_tools\"";
            //Registry.LocalMachine

            var stdout = new List<string>();
            using (var p = new System.Diagnostics.Process())
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = scr;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                //p.ErrorDataReceived += (s, m) => { if (m.Data != null) stdErr.Add(m.Data); };
                p.OutputDataReceived += (s, m) => { if (m.Data != null) stdout.Add(m.Data); };
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();

                p.WaitForExit();
                if (!p.HasExited)
                {
                    p.Kill();
                }

            }
            foundPath = stdout.LastOrDefault(_ => _.EndsWith("ladybug_tools"))?.Trim();
            if (!string.IsNullOrEmpty(foundPath))
            {
                // get from installer's registry
                // InstallLocation    REG_SZ    C:\Users\mingo\ladybug_tools test
                foundPath = foundPath.Split(new[] { "REG_SZ" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault(_ => _.EndsWith("ladybug_tools"))?.Trim();

            }

            return foundPath;
        }

        internal static bool IsWriteable(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    File.WriteAllText(filepath, "");
                    return true;
                }
              
                using (var fs = new FileStream(filepath, FileMode.Open))
                {
                    //var canRead = fs.CanRead;
                    var canWrite = fs.CanWrite;
                    return canWrite;
                }
            }
            catch (System.UnauthorizedAccessException)
            {
                return false;
            }

        }

    }
}
