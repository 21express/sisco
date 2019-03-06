

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
    public class PodCustomerShipmentModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 PodCustomerId { get; set;} 
		public Int32 ShipmentId { get; set;} 
		public DateTime ShipmentDate { get; set;} 
		public String ShipmentCode { get; set;} 
		public Int32 BranchId { get; set;} 
		public String ShipperName { get; set;} 
		public String ReceivedCustBy { get; set;} 
		public DateTime? ReceivedCustDate { get; set;} 
		public String ReceivedCustTime { get; set;} 
		public Int32 Sent { get; set;} 
		public Int32 Received { get; set;}
        public Int32 Returned { get; set; }
        public String Note { get; set; }
        public String SuratJalan { get; set; } 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


