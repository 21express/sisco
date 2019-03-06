using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class PaymentDeliveryDetailDataManager : BaseDataManager
    {
        public PaymentDeliveryDetailDataManager()
        {
            Repository = new PaymentDeliveryDetailRepository();
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

        public int GetPaymentDelivery(int invoiceId)
        {
            return ((PaymentDeliveryDetailRepository)Repository).GetPaymentDelivery(invoiceId);
        }

        public void DeActiveRows(IListParameter[] listParameters, string userName)
        {
            ((PaymentDeliveryDetailRepository)Repository).DeActiveRows(listParameters, userName);
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentDeliveryModel> master, params IListParameter[] listParameters)
        {
            return ((PaymentDeliveryDetailRepository)Repository).FilterPayment(master, listParameters);
        }
    }
}