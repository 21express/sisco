

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
    public class PodInModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime Vdate { get; set;} 
		public String Vtime { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32? DestBranchId { get; set;} 
		public String ArchiveLocation { get; set;} 
		public Int32? CustomerId { get; set;} 
		public String CustomerName { get; set;} 
		public Int32 Status { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public class PodInLookupDataRow : PodInModel
        {
            public string ShipmentCode { get; set; }
        }
    }
}


