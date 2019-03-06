using System;

namespace Devenlab.Common.Interfaces
{
    public interface IBaseModel
    {
        int Id { get; set; }

        Boolean Rowstatus { get; set; }

        DateTime Rowversion { get; set; }

        DateTime Createddate { get; set; }
		
		string Createdby { get; set; }
        
		string Modifiedby { get; set; }

        DateTime? Modifieddate { get; set; }

        EnumStateChange StateChange { get; set; }

    }
}
