using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class PromoModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public String Code { get; set; }
        public bool Active { get; set; }
        public DateTime ExpiredDate { get; set; }
        public String PromoDesc { get; set; }
        public int? CityOrigId { get; set; }
        public int? CityDestId { get; set; }
        public int? PackageTypeId { get; set; }
        public int? ServiceTypeId { get; set; }
        public decimal? MinWeight { get; set; }
        public decimal? Tariff { get; set; }
        public decimal? Discount { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}