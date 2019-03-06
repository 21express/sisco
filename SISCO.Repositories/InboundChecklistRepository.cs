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
    public class InboundChecklistRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "InboundChecklist";
        public InboundChecklistRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public InboundChecklistRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as InboundChecklistModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddToinbound_checklist(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as InboundChecklistModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.inbound_checklist where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as InboundChecklistModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.inbound_checklist select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.inbound_checklist where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.inbound_checklist where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static inbound_checklist PopulateModelToNewEntity(InboundChecklistModel model)
        {
            return new inbound_checklist
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                inbound_id = model.InboundId,
                shipment_id = model.ShipmentId,
                shipment_date = model.ShipmentDate,
                shipment_code = model.ShipmentCode,
                consol_code = model.ConsolCode,
                branch_id = model.BranchId,
                dest_city_id = model.DestCityId,
                dest_city = model.DestCity,
                company_id = model.CustomerId,
                company_name = model.CustomerName,
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
                modifiedby = model.Modifiedby
            };
        }

        private static void PopulateModelToNewEntity(inbound_checklist query, InboundChecklistModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.inbound_id = model.InboundId;
            query.shipment_id = model.ShipmentId;
            query.shipment_date = model.ShipmentDate;
            query.shipment_code = model.ShipmentCode;
            query.consol_code = model.ConsolCode;
            query.branch_id = model.BranchId;
            query.dest_city_id = model.DestCityId;
            query.dest_city = model.DestCity;
            query.company_id = model.CustomerId;
            query.company_name = model.CustomerName;
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

        private static InboundChecklistModel PopulateEntityToNewModel(inbound_checklist item)
        {
            var x = EnumStateChange.Select.ToString();
            return new InboundChecklistModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                InboundId = item.inbound_id,
                ShipmentId = item.shipment_id,
                ShipmentDate = item.shipment_date,
                ShipmentCode = item.shipment_code,
                ConsolCode = item.consol_code,
                BranchId = item.branch_id,
                DestCityId = item.dest_city_id,
                DestCity = item.dest_city,
                CustomerId = item.company_id,
                CustomerName = item.company_name,
                ShipperName = item.shipper_name,
                ConsigneeName = item.consignee_name,
                ServiceTypeId = item.service_type_id,
                PackageTypeId = item.package_type_id,
                PaymentMethodId = item.payment_method_id,
                SalesTypeId = item.sales_type_id,
                TtlPiece = (short) (item.ttl_piece != null ? (short) item.ttl_piece : 0),
                TtlGrossWeight = item.ttl_gross_weight ?? 0,
                TtlChargeableWeight = item.ttl_chargeable_weight ?? 0,
                ManifestId = item.manifest_id,
                ManifestCode = item.manifest_code,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
                StateChange2 = x
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.inbound_checklist select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.inbound_checklist select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.inbound_checklist select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.inbound_checklist select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}