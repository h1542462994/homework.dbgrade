using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbGrade.SqlCreator.Services
{
    public class Replacer
    {
        public void DoReplace()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(App.Current.SourceStorage);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            int i = 0;

            foreach (FileInfo file in fileInfos)
            {
                string relativePath = Path.GetRelativePath(directoryInfo.FullName, file.FullName);
                string newFile = Path.Join(App.Current.TargetStorage, ReplaceAll(relativePath, relativePath));

                string content = File.ReadAllText(file.FullName);
                content = ReplaceAll(content, relativePath);

                File.WriteAllText(newFile, content);

                App.Current.Logger.Log($"已替换文件{i++}/{fileInfos.Length} {relativePath}");
            }

            App.Current.Logger.Log($"已完成替换文件，总计{fileInfos.Length}个文件");
        }

        public string ReplaceAll(string str, string fileContext)
        {
            Regex regex = new Regex("@{[a-zA-Z_][a-zA-Z_0-9]+}");
            HashSet<string> noAccurancs = new HashSet<string>();
            foreach (Match match in regex.Matches(str))
            {
                string varName = match.Value[2..^1];
                if (!App.Current.Settings.args.Keys.Contains(varName))
                {
                    noAccurancs.Add(varName);
                }
            }

            foreach (var item in App.Current.Settings.args)
            {
                str = str.Replace($"@{{{item.Key}}}", item.Value);
            }

            if (noAccurancs.Any())
            {
                foreach (string item in noAccurancs)
                {
                    App.Current.Logger.Log($"未出现的变量名{item} in ${fileContext}", LogLevel.Warning);
                }
            }

            return str;
        }

    }
}
