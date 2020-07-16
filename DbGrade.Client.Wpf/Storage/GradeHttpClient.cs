﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Dto;
using Tro.DbGrade.FrameWork.Models;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    /// <summary>
    /// 封装http服务，用于从服务器获取需要的数据。
    /// </summary>
    public class GradeHttpClient
    {
        public GradeHttpClient(HttpClient client, IOptions<StorageOptions> options)
        {
            Client = client;
            client.BaseAddress = new Uri(options.Value.Uri);
        }

        public HttpClient Client { get; }

        public async Task<IEnumerable<StudentOut>> GetStudentsAsync(string scope, string tag = null, int? year = null)
        {
            var response = await Client.PostAsync(ApiRoute.Students, new Dictionary<string, object>
            {
                { "scope", scope },
                { "tag", tag },
                { "year", year }
            });
            var value = await response.ReadTo<IEnumerable<StudentOut>>();
            return value;
        }

        public async Task<IEnumerable<FrameWork.Dto.Profession>> GetStudentStructAsync()
        {
            var response = await Client.PostAsync(ApiRoute.StudentStruct);
            var value = await response.ReadTo<IEnumerable<FrameWork.Dto.Profession>>();
            return value;
        }

        public async Task<IEnumerable<FrameWork.Dto.Province>> GetDestStructAsync()
        {
            var response = await Client.PostAsync(ApiRoute.DestStruct);
            var value = await response.ReadTo<IEnumerable<FrameWork.Dto.Province>>();
            return value;
        }

        public async Task<IEnumerable<XTerm>> GetTermsAsync() {

            var response = await Client.PostAsync(ApiRoute.Terms);
            var value = await response.ReadTo<IEnumerable<XTerm>>();
            return value;
        }
        
        public async Task<IEnumerable<DestSummary>> GetDestSummariesAysnc(string scope, string tag = null, int? year = null)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.DestSummary, new Dictionary<string, object> {
                    { "scope" ,scope },
                    { "tag", tag },
                    { "year", year }
                });
                var value = await response.ReadTo<IEnumerable<DestSummary>>();
                return value;
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<ClassSummary>> GetClassSummariesAsync(string scope, string tag = null, int? year = null)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.ClassSummary, new Dictionary<string, object>
                {
                    { "scope", scope },
                    { "tag", tag },
                    { "year", year }
                });
                return await response.ReadTo<IEnumerable<ClassSummary>>();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<ReportsView>> GetReportsAsync(string scope, string tag, int? year, int? cyear)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.Reports, new Dictionary<string, object>
                {
                    { "scope", scope },
                    { "tag", tag },
                    { "year", year},
                    { "cyear", cyear }
                });
                return await response.ReadTo<IEnumerable<ReportsView>>();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.Teachers);
                return await response.ReadTo<IEnumerable<Teacher>>();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<ReportSummaryOut>> GetReportSummariesAsync(string scope, string tag, int? year, int? cyear)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.ReportSummary, new Dictionary<string, object> {
                    { "scope", scope },
                    { "tag", tag },
                    { "year", year},
                    { "cyear", cyear }
                });
                return await response.ReadTo<IEnumerable<ReportSummaryOut>>();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<CourseSummaryView>> GetCourseSummariesAsync(string scope, string tag, int? year, int? cyear)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.CourseSummary, new Dictionary<string, object> {
                    { "scope", scope },
                    { "tag", tag },
                    { "year", year},
                    { "cyear", cyear }
                });
                return await response.ReadTo<IEnumerable<CourseSummaryView>>();
            } 
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesAysnc()
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.Course);
                return await response.ReadTo<IEnumerable<Course>>();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<ApiResponse> AddDest(string province, string city)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.AddDest, new Dictionary<string, object>
                {
                    { "province", province },
                    { "city", city }
                });
                return await response.ReadTo<ApiResponse>();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<ApiResponse> AddStruct(string profession, string xclass, int year)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.AddStruct, new Dictionary<string, object>
                {
                    { "profession", profession },
                    { "xclass", xclass },
                    { "year", year }
                });
                return await response.ReadTo<ApiResponse>();
            }
            catch(JsonException e)
            {
                Console.WriteLine(e);
                return null;
            } 
        }

        public async Task<ApiResponse> AddStudent(string sno, string name, Sex sex, int age, int cno, int cino)
        {
            try
            {
                var response = await Client.PostAsync(ApiRoute.AddStudent, new Dictionary<string, object> {
                    { "sno", sno },
                    { "name", name},
                    { "sex", sex },
                    { "age", age },
                    { "cno", cno },
                    { "cino", cino }
                });
                return await response.ReadTo<ApiResponse>();
            } 
            catch(JsonException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
