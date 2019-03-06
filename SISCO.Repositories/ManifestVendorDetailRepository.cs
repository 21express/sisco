using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace SISCO.Repositories
{
    public class ManifestVendorDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Manifest Vendor Detail";
        public ManifestVendorDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ManifestVendorDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ManifestVendorDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTomanifest_vendor_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ManifestVendorDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.manifest_vendor_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ManifestVendorDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.manifest_vendor_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.manifest_vendor_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.manifest_vendor_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static manifest_vendor_detail PopulateModelToNewEntity(ManifestVendorDetailModel model)
		{
            return new manifest_vendor_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                manifest_vendor_id = model.ManifestVendorId,
                shipment_id = model.ShipmentId,
                shipment_date = model.ShipmentDate,
                shipment_code = model.ShipmentCode,
                branch_id = model.BranchId,
                dest_city_id = model.DestCityId,
                shipper_name = model.ShipperName,
                consignee_name = model.ConsigneeName,
                service_type_id = model.ServiceTypeId,
                package_type_id = model.PackageTypeId,
                payment_method_id = model.PaymentMethodId,
                sales_type_id = model.SalesTypeId,
                ttl_piece = model.TtlPiece,
                ttl_gross_weight = model.TtlGrossWeight,
                ttl_chargeable_weight = model.TtlChargeableWeight,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(manifest_vendor_detail query, ManifestVendorDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.manifest_vendor_id = model.ManifestVendorId;
            query.shipment_id = model.ShipmentId;
            query.shipment_date = model.ShipmentDate;
            query.shipment_code = model.ShipmentCode;
            query.branch_id = model.BranchId;
            query.dest_city_id = model.DestCityId;
            query.shipper_name = model.ShipperName;
            query.consignee_name = model.ConsigneeName;
            query.service_type_id = model.ServiceTypeId;
            query.package_type_id = model.PackageTypeId;
            query.payment_method_id = model.PaymentMethodId;
            query.sales_type_id = model.SalesTypeId;
            query.ttl_piece = model.TtlPiece;
            query.ttl_gross_weight = model.TtlGrossWeight;
            query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static ManifestVendorDetailModel PopulateEntityToNewModel(manifest_vendor_detail item)
		{
			return new ManifestVendorDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                ManifestVendorId = item.manifest_vendor_id,
                ShipmentId = item.shipment_id,
                ShipmentDate = item.shipment_date,
                ShipmentCode = item.shipment_code,
                BranchId = item.branch_id,
                DestCityId = item.dest_city_id,
                ShipperName = item.shipper_name,
                ConsigneeName = item.consignee_name,
                ServiceTypeId = item.service_type_id,
                PackageTypeId = item.package_type_id,
                PaymentMethodId = item.payment_method_id,
                SalesTypeId = item.sales_type_id,
                TtlPiece = item.ttl_piece,
                TtlGrossWeight = item.ttl_gross_weight,
                TtlChargeableWeight = item.ttl_chargeable_weight,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.manifest_vendor_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<T>)(from item in query
                                       join m in
                                           (from m in Entities.manifest_vendor where m.rowstatus.Equals(true) select m) on item.manifest_vendor_id equals m.id
                                       join c in
                                           (from c in Entities.cities where c.rowstatus.Equals(true) select c) on item.dest_city_id equals c.id
                                       join pm in
                                           (from pm in Entities.payment_method where pm.rowstatus.Equals(true) select pm) on item.payment_method_id equals pm.id into pmtemp
                                       from p in pmtemp.DefaultIfEmpty()
                                       join st in
                                           (from st in Entities.service_type where st.rowstatus.Equals(true) select st) on item.service_type_id equals st.id into sv
                                       from s in sv.DefaultIfEmpty()
                                       join pt in
                                           (from pt in Entities.package_type where pt.rowstatus.Equals(true) select pt) on item.package_type_id equals pt.id into pc
                                       from p2 in pc.DefaultIfEmpty()
                                       select new ManifestVendorDetailModel
                                       {
                                           Id = item.id,
                                           Rowstatus = item.rowstatus,
                                           Rowversion = item.rowversion,
                                           ManifestVendorId = item.manifest_vendor_id,
                                           ShipmentId = item.shipment_id,
                                           ShipmentDate = item.shipment_date,
                                           ShipmentCode = item.shipment_code,
                                           BranchId = item.branch_id,
                                           DestCityId = item.dest_city_id,
                                           DestCity = c.name,
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
                                           Createddate = item.createddate,
                                           Createdby = item.createdby,
                                           Modifieddate = item.modifieddate,
                                           Modifiedby = item.modifiedby,
                                           StateChange2 = x
                                       });

            return obj.ToList();
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.manifest_vendor_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.manifest_vendor_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.manifest_vendor_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.manifest_vendor_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.manifest_vendor_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}