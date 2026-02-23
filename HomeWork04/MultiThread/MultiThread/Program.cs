using System.Diagnostics;

namespace MultiThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 10000000;
            int[] array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(0, 10);
            }

            var sw = new Stopwatch();
            sw.Start();

            Simple(ref array);

            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds}");

            var res = ThreadCalculate(array);
            Console.WriteLine($"{res}");
        }

        static void Simple(ref int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            Console.WriteLine($"{sum}");
        }

        static long ThreadCalculate(int[] array)
        {
            var sw = new Stopwatch();
            sw.Start();

            var m = array.Length - 1;
            int cores =  Environment.ProcessorCount;
            long chunkSize = (m + 1L) / cores;

            var threads = new List<Thread>(cores);
            long total = 0;
            object lockObj = new();

            for (int i = 0; i < cores; i++)
            {
                int start = (int)(i * chunkSize);
                int end = (i == cores - 1) ? m : (int)(start + chunkSize - 1);

                Thread t = new(() =>
                {
                    long localSum = 0;
                    for (int num = start; num <= end; num++)
                      localSum += array[num];

                    lock (lockObj) { total += localSum; }
                });

                threads.Add(t);
                t.Start();
            }

            foreach (Thread t in threads) t.Join();
            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds}");
      
            return total;
        }
    }
}
