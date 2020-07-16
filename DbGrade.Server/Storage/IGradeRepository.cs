using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Dto;
using Tro.DbGrade.FrameWork.Models;
using Tro.DbGrade.FrameWork.Models.Types;

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

        IEnumerable<Course> GetCourses();

        void AddDest(string province, string city);

        void AddStruct(string profession, string xclass, int year);

        bool AddStudent(string sno, string name, Sex sex, int age, int cno, int cino);

        bool AddTeacher(string tno, string name, Sex sex, int age, Level level, string phone);

        bool AddTerm(int year, Term term);

        bool AddCourse(string name, int period, Way way, double credit);

        bool AddOpenCourse(int cono, int cno, int year, Term term, string tno);
       
        string AddReport(string sno, int cono, double grade);
    }
}
