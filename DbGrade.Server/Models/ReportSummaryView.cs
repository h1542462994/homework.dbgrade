using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.Models.Types;

namespace Tro.DbGrade.Server.Models
{
    public class ReportSummaryView
    {
        public string Sno { get; set; }
        public string SName { get; set; }
        public Sex SSex { get; set; }
        public int SAge { get; set; }
        public double Grade { get; set; }
        public int Cno { get; set; }
        public int CYear { get; set; }
        public string CName { get; set; }
        public int Pno { get; set; }
        public string PName { get; set; }
        public int Prno { get; set; }
        public string PrName { get; set; }
        public int Cino { get; set; }
        public string CiName { get; set; }
        public int? Year { get; set; }
        public Term Term { get; set; }
        public double TotalCredit { get; set; }
        public double CompleteCredit { get; set; }
        public double Point { get; set; }
        public double GPA { get; set; }
    }
}
