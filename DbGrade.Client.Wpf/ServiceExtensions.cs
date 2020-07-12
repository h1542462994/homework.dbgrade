using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace Tro.DbGrade.Client.Wpf
{
    public static class ServiceExtensions
    {
        public static async Task<HttpResponseMessage> GetAsync(this HttpClient client, string uri, IDictionary<string,string> parameters)
        {
            StringBuilder builder = new StringBuilder(uri);
            builder.Append("?");
            foreach (var item in parameters)
            {
                if (item.Value != null)
                {
                    builder.Append($"{item.Key}={item.Value}&");

                }
            }

            uri = builder.ToString();
            uri = uri.TrimEnd('&', '?');

            return await client.GetAsync(uri);
        }

        public static async Task<T> ReadTo<T>(this HttpResponseMessage message)
        {
            var str = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static T GetService<T>(this IServiceProvider provider)
        {
            return (T)provider.GetService(typeof(T));
        }
        
    }
}
