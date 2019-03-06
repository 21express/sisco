using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class CorporatePickupModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public int CorporateId { get; set; }
        public short TtlPod { get; set; }
        public short TtlPiece { get; set; }
        public decimal TtlGrossWeight { get; set; }
        public decimal TtlChargeable { get; set; }
        public decimal TtlSales { get; set; }
        public decimal TtlPpn { get; set; }
        public decimal TtlCommission { get; set; }
        public decimal TtlPph23 { get; set; }
        public decimal TtlNetCommission { get; set; }
        public decimal Balance { get; set; }
        public int? MessengerId { get; set; }
        public bool IsPrint { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public String CreatedPc { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public String ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
