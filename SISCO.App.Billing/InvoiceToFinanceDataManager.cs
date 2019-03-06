using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;

namespace SISCO.App.Billing
{
    public class InvoiceToFinanceDataManager : BaseDataManager
    {
        public InvoiceToFinanceDataManager()
        {
            Repository = new InvoiceToFinanceRepository();
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

        public override void Save<T>(IBaseModel businessModel)
        {
            Repository.Save(businessModel);
        }

        public List<InvoiceFinanceSearchModel> Search(int branchId, string refNume = null, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            return new InvoiceToFinanceRepository().Search(branchId, refNume, dateFrom, dateTo);
        }
    }
}