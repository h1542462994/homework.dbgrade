#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DbGrade.SqlCreator.Services
{
    public class AutoCopy
    {
        public Logger Logger => App.Current.Logger;


        public void DoCopy()
        {
            if (IsCopy)
            {
                Logger.Log($"你启用了autocopy选项，将会将source和target拷贝到{TargetUrl}目录下");
                try
                {
                    Directory.CreateDirectory(TargetUrl);
                    DirectoryInfo sourceDirectory = new DirectoryInfo(App.Current.SourceStorage);
                    foreach (var item in sourceDirectory.GetFiles("*.*", SearchOption.AllDirectories))
                    {
                        string target = Path.Join(TargetUrl, Path.GetRelativePath(App.Current.SourceStorage, item.FullName));
                        string? targetSuperDirectory = Path.GetDirectoryName(target);
                        Directory.CreateDirectory(targetSuperDirectory);
                        
                        File.Copy(item.FullName, target, true);
                    }
                    Logger.Log("已完成文件的自动拷贝");

                } catch(Exception e)
                {
                    Logger.Log($"在执行拷贝时出现异常,type = {e.GetType()},msg = {e.Message}",LogLevel.Error);
                }
            }
        }

        public bool IsCopy { get
            {
                bool copySettingValue = (bool)App.Current.Settings.options.GetValueOrDefault(SettingsOptions.AutoCopy, false);
                return copySettingValue == true;
            }
        }

        public string? TargetUrl { get
            {
                string? targetUrl = (string?)App.Current.Settings.options.GetValueOrDefault(SettingsOptions.AutoCopyTarget, "");
                return targetUrl;
            }
        }
    }
}
