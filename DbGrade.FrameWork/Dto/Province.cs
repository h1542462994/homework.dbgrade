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

        public Province(int prno, string name)
        {
            Prno = prno;
            Name = name;
        }

        public int Prno { get; set; }
        public string Name { get; set; }
        public IEnumerable<City> Cities { get; set; }

        public static readonly Province All = new Province(
            prno: -1,
            name: "--全部--"
            );
    }
}
