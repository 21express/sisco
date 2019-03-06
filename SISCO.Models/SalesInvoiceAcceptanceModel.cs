using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class SalesInvoiceAcceptanceModel : IBaseModel
    {
		public Int32 Id { get; set;}
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;}
        public DateTime Createddate { get; set; } 
        public String Createdby { get; set;}
        public string CreatedPc { get; set; }
		public String Modifiedby { get; set;}
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;}
        public string ModifiedPc { get; set; }
    }

    public class InvoiceAcceptanceFinanceSearchModel
    {
        public int Id { get; set; }
        public System.DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public string RefNumber { get; set; }
    }
}


