using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Les1_V2
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var tasks = new List<Task<Post>>();
            int start = -1;
            int count = 10;
            string pathToFile = "result1.json";
            for (int i = start; i < count + start; i++)
            {
                try
                {
                    tasks.Add(WorkAsync("https://jsonplaceholder.typicode.com", i));
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
            await Task.WhenAll(tasks);

            await SaveToFile.SaveFileAsync(pathToFile, tasks);
        }

        private static async Task<Post> WorkAsync(string apiUrl, int postId)
        {
            var serviceLoadPost = new ServiceLoadPost(apiUrl);
            var posts = await serviceLoadPost.LoadPostAsync(postId);
            Task.WaitAll();
            return posts;
        }
    }
}