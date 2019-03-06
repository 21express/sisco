using System;
using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FranchiseLogModel : IBaseModel
    {
        public int Id { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string AppVersion { get; set; }
        public DateTime InsertedDate { get; set; }

        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}


