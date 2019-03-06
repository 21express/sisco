using System.Collections.Generic;
using System.Security.Permissions;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Repositories;
using Devenlab.Common.Patterns;
using SISCO.Models;

namespace SISCO.App.Operation
{
    public class ConsolidationDataManager : BaseDataManager
    {
        public ConsolidationDataManager()
        {
            Repository = new ConsolidationRepository();
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = @"Get")]
        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            return Repository.Get<T>(listParameter);
        }

        /*[PrincipalPermission(SecurityAction.Demand, Role = @"Save Consolidation Form")]
        [PrincipalPermission(SecurityAction.Demand, Role = @"Update Consolidation Form")]
        [PrincipalPermission(SecurityAction.Demand, Role = @"Save Manifest Form")]
        [PrincipalPermission(SecurityAction.Demand, Role = @"Update Manifest Form")]*/
        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            return Repository.GetSingle<T>(listParameter);
        }

        /*[PrincipalPermission(SecurityAction.Demand, Role = @"Save Inbound Form")]
        [PrincipalPermission(SecurityAction.Demand, Role = @"Update Inbound Form")]*/
        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            return Repository.Get<T>(paging, out count, listParameter);
        }
    }
}
