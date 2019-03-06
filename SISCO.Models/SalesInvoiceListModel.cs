using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class SalesInvoiceListModel : IBaseModel
    {
		public Int32 Id { get; set;} 

        public Int32 SalesInvoiceId { get; set; }
        public Int32 ShipmentId { get; set; }
        public String ShipmentCode { get; set; }
        public DateTime ShipmentProcessDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string Recipient { get; set; }
        public String ConsigneeName { get; set; }
        public String DestinationCity { get; set; }
        public Int32 TotalPiece { get; set; }
        public Decimal TotalChargeableWeight { get; set; }
        public Int32 ServiceTypeId { get; set; }
        public String ServiceType { get; set; }
        public Int32? PackageTypeId { get; set; }
        public String PackageType { get; set; }
        public Int32 PricingPlanId { get; set; }
        public Decimal TariffPerKg { get; set; }
        public Decimal HandlingFee { get; set; }
        public Decimal PackingFee { get; set; }
        public bool NeedRa { get; set; }
        public Decimal TotalTariff { get; set; }
        public Decimal Discount { get; set; }
        public Decimal NetTariff { get; set; }
        public Decimal OtherFee { get; set; }
        public Decimal InsuranceFee { get; set; }
        public Decimal GrandTotal { get; set; }
        public Decimal GrandTotalInBaseCurrency { get; set; }
        public String Currency { get; set; }
        public Decimal CurrencyRate { get; set; }
        public bool Invoiced { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
        public bool NewRow { get; set; }
        public bool Scanned { get; set; }
    }

    public class SalesInvoiceListDataRow : SalesInvoiceListModel
    {
        public Int32 Index { get; set; }

        public decimal TariffTotalInBaseCurrency
        {
            get { return !string.IsNullOrEmpty(Currency) ? TotalTariff * CurrencyRate : TotalTariff; }
        }

        public string OtherLabel { get; set; }
    }
}