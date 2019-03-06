

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
    public class EmployeeModel : IBaseModel
    {
        public enum EmployeeType
        {
            All = 0,
            Messenger = 1,
            CustomerService = 2,
            Marketing = 3,
            Collector = 4
        }

		public Int32 Id { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public String Name { get; set;} 
		public String Address { get; set;} 
		public String Phone { get; set;} 
		public String Email { get; set;} 
		public Int32 DepartmentId { get; set;}
        public Int32? UserId { get; set; }
        public Int32? EmployeeRoleId { get; set; }
        public bool AsMessenger { get; set; }
        public bool AsMarketing { get; set; }
        public bool AsCustomerService { get; set; }
        public bool AsCollector { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


