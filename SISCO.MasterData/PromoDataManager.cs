using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class PromoDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public PromoDataManager()
        {
            Repository = new PromoRepository();
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
            return ((PromoRepository)Repository).Get<T>(paging, out count, expression, parameters);
        }

        public string GenerateCode()
        {
            return ((PromoRepository)Repository).GenerateCode();
        }
    }
}
