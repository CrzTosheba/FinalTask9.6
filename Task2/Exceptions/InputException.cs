using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Exceptions
{
    internal class InputException:Exception
    {
        public InputException(string s) : base(s)
            { }



    }
}
