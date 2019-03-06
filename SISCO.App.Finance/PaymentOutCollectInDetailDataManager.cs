using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class PaymentOutCollectInDetailDataManager : BaseDataManager
    {
        public PaymentOutCollectInDetailDataManager()
        {
            Repository = new PaymentOutCollectInDetailRepository();
        }

        public void DeActiveRows(IListParameter[] listParameters, string userName)
        {
            ((PaymentOutCollectInDetailRepository)Repository).DeActiveRows(listParameters, userName);
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

        public int GetPaymentOutCollectIn(int invoiceId)
        {
            return ((PaymentOutCollectInDetailRepository)Repository).GetPaymentOutCollectIn(invoiceId);
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentOutCollectInModel> master, params IListParameter[] listParameters)
        {
            return ((PaymentOutCollectInDetailRepository)Repository).FilterPayment(master, listParameters);
        }

        public List<PaymentOutCollectInDetailModel> GetPaidCollectIn(int branchId, string paymentMethod, int paymentInBranchId)
        {
            return new PaymentOutCollectInDetailRepository().GetPaidCollectIn(branchId, paymentMethod, paymentInBranchId);
        }
    }
}