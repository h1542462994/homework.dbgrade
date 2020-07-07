using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.DataAcesses;

namespace Tro.DbGrade.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRenameDbService<T>(this IServiceCollection collection) where T: class, IRenameDbService 
        {
            return collection.AddSingleton<IRenameDbService, T>();
        }

        public static IServiceCollection AddDataAccessService<T>(this IServiceCollection collection, Action<DataAccessBuilder> options = null) where T: DataAccessServiceBase
        {
            var builder = new DataAccessBuilder();
            if(options != null)
            {
                options.Invoke(builder);
            }

            return collection.AddSingleton<DataAccessServiceBase, T>();

        }
    }
}
