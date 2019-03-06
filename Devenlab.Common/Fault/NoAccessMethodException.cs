using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Devenlab.Common.Fault
{
	public class NoAccessMethodException : Exception
	{
		public NoAccessMethodException(string message) : base(message)
		{
		}

		public NoAccessMethodException(string message, MethodBase methodBase)
			: base(message)
		{
			CurrentMethodBase = methodBase;
		}

		public override string StackTrace
		{
			get
			{
				var result = new StringBuilder();
				if (CurrentMethodBase != null)
				{

					result.AppendLine("\tMethodName: " + CurrentMethodBase.Name);
					result.AppendLine("\tModule: " + CurrentMethodBase.Module);
				}
				var a = result + base.StackTrace;
				return a;
			}
		}

		internal MethodBase CurrentMethodBase { get; set; }

		
	}
}
