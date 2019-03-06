using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;

namespace SISCO.App.Corporate
{
    public class CorporatePriviledgeDataManager : BaseDataManager
    {
        public CorporatePriviledgeDataManager()
        {
            Repository = new CorporatePriviledgeRepository();
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

        public IEnumerable<T> GetJoinCorporateUserPrivilegeByCorporateUserId<T>(int corporateUserId)
        {
            return ((CorporatePriviledgeRepository)Repository).GetJoinCorporateUserPrivilegeByCorporateUserId<T>(corporateUserId);
        }
    }
}
