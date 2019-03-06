

/* 
*  SOLUTION 	: K-Solution
*  PROJECT		: K
*  TYPE 		: Business Model
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;


namespace SISCO.Models
{
    public class PaymentInCounterModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32? PaymentTypeId { get; set;} 
		public String Description { get; set;} 
		public Int32? CustomerId { get; set;} 
		public String CompanyName { get; set;} 
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
		public Int32 PaidRc { get; set;} 
		public Decimal TotalPaymentRc { get; set;}
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
    }
}


