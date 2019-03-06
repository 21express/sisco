using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class PaymentInCollectOutDetailDataManager : BaseDataManager
    {
        public PaymentInCollectOutDetailDataManager()
        {
            Repository = new PaymentInCollectOutDetailRepository();
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
            return ((PaymentInCollectOutDetailRepository)Repository).GetPaymentOutCollectIn(invoiceId);
        }

        public void DeActiveRows(IListParameter[] listParameters, string userName)
        {
            ((PaymentInCollectOutDetailRepository)Repository).DeActiveRows(listParameters, userName);
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentInCollectOutModel> master, params IListParameter[] listParameters)
        {
            return ((PaymentInCollectOutDetailRepository)Repository).FilterPayment(master, listParameters);
        }

        public List<PaymentInCollectOutDetailModel> GetPaymentOutCollectIn(int branchId, int destBranchId)
        {
            return new PaymentInCollectOutDetailRepository().GetPaymentOutCollectIn(branchId, destBranchId);
        }
    }
}