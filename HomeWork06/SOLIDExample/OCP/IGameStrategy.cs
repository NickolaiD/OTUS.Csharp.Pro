using System;
using System.Collections.Generic;
using System.Text;

namespace OCP
{
    public interface IGameStrategy
    {
        string GetHint(int userInput, int target);
        bool IsWin(int userInput, int target);
    }
}
