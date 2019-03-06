﻿using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class AirportDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public AirportDataManager()
        {
            Repository = new AirportRepository();
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
            return ((AirportRepository)Repository).Get<T>(paging, out count, expression, parameters);
        }
    }
}
