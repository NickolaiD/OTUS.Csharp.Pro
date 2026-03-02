using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string color, int x, int y, double width, double height)
            : base(color, x, y)
        {
            Width = width;
            Height = height;
        }

        public override Shape MyClone()
        {
            return new Rectangle(Color, X, Y, Width, Height);
        }

        public override void Draw()
        {
            Console.WriteLine($"Рисуем прямоугольник: {GetInfo()}");
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Ширина: {Width}, Высота: {Height}";
        }
    }
}
