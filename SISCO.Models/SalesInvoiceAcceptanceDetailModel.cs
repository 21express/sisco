using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class SalesInvoiceAcceptanceDetailModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public Int32 SalesInvoiceAcceptanceId { get; set; }
        public Int32 SalesInvoiceId { get; set; }
        public Int32? CollectorId { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
    }

    public class InvoiceAcceptanceDetailModel
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public int Period { get; set; }
        public decimal Total { get; set; }
        public int? CollectorId { get; set; }
        public string CollectorName { get; set; }
        public string StateChange { get; set; }
    }

    public class InvoiceUnAcceptedModel
    {
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public int Period { get; set; }
    }
}