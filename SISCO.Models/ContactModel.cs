

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
    public class ContactModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime Vdate { get; set;} 
		public String CompanyName { get; set;} 
		public String CompanyAddress { get; set;} 
		public String CompanyPhone { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 CustomerId { get; set;} 
		public Int32 MarketingId { get; set;} 
		public String ContactName { get; set;} 
		public String ContactPhone { get; set;} 
		public String ContactEmail { get; set;} 
		public String Note { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


