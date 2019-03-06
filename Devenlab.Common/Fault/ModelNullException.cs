using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devenlab.Common.Fault
{
    public class ModelNullException : Exception
    {
        public ModelNullException() : base()
        {
            
        }
        public ModelNullException(string message):base(message)
        {
            
        }
    }
}
