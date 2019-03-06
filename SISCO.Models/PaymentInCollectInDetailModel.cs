using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class PaymentInCollectInDetailModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 PaymentInCollectInId { get; set;}
        public String PaymentInCollectInCode { get; set; }
        public Int32 BranchId { get; set; }
        public String BranchName { get; set; }
		public DateTime DateProcess { get; set;} 
		public Int32? InvoiceId { get; set;} 
		public DateTime? InvoiceDate { get; set;} 
		public String InvoiceCode { get; set;} 
		public Decimal InvoiceTotal { get; set;} 
		public Decimal InvoiceBalance { get; set;} 
		public Decimal Payment { get; set;} 
		public Decimal Balance { get; set;} 
		public bool Checked { get; set;} 
		public bool Paid { get; set;} 
		public String CollectPaymentMethod { get; set;} 
		public Int32? CollectCustomerId { get; set;} 
		public String CollectCustomerName { get; set;} 
		public Int32 TypePayment { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public bool? Outstanding { get; set; }

        public String ReportDescription { get; set; }
        public Decimal ReportTtlPiece { get; set; }
        public Decimal ReportTtlGrossWeight { get; set; }
        public Decimal ReportTariff { get; set; }
        public Decimal? ReportPayment { get; set; }
        public Decimal? ReportBalance { get; set; }
        public DateTime? ReportPaymentOutDate { get; set; }
        public String ReportPaymentOutCode { get; set; }
        public bool Verified { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string VerifiedBy { get; set; }
    }

    public class CollectInReport
    {
        public DateTime DateProcess { get; set; }
        public string InvoiceCode { get; set; }
        public decimal InvoiceTotal { get; set; }
        public string BranchName { get; set; }
        public decimal? Balance { get; set; }
        public string ReportDescription { get; set; }
        public DateTime? ReportPaymentDate { get; set; }
        public string ReportPaymentOutCode { get; set; }
        public decimal? ReportPayment { get; set; }
        public bool Verified { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string VerifiedBy { get; set; }
    }
}