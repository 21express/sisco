using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ManifestDetailModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 ManifestId { get; set;}
        public Int32? OrigBranchId { get; set; }
        public Int32? DestBranchId { get; set; }
		public DateTime DateProcess { get; set;} 
		public String ManifestCode { get; set;}
        public String ConsolidationCode { get; set; }
        public Int32? ShipmentId { get; set;} 
		public DateTime? ShipmentDate { get; set;} 
		public String ShipmentCode { get; set;} 
		public String ConsolCode { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 DestCityId { get; set;}
        public String DestCity { get; set; }
        public Int32? CustomerId { get; set;} 
		public String CustomerName { get; set;} 
		public String ShipperName { get; set;} 
		public String ConsigneeName { get; set;} 
		public Int32? ServiceTypeId { get; set;}
        public string ServiceType { get; set; }
        public Int32? PackageTypeId { get; set;}
        public string PackageType { get; set; }
        public Int32? PaymentMethodId { get; set;}
        public string PaymentMethod { get; set; }
        public Int32? SalesTypeId { get; set;} 
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
		public bool Manifested { get; set;}
        public decimal TotalCod { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }

    public class ManifestDetailTemp
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public string ConsolCode { get; set; }
        public int DestBranchId { get; set; }
        public string ShipmentCode { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? PackageTypeId { get; set; }
        public int? PaymentMethodId { get; set; }
    }
}


