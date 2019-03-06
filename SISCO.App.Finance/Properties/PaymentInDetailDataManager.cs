using System.Collections;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class PaymentInDetailDataManager : BaseDataManager
    {
        public PaymentInDetailDataManager()
        {
            Repository = new PaymentInDetailRepository();
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

        public void DeActiveRows(IListParameter[] listParameters, string userName)
        {
            ((PaymentInDetailRepository)Repository).DeActiveRows(listParameters, userName);
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentInModel> master, params IListParameter[] listParameters)
        {
            return ((PaymentInDetailRepository)Repository).FilterPayment(master, listParameters);
        }

        public IEnumerable<PaymentInDetailModel> GetKwitansi(params IListParameter[] listParameters)
        {
            return new PaymentInDetailRepository().GetKwitansi(listParameters);
        }
    }
}
