using System.Diagnostics;

namespace FileReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var spaceCount = GetSpaceCountFromFilesInFolder(Path.Combine("D:", "files"));
            sw.Stop();
            Console.WriteLine($"Общее количество пробелов: {spaceCount}");
            Console.WriteLine($"Время выполнения (миллисекунд): {sw.ElapsedMilliseconds}");
        }

        static int GetSpaceCountFromFilesInFolder(string filePath)
        {
            var fileList = Directory.GetFiles(filePath);

            var tasks = new List<Task<int>>();
            foreach (var file in fileList)
            {
                tasks.Add(Task<int>.Run(() => GetSpaceCountFromFile(file)));
            }
            Task.WaitAll(tasks);

            var totalSpaceCount = 0;
            foreach (var task in tasks)
            {
                totalSpaceCount += task.Result;
            }

            return totalSpaceCount;
        }
        
        static int GetSpaceCountFromFile(string fileName)
        {
            var text = File.ReadAllText(fileName);
            return text.Where(x => x.Equals(' ')).Count();
        }
    }
}
