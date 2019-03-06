

/* 
*  SOLUTION 	: K-Solution
*  PROJECT		: K
*  TYPE 		: Business Model
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;


namespace SISCO.Models
{
    public class SalesInvoiceCostModel : IBaseModel
    {
		public Int32 Id { get; set;}

        public Int32 SalesInvoiceId { get; set; }
        public String Description { get; set; }
        public Decimal Total { get; set; }

		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


