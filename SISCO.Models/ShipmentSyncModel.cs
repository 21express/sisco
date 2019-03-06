using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class ShipmentSyncModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public string Awb { get; set; }
        public string Remark { get; set; }
        public string CnName { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string OrderId { get; set; }
        public decimal? ActWeight { get; set; }
        public int? Pieces { get; set; }
        public string ItemName { get; set; }
        public decimal? GoodsVal { get; set; }
        public string Insurance { get; set; }
        public bool? Cod { get; set; }
        public DateTime? PickupDate { get; set; }
        public string Service { get; set; }
        public bool Imported { get; set; }
        public string Merchant { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantDistrict { get; set; }
        public string MerchantCity { get; set; }
        public string MerchantProvince { get; set; }
        public string MerchantCountry { get; set; }
        public string MerchantPhone { get; set; }
        public string MerchantContact { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedPc { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string Modifiedby { get; set; }
        public string ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
