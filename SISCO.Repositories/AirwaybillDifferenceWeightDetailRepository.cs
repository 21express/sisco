using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class AirwaybillDifferenceWeightDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "AirwaybillDifferenceWeightDetail";
        public AirwaybillDifferenceWeightDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public AirwaybillDifferenceWeightDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as AirwaybillDifferenceWeightDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToairwaybill_difference_weight_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as AirwaybillDifferenceWeightDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.airwaybill_difference_weight_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as AirwaybillDifferenceWeightDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.airwaybill_difference_weight_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.airwaybill_difference_weight_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.airwaybill_difference_weight_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static airwaybill_difference_weight_detail PopulateModelToNewEntity(AirwaybillDifferenceWeightDetailModel model)
		{
			return new airwaybill_difference_weight_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				airwaybill_difference_weight_id = model.AirwaybillDifferenceWeightId,
                shipment_id = model.ShipmentId,
                ttl_piece_pod = model.TtlPiecePod,
                ttl_chargeable_weight_pod = model.TtlChargeableWeightPod,
                consolidation_id = model.ConsolidationId,
                ttl_piece_consol = model.TtlPieceConsol,
                ttl_chargeable_weight_consol = model.TtlChargeableWeightConsol,
                airwaybill_id = model.AirwaybillId,
                ttl_chargeable_weight_airwaybill = model.TtlChargeableWeightAirwaybill,
                diff_weight = model.DiffWeight,
                is_packing = model.IsPacking,
                diff_percent = model.DiffPercent,
                is_diff = model.IsDiff,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(airwaybill_difference_weight_detail query, AirwaybillDifferenceWeightDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.airwaybill_difference_weight_id = model.AirwaybillDifferenceWeightId;
            query.shipment_id = model.ShipmentId;
            query.ttl_piece_pod = model.TtlPiecePod;
            query.ttl_chargeable_weight_pod = model.TtlChargeableWeightPod;
            query.consolidation_id = model.ConsolidationId;
            query.ttl_piece_consol = model.TtlPieceConsol;
            query.ttl_chargeable_weight_consol = model.TtlChargeableWeightConsol;
            query.airwaybill_id = model.AirwaybillId;
            query.ttl_chargeable_weight_airwaybill = model.TtlChargeableWeightAirwaybill;
            query.diff_weight = model.DiffWeight;
            query.is_packing = model.IsPacking;
            query.diff_percent = model.DiffPercent;
            query.is_diff = model.IsDiff;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static AirwaybillDifferenceWeightDetailModel PopulateEntityToNewModel(airwaybill_difference_weight_detail item)
		{
            return new AirwaybillDifferenceWeightDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				AirwaybillDifferenceWeightId = item.airwaybill_difference_weight_id,
                ShipmentId = item.shipment_id,
                TtlPiecePod = item.ttl_piece_pod,
                TtlChargeableWeightPod = item.ttl_chargeable_weight_pod,
                ConsolidationId = item.consolidation_id,
                TtlPieceConsol = item.ttl_piece_consol,
                TtlChargeableWeightConsol = item.ttl_chargeable_weight_consol,
                AirwaybillId = item.airwaybill_id,
                TtlChargeableWeightAirwaybill = item.ttl_chargeable_weight_airwaybill,
                DiffWeight = item.diff_weight,
                IsPacking = item.is_packing,
                DiffPercent = item.diff_percent,
                IsDiff = item.is_diff,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airwaybill_difference_weight_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.airwaybill_difference_weight_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.airwaybill_difference_weight_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.airwaybill_difference_weight_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.airwaybill_difference_weight_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.airwaybill_difference_weight_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<DiffWeightAirwaybillShipmentModel> GetDetails(int diffId)
        {
            var sql = @"SELECT
	                        adwd.id Id,
	                        s.date_process DateProcess,
                            adwd.airwaybill_difference_weight_id AirwaybillDifferenceWeightId,
                            s.id ShipmentId,
                            s.code ShipmentCode, 
                            cs.name CustomerName,
                            adwd.ttl_piece_pod TtlPiecePod,
                            b.code DestBranchCode,
                            adwd.ttl_chargeable_weight_pod TtlChargeableWeightPod,
                            c.id ConsolidationId,
                            c.code ConsolidationCode,
                            adwd.ttl_piece_consol TtlPieceConsol,
                            adwd.ttl_chargeable_weight_consol TtlChargeableWeightConsol,
                            adwd.airwaybill_id AirwaybillId,
                            adwd.ttl_chargeable_weight_airwaybill TtlChargeableWeightAirwaybill,
                            adwd.diff_weight DiffWeight,
                            adwd.is_packing IsPacking,
                            adwd.diff_percent DiffPercent,
                            adwd.is_diff IsDiff,
                            'Select' StateChange
                        FROM airwaybill_difference_weight_detail adwd
                        INNER JOIN airwaybill_difference_weight adw ON adwd.airwaybill_difference_weight_id = adw.id AND adw.rowstatus = 1
                        INNER JOIN shipment s ON adwd.shipment_id = s.id
                        INNER JOIN consolidation c ON c.id = adwd.consolidation_id AND c.rowstatus = 1
                        INNER JOIN branch b ON s.dest_branch_id = b.id
                        LEFT JOIN customer cs ON s.customer_id = cs.id
                        WHERE adwd.rowstatus = 1 AND adw.id = @diffId;";

            return Entities.ExecuteStoreQuery<DiffWeightAirwaybillShipmentModel>(sql, new MySqlParameter("diffId", diffId)).ToList();
        }

        public List<DiffWeightAirwaybillShipmentModel> AuditSMU(List<int> shipmentIds)
        {
            var sql = @"SELECT
	                        0 Id,
	                        s2.date_process DateProcess,
	                        s2.id ShipmentId,
	                        s2.code ShipmentCode,
	                        cs.name CustomerName,
	                        s2.ttl_piece TtlPiecePod,
	                        b.code DestBranchCode,
	                        s2.ttl_chargeable_weight TtlChargeableWeightPod,
	                        c.id ConsolidationId,
	                        c.code ConsolidationCode,
	                        c2.ttl_pcs TtlPieceConsol,
	                        c3.ttl_chargeable_weight TtlChargeableWeightConsol,
                            a.id AirwaybillId,
                            s3.ttl_chargeable_weight TtlChargeableWeightAirwaybill,
	                        IF (s3.ttl_chargeable_weight > c3.ttl_chargeable_weight, s3.ttl_chargeable_weight - c3.ttl_chargeable_weight, 0) DiffWeight,
	                        se.use_packing IsPacking,
                            IF (s3.ttl_chargeable_weight > c3.ttl_chargeable_weight, ((s3.ttl_chargeable_weight - c3.ttl_chargeable_weight)/s3.ttl_chargeable_weight)*100, 0) DiffPercent,
                            IF (s3.ttl_chargeable_weight > c3.ttl_chargeable_weight, true, false) IsDiff,
                            'Insert' StateChange
                        FROM consolidation c
                        INNER JOIN consolidation_detail cd ON c.id = cd.consolidation_id AND cd.rowstatus = 1
                        INNER JOIN shipment s2 ON cd.shipment_id = s2.id AND s2.rowstatus = 1
                        INNER JOIN shipment_expand se ON s2.id = se.shipment_id
                        INNER JOIN branch b ON s2.dest_branch_id = b.id
                        LEFT JOIN customer cs ON s2.customer_id = cs.id
                        INNER JOIN airwaybill_detail ad ON ad.shipment_code = c.code AND ad.rowstatus = 1
                        INNER JOIN airwaybill a ON ad.airwaybill_id = a.id AND a.rowstatus = 1 AND a.is_cancelled = 0
                        INNER JOIN (
	                        SELECT 
		                        s.id shipment_id,
		                        SUM(s.a) ttl_chargeable_weight
	                        FROM (
		                        SELECT
			                        s2.id,
			                        ad.ttl_chargeable_weight a
		                        FROM consolidation c
		                        INNER JOIN consolidation_detail cd ON c.id = cd.consolidation_id AND cd.rowstatus = 1
		                        INNER JOIN shipment s2 ON cd.shipment_id = s2.id AND s2.rowstatus = 1
		                        INNER JOIN airwaybill_detail ad ON ad.shipment_code = c.code AND ad.rowstatus = 1
		                        INNER JOIN airwaybill a ON ad.airwaybill_id = a.id AND a.rowstatus = 1 AND a.is_cancelled = 0
		                        WHERE c.rowstatus = 1 AND s2.id IN({0})
		                        GROUP BY c.id, s2.id
	                        )s
	                        GROUP BY s.id
                        ) s3 ON s2.id = s3.shipment_id
                        INNER JOIN (
	                        SELECT
		                        c.id,
                                COUNT(cd.shipment_id) ttl_pcs
                            FROM consolidation_detail cd
                            INNER JOIN consolidation c ON cd.consolidation_id = c.id AND c.rowstatus = 1
                            WHERE cd.rowstatus = 1 AND cd.shipment_id IN({0})
                            GROUP BY c.id, cd.shipment_id
                        ) c2 ON c2.id = c.id
                        INNER JOIN (
		                    SELECT
			                    d.id,
                                sum(d.ttl_chargeable_weight) ttl_chargeable_weight
                            FROM (
			                    SELECT
				                    c.id,
				                    s.ttl_chargeable_weight
			                    FROM consolidation_detail cd
			                    INNER JOIN shipment s ON cd.shipment_id = s.id AND s.rowstatus = 1
			                    INNER JOIN consolidation c ON cd.consolidation_id = c.id AND c.rowstatus = 1
			                    WHERE cd.rowstatus AND s.id IN({0})
			                    GROUP BY c.id, s.id
                            ) d
                            GROUP BY d.id
                        ) c3 ON c3.id = c.id
                        WHERE c.rowstatus = 1 AND s2.id IN({0})
                        GROUP BY c.id, s2.id;";

            sql = string.Format(sql, string.Join(",", shipmentIds));
            return Entities.ExecuteStoreQuery<DiffWeightAirwaybillShipmentModel>(sql).ToList();
        }
    }
}