

/* 
*  SOLUTION 	: WaterManagementSolution
*  PROJECT		: Pdam.Common
*  TYPE 		: Generated - Data Access Repository
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

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
    public class ConsolidationDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "ConsolidationDetail";
        public ConsolidationDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ConsolidationDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ConsolidationDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToconsolidation_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ConsolidationDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.consolidation_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ConsolidationDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.consolidation_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.consolidation_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.consolidation_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static consolidation_detail PopulateModelToNewEntity(ConsolidationDetailModel model)
		{
			return new consolidation_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				consolidation_id = model.ConsolidationId,
				date_process = model.DateProcess,
				consolidation_code = model.ConsolidationCode,
				shipment_id = model.ShipmentId,
				shipment_date = model.ShipmentDate,
				shipment_code = model.ShipmentCode,
				consol_code = model.ConsolCode,
				branch_id = model.BranchId,
				dest_city_id = model.DestCityId,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				payment_method_id = model.PaymentMethodId,
				sales_type_id = model.SalesTypeId,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				waybill_id = model.WaybillId,
				waybill_code = model.WaybillCode,
				manifest_id = model.ManifestId,
				manifest_code = model.ManifestCode,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(consolidation_detail query, ConsolidationDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.consolidation_id = model.ConsolidationId;
			query.date_process = model.DateProcess;
			query.consolidation_code = model.ConsolidationCode;
			query.shipment_id = model.ShipmentId;
			query.shipment_date = model.ShipmentDate;
			query.shipment_code = model.ShipmentCode;
			query.consol_code = model.ConsolCode;
			query.branch_id = model.BranchId;
			query.dest_city_id = model.DestCityId;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
			query.payment_method_id = model.PaymentMethodId;
			query.sales_type_id = model.SalesTypeId;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.waybill_id = model.WaybillId;
			query.waybill_code = model.WaybillCode;
			query.manifest_id = model.ManifestId;
			query.manifest_code = model.ManifestCode;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        /*private static ConsolidationDetailModel PopulateEntityToNewModel(consolidation_detail item)
		{
			return new ConsolidationDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				ConsolidationId = item.consolidation_id,
				DateProcess = item.date_process,
				ConsolidationCode = item.consolidation_code,
				ShipmentId = item.shipment_id,
				ShipmentDate = item.shipment_date,
				ShipmentCode = item.shipment_code,
				ConsolCode = item.consol_code,
				BranchId = item.branch_id,
				DestCityId = item.dest_city_id,
				ServiceTypeId = item.service_type_id,
				PackageTypeId = item.package_type_id,
				PaymentMethodId = item.payment_method_id,
				SalesTypeId = item.sales_type_id,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
				WaybillId = item.waybill_id,
				WaybillCode = item.waybill_code,
				ManifestId = item.manifest_id,
				ManifestCode = item.manifest_code,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}*/
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.consolidation_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<T>)(from item in query
                                       join m in Entities.consolidations on item.consolidation_id equals m.id
                                       join py in Entities.payment_method on item.payment_method_id equals py.id into pm
                                       from p in pm.DefaultIfEmpty()
                                       join sy in Entities.shipments on item.shipment_id equals sy.id into sh
                                       from s in sh.DefaultIfEmpty()
                                       join ser in Entities.service_type on item.service_type_id equals ser.id into serv
                                       from sr in serv.DefaultIfEmpty()
                                       join d in Entities.cities on item.dest_city_id equals d.id
                                       join pc in Entities.package_type on item.package_type_id equals pc.id
                                       select new ConsolidationDetailModel
                                       {
                                           Id = item.id,
                                           Rowstatus = item.rowstatus,
                                           Rowversion = item.rowversion,
                                           ConsolidationId = item.consolidation_id,
                                           DestConsolidationBranch = m.dest_branch_id,
                                           DateProcess = item.date_process,
                                           ConsolidationCode = item.consolidation_code,
                                           Consignee = s.consignee_name,
                                           CustomerName = s.customer_name,
                                           ShipmentId = item.shipment_id,
                                           ShipmentDate = item.shipment_date,
                                           ShipmentCode = item.shipment_code,
                                           ConsolCode = item.consol_code,
                                           BranchId = item.branch_id,
                                           DestCityId = item.dest_city_id,
                                           DestCity = d.name,
                                           ServiceTypeId = item.service_type_id,
                                           ServiceType = sr.name,
                                           PackageTypeId = item.package_type_id,
                                           PackageType = pc.name,
                                           PaymentMethodId = item.payment_method_id,
                                           PaymentMethod = p.name,
                                           SalesTypeId = item.sales_type_id,
                                           TtlPiece = item.ttl_piece,
                                           TtlGrossWeight = item.ttl_gross_weight,
                                           TtlChargeableWeight = item.ttl_chargeable_weight,
                                           NatureGoods = s.nature_of_goods,
                                           WaybillId = item.waybill_id,
                                           WaybillCode = item.waybill_code,
                                           ManifestId = item.manifest_id,
                                           ManifestCode = item.manifest_code,
                                           Createddate = item.createddate,
                                           Createdby = item.createdby,
                                           Modifieddate = item.modifieddate,
                                           Modifiedby = item.modifiedby,
                                           StateChange2 = x
                                       }).ToList();
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);

            var sql = @"SELECT
                            cd.id Id,
                            cd.rowstatus Rowstatus,
                            cd.rowversion Rowversion,
                            cd.consolidation_id ConsolidationId,
                            c.dest_branch_id DestConsolidationBranch,
                            cd.date_process DateProcess ,
                            cd.consolidation_code ConsolidationCode,
                            s.customer_name CustomerName,
                            cd.shipment_id ShipmentId,
                            cd.shipment_date ShipmentDate,
                            cd.shipment_code ShipmentCode,
                            cd.consol_code ConsolCode,
                            cd.branch_id BranchId,
                            cd.dest_city_id DestCityId,
                            ci.name DestCity ,
                            cd.service_type_id ServiceTypeId,
                            st.name ServiceType,
                            cd.package_type_id PackageTypeId,
                            cd.payment_method_id PaymentMethodId,
                            pm.name PaymentMethod,
                            cd.sales_type_id SalesTypeId,
                            cd.ttl_piece TtlPiece,
                            cd.ttl_gross_weight TtlGrossWeight,
                            cd.ttl_chargeable_weight TtlChargeableWeight,
                            cd.waybill_id WaybillId ,
                            cd.waybill_code WaybillCode,
                            cd.manifest_id ManifestId,
                            cd.manifest_code ManifestCode,
                            cd.createddate CreatedDate,
                            cd.createdby CreatedBy ,
                            cd.modifieddate ModifiedDate,
                            cd.modifiedby ModifiedBy
                        FROM consolidation_detail cd
                        INNER JOIN consolidation c ON cd.consolidation_id = c.id AND c.rowstatus = 1
                        LEFT JOIN payment_method pm ON cd.payment_method_id = pm.id AND pm.rowstatus = 1
                        LEFT JOIN shipment s ON cd.shipment_id = s.id AND s.rowstatus = 1
                        LEFT JOIN service_type st ON cd.service_type_id = st.id AND  st.rowstatus = 1
                        INNER JOIN city ci ON cd.dest_city_id = ci.id AND ci.rowstatus = 1
                        WHERE cd.{0};";
             var executeSql = string.Format(sql, string.Join(" AND cd.", ListClause));

             return Entities.ExecuteStoreQuery<T>(executeSql).FirstOrDefault();

