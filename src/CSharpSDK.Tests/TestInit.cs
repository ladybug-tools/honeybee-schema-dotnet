
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.IO.Compression;

namespace HoneybeeSchema.Test
{
    [SetUpFixture]
    public class TestInit
    {

        [OneTimeSetUp]
        public void Init()
        {
            // download openstudio standard library

            //var resource = Helper.EnergyLibrary.ResourcesStandardsFolder;
            var temp = Path.GetTempPath();
            var opsFolder = Helper.EnergyLibrary.EnergyStandardsFolder;
            if (Directory.Exists(opsFolder))
                return;

            var releaseJson = "https://api.github.com/repos/ladybug-tools/honeybee-energy-standards/releases/latest";
            using (var wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", "request");
                //wc.Headers.Add("Accept", "application/vnd.github.v3+json");
                var json = wc.DownloadString(releaseJson);

                var obj = LBT.Newtonsoft.Json.Linq.JObject.Parse(json);
                var zipUrl = obj["zipball_url"].ToString();

                var zipfile = Path.Combine(temp, "standard.zip");
                wc.Headers.Add("User-Agent", "request");
                //wc2.Headers.Add("Accept", "application/octet-stream");
                wc.DownloadFile(zipUrl, zipfile);

                if (File.Exists(zipfile))
                {
                    var target = Path.Combine(temp, Guid.NewGuid().ToString().Substring(0,5));
                    ZipFile.ExtractToDirectory(zipfile, target);
                    var subFolder = Directory.GetDirectories(target, "*", SearchOption.TopDirectoryOnly)[0]; // ladybug-tools-honeybee-energy-standards-f5fa5d9
                    var energyStandard = Path.Combine(subFolder, "honeybee_energy_standards");
                    DirectoryCopy(energyStandard, opsFolder, true);


                }
            }

        }

        // https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}
