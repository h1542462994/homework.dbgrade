

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Model
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Students
    {
        public string Sno { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }
     
        public int Age { get; set; }
    }
}
