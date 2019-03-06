using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ManifestModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;}
        public string BranchName { get; set; }
        public Int32 DestBranchId { get; set;}
        public string DestBranch { get; set; }
        public String ConsigneeName { get; set;} 
		public String ConsigneeAddress { get; set;} 
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
		public Int32? FleetId { get; set;} 
		public String FleetNumber { get; set;} 
		public DateTime? FleetDate { get; set;} 
		public String FleetTime { get; set;} 
		public Int32? FlightId { get; set;} 
		public String FlightNumber { get; set;} 
		public DateTime? FlightDate { get; set;} 
		public String FlightTime { get; set;} 
		public bool Printed { get; set;} 
		public Int32? StatusId { get; set;}
        public int? ShippingPlanId { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;}
        public String CreatedPc { get; set; }
        public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;}
        public String ModifiedPc { get; set; }
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }

    public class ManifestList
    {
        public string Code { get; set; }
        public string DestBranch { get; set; }
        public short TtlPiece { get; set; }
        public Decimal TtlGrossWeight { get; set; }
        public Decimal TtlChargeableWeight { get; set; }
        public bool Printed { get; set; }
        public string ShippingPlan { get; set; }
    }
}