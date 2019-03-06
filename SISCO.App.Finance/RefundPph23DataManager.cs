using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class RefundPph23DataManager : BaseDataManager
    {
        public RefundPph23DataManager()
        {
            Repository = new RefundPph23Repository();
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

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<RefundPph23Model> master, params IListParameter[] listParameters)
        {
            return ((RefundPph23Repository)Repository).FilterPayment(master, listParameters);
        }
    }
}
