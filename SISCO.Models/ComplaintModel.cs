

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
    public class ComplaintModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime Vdate { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 EmployeeId { get; set;} 
		public Int32 ComplaintBranchId { get; set;} 
		public Int32 CustomerId { get; set;} 
		public String CustomerName { get; set;} 
		public String CustomerPhone { get; set;} 
		public String CustomerContact { get; set;}
        public String RefCode { get; set; }
        public Int32? ShipmentId { get; set; } 
		public int ComplaintCategoryId { get; set;} 
		public String Note { get; set;} 
		public Int32 Status { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


