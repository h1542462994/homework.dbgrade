using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Models
{
    public class Xclass
    {
        [Key]
        public int Cno { get; set; }
        public string Name { get; set; }
        public int Pno { get; set; }
        public int Year { get; set; }


    }
}
