using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Extensions
{
    public class RenameDbService : IRenameDbService
    {
        public string RenameEntity(Type entity)
        {
            return "hello";
        }

        public string RenameProperty(Type entity, FieldInfo field)
        {
            return "hello world";
        }
    }
}
