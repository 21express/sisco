using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class DeliveryOrderRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "DeliveryOrder";
        public DeliveryOrderRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public DeliveryOrderRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as DeliveryOrderModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTodelivery_order(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as DeliveryOrderModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.delivery_order where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as DeliveryOrderModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.delivery_order select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.delivery_order where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.delivery_order where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static delivery_order PopulateModelToNewEntity(DeliveryOrderModel model)
		{
			return new delivery_order
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
				messenger_id = model.MessengerId,
				messenger_name = model.MessengerName,
                asst_id = model.AsstId,
                asst_name = model.AsstName,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				fleet_id = model.FleetId,
				fleet_number = model.FleetNumber,
				fleet_date = model.FleetDate,
				fleet_time = model.FleetTime,
				status_id = model.StatusId,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(delivery_order query, DeliveryOrderModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.messenger_id = model.MessengerId;
			query.messenger_name = model.MessengerName;
            query.asst_id = model.AsstId;
            query.asst_name = model.AsstName;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.fleet_id = model.FleetId;
			query.fleet_number = model.FleetNumber;
			query.fleet_date = model.FleetDate;
			query.fleet_time = model.FleetTime;
			query.status_id = model.StatusId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static DeliveryOrderModel PopulateEntityToNewModel(delivery_order item)
		{
			return new DeliveryOrderModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
				MessengerId = item.messenger_id,
				MessengerName = item.messenger_name,
                AsstId = item.asst_id,
                AsstName = item.asst_name,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
				FleetId = item.fleet_id,
				FleetNumber = item.fleet_number,
				FleetDate = item.fleet_date,
				FleetTime = item.fleet_time,
				StatusId = item.status_id,
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
			var query = (from a in Entities.delivery_order select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join f in Entities.fleets on item.fleet_id equals f.id into fx
                from f in fx.DefaultIfEmpty()
                join v in Entities.vehicle_type on f.vehicle_type_id equals v.id into vx
                from v in vx.DefaultIfEmpty()
                select new DeliveryOrderModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    MessengerId = item.messenger_id,
                    MessengerName = item.messenger_name,
                    AsstId = item.asst_id,
                    AsstName = item.asst_name,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    TtlChargeableWeight = item.ttl_chargeable_weight,
                    FleetId = item.fleet_id,
                    FleetNumber = f.plate_number,
                    FleetDate = item.fleet_date,
                    FleetTime = item.fleet_time,
                    StatusId = item.status_id,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    CreatedPc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    ModifiedPc = item.modifiedpc,
                    VehicleType = v.name
                });

			return (IEnumerable<T>) obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.delivery_order select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.delivery_order select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.delivery_order select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<DeliveryOrderModel> GetByDeliveryOrderIds(int[] deliveryOrderIds)
        {
            var query = from a in Entities.delivery_order
                        where deliveryOrderIds.Contains(a.id)
                        select a;

            return query.Select(PopulateEntityToNewModel);
        }

        public IEnumerable<T> GetDeliveryOrderReport<T>(int branchId, DateTime? fromDate, DateTime? toDate, int? messengerId, int? vehicleTypeId, int? fleetId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("do.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("do.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(do.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(do.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (fleetId != null && fleetId != 0)
            {
                whereClauses.Add("do.fleet_id = @fleetId");
                parameters.Add(new MySqlParameter("fleetId", fleetId));
            }

            if (messengerId != null && messengerId != 0)
            {
                whereClauses.Add("do.messenger_id = @messengerId");
                parameters.Add(new MySqlParameter("messengerId", messengerId));
            }

            if (vehicleTypeId != null && vehicleTypeId != 0)
            {
                whereClauses.Add("f.vehicle_type_id = @vehicleTypeId");
                parameters.Add(new MySqlParameter("vehicleTypeId", vehicleTypeId));
            }

            string sql = @"SELECT
                                do.DateProcess,
                                do.MessengerCode,
                                do.MessengerId,
                                do.MessengerName,
                                do.VehicleType,
                                do.Brand,
                                do.Model,
                                do.PlateNumber,
                                SUM(do.ttl_piece) AS TtlPiece,
                                SUM(do.ttl_gross_weight) AS TtlGrossWeight,
                                SUM(do.TotalDocuments) AS TotalDocuments,
                                SUM(do.TotalPackages) AS TotalPackages
                            FROM (
                                SELECT
                                    DATE(do.date_process) AS DateProcess,
                                    do.messenger_id AS MessengerId,
                                    m.code AS MessengerCode,
                                    do.messenger_name AS MessengerName,
                                    
                                    vt.name AS VehicleType,
                                    f.brand AS Brand,
                                    f.model AS Model,
                                    f.plate_number AS PlateNumber,
                                    do.ttl_piece,
                                    do.ttl_gross_weight,
                                    (SELECT COUNT(id) FROM delivery_order_detail dod WHERE dod.delivery_order_id = do.id AND dod.rowstatus = 1 AND dod.package_type_id = 2) AS TotalDocuments,
                                    (SELECT COUNT(id) FROM delivery_order_detail dod WHERE dod.delivery_order_id = do.id AND dod.rowstatus = 1 AND dod.package_type_id = 1) AS TotalPackages
                                FROM delivery_order do
                                LEFT JOIN fleet f ON f.id = do.fleet_id AND f.rowstatus = 1
                                LEFT JOIN employee m ON m.id = do.messenger_id AND m.rowstatus = 1
                                LEFT JOIN vehicle_type vt ON vt.id = f.vehicle_type_id AND vt.rowstatus = 1
                                WHERE " + string.Join(" AND ", whereClauses) + @"
                            ) do
                              GROUP BY do.DateProcess,
                              do.MessengerId,
                              do.MessengerName,
                              do.VehicleType,
                              do.Brand,
                              do.Model,
                              do.PlateNumber";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<DeliveryPickupModel> GetDeliveryPickupReport(DateTime fromDate, DateTime toDate, int branchId, int? messengerId)
        {
            var sql = @"
                        SELECT
	                        e.id MessengerId, e.code MessengerCode, e.name MessengerName, '' Pod, po.date_process DateProcess, po.customer_name CustomerName, po.pickup_date PickupDeliveryDate,
                            po.ttl_piece TtlPiece, po.ttl_gross_weight TtlGrossWeight, po.ttl_chargeable_weight TtlChargeable, po.note Note, po.pickup_note PickupNote, 'Pickup' as status
                        FROM pickup_order po
                        INNER JOIN employee e ON po.messenger_id = e.id
                        WHERE po.rowstatus = 1 AND e.rowstatus = 1 AND po.confirmed = 1 AND po.branch_id = {0}
                        AND po.date_process >= '{1}' AND po.date_process <= '{2}' {3}

                        UNION

                        SELECT
	                        e.id MessengerId, e.code MessengerCode, e.name MessengerName, dd.shipment_code Pod, d.date_process DateProcess, dd.consignee_name CustomerName, ss.dateprocess PickupDeliveryDate, 
                            dd.ttl_piece TtlPiece, dd.ttl_gross_weight TtlGrossWeight, dd.ttl_chargeable_weight TtlChargeable, ss.status_by Note, ss.status_note PickupNote, 'Delivery' as status
                        FROM delivery_order d
                        INNER JOIN employee e ON d.messenger_id = e.id
                        INNER JOIN delivery_order_detail dd ON d.id = dd.delivery_order_id
                        LEFT JOIN shipment_status ss ON dd.shipment_id = ss.shipment_id AND ss.rowstatus = 1 AND ss.tracking_status_id = 10
                        WHERE d.rowstatus = 1 AND e.rowstatus = 1 AND d.branch_id = {0}
                        AND d.date_process >= '{1}' AND d.date_process <= '{2}' {3}";

            sql = string.Format(sql, branchId, fromDate.ToString("yyyy-MM-dd HH:mm:ss"), toDate.ToString("yyyy-MM-dd HH:mm:ss"), messengerId != null ? "AND e.id = " + messengerId : "");
            return Entities.ExecuteStoreQuery<DeliveryPickupModel>(sql).ToList();
        }
    }
}


