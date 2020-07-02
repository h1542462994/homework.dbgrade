
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DbGrade.SqlCreator.Services
{
    public class Settings: IInitable
    {
        public Dictionary<string, string> args = new Dictionary<string, string>
        {
            { "full", "yumingyuan"},
            { "middle", "yumy" },
            { "short", "ymy" },
            { "no", "1" }
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
                }
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(args, Formatting.Indented);
        }
    }
}
