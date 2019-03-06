using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class CountryDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public CountryDataManager()
        {
            Repository = new CountryRepository();
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
            return ((CountryRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }
    }
}
