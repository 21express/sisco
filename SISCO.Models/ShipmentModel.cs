using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ShipmentModel : IBaseModel
    {
        public class ShipmentMobile
        {
            public string Code { get; set; }
            public DateTime DateProcess { get; set; }
            public decimal Total { get; set; }
            public string EmailPoint { get; set; }
        }

        public class ShipmentPaymentReport : ShipmentModel
        {
            public string PaymentCode { get; set; }
            public DateTime? PaymentDate { get; set; }
            public string PaymentDescription { get; set; }
            public bool Verified { get; set; }
            public DateTime? VerifiedDate { get; set; }
            public string VerifiedBy { get; set; }
        }

        public class ShipmentReportRow : ShipmentModel
        {
            public new string MessengerCode { get; set; }
            public new string CustomerCode { get; set; }
            public new string ServiceType { get; set; }

            public string ShipmentHeader { get; set; }
            public int Number { get; set; }
            public int Count { get; set; }

            public bool IsCod { get; set; }
            public decimal TotalCod { get; set; }
            public string Fulfilment { get; set; }
            public bool Handedover { get; set; }
            public bool PrintEconnote { get; set; }
            public short Printed { get; set; }
            public decimal VolumeL { get; set; }
            public decimal VolumeW { get; set; }
            public decimal VolumeH { get; set; }
            public string EmailPoint { get; set; }
        }

		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;}
        public String BranchName { get; set; }
        public Int32 MarketingId { get; set;} 
		public Int32? MessengerId { get; set;} 
		public String MessengerName { get; set;} 
        public String MessengerCode { get; set; }
        public Int32? MessengerId2 { get; set; }
        public string MessengerName2 { get; set; }
		public Int32 SalesTypeId { get; set;} 
        public String SalesType { get; set; }
		public Int32 CityId { get; set;} 
		public String CityName { get; set;} 
		public Int32 DestCityId { get; set;} 
		public String DestCity { get; set;} 
		public Int32? DestCountryId { get; set;} 
		public String DestCountry { get; set;} 
		public Int32? DestBranchId { get; set;} 
		public String DestBranchName { get; set;} 
		public String Note { get; set;} 
		public Int32? CustomerId { get; set;} 
		public String CustomerName { get; set;} 
        public String CustomerCode { get; set; }
		public Int32 AccountId { get; set;} 
		public String RefNumber { get; set;} 
		public String RefCode { get; set;} 
		public bool Personal { get; set;} 
		public String PersonalName { get; set;} 
		public String ShipperName { get; set;} 
		public String ShipperAddress { get; set;} 
		public String ShipperPostalCode { get; set;} 
		public String ShipperCity { get; set;} 
		public String ShipperPhone { get; set;} 
		public bool ShipperSaved { get; set;} 
		public String ConsigneeName { get; set;} 
		public String ConsigneeAddress { get; set;} 
		public String ConsigneePostalCode { get; set;} 
		public String ConsigneeCity { get; set;} 
		public String ConsigneePhone { get; set;} 
		public bool ConsigneeSaved { get; set;} 
		public Int32 ShippingMethodId { get; set;} 
		public Int32 ServiceTypeId { get; set;} 
        public String ServiceType { get; set; }
		public Int32 PackageTypeId { get; set;}
        public string PackageType { get; set; }
        public Int32 PaymentMethodId { get; set; }
        public string PaymentMethod { get; set; }
        public String PricingCalcType { get; set;} 
		public String CollectPaymentMethod { get; set;} 
		public Int32? CollectCustomerId { get; set;} 
		public String CollectCustomerName { get; set;}
        public String CollectCustomerCode { get; set; }
		public bool PaidColl { get; set;} 
		public Decimal TotalPaymentColl { get; set;} 
		public bool PaidCollect { get; set;} 
		public Decimal TotalPaymentCollect { get; set;} 
		public String NatureOfGoods { get; set;} 
		public String Dimension { get; set;} 
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
		public Int32? PricingPlanId { get; set;} 
        public String PricingPlan { get; set; }
		public Decimal Tariff { get; set;} 
		public Decimal DiscountPercent { get; set;} 
		public Decimal DiscountFixed { get; set;} 
		public Decimal DiscountTotal { get; set;} 
		public Decimal TariffNet { get; set;} 
		public Decimal TariffTotal { get; set;} 
		public Decimal BeforeTaxTotal { get; set;} 
		public Decimal Vat { get; set;} 
		public Decimal AfterTaxTotal { get; set;} 
		public Decimal HandlingFee { get; set;} 
		public Decimal HandlingFeeTotal { get; set;} 
		public Decimal SurchargeFee { get; set;} 
		public Decimal AdminFee { get; set;}
        public Decimal PackingFee { get; set; }
        public Decimal OtherFee { get; set; }
        public Decimal VoidFee { get; set; }
        public Decimal GoodsValue { get; set; }
        public Decimal InsuranceFee { get; set; } 
		public String ProtectionType { get; set;} 
		public Decimal ProtectionValue { get; set;} 
		public Decimal ProtectionFee { get; set;} 
		public Decimal ExtraWeight { get; set;} 
		public Decimal ExtraCharge { get; set;} 
		public Decimal ExtraChargeTotal { get; set;}
        public Decimal Total { get; set; }
        public Int32? CurrencyId { get; set; }
        public String Currency { get; set; } 
		public Decimal CurrencyRate { get; set;} 
		public Decimal TotalSales { get; set;} 
		public bool Cancelled { get; set;} 
		public bool Posted { get; set;} 
		public bool Voided { get; set;}
        public Decimal TotalDue { get; set; }
        public String InvoiceRef { get; set; }
        public Int32? InvoiceId { get; set; }
        public String PaymentReceiptNumber { get; set; } 
		public Int32 Invoiced { get; set;} 
		public Decimal TotalInvoiced { get; set;} 
		public Decimal TotalInvoicedOri { get; set;} 
		public bool Paid { get; set;} 
		public Decimal TotalPayment { get; set;} 
		public Decimal DeliveryFeeMin { get; set;} 
		public Decimal DeliveryFee { get; set;} 
		public Decimal DeliveryFeeTotal { get; set;} 
		public bool PaidDelivery { get; set;} 
		public Decimal TotalPaymentDelivery { get; set;} 
		public Decimal PortFee { get; set;} 
		public Decimal PortFeeBeforeTax { get; set;} 
		public Decimal PortFeeVat { get; set;} 
		public Decimal PortFeeTotal { get; set;} 
		public bool Manifested { get; set;}
        public bool Inbound { get; set; }
        public string ManifestCode { get; set; }
        public bool PodNeeded { get; set;} 
		public Int32 PodSent { get; set;} 
		public Int32 PodReceived { get; set;} 
		public Int32 PodReturned { get; set;} 
		public Decimal McPercent { get; set;} 
		public Decimal McPercentTotal { get; set;} 
		public Decimal McKg { get; set;} 
		public Decimal McKgTotal { get; set;} 
		public Decimal McTotal { get; set;} 
		public Int32 PaidMc { get; set;}
        public Decimal TotalPaymentMc { get; set; }
        public bool AutoNumber { get; set; }
        public bool NeedRa { get; set; } 
		public String AcceptanceEmployee { get; set;} 
		public String DataEntryEmployee { get; set;} 
		public Int32 TrackingStatusId { get; set;}
        public string TrackingStatus { get; set; }
        public Int32 UploadStatus { get; set;}
        public Int32? FranchiseId { get; set; }
        public string FranchiseCode { get; set; }
        public string FranchiseName { get; set; }
        public int? PromoId { get; set; }
        public string PromoCode { get; set; }
        public int? PODStatus { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;}
        public String CreatedPc { get; set; }
        public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? ManifestDate { get; set; }
        public DateTime? Modifieddate { get; set;}
        public String ModifiedPc { get; set; }
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public DateTime? InvoiceCreatedDate { get; set; }
    }

    public class ReportDeliveryJournal
    {
        // ReSharper disable InconsistentNaming
        public String branch_name { get; set; }
        public int branch_id { get; set; }
        public String code { get; set; }
        public DateTime date_process { get; set; }
        public String dest_branch_name { get; set; }
        public int dest_branch_id { get; set; }
        public decimal ttl_piece { get; set; }
        public decimal ttl_chargeable_weight { get; set; }
        public decimal delivery_fee { get; set; }
        public decimal delivery_fee_total { get; set; }
        public String description { get; set; }
        public DateTime? report_date { get; set; }
        public String report_code { get; set; }
        public Decimal payment { get; set; }
        public Decimal balance { get; set; }
        public Decimal totalpayment { get; set; }
        // ReSharper restore InconsistentNaming
    }

    public class ReportSalesJournal : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }

        // ReSharper disable InconsistentNaming
        public int? dest_branch_id { get; set; }
        public string dest_branch_name { get; set; }
        public int? employee_id { get; set; }
        public string employee_name { get; set; }
        public int? marketing_id { get; set; }
        public string marketing_name { get; set; }
        public int? customer_id { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public int? dest_city_id { get; set; }
        public string dest_city { get; set; }
        public int? service_type_id { get; set; }
        public string service_type { get; set; }
        public int? package_type_id { get; set; }
        public string package_type { get; set; }
        public int? payment_method_id { get; set; }
        public string payment_method { get; set; }
        public string ref_number { get; set; }
        public string code { get; set; }
        public DateTime date_process { get; set; }
        public decimal ttl_piece { get; set; }
        public Decimal ttl_gross_weight { get; set; }
        public Decimal total { get; set; }
        public decimal ttl_chargeable_weight { get; set; }
        public decimal discount_total { get; set; }
        public decimal tariff { get; set; }
        public decimal tariff_total { get; set; }
        public decimal tariff_net { get; set; }
        public decimal total_cod { get; set; }
        public decimal packing_fee { get; set; }
        // ReSharper restore InconsistentNaming
    }

    public class PrintBarcode
    {
        public DateTime DateProcess { get; set; }
        public String BranchName { get; set; }
        public String DestBranchName { get; set; }
        public String Number { get; set; }
        public short Count { get; set; }
        public String Code { get; set; }
        public String ServiceType { get; set; }
        public Decimal GrossWeight { get; set; }
        public string CourierName { get; set; }
    }

    public class PrintBarcodeCustomer : PrintBarcode
    {
        public string Customer1 { get; set; }
        public string Customer2 { get; set; }
        public string Customer3 { get; set; }
        public string Customer4 { get; set; }
        public string Customer5 { get; set; }
        public string Customer6 { get; set; }
    }

    public class QrCodePrint
    {
        public String Code { get; set; }
        public DateTime DateProcess { get; set; }
        public string OrigBranch { get; set; }
        public String DestBranch { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal COD { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string ConsigneePhone { get; set; }
        public string ServiceType { get; set; }
        public string JsonBarcode { get; set; }
    }

    public class BarcodeList
    {
        public String Code { get; set; }
        public DateTime DateProcess { get; set; }
        public String DestBranch { get; set; }
    }

    public class ShipmentRowModel: ShipmentModel
    {
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryDateStr { get; set; }
        public string DeliveryTime { get; set; }
        public string RecipientName { get; set; }
        public string DeliveryNote { get; set; }
        public Int32? StatusId { get; set; }
        public string DestBranch { get; set; }
        public int? LeadTime { get; set; }
        public decimal TotalCod { get; set; }
    }
}