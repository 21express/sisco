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
    public class PaymentRcRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentRc";
        public PaymentRcRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PaymentRcRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PaymentRcModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopayment_rc(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PaymentRcModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.payment_rc where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentRcModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_rc select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_rc where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.payment_rc where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static payment_rc PopulateModelToNewEntity(PaymentRcModel model)
		{
			return new payment_rc
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
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(payment_rc query, PaymentRcModel model)
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
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static PaymentRcModel PopulateEntityToNewModel(payment_rc item)
		{
			return new PaymentRcModel
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
			var query = (from a in Entities.payment_rc select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join p in Entities.payment_type on item.payment_type_id equals p.id
                select new PaymentRcModel
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
                    CompanyName = item.company_name,
                    AccountId = item.account_id,
                    Amount = item.amount,
                    TotalInvoice = item.total_invoice,
                    Total = item.total,
                    Adjustment = item.adjustment,
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
			var query = (from a in Entities.payment_rc select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_rc select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.payment_rc select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<PaymentInJournal> DetailJournal(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_rc select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from d in
                           (from d in Entities.payment_rc_detail where d.rowstatus.Equals(true) select d)
                       join q in query on d.payment_rc_id equals q.id
                       join p in
                           (from p in Entities.payment_type where p.rowstatus.Equals(true) select p) on q.payment_type_id
                           equals p.id
                       select new PaymentInJournal
                       {
                           Code = q.code,
                           DateProcces = d.date_process,
                           PaymentType = p.name,
                           Description = d.invoice_code,
                           Company = q.company_name,
                           Balance = d.invoice_balance,
                           Total = d.payment
                       }).ToList();

            return obj;
        }
    }
}