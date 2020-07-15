using System;
using System.Collections.Generic;
using System.Text;
using Tro.DbGrade.FrameWork.Models;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class Locator
    {
        public Locator(string scope, string tag = null, int? cYear = null, int? year=null)
        {
            Scope = scope;
            Tag = tag;
            CYear = cYear;
            Year = year;
        }

        public string Scope { get; set; }
        public string Tag { get; set; }
        public int? CYear { get; set; }

        public int? Year { get; set; }


        public static Locator All(int? cYear = null, int? year = null) => new Locator(scope: FrameWork.Models.Scope.All, cYear: cYear, year: year);
        public static Locator Profession(int profession, int? cYear, int? year = null) => new Locator(scope: FrameWork.Models.Scope.Profession, tag: profession.ToString(), cYear: cYear, year: year);
        public static Locator Xclass(int xclass, int? cYear, int? year = null) => new Locator(scope: FrameWork.Models.Scope.Xclass, tag: xclass.ToString(), cYear: cYear, year: year);
        public static Locator Province(int province, int? cYear, int? year = null) => new Locator(scope: FrameWork.Models.Scope.Province, tag: province.ToString(), cYear: cYear, year: year);
        public static Locator City(int city, int? cYear, int? year = null) => new Locator(scope: FrameWork.Models.Scope.City, tag: city.ToString(), cYear: cYear, year: year);
        public static Locator Teacher(string tno, int? cYear, int? year) => new Locator(scope: FrameWork.Models.Scope.Teacher, tag: tno, cYear: cYear, year: year);
        public static Locator Course(int cono, int? cYear, int? year) => new Locator(scope: FrameWork.Models.Scope.Course, tag: cono.ToString(), cYear: cYear, year: year);
    }
}
