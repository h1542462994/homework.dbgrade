using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class Province
    {

        public Province()
        {
        }

        public Province(int prno, string name, IEnumerable<City> cities)
        {
            Prno = prno;
            Name = name;
            Cities = cities;
        }

        public int Prno { get; set; }
        public string Name { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
