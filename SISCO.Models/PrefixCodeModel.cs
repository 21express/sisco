using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class PrefixCodeModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public String Prefix { get; set; }
        public String Table { get; set; }
        public SByte Tgl { get; set; }
        public SByte Bulan { get; set; }
        public short Tahun { get; set; }
        public Int32 Urut { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
    }
}


