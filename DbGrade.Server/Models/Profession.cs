using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Models
{
    public class Profession
    {
        [Key]
        public int Pno { get; set; }
        public string Name { get; set; }


    }
}
