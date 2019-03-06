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
    public class PaymentInCounterRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentInCounter";
        public PaymentInCounterRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PaymentInCounterRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PaymentInCounterModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopayment_in_counter(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PaymentInCounterModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.payment_in_counter where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentInCounterModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_in_counter select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_in_counter where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.payment_in_counter where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static payment_in_counter PopulateModelToNewEntity(PaymentInCounterModel model)
		{
			return new payment_in_counter
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
				company_name = model.CompanyName,
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
        
        private static void PopulateModelToNewEntity(payment_in_counter query, PaymentInCounterModel model)
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
			query.company_name = model.CompanyName;
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
        
        private static PaymentInCounterModel PopulateEntityToNewModel(payment_in_counter item)
		{
			return new PaymentInCounterModel
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
				CompanyName = item.company_name,
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
			var query = (from a in Entities.payment_in_counter select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_counter select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_counter select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.payment_in_counter select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<PaymentInJournal> DetailJournal(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_in_counter select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from d in (from d in Entities.payment_in_counter_detail where d.rowstatus.Equals(true) select d)
                join q in query on d.payment_in_counter_id equals q.id
                select new PaymentInJournal
                {
                    Code = q.code,
                    DateProcces = d.date_process,
                    PaymentType = "CASH",
                    Description = d.invoice_code,
                    Company = "Not Available",
                    Balance = d.invoice_balance,
                    Total = d.payment
                }).ToList();

            return obj;
        }
    }
}