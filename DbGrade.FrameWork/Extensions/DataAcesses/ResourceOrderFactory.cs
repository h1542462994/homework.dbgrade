using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.FrameWork.Extensions.DataAcesses
{
    public class ResourceOrderFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:请不要将文本作为本地化参数传递", Justification = "<挂起>")]
        public IResourceOrder<T> CreateResourceOrder<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(message: "值为空值");

            value = value.Trim();
            string[] args = value.Split(":");
            if(args.Length == 1)
            {
                return new ResourceOrder<T>(args[0]);
            }
            else if (args.Length == 2)
            {
                if (args[1] == OrderType.Acsending.ToString())
                {
                    return new ResourceOrder<T>(args[0]);
                } 
                else if(args[1] == OrderType.Descending.ToString())
                {
                    return new ResourceOrder<T>(args[1]);
                }
                else
                {
                    throw new ArgumentException(message: "排序方式的值在预期之外");
                }
            }
            else
            {
                throw new ArgumentException(message: "参数过多");
            }
        }
    }
}
