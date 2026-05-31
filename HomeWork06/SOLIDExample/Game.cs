using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExample
{
    public class Game
    {
        private readonly int _min;
        private readonly int _max;
        private readonly int _retryCount;

        public Game(int min, int max, int retryCount)
        {
            if (min >= max)
            {
                throw new ArgumentException("Неверный диапазон чисел");
            }
            _min = min;
            _max = max;
            _retryCount = retryCount;
        }

        public void Start()
        {
            var random = new Random();
            var randomNumber = random.Next(_min, _max);
            int userNumber = 0;
            var win = false;

            Console.WriteLine("Введите число");

            for (int i = 0; i < _retryCount; i++)
            {
                bool isParsed = false;
                do 
                {
                    isParsed = int.TryParse(Console.ReadLine(), out int number);
                    
                    if (isParsed)
                    {
                        userNumber = number;
                    }
                    else
                    {
                        Console.WriteLine("Повторите ввод числа");
                    }
                } 
                
                while (!isParsed);
                
                
                if (userNumber < randomNumber)
                    Console.WriteLine("Больше");
                if (userNumber > randomNumber)
                    Console.WriteLine("Меньше");
                if (userNumber == randomNumber)
                {
                    Console.WriteLine("Верно!");
                    win = true;
                    break;
                }
            }

            if (!win) 
            {
                Console.WriteLine($"Вы проиграли, загаданное число {randomNumber}");
            }

        }
    }
}
