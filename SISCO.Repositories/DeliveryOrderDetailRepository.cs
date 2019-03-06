using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class DeliveryOrderDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "DeliveryOrderDetail";
        public DeliveryOrderDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public DeliveryOrderDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as DeliveryOrderDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTodelivery_order_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as DeliveryOrderDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.delivery_order_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as DeliveryOrderDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.delivery_order_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.delivery_order_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.delivery_order_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static delivery_order_detail PopulateModelToNewEntity(DeliveryOrderDetailModel model)
		{
			return new delivery_order_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				delivery_order_id = model.DeliveryOrderId,
				date_process = model.DateProcess,
				delivery_order_code = model.DeliveryOrderCode,
				shipment_id = model.ShipmentId,
				shipment_date = model.ShipmentDate,
				shipment_code = model.ShipmentCode,
				branch_id = model.BranchId,
				dest_city_id = model.DestCityId,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				shipper_name = model.ShipperName,
				consignee_name = model.ConsigneeName,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				payment_method_id = model.PaymentMethodId,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
                is_cod = model.IsCod,
                total_cod = model.TotalCod,
				received_date = model.ReceivedDate,
                received_by = model.ReceivedBy,
                received_note = model.ReceivedNote,
                received_update = model.ReceivedUpdate,
                received = model.Received,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(delivery_order_detail query, DeliveryOrderDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.delivery_order_id = model.DeliveryOrderId;
			query.date_process = model.DateProcess;
			query.delivery_order_code = model.DeliveryOrderCode;
			query.shipment_id = model.ShipmentId;
			query.shipment_date = model.ShipmentDate;
			query.shipment_code = model.ShipmentCode;
			query.branch_id = model.BranchId;
			query.dest_city_id = model.DestCityId;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.shipper_name = model.ShipperName;
			query.consignee_name = model.ConsigneeName;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
            query.payment_method_id = model.PaymentMethodId;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
            query.is_cod = model.IsCod;
            query.total_cod = model.TotalCod;
            query.received_date = model.ReceivedDate;
            query.received_by = model.ReceivedBy;
            query.received_note = model.ReceivedNote;
            query.received_update = model.ReceivedUpdate;
            query.received = model.Received;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static DeliveryOrderDetailModel PopulateEntityToNewModel(delivery_order_detail item)
		{
			return new DeliveryOrderDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DeliveryOrderId = item.delivery_order_id,
				DateProcess = item.date_process,
				DeliveryOrderCode = item.delivery_order_code,
				ShipmentId = item.shipment_id,
				ShipmentDate = item.shipment_date,
				ShipmentCode = item.shipment_code,
				BranchId = item.branch_id,
				DestCityId = item.dest_city_id,
				CustomerId = item.customer_id,
				CustomerName = item.customer_name,
				ShipperName = item.shipper_name,
				ConsigneeName = item.consignee_name,
				ServiceTypeId = item.service_type_id,
				PackageTypeId = item.package_type_id,
				PaymentMethodId = item.payment_method_id,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
                IsCod = item.is_cod == null ? false : item.is_cod,
                TotalCod = item.total_cod == null ? 0 : item.total_cod,
				ReceivedDate = item.received_date,
                ReceivedBy = item.received_by,
                ReceivedNote = item.received_note,
                ReceivedUpdate = item.received_update,
                Received = item.received,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);

            var sql = @"SELECT
	                        dod.id Id,
                            dod.rowstatus Rowstatus,
	                        dod.rowversion Rowversion,
	                        dod.delivery_order_id DeliveryOrderId,
	                        dod.date_process DateProcess,
	                        dod.delivery_order_code DeliveryOrderCode,
	                        dod.shipment_id ShipmentId,
	                        dod.shipment_date ShipmentDate,
	                        dod.shipment_code ShipmentCode,
	                        dod.branch_id BranchId,
	                        b.code BranchCode,
	                        b.name Branch,
	                        dod.dest_city_id DestCityId,
	                        dod.customer_id CustomerId,
	                        dod.customer_name CustomerName,
	                        dod.shipper_name ShipperName,
	                        dod.consignee_name ConsigneeName,
	                        dod.service_type_id ServiceTypeId,
	                        dod.package_type_id PackageTypeId,
	                        dod.payment_method_id PaymentMethodId,
	                        p.name PaymentMethod,
	                        dod.ttl_piece TtlPiece,
	                        dod.ttl_gross_weight TtlGrossWeight,
	                        dod.ttl_chargeable_weight TtlChargeableWeight,
	                        s.iscod IsCod,
	                        s.total_cod TotalCod,
	                        s.fulfilment Fulfilment,
	                        /*dod.received_date ReceivedDate,
	                        dod.received_by ReceivedBy,
	                        dod.received_note ReceivedNote,
	                        dod.received_update ReceivedUpdate,
	                        dod.received Received,*/
                            IF(ss.dateprocess IS NULL, dod.received_date, ss.dateprocess) ReceivedDate,
	                        IF(ss.dateprocess IS NULL, dod.received_by, ss.status_by) ReceivedBy,
	                        IF(ss.dateprocess IS NULL, dod.received_note, ss.status_note) ReceivedNote,
	                        IF(ss.dateprocess IS NULL, dod.received_update, ss.dateprocess) ReceivedUpdate,
	                        IF(ss.dateprocess IS NOT NULL, 1, 0) Received,
	                        dod.createddate Createddate,
	                        dod.createdby Createdby,
	                        dod.modifieddate Modifieddate,
                            dod.modifiedby Modifiedby,
                            IF (p.name = 'COLLECT', sp.total, 0) Total,
	                        'SELECT' StateChange2
                        FROM delivery_order_detail dod
                        INNER JOIN branch b ON dod.branch_id = b.id
                        INNER JOIN shipment sp ON sp.id= dod.shipment_id AND sp.rowstatus = 1
                        INNER JOIN payment_method p ON dod.payment_method_id = p.id
                        LEFT JOIN shipment_expand s ON dod.shipment_id = s.shipment_id
                        LEFT JOIN shipment_status ss ON ss.shipment_id = dod.shipment_id AND ss.tracking_status_id = 10 AND ss.rowstatus = 1
                        WHERE {0} order by dod.id";

            for (var i = 0; i < ListClause.Count; i++) ListClause[i] = string.Format("dod.{0}", ListClause[i]);

            var result = Entities.ExecuteStoreQuery<DeliveryOrderDetailModel>(string.Format(sql, string.Join(" AND ", ListClause)));
            return (IEnumerable<T>) result.ToList();
            //var query = (from a in Entities.delivery_order_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            //if (query == null)
            //    throw new Exception(MessageEntityNotFound);

            //var x = EnumStateChange.Select.ToString();  
            //var obj = (from item in query
            //    join b in Entities.branches on item.branch_id equals b.id
            //    join p in Entities.payment_method on item.payment_method_id equals p.id
            //    join s in Entities.shipment_expand on item.shipment_id equals s.shipment_id into sx
            //    from s in sx.DefaultIfEmpty()
            //    select new DeliveryOrderDetailModel
            //    {
            //        Id = item.id,
            //        Rowstatus = item.rowstatus,
            //        Rowversion = item.rowversion,
            //        DeliveryOrderId = item.delivery_order_id,
            //        DateProcess = item.date_process,
            //        DeliveryOrderCode = item.delivery_order_code,
            //        ShipmentId = item.shipment_id,
            //        ShipmentDate = item.shipment_date,
            //        ShipmentCode = item.shipment_code,
            //        BranchId = item.branch_id,
            //        BranchCode = b.code,
            //        Branch = b.name,
            //        DestCityId = item.dest_city_id,
            //        CustomerId = item.customer_id,
            //        CustomerName = item.customer_name,
            //        ShipperName = item.shipper_name,
            //        ConsigneeName = item.consignee_name,
            //        ServiceTypeId = item.service_type_id,
            //        PackageTypeId = item.package_type_id,
            //        PaymentMethodId = item.payment_method_id,
            //        PaymentMethod = p.name,
            //        TtlPiece = item.ttl_piece,
            //        TtlGrossWeight = item.ttl_gross_weight,
            //        TtlChargeableWeight = item.ttl_chargeable_weight,
            //        IsCod = item.is_cod != null ? item.is_cod : false,
            //        TotalCod = item.total_cod == null ? 0 : item.total_cod,
            //        Fulfilment = s != null ? s.fulfilment : string.Empty,
            //        ReceivedDate = item.received_date,
            //        ReceivedBy = item.received_by,
            //        ReceivedNote = item.received_note,
            //        ReceivedUpdate = item.received_update,
            //        Received = item.received,
            //        Createddate = item.createddate,
            //        Createdby = item.createdby,
            //        Modifieddate = item.modifieddate,
            //        Modifiedby = item.modifiedby,
            //        StateChange2 = x
            //    });

            //return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            //return (IEnumerable<T>) obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.delivery_order_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.delivery_order_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.delivery_order_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<DeliveryOrderDetailModel> DeliveryResult(IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var sql = @"SELECT
	                        dod.id Id,
	                        dod.rowstatus Rowstatus,
	                        dod.rowversion Rowversion,
	                        d.code DeliveryOrderCode,
	                        dod.delivery_order_id DeliveryOrderId,
	                        dod.date_process DateProcess,
	                        dod.delivery_order_code DeliveryOrderCode,
	                        dod.shipment_id ShipmentId,
	                        dod.shipment_date ShipmentDate,
	                        dod.shipment_code ShipmentCode,
	                        dod.branch_id BranchId,
	                        b.code BranchCode,
	                        b.name Branch,
	                        dod.dest_city_id DestCityId,
	                        dod.customer_id CustomerId,
	                        dod.customer_name CustomerName,
	                        dod.shipper_name ShipperName,
	                        dod.consignee_name ConsigneeName,
	                        dod.service_type_id ServiceTypeId,
	                        dod.package_type_id PackageTypeId,
	                        p.name PackageType,
	                        dod.payment_method_id PaymentMethodId,
	                        pm.name PaymentMethod,
	                        dod.ttl_piece TtlPiece,
	                        dod.ttl_gross_weight TtlGrossWeight,
	                        dod.ttl_chargeable_weight TtlChargeableWeight,
	                        s.iscod IsCod,
	                        s.total_cod TotalCod,
	                        s.fulfilment Fulfilment,
	                        /*dod.received_date ReceivedDate,
	                        dod.received_by ReceivedBy,
	                        dod.received_note ReceivedNote,
	                        dod.received_update ReceivedUpdate,
	                        dod.received Received,
	                        dod.createddate Createddate,
	                        dod.createdby Createdby,
	                        dod.modifieddate Modifieddate,
	                        dod.modifiedby Modifiedby,*/
	                        IF(ss.dateprocess IS NULL, dod.received_date, ss.dateprocess) ReceivedDate,
	                        IF(ss.dateprocess IS NULL, dod.received_by, ss.status_by) ReceivedBy,
	                        IF(ss.dateprocess IS NULL, dod.received_note, ss.status_note) ReceivedNote,
	                        IF(ss.dateprocess IS NULL, dod.received_update, ss.dateprocess) ReceivedUpdate,
	                        IF(ss.dateprocess IS NOT NULL, 1, 0) Received,
	                        dod.createddate Createddate,
	                        dod.createdby Createdby,
	                        dod.modifieddate Modifieddate,
	                        dod.modifiedby Modifiedby,
	                        'SELECT' StateChange2
                        FROM delivery_order_detail dod
                        INNER JOIN delivery_order d ON dod.delivery_order_id = d.id
                        INNER JOIN branch b ON dod.branch_id = b.id
                        INNER JOIN package_type p ON dod.package_type_id = p.id
                        INNER JOIN payment_method pm ON dod.payment_method_id = pm.id
                        LEFT JOIN shipment_expand s ON dod.shipment_id = s.shipment_id
                        LEFT JOIN shipment_status ss ON ss.shipment_id = dod.shipment_id AND ss.tracking_status_id = 10 AND ss.rowstatus = 1
                        WHERE dod.rowstatus = 1 AND {0}
                        GROUP BY dod.shipment_id";

            for (var i = 0; i < ListClause.Count; i++) ListClause[i] = string.Format("d.{0}", ListClause[i]);
            var result = Entities.ExecuteStoreQuery<DeliveryOrderDetailModel>(string.Format(sql, string.Join(" AND ", ListClause))).ToList();
            return result;
            //var query = (from a in Entities.delivery_order select a).Where(whereterm, ListValue.ToArray()).AsQueryable();

            //if (query == null)
            //    throw new Exception(MessageEntityNotFound);

            //var x = EnumStateChange.Select.ToString();
            //var obj = (IEnumerable<DeliveryOrderDetailModel>)(from item in Entities.delivery_order_detail
            //            join q in query on item.delivery_order_id equals q.id
            //            join b in Entities.branches on item.branch_id equals b.id
            //            join p in Entities.package_type on item.package_type_id equals p.id
            //            join pm in Entities.payment_method on item.payment_method_id equals pm.id
            //            join s in Entities.shipment_expand on item.shipment_id equals s.shipment_id into sx
            //            from s in sx.DefaultIfEmpty()
            //            select new DeliveryOrderDetailModel
            //            {
            //                Id = item.id,
            //                Rowstatus = item.rowstatus,
            //                Rowversion = item.rowversion,
            //                DeliveryOrderId = q.id,
            //                DateProcess = item.date_process,
            //                DeliveryOrderCode = q.code,
            //                ShipmentId = item.shipment_id,
            //                ShipmentDate = item.shipment_date,
            //                ShipmentCode = item.shipment_code,
            //                BranchId = item.branch_id,
            //                Branch = b.code,
            //                DestCityId = item.dest_city_id,
            //                CustomerId = item.customer_id,
            //                CustomerName = item.customer_name,
            //                ShipperName = item.shipper_name,
            //                ConsigneeName = item.consignee_name,
            //                ServiceTypeId = item.service_type_id,
            //                PackageTypeId = item.package_type_id,
            //                PackageType = p.name,
            //                PaymentMethodId = item.payment_method_id,
            //                PaymentMethod = pm.name,
            //                TtlPiece = item.ttl_piece,
            //                TtlGrossWeight = item.ttl_gross_weight,
            //                TtlChargeableWeight = item.ttl_chargeable_weight,
            //                IsCod = item.is_cod == null ? false : item.is_cod,
            //                TotalCod = item.total_cod == null ? 0 : item.total_cod,
            //                Fulfilment = s != null ? s.fulfilment : string.Empty,
            //                ReceivedDate = item.received_date,
            //                ReceivedBy = item.received_by,
            //                ReceivedNote = item.received_note,
            //                ReceivedUpdate = item.received_update,
            //                Received = item.received,
            //                Createddate = item.createddate,
            //                Createdby = item.createdby,
            //                Modifieddate = item.modifieddate,
            //                Modifiedby = item.modifiedby,
            //                StateChange2 = x
            //            }).ToList();
            //return obj;
        }

        public IEnumerable<DeliveryOrderDetailModel> GetByShipmentIds(int[] shipmentIds)
        {
            var query = from a in Entities.delivery_order_detail
                         where shipmentIds.Contains(a.shipment_id)
                         select a;

            return query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<MissDeliveryReportModel> ReportMissDelivery(IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.delivery_order_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from a in query
                join b in Entities.branches on a.branch_id equals b.id
                join d in Entities.delivery_order on a.delivery_order_id equals d.id
                join e in Entities.employees on d.messenger_id equals e.id
                select new MissDeliveryReportModel
                {
                    shipment_code = a.shipment_code,
                    // ReSharper disable once PossibleInvalidOperationException
                    shipment_date = (DateTime) a.shipment_date,
                    shipper_name = a.shipper_name,
                    branch_name = b.name,
                    consignee_name = a.consignee_name,
                    received_note = a.received_note,
                    messenger_name = e.name
                }).ToList();
			return obj;
        }
    }
}