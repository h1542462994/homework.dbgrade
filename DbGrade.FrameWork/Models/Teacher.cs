using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
{
    public class Teacher : IComparable<Teacher>
    {
        [Key]
        public string Tno { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public Level Level { get; set; }
        public string Phone { get; set; }

        public int CompareTo([AllowNull] Teacher other)
        {
            if (Tno == null && other.Tno == null)
            {
                return 0;
            }
            else if (Tno == null)
            {
                return -1;
            }
            else if (other.Tno == null)
            {
                return 1;
            }
            return Tno.CompareTo(other.Tno);
        }

        public static readonly Teacher All = new Teacher()
        {
            Tno = null,
            Name = "--全部--"
        };
    }
}
