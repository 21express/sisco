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
    public class PaymentDeliveryRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentDelivery";
        public PaymentDeliveryRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PaymentDeliveryRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PaymentDeliveryModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopayment_delivery(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PaymentDeliveryModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.payment_delivery where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentDeliveryModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_delivery select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_delivery where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.payment_delivery where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static payment_delivery PopulateModelToNewEntity(PaymentDeliveryModel model)
		{
			return new payment_delivery
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
                owner_branch_id = model.OwnerBranchId,
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
        
        private static void PopulateModelToNewEntity(payment_delivery query, PaymentDeliveryModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
            query.owner_branch_id = model.OwnerBranchId;
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
        
        private static PaymentDeliveryModel PopulateEntityToNewModel(payment_delivery item)
		{
			return new PaymentDeliveryModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
                OwnerBranchId = item.owner_branch_id,
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
			var query = (from a in Entities.payment_delivery select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join p in Entities.payment_type on item.payment_type_id equals p.id
                select new PaymentDeliveryModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    OwnerBranchId = item.owner_branch_id,
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
			var query = (from a in Entities.payment_delivery select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_delivery select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.payment_delivery select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<ReportDeliveryJournal> Delivery(IEnumerable<ShipmentModel> shipment, DateTime asOfDate)
        {
            var xx = (from d in (from d in Entities.payment_delivery_detail where d.rowstatus.Equals(true) && d.date_process <= asOfDate select d)
                join m in Entities.payment_delivery on d.payment_delivery_id equals m.id
                join x in (
                    from dx in (from dx in Entities.payment_delivery_detail where dx.rowstatus.Equals(true) select dx)
                    group dx by dx.invoice_id
                    into gs
                    select new {id = gs.Key, total = gs.Sum(a => a.payment)}
                    ) on d.invoice_id equals x.id
                select new
                {
                    d.invoice_id,
                    m.date_process,
                    m.code,
                    m.description,
                    d.payment,
                    x.total
                }).ToList();

            var obj = (from s in shipment
                       join b in Entities.branches on s.DestBranchId equals b.id
                       join g in xx on s.Id equals g.invoice_id into gx
                        from g in gx.DefaultIfEmpty()
                       select new ReportDeliveryJournal
                       {
                           branch_name = b.name,
                           branch_id = b.id,
                           code = s.Code,
                           date_process = s.DateProcess,
                           description = g != null ? g.description : "",
                           delivery_fee_total = s.DeliveryFeeTotal,
                           report_code = g != null ? g.code : "",
                           report_date = g != null ? g.date_process : (DateTime?) null,
                           payment = g != null ? g.total : 0,
                           balance = g != null ? s.DeliveryFeeTotal - g.total : s.DeliveryFeeTotal,
                           totalpayment = g != null ? g.payment : 0
                       });

            return obj.ToList();
        }

        public IEnumerable<ReportDeliveryJournal> PaidDelivery(IListParameter[] parameter, DateTime asofDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray());
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from s in
                           (
                                from s in query where s.delivery_fee_total > 0
                                join g in
                                   (
                                      from dx in
                                          (from dx in Entities.payment_delivery_detail where dx.rowstatus.Equals(true) select dx)
                                      group dx by dx.invoice_id into gs
                                      select new { id = gs.Key, total = gs.Sum(a => a.payment) }
                                   ) on s.id equals g.id
                                   where s.delivery_fee_total == g.total
                                   select new {s.id, s.dest_branch_id, s.code, s.date_process, s.delivery_fee_total, g.total}
                            )
                       join d in
                           (
                            from d in
                                (from d in Entities.payment_delivery_detail where d.rowstatus.Equals(true) select d)
                            join q in (from j in Entities.payment_delivery where j.rowstatus.Equals(true) select j) on d.payment_delivery_id equals q.id
                            where d.date_process <= asofDate
                            select new { del_code = q.code, del_date = d.date_process, d.invoice_id, d.payment, d.balance, q.description }
                           ) on s.id equals d.invoice_id
                       join b in Entities.branches on s.dest_branch_id equals b.id
                       select new ReportDeliveryJournal
                       {
                           dest_branch_name = b.name,
                           dest_branch_id = b.id,
                           code = s.code,
                           description = d.description,
                           date_process = s.date_process,
                           delivery_fee_total = s.delivery_fee_total,
                           report_code = d.del_code,
                           report_date = d.del_date,
                           payment = d.payment,
                           balance = d.balance,
                           totalpayment = s.total
                       });

            return obj.ToList();
        }

        public IEnumerable<ReportDeliveryJournal> OutstandingDelivery(IListParameter[] parameter, DateTime asofDate, IList<int> branch_ids)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = branch_ids.Count > 0 ? (from a in Entities.shipments where branch_ids.Contains((int)a.dest_branch_id) select a).Where(whereterm, ListValue.ToArray()) : (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray());
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var x = (
                from s in query
                join g in
                    (
                        from dx in
                            (from dx in Entities.payment_delivery_detail where dx.rowstatus.Equals(true) select dx)
                        group dx by dx.invoice_id
                        into gs
                        select new {id = gs.Key, total = (int?)gs.Sum(a => a.payment)}
                        ) on s.invoice_id equals g.id into gs
                from g in gs.DefaultIfEmpty()
                select
                    new
                    {
                        s.id,
                        s.dest_branch_id,
                        s.code,
                        s.date_process,
                        s.delivery_fee_total,
                        total = g.total ?? 0
                    }
                ).Where(g => g.delivery_fee_total != g.total).ToList();
            //var sql = ((System.Data.Objects.ObjectQuery)x).ToTraceString();
            var obj = (from s in x
                       join d in
                           (
                            from d in
                                (from d in Entities.payment_delivery_detail where d.rowstatus.Equals(true) select d)
                            join q in
                                (from j in Entities.payment_delivery where j.rowstatus.Equals(true) select j) on d.payment_delivery_id equals q.id
                            where d.date_process <= asofDate
                            select new { del_code = q.code, del_date = d.date_process, d.invoice_id, d.payment, d.balance, q.description }
                           ) on s.id equals d.invoice_id into ds
                           from d in ds.DefaultIfEmpty()
                       join b in Entities.branches on s.dest_branch_id equals b.id
                       select new ReportDeliveryJournal
                       {
                           dest_branch_name = b.name,
                           dest_branch_id = b.id,
                           code = s.code,
                           description = d!= null ? d.description : "",
                           date_process = s.date_process,
                           delivery_fee_total = s.delivery_fee_total,
                           report_code = d!= null ?d.del_code : "",
                           report_date = d!= null ?d.del_date : (DateTime?) null,
                           payment = d!= null ?d.payment : 0,
                           balance = s.delivery_fee_total-s.total,
                           totalpayment = s.total
                       });

            return obj.ToList();
        }

        public IEnumerable<PaymentInJournal> DetailJournals(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_delivery select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from d in
                           (from d in Entities.payment_delivery_detail where d.rowstatus.Equals(true) select d)
                       join q in query on d.payment_delivery_id equals q.id
                       join b in Entities.branches on q.branch_id equals b.id
                       join p in
                           (from p in Entities.payment_type where p.rowstatus.Equals(true) select p) on q.payment_type_id
                           equals p.id
                       select new PaymentInJournal
                       {
                           Code = q.code,
                           DateProcces = d.date_process,
                           PaymentType = p.name,
                           Description = d.invoice_code,
                           Company = b.code + " " + b.name,
                           Balance = d.balance,
                           Total = d.payment
                       }).ToList();

            return obj;
        }
    }
}