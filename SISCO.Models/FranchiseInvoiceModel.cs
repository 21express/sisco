using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class FranchiseInvoiceModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string InvoicedTo { get; set; }
        public DateTime DueDate { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public decimal Materai { get; set; }
        public decimal TotalInvoice { get; set; }
        public decimal Total { get; set; }
        public bool Printed { get; set; }
        public bool Cancelled { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedPc { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
