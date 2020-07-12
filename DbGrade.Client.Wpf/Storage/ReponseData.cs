using System;
using System.Collections.Generic;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class ReponseData<T>
    {
        public int Code { get; }
        public string Message { get; }
        public T Data { get; }
    }
}
