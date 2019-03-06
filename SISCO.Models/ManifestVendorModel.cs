using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class ManifestVendorModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public String Code { get; set; }
        public Int32 BranchId { get; set; }
        public int VendorId { get; set; }
        public short TtlPiece { get; set; }
        public Decimal TtlGrossWeight { get; set; }
        public Decimal TtlChargeableWeight { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String CreatedPc { get; set; }
        public String Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public String ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}