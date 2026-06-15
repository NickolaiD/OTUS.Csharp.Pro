using System;
using System.Collections.Generic;
using System.Text;

namespace DIP
{
    public class Game
    {
        private readonly IGameLogic _gameLogic;
        private readonly IGameUI _gameUI;
        private readonly Random _random;

        public Game(IGameLogic gameLogic, IGameUI gameUI, Random random)
        {
            _gameLogic = gameLogic;
            _gameUI = gameUI;
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
                var userNumber = _gameUI.GetNumberFromUser();
                var result = _gameLogic.Check(userNumber, randomNumber);
                switch (result)
                {
                    case Result.lower:
                        _gameUI.ShowMessage("Меньше");
                        break;
                    case Result.upper:
                        _gameUI.ShowMessage("Больше");
                        break;
                    case Result.win:
                        _gameUI.ShowMessage("Верно!");
                        win = true;
                        break;
                }
            }

            if (!win)
            {
                _gameUI.ShowMessage($"Вы проиграли, загаданное число {randomNumber}");
            }

        }
    }
}
