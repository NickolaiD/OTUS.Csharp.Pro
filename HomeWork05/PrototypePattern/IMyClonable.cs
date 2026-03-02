using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    internal interface IMyClonable<T>
    {
        public T MyClone();
    }
}
