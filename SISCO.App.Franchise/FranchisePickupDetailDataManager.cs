using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Franchise
{
    public class FranchisePickupDetailDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public FranchisePickupDetailDataManager()
        {
            Repository = new FranchisePickupDetailRepository();
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
            return ((FranchisePickupDetailRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public List<FranchiseCommissionModel> GetPickupDetail(int pickupId)
        {
            return new FranchisePickupDetailRepository().GetPickupDetail(pickupId);
        }

        public List<FranchiseCommissionModel> GetPickupDetailPrint(int pickupId)
        {
            return new FranchisePickupDetailRepository().GetPickupDetailPrint(pickupId);
        }

        public FranchiseCommissionModel GetShipmentPickup(string shipmentCode)
        {
            return new FranchisePickupDetailRepository().GetShipmentPickup(shipmentCode);
        }

        public List<FranchisePickupDetailModel> GetPickupAcceptance(params IListParameter[] parameter)
        {
            return new FranchisePickupDetailRepository().GetPickupAcceptance(parameter);
        }
    }
}