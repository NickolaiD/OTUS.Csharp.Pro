using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = F.Get();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            string fSerialized = string.Empty;
            for (int x = 1; x < 100000; x++)
            {
                fSerialized = Serializer.Serialize(f);
            }

            stopWatch.Stop();
            Console.WriteLine("Собственная реализация");
            Console.WriteLine(fSerialized);
            Console.WriteLine($"Время выполнения: {stopWatch.ElapsedMilliseconds}");

            stopWatch.Restart();
            stopWatch.Start();
                        
            for (int x = 1; x < 100000; x++)
            {
                fSerialized = JsonSerializer.Serialize(f);
            }

            stopWatch.Stop();

            Console.WriteLine("\nJson Serializer");
            Console.WriteLine(fSerialized);
            Console.WriteLine($"Время выполнения: {stopWatch.ElapsedMilliseconds}");

            string csvLine = "10,20,30,40,50";
            var person = Serializer.Deserialize<F>(csvLine);


            stopWatch.Restart();
            stopWatch.Start();
            for (int x = 1; x < 100000; x++)
            {
                var persons = LoadFromFile<F>(Path.Combine("d:", "data.csv"));
            }
            stopWatch.Stop();
            
            
            Console.WriteLine($"\nСериализация из файла, время выполнения: {stopWatch.ElapsedMilliseconds}");

            Console.ReadKey();
        }

        public static List<T> LoadFromFile<T>(string filePath, char delimiter = ',') where T : new()
        {
            List<T> result = new List<T>();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    result.Add(Serializer.Deserialize<T>(lines[i], delimiter));
                }
            }

            return result;
        }
    }
}