namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var tr = new Triangle("red", 1, 1, 2, 3, 4);
            var tr1 = (Triangle)tr.MyClone();
            Console.WriteLine(tr1.SideC);


        }
    }
}
