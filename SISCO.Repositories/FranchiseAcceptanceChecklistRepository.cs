using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using System.Linq;
using System.Linq.Dynamic;

namespace SISCO.Repositories
{
    public class FranchiseAcceptanceChecklistRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "FranchiseAcceptanceChecklist";
        public FranchiseAcceptanceChecklistRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseAcceptanceChecklistRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as FranchiseAcceptanceChecklistModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTofranchise_acceptance_checklist(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as FranchiseAcceptanceChecklistModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_acceptance_checklist where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseAcceptanceChecklistModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_acceptance_checklist select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_acceptance_checklist where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.franchise_acceptance_checklist where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static franchise_acceptance_checklist PopulateModelToNewEntity(FranchiseAcceptanceChecklistModel model)
        {
            return new franchise_acceptance_checklist
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                franchise_acceptance_id = model.FranchiseAcceptanceId,
                shipment_id = model.ShipmentId,
                shipment_date = model.ShipmentDate,
                shipment_code = model.ShipmentCode,
                service_type_id = model.ServiceTypeId,
                package_type_id = model.PackageTypeId,
                payment_method_id = model.PaymentMethodId,
                ttl_piece = model.TtlPiece,
                ttl_gross_weight = model.TtlGrossWeight,
                ttl_chargeable_weight = model.TtlChargeableWeight,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(franchise_acceptance_checklist query, FranchiseAcceptanceChecklistModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.franchise_acceptance_id = model.FranchiseAcceptanceId;
            query.shipment_id = model.ShipmentId;
            query.shipment_date = model.ShipmentDate;
            query.shipment_code = model.ShipmentCode;
            query.service_type_id = model.ServiceTypeId;
            query.package_type_id = model.PackageTypeId;
            query.payment_method_id = model.PaymentMethodId;
            query.ttl_piece = model.TtlPiece;
            query.ttl_gross_weight = model.TtlGrossWeight;
            query.ttl_chargeable_weight = model.TtlChargeableWeight;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static FranchiseAcceptanceChecklistModel PopulateEntityToNewModel(franchise_acceptance_checklist item)
        {
            return new FranchiseAcceptanceChecklistModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                FranchiseAcceptanceId = item.franchise_acceptance_id,
                ShipmentId = item.shipment_id,
                ShipmentDate = item.shipment_date,
                ShipmentCode = item.shipment_code,
                ServiceTypeId = item.service_type_id,
                PackageTypeId = item.package_type_id,
                PaymentMethodId = item.payment_method_id,
                TtlPiece = item.ttl_piece,
                TtlGrossWeight = item.ttl_gross_weight,
                TtlChargeableWeight = item.ttl_chargeable_weight,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_acceptance_checklist select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_acceptance_checklist select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_acceptance_checklist select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_acceptance_checklist select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}
