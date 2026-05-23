namespace SOLIDExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var k = random.Next(0, 100);
            int x = -1;
            do
            {
                x = int.Parse(Console.ReadLine());
                if (x < k)
                    Console.WriteLine("Больше");
                if (x > k)
                    Console.WriteLine("Меньше");
            } while (x != k);
            
        }
    }
}
