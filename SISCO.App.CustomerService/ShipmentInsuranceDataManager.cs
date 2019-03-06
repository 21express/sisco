using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.CustomerService
{
    public class ShipmentInsuranceDataManager : BaseDataManager
    {
        public ShipmentInsuranceDataManager()
        {
            Repository = new ShipmentInsuranceRepository();
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

        public IEnumerable<T> Search<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            return new ShipmentInsuranceRepository().Search<T>(paging, out totalCount, parameter);
        }
    }
}
