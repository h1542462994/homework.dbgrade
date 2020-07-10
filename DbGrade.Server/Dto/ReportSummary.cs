using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.Models.Types;

namespace Tro.DbGrade.Server.Dto
{
    public class ReportSummary
    {
        public string Sno { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }

        public int Cno { get; set; }
        public int CYear { get; set; }
        public string CName { get; set; }
        public int Pno { get; set; }
        public string PName { get; set; }
        public Grade TotalGrade { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
    }
}
