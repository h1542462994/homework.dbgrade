﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tro.DbGrade.FrameWork.Dto
{
    public class Xclass
    {
        public Xclass()
        {

        }

        public Xclass(int cno, string name)
        {
            Cno = cno;
            Name = name;
        }

        public Xclass(int cno, string name, int year)
        {
            Cno = cno;
            Name = name;
            Year = year;
        }


        //public int StudentCount { get; set; }
        public int Cno { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public readonly static Xclass All = new Xclass(
            cno: -1,
            name: "--全部--"
            );

        public override string ToString()
        {
            if (Cno <= 0)
            {
                return "--全部--";
            }
            else
            {
                return $"{Year}届{Name}";
            }
        }
    }
}
