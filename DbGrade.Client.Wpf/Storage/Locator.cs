using System;
using System.Collections.Generic;
using System.Text;


namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class Locator
    {
        public Locator(string scope, string tag = null, int? cYear = null)
        {
            Scope = scope;
            Tag = tag;
            CYear = cYear;
        }

        public string Scope { get; set; }
        public string Tag { get; set; }
        public int? CYear { get; set; }


        public static Locator All(int? cYear = null) => new Locator(scope: FrameWork.Models.Scope.All, cYear: cYear);
        public static Locator Profession(int profession, int? cYear) => new Locator(scope: FrameWork.Models.Scope.Profession, tag: profession.ToString(), cYear: cYear);
        public static Locator Xclass(int xclass, int? cYear) => new Locator(scope: FrameWork.Models.Scope.Xclass, tag: xclass.ToString(), cYear: cYear);
        public static Locator Province(int province, int? cYear) => new Locator(scope: FrameWork.Models.Scope.Province, tag: province.ToString(), cYear: cYear);
        public static Locator City(int city, int? cYear) => new Locator(scope: FrameWork.Models.Scope.City, tag: city.ToString(), cYear: cYear);
    }
}
