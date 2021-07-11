using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Les1_V2
{
    internal class ServiceLoadPost
    {
        private static HttpClient Client;
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        private static string _baseApiUrl;

        public ServiceLoadPost(string baseApiUrl)
        {
            _baseApiUrl = baseApiUrl;
            Client = new HttpClient() { BaseAddress = new Uri(_baseApiUrl) };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Post>> LoadPostsAsync(int startId = 1, int count = 1)
        {
            var tasks = Enumerable.Range(startId, count)
                                  .Select(id => LoadPostAsync(id));
            await Task.WhenAll(tasks);
            return tasks.Select(x => x.Result);
        }

        public async Task<Post> LoadPostAsync(int id = 1)
        {
            if (id <= 0)
            {
                return new Post();
            }
            var tasks = await Client.GetAsync(Client.BaseAddress + $"posts/{id}");
            var content = await tasks.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(content, Options);
        }
    }
}