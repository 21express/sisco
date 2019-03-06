

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
    public class BranchModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public Decimal MaxDiscount { get; set; }
        public Decimal RaFee { get; set; } 
		public String Code { get; set;} 
		public String Name { get; set;} 
		public String Address { get; set;} 
		public String Phone { get; set;} 
		public String Contact { get; set;} 
		public String ContactEmail { get; set;} 
		public String ContactPhone { get; set;} 
		public Int32 CityId { get; set;} 
		public Int32 BranchTypeId { get; set;} 
		public Decimal WhKg { get; set;} 
		public Decimal WhAdmin { get; set;} 
		public String PrefixCode { get; set;} 
		public String PrefixCode1 { get; set;}
        public String PrefixCode2 { get; set; }
        public String PrefixOnlineCode1 { get; set; }
        public String HeaderShipment { get; set; }
        public String InvoiceHeader1 { get; set; }
        public String InvoiceHeader2 { get; set; }
        public String InvoiceHeader3 { get; set; }
        public String InvoiceFooter1 { get; set; }
        public String InvoiceFooter2 { get; set; }
        public String BankName { get; set; }
        public String BankAccountName { get; set; }
        public String BankAccountNumber { get; set; } 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


