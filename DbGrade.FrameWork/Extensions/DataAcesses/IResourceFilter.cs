using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.FrameWork.Extensions.DataAcesses
{
    public interface IResourceFilter<T>
    {
       IQueryable<T> DoFilter(IQueryable<T> collection);
    }
}
