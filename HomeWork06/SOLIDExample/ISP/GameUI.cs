using System;
using System.Collections.Generic;
using System.Text;

namespace ISP
{
    public class GameUI : IGetNumberFromUser, IShowMessage
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

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
