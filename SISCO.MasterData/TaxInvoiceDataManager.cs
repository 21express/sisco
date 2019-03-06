﻿using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using System.Collections.Generic;

namespace SISCO.App.MasterData
{
    public class TaxInvoiceDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public TaxInvoiceDataManager()
        {
            Repository = new TaxInvoiceRepository();
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

        public IEnumerable<T> Get<T>(Paging paging, out int count, string expression, object[] parameters)
        {
            return ((TaxInvoiceRepository)Repository).Get<T>(paging, out count, expression, parameters);
        }
    }
}