﻿using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class TaxTypeDataManager : BaseDataManager
    {
        public TaxTypeDataManager()
        {
            Repository = new TaxTypeRepository();
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
    }
}
