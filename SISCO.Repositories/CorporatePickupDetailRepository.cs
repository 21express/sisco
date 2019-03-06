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

namespace SISCO.Repositories
{
    public class CorporatePickupDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "CorporatePickupDetail";
        public CorporatePickupDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CorporatePickupDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CorporatePickupDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocorporate_pickup_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as CorporatePickupDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.corporate_pickup_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CorporatePickupDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.corporate_pickup_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.corporate_pickup_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.corporate_pickup_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static corporate_pickup_detail PopulateModelToNewEntity(CorporatePickupDetailModel model)
        {
            return new corporate_pickup_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                corporate_pickup_id = model.CorporatePickupId,
                shipment_id = model.ShipmentId,
                createddate = model.Createddate,
                createdby = model.Createdby,
                createdpc = model.CreatedPc,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
            };
        }

        private static void PopulateModelToNewEntity(corporate_pickup_detail query, CorporatePickupDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.corporate_pickup_id = model.CorporatePickupId;
            query.shipment_id = model.ShipmentId;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
        }

        private static CorporatePickupDetailModel PopulateEntityToNewModel(corporate_pickup_detail item)
        {
            return new CorporatePickupDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                CorporatePickupId = item.corporate_pickup_id,
                ShipmentId = item.shipment_id,
                Createddate = item.createddate,
                Createdby = item.createdby,
                CreatedPc = item.createdpc,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
                ModifiedPc = item.modifiedpc
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_pickup_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_pickup_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_pickup_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.corporate_pickup_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.corporate_pickup_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.corporate_pickup_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<CorporatePickupDetailModel> GetPickupAcceptance(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_pickup_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var result = (from q in query
                join s in Entities.shipments on q.shipment_id equals s.id
                select new CorporatePickupDetailModel
                {
                    Id = q.id,
                    Rowstatus = q.rowstatus,
                    Rowversion = q.rowversion,
                    CorporatePickupId = q.corporate_pickup_id,
                    ShipmentId = q.shipment_id,
                    ShipmentDate = s.date_process,
                    ShipmentCode = s.code,
                    ServiceTypeId = s.service_type_id,
                    PackageTypeId = s.package_type_id,
                    TtlPiece = s.ttl_piece,
                    TtlChargeableWeight = s.ttl_chargeable_weight,
                    TtlGrossWeight = s.ttl_gross_weight,
                    Createddate = q.createddate,
                    Createdby = q.createdby,
                    CreatedPc = q.createdpc,
                    Modifieddate = q.modifieddate,
                    Modifiedby = q.modifiedby,
                    ModifiedPc = q.modifiedpc
                }).ToList();

            return result;
        }

        public List<CorporatePickupDetailModel> GetPickupDetail(int pickupId)
        {
            var sql = @"
                SELECT 
		                p.id Id,
		                p.rowstatus Rowstatus,
		                p.rowversion Rowversion,
                        p.corporate_pickup_id CorporatePickupId,
                        s.id ShipmentId,
                        s.date_process ShipmentDate,
                        s.code ShipmentCode,
		                s.ttl_piece TtlPiece,
		                s.ttl_gross_weight TtlGrossWeight,
		                s.ttl_chargeable_weight TtlChargeableWeight,
                        t.name PackageType,
                        v.name ServiceType,
		                true Checked,
		                0 StateChange
                FROM corporate_pickup_detail p
                INNER JOIN shipment s ON p.shipment_id = s.id
                INNER JOIN package_type t ON t.id = s.package_type_id
                INNER JOIN service_type v ON s.service_type_id = v.id
                WHERE s.rowstatus = 1 AND p.rowstatus = 1 AND p.corporate_pickup_id = ? AND s.voided = 0
                ORDER BY p.createddate DESC, s.voided
                ";

            var result = Entities.ExecuteStoreQuery<CorporatePickupDetailModel>(sql, pickupId).ToList();
            return result;
        }

        public List<CorporatePickupDetailModel> GetPickupDetailPrint(int pickupId)
        {
            var sql = @"SELECT
                        p.id Id,
                        s.code ShipmentCode,
		                IF(s.voided > 0, 0, s.ttl_piece) TtlPiece,
		                IF(s.voided > 0, 0, s.ttl_gross_weight) TtlGrossWeight,
		                IF(s.voided > 0, 0, s.ttl_chargeable_weight) TtlChargeableWeight,
		                p.shipment_id ShipmentId,
                        IF(s.voided > 0, 'Voided', '') Notes,
                        t.name PackageType,
                        v.name ServiceType,
		                true Checked,
		                0 StateChange
                FROM corporate_pickup_detail p
                INNER JOIN shipment s ON p.shipment_id = s.id
                INNER JOIN package_type t ON t.id = s.package_type_id
                INNER JOIN service_type v ON s.service_type_id = v.id
                WHERE s.rowstatus = 1 AND p.rowstatus = 1 AND p.corporate_pickup_id = ?
                ORDER BY s.voided, p.createddate DESC
                ";

            var result = Entities.ExecuteStoreQuery<CorporatePickupDetailModel>(sql, pickupId).ToList();
            return result;
        }

        public CorporatePickupDetailModel GetShipmentPickup(string shipmentCode)
        {
            var sql = @"
                SELECT 
		                s.ttl_piece TtlPiece,
		                s.ttl_gross_weight TtlGrossWeight,
		                s.ttl_chargeable_weight TtlChargeableWeight,
		                s.code ShipmentCode,
		                s.id ShipmentId,
                        t.name PackageType,
                        v.name ServiceType,
		                true Checked,
		                1 StateChange
                FROM shipment s
                INNER JOIN package_type t ON t.id = s.package_type_id
                INNER JOIN service_type v ON s.service_type_id = v.id
                WHERE s.rowstatus = 1 AND s.pod_status = 0 AND s.code = ?
                ";

            var result = Entities.ExecuteStoreQuery<CorporatePickupDetailModel>(sql, shipmentCode).FirstOrDefault();
            return result;
        }
    }
}