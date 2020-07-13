using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
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
        public int? Term { get; set; }
        public double TotalCredit { get; set; }
        public double CompleteCredit { get; set; }
        public double Point { get; set; }
        public double GPA { get; set; }
        /// <summary>
        /// 在学校内的排名，只在同一届之内排名
        /// </summary>
        public long OrderOfSchool { get; set; }
        /// <summary>
        /// 在专业内的排名
        /// </summary>
        public long OrderOfProfession { get; set; }
        /// <summary>
        /// 在班级内的排名
        /// </summary>
        public long OrderOfClass { get; set; }
    }
}
