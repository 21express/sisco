using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class PickupOrderModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public DateTime DateProcess { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Int32? CustomerId { get; set; }
        public Int32? FranchiseId { get; set; }
        public Int32? DropPointId { get; set; }
        public String CustomerName { get; set; }
        public String CustomerAddress { get; set; }
        public String CustomerPhone { get; set; }
        public String CustomerContact { get; set; }
        public Boolean NewCustomer { get; set; }
        public DateTime PickupDate { get; set; }
        public Int32 ServiceTypeId { get; set; }
        public string ServiceName { get; set; }
        public Int32 PackageTypeId { get; set; }
        public string PackageName { get; set; }
        public Int32 PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public String NatureOfGoods { get; set; }
        public String Dimension { get; set; }
        public SByte TtlPiece { get; set; }
        public Decimal TtlGrossWeight { get; set; }
        public Decimal TtlChargeableWeight { get; set; }
        public Int32 Total { get; set; }
        public Int32 VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public Int32 MessengerId { get; set; }
        public string MessengerName { get; set; }
        public bool Cancelled { get; set; }
        public bool Confirmed { get; set; }
        public bool PickedUp { get; set; }
        public String Note { get; set; }
        public String PickupNote { get; set; }
        public Int32 StatusId { get; set; }
        public bool? ReceivedCash { get; set; }
        public decimal? TotalCash { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public string CreatedPc { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string ModifiedPc { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
    }
}


