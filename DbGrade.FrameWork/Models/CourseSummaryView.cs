using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
{
    public class CourseSummaryView : IComparable<CourseSummaryView>
    {
        [Key]
        public int Ono { get; set; }
        public int Cono { get; set; }
        public string CoName { get; set; }
        public double Credit { get; set; }
        public int Period { get; set; }
        public Way Way { get; set; }
        public int Year { get; set; }
        public Term Term { get; set; }
        public int Cno { get; set; }
        public string CName { get; set; }
        public int CYear { get; set; }
        public string CDisplay => $"{CYear}届{CName}";
        public int Pno { get; set; }
        public string PName { get; set; }
        public string Tno { get; set; }
        public string TName { get; set; }
        public int TAge { get; set; }
        public Sex TSex { get; set; }
        public Level TLevel { get; set; }
        public string TPhone { get; set; }
        public double AvgGrade { get; set; }
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
        public int Count { get; set; }

        public int CompareTo([AllowNull] CourseSummaryView other)
        {
            return Ono.CompareTo(other.Ono);
        }
    }
}
