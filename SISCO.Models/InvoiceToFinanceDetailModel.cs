using Devenlab.Common.Interfaces;
namespace SISCO.Models
{
    public class InvoiceToFinanceDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public System.DateTime Rowversion { get; set; }
        public int InvoiceToFinanceId { get; set; }
        public int SalesInvoiceId { get; set; }
        public System.DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public System.DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class InvoiceFinanceDetailModel
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public int Period { get; set; }
        public decimal Total { get; set; }
        public string StateChange { get; set; }
    }
}