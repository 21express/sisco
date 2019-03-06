

/* 
*  SOLUTION 	: WaterManagementSolution
*  PROJECT		: Pdam.Common
*  TYPE 		: Generated - Data Access Repository
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class WaybillDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "WaybillDetail";
        public WaybillDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public WaybillDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as WaybillDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTowaybill_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as WaybillDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.waybill_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as WaybillDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.waybill_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.waybill_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.waybill_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static waybill_detail PopulateModelToNewEntity(WaybillDetailModel model)
        {
            Debug.Assert(model.ShipmentDate != null, "model.ShipmentDate != null");
            return new waybill_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				waybill_id = model.WaybillId,
				date_process = model.DateProcess,
				waybill_code = model.WaybillCode,
				shipment_id = model.ShipmentId,
				shipment_date = (DateTime) model.ShipmentDate,
				shipment_code = model.ShipmentCode,
                consolidation_code = model.ConsolidationCode,
				consol_code = model.ConsolCode,
				branch_id = model.BranchId,
				dest_city_id = model.DestCityId,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				shipper_name = model.ShipperName,
				consignee_name = model.ConsigneeName,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				payment_method_id = model.PaymentMethodId,
				sales_type_id = model.SalesTypeId,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				manifest_id = model.ManifestId,
				manifest_code = model.ManifestCode,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
        }

        private static void PopulateModelToNewEntity(waybill_detail query, WaybillDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.waybill_id = model.WaybillId;
			query.date_process = model.DateProcess;
			query.waybill_code = model.WaybillCode;
			query.shipment_id = model.ShipmentId;
            Debug.Assert(model.ShipmentDate != null, "model.ShipmentDate != null");
            query.shipment_date = (DateTime) model.ShipmentDate;
			query.shipment_code = model.ShipmentCode;
            query.consolidation_code = model.ConsolidationCode;
			query.consol_code = model.ConsolCode;
			query.branch_id = model.BranchId;
			query.dest_city_id = model.DestCityId;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.shipper_name = model.ShipperName;
			query.consignee_name = model.ConsigneeName;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
			query.payment_method_id = model.PaymentMethodId;
			query.sales_type_id = model.SalesTypeId;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.manifest_id = model.ManifestId;
			query.manifest_code = model.ManifestCode;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static WaybillDetailModel PopulateEntityToNewModel(waybill_detail item)
		{
			return new WaybillDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				WaybillId = item.waybill_id,
				DateProcess = item.date_process,
				WaybillCode = item.waybill_code,
				ShipmentId = item.shipment_id,
				ShipmentDate = item.shipment_date,
				ShipmentCode = item.shipment_code,
                ConsolidationCode = item.consolidation_code,
				ConsolCode = item.consol_code,
				BranchId = item.branch_id,
				DestCityId = item.dest_city_id,
				CustomerId = item.customer_id,
				CustomerName = item.customer_name,
				ShipperName = item.shipper_name,
				ConsigneeName = item.consignee_name,
				ServiceTypeId = item.service_type_id,
				PackageTypeId = item.package_type_id,
				PaymentMethodId = item.payment_method_id,
				SalesTypeId = item.sales_type_id,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
				ManifestId = item.manifest_id,
				ManifestCode = item.manifest_code,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            
            var query = (from a in Entities.waybill_detail select a)
                .Where(whereterm, ListValue.ToArray()).AsQueryable();

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<T>) (from item in query
                join m in Entities.waybills on item.waybill_id equals m.id
                join c in Entities.cities on item.dest_city_id equals c.id into cx
                from c in cx.DefaultIfEmpty()
                select new WaybillDetailModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    WaybillId = item.waybill_id,
                    OrigBranchIdAirwaybill = m.branch_id,
                    DestBranchIdAirwaybill = m.dest_branch_id,
                    DateProcess = item.date_process,
                    WaybillCode = item.waybill_code,
                    ShipmentId = item.shipment_id,
                    ShipmentDate = item.shipment_date,
                    ShipmentCode = item.shipment_code,
                    ConsolidationCode = item.consolidation_code,
                    ConsolCode = item.consol_code,
                    BranchId = item.branch_id,
                    DestCityId = item.dest_city_id,
                    DestCity = c != null ? c.name : "",
                    CustomerId = item.customer_id,
                    CustomerName = item.customer_name,
                    ShipperName = item.shipper_name,
                    ConsigneeName = item.consignee_name,
                    ServiceTypeId = item.service_type_id,
                    PackageTypeId = item.package_type_id,
                    PaymentMethodId = item.payment_method_id,
                    SalesTypeId = item.sales_type_id,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    TtlChargeableWeight = item.ttl_chargeable_weight,
                    ManifestId = item.manifest_id,
                    ManifestCode = item.manifest_code,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    StateChange2 = x
                });
            //return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return obj.OrderBy("Id ASC").ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.waybill_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.waybill_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.waybill_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}      
    }
}