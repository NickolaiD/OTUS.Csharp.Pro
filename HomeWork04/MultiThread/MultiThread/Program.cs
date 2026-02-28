using System.Diagnostics;

namespace MultiThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = new int[] { 100000, 1000000, 10000000};

            foreach (var size in sizes)
            {
                Console.WriteLine($"Количество элементов - {size}");
                int[] array = new int[size];
                Random random = new Random();

                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next(0, 10);
                }

                var sw = new Stopwatch();
                Simple(array, sw);
                ThreadCalculate(array, sw);
                Plinq(array, sw);
                Console.WriteLine();
            }
        }

        static void Simple(int[] array, Stopwatch sw)
        {
            sw.Reset();
            sw.Start();

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            sw.Stop();

            Console.WriteLine($"Простой обход - сумма {sum}, время {sw.ElapsedMilliseconds}");
            
        }

        static void ThreadCalculate(int[] array, Stopwatch sw)
        {
            sw.Reset();
            sw.Start();

            var m = array.Length - 1;
            int cores =  Environment.ProcessorCount;
            long chunkSize = (m + 1L) / cores;

            var threads = new List<Thread>(cores);
            int sum = 0;
            object lockObj = new();

            for (int i = 0; i < cores; i++)
            {
                int start = (int)(i * chunkSize);
                int end = (i == cores - 1) ? m : (int)(start + chunkSize - 1);

                Thread t = new(() =>
                {
                    int localSum = 0;
                    for (int num = start; num <= end; num++)
                      localSum += array[num];

                    lock (lockObj) { sum += localSum; }
                });

                threads.Add(t);
                t.Start();
            }

            foreach (Thread t in threads) t.Join();
            sw.Stop();

            Console.WriteLine($"Thread - сумма {sum}, время {sw.ElapsedMilliseconds}");
        }

        static void Plinq(int[] array, Stopwatch sw)
        {
            sw.Reset();
            sw.Start();
            long sum = array.AsParallel().Sum();
            sw.Stop();

            Console.WriteLine($"PLINQ - сумма {sum}, время {sw.ElapsedMilliseconds}");
        }
    }
}
