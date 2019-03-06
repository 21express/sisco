using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class RunningTextDataManager : BaseDataManager
    {
        public RunningTextDataManager()
        {
            Repository = new RunningTextRepository();
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

        public IEnumerable<T> GetByBranchIdAndDepartmentIdAndUserId<T>(int branchId, int departmentId, int userId)
        {
            return ((RunningTextRepository)Repository).GetByBranchIdAndDepartmentIdAndUserId<T>(branchId, departmentId, userId);
        }

        public List<RunningTextModel> GetRunningText(params IListParameter[] listParameter)
        {
            return new RunningTextRepository().GetRunningText(listParameter);
        }
    }
}
