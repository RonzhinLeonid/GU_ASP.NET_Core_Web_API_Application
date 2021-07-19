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
            WorkAsync("https://jsonplaceholder.typicode.com", "result1.json", 4, 20);
            WorkAsync("https://jsonplaceholder.typicode.com", "result2.json", 5, 20);
            WorkAsync("https://jsonplaceholder.typicode.com", "result3.json", 6, 20);
            WorkAsync("https://jsonplaceholder.typicode.com", "result4.json", 7, 20);
            WorkAsync("https://jsonplaceholder.typicode.com", "result5.json", 8, 20);
            Console.ReadLine();

            Console.ReadKey();
        }
        static async void WorkAsync(string apiUrl, string pathToFile, int start=1, int count = 1)
        {
            ServiceLoadPost.InitializeClient(apiUrl);
            var posts = await ServiceLoadPost.LoadPostsAsync(start, count);
            await SaveToFile.SaveToFileAsync(pathToFile, posts);
        }
    }
}
