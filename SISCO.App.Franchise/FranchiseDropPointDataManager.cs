using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.Franchise
{
    public class FranchiseDropPointDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public FranchiseDropPointDataManager()
        {
            Repository = new FranchiseDropPointRepository();
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
            return ((FranchiseDropPointRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public string GenerateCode(DateTime date)
        {
            return new FranchiseDropPointRepository().GenerateCode(date);
        }
    }
}