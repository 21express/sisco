using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class ShipmentExpandModel:IBaseModel
    {
        public int ShipmentId { get; set; }
        public decimal VolumeL { get; set; }
        public decimal VolumeW { get; set; }
        public decimal VolumeH { get; set; }
        public string ReturnAWB { get; set; }
        public bool UsePacking { get; set; }
        public bool IsCod { get; set; }
        public decimal TotalCod { get;set;}
        public bool PaidCod { get; set; }
        public string Fulfilment { get; set; }
        public short Printed { get; set; }
        public int? DropPointId { get; set; }
        public string EmailPoint { get; set; }
        public bool? Handedover { get; set; }
        public string OtherLabel { get; set; }
        public int? SprinterId { get; set; }
        public decimal? InsuranceRate { get; set; }
        public string ShipperEmail { get; set; }
        public string ShipperPhone2 { get; set; }
        public decimal? DiffCw { get; set; }
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public System.DateTime Rowversion { get; set; }
        public System.DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public System.DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }
}
