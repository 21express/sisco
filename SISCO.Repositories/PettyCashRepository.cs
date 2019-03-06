using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class PettyCashRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Petty Cash";
        public PettyCashRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PettyCashRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PettyCashModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopetty_cash(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as PettyCashModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.petty_cash where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PettyCashModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.petty_cash select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.petty_cash where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.petty_cash where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static petty_cash PopulateModelToNewEntity(PettyCashModel model)
		{
			return new petty_cash
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                branch_id = model.BranchId,
				code = model.Code,
                description = model.Description,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(petty_cash query, PettyCashModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.branch_id = model.BranchId;
			query.code = model.Code;
            query.description = model.Description;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static PettyCashModel PopulateEntityToNewModel(petty_cash item)
		{
            return new PettyCashModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                BranchId = item.branch_id,
				Code = item.code,
                Description = item.description,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby  
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.petty_cash select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.petty_cash select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.petty_cash select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.petty_cash select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.petty_cash select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.petty_cash select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<PettyCashEmployeeBalance> GetEmployeeTransactional(int branchId, DateTime dateFrom, DateTime dateTo, int? employeeId = null)
        {
            var sql = @"select
	                        e.code EmployeeCode,
                            e.name EmployeeName,
                            GetBalancePettyCash(pcj.paid_received_by, pcj.date_process) BeginningBalance,
                            pc.code PettyCashVoucher,
                            pcj.date_process TransactionDate,
	                        pcj.debit_amount Debit,
                            pcj.credit_amount Credit,
                            GetBalancePettyCash(pcj.paid_received_by, pcj.date_process) + pcj.credit_amount - pcj.debit_amount EndingBalance
                        from petty_cash_journal pcj
                        inner join petty_cash pc on pc.id = pcj.petty_cash_id and pc.rowstatus = 1 and pc.branch_id = @branchId
                        inner join employee e on pcj.paid_received_by = e.id
                        where {0}
                        order by pcj.paid_received_by, pcj.date_process;";

            var param = new List<MySqlParameter>();
            var sqlParam = new List<string>();
            sqlParam.Add("pcj.rowstatus = 1");
            sqlParam.Add(string.Format("pcj.date_process >= '{0}'", dateFrom.ToString("yyyy-MM-dd 00:00:00")));
            sqlParam.Add(string.Format("pcj.date_process <= '{0}'", dateTo.ToString("yyyy-MM-dd 23:59:59")));

            param.Add(new MySqlParameter("branchId", branchId));
            if (employeeId != null)
            {
                sqlParam.Add("pcj.paid_received_by = @employeeId");
                param.Add(new MySqlParameter("employeeId", employeeId));
            }

            sql = string.Format(sql, string.Join(" and ", sqlParam));
            return Entities.ExecuteStoreQuery<PettyCashEmployeeBalance>(sql, param.ToArray()).ToList();
        }
    }
}