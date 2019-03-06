

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
    public class RunningTextModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public String Name { get; set;} 
		public DateTime? FromDate { get; set;} 
		public SByte FromHour { get; set;} 
		public SByte FromMinute { get; set;} 
		public DateTime? ToDate { get; set;} 
		public SByte ToHour { get; set;} 
		public SByte ToMinute { get; set;} 
		public Int32? UserId { get; set;} 
		public Int32? RoleId { get; set;} 
        public short? AnnouncementType { get; set; }
        public int? FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public int? CorporateId { get; set; }
        public string CorporateName { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


