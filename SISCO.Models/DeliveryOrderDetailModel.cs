

/* 
*  SOLUTION 	: K-Solution
*  PROJECT		: K
*  TYPE 		: Business Model
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;


namespace SISCO.Models
{
    public class DeliveryOrderDetailModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;}
        public Int32 DeliveryOrderId { get; set; }
		public String DeliveryOrderCode { get; set;} 
		public Int32 ShipmentId { get; set;} 
		public DateTime? ShipmentDate { get; set;} 
		public String ShipmentCode { get; set;} 
		public String ConsolCode { get; set;} 
		public Int32? BranchId { get; set;}
        public String BranchCode { get; set; }
        public string Branch { get; set; }
        public Int32? DestCityId { get; set;} 
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
		public short TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;}
        public string Fulfilment { get; set; }
        public bool? IsCod { get; set; }
        public decimal? TotalCod { get; set; }
        public decimal Total { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string ReceivedBy { get; set; }
        public string ReceivedNote { get; set; }
        public DateTime? ReceivedUpdate { get; set; }
        public bool Received { get; set; }
        public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }

    public class MissDeliveryReportModel: IBaseModel
    {
        // ReSharper disable InconsistentNaming
        public String shipment_code { get; set; }
        public DateTime shipment_date { get; set; }
        public String shipper_name { get; set; }
        public String branch_name { get; set; }
        public String consignee_name { get; set; }
        public String received_note { get; set; }
        public String messenger_name { get; set; }
        // ReSharper restore InconsistentNaming
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}


