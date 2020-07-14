using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class ReportSummaryOut : IComparable<ReportSummaryOut>
    {
        public string Sno { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }

        public int Cno { get; set; }
        public int CYear { get; set; }
        public string CDisplay => $"{CYear}届{CName}";
        public string CName { get; set; }
        public int Pno { get; set; }
        public string PName { get; set; }
        /// <summary>
        /// 表示再次阶段内的总学分（包含）
        /// </summary>
        public double TotalCredit { get; set; }
        /// <summary>
        /// 已完成的学分
        /// </summary>
        public double CompleteCredit { get; set; }
        /// <summary>
        /// GPA
        /// </summary>
        public double GPA { get; set; }
        /// <summary>
        /// GPA积分
        /// </summary>
        public double Point { get; set; }
        public long Order { get; set; }

        public int CompareTo([AllowNull] ReportSummaryOut other)
        {
            return Sno.CompareTo(other.Sno);
        }
    }
}
