using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class PaymentInCounterDetailDataManager : BaseDataManager
    {
        public PaymentInCounterDetailDataManager()
        {
            Repository = new PaymentInCounterDetailRepository();
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

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentInCounterModel> master, params IListParameter[] listParameters)
        {
            return ((PaymentInCounterDetailRepository)Repository).FilterPayment(master, listParameters);
        }
    }
}