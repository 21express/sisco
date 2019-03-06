using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ShipmentStatusModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public Int32 ShipmentId { get; set; }
        public Int32 TrackingStatusId { get; set; }
        public bool IsFinalStatus { get; set; }
        public String MissDeliveryReason { get; set; }
        public Int32 PositionStatusId { get; set; }
        public String PositionStatus { get; set; }
        public Int32 BranchId { get; set; }
        public String StatusBy { get; set; }
        public String StatusNote { get; set; }
        public String Reference { get; set; }
        public Int32? EmployeeId { get; set; }
        public string OtherLabel { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
        public string TrackingStatus { get; set; }
    }
}
