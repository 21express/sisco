using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Franchise
{
    public class FranchiseDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public FranchiseDataManager()
        {
            Repository = new FranchiseRepository();
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

        public string GenerateCode(FranchiseModel model)
        {
            return ((FranchiseRepository)Repository).GenerateCode(model);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((FranchiseRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }
    }
}
