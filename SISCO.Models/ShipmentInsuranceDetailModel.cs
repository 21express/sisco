using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class ShipmentInsuranceDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int ShipmentInsuranceId { get; set; }
        public string Insured { get; set; }
        public int ShipmentId { get; set; }
        public string Conveyance { get; set; }
        public string NatureOfGoods { get; set; }
        public decimal GoodsValue { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }
}