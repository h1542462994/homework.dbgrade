using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.Models.Types;

namespace Tro.DbGrade.Server.Models
{
    public class StudentOutView
    {
        [Key]
        public string Sno { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }

        public int Cno { get; set; }
        public int CYear { get; set; }
        public string CName { get; set; }
        public int Pno { get; set; }
        public string PName { get; set; }
        public int Prno { get; set; }
        public string PrName { get; set; }
        public int Cino { get; set; }
        public string CiName { get; set; }
        public double TotalCredit { get; set; }
        public double CompleteCredit { get; set; }
        public double Point { get; set; }
        public double GPA { get; set; }
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
    }
}
