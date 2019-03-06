using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class BankAccountBranchModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int BankAccountId { get; set; }
        public int BranchId { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }
}