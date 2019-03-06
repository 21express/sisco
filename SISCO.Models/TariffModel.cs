

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
    public class TariffModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public Int32? AirlineId { get; set;}
        public Int32 CityOrigId { get; set; }
        public Int32 CityDestId { get; set; } 
		public Int32? ServiceTypeId { get; set;} 
		public Int32? PackageTypeId { get; set;} 
		public Decimal Tariff { get; set;} 
		public Decimal HandlingFee { get; set;} 
		public Decimal? DiscountPercent { get; set;} 
		public Decimal? DiscountFixed { get; set;} 
		public Decimal MinWeight { get; set;}
        public bool? Ra { get; set; }
        public Decimal? OtherFee { get; set;} 
		public Decimal? OtherPercent { get; set;} 
		public Decimal? OtherKg { get; set;} 
		public Int32? CurrencyId { get; set;} 
		public Int32? PricingPlanId { get; set;} 
		public Decimal? FromWeight { get; set;} 
		public Decimal? ToWeight { get; set;} 
        public string LeadTime { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }

        public String CityOrigName { get; set; }
        public String CityDestName { get; set; }
        public String ServiceTypeName { get; set; }
    }
}


