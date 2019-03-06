using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Corporate
{
    public class ShipmentSyncDataManager : BaseDataManager
    {
        public ShipmentSyncDataManager()
        {
            Repository = new ShipmentSyncRepository();
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

        public void BulkInsert(string sql)
        {
            new ShipmentSyncRepository().BulkInsert(sql);
        }

        public void UpdateShipment(string shipmentCode, string userLogin, string computerName)
        {
            new ShipmentSyncRepository().UpdateShipment(shipmentCode, userLogin, computerName);
        }
    }
}