/*

			var query = (from a in Entities.consolidation_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

		    var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<T>)(from item in query
                       join m in (from m in Entities.consolidations where m.rowstatus.Equals(true) select m) on item.consolidation_id equals m.id
                       join py in (from py in Entities.payment_method where py.rowstatus.Equals(true) select py) on item.payment_method_id equals py.id into pm
                       from p in pm.DefaultIfEmpty()
                       join sy in (from sy in Entities.shipments where sy.rowstatus.Equals(true) select sy) on item.shipment_id equals sy.id into sh
                       from s in sh.DefaultIfEmpty()
                       join ser in (from ser in Entities.service_type where ser.rowstatus.Equals(true) select ser) on item.service_type_id equals ser.id into serv
                       from sr in serv.DefaultIfEmpty()
                       join d in (from d in Entities.cities where d.rowstatus.Equals(true) select d) on item.dest_city_id equals d.id
                       select new ConsolidationDetailModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           ConsolidationId = item.consolidation_id,
                           DestConsolidationBranch = m.dest_branch_id,
                           DateProcess = item.date_process,
                           ConsolidationCode = item.consolidation_code,
                           CustomerName = s.customer_name,
                           ShipmentId = item.shipment_id,
                           ShipmentDate = item.shipment_date,
                           ShipmentCode = item.shipment_code,
                           ConsolCode = item.consol_code,
                           BranchId = item.branch_id,
                           DestCityId = item.dest_city_id,
                           DestCity = d.name,
                           ServiceTypeId = item.service_type_id,
                           ServiceType = sr.name,
                           PackageTypeId = item.package_type_id,
                           PaymentMethodId = item.payment_method_id,
                           PaymentMethod = p.name,
                           SalesTypeId = item.sales_type_id,
                           TtlPiece = item.ttl_piece,
                           TtlGrossWeight = item.ttl_gross_weight,
                           TtlChargeableWeight = item.ttl_chargeable_weight,
                           WaybillId = item.waybill_id,
                           WaybillCode = item.waybill_code,
                           ManifestId = item.manifest_id,
                           ManifestCode = item.manifest_code,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           StateChange2 = x
                       }).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            //var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return obj.FirstOrDefault();
 */
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
		    var query = (from a in Entities.consolidation_detail select a).Where(whereterm, ListValue.ToArray()).ToList();//.OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

		    var x = EnumStateChange.Select.ToString();
            var obj = (from item in query
                       join m in
                           (from m in Entities.consolidations where m.rowstatus.Equals(true) select m) on item.consolidation_id equals m.id
                       join py in
                           (from py in Entities.payment_method where py.rowstatus.Equals(true) select py) on item.payment_method_id equals py.id into pm
                       from p in pm.DefaultIfEmpty()
                       join sy in
                           (from sy in Entities.shipments where sy.rowstatus.Equals(true) select sy) on item.shipment_id equals sy.id into sh
                       from s in sh.DefaultIfEmpty()
                       join ser in
                           (from ser in Entities.service_type where ser.rowstatus.Equals(true) select ser) on item.service_type_id equals ser.id into serv
                       from sr in serv.DefaultIfEmpty()
                       join d in
                           (from d in Entities.cities where d.rowstatus.Equals(true) select d) on item.dest_city_id equals d.id
                       join pc in Entities.package_type on item.package_type_id equals pc.id
                       select new ConsolidationDetailModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           ConsolidationId = item.consolidation_id,
                           DestConsolidationBranch = m.dest_branch_id,
                           DateProcess = item.date_process,
                           ConsolidationCode = item.consolidation_code,
                           CustomerName = s.customer_name,
                           ShipmentId = item.shipment_id,
                           ShipmentDate = item.shipment_date,
                           ShipmentCode = item.shipment_code,
                           ConsolCode = item.consol_code,
                           BranchId = item.branch_id,
                           DestCityId = item.dest_city_id,
                           DestCity = d.name,
                           ServiceTypeId = item.service_type_id,
                           ServiceType = sr.name,
                           PackageTypeId = item.package_type_id,
                           PackageType = pc.name,
                           PaymentMethodId = item.payment_method_id,
                           PaymentMethod = p.name,
                           SalesTypeId = item.sales_type_id,
                           TtlPiece = item.ttl_piece,
                           TtlGrossWeight = item.ttl_gross_weight,
                           TtlChargeableWeight = item.ttl_chargeable_weight,
                           WaybillId = item.waybill_id,
                           WaybillCode = item.waybill_code,
                           ManifestId = item.manifest_id,
                           ManifestCode = item.manifest_code,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           StateChange2 = x
                       });
            var tquery = (from a in Entities.consolidation_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) obj.ToList();
		}
    }
}


