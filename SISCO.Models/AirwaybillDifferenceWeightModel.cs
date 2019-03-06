using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class AirwaybillDifferenceWeightModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public int BranchId { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class DifferenceWeightSearchModel
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public string ConsolidationCode { get; set; }
        public string ShipmentCode { get; set; }
    }
}