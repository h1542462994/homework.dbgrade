using System;
using System.Collections.Generic;
using System.Text;

namespace Tro.DbGrade.FrameWork.Models
{
    public class DestSummaryView
    {
        public int Prno { get; set; }
        public string PrName { get; set; }
        public int PrSummaryCount { get; set; }
        public int Cino { get; set; }
        public string CiName { get; set; }
        public int CiSummaryCount { get; set; }
    }
}
