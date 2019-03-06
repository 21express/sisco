using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.Operation
{
    public class PodHandoverDataManager : BaseDataManager
    {
        public PodHandoverDataManager()
        {
            Repository = new PodHandoverRepository();
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

        public IEnumerable<T> Search<T>(Paging paging, out int totalCount, int? id = null, DateTime? dateFrom = null, DateTime? dateTo = null, string pod = null)
        {
            return new PodHandoverRepository().Search<T>(paging, out totalCount, id, dateFrom, dateTo, pod);
        }
    }
}