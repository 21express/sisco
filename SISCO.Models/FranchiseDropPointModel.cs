using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class FranchiseDropPointModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime PickupDate { get; set; }
        public string Code { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class DropPointPickup
    {
        public string Code { get; set; }
        public DateTime PickupDate { get; set; }
        public string DropPointName { get; set; }
        public string ShipmentCode { get; set; }
    }
}
