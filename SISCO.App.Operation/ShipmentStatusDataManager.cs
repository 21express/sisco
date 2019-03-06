using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories;
using Devenlab.Common.Patterns;
using SISCO.Repositories.Context;

namespace SISCO.App.Operation
{
    public class ShipmentStatusDataManager : BaseDataManager
    {
        public ShipmentStatusDataManager()
        {
            Repository = new ShipmentStatusRepository();
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

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var data = Repository.GetSingle<ShipmentStatusModel>(WhereTerm.Default(id, "id", EnumSqlOperator.Equals));
            base.DeActive(id, userName, deleteDate);

            var shipmentStatus = Repository.Get<ShipmentStatusModel>(WhereTerm.Default(data.ShipmentId, "shipment_id", EnumSqlOperator.Equals)).LastOrDefault();
            if (shipmentStatus != null)
            {
                var ship = new ShipmentRepository();
                var s = ship.GetSingle<ShipmentModel>(WhereTerm.Default(shipmentStatus.ShipmentId, "id", EnumSqlOperator.Equals));
                if (s != null)
                {
                    s.TrackingStatusId = shipmentStatus.TrackingStatusId;
                    ship.Update(s);
                }
            }
        }

        public void Save<T>(int p, IList<T> shipments)
        {

            ((ShipmentStatusRepository)Repository).Save<T>(p, shipments);
        }

        public ShipmentStatusModel GetLastStatusByShipment(int shipmentId, List<int> trackingStatuses)
        {
            return new ShipmentStatusRepository().GetLastStatusByShipment(shipmentId, trackingStatuses);
        }

        public List<ShipmentStatusModel> GetTrackingView(int shipmentId)
        {
            return new ShipmentStatusRepository().GetTrackingView(shipmentId);
        }
    }
}
