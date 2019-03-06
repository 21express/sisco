using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class CostModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public DateTime DateProcess { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public Int32? PaymentTypeId { get; set;} 
        public String PaymentType { get; set; }
		public String Description { get; set;} 
		public Decimal Total { get; set;}
        public decimal? HardCash { get; set; }
        public bool Printed { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
        public String Createdpc { get; set; }
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public String Modifiedpc { get; set; }
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }

    public class CostJournal
    {
        public DateTime DateProcess { get; set; }
        public string CostType { get; set; }
        public decimal Amount { get; set; }
    }
}