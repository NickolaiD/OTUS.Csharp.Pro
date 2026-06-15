using System;
using System.Collections.Generic;
using System.Text;

namespace OCP
{
    internal class ClassicGameStrategy : IGameStrategy
    {
        public string GetHint(int userInput, int target)
        {
            if (userInput < target) return "Больше";
            if (userInput > target) return "Меньше";
            return "Верно!";
        }

        public bool IsWin(int guess, int target) => guess == target;

    }
}
