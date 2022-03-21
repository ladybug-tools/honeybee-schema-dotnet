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
        public static string SettingPath => Pathes.SettingPath;
        public static string ApplicationRoot => Pathes.ApplicationRoot;
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
                settings = Newtonsoft.Json.JsonConvert.DeserializeObject<SettingConfig>(text);
            }
            else
            {
                settings = new SettingConfig();
                //settings.LBTRootFolder = @"C:\Users\mingo\ladybug_tools_revit";
                settings.SaveSettings();
            }

            return settings;
        }

        public bool SaveSettings()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            File.WriteAllText(SettingPath, json);
            return File.Exists(SettingPath);
        }
    }

}
