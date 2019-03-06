using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class ShipmentInsuranceModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public System.DateTime Rowversion { get; set; }
        public System.DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public string ShipmentCode { get; set; }
        public bool IsCash { get; set; }
        public System.DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public System.DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class InsuranceDetail
    {
        public int ShipmentId { get; set; }
        public bool Posted { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateProcess { get; set; }
        public string CityName { get; set; }
        public string DestCity { get; set; }
        public string NatureOfGoods { get; set; }
        public string Conveyance { get; set; }
        public string Code { get; set; }
        public decimal GoodsValue { get; set; }
        public decimal? Rate { get; set; }
        public decimal InsuranceFee { get; set; }
        public string StateChange { get; set; }
    }
}