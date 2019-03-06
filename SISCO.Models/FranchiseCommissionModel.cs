using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FranchiseCommissionModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public DateTime? DateProcess { get; set; }
        public string ShipmentCode { get; set; }
        public Int32 FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public Int32 ShipmentId { get; set; }
        public bool ShipmentVoided { get; set; }
        public short TtlPiece { get; set; }
        public Decimal TtlGrossWeight { get; set; }
        public Decimal TtlChargeableWeight { get; set; } 
        public Decimal TotalSales { get; set; }
        public Decimal PPN { get; set; }
        public Decimal Commission { get; set; }
        public Decimal PPH23 { get; set; }
        public Decimal TotalNetCommission { get; set; }
        public decimal? OtherFee { get; set; }
        public decimal? InsuranceFee { get; set; }
        public decimal Debs { get; set; }
        public string PackageType { get; set; }
        public string ServiceType { get; set; }
        public string Notes { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public bool Checked { get; set; }
        public string CustomerName { get; set; }
        public string Npwp { get; set; }
        public string NpwpName { get; set; }
        public string ShipperName { get; set; }
        public string StatusPayment { get; set; }
        public bool IsDropPoint { get; set; }
    }
}