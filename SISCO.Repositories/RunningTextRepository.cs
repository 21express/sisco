

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
    public class RunningTextRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "RunningText";
        public RunningTextRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public RunningTextRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as RunningTextModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTorunning_text(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as RunningTextModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.running_text where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as RunningTextModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.running_text select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.running_text where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.running_text where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static running_text PopulateModelToNewEntity(RunningTextModel model)
        {
            return new running_text
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                name = model.Name,
                from_date = model.FromDate,
                from_hour = model.FromHour,
                from_minute = model.FromMinute,
                to_date = model.ToDate,
                to_hour = model.ToHour,
                to_minute = model.ToMinute,
                user_id = model.UserId,
                role_id = model.RoleId,
                announcement_type = model.AnnouncementType,
                franchise_id = model.FranchiseId,
                corporate_id = model.CorporateId,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(running_text query, RunningTextModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.name = model.Name;
            query.from_date = model.FromDate;
            query.from_hour = model.FromHour;
            query.from_minute = model.FromMinute;
            query.to_date = model.ToDate;
            query.to_hour = model.ToHour;
            query.to_minute = model.ToMinute;
            query.user_id = model.UserId;
            query.role_id = model.RoleId;
            query.announcement_type = model.AnnouncementType;
            query.franchise_id = model.FranchiseId;
            query.corporate_id = model.CorporateId;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static RunningTextModel PopulateEntityToNewModel(running_text item)
        {
            return new RunningTextModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                Name = item.name,
                FromDate = item.from_date,
                FromHour = item.from_hour,
                FromMinute = item.from_minute,
                ToDate = item.to_date,
                ToHour = item.to_hour,
                ToMinute = item.to_minute,
                UserId = item.user_id,
                RoleId = item.role_id,
                AnnouncementType = item.announcement_type,
                FranchiseId = item.franchise_id,
                CorporateId = item.corporate_id,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.running_text select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.running_text select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.running_text select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.running_text select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).Cast<RunningTextModel>().ToList();
        }

        public IEnumerable<T> GetByBranchIdAndDepartmentIdAndUserId<T>(int branchId, int departmentId, int userId)
        {
            var now = DateTime.Now;
            var query = (from a in Entities.running_text
                         where a.rowstatus && (a.user_id != null || a.user_id == userId || a.role_id != null || a.role_id == departmentId)
                         && a.from_date <= now.Date && a.to_date >= now.Date
                         && a.from_hour <= now.Hour && a.to_hour >= now.Hour
                         //&& a.from_minute <= now.Minute && a.to_minute >= now.Minute
                         select a);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<RunningTextModel> GetRunningText(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.running_text select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            
            var tquery = (from q in query
                          join f in Entities.franchises on q.franchise_id equals f.id into fm
                          from f in fm.DefaultIfEmpty()
                          join c in Entities.customers on q.corporate_id equals c.id into cm
                          from c in cm.DefaultIfEmpty()
                          select new RunningTextModel
                          {
                              Id = q.id,
                              Rowstatus = q.rowstatus,
                              Rowversion = q.rowversion,
                              Name = q.name,
                              FromDate = q.from_date,
                              FromHour = q.from_hour,
                              FromMinute = q.from_minute,
                              ToDate = q.to_date,
                              ToHour = q.to_hour,
                              ToMinute = q.to_minute,
                              UserId = q.user_id,
                              RoleId = q.role_id,
                              AnnouncementType = q.announcement_type,
                              FranchiseId = q.franchise_id,
                              FranchiseName = f != null ? f.name : "",
                              CorporateId = q.corporate_id,
                              CorporateName = c != null ? c.name : "",
                              Createddate = q.createddate,
                              Createdby = q.createdby,
                              Modifieddate = q.modifieddate,
                              Modifiedby = q.modifiedby
                          }).ToList();
            return tquery;
        }
    }
}


