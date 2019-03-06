using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class PettyCashJournalModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int PettyCashId { get; set; }
        public DateTime DateProcess { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public int PaidReceivedBy { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class PettyCashDetailJournalModel
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public int PaidReceivedBy { get; set; }
        public string EmployeeName { get; set; }
        public string StateChange { get; set; }
    }

    public class PettyCashSearch
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateProcess { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public string EmployeeName { get; set; }
    }

    public class PettyCashSummary
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
    }
}