namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle("red", 1, 2, 3, 4, 5);
            triangle.Draw();

            var triangle1 = triangle.MyClone();
            Console.WriteLine("MyClone " + triangle1.GetInfo());  //приведение типа не требуется

            var triangle2 = triangle.Clone();
            Console.WriteLine("Clone " + ((Triangle)triangle2).GetInfo());

            Console.WriteLine();
            var circle = new Circle("black", 10, 20, 30);
            circle.Draw();

            var circle1 = circle.MyClone();
            Console.WriteLine("MyClone " + circle1.GetInfo());  //приведение типа не требуется

            var circle2 = circle.Clone();
            Console.WriteLine("Clone " + ((Circle)circle2).GetInfo());

        }
    }
}
