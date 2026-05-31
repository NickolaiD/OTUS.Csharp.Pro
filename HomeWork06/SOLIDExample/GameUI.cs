using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExample
{
    public class GameUI
    {
        public int GetNumberFromUser()
        {
            while (true)
            {
                Console.Write("Введите число: ");

                if (int.TryParse(Console.ReadLine(), out int number))
                    return number;

                Console.WriteLine("Ошибка! Повторите ввод числа");
            }
        }
    }
}
