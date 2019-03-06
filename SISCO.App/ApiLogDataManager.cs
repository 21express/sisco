using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Repositories;
using Devenlab.Common.Patterns;
using SISCO.Repositories.Context;
using System;

namespace SISCO.App
{
    public class ApiLogDataManager : BaseDataManager
    {
        public ApiLogDataManager()
        {
            Repository = new ApiLogRepository();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            throw new NotImplementedException();
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            throw new NotImplementedException();
        }
    }
}
