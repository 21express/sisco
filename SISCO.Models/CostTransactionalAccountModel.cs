using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class CostTransactionalAccountModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int CostId { get; set; }
        public int TransactionalAccountId { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class CostTransactionalAccount
    {
        public int Id { get; set; }
        public int CostId { get; set; }
        public string AccountNumber { get; set; }
        public int TransactionalAccountId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}