using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tro.DbGrade.FrameWork.Models;

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

        public async Task<IEnumerable<StudentOutView>> GetStudentsAsync(string scope, string tag = null, int? year = null)
        {
            var response = await Client.PostAsync(ApiRoute.Students, new Dictionary<string, object>
            {
                { "scope", scope },
                { "tag", tag },
                { "year", year }
            });
            var value = await response.ReadTo<IEnumerable<StudentOutView>>();
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
        

    }
}
