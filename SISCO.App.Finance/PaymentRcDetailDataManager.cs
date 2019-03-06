using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class PaymentRcDetailDataManager : BaseDataManager
    {
        public PaymentRcDetailDataManager()
        {
            Repository = new PaymentRcDetailRepository();
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

        public int GetPaymentRc(int invoiceId)
        {
            return ((PaymentRcDetailRepository)Repository).GetPaymentRc(invoiceId);
        }

        public void DeActiveRows(IListParameter[] listParameters, string userName)
        {
            ((PaymentRcDetailRepository)Repository).DeActiveRows(listParameters, userName);
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentRcModel> master, params IListParameter[] listParameters)
        {
            return ((PaymentRcDetailRepository)Repository).FilterPayment(master, listParameters);
        }
    }
}