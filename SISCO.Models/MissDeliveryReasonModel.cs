using System;
using System.ComponentModel;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class MissDeliveryReasonModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public String Code { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
