using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class CorporatePickupDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int CorporatePickupId { get; set; }
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string ShipmentCode { get; set; }
        public int ServiceTypeId { get; set; }
        public int PackageTypeId { get; set; }
        public Int16 TtlPiece { get; set; }
        public decimal TtlChargeableWeight { get; set; }
        public decimal TtlGrossWeight { get; set; }
        public bool Checked { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedPc { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
