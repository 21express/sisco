using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class PaymentOutCollectInDetailModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public Int32 PaymentOutCollectInId { get; set; }
        public String PaymentInCollectInCode { get; set; }
        public Int32 InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public String InvoiceCode { get; set; }
        public Decimal InvoiceTotal { get; set; }
        public Decimal InvoiceBalance { get; set; }
        public Decimal Payment { get; set; }
        public Decimal Balance { get; set; }
        public bool Checked { get; set; }
        public bool Paid { get; set; }
        public String CollectPaymentMethod { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public EnumStateChange StateChange { get; set; }
        public String StateChange2 { get; set; }
        public DateTime? ReportPaymentDate { get; set; }
        public Decimal ReportPayment { get; set; }
        public String ReportBranch { get; set; }
        public String ReportPaymentInCollectOutCode { get; set; }
        public String ReportDescription { get; set; }
        public String Description { get; set; }
    }
}
