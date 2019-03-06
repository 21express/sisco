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
    public class DropPointDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public DropPointDataManager()
        {
            Repository = new DropPointRepository();
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
            return ((DropPointRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public string GenerateCode(DropPointModel model)
        {
            return ((DropPointRepository)Repository).GenerateCode(model);
        }

        public List<DropPointReport> CommissionReport(DateTime from, DateTime to, int? branchId = null)
        {
            return new DropPointRepository().CommissionReport(from, to, branchId);
        }
    }
}
