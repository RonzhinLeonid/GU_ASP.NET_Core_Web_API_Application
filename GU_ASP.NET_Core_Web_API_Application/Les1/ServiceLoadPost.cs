﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Les1
{
    static class ServiceLoadPost
    {
        static HttpClient Client;
        static readonly JsonSerializerOptions Options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        public static void InitializeClient(string baseApiUrl)
        {
            Client = new HttpClient() { BaseAddress = new Uri(baseApiUrl) };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<Post>> LoadPostsAsync(int startId = 1, int count = 1)
        {
            var tasks = Enumerable.Range(startId, count)
                                  .Select(id => Client.GetStringAsync($"posts/{id}")
                                  .ContinueWith(x => JsonSerializer.Deserialize<Post>(x.Result, Options)));
            await Task.WhenAll(tasks);
            return tasks.Select(x => x.Result);
        }
    }
}
