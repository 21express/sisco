using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class InvoiceTransferAcceptanceDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int InvoiceTransferAcceptanceId { get; set; }
        public int SalesInvoiceId { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class UnacceptedTransferModel
    {
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public int Period { get; set; }
    }

    public class TransferAcceptanceDetailModel
    {
        public int Id { get; set; }
        public int InvoiceTransferAcceptanceId { get; set; }
        public int SalesInvoiceId { get; set; }
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public int Period { get; set; }
        public string StateChange { get; set; }
    }
}