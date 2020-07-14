using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class ClassSummary : IComparable<ClassSummary>
    {
        public int Pno { get; set; }
        public string PName { get; set; }
        public int PSummaryCount { get; set; }
        public int Cno { get; set; }
        public int CYear { get; set; }
        public string CName { get; set; }

        public int CSummaryCount { get; set; }

        public string CDisplay => $"{CYear}届{CName}";

        public int CompareTo([AllowNull] ClassSummary other)
        {
            return Cno.CompareTo(other.Cno);
        }
    }
}
