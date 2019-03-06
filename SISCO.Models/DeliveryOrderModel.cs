using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class DeliveryOrderModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 MessengerId { get; set;} 
		public String MessengerName { get; set;}
        public Int32? AsstId { get; set; }
        public String AsstName { get; set; } 
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
		public Int32? FleetId { get; set;} 
		public String FleetNumber { get; set;} 
		public DateTime? FleetDate { get; set;} 
		public String FleetTime { get; set;} 
		public Int32? StatusId { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;}
        public String CreatedPc { get; set; }
        public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;}
        public String ModifiedPc { get; set; }
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public string VehicleType { get; set; }
    }

    public class DeliveryPickupModel
    {
        public int MessengerId { get; set; }
        public string MessengerCode { get; set; }
        public string MessengerName { get; set; }
        public DateTime DateProcess { get; set; }
        public string Pod { get; set; }
        public string CustomerName { get; set; }
        public DateTime? PickupDeliveryDate { get; set; }
        public decimal TtlPiece { get; set; }
        public decimal TtlGrossWeight { get; set; }
        public decimal TtlChargeable { get; set; }
        public string PickupNote { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
    }
}