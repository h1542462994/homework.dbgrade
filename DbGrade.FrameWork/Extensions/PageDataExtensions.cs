using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tro.DbGrade.FrameWork.Extensions
{
    public static class PageDataExtensions
    {

        public static PageData<T> ToPage<T>(IQueryable<T> collection, int pageIndex = 0, int eachCount = 0)
        {
            int count = collection.Count();

            if(eachCount <= 0)
            {
                return new PageData<T>(0, 0, count, collection);
            }
            else
            {
                int pageCount = (count - 1) / eachCount + 1;
                collection = collection.Skip(pageIndex * eachCount).Take(eachCount);
                return new PageData<T>(pageIndex, pageCount, count, collection);
            }
        }
    }
}
