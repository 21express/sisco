using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class CodPaymentInDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int CodPaymentInId { get; set; }
        public DateTime DateProcess { get; set; }
        public int ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public DateTime ShipmentDate { get; set; }
        public decimal TotalCod { get; set; }
        public decimal ActualPaid { get; set; }
        public string DeliveryCode { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
        public string StateChange2 { get; set; }
        public bool Checked { get; set; }
    }
}
