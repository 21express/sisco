using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.MasterData
{
    public class VendorDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public VendorDataManager()
        {
            Repository = new VendorRepository();
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
            return ((VendorRepository)Repository).Get<T>(paging, out count, expression, parameters);
        }

        public void Save(IList<VendorModel> list, IList<VendorModel> deletedList, string actor)
        {
            ((VendorRepository)Repository).SaveList(list, deletedList, actor);
        }
    }
}