using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DbGrade.SqlCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            App.Create();
            App app = App.Current;
            app.Init();
            app.Run();

        }
    }
}
