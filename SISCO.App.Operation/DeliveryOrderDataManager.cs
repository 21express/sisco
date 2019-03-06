using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories;
using Devenlab.Common.Patterns;

namespace SISCO.App.Operation
{
    public class DeliveryOrderDataManager : BaseDataManager
    {
        public DeliveryOrderDataManager()
        {
            Repository = new DeliveryOrderRepository();
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

        public IEnumerable<DeliveryOrderModel> GetByDeliveryOrderIds(int[] deliveryOrderIds)
        {
            return ((DeliveryOrderRepository)Repository).GetByDeliveryOrderIds(deliveryOrderIds);
        }
    }
}
