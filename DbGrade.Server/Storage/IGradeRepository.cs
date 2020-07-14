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
        IEnumerable<FrameWork.Dto.Profession> GetStruct();

        IEnumerable<FrameWork.Dto.Province> GetDestStruct();


        IEnumerable<DestSummary> GetDestSummaries(string scope, int? tag, int? year);
        
        IEnumerable<ClassSummary> GetClassSummaries(string scope, int? tag, int? year);

        IEnumerable<StudentOut> GetStudents(string scope, int? tag, int? year);

        IEnumerable<ReportsView> GetReports(string scope, string tag, int? year, int? cyear);

        IEnumerable<ReportSummaryOut> GetReportSummaries(string scope, int? tag, int? year, int? cyear);
        IEnumerable<CourseSummaryView> GetCourseSummaries(string scope, string tag, int? year, int? cyear);
        IEnumerable<OpenCoursesView> GetOpenCourses(string scope, string tag, int? year, int? cyear);
        IEnumerable<XTerm> GetTerms();
        IEnumerable<Teacher> GetTeachers();
    }
}
