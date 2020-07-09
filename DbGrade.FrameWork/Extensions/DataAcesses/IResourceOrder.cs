
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.FrameWork.Extensions.DataAcesses
{
    public interface IResourceOrder<T>
    {
        IQueryable<T> DoOrder(IQueryable<T> collection);
    }
}
