using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class CodPaymentInModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public int BranchId { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public bool FundTransfer { get; set; }
        public decimal TotalCash { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string CreatedPc { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string ModifiedPc { get; set; }
        public EnumStateChange StateChange { get; set; }
    }

    public class CodPaymentReport
    {
        public DateTime DateProcess { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ShipmentCode { get; set; }
        public string DeliveryCode { get; set; }
        public decimal TotalCod { get; set; }
        public decimal ActualPaid { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalCash { get; set; }
    }

    public class OutstandingCod
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateProcess { get; set; }
        public decimal Total { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public bool Paid { get; set; }
        public string PaymentCode { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool Transfer { get; set; }
        public string TransferCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public bool Verify { get; set; }
        public string VerifyCode { get; set; }
        public DateTime? VerifyDate { get; set; }
        public string StatusBy { get; set; }
        public bool Received { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
