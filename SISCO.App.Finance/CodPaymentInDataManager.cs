using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class CodPaymentInDataManager : BaseDataManager
    {
        public CodPaymentInDataManager()
        {
            Repository = new CodPaymentInRepository();
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

        public List<CodFundTransferDetailModel> GetUnpaidCodPayment(int branchId)
        {
            return new CodPaymentInRepository().GetUnpaidCodPayment(branchId);
        }

        public List<OutstandingCod> GetOutstandingPayment(int branchId)
        {
            return new CodPaymentInRepository().GetOutstandingPayment(branchId);
        }
    }
}