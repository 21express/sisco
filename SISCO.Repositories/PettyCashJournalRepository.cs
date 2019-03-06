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
    public class PettyCashJournalRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Petty Cash Journal";
        public PettyCashJournalRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PettyCashJournalRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PettyCashJournalModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopetty_cash_journal(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as PettyCashJournalModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.petty_cash_journal where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PettyCashJournalModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.petty_cash_journal select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.petty_cash_journal where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.petty_cash_journal where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static petty_cash_journal PopulateModelToNewEntity(PettyCashJournalModel model)
		{
			return new petty_cash_journal
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				petty_cash_id = model.PettyCashId,
                date_process = model.DateProcess,
                debit_amount = model.DebitAmount,
                credit_amount = model.CreditAmount,
                paid_received_by = model.PaidReceivedBy,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(petty_cash_journal query, PettyCashJournalModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.petty_cash_id = model.PettyCashId;
            query.date_process = model.DateProcess;
            query.debit_amount = model.DebitAmount;
            query.credit_amount = model.CreditAmount;
            query.paid_received_by = model.PaidReceivedBy;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static PettyCashJournalModel PopulateEntityToNewModel(petty_cash_journal item)
		{
            return new PettyCashJournalModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				PettyCashId = item.petty_cash_id,
                DateProcess = item.date_process,
                DebitAmount = item.debit_amount,
                CreditAmount = item.credit_amount,
                PaidReceivedBy = item.paid_received_by,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.petty_cash_journal select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.petty_cash_journal select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.petty_cash_journal select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.petty_cash_journal select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.petty_cash_journal select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.petty_cash_journal select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<PettyCashDetailJournalModel> GetJournals (int pettyId)
        {
            var sql = @"SELECT 
	                        pcj.id Id,
                            pcj.date_process DateProcess,
                            pcj.debit_amount DebitAmount,
                            pcj.credit_amount CreditAmount,
                            pcj.paid_received_by PaidReceivedBy,
                            e.name EmployeeName,
                            'Select' StateChange
                        FROM petty_cash_journal pcj
                        INNER JOIN petty_cash pc ON pcj.petty_cash_id = pc.id AND pc.rowstatus = 1
                        INNER JOIN employee e ON pcj.paid_received_by = e.id
                        WHERE pcj.rowstatus = 1 AND pcj.petty_cash_id = @pettyId;";

            return Entities.ExecuteStoreQuery<PettyCashDetailJournalModel>(sql, new MySqlParameter("pettyId", pettyId)).ToList();
        }

        public List<PettyCashSearch> Search (int branchId, string code = null, string description = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, int? employeeId = null)
        {
            var sql = @"SELECT
	                        pc.code Code,
                            pc.description Description,
                            pcj.date_process DateProcess,
                            pcj.debit_amount DebitAmount,
                            pcj.credit_amount CreditAmount,
                            e.name EmployeeName
                        FROM petty_cash pc
                        INNER JOIN petty_cash_journal pcj ON pc.id = pcj.petty_cash_id AND pcj.rowstatus = 1
                        INNER JOIN employee e ON pcj.paid_received_by = e.id
                        WHERE {0}";

            var param = new List<string>();
            var sqlparam = new List<MySqlParameter>();

            param.Add("pc.rowstatus = 1");
            param.Add("pc.branch_id = @branchId");
            sqlparam.Add(new MySqlParameter("branchId", branchId));

            if (!string.IsNullOrEmpty(code))
            {
                param.Add("pc.code = @code");
                sqlparam.Add(new MySqlParameter("code", code));
            }

            if (!string.IsNullOrEmpty(description))
            {
                param.Add("pc.description LIKE @description");
                sqlparam.Add(new MySqlParameter("description", string.Format("%{0}%", description)));
            }

            if (dateFrom > DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("pcj.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo > DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("pcj.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            if (employeeId != null)
            {
                param.Add("pcj.paid_received_by = @employeeId");
                sqlparam.Add(new MySqlParameter("employeeId", employeeId));
            }

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<PettyCashSearch>(sql, sqlparam.ToArray()).ToList();
        }

        public List<PettyCashSummary> GetSummary(int branchId, DateTime beforeDate)
        {
            var sql = @"SELECT
	                        pc.code Code,
                            pc.description Description,
                            SUM(pcj.credit_amount) - SUM(pcj.debit_amount) Balance
                        FROM petty_cash pc
                        INNER JOIN petty_cash_journal pcj ON pc.id = pcj.petty_cash_id AND pcj.rowstatus = 1
                        INNER JOIN employee e ON pcj.paid_received_by = e.id
                        WHERE pc.rowstatus = 1 AND pc.branch_id = @branchId AND pcj.date_process <= '{0}'
                        GROUP BY pc.id
                        HAVING Balance <> 0;";

            sql = string.Format(sql, beforeDate.ToString("yyyy-MM-dd 23:59:59"));
            return Entities.ExecuteStoreQuery<PettyCashSummary>(sql, new MySqlParameter("branchId", branchId)).ToList();
        }
    }
}