using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
{
    public class OpenCoursesView : IComparable<OpenCoursesView>
    {
        [Key]
        public int Ono { get; set; }
        public int Cono { get; set; }
        public string CoName { get; set; }
        public double Credit { get; set; }
        public int Period { get; set; }
        public Way Way { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public int Cno { get; set; }
        public string CName { get; set; }
        public int CYear { get; set; }
        public int Pno { get; set; }
        public string PName { get; set; }
        public string Tno { get; set; }
        public string TName { get; set; }
        public int TAge { get; set; }
        public Sex TSex { get; set; }
        public Level TLevel { get; set; }
        public string TPhone { get; set; }
        public int CompareTo([AllowNull] OpenCoursesView other)
        {
            return Ono.CompareTo(other.Ono);
        }
    }
}
