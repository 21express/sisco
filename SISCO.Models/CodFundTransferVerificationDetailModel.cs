using Devenlab.Common;
using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Models
{
    public class CodFundTransferVerificationDetailModel : IBaseModel
    {
        public Int32 Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public DateTime DateProcess { get; set; }
        public Int32 CodFundTransferVerificationId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceCode { get; set; }
        public decimal InvoiceTotal { get; set; }
        public DateTime Createddate { get; set; }
        public String Createdby { get; set; }
        public String Modifiedby { get; set; }
        public EnumStateChange StateChange { get; set; }
        public string StateChange2 { get; set; }
        public DateTime? Modifieddate { get; set; }

        public int? DestBranchId { get; set; }
        public string DestBranch { get; set; }
        public bool Verified { get; set; }
    }
}
