using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class OtherInvoiceAcceptanceDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int OtherInvoiceAcceptanceId { get; set; }
        public int OtherInvoiceId { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public class OtherInvoiceAcceptanceDetail : OtherInvoiceAcceptanceDetailModel
    {
        public string OriginBranch { get; set; }
        public string RefNumber { get; set; }
        public decimal Total { get; set; }
        public string StateChange2 { get; set; }
        public bool Accepted { get; set; }
        public int DestBranchId { get; set; }
    }
}