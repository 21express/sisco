

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
    public class UserPrivilegeModel : IBaseModel
    {
		public Int32 Id { get; set;} 
        public int RoleId { get; set;} 
        public string ModuleName { get; set;}
        public string FormName { get; set; }
        public bool AllowAccess { get; set; }
        public bool AllowView { get; set; }
        public bool AllowViewAll { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPrint { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


