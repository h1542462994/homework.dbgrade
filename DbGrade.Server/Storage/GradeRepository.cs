using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Dto;
using Tro.DbGrade.FrameWork.Models;

namespace Tro.DbGrade.Server.Storage
{
    public class GradeRepository : IGradeRepository
    {
        public GradeRepository(GradeDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public GradeDbContext DbContext { get; }

        public IEnumerable<FrameWork.Dto.Province> GetDestStruct(int? year) =>
            from province in DbContext.Provinces
            select new FrameWork.Dto.Province(
                province.Prno,
                province.Name,
                from city in DbContext.Cities
                where city.Prno == province.Prno
                select new FrameWork.Dto.City(
                    city.Cino,
                    city.Name,
                    (from student in DbContext.StudentOutView where student.Cino == city.Cino && (year == null || student.CYear == year) select student).Count()
                    )
                );

        public IEnumerable<FrameWork.Dto.Profession> GetStruct(int? year) =>
            from profession in DbContext.Professions
            select new FrameWork.Dto.Profession(
                profession.Pno,
                profession.Name,
                from xclass in DbContext.Xclasses
                where (year == null || year == xclass.Year)
                where xclass.Pno == profession.Pno
                select new FrameWork.Dto.Xclass(
                    xclass.Cno,
                    xclass.Name,
                    xclass.Year,
                    (from student in DbContext.Students where student.Cno == xclass.Cno select student).Count()));

        public IEnumerable<StudentOutView> GetStudents(string scope, int? tag, int? year)
        {
            return from student in DbContext.StudentOutView
            where
               ((scope == Scope.Profession && student.Pno == tag) ||
               (scope == Scope.Xclass && student.Cno == tag) ||
               (scope == Scope.Province && student.Prno == tag) ||
               (scope == Scope.City && student.Cino == tag) ||
               (scope == Scope.All || scope == null)) && (year == null || year == student.CYear)
            select student;
        }
        public IEnumerable<ReportsView> GetReports(string scope, string tag, int? year, int? cyear) =>
            from report in DbContext.ReportsView
            where
                ((scope == Scope.Profession && report.Pno == int.Parse(tag)) ||
                (scope == Scope.Xclass && report.Cno == int.Parse(tag)) ||
                (scope == Scope.Province && report.Prno == int.Parse(tag)) ||
                (scope == Scope.City && report.Cino == int.Parse(tag)) ||
                (scope) == Scope.OpenCourse && report.Ono == int.Parse(tag) ||
                (scope) == Scope.Course && report.Cno == int.Parse(tag) ||
                (scope) == Scope.Student && report.Sno == tag ||
                (scope) == Scope.Teacher && report.Tno == tag ||
                scope == Scope.All || scope == null) && (year == null || year == report.Year) && (cyear == null || year == report.CYear)
            select report;

        public IEnumerable<ReportSummary> GetReportSummaries(string scope, int? tag, int? year, int? cyear)
        {
            return from student in DbContext.StudentOutView
                   where
                   ((scope == Scope.Profession && student.Pno == tag) ||
                   (scope == Scope.Xclass && student.Cno == tag) ||
                   (scope == Scope.All || scope == null)) && (year == null || year == student.CYear)
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
                       TotalGrade = new Grade()
                       {
                           Year = null,
                           TotalCredit = student.TotalCredit,
                           CompleteCredit = student.CompleteCredit,
                           Point = student.Point,
                           GPA = student.GPA,
                           OrderOfSchool = student.OrderOfSchool,
                           OrderOfProfession = student.OrderOfProfession,
                           OrderOfClass = student.OrderOfClass
                       },
                       Grades = (from report in DbContext.ReportSummaryView where student.Sno == report.Sno select new Grade() { 
                       Year = report.Year,
                       TotalCredit = report.TotalCredit,
                       CompleteCredit = report.CompleteCredit,
                       Point = report.Point,
                       GPA = report.GPA,
                       OrderOfSchool = report.OrderOfSchool,
                       OrderOfProfession = report.OrderOfProfession,
                       OrderOfClass = report.OrderOfClass})
                   };
        }

        public IEnumerable<CourseSummaryView> GetCourseSummaries(string scope, string tag, int? year, int? cyear)
        {
            return from courseSummary in DbContext.CourseSummaryView
                   where
                   ((scope == Scope.Profession && courseSummary.Pno ==  int.Parse(tag)) ||
                   (scope == Scope.Xclass && courseSummary.Cno == int.Parse(tag)) ||
                   (scope == Scope.Course && courseSummary.Cono == int.Parse(tag)) ||
                   (scope == Scope.Teacher && courseSummary.Tno == tag) ||
                   (scope == Scope.All || scope == null)) && (year == null || year == courseSummary.CYear)
                   select courseSummary;
        }

        
    }
}
