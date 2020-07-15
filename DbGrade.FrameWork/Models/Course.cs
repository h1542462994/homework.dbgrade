using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
{
    public class Course: IComparable<Course>
    {
        [Key]
        public int Cono { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public Way Way { get; set; }
        public double Credit { get; set; }

        public int CompareTo([AllowNull] Course other)
        {
            return Cono.CompareTo(other.Cono);
        }


        public static readonly Course All = new Course()
        {
            Cono = -1,
            Name = "--全部--"
        };
    }
}
