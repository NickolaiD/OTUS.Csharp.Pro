using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork08
{
    public class FileArgs : EventArgs
    {
        public string Message { get; set; } = string.Empty;
        public bool StopWork { get; set; }
    }
}
