using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models.TransferObject;
using SISCO.Repositories.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.LocalStorage
{
    public class CountryServices : BaseDataManager, IExtendedQueryableDataManager
    {
        public CountryServices()
        {
            Repository = new CountryObject();
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

        public void Save(List<CountryData> countries)
        {
            new CountryObject().Save(countries);
        }
    }
}
