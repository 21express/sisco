

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
    public class SalesLeadModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime Vdate { get; set;} 
		public Int32 MarketingId { get; set;} 
		public Int32 EmployeeId { get; set;} 
		public Int32? CustomerId { get; set;} 
		public Int32? ContactId { get; set;} 
		public String ContactName { get; set;} 
		public String ContactPhone { get; set;} 
		public String ContactEmail { get; set;} 
		public String Note { get; set;}
        public Int32 FollowUpsCount { get; set; }
        public Int32 LastLeadStatusId { get; set; }
        public DateTime? LastFollowUpDate { get; set; } 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


