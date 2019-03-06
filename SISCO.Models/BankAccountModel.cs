using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class BankAccountModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int BranchId { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountName { get; set; }
        public string AccountAddress { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }
}