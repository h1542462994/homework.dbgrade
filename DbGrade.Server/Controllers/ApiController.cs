﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
