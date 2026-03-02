using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    // Класс Circle (наследник Shape)
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string color, int x, int y, double radius) : base(color, x, y)
        {
            Radius = radius;
        }

        public override Shape MyClone()
        {
            // Поверхностное копирование (для значимых типов достаточно)
            return new Circle(Color, X, Y, Radius);
        }

        public override void Draw()
        {
            Console.WriteLine($"Рисуем круг: {GetInfo()}");
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Радиус: {Radius}";
        }

    }
}
