using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;

namespace SISCO.Repositories
{
    public class DropPointRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        private const string OBJECT_NAME = "Drop Point";
        public DropPointRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public DropPointRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as DropPointModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTodrop_point(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as DropPointModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.drop_point where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as DropPointModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.drop_point select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.drop_point where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.drop_point where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static drop_point PopulateModelToNewEntity(DropPointModel model)
		{
            return new drop_point
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				code = model.Code,
				name = model.Name,
                address = model.Address,
                branch_id = model.BranchId,
                no_id = model.NoId,
                commission = model.Commission,
                email = model.Email,
                phone = model.Phone,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}

        private static void PopulateModelToNewEntity(drop_point query, DropPointModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.code = model.Code;
			query.name = model.Name;
            query.address = model.Address;
            query.branch_id = model.BranchId;
            query.no_id = model.NoId;
            query.commission = model.Commission;
            query.email = model.Email;
            query.phone = model.Phone;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}

        private static DropPointModel PopulateEntityToNewModel(drop_point item)
		{
			return new DropPointModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Code = item.code,
				Name = item.name,
                Address = item.address,
                BranchId = item.branch_id,
                NoId = item.no_id,
                Commission = item.commission,
                Email = item.email,
                Phone = item.phone,
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
            var query = (from a in Entities.drop_point select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.drop_point select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.drop_point select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.drop_point select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.drop_point select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.drop_point select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public string GenerateCode(DropPointModel model)
        {
            var branchCode = (from a in Entities.branches
                              where a.id == model.BranchId
                              select a.code).FirstOrDefault();

            var pattern = string.Format("DP-{0}###", branchCode);

            return GenerateCode("drop-point", pattern);
        }

        public List<DropPointReport> CommissionReport(DateTime from, DateTime to, int? branchId = null)
        {
            var filter = string.Empty;
            filter += string.Format("s.date_process >= '{0}-{1}-{2} 00:00:00' ", from.Year, from.Month, from.Day);
            filter += string.Format("AND s.date_process <= '{0}-{1}-{2} 23:59:59' ", to.Year, to.Month, to.Day);

            if (branchId != null)
            {
                filter += string.Format("AND s.branch_id = {0}", branchId);
            }

            var sql = @"SELECT
	                        s.code ShipmentCode,
                            s.date_process ShipmentDate,
                            s.discount_percent Percent,
                            s.discount_total Total,
                            dp.code Code,
                            dp.name Name
                        FROM shipment s
                        INNER JOIN shipment_expand se ON s.id = se.shipment_id
                        INNER JOIN drop_point dp ON se.drop_point_id = dp.id
                        WHERE s.rowstatus = 1 AND s.voided = 0 AND {0};";
            sql = string.Format(sql, filter);
            return Entities.ExecuteStoreQuery<DropPointReport>(sql).ToList();
        }
    }
}