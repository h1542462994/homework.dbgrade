

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
{
    
    public class Student
    {
        [Key]
        public string Sno { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }
     
        public int Age { get; set; }
        public int Cno { get; set; }
        public int Cino { get; set; }

        public double TotalCredit { get; set; }
    }
}
