﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.Dto;
using Tro.DbGrade.Server.Models;

namespace Tro.DbGrade.Server.Storage
{
    public class GradeRepository : IGradeRepository
    {
        public GradeRepository(GradeDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public GradeDbContext DbContext { get; }

        public IEnumerable<Dto.Province> GetDestStruct(int? year) =>
            from province in DbContext.Provinces
            select new Dto.Province(
                province.Prno,
                province.Name,
                from city in DbContext.Cities
                where city.Prno == province.Prno
                select new Dto.City(
                    city.Cino,
                    city.Name,
                    (from student in DbContext.StudentsView where student.Cino == city.Cino && (year == null || student.CYear == year) select student).Count()
                    )
                );

        public IEnumerable<Dto.Profession> GetStruct(int? year) =>
            from profession in DbContext.Professions
            select new Dto.Profession(
                profession.Pno,
                profession.Name,
                from xclass in DbContext.Xclasses
                where (year == null || year == xclass.Year)
                where xclass.Pno == profession.Pno
                select new Dto.Xclass(
                    xclass.Cno,
                    xclass.Name,
                    xclass.Year,
                    (from student in DbContext.Students where student.Cno == xclass.Cno select student).Count()));

        public IEnumerable<StudentsView> GetStudents(string scope, int? tag, int? year) =>
             from student in DbContext.StudentsView
             where
                ((scope == Scope.Profession && student.Pno == tag) ||
                (scope == Scope.Xclass && student.Cno == tag) ||
                (scope == Scope.Province && student.Prno == tag) ||
                (scope == Scope.City && student.Cino == tag) ||
                (scope == Scope.All || scope == null)) && (year == null || year == student.CYear)
             select student;

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
        
    }
}