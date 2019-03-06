using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class OtherInvoiceModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public DateTime DateProcess { get; set; }
        public String Code { get; set; }
        public String RefNumber { get; set; }
        public Int32 BranchId { get; set; }
        public String BranchName { get; set; }
        public Int32 OwnerBranchId { get; set; }
        public String OwnerBranch { get; set; }
        public Int32 EmployeeId { get; set; }
        public Decimal Credit { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public Int32? CustomerId { get; set; }
        public String CustomerName { get; set; }
        public Decimal TtlPiece { get; set; }
        public Decimal TtlGrossWeight { get; set; }
        public Decimal TtlChargeableWeight { get; set; }
        public Decimal TotalSales { get; set; }
        public Decimal TotalCost { get; set; }
        public Decimal Total { get; set; }
        public bool Cancelled { get; set; }
        public bool InPaid { get; set; }
        public Decimal InTotalPayment { get; set; }
        public bool OutPaid { get; set; }
        public Decimal OutTotalPayment { get; set; }
        public String Description { get; set; }
        public bool Accept { get; set; }
        public DateTime? AcceptAt { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String CreatedPc { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public DateTime? Modifieddate { get; set; }
        public String ModifiedPc { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
    }

    public class SendInvoice
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
        public DateTime DateProcess { get; set; }
        public string RefNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public string LetterNo { get; set; }
    }

    public class PaymentDescriptoin
    {
        public string PaymentInDescription { get; set; }
        public string PaymentOutDescription { get; set; }
    }
}