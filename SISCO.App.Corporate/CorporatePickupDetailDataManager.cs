using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Corporate
{
    public class CorporatePickupDetailDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public CorporatePickupDetailDataManager()
        {
            Repository = new CorporatePickupDetailRepository();
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
            return ((CorporatePickupDetailRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public List<CorporatePickupDetailModel> GetPickupAcceptance(params IListParameter[] parameter)
        {
            return new CorporatePickupDetailRepository().GetPickupAcceptance(parameter);
        }

        public List<CorporatePickupDetailModel> GetPickupDetail(int pickupId)
        {
            return new CorporatePickupDetailRepository().GetPickupDetail(pickupId);
        }

        public List<CorporatePickupDetailModel> GetPickupDetailPrint(int pickupId)
        {
            return new CorporatePickupDetailRepository().GetPickupDetailPrint(pickupId);
        }

        public CorporatePickupDetailModel GetShipmentPickup(string shipmentCode)
        {
            return new CorporatePickupDetailRepository().GetShipmentPickup(shipmentCode);
        }
    }
}