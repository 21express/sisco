using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class PettyCashModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int BranchId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class PettyCashEmployeeBalance
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public decimal BeginningBalance { get; set; }
        public string PettyCashVoucher { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal EndingBalance { get; set; }
    }
}
