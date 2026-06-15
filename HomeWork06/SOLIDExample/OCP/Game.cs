using System;
using System.Collections.Generic;
using System.Text;

namespace OCP

{
    public class Game
    {
        private readonly IGameStrategy _gameStrategy;
        private readonly IGameUI _gameUI;
        private readonly Random _random;

        public Game(IGameStrategy gameStrategy, IGameUI gameUI, Random random)
        {
            _gameStrategy = gameStrategy;
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

            for (int i = 0; i < retryCount;  i++)
            {
                var userNumber = _gameUI.GetNumberFromUser();
                var result = _gameStrategy.GetHint(userNumber, randomNumber);
                _gameUI.ShowMessage(result);
                
                if (_gameStrategy.IsWin(userNumber, randomNumber))
                {
                    _gameUI.ShowMessage($"Победа! Число: {randomNumber}");
                    return;
                }

            }

            _gameUI.ShowMessage($"Вы проиграли, загаданное число {randomNumber}");


        }
    }
}
