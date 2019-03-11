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
    public class TransactionalAccountRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Transactional Account";
        public TransactionalAccountRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public TransactionalAccountRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as TransactionalAccountModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTotransactional_account(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as TransactionalAccountModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.transactional_account where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as TransactionalAccountModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.transactional_account select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.transactional_account where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.transactional_account where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static transactional_account PopulateModelToNewEntity(TransactionalAccountModel model)
		{
			return new transactional_account
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				bank_account_id = model.BankAccountId,
                date_process = model.DateProcess,
                description = model.Description,
                debit_total_amount = model.DebitTotalAmount,
                credit_total_amount = model.CreditTotalAmount,
                balance = model.Balance,
                closed_by = model.ClosedBy,
                closed_date = model.ClosedDate,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(transactional_account query, TransactionalAccountModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.bank_account_id = model.BankAccountId;
            query.date_process = model.DateProcess;
            query.description = model.Description;
            query.debit_total_amount = model.DebitTotalAmount;
            query.credit_total_amount = model.CreditTotalAmount;
            query.balance = model.Balance;
            query.closed_by = model.ClosedBy;
            query.closed_date = model.ClosedDate;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static TransactionalAccountModel PopulateEntityToNewModel(transactional_account item)
		{
            return new TransactionalAccountModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				BankAccountId = item.bank_account_id,
                DateProcess = item.date_process,
                Description = item.description,
                DebitTotalAmount = item.debit_total_amount,
                CreditTotalAmount = item.credit_total_amount,
                Balance = item.balance,
                ClosedBy = item.closed_by,
                ClosedDate = item.closed_date,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.transactional_account select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.transactional_account select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.transactional_account select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.transactional_account select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.transactional_account select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.transactional_account select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void AddTransaction(TransactionalAccountModel transaction, string user)
        {
            Entities.ExecuteStoreCommand("call BankTransactional (@bankId, @dateProcess, @description, @debit, @credit, @actor);",
                new MySqlParameter("bankId", transaction.BankAccountId),
                new MySqlParameter("dateProcess", transaction.DateProcess),
                new MySqlParameter("description", transaction.Description),
                new MySqlParameter("debit", transaction.DebitTotalAmount),
                new MySqlParameter("credit", transaction.CreditTotalAmount),
                new MySqlParameter("actor", user));
        }

        public List<BankTransactionModel> GetDetails(int bankId, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var sql = @"SET @row = 0;
                        SELECT
                            Id,
                            RowNum,
	                        DateProcess,
                            Description,
                            DebitTotalAmount,
                            CreditTotalAmount,
                            Balance
                        FROM (
	                        SELECT 
                                Id,
		                        (@row:=@row + 1) RowNum,
		                        date_process DateProcess,
		                        description Description,
		                        debit_total_amount DebitTotalAmount,
		                        credit_total_amount CreditTotalAmount,
		                        balance Balance
	                        FROM transactional_account
	                        WHERE {0}
                            ORDER BY date_process
                        ) s
                        HAVING RowNum > @row-150;";

            var param = new List<string>();
            var sqlparam = new List<MySqlParameter>();

            param.Add("rowstatus = 1");
            param.Add("bank_account_id = @bankId");
            sqlparam.Add(new MySqlParameter("bankId", bankId));

            if (dateFrom > DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo > DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            sql = string.Format(sql, string.Join(" AND ", param));

            return Entities.ExecuteStoreQuery<BankTransactionModel>(sql, sqlparam.ToArray()).ToList();
        }

        public List<BankTransactionModel> GetTransactionRevisionList(TransactionalAccountModel transaction)
        {
            var sql = @"(
                        SELECT
	                        id Id,
                            date_process DateProcess,
                            description Description,
                            debit_total_amount DebitTotalAmount,
                            credit_total_amount CreditTotalAmount,
                            balance Balance,
                            false IsModify,
                            'Select' StateChange
                        FROM transactional_account
                        WHERE rowstatus = 1 AND bank_account_id = @bankId AND date_process < '{0}'
                        ORDER BY date_process DESC
                        LIMIT 9
                        )

                        UNION

                        (
                        SELECT 
	                        id Id,
                            date_process DateProcess,
                            description Description,
                            debit_total_amount DebitTotalAmount,
                            credit_total_amount CreditTotalAmount,
                            balance Balance,
                            true IsModify,
                            'Select' StateChange
                        FROM siscodb.transactional_account
                        WHERE rowstatus = 1 AND id = @id
                        )

                        UNION

                        (
                        SELECT
	                        id Id,
                            date_process DateProcess,
                            description Description,
                            debit_total_amount DebitTotalAmount,
                            credit_total_amount CreditTotalAmount,
                            balance Balance,
                            false IsModify,
                            'Select' StateChange
                        FROM transactional_account
                        WHERE rowstatus = 1 AND bank_account_id = @bankId AND date_process > '{0}'
                        ORDER BY date_process ASC
                        LIMIT 20
                        )

                        ORDER BY DateProcess;";

            sql = string.Format(sql, transaction.DateProcess.ToString("yyyy-MM-dd HH:mm:ss"));
            return Entities.ExecuteStoreQuery<BankTransactionModel>(sql, new MySqlParameter("bankId", transaction.BankAccountId), new MySqlParameter("id", transaction.Id)).ToList();
        }

        public decimal GetBankBalance(int bankId, DateTime transactionDate)
        {
            var result = Entities.ExecuteStoreQuery<BankBalance>(
                string.Format("call GetBankBalance(@bankId, '{0}', @d);", transactionDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new MySqlParameter("bankId", bankId)).First();

            return result.Balance;
        }

        public void TransactionalRevision(int pid, string description, DateTime transactionDate, decimal debit, decimal credit, DateTime startDate, string actor)
        {
            var sql = "call BankTransactionRevision(@pid, @description, '{0}', @debit, @credit, '{1}', @actor);";
            sql = string.Format(sql, transactionDate.ToString("yyyy-MM-dd HH:mm:ss"), startDate.ToString("yyyy-MM-dd HH:mm:ss"));
            Entities.ExecuteStoreCommand(sql,
                new MySqlParameter("pid", pid),
                new MySqlParameter("description", description),
                new MySqlParameter("debit", debit),
                new MySqlParameter("credit", credit),
                new MySqlParameter("actor", actor));
        }

        public List<TransactionLookup> SearchTransactionCredit(int bankId, DateTime? dateFrom = null, DateTime? dateTo = null,
            string description = null, decimal? total = null)
        {
            var sql = @"SELECT
	                        ta.id Id,
                            ta.date_process DateProcess,
                            ta.description Description,
                            ta.credit_total_amount Total
                        FROM transactional_account ta
                        WHERE {0}
                        ORDER BY ta.date_process
                        LIMIT 100;";

            var param = new List<string>();
            param.Add("ta.rowstatus = 1");
            param.Add("ta.bank_account_id = @bankId");
            param.Add("ta.debit_total_amount = 0");
            param.Add("ta.closed_date IS NULL");

            if (dateFrom > DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("ta.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo > DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("ta.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            if (!string.IsNullOrEmpty(description)) param.Add(string.Format("ta.description LIKE '%{0}%'", description));
            if (total > 0) param.Add(string.Format("ta.credit_total_amount = {0}", total));

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<TransactionLookup>(sql, new MySqlParameter("bankId", bankId)).ToList();
        }

        public List<TransactionLookup> SearchTransactionDebit(int bankId, DateTime? dateFrom = null, DateTime? dateTo = null,
            string description = null, decimal? total = null)
        {
            var sql = @"SELECT
	                        ta.id Id,
                            ta.date_process DateProcess,
                            ta.description Description,
                            ta.debit_total_amount Total
                        FROM transactional_account ta
                        WHERE {0}
                        ORDER BY ta.date_process
                        LIMIT 100;";

            var param = new List<string>();
            param.Add("ta.rowstatus = 1");
            param.Add("ta.bank_account_id = @bankId");
            param.Add("ta.credit_total_amount = 0");
            param.Add("ta.closed_date IS NULL");

            if (dateFrom > DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("ta.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo > DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("ta.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            if (!string.IsNullOrEmpty(description)) param.Add(string.Format("ta.description LIKE '%{0}%'", description));
            if (total > 0) param.Add(string.Format("ta.debit_total_amount = {0}", total));

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<TransactionLookup>(sql, new MySqlParameter("bankId", bankId)).ToList();
        }

        public decimal GetTransactionBalanceAgaintsPayment(int pid, int? paymentId = null, int? paymentCounterId = null, 
            int? paymentOtherInId = null, int? paymentCollectOutId = null)
        {
            var sql = @"SELECT
                            ta.debit_total_amount + ta.credit_total_amount - IF(pi.id IS NOT NULL, pi.total, 0) - IF(pic.id IS NOT NULL, pic.total, 0) - IF (oipi.id IS NOT NULL, oipi.total, 0) - IF (pico.id IS NOT NULL, pico.total, 0) Balance
                        FROM transactional_account ta
                        LEFT JOIN payment_in pi ON ta.id = pi.transactional_account_id AND pi.rowstatus = 1{1}
                        LEFT JOIN payment_in_counter pic ON ta.id = pic.transactional_account_id AND pic.rowstatus = 1{2}
                        LEFT JOIN other_invoice_payment_in oipi ON ta.id = oipi.transactional_account_id AND oipi.rowstatus = 1{3}
                        LEFT JOIN payment_in_collect_out pico ON ta.id = pico.transactional_account_id AND pico.rowstatus = 1{4}
                        WHERE {0}";

            var param = new List<string>();
            param.Add("ta.rowstatus = 1");
            param.Add("ta.id = @pid");

            if (paymentId != null)
                sql = string.Format(sql, string.Join(" AND ", param), " AND pi.id <> " + paymentId, string.Empty, string.Empty, string.Empty, string.Empty);
            else if (paymentCounterId != null)
                sql = string.Format(sql, string.Join(" AND ", param), string.Empty, " AND pic.id <> " + paymentCounterId, string.Empty, string.Empty, string.Empty);
            else if (paymentOtherInId != null)
                sql = string.Format(sql, string.Join(" AND ", param), string.Empty, string.Empty, " AND oipi.id <> " + paymentOtherInId, string.Empty);
            else if (paymentCollectOutId != null)
                sql = string.Format(sql, string.Join(" AND ", param), string.Empty, string.Empty, string.Empty, " AND pico.id <> " + paymentCollectOutId);
            else sql = string.Format(sql, string.Join(" AND ", param), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

            return Entities.ExecuteStoreQuery<BankBalance>(sql, new MySqlParameter("pid", pid)).First().Balance;
        }

        public decimal GetWithdrawAgaintsCost(int branchId, DateTime beforeDate, int? costId = null)
        {
            var sql = costId == null ? string.Format("call GetBalanceWithdrawAgaintsCost(@branchId, '{0}', null);", beforeDate.ToString("yyyy-MM-dd HH:mm:ss")) : string.Format("call GetBalanceWithdrawAgaintsCost(@branchId, '{0}', {1});", beforeDate.ToString("yyyy-MM-dd HH:mm:ss"), costId);

            var result = Entities.ExecuteStoreQuery<BankBalance>(sql, new MySqlParameter("branchId", branchId)).First();

            return result.Balance;
        }

        public List<TransactionJournal> GetTransactionJournal(int bankId, DateTime? dateFrom = null, DateTime? dateTo = null, 
            bool closed = false)
        {
            var sql = @"SELECT
	                        ta.id Id,
	                        ta.date_process TransactionAccountDate,
	                        ta.description Description,
	                        null TransactionId,
	                        '' TransactionCode,
	                        null TransactionDate,
	                        '' TransactionDescription,
	                        'TA' TransactionType,
	                        ta.debit_total_amount Debit,
	                        ta.credit_total_amount Credit,
	                        IF (ta.debit_total_amount > 0, 0, 
		                        ta.debit_total_amount+ta.credit_total_amount 
		                        - if ((select count(id) from payment_in where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from payment_in where transactional_account_id = ta.id and rowstatus = 1), 0) 
		                        - if ((select count(id) from payment_in_counter where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from payment_in_counter where transactional_account_id = ta.id and rowstatus = 1), 0) 
		                        - if ((select count(id) from other_invoice_payment_in where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from other_invoice_payment_in where transactional_account_id = ta.id and rowstatus = 1), 0) 
		                        - if ((select count(id) from payment_in_collect_out where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from payment_in_collect_out where transactional_account_id = ta.id and rowstatus = 1), 0) 
	                        ) Balance,
	                        ta.closed_date Closeddate,
                            null TotalPph,
                            null MateraiFee
                        FROM transactional_account ta
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        pi.description Description,
	                        ta.id TransactionId,
	                        pi.code TransactionCode,
	                        pi.date_process TransactionDate,
	                        pid.invoice_ref_number TransactionDescription,
	                        'Invoice' TransactionType,
	                        IF(pi.adjustment > 0, pi.adjustment, 0) Debit,
	                        pi.total Credit,
	                        pid.payment Balance,
	                        ta.closed_date Closeddate,
                            pid.total_pph23 TotalPPh,
                            pid.materai_fee MateraiFee
                        FROM transactional_account ta
                        INNER JOIN payment_in pi ON pi.transactional_account_id = ta.id AND pi.rowstatus = 1
                        INNER JOIN payment_in_detail pid ON pi.id = pid.payment_in_id AND pid.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        pic.description Description,
	                        ta.id TransactionId,
	                        pic.code TransactionCode,
	                        pic.date_process TransactionDate,
	                        '' TransactionDescription,
	                        'Counter' TransactionType,
	                        IF(pic.adjustment > 0, pic.adjustment, 0) Debit,
	                        pic.Total Credit,
	                        0 Balance
	                        ,ta.closed_date Closeddate,
                            null TotalPPh,
                            null MateraiFee
                        FROM transactional_account ta
                        INNER JOIN payment_in_counter pic ON pic.transactional_account_id = ta.id AND pic.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        oipi.description Description,
	                        ta.id TransactionId,
	                        oipi.code TransactionCode,
	                        oipi.date_process TransactionDate,
	                        oipid.invoice_ref_number TransactionDescription,
	                        'Other' TransactionType,
	                        IF(oipi.adjustment > 0, oipi.adjustment, 0) Debit,
	                        oipi.total Credit,
	                        oipid.payment Balance,
	                        ta.closed_date Closeddate,
                            oipid.total_pph23 TotalPPh,
                            oipid.materai_fee MateraiFee
                        FROM transactional_account ta
                        INNER JOIN other_invoice_payment_in oipi ON oipi.transactional_account_id = ta.id AND oipi.rowstatus = 1
                        INNER JOIN other_invoice_payment_in_detail oipid ON oipi.id = oipid.other_invoice_payment_in_id AND oipid.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        pico.description Description,
	                        ta.id TransactionId,
	                        pico.code TransactionCode,
	                        pico.date_process TransactionDate,
	                        '' TransactionDescription,
	                        'Collect' TransactionType,
	                        IF(pico.adjustment > 0, pico.adjustment, 0) Debit,
	                        pico.Total Credit,
	                        0 Balance
	                        ,ta.closed_date Closeddate,
                            null TotalPPh,
                            null MateraiFee
                        FROM transactional_account ta
                        INNER JOIN payment_in_collect_out pico ON pico.transactional_account_id = ta.id AND pico.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        ta.description Description,
	                        ta.id TransactionId,
	                        c.code TransactionCode,
	                        c.date_process TransactionDate,
	                        c.description TransactionDescription,
	                        'Cost' TransactionType,
	                        0 Debit,
	                        c.total Credit,
	                        0 Balance,
                            ta.closed_date Closeddate,
                            null TotalPPh,
                            null MateraiFee
                        FROM transactional_account ta
                        INNER JOIN cost_transactional_account cta on ta.id = cta.transactional_account_id and cta.rowstatus = 1
                        INNER JOIN cost c ON cta.cost_id = c.id and c.rowstatus = 1
                        WHERE {0}

                        ORDER BY TransactionAccountDate, TransactionDate;";

            var param = new List<string>();
            
            param.Add("ta.rowstatus = 1");
            param.Add("ta.bank_account_id = @bankId");
            if (closed) param.Add("ta.closed_date IS NULL");

            if (dateFrom > DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("ta.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo > DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("ta.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<TransactionJournal>(sql, new MySqlParameter("bankId", bankId)).ToList();
        }

        public List<TransactionJournal> GetTransactionJournalVerified(int bankId, DateTime? dateFrom = null, 
            DateTime? dateTo = null)
        {
            var sql = @"SELECT
	                        ta.id Id,
	                        ta.date_process TransactionAccountDate,
	                        ta.description Description,
	                        null TransactionId,
	                        '' TransactionCode,
	                        null TransactionDate,
	                        '' TransactionDescription,
	                        'TA' TransactionType,
	                        ta.debit_total_amount Debit,
	                        ta.credit_total_amount Credit,
	                        IF (ta.debit_total_amount > 0, 0, 
		                        ta.debit_total_amount+ta.credit_total_amount 
		                        - if ((select count(id) from payment_in where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from payment_in where transactional_account_id = ta.id and rowstatus = 1), 0) 
		                        - if ((select count(id) from payment_in_counter where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from payment_in_counter where transactional_account_id = ta.id and rowstatus = 1), 0) 
		                        - if ((select count(id) from other_invoice_payment_in where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from other_invoice_payment_in where transactional_account_id = ta.id and rowstatus = 1), 0) 
		                        - if ((select count(id) from payment_in_collect_out where transactional_account_id = ta.id and rowstatus = 1) > 0, (select sum(total) from payment_in_collect_out where transactional_account_id = ta.id and rowstatus = 1), 0) 
	                        ) Balance,
	                        ta.closed_date Closeddate,
                            null TotalPph,
                            null MateraiFee
                        FROM transactional_account ta
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        pi.description Description,
	                        ta.id TransactionId,
	                        pi.code TransactionCode,
	                        pi.date_process TransactionDate,
	                        pid.invoice_ref_number TransactionDescription,
	                        'Invoice' TransactionType,
	                        IF(pi.adjustment > 0, pi.adjustment, 0) Debit,
	                        pi.total Credit,
	                        pid.payment Balance,
	                        ta.closed_date Closeddate,
                            pid.total_pph23 TotalPPh,
                            pid.materai_fee MateraiFee
                        FROM transactional_account ta
                        INNER JOIN payment_in pi ON pi.transactional_account_id = ta.id AND pi.rowstatus = 1
                        INNER JOIN payment_in_detail pid ON pi.id = pid.payment_in_id AND pid.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        pic.description Description,
	                        ta.id TransactionId,
	                        pic.code TransactionCode,
	                        pic.date_process TransactionDate,
	                        '' TransactionDescription,
	                        'Counter' TransactionType,
	                        IF(pic.adjustment > 0, pic.adjustment, 0) Debit,
	                        pic.Total Credit,
	                        0 Balance
	                        ,ta.closed_date Closeddate,
                            null TotalPPh,
                            null MateraiFee
                        FROM transactional_account ta
                        INNER JOIN payment_in_counter pic ON pic.transactional_account_id = ta.id AND pic.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        oipi.description Description,
	                        ta.id TransactionId,
	                        oipi.code TransactionCode,
	                        oipi.date_process TransactionDate,
	                        oipid.invoice_ref_number TransactionDescription,
	                        'Other' TransactionType,
	                        IF(oipi.adjustment > 0, oipi.adjustment, 0) Debit,
	                        oipi.total Credit,
	                        oipid.payment Balance,
	                        ta.closed_date Closeddate,
                            oipid.total_pph23 TotalPPh,
                            oipid.materai_fee MateraiFee
                        FROM transactional_account ta
                        INNER JOIN other_invoice_payment_in oipi ON oipi.transactional_account_id = ta.id AND oipi.rowstatus = 1
                        INNER JOIN other_invoice_payment_in_detail oipid ON oipi.id = oipid.other_invoice_payment_in_id AND oipid.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        pico.description Description,
	                        ta.id TransactionId,
	                        pico.code TransactionCode,
	                        pico.date_process TransactionDate,
	                        '' TransactionDescription,
	                        'Collect' TransactionType,
	                        IF(pico.adjustment > 0, pico.adjustment, 0) Debit,
	                        pico.Total Credit,
	                        0 Balance
	                        ,ta.closed_date Closeddate,
                            null TotalPPh,
                            null MateraiFee
                        FROM transactional_account ta
                        INNER JOIN payment_in_collect_out pico ON pico.transactional_account_id = ta.id AND pico.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        null Id,
	                        ta.date_process TransactionAccountDate,
	                        ta.description Description,
	                        ta.id TransactionId,
	                        c.code TransactionCode,
	                        c.date_process TransactionDate,
	                        c.description TransactionDescription,
	                        'Cost' TransactionType,
	                        0 Debit,
	                        c.total Credit,
	                        0 Balance,
                            ta.closed_date Closeddate,
                            null TotalPPh,
                            null MateraiFee
                        FROM transactional_account ta
                        INNER JOIN cost_transactional_account cta on ta.id = cta.transactional_account_id and cta.rowstatus = 1
                        INNER JOIN cost c ON cta.cost_id = c.id and c.rowstatus = 1
                        WHERE {0}

                        ORDER BY TransactionAccountDate, TransactionDate;";

            var param = new List<string>();

            param.Add("ta.rowstatus = 1");
            param.Add("ta.bank_account_id = @bankId");
            param.Add("ta.closed_date IS NOT NULL");

            if (dateFrom > DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("ta.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo > DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("ta.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<TransactionJournal>(sql, new MySqlParameter("bankId", bankId)).ToList();
        }

        public void Closing(int id, string actor)
        {
            Entities.ExecuteStoreCommand("call ClosingTransactionalAccount(@pid, @actor);", new MySqlParameter("pid", id), new MySqlParameter("actor", actor));
        }

        public void Cancellation(int id, string actor)
        {
            Entities.ExecuteStoreCommand("call CancellationVerifiedTransactionalAccount(@pid, @actor);", new MySqlParameter("pid", id), new MySqlParameter("actor", actor));
        }

        public List<TransactionJournalReport> JournalReport(int bankId, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var sql = @"SELECT
	                        ta.id Id,
	                        CONCAT(ba.account_no, ' - ', ba.bank_name) AccountNo,
	                        ta.date_process,
	                        DATE_FORMAT(ta.date_process, '%Y-%m-%d') TransactionAccountDate,
	                        ta.description Description,
	                        '' TransactionCode,
	                        null TransactionDate,
	                        '' TransactionDescription,
	                        ta.debit_total_amount Debit,
	                        ta.credit_total_amount Credit,
	                        ta.balance Balance,
	                        ta.closed_date ClosedDate
                        FROM transactional_account ta
                        INNER JOIN bank_account ba ON ba.id = ta.bank_account_id and ba.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        ta.id Id,
	                        CONCAT(ba.account_no, ' - ', ba.bank_name) AccountNo,
	                        ta.date_process,
	                        DATE_FORMAT(ta.date_process, '%Y-%m-%d') TransactionAccountDate,
	                        ta.description Description,
	                        pi.code TransactionCode,
	                        pi.date_process TransactionDate,
	                        GROUP_CONCAT(pid.invoice_ref_number) TransactionDescription,
	                        0 Debit,
	                        pi.total Credit,
	                        ta.balance Balance,
	                        ta.closed_date ClosedDate
                        FROM transactional_account ta
                        INNER JOIN bank_account ba ON ba.id = ta.bank_account_id and ba.rowstatus = 1
                        INNER JOIN payment_in pi ON pi.transactional_account_id = ta.id AND pi.rowstatus = 1
                        INNER JOIN payment_in_detail pid ON pi.id = pid.payment_in_id AND pid.rowstatus = 1
                        WHERE {0}
                        GROUP BY pi.id

                        UNION

                        SELECT
	                        ta.id Id,
	                        CONCAT(ba.account_no, ' - ', ba.bank_name) AccountNo,
	                        ta.date_process,
	                        DATE_FORMAT(ta.date_process, '%Y-%m-%d') TransactionAccountDate,
	                        ta.description Description,
	                        pic.code TransactionCode,
	                        pic.date_process TransactionDate,
	                        '' TransactionDescription,
	                        0 Debit,
	                        pic.Total Credit,
	                        ta.balance Balance,
	                        ta.closed_date ClosedDate
                        FROM transactional_account ta
                        INNER JOIN bank_account ba ON ba.id = ta.bank_account_id and ba.rowstatus = 1
                        INNER JOIN payment_in_counter pic ON pic.transactional_account_id = ta.id AND pic.rowstatus = 1
                        WHERE {0}

                        UNION

                        SELECT
	                        ta.id Id,
	                        CONCAT(ba.account_no, ' - ', ba.bank_name) AccountNo,
	                        ta.date_process,
	                        DATE_FORMAT(ta.date_process, '%Y-%m-%d') TransactionAccountDate,
	                        ta.description Description,
	                        oipi.code TransactionCode,
	                        oipi.date_process TransactionDate,
	                        GROUP_CONCAT(oipid.invoice_ref_number) TransactionDescription,
	                        0 Debit,
	                        oipi.total Credit,
	                        ta.balance Balance,
	                        ta.closed_date ClosedDate
                        FROM transactional_account ta
                        INNER JOIN bank_account ba ON ba.id = ta.bank_account_id and ba.rowstatus = 1
                        INNER JOIN other_invoice_payment_in oipi ON oipi.transactional_account_id = ta.id AND oipi.rowstatus = 1
                        INNER JOIN other_invoice_payment_in_detail oipid ON oipi.id = oipid.other_invoice_payment_in_id AND oipid.rowstatus = 1
                        WHERE {0}
                        GROUP BY oipi.id

                        UNION

                        SELECT
	                        ta.id Id,
	                        CONCAT(ba.account_no, ' - ', ba.bank_name) AccountNo,
	                        ta.date_process,
	                        DATE_FORMAT(ta.date_process, '%Y-%m-%d') TransactionAccountDate,
	                        ta.description Description,
	                        pico.code TransactionCode,
	                        pico.date_process TransactionDate,
	                        GROUP_CONCAT(picod.invoice_code) TransactionDescription,
	                        0 Debit,
	                        pico.total Credit,
	                        ta.balance Balance,
	                        ta.closed_date ClosedDate
                        FROM transactional_account ta
                        INNER JOIN bank_account ba ON ba.id = ta.bank_account_id and ba.rowstatus = 1
                        INNER JOIN payment_in_collect_out pico ON pico.transactional_account_id = ta.id AND pico.rowstatus = 1
                        INNER JOIN payment_in_collect_out_detail picod ON pico.id = picod.payment_in_collect_out_id AND picod.rowstatus = 1
                        WHERE {0}
                        GROUP BY pico.id

                        UNION

                        SELECT 
	                        ta.id Id,
	                        CONCAT(ba.account_no, ' - ', ba.bank_name) AccountNo,
	                        ta.date_process,
	                        DATE_FORMAT(ta.date_process, '%Y-%m-%d') TransactionAccountDate,
	                        ta.description Description,
	                        c.code TransactionCode,
	                        c.date_process TransactionDate,
	                        '' TransactionDescription,
	                        c.total Debit,
	                        0 Credit,
	                        ta.balance Balance,
	                        ta.closed_date ClosedDate
                        FROM transactional_account ta
                        INNER JOIN bank_account ba ON ba.id = ta.bank_account_id and ba.rowstatus = 1
                        INNER JOIN cost_transactional_account cta ON cta.transactional_account_id = ta.id AND cta.rowstatus = 1
                        INNER JOIN cost c ON cta.cost_id = c.id AND c.rowstatus = 1
                        WHERE {0}

                        ORDER BY date_process, TransactionDate;";

            var param = new List<string>();

            param.Add("ta.rowstatus = 1");
            param.Add("ta.bank_account_id = @bankId");

            if (dateFrom > DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("ta.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo > DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("ta.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<TransactionJournalReport>(sql, new MySqlParameter("bankId", bankId)).ToList();
        }

        public TransactionalAccountModel GetTransactionAccountAgaintsCostTransaction(int id)
        {
            var sql = @"SELECT
	                        ta.id Id,
                            ta.description Description,
                            ta.debit_total_amount DebitTotalAmount
                        FROM transactional_account ta 
                        LEFT JOIN cost_transactional_account cta ON ta.id = cta.transactional_account_id AND cta.rowstatus = 1
                        WHERE ta.rowstatus = 1 AND ta.id = @pid AND cta.id IS NULL;";

            return Entities.ExecuteStoreQuery<TransactionalAccountModel>(sql, new MySqlParameter("pid", id)).FirstOrDefault();
        }

        public List<TransactionalJournalUnposted> JournalUnpostedReport (int bankId, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var sql = @"SELECT
	                        ba.account_no AccountNo,
                            ba.bank_name BankName,
	                        ta.date_process DateProcess,
	                        ta.description Description,
	                        ta.debit_total_amount Debit,
                            ta.credit_total_amount Credit,
                            ta.balance Balance
                        FROM transactional_account ta
                        INNER JOIN bank_account ba ON ta.bank_account_id = ba.id AND ba.rowstatus = 1
                        LEFT JOIN payment_in pi ON pi.transactional_account_id = ta.id AND pi.rowstatus = 1
                        LEFT JOIN payment_in_counter pic ON pic.transactional_account_id = ta.id AND pic.rowstatus = 1
                        LEFT JOIN other_invoice_payment_in oipi ON oipi.transactional_account_id = ta.id AND oipi.rowstatus = 1
                        LEFT JOIN payment_in_collect_out pico ON pico.transactional_account_id = ta.id AND pico.rowstatus = 1
                        WHERE {0}";

            var sqlparam = new List<string>();
            sqlparam.Add("ta.rowstatus = 1");
            sqlparam.Add("ta.bank_account_id = @bankId");
            sqlparam.Add("pi.id IS NULL AND pic.id IS NULL AND oipi.id IS NULL AND pico.id IS NULL");

            if (dateFrom != null)
                sqlparam.Add(string.Format("ta.date_process >= '{0}'", ((DateTime)dateFrom).ToString("yyyy-MM-dd 00:00:00")));
            if (dateTo != null)
                sqlparam.Add(string.Format("ta.date_process <= '{0}'", ((DateTime)dateTo).ToString("yyyy-MM-dd 23:59:59")));

            sql = string.Format(sql, string.Join(" AND ", sqlparam));
            return Entities.ExecuteStoreQuery<TransactionalJournalUnposted>(sql, new MySqlParameter("bankId", bankId)).ToList();
        }
    }
}