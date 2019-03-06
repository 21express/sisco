

/* 
*  SOLUTION 	: K-Solution
*  PROJECT		: K
*  TYPE 		: Business Model
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class InboxModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime Rowversion { get; set;}  
		public Int32 BranchId { get; set;}
		public Int32 DepartmentId { get; set;}
		public string TransactionType { get; set;} 
		public string RefNumber { get; set;} 
		public int? RefId { get; set;} 
		public string Description { get; set;}
		public bool IsOpen { get; set;} 
		public DateTime DateAssigned { get; set;} 
		public DateTime? DateViewed { get; set;}
        public DateTime? DateCompleted { get; set; }
        public int? CompletedBy { get; set; } 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
    }
}


