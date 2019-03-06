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
    public class PaymentInRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentIn";
        public PaymentInRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PaymentInRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PaymentInModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopayment_in(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PaymentInModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.payment_in where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentInModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_in select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_in where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.payment_in where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static payment_in PopulateModelToNewEntity(PaymentInModel model)
		{
			return new payment_in
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
				payment_type_id = model.PaymentTypeId,
				description = model.Description,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				account_id = model.AccountId,
				amount = model.Amount,
				total_invoice = model.TotalInvoice,
				total = model.Total,
				adjustment = model.Adjustment,
				total_credit = model.TotalCredit,
				total_other = model.TotalOther,
				rc_percent = model.RcPercent,
				rc_percent_total = model.RcPercentTotal,
				rc_kg = model.RcKg,
				rc_kg_total = model.RcKgTotal,
				rc_fixed = model.RcFixed,
				rc_total = model.RcTotal,
				paid_rc = model.PaidRc,
				total_payment_rc = model.TotalPaymentRc,
				marketing_id = model.MarketingId,
				mc_percent = model.McPercent,
				mc_percent_total = model.McPercentTotal,
				mc_kg = model.McKg,
				mc_kg_total = model.McKgTotal,
				mc_fixed = model.McFixed,
				mc_total = model.McTotal,
				paid_mc = model.PaidMc,
				total_payment_mc = model.TotalPaymentMc,
                transactional_account_id = model.TransactionalAccountId,
                verified = model.Verified,
                verified_by = model.VerifiedBy,
                verified_date = model.VerifiedDate,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(payment_in query, PaymentInModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.payment_type_id = model.PaymentTypeId;
			query.description = model.Description;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.account_id = model.AccountId;
			query.amount = model.Amount;
			query.total_invoice = model.TotalInvoice;
			query.total = model.Total;
			query.adjustment = model.Adjustment;
			query.total_credit = model.TotalCredit;
			query.total_other = model.TotalOther;
			query.rc_percent = model.RcPercent;
			query.rc_percent_total = model.RcPercentTotal;
			query.rc_kg = model.RcKg;
			query.rc_kg_total = model.RcKgTotal;
			query.rc_fixed = model.RcFixed;
			query.rc_total = model.RcTotal;
			query.paid_rc = model.PaidRc;
			query.total_payment_rc = model.TotalPaymentRc;
			query.marketing_id = model.MarketingId;
			query.mc_percent = model.McPercent;
			query.mc_percent_total = model.McPercentTotal;
			query.mc_kg = model.McKg;
			query.mc_kg_total = model.McKgTotal;
			query.mc_fixed = model.McFixed;
			query.mc_total = model.McTotal;
			query.paid_mc = model.PaidMc;
			query.total_payment_mc = model.TotalPaymentMc;
            query.transactional_account_id = model.TransactionalAccountId;
            query.verified = model.Verified;
            query.verified_by = model.VerifiedBy;
            query.verified_date = model.VerifiedDate;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static PaymentInModel PopulateEntityToNewModel(payment_in item)
		{
			return new PaymentInModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
				PaymentTypeId = item.payment_type_id,
				Description = item.description,
				CustomerId = item.customer_id,
				CustomerName = item.customer_name,
				AccountId = item.account_id,
				Amount = item.amount,
				TotalInvoice = item.total_invoice,
				Total = item.total,
				Adjustment = item.adjustment,
				TotalCredit = item.total_credit,
				TotalOther = item.total_other,
				RcPercent = item.rc_percent,
				RcPercentTotal = item.rc_percent_total,
				RcKg = item.rc_kg,
				RcKgTotal = item.rc_kg_total,
				RcFixed = item.rc_fixed,
				RcTotal = item.rc_total,
				PaidRc = item.paid_rc,
				TotalPaymentRc = item.total_payment_rc,
				MarketingId = item.marketing_id,
				McPercent = item.mc_percent,
				McPercentTotal = item.mc_percent_total,
				McKg = item.mc_kg,
				McKgTotal = item.mc_kg_total,
				McFixed = item.mc_fixed,
				McTotal = item.mc_total,
				PaidMc = item.paid_mc,
				TotalPaymentMc = item.total_payment_mc,
                TransactionalAccountId = item.transactional_account_id,
                Verified = item.verified,
                VerifiedBy = item.verified_by,
                VerifiedDate = item.verified_date,
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
			var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var obj = (from item in query
                       join c in Entities.customers on item.customer_id equals c.id
                       join p in (from p in Entities.payment_type where p.rowstatus.Equals(true) select p) on item.payment_type_id equals p.id
                       join m in (from m in Entities.employees where m.rowstatus.Equals(true) select m) on item.marketing_id equals m.id into mx
                       from m in mx.DefaultIfEmpty()
                       //where item.mc_percent > 0 || item.mc_fixed > 0
                       select new PaymentInModel
			            {
				            Id = item.id,
				            Rowstatus = item.rowstatus,
				            Rowversion = item.rowversion,
				            DateProcess = item.date_process,
				            Code = item.code,
				            BranchId = item.branch_id,
				            PaymentTypeId = item.payment_type_id,
                            PaymentType = p.name,
				            Description = item.description,
				            CustomerId = item.customer_id,
				            CustomerName = c.name,
				            AccountId = item.account_id,
				            Amount = item.amount,
				            TotalInvoice = item.total_invoice,
				            Total = item.total,
				            Adjustment = item.adjustment,
				            TotalCredit = item.total_credit,
				            TotalOther = item.total_other,
				            RcPercent = item.rc_percent,
				            RcPercentTotal = item.rc_percent_total,
				            RcKg = item.rc_kg,
				            RcKgTotal = item.rc_kg_total,
				            RcFixed = item.rc_fixed,
				            RcTotal = item.rc_total,
				            PaidRc = item.paid_rc,
				            TotalPaymentRc = item.total_payment_rc,
				            MarketingId = item.marketing_id,
                            MarketingName = m!=null?m.name:"",
				            McPercent = item.mc_percent,
				            McPercentTotal = item.mc_percent_total,
				            McKg = item.mc_kg,
				            McKgTotal = item.mc_kg_total,
				            McFixed = item.mc_fixed,
				            McTotal = item.mc_total,
				            PaidMc = item.paid_mc,
				            TotalPaymentMc = item.total_payment_mc,
                            TransactionalAccountId = item.transactional_account_id,
                            Verified = item.verified,
                            VerifiedBy = item.verified_by,
                            VerifiedDate = item.verified_date,
				            Createddate = item.createddate,
				            Createdby = item.createdby,
                            CreatedPc = item.createdpc,
				            Modifieddate = item.modifieddate,
				            Modifiedby = item.modifiedby,
                            ModifiedPc = item.modifiedpc
			            });

			return (IEnumerable<T>) obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			
            var tquery = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();

		    var obj = (from item in query
		        join p in Entities.payment_type on item.payment_type_id equals p.id into py
		        from p in py.DefaultIfEmpty()
		        select new PaymentInModel
		        {
		            Id = item.id,
		            Rowstatus = item.rowstatus,
		            Rowversion = item.rowversion,
		            DateProcess = item.date_process,
		            Code = item.code,
		            BranchId = item.branch_id,
		            PaymentTypeId = item.payment_type_id,
                    PaymentType = p.name,
		            Description = item.description,
		            CustomerId = item.customer_id,
		            CustomerName = item.customer_name,
		            AccountId = item.account_id,
		            Amount = item.amount,
		            TotalInvoice = item.total_invoice,
		            Total = item.total,
		            Adjustment = item.adjustment,
		            TotalCredit = item.total_credit,
		            TotalOther = item.total_other,
		            RcPercent = item.rc_percent,
		            RcPercentTotal = item.rc_percent_total,
		            RcKg = item.rc_kg,
		            RcKgTotal = item.rc_kg_total,
		            RcFixed = item.rc_fixed,
		            RcTotal = item.rc_total,
		            PaidRc = item.paid_rc,
		            TotalPaymentRc = item.total_payment_rc,
		            MarketingId = item.marketing_id,
		            McPercent = item.mc_percent,
		            McPercentTotal = item.mc_percent_total,
		            McKg = item.mc_kg,
		            McKgTotal = item.mc_kg_total,
		            McFixed = item.mc_fixed,
		            McTotal = item.mc_total,
		            PaidMc = item.paid_mc,
		            TotalPaymentMc = item.total_payment_mc,
                    TransactionalAccountId = item.transactional_account_id,
                    Verified = item.verified,
                    VerifiedBy = item.verified_by,
                    VerifiedDate = item.verified_date,
		            Createddate = item.createddate,
		            Createdby = item.createdby,
                    CreatedPc = item.createdpc,
		            Modifieddate = item.modifieddate,
		            Modifiedby = item.modifiedby,
                    ModifiedPc = item.modifiedpc
		        });

            return (IEnumerable<T>) obj.ToList();
		}

        public IEnumerable<PaymentInJournal> DetailJournal(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from d in
                           (from d in Entities.payment_in_detail where d.rowstatus.Equals(true) select d)
                       join q in query on d.payment_in_id equals q.id
                       join p in
                           (from p in Entities.payment_type where p.rowstatus.Equals(true) select p)
                            on q.payment_type_id equals p.id
                       select new PaymentInJournal
                       {
                           Code = q.code,
                           DateProcces = d.date_process,
                           PaymentType = p.name,
                           Description = d.invoice_code,
                           Company = q.customer_name,
                           Balance = d.invoice_balance,
                           Total = d.payment,
                       }).ToList();

            return obj;
        }

        public IEnumerable<PaymentInJournal> ReportDetailJournal(DateTime? fromDate, DateTime? toDate, int? customerFromId, int? customerToId,
            int? paymentTypeId, int? branchId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClausesPICI = new List<string>();
            var whereClausesPICO = new List<string>();
            var whereClausesPIC = new List<string>();
            var whereClausesPI = new List<string>();
            var whereClausesPOCI = new List<string>();

            whereClausesPICI.Add("pici.rowstatus = @rowstatus");
            whereClausesPICO.Add("pico.rowstatus = @rowstatus");
            whereClausesPIC.Add("pic.rowstatus = @rowstatus");
            whereClausesPI.Add("pi.rowstatus = @rowstatus");
            whereClausesPOCI.Add("poci.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClausesPICI.Add("pici.date_process >= @fromDate");
                whereClausesPICO.Add("pico.date_process >= @fromDate");
                whereClausesPIC.Add("pic.date_process >= @fromDate");
                whereClausesPI.Add("pi.date_process >= @fromDate");
                whereClausesPOCI.Add("poci.date_process >= @fromDate");
                parameters.Add(new MySqlParameter("fromDate", ((DateTime)fromDate).ToString("yyyy-MM-dd") + " 00:00:01"));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClausesPICI.Add("pici.date_process <= @toDate");
                whereClausesPICO.Add("pico.date_process <= @toDate");
                whereClausesPIC.Add("pic.date_process <= @toDate");
                whereClausesPI.Add("pi.date_process <= @toDate");
                whereClausesPOCI.Add("poci.date_process <= @toDate");
                parameters.Add(new MySqlParameter("toDate", ((DateTime)toDate).ToString("yyyy-MM-dd") + " 23:59:59"));
            }

            if (customerFromId != null && customerFromId > 0)
            {
                whereClausesPICI.Add("pici.customer_id >= @customerFromId");
                whereClausesPICO.Add("pico.customer_id >= @customerFromId");
                whereClausesPIC.Add("pic.customer_id >= @customerFromId");
                whereClausesPI.Add("pi.customer_id >= @customerFromId");
                whereClausesPOCI.Add("poci.customer_id >= @customerFromId");
                parameters.Add(new MySqlParameter("customerFromId", customerFromId));
            }

            if (customerToId != null && customerToId > 0)
            {
                whereClausesPICI.Add("pici.customer_id <= @customerToId");
                whereClausesPICO.Add("pico.customer_id <= @customerToId");
                whereClausesPIC.Add("pic.customer_id <= @customerToId");
                whereClausesPI.Add("pi.customer_id <= @customerToId");
                whereClausesPOCI.Add("poci.customer_id <= @customerToId");
                parameters.Add(new MySqlParameter("customerToId", customerToId));
            }

            if (paymentTypeId != null && paymentTypeId > 0)
            {
                whereClausesPICI.Add("4 = @paymentTypeId");
                whereClausesPICO.Add("pico.payment_type_id = @paymentTypeId");
                whereClausesPIC.Add("4 = @paymentTypeId");
                whereClausesPI.Add("pi.payment_type_id = @paymentTypeId");
                whereClausesPOCI.Add("poci.payment_type_id = @paymentTypeId");
                parameters.Add(new MySqlParameter("paymentTypeId", paymentTypeId));
            }

            if (branchId != null && branchId > 0)
            {
                whereClausesPICI.Add("pici.branch_id = @branchId");
                whereClausesPICO.Add("pico.owner_branch_id = @branchId");
                whereClausesPIC.Add("pic.branch_id = @branchId");
                whereClausesPI.Add("pi.branch_id = @branchId");
                whereClausesPOCI.Add("poci.branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            string sql = @"SELECT code as 'Code', date_process as 'DateProcces', name as 'PaymentType', invoice_code as 'Description',
                            customer_name as 'Company', invoice_balance as 'Balance', payment as 'Total' FROM 
                            (
                                SELECT pici.code, pici.date_process, 'CASH' as 'name', picid.invoice_code, 'Not Available' as 'customer_name', 
                                picid.invoice_balance, picid.payment FROM payment_in_collect_in_detail picid
                                LEFT OUTER JOIN payment_in_collect_in pici ON pici.id = picid.payment_in_collect_in_id
                                WHERE " + string.Join(" AND ", whereClausesPICI) + @"
                                UNION ALL
                                SELECT pico.code, pico.date_process, pt.name, picod.invoice_code, 'Not Available' as 'customer_name', 
                                picod.invoice_balance, picod.payment FROM payment_in_collect_out_detail picod
                                LEFT OUTER JOIN payment_in_collect_out pico ON pico.id = picod.payment_in_collect_out_id
                                LEFT OUTER JOIN payment_type pt ON pt.id = pico.payment_type_id
                                WHERE " + string.Join(" AND ", whereClausesPICO) + @"
                                UNION ALL
                                SELECT pic.code, picd.date_process, 'CASH' as 'name', picd.invoice_code, 'Not Available' as 'customer_name', 
                                picd.invoice_balance, picd.payment FROM payment_in_counter_detail picd
                                LEFT OUTER JOIN payment_in_counter pic ON pic.id = picd.payment_in_counter_id
                                WHERE " + string.Join(" AND ", whereClausesPIC) + @"
                                UNION ALL
                                SELECT pi.code, pid.date_process, pt.name, pid.invoice_code, pi.customer_name, 
                                pid.invoice_balance, pid.payment FROM payment_in_detail pid
                                LEFT OUTER JOIN payment_in pi on pi.id = pid.payment_in_id
                                LEFT OUTER JOIN payment_type pt ON pt.id = pi.payment_type_id
                                WHERE " + string.Join(" AND ", whereClausesPI) + @"
                                UNION ALL
                                SELECT poci.code, poci.date_process, pt.name, pocid.invoice_code, 'Not Available',
                                pocid.invoice_balance, pocid.payment FROM payment_out_collect_in_detail pocid
                                LEFT OUTER JOIN payment_out_collect_in poci on poci.id = pocid.payment_out_collect_in_id
                                LEFT OUTER JOIN payment_type pt ON pt.id = poci.payment_type_id
                                WHERE " + string.Join(" AND ", whereClausesPOCI) + @"
                            ) PAYMENT ORDER BY date_process";
            //+ " LIMIT 99999";

            return Entities.ExecuteStoreQuery<PaymentInJournal>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<PaymentInModel> Rc(IListParameter[] parameter, DateTime asofDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var ps = (from d in Entities.payment_rc_detail
                where d.rowstatus.Equals(true) && d.date_process <= asofDate
                group d by d.invoice_id
                into gs
                select new {invoice_id = gs.Key, total = gs.Sum(a => a.payment)}).ToList();

            var pr = (from r in Entities.payment_rc_detail
                join e in Entities.payment_rc on r.payment_rc_id equals e.id
                where r.rowstatus.Equals(true) && r.date_process <= asofDate && e.rowstatus.Equals(true)
                select new {r.payment, e.id, r.invoice_id, e.code, r.date_process, e.description}).ToList();

            var obj = (from q in query
                join d in ps on q.id equals d.invoice_id into px from d in px.DefaultIfEmpty()
                join r in pr on q.id equals r.invoice_id into rx from r in rx.DefaultIfEmpty()
                join c in Entities.customers on q.customer_id equals c.id
                select new PaymentInModel
                {
                    Id = q.id,
		            Rowstatus = q.rowstatus,
		            Rowversion = q.rowversion,
		            BranchId = q.branch_id,
		            PaymentTypeId = q.payment_type_id,
		            CustomerId = q.customer_id,
                    CustomerName = c.code + " " + c.name,
		            AccountId = q.account_id,
		            Amount = q.amount,
		            TotalInvoice = q.total_invoice,
		            Total = q.total,
		            Adjustment = q.adjustment,
		            TotalCredit = q.total_credit,
		            TotalOther = q.total_other,
		            MarketingId = q.marketing_id,
		            McPercent = q.mc_percent,
		            McPercentTotal = q.mc_percent_total,
		            McKg = q.mc_kg,
		            McKgTotal = q.mc_kg_total,
		            McFixed = q.mc_fixed,
		            McTotal = q.mc_total,
		            PaidMc = q.paid_mc,
		            TotalPaymentMc = q.total_payment_mc,
		            Createddate = q.createddate,
		            Createdby = q.createdby,
                    CreatedPc = q.createdpc,
		            Modifieddate = q.modifieddate,
		            Modifiedby = q.modifiedby,
                    ModifiedPc = q.modifiedpc,
                    DateProcess = q.date_process,
                    Code = q.code,
                    Description = q.description,
                    RcPercent = q.rc_percent,
                    RcPercentTotal = q.rc_percent_total,
                    RcKg = q.rc_kg,
                    RcKgTotal = q.rc_kg_total,
                    RcFixed = q.rc_fixed,
                    RcTotal = q.rc_total,
                    PaidRc = q.paid_rc,
                    TotalPaymentRc = d==null?0:d.total,
                    TransactionalAccountId = q.transactional_account_id,
                    Verified = q.verified,
                    VerifiedBy = q.verified_by,
                    VerifiedDate = q.verified_date,
                    Balance = d!=null?q.rc_total - d.total:q.rc_total,
                    ReportCode = r==null?"":r.code,
                    ReportDate = r==null?(DateTime?) null:r.date_process,
                    ReportPayment = r==null?0:r.payment,
                    ReportDescription = r!=null?r.description:"",
                }).ToList();

            return obj.Where(d => d.Balance.GetValueOrDefault() > 0).ToList();
        }

        public IEnumerable<PaymentInModel> PaidRc(IListParameter[] parameter, DateTime asofDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var ps = (from d in Entities.payment_rc_detail
                      where d.rowstatus.Equals(true) && d.date_process <= asofDate
                      group d by d.invoice_id
                          into gs
                          select new { invoice_id = gs.Key, total = gs.Sum(a => a.payment) }).ToList();

            var pr = (from r in Entities.payment_rc_detail
                      join e in Entities.payment_rc on r.payment_rc_id equals e.id
                      where r.rowstatus.Equals(true) && r.date_process <= asofDate && e.rowstatus.Equals(true)
                      select new { r.payment, e.id, r.invoice_id, e.code, r.date_process }).ToList();

            var obj = (from q in query
                       join d in ps on q.id equals d.invoice_id
                       join r in pr on q.id equals r.invoice_id
                       where q.rc_total == d.total
                       select new PaymentInModel
                       {
                           Id = q.id,
                           Rowstatus = q.rowstatus,
                           Rowversion = q.rowversion,
                           BranchId = q.branch_id,
                           PaymentTypeId = q.payment_type_id,
                           CustomerId = q.customer_id,
                           AccountId = q.account_id,
                           Amount = q.amount,
                           TotalInvoice = q.total_invoice,
                           Total = q.total,
                           Adjustment = q.adjustment,
                           TotalCredit = q.total_credit,
                           TotalOther = q.total_other,
                           MarketingId = q.marketing_id,
                           McPercent = q.mc_percent,
                           McPercentTotal = q.mc_percent_total,
                           McKg = q.mc_kg,
                           McKgTotal = q.mc_kg_total,
                           McFixed = q.mc_fixed,
                           McTotal = q.mc_total,
                           PaidMc = q.paid_mc,
                           TotalPaymentMc = q.total_payment_mc,
                           Createddate = q.createddate,
                           Createdby = q.createdby,
                           CreatedPc = q.createdpc,
                           Modifieddate = q.modifieddate,
                           Modifiedby = q.modifiedby,
                           ModifiedPc = q.modifiedpc,
                           DateProcess = q.date_process,
                           Code = q.code,
                           Description = q.description,
                           CustomerName = q.customer_name,
                           RcPercent = q.rc_percent,
                           RcPercentTotal = q.rc_percent_total,
                           RcKg = q.rc_kg,
                           RcKgTotal = q.rc_kg_total,
                           RcFixed = q.rc_fixed,
                           RcTotal = q.rc_total,
                           PaidRc = q.paid_rc,
                           TotalPaymentRc = d.total,
                           TransactionalAccountId = q.transactional_account_id,
                           Verified = q.verified,
                           VerifiedBy = q.verified_by,
                           VerifiedDate = q.verified_date,
                           Balance = q.rc_total - d.total,
                           ReportCode = r == null ? "" : r.code,
                           ReportDate = r == null ? (DateTime?)null : r.date_process,
                           ReportPayment = r == null ? 0 : r.payment
                       }).ToList();

            return obj;
        }

        public IEnumerable<PaymentInModel> OutstandingRc(IListParameter[] parameter, DateTime asofDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var ps = (from d in Entities.payment_rc_detail
                where d.rowstatus.Equals(true) && d.date_process <= asofDate
                group d by new {d.invoice_id, d.invoice_total}
                into gs
                select new {gs.Key.invoice_id, rc_total = gs.Key.invoice_total, total = gs.Sum(a => a.payment)}).Where(
                    p => p.rc_total != p.total).ToList();

            var pr = (from p in ps
                join d in Entities.payment_rc_detail on p.invoice_id equals d.invoice_id
                join m in Entities.payment_rc on d.payment_rc_id equals m.id
                select new
                {
                    d.invoice_id,
                    m.date_process,
                    p.total,
                    m.code,
                    d.payment
                }).ToList();

            var obj = (from q in query
                join c in Entities.customers on q.customer_id equals c.id
                join r in pr on q.id equals r.invoice_id into rx
                from r in rx.DefaultIfEmpty()
                select new PaymentInModel
                {
                    Id = q.id,
                    Code = q.code,
                    DateProcess = q.date_process,
                    Description = q.description,
                    CustomerName = c.code + " " + q.customer_name,
                    RcPercent = q.rc_percent,
                    RcPercentTotal = q.rc_percent_total,
                    RcKg = q.rc_kg,
                    RcKgTotal = q.rc_kg_total,
                    RcFixed = q.rc_fixed,
                    RcTotal = q.rc_total,
                    PaidRc = q.paid_rc,
                    TotalPaymentRc = r != null ? r.total : 0,
                    Balance = r != null ? q.rc_total - r.total : q.rc_total,
                    ReportCode = r == null ? "" : r.code,
                    ReportDate = r == null ? (DateTime?)null : r.date_process,
                    ReportPayment = r == null ? 0 : r.payment
                }).ToList();

            return obj.Where(r => r.Balance.GetValueOrDefault() > 0).ToList();
        }

        public IEnumerable<PaymentInModel> Mc(IListParameter[] parameter, DateTime asofDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var ps = (from d in Entities.payment_mc_detail
                      where d.rowstatus.Equals(true) && d.date_process <= asofDate
                      group d by d.invoice_id
                          into gs
                          select new { invoice_id = gs.Key, total = gs.Sum(a => a.payment) }).ToList();

            var pr = (from r in Entities.payment_mc_detail
                      join e in Entities.payment_mc on r.payment_mc_id equals e.id
                      where r.rowstatus.Equals(true) && r.date_process <= asofDate && e.rowstatus.Equals(true)
                      select new { r.payment, e.id, r.invoice_id, e.code, r.date_process }).ToList();

            var obj = (from q in query
                       join d in ps on q.id equals d.invoice_id into px
                       from d in px.DefaultIfEmpty()
                       join r in pr on q.id equals r.invoice_id into rx
                       from r in rx.DefaultIfEmpty()
                       select new PaymentInModel
                       {
                           Id = q.id,
                           Rowstatus = q.rowstatus,
                           Rowversion = q.rowversion,
                           BranchId = q.branch_id,
                           PaymentTypeId = q.payment_type_id,
                           CustomerId = q.customer_id,
                           AccountId = q.account_id,
                           Amount = q.amount,
                           TotalInvoice = q.total_invoice,
                           Total = q.total,
                           Adjustment = q.adjustment,
                           TotalCredit = q.total_credit,
                           TotalOther = q.total_other,
                           MarketingId = q.marketing_id,
                           McPercent = q.mc_percent,
                           McPercentTotal = q.mc_percent_total,
                           McKg = q.mc_kg,
                           McKgTotal = q.mc_kg_total,
                           McFixed = q.mc_fixed,
                           McTotal = q.mc_total,
                           PaidMc = q.paid_mc,
                           TotalPaymentMc = d == null ? 0 : d.total,
                           Createddate = q.createddate,
                           Createdby = q.createdby,
                           CreatedPc = q.createdpc,
                           Modifieddate = q.modifieddate,
                           Modifiedby = q.modifiedby,
                           ModifiedPc = q.modifiedpc,
                           DateProcess = q.date_process,
                           Code = q.code,
                           Description = q.description,
                           CustomerName = q.customer_name,
                           RcPercent = q.rc_percent,
                           RcPercentTotal = q.rc_percent_total,
                           RcKg = q.rc_kg,
                           RcKgTotal = q.rc_kg_total,
                           RcFixed = q.rc_fixed,
                           RcTotal = q.rc_total,
                           PaidRc = q.paid_rc,
                           TotalPaymentRc = q.total_payment_rc,
                           TransactionalAccountId = q.transactional_account_id,
                           ReportCode = r == null ? "" : r.code,
                           ReportDate = r == null ? (DateTime?)null : r.date_process,
                           ReportPayment = r == null ? 0 : r.payment
                       }).ToList();

            return obj;
        }

        public IEnumerable<PaymentInModel> PaidMc(IListParameter[] parameter, DateTime asofDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var ps = (from d in Entities.payment_mc_detail
                      where d.rowstatus.Equals(true) && d.date_process <= asofDate
                      group d by d.invoice_id
                          into gs
                          select new { invoice_id = gs.Key, total = gs.Sum(a => a.payment) }).ToList();

            var pr = (from r in (from r in Entities.payment_mc_detail where r.rowstatus.Equals(true) && r.date_process <= asofDate select r)
                      join e in (from e in Entities.payment_mc where e.rowstatus.Equals(true) select e) on r.payment_mc_id equals e.id
                      select new { r.payment, e.id, r.invoice_id, e.code, r.date_process }).ToList();

            var obj = (from q in query
                       join d in ps on q.id equals d.invoice_id
                       join r in pr on q.id equals r.invoice_id
                       where q.mc_total == d.total
                       select new PaymentInModel
                       {
                           Id = q.id,
                           Rowstatus = q.rowstatus,
                           Rowversion = q.rowversion,
                           BranchId = q.branch_id,
                           PaymentTypeId = q.payment_type_id,
                           CustomerId = q.customer_id,
                           AccountId = q.account_id,
                           Amount = q.amount,
                           TotalInvoice = q.total_invoice,
                           Total = q.total,
                           Adjustment = q.adjustment,
                           TotalCredit = q.total_credit,
                           TotalOther = q.total_other,
                           MarketingId = q.marketing_id,
                           McPercent = q.mc_percent,
                           McPercentTotal = q.mc_percent_total,
                           McKg = q.mc_kg,
                           McKgTotal = q.mc_kg_total,
                           McFixed = q.mc_fixed,
                           McTotal = q.mc_total,
                           PaidMc = q.paid_mc,
                           TotalPaymentMc = d.total,
                           Createddate = q.createddate,
                           Createdby = q.createdby,
                           CreatedPc = q.createdpc,
                           Modifieddate = q.modifieddate,
                           Modifiedby = q.modifiedby,
                           ModifiedPc = q.modifiedpc,
                           DateProcess = q.date_process,
                           Code = q.code,
                           Description = q.description,
                           CustomerName = q.customer_name,
                           RcPercent = q.rc_percent,
                           RcPercentTotal = q.rc_percent_total,
                           RcKg = q.rc_kg,
                           RcKgTotal = q.rc_kg_total,
                           RcFixed = q.rc_fixed,
                           RcTotal = q.rc_total,
                           PaidRc = q.paid_rc,
                           TotalPaymentRc = q.total_payment_rc,
                           TransactionalAccountId = q.transactional_account_id,
                           ReportCode = r == null ? "" : r.code,
                           ReportDate = r == null ? (DateTime?)null : r.date_process,
                           ReportPayment = r == null ? 0 : r.payment
                       }).ToList();

            return obj;
        }

        public IEnumerable<PaymentInModel> OutstandingMc(IListParameter[] parameter, DateTime asofDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var ps = (from d in Entities.payment_mc_detail
                      where d.rowstatus.Equals(true) && d.date_process <= asofDate
                      group d by d.invoice_id
                          into gs
                          select new { invoice_id = gs.Key, total = gs.Sum(a => a.payment) }).ToList();

            var pr = (from r in (from r in Entities.payment_mc_detail where r.rowstatus.Equals(true) && r.date_process <= asofDate select r)
                      join e in (from e in Entities.payment_mc where e.rowstatus.Equals(true) select e) on r.payment_mc_id equals e.id
                      join p in (from p in Entities.payment_in where p.rowstatus.Equals(true) select p) on r.invoice_id equals p.id
                      join m in (from m in Entities.employees where m.rowstatus.Equals(true) && m.as_marketing.Equals(true) select m) on e.marketing_id equals m.id into mx
                      from m in mx.DefaultIfEmpty()
                      join pd in (from pd in Entities.payment_in_detail where pd.rowstatus.Equals(true) select pd) on p.id equals pd.invoice_id
                      select new { r.payment, e.id, r.invoice_id, pd.invoice_ref_number, pd.date_process, m.name, p.customer_name }).ToList();

            var obj1 = (from q in query
                        join d in ps on q.id equals d.invoice_id into px
                        from d in px.DefaultIfEmpty()
                        select new
                        {
                            Id = q.id,
                            DateProcess = q.date_process,
                            Code = q.code,
                            Description = q.description,
                            CustomerName = q.customer_name,
                            McPercent = q.mc_percent,
                            McPercentTotal = q.mc_percent_total,
                            McKg = q.mc_kg,
                            McKgTotal = q.mc_kg_total,
                            McFixed = q.mc_fixed,
                            McTotal = q.mc_total,
                            PaidMc = q.paid_mc,
                            TotalPaymentMc = d != null ? d.total : 0
                        }).ToList().Where(p => p.McTotal != p.TotalPaymentMc);

            var obj = (from q in obj1
                       join r in pr on q.Id equals r.invoice_id into rx                       
                       from r in rx.DefaultIfEmpty()
                       select new PaymentInModel
                       {
                           Id = q.Id,
                           DateProcess = q.DateProcess,
                           Code = q.Code,
                           Description = q.Description,
                           CustomerCode = r!= null ? r.customer_name : "",
                           CustomerName = q.CustomerName,
                           MarketingName = r!= null ? r.name : "",
                           McPercent = q.McPercent,
                           McPercentTotal = q.McPercentTotal,
                           McKg = q.McKg,
                           McKgTotal = q.McKgTotal,
                           McFixed = q.McFixed,
                           McTotal = q.McTotal,
                           PaidMc = q.PaidMc,
                           TotalPaymentMc = q.TotalPaymentMc,
                           ReportCode = r == null ? "" : r.invoice_ref_number,
                           ReportDate = r == null ? (DateTime?)null : r.date_process,
                           ReportPayment = r == null ? 0 : r.payment
                       }).ToList();

            return obj;
        }

        public IEnumerable<OutstandingPph23> OutstandingPph (int? fakturId, DateTime? from, DateTime? to, int? customerId)
        {
            var sql = @"SELECT 
	                        p.date_process DateProcess,
                            si.ref_number RefNumber,
                            si.company_id CompanyId,
                            si.company_invoiced_to Company,
                            si.total TotalInvoice,
                            pid.total_pph23 TotalPph,
                            1 PayType
                        FROM sales_invoice si 
                        INNER JOIN payment_in_detail pid ON si.id = pid.invoice_id AND pid.rowstatus = 1 AND pid.use_pph23 = 1 AND pid.is_returned = 0
                        INNER JOIN payment_in p ON pid.payment_in_id = p.id AND p.rowstatus = 1
                        LEFT JOIN other_invoice oi ON si.ref_number = oi.ref_number AND oi.rowstatus = 1
                        LEFT JOIN other_invoice_payment_in_detail oipid ON oi.id = oipid.invoice_id AND oipid.rowstatus = 1
                        LEFT JOIN other_invoice_payment_in oipi ON oipid.other_invoice_payment_in_id = oipi.id AND oipi.rowstatus = 1
                        WHERE {0}

                        UNION 

                        SELECT
	                        oipid.date_process DateProcess,
                            si.ref_number RefNumber,
                            si.company_id CompanyId,
                            si.company_invoiced_to Company,
                            si.total TotalInvoice,
                            oipid.total_pph23 TotalPph,
                            2 PayType
                        FROM sales_invoice si
                        INNER JOIN other_invoice oi ON si.ref_number = oi.ref_number AND oi.rowstatus = 1
                        INNER JOIN other_invoice_payment_in_detail oipid ON oi.id = oipid.invoice_id AND oipid.rowstatus = 1 AND oipid.use_pph23 = 1 AND oipid.is_returned = 0
                        INNER JOIN other_invoice_payment_in oipi ON oipid.other_invoice_payment_in_id = oipi.id AND oipi.rowstatus = 1
                        LEFT JOIN siscodb.payment_in_detail pid ON si.id = pid.invoice_id AND pid.rowstatus = 1
                        LEFT JOIN siscodb.payment_in pi ON pid.payment_in_id = pi.id AND pi.rowstatus = 1
                        WHERE {1};";

            var param1 = new List<string>();
            var param2 = new List<string>();

            var sqlparam = new List<MySqlParameter>();

            param1.Add("si.rowstatus = 1");
            param2.Add("si.rowstatus = 1");

            if (fakturId != null)
            {
                param1.Add("si.tax_invoice_id = @fakturId");
                param2.Add("si.tax_invoice_id = @fakturId");
                sqlparam.Add(new MySqlParameter("fakturId", fakturId));
            }

            if (from != null)
            {
                param1.Add(string.Format("p.date_process >= '{0}'", ((DateTime)from).ToString("yyyy-MM-dd 00:00:00")));
                param2.Add(string.Format("oipi.date_process >= '{0}'", ((DateTime)from).ToString("yyyy-MM-dd 00:00:00")));
            }

            if (to != null)
            {
                param1.Add(string.Format("p.date_process <= '{0}'", ((DateTime)to).ToString("yyyy-MM-dd 23:59:59")));
                param2.Add(string.Format("oipi.date_process <= '{0}'", ((DateTime)to).ToString("yyyy-MM-dd 23:59:59")));
            }

            if (customerId != null)
            {
                param1.Add("si.company_id = @customerId");
                param2.Add("si.company_id = @customerId");
                sqlparam.Add(new MySqlParameter("customerId", customerId));
            }

            param1.Add("(oi.id IS NULL AND oipi.id IS NULL AND oipid.id IS NULL)");
            param2.Add("(pid.id IS NULL AND pi.id IS NULL)");

            sql = string.Format(sql, string.Join(" AND ", param1), string.Join(" AND ", param2));

            return Entities.ExecuteStoreQuery<OutstandingPph23>(sql, sqlparam.ToArray()).ToList();
        }

        public List<PaymentInModel> GetInvoiceMarketing(int marketingId)
        {
            var sql = @"SELECT 
	                        pi.id Id,
                            pi.rowstatus Rowstatus,
                            pi.rowversion Rowversion,
                            pi.date_process DateProcess,
                            pi.code Code,
                            pi.branch_id BranchId,
                            pi.payment_type_id PaymentTypeId,
                            pi.description Description,
                            pi.customer_id CustomerId,
                            pi.customer_name CustomerName,
                            pi.account_id AccountId,
                            pi.amount Amount,
                            pi.total_invoice TotalInvoice,
                            pi.total Total,
                            pi.adjustment Adjustment,
                            pi.total_credit TotalCredit,
                            pi.total_other TotalOther,
                            pi.rc_percent RcPercent,
                            pi.rc_percent_total RcPercentTotal,
                            pi.rc_kg RcKg,
                            pi.rc_kg_total RcKgTotal,
                            pi.rc_fixed RcFixed,
                            pi.rc_total RcTotal,
                            pi.paid_rc PaidRc,
                            pi.total_payment_rc TotalPaymentRc,
                            e.id MarketingId,
                            pi.mc_percent McPercent,
                            pi.mc_percent_total McPercentTotal,
                            pi.mc_kg McKg,
                            pi.mc_kg_total McKgTotal,
                            pi.mc_fixed McFixed,
                            pi.mc_total McTotal,
                            pi.paid_mc PaidMc,
                            pi.total_payment_mc TotalPaymentMc,
                            pi.transactional_account_id TransactionalAccountId,
                            pi.verified Verified,
                            pi.verified_by VerifiedBy,
                            pi.verified_date VerifiedDate,
                            pi.createddate Createddate,
                            pi.createdby Createdby,
                            pi.createdpc CreatedPc,
                            pi.modifieddate Modifieddate,
                            pi.modifiedby Modifiedby,
                            pi.modifiedpc ModifiedPc
                        FROM payment_in pi
                        INNER JOIN customer c ON pi.customer_id = c.id
                        INNER JOIN employee e ON c.marketing_employee_id = e.id
                        WHERE pi.rowstatus = 1 AND e.id = @marketingId and pi.mc_total > 0;";

            return Entities.ExecuteStoreQuery<PaymentInModel>(sql, new MySqlParameter("marketingId", marketingId)).ToList();
        }
    }
}