using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Extensions
{
    /// <summary>
    /// 重命名服务的选项
    /// </summary>
    public class RenameDbOptions
    {
        /// <summary>
        /// 对应的配置Section
        /// </summary>
        public const string RenameDb = "RenameDb";


        /// <summary>
        /// 是否启用重命名功能，默认值为<see cref="false"/>
        /// </summary>
        public bool IsOpen { get; set; } = false;
        /// <summary>
        /// 全名，例如yumingyuan
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 中长名，例如yumy
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// 短名，例如ymy
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 组号，例如1
        /// </summary>
        public int GroupNo { get; set; }
    }
}
