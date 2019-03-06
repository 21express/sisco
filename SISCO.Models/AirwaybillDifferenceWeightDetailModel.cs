using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class AirwaybillDifferenceWeightDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int AirwaybillDifferenceWeightId { get; set; }
        public int ShipmentId { get; set; }
        public short TtlPiecePod { get; set; }
        public decimal TtlChargeableWeightPod { get; set; }
        public int ConsolidationId { get; set; }
        public short TtlPieceConsol { get; set; }
        public decimal TtlChargeableWeightConsol { get; set; }
        public int AirwaybillId { get; set; }
        public decimal TtlChargeableWeightAirwaybill { get; set; }
        public decimal DiffWeight { get; set; }
        public bool IsPacking { get; set; }
        public bool IsDiff { get; set; }
        public decimal DiffPercent { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class DiffWeightAirwaybillShipmentModel
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public int AirwaybillDifferenceWeightId { get; set; }
        public int ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public string CustomerName { get; set; }
        public int TtlPiecePod { get; set; }
        public string DestBranchCode { get; set; }
        public decimal TtlChargeableWeightPod { get; set; }
        public int ConsolidationId { get; set; }
        public string ConsolidationCode { get; set; }
        public int TtlPieceConsol { get; set; }
        public decimal TtlChargeableWeightConsol { get; set; }
        public int AirwaybillId { get; set; }
        public decimal TtlChargeableWeightAirwaybill { get; set; }
        public decimal DiffWeight { get; set; }
        public bool IsPacking { get; set; }
        public bool IsDiff { get; set; }
        public decimal DiffPercent { get; set; }
        public string StateChange { get; set; }
    }
}