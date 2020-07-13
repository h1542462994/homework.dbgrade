using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Dto;
using Tro.DbGrade.FrameWork.Models;

namespace Tro.DbGrade.Server.Storage
{
    public interface IGradeRepository
    {
        IEnumerable<FrameWork.Dto.Profession> GetStruct(int? year);

        IEnumerable<FrameWork.Dto.Province> GetDestStruct(int? year);

        IEnumerable<DestSummaryView> GetDests(string scope, int? tag);

        IEnumerable<StudentOutView> GetStudents(string scope, int? tag, int? year);

        IEnumerable<ReportsView> GetReports(string scope, string tag, int? year, int? cyear);

        IEnumerable<ReportSummary> GetReportSummaries(string scope, int? tag, int? year, int? cyear);
        IEnumerable<CourseSummaryView> GetCourseSummaries(string scope, string tag, int? year, int? cyear);
        IEnumerable<XTerm> GetTerms();
    }
}
