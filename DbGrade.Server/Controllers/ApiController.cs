﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Dto;
using Tro.DbGrade.FrameWork.Models.Types;
using Tro.DbGrade.Server.Storage;

namespace Tro.DbGrade.Server.Controllers
{
    [Route("api")]
    public class ApiController: Controller
    {
        public IGradeRepository GradeRepository { get; }

        public ApiController(IGradeRepository gradeRepository)
        {
            GradeRepository = gradeRepository;
        }

        [HttpGet("struct")]
        [HttpPost("struct")]
        public object Struct()
        {
            return GradeRepository.GetStruct();
        }

        [HttpGet("students")]
        [HttpPost("students")]
        public object Students(string scope, int? tag, int? year)
        {
            return GradeRepository.GetStudents(scope, tag, year);
        }

        [HttpGet("dest_struct")]
        [HttpPost("dest_struct")]
        public object DestStruct()
        {
            return GradeRepository.GetDestStruct();
        }

        [HttpGet("dest_summary")]
        [HttpPost("dest_summary")]
        public object DestSummary(string scope, int? tag, int? year)
        {
            return GradeRepository.GetDestSummaries(scope, tag, year);
        }

        [HttpGet("class_summary")]
        [HttpPost("class_summary")]
        public object ClassSummary(string scope, int? tag, int? year)
        {
            return GradeRepository.GetClassSummaries(scope, tag, year);
        }

        [HttpGet("reports")]
        [HttpPost("reports")]
        public object Reports(string scope, string tag, int? year, int? cyear)
        {
            return GradeRepository.GetReports(scope, tag, year, cyear);
        }

        [HttpGet("report_summary")]
        [HttpPost("report_summary")]
        public object ReportSummary(string scope, int? tag, int? year, int? cyear)
        {
            return GradeRepository.GetReportSummaries(scope, tag, year, cyear);
        }

        [HttpGet("course_summary")]
        [HttpPost("course_summary")]
        public object CourseSummary(string scope, string tag, int? year, int? cyear)
        {
            return GradeRepository.GetCourseSummaries(scope, tag, year, cyear);
        }

        [HttpGet("terms")]
        [HttpPost("terms")]
        public object Terms()
        {
            return GradeRepository.GetTerms();
        }

        [HttpGet("teachers")]
        [HttpPost("teachers")]
        public object Teachers()
        {
            return GradeRepository.GetTeachers();
        }

        [HttpGet("open_courses")]
        [HttpPost("open_courses")]
        public object OpenCourses(string scope, string tag, int? year, int? cyear)
        {
            return GradeRepository.GetOpenCourses(scope, tag, year, cyear);
        }

        [HttpGet("courses")]
        [HttpPost("courses")]
        public object Courses()
        {
            return GradeRepository.GetCourses();
        }

        [HttpGet("dest/add")]
        [HttpPost("dest/add")]
        public object AddDest(string province, string city)
        {
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city)) return ApiResponse.BadRequest("参数不能为空");
            if (province.Length > 20 || city.Length > 20) return ApiResponse.BadRequest("参数太长");
            GradeRepository.AddDest(province, city);
            return ApiResponse.OK();
        }

        [HttpGet("struct/add")]
        [HttpPost("struct/add")]
        public object AddStruct(string profession, string xclass, int year)
        {
            if (string.IsNullOrEmpty(profession) || string.IsNullOrEmpty(xclass)) return ApiResponse.BadRequest("参数不能为空");
            if (profession.Length > 20 || xclass.Length > 20) return ApiResponse.BadRequest("参数太长");
            GradeRepository.AddStruct(profession, xclass, year);
            return ApiResponse.OK();
        }

        [HttpGet("student/add")]
        [HttpPost("student/add")]
        public object AddStudent(string sno, string name, Sex sex, int age, int cno, int cino)
        {
            var result = GradeRepository.AddStudent(sno, name, sex, age, cno, cino);
            if (result)
            {
                return ApiResponse.OK();
            } 
            else
            {
                return ApiResponse.BadRequest("该学生已存在");
            }
        }

        [HttpGet("teacher/add")]
        [HttpPost("teacher/add")]
        public object AddTeacher(string tno, string name, Sex sex, int age, Level level, string phone)
        {
            var result = GradeRepository.AddTeacher(tno, name, sex, age, level, phone);
            if (result)
            {
                return ApiResponse.OK();
            } 
            else
            {
                return ApiResponse.BadRequest("该教师已存在");
            }
        }

        [HttpGet("term/add")]
        [HttpPost("term/add")]
        public object AddTerm(int year, Term term)
        {
            var result = GradeRepository.AddTerm(year, term);
            if (result)
            {
                return ApiResponse.OK();
            } 
            else
            {
                return ApiResponse.BadRequest("该学期已存在");
            }
        }

        [HttpGet("course/add")]
        [HttpPost("course/add")]
        public object AddCourse(string name, int period, Way way, double credit)
        {
            var result = GradeRepository.AddCourse(name, period, way, credit);
            if (result)
            {
                return ApiResponse.OK();
            }
            else
            {
                return ApiResponse.BadRequest("该课程已存在");
            }
        }

        [HttpGet("open_course/add")]
        [HttpPost("open_course/add")]
        public object AddOpenCourse(int cono, int cno, int year, Term term, string tno)
        {
            var result = GradeRepository.AddOpenCourse(cono, cno, year, term, tno);
            if (result)
            {
                return ApiResponse.OK();
            } 
            else
            {
                return ApiResponse.BadRequest("该开设课程已存在");
            }
        }

        [HttpGet("report/add")]
        [HttpPost("report/add")]
        public object AddReport(string sno, int cono, double grade)
        {
            var result = GradeRepository.AddReport(sno, cono, grade);
            if (result == null)
            {
                return ApiResponse.OK();
            } 
            else
            {
                return ApiResponse.BadRequest(result);
            }
        }
    }
}
