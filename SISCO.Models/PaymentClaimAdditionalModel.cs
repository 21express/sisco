using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class PaymentClaimAdditionalModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int PaymentInId { get; set; }
        public int ClaimedId { get; set; }
        public decimal Payment { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class PaymentClaim
    {
        public int Id { get; set; }
        public int ClaimedId { get; set; }
        public string LetterNo { get; set; }
        public string CustomerName { get; set; }
        public decimal Payment { get; set; }
        public string DocName { get; set; }
        public decimal Total { get; set; }
        public string StateChange { get; set; }
    }
}