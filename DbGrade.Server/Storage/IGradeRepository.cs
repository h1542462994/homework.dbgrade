using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.Server.Dto;
using Tro.DbGrade.Server.Models;

namespace Tro.DbGrade.Server.Storage
{
    public interface IGradeRepository
    {
        IEnumerable<Dto.Profession> GetStruct(int? year);

        IEnumerable<Dto.Province> GetDestStruct(int? year);

        IEnumerable<StudentOutView> GetStudents(string scope, int? tag, int? year);

        IEnumerable<ReportsView> GetReports(string scope, string tag, int? year, int? cyear);

        IEnumerable<ReportSummary> GetReportSummaries(string scope, int? tag, int? year, int? cyear);
        IEnumerable<CourseSummaryView> GetCourseSummaries(string scope, string tag, int? year, int? cyear);
    }
}
