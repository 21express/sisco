using System;
using System.Text;
using Devenlab.Common.Interfaces;

namespace Devenlab.Common.Fault
{
	[Serializable]
	public class BusinessException: Exception 
	{
		public BusinessException(string message) : base(message)
		{
            Severity = Severity.Fatal;
		}

        public BusinessException(string message, Severity severity)
            : base(message)
        {
            Severity = Severity.Fatal;
            Severity = severity;
        }

        public Severity Severity { get; set; }

		public BusinessException(string message, Severity severity,  Exception innerException)
			: base(message, innerException)
		{
		    Severity = severity;
		}

		public BusinessException(string message, Severity severity, IBaseModel model) 
			: base(message)
		{
			BusinessModel = model;
		    Severity = severity;
		}

		public BusinessException(string message, Severity severity, IBaseModel model, Exception innerException)
			: base(message, innerException)
		{
			BusinessModel = model;
		    Severity = severity;
		}

		public override string StackTrace
		{
			get
			{
				var result = new StringBuilder();
				if ( BusinessModel != null)
				{
					foreach(var b in BusinessModel.GetType().GetProperties())
					{
						result.AppendLine("\t" + b.Name + ": " + b.GetValue(BusinessModel, null));
					}
				}
				var a = result + base.StackTrace;
				return a;
			}
		}
		
		public IBaseModel BusinessModel { get; set; }
		
	}

    public enum Severity
    {
        Info,
        Warning,
        Mandatory,
        Error,
        Fatal
    }
}
