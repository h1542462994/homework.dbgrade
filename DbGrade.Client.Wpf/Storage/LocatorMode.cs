using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Storage
{

    public class LocatorMode : IComparable, IComparable<LocatorMode>
    {
        private LocatorMode()
        {
        }

        private LocatorMode(string scope, int index)
        {
            Scope = scope;
            Index = index;
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Scope.Equals(((LocatorMode)obj).Scope);
        }

        public override int GetHashCode()
        {
            return Scope.GetHashCode();
        }

        public int Index { get; }
        public string Scope { get;  }

        public override string ToString()
        {
            if (this == Struct)
            {
                return "根据专业、班级筛选";
            }
            else if (this == Dest)
            {
                return "根据地区筛选";
            } else
            {
                return null;
            }
        }

        public int CompareTo(object obj)
        {
            return Index.CompareTo(((LocatorMode)obj).Index);
        }

        public int CompareTo([AllowNull] LocatorMode other)
        {
            if (other == null)
            {
                return -1;
            }
            return Index.CompareTo(other.Index);
        }

        public static readonly LocatorMode Struct = new LocatorMode("struct", 0);
        public static readonly LocatorMode Dest = new LocatorMode("dest",1);
    }
}
