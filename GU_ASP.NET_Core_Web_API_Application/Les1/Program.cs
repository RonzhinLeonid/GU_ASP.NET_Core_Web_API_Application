using System;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Les1
{
    class Program
    {

        static void Main(string[] args)
        {
            WorkAsync("https://jsonplaceholder.typicode.com", "result.json", 4, 10);
            Console.WriteLine();
        }
        static async void WorkAsync(string apiUrl, string pathToFile, int start, int count = 1)
        {
            ServiceLoadPost.InitializeClient(apiUrl);
            var posts = await ServiceLoadPost.LoadPostsAsync(start, count);

            await SaveToFile.SaveToFileAsync(pathToFile, posts);
        }
    }
}
