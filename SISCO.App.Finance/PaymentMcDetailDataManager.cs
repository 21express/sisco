using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class PaymentMcDetailDataManager : BaseDataManager
    {
        public PaymentMcDetailDataManager()
        {
            Repository = new PaymentMcDetailRepository();
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

        public int GetPaymentMc(int invoiceId)
        {
            return ((PaymentMcDetailRepository)Repository).GetPaymentMc(invoiceId);
        }

        public void DeActiveRows(IListParameter[] listParameters, string userName)
        {
            ((PaymentRcDetailRepository)Repository).DeActiveRows(listParameters, userName);
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentMcModel> master, params IListParameter[] listParameters)
        {
            return ((PaymentMcDetailRepository)Repository).FilterPayment(master, listParameters);
        }
    }
}