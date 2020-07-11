
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Models
{
    public class StructView
    {
        public int Pno { get; set; }
        public string PName { get; set; }
        public int? PCount { get; set; }
        public int? Cno { get; set; }
        public string CName { get; set; }
        public int? Year { get; set; }

        public int? CCount { get; set; }
    }
}
