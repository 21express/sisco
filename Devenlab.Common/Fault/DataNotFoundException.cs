using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devenlab.Common.Fault
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

        public DataNotFoundException(string message, params IListParameter[] whereTerm) 
			: base(message)
        {
            listParameters = whereTerm;
        }

        private readonly IList<IListParameter> listParameters; 

        public override string Message
        {
            get
            {
                var bmessage = "Base Message: " +  base.Message + Environment.NewLine;
                if (listParameters != null)
                {
                    bmessage += WhereTerm.GetParamaterForMessage(listParameters.ToArray());
                }
                return bmessage;

            }
        }
    }
}
