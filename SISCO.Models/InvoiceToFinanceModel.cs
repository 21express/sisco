using Devenlab.Common.Interfaces;
namespace SISCO.Models
{
    public class InvoiceToFinanceModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public System.DateTime Rowversion { get; set; }
        public System.DateTime DateProcess { get; set; }
        public int BranchId { get; set; }
        public string Description { get; set; }
        public System.DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public System.DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class InvoiceFinanceSearchModel
    {
        public int Id { get; set; }
        public System.DateTime DateProcess { get; set; }
        public string RefNumber { get; set; }
    }
}