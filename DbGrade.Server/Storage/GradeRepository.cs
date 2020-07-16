using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Dto;
using Tro.DbGrade.FrameWork.Models;
using Tro.DbGrade.FrameWork;
using System.Runtime.Serialization;
using System.Globalization;
using Tro.DbGrade.FrameWork.Models.Types;
using Microsoft.Data.SqlClient;

namespace Tro.DbGrade.Server.Storage
{
    public class GradeRepository : IGradeRepository
    {
        public GradeRepository(GradeDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public GradeDbContext DbContext { get; }

        [Completed]
        public IEnumerable<FrameWork.Dto.Profession> GetStruct() =>
            from profession in DbContext.Professions
            select new FrameWork.Dto.Profession(
                profession.Pno,
                profession.Name,
                from xclass in DbContext.Xclasses
                where xclass.Pno == profession.Pno
                select new FrameWork.Dto.Xclass(
                    xclass.Cno,
                    xclass.Name,
                    xclass.Year));

        [Completed]
        public IEnumerable<FrameWork.Dto.Province> GetDestStruct() =>
            from province in DbContext.Provinces
            select new FrameWork.Dto.Province(
                province.Prno,
                province.Name,
                from city in DbContext.Cities
                where city.Prno == province.Prno
                select new FrameWork.Dto.City(
                    city.Cino,
                    city.Name)
                );

        [Completed]
        public IEnumerable<DestSummary> GetDestSummaries(string scope, int? tag, int? year)
        {
            var summaries = from province in DbContext.Provinces
                          select new
                          {
                              prno = province.Prno,
                              name = province.Name,
                              pCount = (from student in DbContext.StudentOutView
                                        where student.Prno == province.Prno && (year == null || year == student.CYear)
                                        select student).Count(),
                              cities = from city in DbContext.Cities
                                       where city.Prno == province.Prno
                                       select new
                                       {
                                           cino = city.Cino,
                                           name = city.Name,
                                           pCount = (from student in DbContext.StudentOutView
                                                     where student.Cino == city.Cino && (year == null || year == student.CYear)
                                                     select student).Count()
                                       }
                          };
            return summaries.SelectMany((province) => 
                from city in province.cities
                where 
                    ((scope == Scope.Province && tag == province.prno) ||
                    (scope == Scope.City && tag == city.cino) ||
                    (scope == Scope.All || scope == null))
                select
                     new DestSummary()
                     {
                         Prno = province.prno,
                         PrName = province.name,
                         PrSummaryCount = province.pCount,
                         Cino = city.cino,
                         CiName = city.name,
                         CiSummaryCount = city.pCount
                     });
        }

        [Completed]
        public IEnumerable<ClassSummary> GetClassSummaries(string scope, int? tag, int? year)
        {
            var summaries = from profession in DbContext.Professions
                            select new
                            {
                                pno = profession.Pno,
                                name = profession.Name,
                                pCount = (from student in DbContext.StudentOutView
                                          where student.Pno == profession.Pno && (year == null || year == student.CYear)
                                          select student).Count(),
                                xclasses = from xclass in DbContext.Xclasses
                                           where xclass.Pno == profession.Pno
                                           select new
                                           {
                                               cno = xclass.Cno,
                                               cyear = xclass.Year,
                                               name = xclass.Name,
                                               pCount = (
                                               from student in DbContext.StudentOutView
                                               where student.Cno == xclass.Cno && (year == null || year == student.CYear)
                                               select student
                                               ).Count()
                                           }

                            };
           
            return summaries.SelectMany(profession =>
                from xclass in profession.xclasses
                where 
                    ((scope == Scope.Profession && tag == profession.pno) ||
                    (scope == Scope.Xclass && tag == xclass.cno) ||
                    (scope == Scope.All || scope == null))
                select 
                    new ClassSummary()
                    {
                        Pno = profession.pno,
                        PName = profession.name,
                        PSummaryCount = profession.pCount,
                        Cno = xclass.cno,
                        CYear = xclass.cyear,
                        CName = xclass.name,
                        CSummaryCount = xclass.pCount
                    }
            );
            
        }
        
        [Completed]
        public IEnumerable<StudentOut> GetStudents(string scope, int? tag, int? year)
        {
            var students = from student in DbContext.StudentOutView
            where
               ((scope == Scope.Profession && student.Pno == tag) ||
               (scope == Scope.Xclass && student.Cno == tag) ||
               (scope == Scope.Province && student.Prno == tag) ||
               (scope == Scope.City && student.Cino == tag) ||
               (scope == Scope.All || scope == null)) && (year == null || year == student.CYear)
            select student;

            

            return from student in students select 
                   new StudentOut()
                   {
                        Sno = student.Sno,
                        Name = student.Name,
                        Sex = student.Sex,
                        Age = student.Age,
                        Cno = student.Cno,
                        CYear = student.CYear,
                        CName = student.CName,
                        Pno = student.Pno,
                        PName = student.PName,
                        Prno = student.Prno,
                        PrName =student.PrName,
                        Cino = student.Cino,
                        CiName = student.CiName,
                        TotalCredit = student.TotalCredit,
                        CompleteCredit = student.CompleteCredit,
                        Point = student.Point,
                        GPA = student.GPA,
                        Order = scope == Scope.Xclass? student.OrderOfClass:(scope == Scope.Profession? student.OrderOfProfession: student.OrderOfSchool)
                   };
        }

        [Completed]
        public IEnumerable<ReportsView> GetReports(string scope, string tag, int? year, int? cyear) =>
            from report in DbContext.ReportsView
            where
                ((scope == Scope.Profession && report.Pno == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                (scope == Scope.Xclass && report.Cno == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                (scope == Scope.Province && report.Prno == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                (scope == Scope.City && report.Cino == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                (scope) == Scope.OpenCourse && report.Ono == int.Parse(tag, CultureInfo.InvariantCulture) ||
                (scope) == Scope.Course && report.Cno == int.Parse(tag, CultureInfo.InvariantCulture) ||
                (scope) == Scope.Student && report.Sno == tag ||
                (scope) == Scope.Teacher && report.Tno == tag ||
                scope == Scope.All || scope == null) && (year == null || year == report.Year) && (cyear == null || year == report.CYear)
            select report;

        [Completed]
        public IEnumerable<ReportSummaryOut> GetReportSummaries(string scope, int? tag, int? year, int? cyear)
        {
            var reports = (from student in DbContext.StudentOutView
                           where
                           ((scope == Scope.Profession && student.Pno == tag) ||
                           (scope == Scope.Xclass && student.Cno == tag) ||
                           (scope == Scope.All || scope == null)) && (cyear == null || cyear == student.CYear)
                           select new ReportSummary()
                           {
                               Sno = student.Sno,
                               Name = student.Name,
                               Age = student.Age,
                               Sex = student.Sex,
                               Cno = student.Cno,
                               CName = student.CName,
                               CYear = student.CYear,
                               Pno = student.Pno,
                               PName = student.PName,
                               TotalGrade = year == null ? new Grade()
                               {
                                   Year = null,
                                   TotalCredit = student.TotalCredit,
                                   CompleteCredit = student.CompleteCredit,
                                   Point = student.Point,
                                   GPA = student.GPA,
                                   OrderOfSchool = student.OrderOfSchool,
                                   OrderOfProfession = student.OrderOfProfession,
                                   OrderOfClass = student.OrderOfClass
                               } : (from report in DbContext.ReportSummaryView
                                    where student.Sno == report.Sno && report.Year == year
                                    select new Grade()
                                    {
                                        Year = report.Year,
                                        TotalCredit = report.TotalCredit,
                                        CompleteCredit = report.CompleteCredit,
                                        Point = report.Point,
                                        GPA = report.GPA,
                                        OrderOfSchool = report.OrderOfSchool,
                                        OrderOfProfession = report.OrderOfProfession,
                                        OrderOfClass = report.OrderOfClass
                                    }).First()
                           });


            return from report in reports
                    select new ReportSummaryOut()
                    {
                        Sno = report.Sno,
                        Name = report.Name,
                        Age = report.Age,
                        Sex = report.Sex,
                        Cno = report.Cno,
                        CName = report.CName,
                        CYear = report.CYear,
                        Pno = report.Pno,
                        PName = report.PName,
                        TotalCredit = report.TotalGrade.TotalCredit,
                        CompleteCredit = report.TotalGrade.CompleteCredit,
                        Point = report.TotalGrade.Point,
                        GPA = report.TotalGrade.GPA,
                        Order = scope == Scope.Xclass ? report.TotalGrade.OrderOfClass: (scope == Scope.Profession ? report.TotalGrade.OrderOfProfession: report.TotalGrade.OrderOfSchool)
                    };
        }

        [Completed]
        public IEnumerable<CourseSummaryView> GetCourseSummaries(string scope, string tag, int? year, int? cyear)
        {
            return from courseSummary in DbContext.CourseSummaryView
                   where
                   ((scope == Scope.Profession && courseSummary.Pno ==  int.Parse(tag, CultureInfo.InvariantCulture)) ||
                   (scope == Scope.Xclass && courseSummary.Cno == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                   (scope == Scope.Course && courseSummary.Cono == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                   (scope == Scope.Teacher && courseSummary.Tno == tag) ||
                   (scope == Scope.All || scope == null)) && (year == null || year == courseSummary.Year) && (cyear == null || cyear == courseSummary.CYear)
                   select courseSummary;
        }

        [Completed]
        public IEnumerable<XTerm> GetTerms()
        {
            return DbContext.Terms;
        }

        [Completed]
        public IEnumerable<Teacher> GetTeachers()
        {
            return DbContext.Teachers;
        }

        [Completed]
        public IEnumerable<OpenCoursesView> GetOpenCourses(string scope, string tag, int? year, int? cyear)
        {
            return from openCourse in DbContext.OpenCoursesView
                   where
                   ((scope == Scope.Profession && openCourse.Pno == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                   (scope == Scope.Xclass && openCourse.Cno == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                   (scope == Scope.Course && openCourse.Cono == int.Parse(tag, CultureInfo.InvariantCulture)) ||
                   (scope) == Scope.Teacher && openCourse.Tno == tag) ||
                   (scope == Scope.All || scope == null) && (year == null || year == openCourse.Year) &&
                   (cyear == null || cyear == openCourse.CYear)
                   select openCourse;
        }

        [Completed]
        public IEnumerable<Course> GetCourses()
        {
            return DbContext.Courses;
        }

        public void AddDest(string province, string city)
        {
            DbContext.Database.ExecuteSqlInterpolated($"exec addDest {province},{city}");
        }

        public void AddStruct(string profession, string xclass, int year)
        {
            DbContext.Database.ExecuteSqlInterpolated($"exec addStruc {profession},{xclass},{year}");
        }

        public bool AddStudent(string sno, string name, Sex sex, int age, int cno, int cino)
        {
            if ((from student in DbContext.Students where student.Sno == sno select student).Any())
            {
                return false;
            } 
            else
            { 
                DbContext.Database.ExecuteSqlInterpolated($"exec addStudent {sno},{name},{sex},{age},{cno},{cino}");
                return true;
            }
        }

        public bool AddTeacher(string tno, string name, Sex sex, int age, Level level, string phone)
        {
            if ((from teacher in DbContext.Teachers where teacher.Tno == tno select teacher).Any())
            {
                return false;
            }
            else
            {
                DbContext.Database.ExecuteSqlInterpolated($"exec addTeacher {tno},{name},{sex},{age},{level},{phone}");
                return true;
            }
        }

        public bool AddTerm(int year, Term term)
        {
            if ((from xterm in DbContext.Terms where xterm.Year == year && xterm.Term == term select xterm).Any())
            {
                return false;
            } 
            else
            {
                DbContext.Database.ExecuteSqlInterpolated($"exec addTerm {year},{term}");
                return true;
            }
        }

        public bool AddCourse(string name, int period, Way way, double credit)
        {
            if ((from course in DbContext.Courses where course.Name == name select course).Any())
            {
                return false;
            }
            else
            {
                try
                {
                    DbContext.Database.ExecuteSqlInterpolated($"exec addCourse {name},{period},{way},{credit}");

                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            }
        }

        public bool AddOpenCourse(int cono, int cno, int year, Term term, string tno)
        {
            if ((from openCourse in DbContext.OpenCoursesView where openCourse.Cono == cono && openCourse.Cno == cno select openCourse).Any())
            {
                return false;
            }
            else
            {
                DbContext.Database.ExecuteSqlInterpolated($"exec addOpenCourse {cono},{cno},{year},{term},{tno}");
                return true;
            }
        }

        public string AddReport(string sno, int cono, double grade)
        {
            var student = (from item in DbContext.Students where item.Sno == sno select item).First();
            if (!(from openCourse in DbContext.OpenCoursesView where openCourse.Cono == cono && openCourse.Cno == student.Cno select openCourse).Any())
            {
                return "不存在的开课";
            }

            if ((from report in DbContext.ReportsView where report.Sno == sno && report.Cono == cono select report).Any())
            {
                return "已存在该报告";
            } 
            else
            {
                DbContext.Database.ExecuteSqlInterpolated($"exec addReport {sno},{cono},{grade}");
                return null;
            }
        }
    }
}
