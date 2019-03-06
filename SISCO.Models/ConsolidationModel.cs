

using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ConsolidationModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32 DestBranchId { get; set;} 
		public String ConsigneeName { get; set;} 
		public String ConsigneeAddress { get; set;} 
		public Decimal Length { get; set;} 
		public Decimal Width { get; set;} 
		public Decimal Height { get; set;} 
		public Decimal VolumeWeight { get; set;} 
		public Decimal TtlPiece { get; set;} 
		public Decimal TtlGrossWeight { get; set;} 
		public Decimal TtlChargeableWeight { get; set;} 
		public Int32? StatusId { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;}
        public string CreatedPc { get; set; }
        public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;}
        public string ModifiedPc { get; set; }
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }

    public class ConsolidationShipmentModel
    {
        public int ConsolidationId { get; set; }
        public int ShipmentId { get; set; }
    }
}