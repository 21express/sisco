using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class CustomerModel : IBaseModel
    {
		public Int32 Id { get; set;} 
		public String Code { get; set;} 
		public Int32 BranchId { get; set;} 
		public String Name { get; set;} 
		public String Address { get; set;} 
		public String PostalCode { get; set;} 
		public Int32 CityId { get; set;} 
		public String Locality { get; set;} 
		public String Province { get; set;} 
		public String CountryCode { get; set;} 
		public String Phone { get; set;} 
		public String Fax { get; set;} 
		public String Email { get; set;} 
		public String Npwp { get; set;} 
		public String TaxName { get; set;} 
		public String TaxAddress { get; set;} 
		public bool Same { get; set;} 
		public String Contact { get; set;} 
		public String ContactEmail { get; set;} 
		public String ContactPhone { get; set;} 
		public Decimal Credit { get; set;} 
		public Decimal CreditLimit { get; set;} 
		public Decimal Discount { get; set;} 
		public Decimal HandlingFee { get; set;} 
		public Decimal RcPercent { get; set;} 
		public Decimal RcKg { get; set;} 
		public Decimal RcFixed { get; set;} 
		public Decimal CommPercent { get; set;} 
		public Decimal CommKg { get; set;} 
		public Int32? MarketingEmployeeId { get; set;} 
		public Decimal McPercent { get; set;} 
		public Decimal McKg { get; set;} 
		public Decimal McFixed { get; set;} 
		public String BankName { get; set;} 
		public String BankAccountName { get; set;} 
		public String BankAccountNumber { get; set;} 
		public String PodNeeded { get; set;} 
		public String Disabled { get; set;} 
		public DateTime StartDate { get; set;} 
		public Decimal InitialBalance { get; set;} 
		public Decimal ClosingBalance { get; set;} 
		public Decimal Balance { get; set;} 
		public Decimal BalanceIn { get; set;} 
		public Decimal BalanceOut { get; set;} 
		public String Note { get; set;} 
        public int? FranchiseId { get; set; }
        public string ProductKey { get; set; }
        public bool? ActiveFlag { get; set; }
		public String Footer1 { get; set;}
        public String CorporateKey { get; set; }
        public String IPStatic { get; set; }
        public bool? CorporateFlag { get; set; }
        public bool PickupPo { get; set; }
        public bool PickupDn { get; set; }
        public bool PickupOc { get; set; }
        public bool DeliveryRc { get; set; }
        public int? TaxInvoiceId { get; set; }
        public int? ServiceTypeId { get; set; }
		public DateTime Createddate { get; set;} 
		public String Createdby { get; set;} 
		public String Modifiedby { get; set;} 
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set;} 
        public bool Rowstatus { get; set;}
        public DateTime Rowversion { get; set; }
    }
}


