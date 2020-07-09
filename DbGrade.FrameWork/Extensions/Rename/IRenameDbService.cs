#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Extensions.Rename
{
    /// <summary>
    /// 根据课程设计的要求，提供重命名服务。
    /// </summary>
    public interface IRenameDbService
    {
        string RenameEntity(string entityName);

        string RenameColumn(string columnName);

        string RenameConnectionString(string connectionString);
    }
}
