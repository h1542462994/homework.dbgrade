using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class Profession
    {
        public Profession()
        {
        }

        public Profession(int pno, string name, params Xclass[] xclasses)
        {
            Pno = pno;
            Name = name;
            Xclasses = xclasses;
        }

        public Profession(int pno, string name, IEnumerable<Xclass> xclasses)
        {
            Pno = pno;
            Name = name;
            Xclasses = xclasses;
        }

        public int Pno { get; set; }
        public string Name { get; set; }
        public IEnumerable<Xclass> Xclasses { get;set;}
    }
}
