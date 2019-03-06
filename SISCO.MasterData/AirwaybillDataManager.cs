using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;

namespace SISCO.App.MasterData
{
    public class AirwaybillDataManager : BaseDataManager
    {
        public AirwaybillDataManager()
        {
            Repository = new AirwaybillRepository();
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

        public override void Save<T>(IBaseModel businessModel)
        {
            base.Save<T>(businessModel);

            ActionPoster.Post(0, businessModel.Createdby, Transaction.OutboundUdara, businessModel);
        }

        public IEnumerable<AirwaybillPrintModel> Print(int airwaybillId)
        {
            return new AirwaybillDetailRepository().Print(airwaybillId);
        }

        public List<ConsolidationShipmentModel> GetShipments(int smuId)
        {
            return new AirwaybillRepository().GetShipments(smuId);
        }

        public List<AuditAirwaybillModel> FindAriwaybillList(int branchId, string awbNo = null, DateTime? dateFrom = null, DateTime? dateTo = null, int? airlineId = null, int? airportId = null, int? destAirportId = null)
        {
            return new AirwaybillRepository().FindAriwaybillList(branchId, awbNo, dateFrom, dateTo, airlineId, airportId, destAirportId);
        }

        public List<AirwaybillHeavyDifference> GetAirwaybillReportWeight(int branchId, DateTime dateFrom, DateTime dateTo)
        {
            return new AirwaybillRepository().GetAirwaybillReportWeight(branchId, dateFrom, dateTo);
        }
    }
}
