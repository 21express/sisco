using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class ClaimedDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int ClaimedId { get; set; }
        public int ShipmentId { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class ShipmentClaimed
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public string CustomerName { get; set; }
        public string ShipmentCode { get; set; }
        public decimal GoodsValue { get; set; }
        public decimal InsuranceFee { get; set; }
        public string StateChange2 { get; set; }
    }
}