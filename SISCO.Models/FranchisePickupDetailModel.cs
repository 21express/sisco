using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FranchisePickupDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int FranchisePickupId { get; set; }
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string ShipmentCode { get; set; }
        public int ServiceTypeId { get; set; }
        public int PackageTypeId { get; set; }
        public int PaymentMethodId { get; set; }
        public Int16 TtlPiece { get; set; }
        public decimal TtlChargeableWeight { get; set; }
        public decimal TtlGrossWeight { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedPc { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public class PickupDetailRow
    {
        public bool Checked { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal TotalSales { get; set; }
        public decimal Ppn { get; set; }
        public decimal Commission { get; set; }
        public decimal Pph { get; set; }
        public decimal TotalNetCommission { get; set; }
        public short PodStatus { get; set; }
    }
}
