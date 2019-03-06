using System;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Models
{
    public class FranchiseModel: IBaseModel
    {
        public int Id { get; set; }

        public bool Rowstatus { get; set; }

        public DateTime Rowversion { get; set; }

        public Int32 BranchId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Int32 CityId { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public decimal Commission { get; set; }

        public string ProductKey { get; set; }

        public bool ActiveFlag { get; set; }

        public short? OrgType { get; set; }

        public string NPWP { get; set; }

        public string NPWPName { get; set; }

        public int PaymentMethodId { get; set; }

        public int Credit { get; set; }

        public DateTime Createddate { get; set; }

        public string Createdby { get; set; }

        public string Modifiedby { get; set; }

        public DateTime? Modifieddate { get; set; }

        public EnumStateChange StateChange { get; set; }
    }

    public class OutstandingPayment
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateProcess { get; set; }
        public decimal Total { get; set; }
        public int FranchiseId { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string FranchiseCode { get; set; }
        public string FranchiseName { get; set; }
        public bool Paid { get; set; }
        public string PaymentCode { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool Transfer { get;set;}
        public string TransferCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public bool Verify { get; set; }
        public string VerifyCode { get; set; }
        public DateTime? VerifyDate { get; set; }
    }
}