using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DbGrade.SqlCreator.Services
{
    public class Logger : IInitable
    {
        private string SystemLogFile { get; set; }

        public void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            ConsoleColor preConsoleColor = Console.ForegroundColor;
            string wrapped = $"{DateTime.Now}\t{logLevel}\t{message}";
            if(logLevel == LogLevel.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if(logLevel == LogLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(wrapped);
            File.AppendAllText(SystemLogFile, $"{wrapped}\n");
            Console.ForegroundColor = preConsoleColor;
        }



        public void Init()
        {
            SystemLogFile = Path.Join(App.Current.DataStorage, @"system.log");
            if (!File.Exists(SystemLogFile))
            {
                Log("create the log file");
            }
        }
    }


    public enum LogLevel
    {
        Info,
        Warning,
        Error,
    }
}
