using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Franchise
{
    public class FranchisePriviledgeDataManager : BaseDataManager
    {
        public FranchisePriviledgeDataManager()
        {
            Repository = new FranchisePriviledgeRepository();
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

        public IEnumerable<T> GetJoinFranchiseUserPrivilegeByFranchiseUserId<T>(int franchiseUserId)
        {
            return ((FranchisePriviledgeRepository)Repository).GetJoinFranchiseUserPrivilegeByFranchiseUserId<T>(franchiseUserId);
        }
    }
}
