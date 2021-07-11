using System;
using System.Threading.Tasks;

namespace Les1_V2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Work("https://jsonplaceholder.typicode.com", "result1.json", 4, 20).Wait();
            Console.WriteLine("1");
            Work("https://jsonplaceholder.typicode.com", "result2.json", 5, 20).Wait();
            Console.WriteLine("2");
            Work("https://jsonplaceholder.typicode.com", "result3.json", -1, 20).Wait();
            Console.WriteLine("3");
            Task.WaitAll();
        }

        private static async Task Work(string apiUrl, string pathToFile, int start = 1, int count = 1)
        {
            await Task.Run(() => WorkAsync(apiUrl, pathToFile, start, count));
            Task.WaitAll();
        }

        //private static async void WorkAsync(string apiUrl, string pathToFile, int start, int count)
        //{
        //    var serviceLoadPost = new ServiceLoadPost(apiUrl);
        //    var posts = await serviceLoadPost.LoadPostsAsync(start, count);
        //    await SaveToFile.SaveToFileAsync(pathToFile, posts);
        //}

        private static void WorkAsync(string apiUrl, string pathToFile, int start, int count)
        {
            var serviceLoadPost = new ServiceLoadPost(apiUrl);
            var posts = serviceLoadPost.LoadPostsAsync(start, count);
            SaveToFile.SaveFile(pathToFile, posts.Result);
        }
    }
}