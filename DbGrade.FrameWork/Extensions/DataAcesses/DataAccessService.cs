using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Tro.FrameWork.Extensions.DataAcesses
{
    public class DataAccessService 
    {
        public DataAccessService(IOptions<DataAccessOptions> options, DbContext dbContext)
        {
            Options = options.Value;
            DbContext = dbContext;
        }

        public DataAccessOptions Options { get; }
        public DbContext DbContext { get; }

        public PageData<T> Data<T>(int pageIndex = 0, ResourceOrder[] orders = null) where T:class
        {
            DbSet<T> set = DbContext.Set<T>();
            var collection = from item in DbContext.Set<T>() select item;
            collection = collection.Skip(pageIndex * Options.EachCount).Take(Options.EachCount);
            if (orders != null && orders.Any())
            {
                foreach (var order in orders)
                {
                    if (!order.Descending)
                    {
                        collection = collection.OrderBy((item) => item.GetType().GetProperty(order.Column).GetValue(item));
                    }
                    else
                    {
                        collection = collection.OrderByDescending((item) => item.GetType().GetProperty(order.Column).GetValue(item));
                    }
                }

            }


            int count = collection.Count();
            int pageCount = (count - 1) / Options.EachCount + 1;


            return new PageData<T>(count, pageIndex, pageCount, collection);
        }
    }
}
