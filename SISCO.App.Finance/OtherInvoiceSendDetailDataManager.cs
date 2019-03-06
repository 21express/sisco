using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;

namespace SISCO.App.Finance
{
    public class OtherInvoiceSendDetailDataManager : BaseDataManager
    {
        public OtherInvoiceSendDetailDataManager()
        {
            Repository = new OtherInvoiceSendDetailRepository();
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

        public List<SendInvoice> GetDetailsInvoice(int sendId)
        {
            return new OtherInvoiceSendDetailRepository().GetDetailsInvoice(sendId);
        }

        public List<SendInvoice> Filter(string letterNo = null, string refNumber = null, DateTime? start = null, DateTime? end = null)
        {
            return new OtherInvoiceSendDetailRepository().Filter(letterNo, refNumber, start, end);
        }
    }
}