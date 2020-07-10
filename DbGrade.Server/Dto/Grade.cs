using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Dto
{
    /// <summary>
    /// 表示一个成绩项
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// 统计的年份，若为<see cref="null"/>，则表示为总的统计。
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// 表示再次阶段内的总学分（包含）
        /// </summary>
        public double TotalCredit { get; set; }
        /// <summary>
        /// 已完成的学分
        /// </summary>
        public double CompleteCredit { get; set; }
        /// <summary>
        /// GPA
        /// </summary>
        public double GPA { get; set; }
        /// <summary>
        /// GPA积分
        /// </summary>
        public double Point { get; set; }
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
