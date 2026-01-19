namespace FileReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileList = Directory.GetFiles(Path.Combine("D:", "files"));

            var  tasks = new List<Task<int>>();
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

            Console.WriteLine($"Общее количество пробелов: {totalSpaceCount}");
        }

        static int GetSpaceCountFromFile(string fileName)
        {
            var text = File.ReadAllText(fileName);
            return text.Where(x => x.Equals(' ')).Count();
        }
    }
}
