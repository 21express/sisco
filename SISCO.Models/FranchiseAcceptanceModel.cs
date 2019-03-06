using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FranchiseAcceptanceModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public String Code { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 FranchisePickupId { get; set; }
        public Int32 FranchiseId { get; set; }
        public string FranchisePickupCode { get; set; }
        public Int16? TtlPiece { get; set; }
        public Decimal? TtlGrossWeight { get; set; }
        public Decimal? TtlChargeableWeight { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String CreatedPc { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
        public String ModifiedPc { get; set; }
    }
}
