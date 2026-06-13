using System;
using System.Collections.Generic;
using System.Text;

namespace DIP
{
    public interface IGameLogic
    {
        public Result Check(int userInput, int numberToCheck);
    }
}
