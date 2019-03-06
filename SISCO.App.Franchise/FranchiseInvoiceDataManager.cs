using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Franchise
{
    public class FranchiseInvoiceDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public FranchiseInvoiceDataManager()
        {
            Repository = new FranchiseInvoiceRepository();
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

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((FranchiseInvoiceRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public List<FranchiseInvoiceListModel> GetUninvoiced(IListParameter[] listParameter)
        {
            return new FranchiseInvoiceRepository().GetUninvoiced(listParameter);
        }

        public string GenerateReceipt()
        {
            return new FranchiseInvoiceRepository().GenerateReceipt();
        }
    }
}