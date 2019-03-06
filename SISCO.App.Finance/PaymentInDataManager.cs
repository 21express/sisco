using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class PaymentInDataManager : BaseDataManager
    {
        public PaymentInDataManager()
        {
            Repository = new PaymentInRepository();
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

        public int GetPaymentInvoice(int invoiceId)
        {
            return ((PaymentInDetailRepository)Repository).GetPaymentInvoice(invoiceId);
        }

        public List<PaymentInModel> GetInvoiceMarketing(int marketingId)
        {
            return new PaymentInRepository().GetInvoiceMarketing(marketingId);
        }
    }
}
