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
    public class TrackingStatusRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "TrackingStatus";
        public TrackingStatusRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public TrackingStatusRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as TrackingStatusModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTotracking_status(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as TrackingStatusModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.tracking_status where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as TrackingStatusModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.tracking_status select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.tracking_status where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.tracking_status where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static tracking_status PopulateModelToNewEntity(TrackingStatusModel model)
        {
            return new tracking_status
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                code = model.Code,
                is_final_status = model.IsFinalStatus,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(tracking_status query, TrackingStatusModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.code = model.Code;
            query.is_final_status = model.IsFinalStatus;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static TrackingStatusModel PopulateEntityToNewModel(tracking_status item)
        {
            return new TrackingStatusModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                Code = item.code,
                IsFinalStatus = item.is_final_status,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.tracking_status select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.tracking_status select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.tracking_status select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.tracking_status select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void SaveList(IList<TrackingStatusModel> list, IList<TrackingStatusModel> deletedList, string actor)
        {
            var existingIds = from o in list where o.Id != 0 select o.Id;
            var fromDatabase = from o in Entities.tracking_status
                               where existingIds.Contains(o.id) && o.rowstatus
                               select o;
            foreach (var entity in fromDatabase)
            {
                PopulateModelToNewEntity(entity, list.First(row => row.Id == entity.id));
            }

            foreach (var model in list.Where(row => row.Id == 0))
            {
                var entity = PopulateModelToNewEntity(model);
                Entities.AddTotracking_status(entity);
            }

            var deletedIds = from o in deletedList where o.Id != 0 select o.Id;
            var toBeDeleted = from o in Entities.tracking_status
                              where deletedIds.Contains(o.id) && o.rowstatus
                              select o;
            foreach (var entity in toBeDeleted)
            {
                entity.rowstatus = false;
                entity.rowversion = DateTime.Now;
                entity.modifiedby = actor;
                entity.modifieddate = DateTime.Now;
            }

            Entities.SaveChanges();
        }       
    }
}