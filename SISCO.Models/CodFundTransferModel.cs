using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class CodFundTransferModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public int BranchId { get; set; }
        public int DestBranchId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal Adjustment { get; set; }
        public decimal Total { get; set; }
        public bool ConfirmAdmin { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public string CreatedPc { get; set; }
        public string ModifiedPc { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
