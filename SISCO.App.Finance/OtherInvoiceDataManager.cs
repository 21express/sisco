using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using System;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class OtherInvoiceDataManager : BaseDataManager
    {
        public OtherInvoiceDataManager()
        {
            Repository = new OtherInvoiceRepository();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            return Repository.Get<T>(listParameter);
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            return Repository.GetSingle<T>(listParameter);
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            return Repository.Get<T>(paging, out count, listParameter);
        }

        public List<SendInvoice> GetUnsendInvoice(int branchId, int destBranchId, DateTime start, DateTime end)
        {
            return new OtherInvoiceRepository().GetUnsendInvoice(branchId, destBranchId, start, end);
        }

        public PaymentDescriptoin GetPaymentDescription (int pid)
        {
            return new OtherInvoiceRepository().GetPaymentDescription(pid);
        }
    }
}