

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.Models.Types;

namespace Tro.DbGrade.Server.Model
{
    public class Student
    {
        [Key]
        public string Sno { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }
     
        public int Age { get; set; }

        public double TotalCredit { get; set; }
    }
}
