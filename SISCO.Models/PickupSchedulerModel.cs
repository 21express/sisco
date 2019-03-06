using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class PickupSchedulerModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public DateTime StartDate { get; set; }
        public bool Active { get; set; }
        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri { get; set; }
        public bool Sat { get; set; }
        public bool Sun { get; set; }
        public Int32 BranchId { get; set; }
        public Int32 EmployeeId { get; set; }   
        public Int32? CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String CustomerAddress { get; set; }
        public String CustomerPhone { get; set; }
        public String CustomerContact { get; set; }
        public Int32 ServiceTypeId { get; set; }
        public Int32 PackageTypeId { get; set; }
        public Int32 PaymentMethodId { get; set; }
        public String NatureOfGoods { get; set; }
        public String Dimension { get; set; }
        public SByte TtlPiece { get; set; }
        public Decimal TtlGrossWeight { get; set; }
        public Decimal TtlChargeableWeight { get; set; }
        public Int32 Total { get; set; }
        public Int32 VehicleTypeId { get; set; }
        public Int32 MessengerId { get; set; }
        public String Note { get; set; }
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