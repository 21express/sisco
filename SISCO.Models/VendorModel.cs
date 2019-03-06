using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class VendorModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
    }
}