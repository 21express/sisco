using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;

namespace SISCO.App.Finance
{
    public class SalesInvoiceAcceptanceDataManager : BaseDataManager
    {
        public SalesInvoiceAcceptanceDataManager()
        {
            Repository = new SalesInvoiceAcceptanceRepository();
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

        public List<InvoiceAcceptanceFinanceSearchModel> Search(int branchId, string refNumber = null, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            return new SalesInvoiceAcceptanceRepository().Search(branchId, refNumber, dateFrom, dateTo);
        }
    }
}
