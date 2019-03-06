using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class DropPointModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int BranchId { get; set; }
        public string Phone { get; set; }
        public string NoId { get; set; }
        public string Email { get; set; }
        public decimal Commission { get; set; }
        public DateTime Createddate { get; set; }
        public string CreatedPc { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public string ModifiedPc {get;set;}
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public class DropPointReport
    {
        public string ShipmentCode { get; set; }
        public DateTime ShipmentDate { get; set; }
        public decimal Percent { get; set; }
        public decimal Total { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
