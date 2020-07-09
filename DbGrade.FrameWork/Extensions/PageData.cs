using System;
using System.Collections.Generic;
using System.Text;

namespace Tro.DbGrade.FrameWork.Extensions
{
    public class PageData<T>
    {
        public PageData()
        {
        }

        public PageData(int pageIndex, int pageCount, int count, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PageCount = pageCount;
            Count = count;
            Data = data;
        }

        public int PageIndex { get; }
        public int PageCount { get; }
        public int Count { get; }
        public IEnumerable<T> Data { get; }
    }
}
