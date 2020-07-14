using System;
using System.Collections.Generic;
using System.Text;

namespace Tro.DbGrade.FrameWork
{
    /// <summary>
    /// 表示是否完成
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class CompletedAttribute : Attribute
    {

        public CompletedAttribute()
        {
        }

    }
}
