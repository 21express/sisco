using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class ClaimedModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public int BranchId { get; set; }
        public string CustomerName { get; set; }
        public int ClaimedBranchId { get; set; }
        public int CustomerBranchId { get; set; }
        public string LetterNo { get; set; }
        public string Description { get; set; }
        public string DocName { get; set; }
        public decimal Total { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class ClaimedSearch
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public string CustomerName { get; set; }
        public string LetterNo { get; set; }
        public decimal Total { get; set; }
        public string ShipmentCode { get; set; }
    }

    public class ClaimedPaymentDetail
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string LetterNo { get; set; }
        public string DocName { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public string StateChange { get; set; }
    }

    public class ClaimReport
    {
        public DateTime ClaimDate { get; set; }
        public string LetterNo { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string BilledTo { get; set; }
        public string CustomerBranch { get; set; }
        public decimal Total { get; set; }
        public decimal? Payment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentCode { get; set; }
    }
}