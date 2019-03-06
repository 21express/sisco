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
    public class FranchiseAcceptanceRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "FranchiseAcceptance";
        public FranchiseAcceptanceRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseAcceptanceRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as FranchiseAcceptanceModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTofranchise_acceptance(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as FranchiseAcceptanceModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_acceptance where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseAcceptanceModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_acceptance select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.inbounds where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.inbounds where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static franchise_acceptance PopulateModelToNewEntity(FranchiseAcceptanceModel model)
        {
            return new franchise_acceptance
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                date_process = model.DateProcess,
                code = model.Code,
                branch_id = model.BranchId,
                franchise_pickup_id = model.FranchisePickupId,
                franchise_id = model.FranchiseId,
                franchise_pickup_code = model.FranchisePickupCode,
                ttl_piece = model.TtlPiece,
                ttl_gross_weight = model.TtlGrossWeight,
                ttl_chargeable_weight = model.TtlChargeableWeight,
                createddate = model.Createddate,
                createdby = model.Createdby,
                createdpc = model.CreatedPc,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
            };
        }

        private static void PopulateModelToNewEntity(franchise_acceptance query, FranchiseAcceptanceModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.code = model.Code;
            query.branch_id = model.BranchId;
            query.franchise_pickup_id = model.FranchisePickupId;
            query.franchise_id = model.FranchiseId;
            query.franchise_pickup_code = model.FranchisePickupCode;
            query.ttl_piece = model.TtlPiece;
            query.ttl_gross_weight = model.TtlGrossWeight;
            query.ttl_chargeable_weight = model.TtlChargeableWeight;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
        }

        private static FranchiseAcceptanceModel PopulateEntityToNewModel(franchise_acceptance item)
        {
            return new FranchiseAcceptanceModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                DateProcess = item.date_process,
                Code = item.code,
                BranchId = item.branch_id,
                FranchisePickupId = item.franchise_pickup_id,
                FranchiseId = item.franchise_id,
                FranchisePickupCode = item.franchise_pickup_code,
                TtlPiece = item.ttl_piece,
                TtlGrossWeight = item.ttl_gross_weight,
                TtlChargeableWeight = item.ttl_chargeable_weight,
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
            var query = (from a in Entities.franchise_acceptance select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_acceptance select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_acceptance select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_acceptance select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}
