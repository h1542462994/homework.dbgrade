using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.FrameWork.Extensions.DataAcesses
{
    public static class ResourceOrderExtensions
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection collection, Action<DataAccessOptions> options = null)
        {
            collection.AddOptions<DataAccessOptions>().Configure(options);
            return collection.AddScoped<DataAccessService>();
        }
    }
}
