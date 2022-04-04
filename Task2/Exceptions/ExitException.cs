using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Exceptions
{
    internal class ExitException:Exception
    {
        public ExitException():base()
        {

        }
        public ExitException(string s):base(s)
        {
                
        }
    }
}
