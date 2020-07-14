using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
{
    public class ReportsView : IComparable<ReportsView>
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

        public string CDisplay => $"{CYear}届{CName}";
        public int Ono { get; set; }
        public int Cono { get; set; }
        public string CoName { get; set; }
        public double Credit { get; set; }
        public double CreditGet { get; set; }
        public int Period { get; set; }

        public Way Way { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public string Tno { get; set; }
        public string TName { get; set; }
        public int TAge { get; set; }
        public Sex Tsex { get; set; }
        public Level TLevel { get; set; }
        public string TPhone { get; set; }

        public int CompareTo([AllowNull] ReportsView other)
        {
            if (Sno == other.Sno)
            {
                return Ono.CompareTo(other.Ono);
            } else
            {
                return Sno.CompareTo(other.Sno);
            }
        }
    }
}
