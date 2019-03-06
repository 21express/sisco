using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class PickupDocumentModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public int BranchId { get; set; }
        public string Code { get; set; }
        public int CustomerShipperId { get; set; }
        public int CustomerConsigneeId { get; set; }
        public int MessengerId { get; set; }
        public bool UsePo { get; set; }
        public bool UseDn { get; set; }
        public bool UseOc { get; set; }
        public bool Po { get; set; }
        public bool Dn { get; set; }
        public bool Oc { get; set; }
        public string Note { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedPc { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public class PickupDocumentAndPod
    {
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public string CustomerShipper { get; set; }
        public string CustomerConsignee { get; set; }
        public string MessengerName { get; set; }
        public string ShipmentCode { get; set; }
    }
}
