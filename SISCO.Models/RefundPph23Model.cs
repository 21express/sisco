using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class RefundPph23Model : IBaseModel
    {
        public Int32 Id { get; set; } 
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public int BranchId { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public string Createdpc { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string Modifiedpc { get; set; }
    }
}
