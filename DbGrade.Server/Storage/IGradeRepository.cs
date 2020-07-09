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
        public IEnumerable<Dto.Profession> GetStruct(int? year);

        public IEnumerable<Dto.Province> GetDestStruct(int? year);

        public IEnumerable<StudentsView> GetStudents(string scope, int? tag, int? year);
        IEnumerable<ReportsView> GetReports(string scope, string tag, int? year, int? cyear);
    }
}
