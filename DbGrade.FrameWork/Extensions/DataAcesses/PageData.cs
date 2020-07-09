using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.FrameWork.Extensions.DataAcesses
{
    public class PageData<T>
    {
        public PageData()
        {
        }

        public PageData(int count, int pageIndex, int pageCount, IQueryable<T> data)
        {
            Count = count;
            PageIndex = pageIndex;
            PageCount = pageCount;
            Data = data;
        }

        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public IQueryable<T> Data { get; set; }
    }
}
