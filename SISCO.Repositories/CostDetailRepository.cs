using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class CostDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "CostDetail";
        public CostDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public CostDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CostDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocost_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as CostDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.cost_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CostDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.cost_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.cost_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.cost_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static cost_detail PopulateModelToNewEntity(CostDetailModel model)
		{
			return new cost_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				cost_id = model.CostId,
				date_process = model.DateProcess,
				cost_type_id = model.CostTypeId,
				description = model.Description,
				amount = model.Amount,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(cost_detail query, CostDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.cost_id = model.CostId;
			query.date_process = model.DateProcess;
			query.cost_type_id = model.CostTypeId;
			query.description = model.Description;
			query.amount = model.Amount;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static CostDetailModel PopulateEntityToNewModel(cost_detail item)
		{
			return new CostDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				CostId = item.cost_id,
				DateProcess = item.date_process,
				CostTypeId = item.cost_type_id,
				Description = item.description,
				Amount = item.amount,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cost_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (from item in query
                join c in Entities.cost_type on item.cost_type_id equals c.id
                select new CostDetailModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    CostId = item.cost_id,
                    DateProcess = item.date_process,
                    CostTypeId = item.cost_type_id,
                    CostType = c.name,
                    Description = item.description,
                    Amount = item.amount,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    StateChange2 = x
                }).ToList();
			return (IEnumerable<T>) obj;
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cost_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cost_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.cost_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<CostDetailModel> GetCostDetailReport(DateTime from, DateTime to, int[] costTypeIds, int branchId)
        {
            var fromDate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
            var toDate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

            var sql = @"SELECT
                            c.date_process DateProcess,
                            cd.amount Amount,
                            ct.name CostType,
                            d.name DivisionName,
                            cd.description Description
                        FROM cost_detail cd
                        INNER JOIN cost c ON cd.cost_id = c.id AND c.rowstatus = 1 
                        INNER JOIN cost_type ct ON cd.cost_type_id = ct.id
                        LEFT JOIN division d ON ct.division_id = d.id
                        WHERE cd.rowstatus = 1 AND c.branch_id = {0} AND c.date_process >= '{1}' AND c.date_process <= '{2}' {3}";

            if (costTypeIds.Any())
            {
                sql = string.Format(sql, branchId, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), string.Format("AND ct.id IN({0})", string.Join(",", costTypeIds)));
                var result = Entities.ExecuteStoreQuery<CostDetailModel>(sql).ToList();
                return result;
            }
            else
            {
                sql = string.Format(sql, branchId, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"), string.Empty);
                var result = Entities.ExecuteStoreQuery<CostDetailModel>(sql).ToList();
                return result;
            }
        }

        public List<CostJournal> GetCostPivotSource(DateTime from, DateTime to, int[] costTypeIds, int? branchId = null)
        {
            var fromDate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
            var toDate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

            var sql = @"SELECT 
	                        DATE(c.date_process) DateProcess,
                            ct2.name CostType,
                            REPLACE(FORMAT(SUM(cd.amount),0), ',','') Amount
                        FROM cost c
                        INNER JOIN cost_detail cd ON c.id = cd.cost_id AND cd.rowstatus = 1 
                        INNER JOIN cost_type ct2 ON cd.cost_type_id = ct2.id
                        WHERE c.rowstatus = 1 AND {0}
                        GROUP BY DATE(c.date_process), ct2.name;";

            var whereList = new List<string>();
            var sqlParams = new List<MySqlParameter>();

            whereList.Add("c.date_process >= @from");
            sqlParams.Add(new MySqlParameter("from", fromDate));

            whereList.Add("c.date_process <= @to");
            sqlParams.Add(new MySqlParameter("to", toDate));

            if (branchId != null)
            {
                whereList.Add("c.branch_id = @branchId");
                sqlParams.Add(new MySqlParameter("branchId", branchId));
            }

            if (costTypeIds.Any())
            {
                whereList.Add(string.Format("ct2.id IN({0})", string.Join(",", costTypeIds)));
            }

            sql = string.Format(sql, string.Join(" AND ", whereList));

            return Entities.ExecuteStoreQuery<CostJournal>(sql, sqlParams.ToArray()).ToList();
        }
    }
}