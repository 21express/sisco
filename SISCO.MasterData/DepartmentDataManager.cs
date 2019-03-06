using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class DepartmentDataManager : BaseDataManager
    {
        public DepartmentDataManager()
        {
            Repository = new DepartmentRepository();
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

        public void Save(IList<DepartmentModel> list, IList<DepartmentModel> deletedList, string actor)
        {
            ((DepartmentRepository)Repository).SaveList(list, deletedList, actor);
        }
    }
}
