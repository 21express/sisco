using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class AirwaybillDetailModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 AirwaybillId { get; set;}
        public Int32 OrigBranchIdAirwaybill { get; set; }
        public Int32? DestBranchIdAirwaybill { get; set; }
		public DateTime DateProcess { get; set;} 
		public String AirwaybillCode { get; set;} 
		public Int32 ShipmentId { get; set;} 
		public DateTime ShipmentDate { get; set;} 
		public String ShipmentCode { get; set;}
        public String ConsolidationCode { get; set; }
        public String ConsolCode { get; set;} 
		public Int32? BranchId { get; set;} 
		public Int32? DestCityId { get; set;}
        public string DestCity { get; set; }
        public Int32? CustomerId { get; set;} 
		public String CustomerName { get; set;} 
		public String ShipperName { get; set;} 
		public String ConsigneeName { get; set;} 
		public Int32? ServiceTypeId { get; set;} 
		public Int32? PackageTypeId { get; set;} 
		public Int32? PaymentMethodId { get; set;} 
		public Int32? SalesTypeId { get; set;} 
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
		public Int32? ManifestId { get; set;} 
		public String ManifestCode { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


