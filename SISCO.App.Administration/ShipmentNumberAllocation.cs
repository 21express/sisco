using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Repositories;
using Devenlab.Common.Patterns;

namespace SISCO.App.Administration
{
    public class ShipmentNumberAllocationDataManager : BaseDataManager
    {
        public ShipmentNumberAllocationDataManager()
        {
            Repository = new PickupOrderRepository();
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
    }
}
