

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
using System.Transactions;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class ComplaintFollowUpRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "ComplaintFollowUp";
        public ComplaintFollowUpRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ComplaintFollowUpRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ComplaintFollowUpModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocomplaint_follow_up(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ComplaintFollowUpModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.complaint_follow_up where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ComplaintFollowUpModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.complaint_follow_up select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.complaint_follow_up where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.complaint_follow_up where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static complaint_follow_up PopulateModelToNewEntity(ComplaintFollowUpModel model)
		{
			return new complaint_follow_up
			{
				id = model.Id,
				complaint_id = model.ComplaintId,
				vdate = model.Vdate,
				branch_id = model.BranchId,
				employee_id = model.EmployeeId,
				note = model.Note,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(complaint_follow_up query, ComplaintFollowUpModel model)
		{
			query.id = model.Id;
			query.complaint_id = model.ComplaintId;
			query.vdate = model.Vdate;
			query.branch_id = model.BranchId;
			query.employee_id = model.EmployeeId;
			query.note = model.Note;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static ComplaintFollowUpModel PopulateEntityToNewModel(complaint_follow_up item)
		{
			return new ComplaintFollowUpModel
			{
				Id = item.id,
				ComplaintId = item.complaint_id,
				Vdate = item.vdate,
				BranchId = item.branch_id,
				EmployeeId = item.employee_id,
				Note = item.note,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.complaint_follow_up orderby a.createddate ascending select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.complaint_follow_up select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.complaint_follow_up select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.complaint_follow_up select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public void Save<T>(ComplaintModel parent, IList<T> models)
        {
            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM complaint_follow_up WHERE complaint_id = {0}", parent.Id);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as ComplaintFollowUpModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.ComplaintId = parent.Id;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddTocomplaint_follow_up(entity);
                }

                Entities.SaveChanges();

                scope.Complete();
            }
        }
    }
}


