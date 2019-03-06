using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class InvoiceDistributionResultDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int InvoiceDistributionResultId { get; set; }
        public int SalesInvoiceId { get; set; }
        public int CollectorId { get; set; }
        public int PaymentTypeId { get; set; }
        public string ReceiptName { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class InvoiceUnDistributionDetailModel
    {
        public string RefNumber { get; set; }
        public DateTime DateProcess { get; set; }
        public DateTime DueDate { get; set; }
        public string CustomerName { get; set; }
        public string CollectorName { get; set; }
    }

    public class InvoiceDistributionDetailModel
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public int CollectorId { get; set; }
        public string CollectorName { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public string ReceiptName { get; set; }
        public string StateChange { get; set; }
    }

    public class InvoiceCollectorModel
    {
        public int SalesInvoiceId { get; set; }
        public bool Cancelled { get; set; }
        public bool Printed { get; set; }
        public string CustomerName { get; set; }
        public int? CollectorId { get; set; }
    }
}