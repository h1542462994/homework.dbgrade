#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Extensions
{
    /// <summary>
    /// 根据课程设计的要求，提供重命名服务。
    /// </summary>
    public interface IRenameDbService
    {
        string RenameEntity(Type entity);
        string RenameProperty(Type entity, FieldInfo field);

    }
}
