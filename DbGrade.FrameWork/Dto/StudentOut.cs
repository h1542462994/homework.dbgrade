using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class StudentOut: IComparable<StudentOut>
    {
        public string Sno { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }

        public int Cno { get; set; }
        public int CYear { get; set; }
        public string CName { get; set; }
        public string CDisplay => $"{CYear}届{CName}";
        public int Pno { get; set; }
        public string PName { get; set; }
        public int Prno { get; set; }
        public string PrName { get; set; }
        public int Cino { get; set; }
        public string CiName { get; set; }
        public double TotalCredit { get; set; }
        public double CompleteCredit { get; set; }
        public double Point { get; set; }
        public double GPA { get; set; }

        public long Order { get; set; }

        public int CompareTo([AllowNull] StudentOut other)
        {
            if (Sno == null && other.Sno == null)
            {
                return 0;
            }
            else if (Sno == null)
            {
                return -1;
            }
            else if (other.Sno == null)
            {
                return 1;
            }
            return Sno.CompareTo(other.Sno);
        }

        public static readonly StudentOut All = new StudentOut()
        {
            Sno = null,
            Name = "--全部--"
        };
    }
}
