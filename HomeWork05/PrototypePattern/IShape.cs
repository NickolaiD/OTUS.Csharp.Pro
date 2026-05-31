using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    // Базовый интерфейс для прототипа
    public interface IShape
    {
        void Draw();
        string GetInfo();
    }
}
