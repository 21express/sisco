using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class InvoiceDistributionResultDetailDataManager : BaseDataManager
    {
        public InvoiceDistributionResultDetailDataManager()
        {
            Repository = new InvoiceDistributionResultDetailRepository();
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

        public List<InvoiceUnDistributionDetailModel> GetUnDistributed(int branchId)
        {
            return new InvoiceDistributionResultDetailRepository().GetUnDistributed(branchId);
        }

        public List<InvoiceDistributionDetailModel> GetDetails(int distributionId)
        {
            return new InvoiceDistributionResultDetailRepository().GetDetails(distributionId);
        }

        public bool IsDistributed (string refNumber)
        {
            return new InvoiceDistributionResultDetailRepository().IsDistributed(refNumber);
        }

        public InvoiceCollectorModel GetCollector(string refNumber)
        {
            return new InvoiceDistributionResultDetailRepository().GetCollector(refNumber);
        }

        public bool IsInvoiceTransfered(string refNumber)
        {
            return new InvoiceDistributionResultDetailRepository().IsInvoiceTransfered(refNumber);
        }
    }
}