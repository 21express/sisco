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
    public class FranchisePickupDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "FranchisePickupDetail";
        public FranchisePickupDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchisePickupDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchisePickupDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_pickup_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchisePickupDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_pickup_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchisePickupDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_pickup_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_pickup_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.franchise_pickup_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static franchise_pickup_detail PopulateModelToNewEntity(FranchisePickupDetailModel model)
        {
            return new franchise_pickup_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                franchise_pickup_id = model.FranchisePickupId,
                shipment_id = model.ShipmentId,
                createddate = model.Createddate,
                createdby = model.Createdby,
                createdpc = model.CreatedPc,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
            };
        }

        private static void PopulateModelToNewEntity(franchise_pickup_detail query, FranchisePickupDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.franchise_pickup_id = model.FranchisePickupId;
            query.shipment_id = model.ShipmentId;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
        }

        private static FranchisePickupDetailModel PopulateEntityToNewModel(franchise_pickup_detail item)
        {
            return new FranchisePickupDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                FranchisePickupId = item.franchise_pickup_id,
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
            var query = (from a in Entities.franchise_pickup_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_pickup_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_pickup_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_pickup_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_pickup_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_pickup_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<FranchiseCommissionModel> GetPickupDetail(int pickupId)
        {
            var sql = @"
                SELECT 
		                p.id Id,
		                f.rowstatus Rowstatus,
		                f.rowversion Rowversion,
		                s.ttl_piece TtlPiece,
		                s.ttl_gross_weight TtlGrossWeight,
		                s.ttl_chargeable_weight TtlChargeableWeight,
		                s.code ShipmentCode,
		                f.franchise_id FranchiseId,
		                f.shipment_id ShipmentId,
                        f.total_sales TotalSales,                
		                f.ppn_1 PPN,
		                f.commission Commission,
		                f.pph_23 PPH23,
		                f.total_net_commission TotalNetCommission,
                        f.Debs Debs,
		                f.createddate Createddate,
		                f.createdby Createdby,
		                f.modifieddate Modifieddate,
		                f.modifiedby Modifiedby,
                        t.name PackageType,
                        y.name ServiceType,
		                true Checked,
		                0 StateChange
                FROM franchise_commission f
                INNER JOIN shipment s ON f.shipment_id = s.id
                INNER JOIN franchise_pickup_detail p ON f.shipment_id = p.shipment_id
                INNER JOIN package_type t ON t.id = s.package_type_id
                INNER JOIN service_type y ON y.id = s.service_type_id
                WHERE s.rowstatus = 1 AND f.rowstatus = 1 AND p.rowstatus = 1 AND p.franchise_pickup_id = ? AND s.voided = 0
                ORDER BY f.createddate DESC, s.voided
                ";

            var result = Entities.ExecuteStoreQuery<FranchiseCommissionModel>(sql, pickupId).ToList();
            return result;
        }

        public List<FranchiseCommissionModel> GetPickupDetailPrint(int pickupId)
        {
            var sql = @"
                SELECT 
		                p.id Id,
		                f.rowstatus Rowstatus,
		                f.rowversion Rowversion,
                        s.code ShipmentCode,
		                IF(s.voided > 0, 0, s.ttl_piece) TtlPiece,
		                IF(s.voided > 0, 0, s.ttl_gross_weight) TtlGrossWeight,
		                IF(s.voided > 0, 0, s.ttl_chargeable_weight) TtlChargeableWeight,
		                f.franchise_id FranchiseId,
		                f.shipment_id ShipmentId,
                        IF(s.voided > 0, 0, f.total_sales) TotalSales,	                
		                IF(s.voided > 0, 0, f.ppn_1) PPN,
		                IF(s.voided > 0, 0, f.commission) Commission,
		                IF(s.voided > 0, 0, f.pph_23) PPH23,
		                IF(s.voided > 0, 0, f.total_net_commission) TotalNetCommission,
                        IF(s.voided > 0, 0, f.Debs) Debs,
                        IF(s.voided > 0, 'Voided', '') Notes,
		                f.createddate Createddate,
		                f.createdby Createdby,
		                f.modifieddate Modifieddate,
		                f.modifiedby Modifiedby,
                        t.name PackageType,
                        y.name ServiceType,
		                true Checked,
		                0 StateChange
                FROM franchise_commission f
                INNER JOIN shipment s ON f.shipment_id = s.id
                INNER JOIN franchise_pickup_detail p ON f.shipment_id = p.shipment_id
                INNER JOIN package_type t ON t.id = s.package_type_id
                INNER JOIN service_type y ON y.id = s.service_type_id
                WHERE s.rowstatus = 1 AND f.rowstatus = 1 AND p.rowstatus = 1 AND p.franchise_pickup_id = ?
                ORDER BY s.voided, f.createddate DESC
                ";

            var result = Entities.ExecuteStoreQuery<FranchiseCommissionModel>(sql, pickupId).ToList();
            return result;
        }

        public FranchiseCommissionModel GetShipmentPickup(string shipmentCode)
        {
            var sql = @"
                SELECT 
		                f.id Id,
		                f.rowstatus Rowstatus,
		                f.rowversion Rowversion,
		                s.ttl_piece TtlPiece,
		                s.ttl_gross_weight TtlGrossWeight,
		                s.ttl_chargeable_weight TtlChargeableWeight,
		                s.code ShipmentCode,
		                f.franchise_id FranchiseId,
		                f.shipment_id ShipmentId,
		                f.total_sales TotalSales,
		                f.ppn_1 PPN,
		                f.commission Commission,
		                f.pph_23 PPH23,
		                f.total_net_commission TotalNetCommission,
		                f.createddate Createddate,
		                f.createdby Createdby,
		                f.modifieddate Modifieddate,
		                f.modifiedby Modifiedby,
		                true Checked,
		                1 StateChange
                FROM franchise_commission f
                INNER JOIN shipment s ON f.shipment_id = s.id
                WHERE s.rowstatus = 1 AND f.rowstatus = 1 AND s.pod_status = 0 AND s.code = ?
                ORDER BY f.createddate
                ";

            var result = Entities.ExecuteStoreQuery<FranchiseCommissionModel>(sql, shipmentCode).FirstOrDefault();
            return result;
        }

        public List<FranchisePickupDetailModel> GetPickupAcceptance(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);

            if (ListValue.Count > 0)
            {
                for (var i = 0; i < ListValue.Count; i++)
                {
                    whereterm = whereterm.Replace(string.Format("@{0}", i), "?");
                }
            }

            var sql = string.Format(@"
                SELECT
                    f.id Id,
                    f.rowstatus Rowstatus,
                    f.franchise_pickup_id FranchisePickupId,
                    f.shipment_id ShipmentId,
                    s.date_process ShipmentDate,
                    s.code ShipmentCode,
                    s.service_type_id ServiceTypeId,
                    s.package_type_id PackageTypeId,
                    s.payment_method_id PaymentMethodId,
                    s.ttl_piece TtlPiece,
                    s.ttl_chargeable_weight TtlChargeableWeight,
                    s.ttl_gross_weight TtlGrossWeight,
                    f.createddate Createddate,
                    f.createdby Createdby,
                    f.modifieddate Modifieddate,
                    f.modifiedby Modifiedby
                FROM franchise_pickup_detail f
                INNER JOIN shipment s ON f.shipment_id = s.id
                WHERE s.rowstatus = 1 AND {0}", whereterm.Replace("rowstatus", "f.rowstatus"));
            var result = Entities.ExecuteStoreQuery<FranchisePickupDetailModel>(sql, ListValue.ToArray()).ToList();
            return result;
        }
    }
}
