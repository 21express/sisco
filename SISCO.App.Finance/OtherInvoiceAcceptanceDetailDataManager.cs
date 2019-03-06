using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.Finance
{
    public class OtherInvoiceAcceptanceDetailDataManager : BaseDataManager
    {
        public OtherInvoiceAcceptanceDetailDataManager()
        {
            Repository = new OtherInvoiceAcceptanceDetailRepository();
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

        public OtherInvoiceAcceptanceDetail GetInvoice(string refNumber)
        {
            return ((OtherInvoiceAcceptanceDetailRepository)Repository).GetInvoice(refNumber);
        }

        public List<OtherInvoiceAcceptanceDetail> GetInvoices(int otherInvoiceAcceptanceId)
        {
            return ((OtherInvoiceAcceptanceDetailRepository)Repository).GetInvoices(otherInvoiceAcceptanceId);
        }
    }
}
