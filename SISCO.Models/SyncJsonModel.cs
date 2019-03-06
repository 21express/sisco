using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class SyncJsonModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public string Json { get; set; }
        public bool Imported { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Createdpc { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string Modifiedby { get; set; }
        public string Modifiedpc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
