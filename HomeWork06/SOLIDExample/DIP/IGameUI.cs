using System;
using System.Collections.Generic;
using System.Text;

namespace DIP
{
    public interface IGameUI
    {
        public int GetNumberFromUser();
        public void ShowMessage(string message);
        
    }
}
