using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class CostDetailModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32 CostId { get; set;} 
		public DateTime DateProcess { get; set;} 
		public Int32 CostTypeId { get; set;} 
        public String CostType { get; set; }
        public string DivisionName { get; set; }
		public String Description { get; set;} 
		public Decimal Amount { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public bool Selected { get; set; }
        public DateTime CostDate { get; set; }
    }
}


