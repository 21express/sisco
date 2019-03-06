using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FleetModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 VehicleTypeId { get; set;} 
        public String VehicleType { get; set; }
		public String PlateNumber { get; set;} 
		public String Brand { get; set;} 
		public String Model { get; set;} 
		public Int32 Year { get; set;} 
		public DateTime NextExpirationDate { get; set;} 
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


