using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class TaxInvoiceModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public string Name { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}