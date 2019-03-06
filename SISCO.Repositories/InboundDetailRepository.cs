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
    public class InboundDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "InboundDetail";
        public InboundDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public InboundDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as InboundDetailModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddToinbound_detail(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as InboundDetailModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.inbound_detail where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as InboundDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.inbound_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.inbound_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.inbound_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static inbound_detail PopulateModelToNewEntity(InboundDetailModel model)
        {
            return new inbound_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                inbound_id = model.InboundId,
                inbound_code = model.InboundCode,
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
                ttl_piece = model.TtlPiece,
                ttl_gross_weight = model.TtlGrossWeight,
                ttl_chargeable_weight = model.TtlChargeableWeight,
                manifest_id = model.ManifestId,
                manifest_code = model.ManifestCode,
                inbound_status_id = model.InboundStatusId,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(inbound_detail query, InboundDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.inbound_id = model.InboundId;
            query.inbound_code = model.InboundCode;
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
            query.ttl_piece = model.TtlPiece;
            query.ttl_gross_weight = model.TtlGrossWeight;
            query.ttl_chargeable_weight = model.TtlChargeableWeight;
            query.manifest_id = model.ManifestId;
            query.manifest_code = model.ManifestCode;
            query.inbound_status_id = model.InboundStatusId;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static InboundDetailModel PopulateEntityToNewModel(inbound_detail item)
        {
            Debug.Assert(item.branch_id != null, "item.branch_id != null");
            Debug.Assert(item.dest_city_id != null, "item.dest_city_id != null");
            Debug.Assert(item.ttl_piece != null, "item.ttl_piece != null");
            Debug.Assert(item.ttl_chargeable_weight != null, "item.ttl_chargeable_weight != null");
            Debug.Assert(item.manifest_id != null, "item.manifest_id != null");
            Debug.Assert(item.ttl_gross_weight != null, "item.ttl_gross_weight != null");
            return new InboundDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                InboundId = item.inbound_id,
                InboundCode = item.inbound_code,
                ShipmentId = item.shipment_id,
                ShipmentDate = item.shipment_date,
                ShipmentCode = item.shipment_code,
                ConsolCode = item.consol_code,
                BranchId = (int) item.branch_id,
                DestCityId = (int) item.dest_city_id,
                CustomerId = item.customer_id,
                CustomerName = item.customer_name,
                ShipperName = item.shipper_name,
                ConsigneeName = item.consignee_name,
                ServiceTypeId = item.service_type_id,
                PackageTypeId = item.package_type_id,
                PaymentMethodId = item.payment_method_id,
                TtlPiece = (sbyte) item.ttl_piece,
                TtlGrossWeight = (decimal) item.ttl_gross_weight,
                TtlChargeableWeight = (decimal) item.ttl_chargeable_weight,
                ManifestId = (int) item.manifest_id,
                ManifestCode = item.manifest_code,
                InboundStatusId = item.inbound_status_id,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,

            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.inbound_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (from item in query
                join c in Entities.cities on item.dest_city_id equals c.id into ci
                from c in ci.DefaultIfEmpty()
                select new InboundDetailModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    InboundId = item.inbound_id,
                    InboundCode = item.inbound_code,
                    ShipmentId = item.shipment_id,
                    ShipmentDate = item.shipment_date,
                    ShipmentCode = item.shipment_code,
                    ConsolCode = item.consol_code,
                    BranchId = (int) item.branch_id,
                    DestCityId = (int) item.dest_city_id,
                    DestCity = c.name,
                    CustomerId = item.customer_id,
                    CustomerName = item.customer_name,
                    ShipperName = item.shipper_name,
                    ConsigneeName = item.consignee_name,
                    ServiceTypeId = item.service_type_id,
                    PackageTypeId = item.package_type_id,
                    PaymentMethodId = item.payment_method_id,
                    TtlPiece = (sbyte) item.ttl_piece,
                    TtlGrossWeight = (decimal) item.ttl_gross_weight,
                    TtlChargeableWeight = (decimal) item.ttl_chargeable_weight,
                    ManifestId = (int) item.manifest_id,
                    ManifestCode = item.manifest_code,
                    InboundStatusId = item.inbound_status_id,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    StateChange2 = x
                });
            //return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return (IEnumerable<T>)obj.ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.inbound_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.inbound_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.inbound_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

    }
}