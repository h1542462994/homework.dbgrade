using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class City
    {
        public City()
        {
        }

        public City(int cino, string name)
        {
            Cino = cino;
            Name = name;
        }

        public City(int cino, string name, int studentCount)
        {
            Cino = cino;
            Name = name;
            StudentCount = studentCount;
        }

        public int Cino { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }


        public static readonly City All = new City(
            cino: -1,
            name: "--全部--"
            );
    }
}
