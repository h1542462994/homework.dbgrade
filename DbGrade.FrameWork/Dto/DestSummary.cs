using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class DestSummary : IComparable<DestSummary>
    {
        public int Prno { get; set; }
        public string PrName { get; set; }
        public int PrSummaryCount { get; set; }

        public int Cino { get; set; }
        public string CiName { get; set; }
        public int CiSummaryCount { get; set; }

        public int CompareTo([AllowNull] DestSummary other)
        {
            return Cino.CompareTo(other.Cino);
        }
    }
}
