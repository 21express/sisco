using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class CityModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime Rowverstion { get; set;} 
		public String Name { get; set;} 
		public Int32 CountryId { get; set;} 
		public Int32 BranchId { get; set;} 
		public SByte LeadTime { get; set;}
        public bool Cod { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
        public string ZipCode { get; set; }
        public Int32? DistrictId { get; set; }
        public String Description1 { get; set; }
        public bool IsOutArea { get; set; }
    }
}


