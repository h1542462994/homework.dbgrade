
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DbGrade.SqlCreator.Services
{
    /// <summary>
    /// 系统支持的设置选项
    /// </summary>
    public static class SettingsOptions
    {
        /// <summary>
        /// 对应<see cref="Settings.options"/>的设置为autocopy的设置项。
        /// </summary>
        public static string AutoCopy => "autocopy";
        /// <summary>
        /// 对应<see cref="Settings.options"/>的设置为autocopy-target的设置项。
        /// </summary>
        public static string AutoCopyTarget => "autocopy-target";
    }

    public class Settings: IInitable
    {
        public Dictionary<string, string> args = new Dictionary<string, string>
        {
            { "full", "yumingyuan"},
            { "middle", "yumy" },
            { "short", "ymy" },
            { "no", "1" }
        };
        public Dictionary<string, object> options = new Dictionary<string, object>
        {
            { SettingsOptions.AutoCopy, false },
            { SettingsOptions.AutoCopyTarget, "" }
        };

        

        public void Init()
        {
            string ConfigPath = Path.Join(App.Current.DataStorage, @"config.json");
            if (!File.Exists(ConfigPath))
            {
                string value = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(ConfigPath, value);
            } else
            {
                string content = File.ReadAllText(ConfigPath);
                Settings settings = JsonConvert.DeserializeObject<Settings>(content);
                if(settings != null)
                {
                    args = settings.args;
                    options = settings.options;
                }
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(args, Formatting.Indented);
        }
    }
}
