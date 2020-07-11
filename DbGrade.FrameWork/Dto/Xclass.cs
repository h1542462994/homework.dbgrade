using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class Xclass
    {
        public Xclass()
        {

        }

        public Xclass(int cno, string name, int year, int studentCount)
        {
            Cno = cno;
            Name = name;
            Year = year;
            StudentCount = studentCount;
        }


        public int StudentCount { get; set; }
        public int Cno { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
