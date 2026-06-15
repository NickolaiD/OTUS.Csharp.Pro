using System;
using System.Collections.Generic;
using System.Text;

namespace ISP
{
    public class Game
    {
        private readonly IGameLogic _gameLogic;
        private readonly IGetNumberFromUser _numberFromUser;
        private readonly IShowMessage _showMessage;
        private readonly Random _random;
        
        public Game(IGameLogic gameLogic, IGetNumberFromUser numberFromUser, IShowMessage showMessage, Random random)
        {
            _gameLogic = gameLogic;
            _numberFromUser = numberFromUser;
            _showMessage = showMessage;
            _random = random;
        }

        public void Play(int min, int max, int retryCount)
        {

            if (min >= max)
            {
                throw new ArgumentException("Неверный диапазон чисел");
            }

            var randomNumber = _random.Next(min, max);
            var win = false;

            for (int i = 0; i < retryCount && !win; i++)
            {
                var userNumber = _numberFromUser.GetNumberFromUser();
                var result = _gameLogic.Check(userNumber, randomNumber);
                switch (result)
                {
                    case Result.lower:
                        _showMessage.ShowMessage("Меньше");
                        break;
                    case Result.upper:
                        _showMessage.ShowMessage("Больше");
                        break;
                    case Result.win:
                        _showMessage.ShowMessage("Верно!");
                        win = true;
                        break;
                }
            }

            if (!win)
            {
                _showMessage.ShowMessage($"Вы проиграли, загаданное число {randomNumber}");
            }

        }
    }
}
