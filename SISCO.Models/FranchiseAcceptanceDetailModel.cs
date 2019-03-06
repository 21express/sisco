using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FranchiseAcceptanceDetailModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public Int32 FranchiseAcceptanceId { get; set; }
        public Int32? ShipmentId { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string ShipmentCode { get; set; }
        public Int32? ServiceTypeId { get; set; }
        public Int32? PackageTypeId { get; set; }
        public Int32? PaymentMethodId { get; set; }
        public Int16? TtlPiece { get; set; }
        public Decimal? TtlGrossWeight { get; set; }
        public Decimal? TtlChargeableWeight { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
    }
}
