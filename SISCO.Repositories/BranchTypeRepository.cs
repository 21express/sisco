

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
    public class BranchTypeRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "BranchType";
        public BranchTypeRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public BranchTypeRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as BranchTypeModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTobranch_type(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as BranchTypeModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.branch_type where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as BranchTypeModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.branch_type select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.branch_type where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.branch_type where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static branch_type PopulateModelToNewEntity(BranchTypeModel model)
		{
			return new branch_type
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				name = model.Name,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(branch_type query, BranchTypeModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.name = model.Name;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static BranchTypeModel PopulateEntityToNewModel(branch_type item)
		{
			return new BranchTypeModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Name = item.name,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.branch_type select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.branch_type select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.branch_type select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.branch_type select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}        
       
    }
}


