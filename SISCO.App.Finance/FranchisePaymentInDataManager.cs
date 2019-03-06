using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class FranchisePaymentInDataManager : BaseDataManager
    {
        public FranchisePaymentInDataManager()
        {
            Repository = new FranchisePaymentInRepository();
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

        public List<FranchiseFundTransferDetailModel> GetUnpaidFranchisePayment(int branchId)
        {
            return new FranchisePaymentInRepository().GetUnpaidFranchisePayment(branchId);
        }

        public List<OutstandingPayment> GetOutstandingPayment(int? franchiseId, int branchId, int paymentId)
        {
            return new FranchisePaymentInRepository().GetOutstandingPayment(franchiseId, branchId, paymentId);
        }
    }
}
