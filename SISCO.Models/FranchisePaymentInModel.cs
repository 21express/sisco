using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FranchisePaymentInModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32? PaymentTypeId { get; set;} 
		public Decimal Amount { get; set;} 
		public Decimal TotalInvoice { get; set;} 
		public Decimal Total { get; set;} 
		public Decimal Adjustment { get; set;}
        public bool FundTransfer { get; set; }
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