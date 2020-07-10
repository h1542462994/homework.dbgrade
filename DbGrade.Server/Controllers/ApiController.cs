using Microsoft.AspNetCore.Mvc;
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
        public object Struct(int? year)
        {
            return GradeRepository.GetStruct(year);
        }

        [HttpGet("students")]
        [HttpPost("students")]
        public object Students(string scope, int? tag, int? year)
        {
            return GradeRepository.GetStudents(scope, tag, year);
        }

        [HttpGet("dest_struct")]
        [HttpPost("dest_struct")]
        public object DestStruct(int? year)
        {
            return GradeRepository.GetDestStruct(year);
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
    }
}
