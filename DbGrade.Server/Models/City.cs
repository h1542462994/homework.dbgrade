using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Models
{
    public class City
    {
        [Key]
        public int Cino { get; set; }
        public string Name { get; set; }
        public int Prno { get; set; }
    }
}
