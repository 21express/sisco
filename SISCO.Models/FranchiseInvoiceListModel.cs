using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class FranchiseInvoiceListModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int FranchiseInvoiceId { get; set; }
        public int ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int DestCityId { get; set; }
        public string DestCity { get; set; }
        public short TotalPieces { get; set; }
        public decimal TotalCw { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public decimal InsuranceFee { get; set; }
        public decimal OtherFee { get; set; }
        public decimal PackingFee { get; set; }
        public decimal TotalSales { get; set; }
        public decimal Ppn { get; set; }
        public decimal Commission { get; set; }
        public decimal Pph23 { get; set; }
        public decimal NetCommission { get; set; }
        public decimal TotalInvoice { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
