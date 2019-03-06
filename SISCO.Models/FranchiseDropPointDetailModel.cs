using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class FranchiseDropPointDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int FranchiseDropPointId { get; set; }
        public int ShipmentId { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class FranchiseDropPointDetailSearch : FranchiseDropPointDetailModel
    {
        public string ShipmentCode { get; set; }
        public string Code { get; set; }
        public DateTime PickupDate { get; set; }
        public string DropPointName { get; set; }
        public int? FranchiseId { get; set; }
        public int BranchId { get; set; }
    }

    public class FranchiseDropPointPickup
    {
        public int Id { get; set; }
        public string ShipmentCode { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string DropPointName { get; set; }
        public int TtlPiece { get; set; }
        public decimal TtlGrossWeight { get; set; }
        public decimal TtlChargeable { get; set; }
        public decimal Total { get; set; }
    }
}