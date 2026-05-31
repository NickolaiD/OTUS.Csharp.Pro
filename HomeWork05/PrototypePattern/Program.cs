namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle("red", 1, 2, 3, 4, 5);
            triangle.Draw();

            var triangle1 = triangle.MyClone();  //приведение типа не требуется
            Console.WriteLine("MyClone " + triangle1.GetInfo());  

            var triangle2 = (Triangle)triangle.Clone();
            Console.WriteLine("Clone " + (triangle2).GetInfo());

            Console.WriteLine();
            var circle = new Circle("black", 10, 20, 30);
            circle.Draw();

            var circle1 = circle.MyClone();  //приведение типа не требуется
            Console.WriteLine("MyClone " + circle1.GetInfo());  

            var circle2 = (Circle)circle.Clone();
            Console.WriteLine("Clone " + (circle2).GetInfo());

        }
    }
}
