using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.MasterData
{
    public class ShipmentExpandDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public ShipmentExpandDataManager()
        {
            Repository = new ShipmentExpandRepository();
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

        public IEnumerable<T> Get<T>(Paging paging, out int count, string expression, object[] parameters)
        {
            return ((ShipmentExpandRepository)Repository).Get<T>(paging, out count, expression, parameters);
        }

        public void Printing(int shipmentId)
        {
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(shipmentId, "shipment_id"));
            if (expand == null)
            {
                expand = new ShipmentExpandModel
                {
                    ShipmentId = shipmentId,
                    VolumeL = 1,
                    VolumeH = 1,
                    VolumeW = 1,
                    IsCod = false,
                    UsePacking = false,
                    TotalCod = 0,
                    PaidCod = false,
                    Printed = 0
                };
                new ShipmentExpandDataManager().Save<ShipmentExpandModel>(expand);
            }

            new ShipmentExpandRepository().Printing(shipmentId);
        }
    }
}
