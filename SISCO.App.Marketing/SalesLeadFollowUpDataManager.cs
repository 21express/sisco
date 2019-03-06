using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Marketing
{
    public class SalesLeadFollowUpDataManager : BaseDataManager
    {
        public SalesLeadFollowUpDataManager()
        {
            Repository = new SalesLeadFollowUpRepository();
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

        public void Save<T>(SalesLeadModel p, IList<T> followUps)
        {
            ((SalesLeadFollowUpRepository)Repository).Save(p, followUps);
        }
    }
}
