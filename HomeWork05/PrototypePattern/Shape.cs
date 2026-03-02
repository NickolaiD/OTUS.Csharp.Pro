using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public abstract class Shape : IShape, IMyClonable<Shape>, ICloneable
    {
        public string Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        protected Shape(string color, int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }


        public abstract Shape MyClone();
        public abstract object Clone();
        public abstract void Draw();
        public virtual string GetInfo()
        {
            return $"Цвет: {Color}, Координаты: ({X}, {Y})";
        }
    }
}
