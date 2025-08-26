 
using System;
using System.IO;

namespace HoneybeeSchema.Helper
{
    public class SettingConfig
    {
        /// <summary>
        /// Set LBT root folder if you want to change default installation folder
        /// </summary>
        public string LBTRootFolder { get; set; }
        public static string SettingPath => Paths.SettingPath;
        public static string ApplicationRoot => Paths.ApplicationRoot;
        public SettingConfig()
        {
            this.LBTRootFolder = string.Empty;
        }

        public static SettingConfig GetSavedSettings()
        {
            SettingConfig settings = null;
            if (File.Exists(SettingPath))
            {
                var text = File.ReadAllText(SettingPath);
                settings = LBT.Newtonsoft.Json.JsonConvert.DeserializeObject<SettingConfig>(text);
            }
            // do nothing if the file doesn't exist
            // just return null
            return settings;
        }

        public bool SaveSettings()
        {
            string json = LBT.Newtonsoft.Json.JsonConvert.SerializeObject(this);
            File.WriteAllText(SettingPath, json);
            return File.Exists(SettingPath);
        }
    }

}
