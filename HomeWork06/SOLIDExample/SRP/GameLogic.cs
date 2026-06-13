using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExample
{
    public class GameLogic
    {
        public Result Check(int userInput, int numberToCheck)
        {
            if (userInput < numberToCheck)
                return(Result.upper);
            if (userInput > numberToCheck)
                return (Result.lower);
            return (Result.win);

        }
    }
}
