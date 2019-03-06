using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System.Collections.Generic;

namespace SISCO.App.Billing
{
    public class InvoiceToFinanceDetailDataManager : BaseDataManager
    {
        public InvoiceToFinanceDetailDataManager()
        {
            Repository = new InvoiceToFinanceDetailRepository();
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

        public List<InvoiceFinanceDetailModel> Get(int invoiceFinanceId)
        {
            return new InvoiceToFinanceDetailRepository().Get(invoiceFinanceId);
        }

        public bool IsRefSent(string refNumber)
        {
            return new InvoiceToFinanceDetailRepository().IsRefSent(refNumber);
        }
    }
}