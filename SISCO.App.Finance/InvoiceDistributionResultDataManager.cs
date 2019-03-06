using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using System;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class InvoiceDistributionResultDataManager : BaseDataManager
    {
        public InvoiceDistributionResultDataManager()
        {
            Repository = new InvoiceDistributionResultRepository();
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

        public List<InvoiceFinanceSearchModel> Search(int branchId, string refNumber = null, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            return new InvoiceDistributionResultRepository().Search(branchId, refNumber, dateFrom, dateTo);
        }
    }
}
