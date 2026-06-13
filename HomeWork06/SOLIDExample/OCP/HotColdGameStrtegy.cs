using System;
using System.Collections.Generic;
using System.Text;

namespace OCP
{
    public class HotColdGameStrategy : IGameStrategy
    {
        public string GetHint(int guess, int target)
        {
            int diff = Math.Abs(guess - target);
            if (diff == 0) return "Верно!";
            if (diff <= 5) return "Горячо!";
            if (diff <= 15) return "Тепло";
            return "Холодно";
        }

        public bool IsWin(int guess, int target) => guess == target;
    }
}
