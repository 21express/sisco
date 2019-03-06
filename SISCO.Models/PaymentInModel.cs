using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class PaymentInModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32? PaymentTypeId { get; set;}
        public String PaymentType { get; set; }
        public String Description { get; set;} 
		public Int32 CustomerId { get; set;} 
		public String CustomerName { get; set;} 
		public Int32? AccountId { get; set;} 
		public Decimal Amount { get; set;} 
		public Decimal TotalInvoice { get; set;} 
		public Decimal Total { get; set;} 
		public Decimal Adjustment { get; set;} 
		public Decimal TotalCredit { get; set;} 
		public Decimal TotalOther { get; set;} 
		public Decimal RcPercent { get; set;} 
		public Decimal RcPercentTotal { get; set;} 
		public Decimal RcKg { get; set;} 
		public Decimal RcKgTotal { get; set;} 
		public Decimal RcFixed { get; set;} 
		public Decimal RcTotal { get; set;} 
		public bool PaidRc { get; set;} 
		public Decimal TotalPaymentRc { get; set;} 
		public Int32? MarketingId { get; set;} 
        public String MarketingName { get; set; }
		public Decimal McPercent { get; set;} 
		public Decimal McPercentTotal { get; set;} 
		public Decimal McKg { get; set;} 
		public Decimal McKgTotal { get; set;} 
		public Decimal McFixed { get; set;} 
		public Decimal McTotal { get; set;} 
		public bool PaidMc { get; set;} 
		public Decimal TotalPaymentMc { get; set;}
        public int TransactionalAccountId { get; set; }
        public bool Verified { get; set; }
        public string VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;}
        public String CreatedPc { get; set; }
        public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;}
        public String ModifiedPc { get; set; }
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public String ReportCode { get; set; }
        public DateTime? ReportDate { get; set; }
        public Decimal? ReportPayment { get; set; }
        public String ReportDescription { get; set; }
        public Decimal? Balance { get; set; }

        public String CustomerCode { get; set; }
        public class PodInLookupDataRow : PodInModel
        {
            public string ShipmentCode { get; set; }
        }
    }

    public class PaymentInJournal
    {
        public String Code { get; set; }
        public Int32 PaymentTypeId { get; set; }
        public String PaymentType { get; set; }
        public DateTime DateProcces { get; set; }
        public String Description { get; set; }
        public String Company { get; set; }
        public Decimal? TotalInvoice { get; set; }
        public Decimal? Balance { get; set; }
        public Decimal Total { get; set; }
    }

    public class OutstandingPph23
    {
        public DateTime DateProcess { get; set; }
        public string RefNumber { get; set; }
        public int? CompanyId { get; set; }
        public string Company { get; set; }
        public Decimal TotalInvoice { get; set; }
        public Decimal TotalPph { get; set; }
        public Int16 PayType { get; set; }
    }

    public class ReturnPph23 : OutstandingPph23
    {
        public string Code { get; set; }
        public DateTime? DateReturn { get; set; }
    }
}


