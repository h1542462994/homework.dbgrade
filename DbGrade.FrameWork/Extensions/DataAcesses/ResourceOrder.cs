using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.FrameWork.Extensions.DataAcesses
{
    public enum OrderType
    {
        Acsending,
        Descending
    }

    public class ResourceOrder<T> : IResourceOrder<T>
    {
        public ResourceOrder()
        {
        }

        public ResourceOrder(string column, OrderType orderType = OrderType.Acsending)
        {
            Column = column;
            OrderType = orderType  ;
        }

        public string Column { get; set; }
        public OrderType OrderType { get; set; } = OrderType.Acsending;

        public IQueryable<T> DoOrder(IQueryable<T> collection)
        {
            if (OrderType == OrderType.Acsending)
            {
                return collection.OrderBy((item) => typeof(T).GetProperty(Column).GetValue(item));
            } 
            else
            {
                return collection.OrderByDescending((item) => typeof(T).GetProperty(Column).GetValue(item));
            }
        }
    }
}
