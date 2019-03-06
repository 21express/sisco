using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ShipmentAllocationModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime AllocDate { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32? CustomerId { get; set;}
        public Int32? FranchiseId { get; set; }
        public Int32? DropPointId { get; set; }
		public String CustomerName { get; set;} 
		public String CustomerAddress { get; set;} 
		public Int64 ShipmentCodeStart { get; set;}
        public Int64 ShipmentCodeEnd { get; set; } 
		public Int32 ShipmentCodeCount { get; set;} 
		public Int32 ShipmentCodeUsed { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}