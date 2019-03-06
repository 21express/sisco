using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories.LocalStorage;
using SISCO.Models.MasterData;
using SISCO.Models.TransferObject;

namespace SISCO.LocalStorage
{
    public class CityServices : BaseDataManager, IExtendedQueryableDataManager
    {
        public CityServices()
        {
            Repository = new CityObject();
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
            return ((CityObject)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public void Save(List<CityData> cities)
        {
            new CityObject().Save(cities);
        }
    }
}