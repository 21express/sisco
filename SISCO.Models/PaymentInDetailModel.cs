using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class PaymentInDetailModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 PaymentInId { get; set;} 
        public String PaymentInCode { get; set; }
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
		public String InvoiceType { get; set;} 
		public String InvoiceRefNumber { get; set;}
        public bool UsePph23 { get; set; }
        public decimal TotalPph23 { get; set; }
        public bool UseMaterai { get; set; }
        public decimal MateraiFee { get; set; }
        public DateTime? DateReturn { get; set; }
        public bool IsReturn { get; set; }
        public string Note { get; set; }
        public int? RefundId { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Int16 PayType { get; set; }
    }
}