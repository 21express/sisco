using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories;
using Devenlab.Common.Patterns;

namespace SISCO.App.Operation
{
    public class DeliveryOrderDetailDataManager : BaseDataManager
    {
        public DeliveryOrderDetailDataManager()
        {
            Repository = new DeliveryOrderDetailRepository();
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

        public IEnumerable<DeliveryOrderDetailModel> DeliveryResult(IListParameter[] listParameter)
        {
            return ((DeliveryOrderDetailRepository)Repository).DeliveryResult(listParameter);
        }

        public IEnumerable<DeliveryOrderDetailModel> GetByShipmentIds(int[] shipmentIds)
        {
            return ((DeliveryOrderDetailRepository)Repository).GetByShipmentIds(shipmentIds);
        }
    }
}
