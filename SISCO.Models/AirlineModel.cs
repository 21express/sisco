

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
    public class AirlineModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public String Code { get; set;} 
		public String Name { get; set;} 
		public Decimal AdminFee { get; set;} 
		public Decimal AdminFeeVia { get; set;} 
		public Decimal VoidFee { get; set;} 
		public Decimal RefundFee { get; set;} 
		public Decimal ScFee { get; set;} 
		public Decimal ScFeeMin { get; set;} 
		public Decimal ScFeeMinWeight { get; set;} 
		public Decimal SoFee { get; set;} 
		public Decimal FeFee { get; set;} 
		public Decimal HandlingFee { get; set;} 
		public Decimal MinWeight { get; set;} 
		public bool AdminIncludeTax { get; set;} 
		public bool ShowAsAgreed { get; set;} 
		public Decimal AdminFeeCustomer { get; set;} 
		public Decimal VoidFeeCustomer { get; set;} 
		public Decimal RefundFeeCustomer { get; set;} 
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


