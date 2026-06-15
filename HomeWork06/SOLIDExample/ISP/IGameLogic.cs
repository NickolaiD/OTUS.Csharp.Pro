using System;
using System.Collections.Generic;
using System.Text;

namespace ISP
{
    public interface IGameLogic
    {
        public Result Check(int userInput, int numberToCheck);
    }
}
