using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class ManifestDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "ManifestDetail";
        public ManifestDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ManifestDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ManifestDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTomanifest_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ManifestDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.manifest_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ManifestDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.manifest_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.manifest_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.manifest_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static manifest_detail PopulateModelToNewEntity(ManifestDetailModel model)
		{
			return new manifest_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				manifest_id = model.ManifestId,
                consolidation_code = model.ConsolidationCode,
				date_process = model.DateProcess,
				manifest_code = model.ManifestCode,
				shipment_id = model.ShipmentId,
				shipment_date = model.ShipmentDate,
				shipment_code = model.ShipmentCode,
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
				manifested = model.Manifested,
                total_cod = model.TotalCod,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(manifest_detail query, ManifestDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.manifest_id = model.ManifestId;
			query.date_process = model.DateProcess;
			query.manifest_code = model.ManifestCode;
            query.consolidation_code = model.ConsolidationCode;
			query.shipment_id = model.ShipmentId;
			query.shipment_date = model.ShipmentDate;
			query.shipment_code = model.ShipmentCode;
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
			query.manifested = model.Manifested;
            query.total_cod = model.TotalCod;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static ManifestDetailModel PopulateEntityToNewModel(manifest_detail item)
		{
			return new ManifestDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				ManifestId = item.manifest_id,
				DateProcess = item.date_process,
				ManifestCode = item.manifest_code,
                ConsolidationCode = item.consolidation_code,
				ShipmentId = item.shipment_id,
				ShipmentDate = item.shipment_date,
				ShipmentCode = item.shipment_code,
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
				Manifested = item.manifested,
                TotalCod = item.total_cod,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}

        public IEnumerable<ManifestDetailModel> GetDetail(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.manifest_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return query.Select(PopulateEntityToNewModel).ToList();
        }
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.manifest_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<T>)(from item in query
                join m in (from m in Entities.manifests where m.rowstatus.Equals(true) select m) on item.manifest_id equals m.id
                join c in (from c in Entities.cities where c.rowstatus.Equals(true) select c) on item.dest_city_id equals c.id
                join pm in (from pm in Entities.payment_method where pm.rowstatus.Equals(true) select pm) on item.payment_method_id equals pm.id into pmtemp
                from p in pmtemp.DefaultIfEmpty()
                join st in (from st in Entities.service_type where st.rowstatus.Equals(true) select st) on item.service_type_id equals st.id into sv
                from s in sv.DefaultIfEmpty()
                join pt in (from pt in Entities.package_type where pt.rowstatus.Equals(true) select pt) on item.package_type_id equals pt.id into pc
                from p2 in pc.DefaultIfEmpty()
                select new ManifestDetailModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    ManifestId = item.manifest_id,
                    OrigBranchId = m.branch_id,
                    DestBranchId = m.dest_branch_id,
                    DateProcess = item.date_process,
                    ManifestCode = item.manifest_code,
                    ConsolidationCode = item.consolidation_code,
                    ShipmentId = item.shipment_id,
                    ShipmentDate = item.shipment_date,
                    ShipmentCode = item.shipment_code,
                    ConsolCode = item.consol_code,
                    BranchId = item.branch_id,
                    DestCityId = item.dest_city_id,
                    DestCity = c.name,
                    CustomerId = item.customer_id,
                    CustomerName = item.customer_name,
                    ShipperName = item.shipper_name,
                    ConsigneeName = item.consignee_name,
                    ServiceTypeId = item.service_type_id,
                    ServiceType = s.name,
                    PackageTypeId = item.package_type_id,
                    PackageType = p2.name,
                    PaymentMethodId = item.payment_method_id,
                    PaymentMethod = p.name,
                    SalesTypeId = item.sales_type_id,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    TtlChargeableWeight = item.ttl_chargeable_weight,
                    Manifested = item.manifested,
                    TotalCod = item.total_cod,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    StateChange2 = x
                });
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.manifest_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.manifest_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.manifest_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<ManifestDetailModel> GetInbound(int destbranchid, string shipmentcode)
        {
            var obj = (from d in Entities.manifest_detail
                       join m in Entities.manifests on d.manifest_id equals m.id
                       where m.rowstatus.Equals(true) && m.dest_branch_id == destbranchid && d.rowstatus.Equals(true) && d.shipment_code == shipmentcode
                       select d).AsQueryable();

            if (!obj.Any())
            {
                obj = (from d in Entities.manifest_detail
                       join m in Entities.manifests on d.manifest_id equals m.id
                       where m.rowstatus.Equals(true) && m.dest_branch_id == destbranchid && d.rowstatus.Equals(true) && d.consol_code == shipmentcode
                       select d).AsQueryable();

                if (!obj.Any()) return new List<ManifestDetailModel>();
            }

            var x = EnumStateChange.Insert.ToString();
            var result = (from d in Entities.manifest_detail
                          join c in Entities.cities on d.dest_city_id equals c.id
                where d.rowstatus.Equals(true) && d.manifest_id == obj.FirstOrDefault().manifest_id
                          select new ManifestDetailModel
                          {
                              Id = d.id,
                              Rowstatus = d.rowstatus,
                              Rowversion = d.rowversion,
                              ManifestId = d.manifest_id,
                              DateProcess = d.date_process,
                              ManifestCode = d.manifest_code,
                              ConsolidationCode = d.consolidation_code,
                              ShipmentId = d.shipment_id,
                              ShipmentDate = d.shipment_date,
                              ShipmentCode = d.shipment_code,
                              ConsolCode = d.consol_code,
                              BranchId = d.branch_id,
                              DestCityId = d.dest_city_id,
                              DestCity = c.name,
                              CustomerId = d.customer_id,
                              CustomerName = d.customer_name,
                              ShipperName = d.shipper_name,
                              ConsigneeName = d.consignee_name,
                              ServiceTypeId = d.service_type_id,
                              PackageTypeId = d.package_type_id,
                              PaymentMethodId = d.payment_method_id,
                              SalesTypeId = d.sales_type_id,
                              TtlPiece = d.ttl_piece,
                              TtlGrossWeight = d.ttl_gross_weight,
                              TtlChargeableWeight = d.ttl_chargeable_weight,
                              Manifested = d.manifested,
                              TotalCod = d.total_cod,
                              Createddate = d.createddate,
                              Createdby = d.createdby,
                              Modifieddate = d.modifieddate,
                              Modifiedby = d.modifiedby,
                              StateChange2 = x
                          }).AsQueryable();

            return result.ToList();
        }

        public List<ManifestDetailTemp> IsManifested(List<string> shipmentCodes)
        {
            var sql = @"SELECT
                            md.id Id,
	                        m.date_process DateProcess,
                            md.consol_code ConsolCode,
                            m.dest_branch_id DestBranchId,
                            md.shipment_code ShipmentCode,
                            md.service_type_id ServiceTypeId,
                            md.package_type_id PackageTypeId,
                            md.payment_method_id PaymentMethodId
                        FROM manifest_detail md
                        INNER JOIN manifest m ON md.manifest_id = m.id AND m.rowstatus = 1
                        WHERE 
                            md.rowstatus = 1 AND
	                        md.shipment_code IN ('{0}')
                        ORDER BY m.date_process DESC";

            sql = string.Format(sql, string.Join("', '", shipmentCodes));
            return Entities.ExecuteStoreQuery<ManifestDetailTemp>(sql).ToList();
        }

        public bool IsConsolExists(string consolCode)
        {
            var sql = @"select
	                        m.id Id
                        from manifest_detail md 
                        inner join manifest m on md.manifest_id = m.id and m.rowstatus = 1
                        where md.rowstatus = 1 and md.consol_code = @consol";
            var result = Entities.ExecuteStoreQuery<ManifestModel>(sql, new MySqlParameter("consol", consolCode)).FirstOrDefault();
            return result != null;
        }
    }
}