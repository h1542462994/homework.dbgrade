using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.FrameWork.Models
{
    public class XTerm: IComparable<XTerm>
    {
        public int Year { get; set; }
        public Term Term { get; set; }

        public int CompareTo([AllowNull] XTerm other)
        {
            if (Year == other.Year)
            {
                return Term.CompareTo(other.Term);
            } 
            else
            {
                return Year.CompareTo(other.Year);
            }
        }
    }
}
