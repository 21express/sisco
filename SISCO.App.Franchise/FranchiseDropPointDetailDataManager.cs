using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.Franchise
{
    public class FranchiseDropPointDetailDataManager: BaseDataManager, IExtendedQueryableDataManager
    {
        public FranchiseDropPointDetailDataManager()
        {
            Repository = new FranchiseDropPointDetailRepository();
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
            return ((FranchiseDropPointDetailRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public FranchiseDropPointPickup PickupDropPoint(string shipmentCode)
        {
            return new FranchiseDropPointDetailRepository().PickupDropPoint(shipmentCode);
        }

        public List<FranchiseDropPointPickup> GetPickupDropPoint(int franchiseDropPointId)
        {
            return new FranchiseDropPointDetailRepository().GetPickupDropPoint(franchiseDropPointId);
        }

        public FranchiseDropPointPickup ShipmentPickedup(string shipmentCode)
        {
            return new FranchiseDropPointDetailRepository().ShipmentPickedup(shipmentCode);
        }
    }
}