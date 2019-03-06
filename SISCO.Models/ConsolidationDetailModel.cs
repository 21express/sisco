using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ConsolidationDetailModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 ConsolidationId { get; set;} 
        public Int32? DestConsolidationBranch { get; set; }
		public DateTime DateProcess { get; set;} 
		public String ConsolidationCode { get; set;} 
		public Int32 ShipmentId { get; set;} 
		public DateTime ShipmentDate { get; set;} 
		public String ShipmentCode { get; set;} 
		public String ConsolCode { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 DestCityId { get; set;}
        public string DestCity { get; set; }
        public Int32? ServiceTypeId { get; set;}
        public string ServiceType { get; set; }
        public Int32? PackageTypeId { get; set;} 
        public String PackageType { get; set; }
		public Int32? PaymentMethodId { get; set;}
        public string PaymentMethod { get; set; }
        public Int32? SalesTypeId { get; set;} 
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
		public Int32? WaybillId { get; set;} 
		public String WaybillCode { get; set;} 
		public Int32? ManifestId { get; set;} 
		public String ManifestCode { get; set;}
        public string CustomerName { get; set; }
        public string Consignee { get; set; }
        public string NatureGoods { get; set; }
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


