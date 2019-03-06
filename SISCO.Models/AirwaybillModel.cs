using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class AirwaybillModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 DestBranchId { get; set;} 
        public String DestBranchName { get; set; }
		public Int32 AirlineId { get; set;}
        public string Airline { get; set; }
        public Int32 AirportId { get; set;}
        public string Airport { get; set; }
        public Int32 DestAirportId { get; set;}
        public string DestAirport { get; set; }
        public Int32 ViaAirportId { get; set;} 
		public String ShipperName { get; set;} 
		public String ShipperAddress { get; set;} 
		public String ConsigneeName { get; set;} 
		public String ConsigneeAddress { get; set;} 
		public String TypeOfPacking { get; set;} 
		public String NatureOfGoods { get; set;} 
		public String Dimension { get; set;} 
		public String PackageCondition { get; set;} 
		public String HandlingInformation1 { get; set;} 
		public String HandlingInformation2 { get; set;} 
		public Int32? FlightId { get; set;}
        public string Flight { get; set; }
        public DateTime? EstDepDate { get; set;} 
		public String EstDepTime { get; set;} 
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
        public Decimal? GwSmu { get; set; }
        public Decimal? DiffSmu { get; set; }
		public Decimal MinWeight { get; set;} 
		public Decimal Tariff { get; set;} 
		public Decimal TariffTotal { get; set;} 
		public Decimal BeforeTaxTotal { get; set;} 
		public Decimal Vat { get; set;} 
		public Decimal AfterTaxTotal { get; set;} 
		public Decimal AdminFee { get; set;} 
		public Decimal AdminFeeVia { get; set;} 
		public Decimal ScFee { get; set;} 
		public Decimal ScFeeMin { get; set;} 
		public Decimal ScFeeMinWeight { get; set;} 
		public Decimal ScFeeTotal { get; set;} 
		public Decimal HandlingFee { get; set;} 
		public Decimal HandlingFeeTotal { get; set;} 
		public Decimal Commission { get; set;} 
		public Decimal CommissionTotal { get; set;} 
		public Decimal SoFee { get; set;} 
		public Decimal SoFeeTotal { get; set;} 
		public Decimal FeFee { get; set;} 
		public Decimal FeFeeTotal { get; set;} 
		public Decimal Total { get; set;} 
		public Decimal TotalWaybill { get; set;} 
		public Decimal VoidFee { get; set;} 
		public Decimal RefundFee { get; set;} 
		public bool Cancelled { get; set;} 
		public bool Posted { get; set;} 
		public bool Voided { get; set;} 
		public bool Refunded { get; set;} 
		public bool AdminIncludeTax { get; set;} 
		public bool ShowAsAgreed { get; set;} 
		public bool Departed { get; set;} 
		public String ActFlight { get; set;} 
		public DateTime? ActDepDate { get; set;} 
		public String ActDepTime { get; set;} 
		public bool ActSame { get; set;} 
		public String ActNote { get; set;} 
		public DateTime? ActUpdated { get; set;} 
		public String ActUsername { get; set;} 
		public bool ActConfirmed { get; set;} 
		public bool Arrived { get; set;} 
		public DateTime? ArrDate { get; set;} 
		public String ArrTime { get; set;} 
		public short? ArrTtlPiece { get; set;} 
		public Decimal? ArrTtlGrossWeight { get; set;} 
		public Int32? ArrBranchId { get; set;} 
		public DateTime? ArrUpdated { get; set;} 
		public String ArrUsername { get; set;} 
		public String SalesRef { get; set;} 
		public bool Waybilled { get; set;} 
		public Decimal TotalDue { get; set;} 
		public String InvoiceRef { get; set;} 
		public Int32 Invoiced { get; set;} 
		public Decimal TotalInvoiced { get; set;} 
		public Decimal TotalInvoicedOri { get; set;} 
		public bool Paid { get; set;} 
		public Decimal TotalPayment { get; set;} 
		public Decimal PortFee { get; set;} 
		public Decimal PortFeeBeforeTax { get; set;} 
		public Decimal PortFeeVat { get; set;} 
		public Decimal PortFeeTotal { get; set;} 
		public Int32? StatusId { get; set;}
        public bool IsCancelled { get; set; }
        public int? RevisedToId { get; set; }
        public string ReasonToRevision { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;}
        public String CreatedPc { get; set; }
		public String Modifiedby { get; set;}
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;}
        public String ModifiedPc { get; set; }
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }

    public class AirwaybillPrintModel
    {
        public String Code { get; set; }
        public String Shipper { get; set; }
        public String DestinationBranch { get; set; }
        public String Consignee { get; set; }
        public String PaymentMethod { get; set; }
    }

    public class AuditAirwaybillModel
    {
        public Int32 Id { get; set; }
        public DateTime DateProcess { get; set; }
        public String Code { get; set; }
        public string Airline { get; set; }
        public string Airport { get; set; }
        public string DestAirport { get; set; }
        public bool Select { get; set; }
    }

    public class AirwaybillHeavyDifference
    {
        public string DestBranch { get; set; }
        public string AirwaybillCode { get; set; }
        public string ConsolidationCode { get; set; }
        public int? ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public string CustomerName { get; set; }
        public int? TotalConsolidationPieces { get; set; }
        public decimal? TotalConsolidationWeight { get; set; }
        public int? TotalShipmentPieces { get; set; }
        public decimal? TotalShipmentWeight { get; set; }
        public decimal? Diff { get; set; }
    }
}