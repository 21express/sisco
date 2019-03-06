using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devenlab.Common.Patterns
{
    public class ProcessErrorEventArgs : EventArgs
    {
        public ProcessErrorEventArgs(Exception err)
        {
            Exception = err;
        }

        public Exception Exception { get; set; }

    }
}
