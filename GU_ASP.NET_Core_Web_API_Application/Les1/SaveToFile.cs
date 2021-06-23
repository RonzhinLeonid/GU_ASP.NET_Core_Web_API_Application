using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Les1
{
    static class SaveToFile
    {
        static readonly JsonSerializerOptions Options = new JsonSerializerOptions() { WriteIndented = true };

        public static async Task SaveToFileAsync<T>(string pathToFile, IEnumerable<T> data)
        {
            var stream = File.Create(pathToFile);
            await JsonSerializer.SerializeAsync(stream, data, Options);
        }
    }
}
