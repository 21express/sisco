using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class SalesInvoiceModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime Vdate { get; set;} 
		public String Code { get; set;} 
		public String RefNumber { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 EmployeeId { get; set;} 
		public Decimal Credit { get; set;} 
		public DateTime DueDate { get; set;} 
		public Int32 SalesInvoiceTypeId { get; set;}
        public String SalesInvoiceType { get; set; }
        public int Period { get; set;} 
		public DateTime DateFrom { get; set;} 
		public DateTime DateTo { get; set;} 
		public Int32? FilterDestCityId { get; set;} 
		public Int32? FilterPackageTypeId { get; set;} 
		public Int32? FilterPaymentMethodId { get; set;} 
		public Int32 FilterSalesInvoiceTypeId { get; set;} 
		public Int32 CompanyId { get; set;} 
		public String CompanyName { get; set;} 
		public String CompanyInvoicedTo { get; set;} 
		public Decimal Discount { get; set;} 
		public Int32 CurrencyId { get; set;} 
		public Decimal CurrencyRate { get; set;} 
		public Decimal TotalPiece { get; set;} 
		public Decimal TotalGrossWeight { get; set;} 
		public Decimal TotalChargeableWeight { get; set;} 
		public Decimal TotalSales { get; set;} 
		public Decimal TotalCost { get; set;} 
		public Decimal Total { get; set;} 
		public Decimal CostMaterai { get; set;} 
		public Decimal WhWeight { get; set;} 
		public Decimal WhKg { get; set;} 
		public Decimal WhKgTotal { get; set;} 
		public Decimal WhAdmin { get; set;} 
		public Decimal WhTotal { get; set;} 
		public Decimal TotalServiceTariff1 { get; set;} 
		public Decimal TotalServiceTariff2 { get; set;} 
		public Decimal TotalServiceTariff3 { get; set;} 
		public Decimal TotalRecord { get; set;} 
		public Decimal TotalDiscount { get; set;} 
		public Decimal TotalPacking { get; set;} 
		public Decimal TotalOther { get; set;} 
		public bool Printed { get; set;} 
		public bool Cancelled { get; set;}
        public string InvoiceRevised { get; set; }
        public string InvoiceRevisionOf { get; set; }
		public bool Paid { get; set;} 
		public Decimal TotalPayment { get; set;} 
		public Decimal RcPercent { get; set;} 
		public Decimal RcPercentTotal { get; set;} 
		public Decimal RcKg { get; set;}
        public Decimal RcKgTotal { get; set; }
        public Decimal RcFixed { get; set; }
        public Decimal RcTotal { get; set; }
        public Decimal RaChargeableWeight { get; set; }
        public Decimal RaFee { get; set; }
        public Decimal RaTotal { get; set; } 
		public Int32 PaidRc { get; set;} 
		public Decimal TotalPaymentRc { get; set;} 
		public String Description { get; set;} 
		public String Description1 { get; set;} 
		public String Description2 { get; set;} 
		public String Description3 { get; set;}
        public int TaxTypeId { get; set; }
        public bool ReqTaxInvoice { get; set; }
        public int? TaxInvoiceId { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxTotal { get; set; }
        public string TaxInvoice { get; set; }
        public DateTime Createddate { get; set; } 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public class SalesInvoiceReportRow : SalesInvoiceModel
        {

        }
    }

    public class SalesInvoicePaymentReportModel : SalesInvoiceModel
    {
        public DateTime? PaymentDate { get; set; }
        public string PaymentCode { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentDescription { get; set; }
    }

    public class PaidPaymentReportModel
    {
        public int Id { get; set; }
        public DateTime Vdate { get; set; }
        public string Code { get; set; }
        public string RefNumber { get; set; }
        public DateTime DueDate { get; set; }
        public string CompanyInvoicedTo { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentCode { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentDescription { get; set; }
        public decimal Outstanding { get; set; }
    }

    public class ReportInvoice
    {
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalInvoice { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? Payment { get; set; }
        public string PaymentType { get; set; }
        public string Period { get; set; }
        public bool Cancelled { get; set; }
        public string InvoiceRevised { get; set; }
        public string InvoiceType { get; set; }
        public bool OtherInvoice { get; set; }
    }

    public class InvoiceTax
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public string RefNumber { get; set; }
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public DateTime DueDate { get; set; }
        public string CompanyInvoicedTo { get; set; }
        public decimal Total { get; set; }
        public decimal TaxTotal { get; set; }
        public string TaxInvoice { get; set; }
        public string TaxInvoiceName { get; set; }
        public string Period { get; set; }
        public bool Printed { get; set; }
        public string InvoiceRevisionOf { get; set; }
    }

    public class InvoiceDistributionInternalModel
    {
        public string RefNumber { get; set; }
        public DateTime DateProcess { get; set; }
        public DateTime DueDate { get; set; }
        public string CustomerName { get; set; }
        public int Period { get; set; }
        public bool Cancelled { get; set; }
        public bool IsBillingDeliver { get; set; }
        public DateTime? BillingDeliverDate { get; set; }
        public bool IsFinanceAcceptance { get; set; }
        public DateTime? FinanceAcceptanceDate { get; set; }
        public string CollectorName { get; set; }
        public bool IsReceipt { get; set; }
        public string ReportCollectorName { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string ReceiptName { get; set; }
        public string PaymentType { get; set; }
        public bool IsDeliverTransfer { get; set; }
        public DateTime? DeliverTransferDate { get; set; }
        public bool IsTransferAccepted { get; set; }
        public DateTime? TransferAcceptedDate { get; set; }
    }

    public class PrintInvoiceModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateProcess { get; set; }
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public int Period { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Total { get; set; }
        public string TaxInvoice { get; set; }
        public bool Printed { get; set; }
        public bool PrintDetail { get; set; }
        public bool PrintInvoice { get; set; }
        public bool PrintDelivery { get; set; }
        public bool DownloadFaktur { get; set; }
    }
}