namespace HomeWork08
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            var people = new List<Person>
            {
                new Person { Name = "Анна", Age = 25 },
                new Person { Name = "Борис", Age = 30 },
                new Person { Name = "Виктор", Age = 40 },
                new Person { Name = "Галина", Age = 35 }
            };

            var oldest = people.GetMax<Person>(p => p.Age);
            if (oldest != null)
            {
                Console.WriteLine($"Самый старший: {oldest.Name} {oldest.Age}");
            }


            var traverser = new DirectoryTraverser();
            traverser.FileFound += Traverser_OnFileFound;
            var files = traverser.GetFiles(@"C:\Temp");
            traverser.FileFound -= Traverser_OnFileFound;

            Console.WriteLine($"Всего файлов: {files.Count}");
        }

        private static void Traverser_OnFileFound(object sender, FileArgs e)
        {
            Console.WriteLine(e.Message);
            e.StopWork = true;  // возможность отмены дальнейшего поиска из обработчика
        }
    }
}
