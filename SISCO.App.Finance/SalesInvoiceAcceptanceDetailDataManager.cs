using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class SalesInvoiceAcceptanceDetailDataManager : BaseDataManager
    {
        public SalesInvoiceAcceptanceDetailDataManager()
        {
            Repository = new SalesInvoiceAcceptanceDetailRepository();
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

        public List<InvoiceUnAcceptedModel> GetUnaccepted(int branchId)
        {
            return new SalesInvoiceAcceptanceDetailRepository().GetUnaccepted(branchId);
        }

        public List<InvoiceAcceptanceDetailModel> GetDetails (int invoiceAcceptanceId)
        {
            return new SalesInvoiceAcceptanceDetailRepository().GetDetails(invoiceAcceptanceId);
        }

        public bool IsAccepted(string refNumber)
        {
            return new SalesInvoiceAcceptanceDetailRepository().IsAccepted(refNumber);
        }
    }
}
