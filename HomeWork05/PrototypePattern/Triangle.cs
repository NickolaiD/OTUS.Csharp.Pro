using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    // Класс Triangle (наследник Shape)
    public class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(string color, int x, int y, double sideA, double sideB, double sideC)
            : base(color, x, y)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override Shape MyClone()
        {
            return new Triangle(Color, X, Y, SideA, SideB, SideC);
        }

        public override void Draw()
        {
            Console.WriteLine($"Рисуем треугольник: {GetInfo()}");
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Стороны: {SideA}, {SideB}, {SideC}";
        }

        public override object Clone()
        {
            return (new Triangle(Color, X, Y, SideA, SideB, SideC));
            
        }
    }
}
