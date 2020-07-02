using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DbGrade.SqlCreator.Services;

namespace DbGrade.SqlCreator
{
    public class App: IInitable { 

        
        private App()
        {

        }
        public static App Current { get; private set; }
        public Logger Logger { get; } = new Logger();
        public Settings Settings { get; } = new Settings();
        public static void Create()
        {
            Current = new App();
        }

        public string DataStorage => AppDomain.CurrentDomain.BaseDirectory + @"\data";
        public string SourceStorage => Path.Join(DataStorage, @"\source");
        public string TargetStorage => Path.Join(DataStorage, @"\target");


        public void Init()
        {
            Directory.CreateDirectory(DataStorage);
            Directory.CreateDirectory(SourceStorage);
            if (Directory.Exists(TargetStorage))
            {
                Directory.Delete(TargetStorage, true);
            }
            Directory.CreateDirectory(TargetStorage);
            Settings.Init();
            Logger.Init();
        }

        public void Run()
        {
            Console.WriteLine("当前参数:");
            Console.WriteLine(Settings);
            Replacer replacer = new Replacer();
            replacer.DoReplace();
            
            Console.ReadLine();

        }

    }
}
