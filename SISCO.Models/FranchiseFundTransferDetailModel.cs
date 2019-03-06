using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;

namespace SISCO.Models
{
    public class FranchiseFundTransferDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public int FranchiseFundTransferId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceCode { get; set; }
        public decimal InvoiceTotal { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }

        public bool Checked { get; set; }
    }

    public class FundTransferDetail
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceCode { get; set; }
        public decimal InvoiceTotal { get; set; }
        public bool Checked { get; set; }
        public EnumStateChange StateChange { get; set; }
    }
}
