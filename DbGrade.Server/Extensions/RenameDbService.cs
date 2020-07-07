using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.Extensions
{
    public class RenameDbService : IRenameDbService
    {
        public RenameDbOptions Options { get; }

        public RenameDbService(IOptions<RenameDbOptions> options)
        {
            this.Options = options.Value;
        }

        public string RenameEntity(string entityName)
        {
            if (Options.IsOpen)
            {
                return $"{Options.MiddleName}_{entityName}{Options.GroupNo}";
            } 
            else
            {
                return entityName;
            }
        }

        public string RenameColumn(string columnName)
        {
            if (Options.IsOpen)
            {
                return $"{Options.ShortName}_{columnName}{Options.GroupNo}";
            } 
            else
            {

                return columnName;
            }
        }

        public string RenameConnectionString(string connectionString)
        {
            if (Options.IsOpen)
            {
                return connectionString.Replace("@{DataBase}", $"{Options.FullName}MIS{Options.GroupNo}", StringComparison.CurrentCulture);
            }
            else
            {
                return connectionString;
            }
        }
    }
}
