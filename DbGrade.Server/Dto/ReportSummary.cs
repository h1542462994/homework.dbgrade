using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Dto
{
    public class ReportSummary
    {
        public string Sno { get; set; }
        public Grade TotalGrade { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
    }
}
