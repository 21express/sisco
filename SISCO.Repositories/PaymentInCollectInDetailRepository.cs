using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using Microsoft.SqlServer.Server;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class PaymentInCollectInDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentInCollectInDetail";
        public PaymentInCollectInDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PaymentInCollectInDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PaymentInCollectInDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopayment_in_collect_in_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PaymentInCollectInDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.payment_in_collect_in_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentInCollectInDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_in_collect_in_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_in_collect_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.payment_in_collect_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static payment_in_collect_in_detail PopulateModelToNewEntity(PaymentInCollectInDetailModel model)
		{
			return new payment_in_collect_in_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				payment_in_collect_in_id = model.PaymentInCollectInId,
                branch_id = model.BranchId,
				date_process = model.DateProcess,
				invoice_id = model.InvoiceId,
				invoice_date = model.InvoiceDate,
				invoice_code = model.InvoiceCode,
				invoice_total = model.InvoiceTotal,
				invoice_balance = model.InvoiceBalance,
				payment = model.Payment,
				balance = model.Balance,
				@checked = model.Checked,
				paid = model.Paid,
				collect_payment_method = model.CollectPaymentMethod,
				collect_customer_id = model.CollectCustomerId,
				collect_customer_name = model.CollectCustomerName,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(payment_in_collect_in_detail query, PaymentInCollectInDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.payment_in_collect_in_id = model.PaymentInCollectInId;
			query.date_process = model.DateProcess;
            query.branch_id = model.BranchId;
			query.invoice_id = model.InvoiceId;
			query.invoice_date = model.InvoiceDate;
			query.invoice_code = model.InvoiceCode;
			query.invoice_total = model.InvoiceTotal;
			query.invoice_balance = model.InvoiceBalance;
			query.payment = model.Payment;
			query.balance = model.Balance;
			query.@checked = model.Checked;
			query.paid = model.Paid;
			query.collect_payment_method = model.CollectPaymentMethod;
			query.collect_customer_id = model.CollectCustomerId;
			query.collect_customer_name = model.CollectCustomerName;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static PaymentInCollectInDetailModel PopulateEntityToNewModel(payment_in_collect_in_detail item)
		{
			return new PaymentInCollectInDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				PaymentInCollectInId = item.payment_in_collect_in_id,
                BranchId = item.branch_id,
				DateProcess = item.date_process,
				InvoiceId = item.invoice_id,
				InvoiceDate = item.invoice_date,
				InvoiceCode = item.invoice_code,
				InvoiceTotal = item.invoice_total,
				InvoiceBalance = item.invoice_balance,
				Payment = item.payment,
				Balance = item.balance,
				Checked = item.@checked,
				Paid = item.paid,
				CollectPaymentMethod = item.collect_payment_method,
				CollectCustomerId = item.collect_customer_id,
				CollectCustomerName = item.collect_customer_name,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<T>) (from item in query
                join m in Entities.payment_in_collect_in on item.payment_in_collect_in_id equals m.id
                select new PaymentInCollectInDetailModel
			    {
				    Id = item.id,
				    Rowstatus = item.rowstatus,
				    Rowversion = item.rowversion,
				    PaymentInCollectInId = item.payment_in_collect_in_id,
                    PaymentInCollectInCode = m.code,
                    BranchId = item.branch_id,
				    DateProcess = item.date_process,
				    InvoiceId = item.invoice_id,
				    InvoiceDate = item.invoice_date,
				    InvoiceCode = item.invoice_code,
				    InvoiceTotal = item.invoice_total,
				    InvoiceBalance = item.invoice_balance,
				    Payment = item.payment,
				    Balance = item.balance,
				    Checked = item.@checked,
				    Paid = item.paid,
				    CollectPaymentMethod = item.collect_payment_method,
				    CollectCustomerId = item.collect_customer_id,
				    CollectCustomerName = item.collect_customer_name,
				    Createddate = item.createddate,
				    Createdby = item.createdby,
				    Modifieddate = item.modifieddate,
				    Modifiedby = item.modifiedby,
                    StateChange2 = x
			    }
            ).AsQueryable();
			return obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.payment_in_collect_in_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentInCollectInModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_in_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.payment_in_collect_in_id equals m.Id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 Kwitansi = a.invoice_code
                                                             }).ToList();

            return obj;
        }

        public IEnumerable<PaymentInCollectInDetailModel> ReportUnInvoice(IEnumerable<PaymentInCollectInModel> master,
            IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                       join m in master on item.payment_in_collect_in_id equals m.Id
                       join s in (from s in Entities.shipments where s.invoiced.Equals(0) select s) on item.invoice_id equals s.id
                       select new PaymentInCollectInDetailModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           PaymentInCollectInId = item.payment_in_collect_in_id,
                           BranchId = item.branch_id,
                           DateProcess = item.date_process,
                           InvoiceId = item.invoice_id,
                           InvoiceDate = item.invoice_date,
                           InvoiceCode = item.invoice_code,
                           InvoiceTotal = item.invoice_total,
                           InvoiceBalance = item.invoice_balance,
                           Payment = item.payment,
                           Balance = item.balance,
                           Checked = item.@checked,
                           Paid = item.paid,
                           CollectPaymentMethod = item.collect_payment_method,
                           CollectCustomerId = item.collect_customer_id,
                           CollectCustomerName = item.collect_customer_name,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           ReportDescription = m.Description,
                           ReportTtlPiece = s.ttl_piece,
                           ReportTtlGrossWeight = s.ttl_gross_weight,
                           ReportTariff = s.tariff
                       }).AsQueryable();

            return obj.ToList();
        }

        public IEnumerable<CollectInReport> ReportCollectInBr(IEnumerable<ShipmentModel> shipment, DateTime asOfDate, int branchId)
        {
            var xx =
                (from s in (from s in Entities.payment_out_collect_in_detail where s.rowstatus.Equals(true) select s)
                    join x in
                        (from x in Entities.payment_out_collect_in
                            where x.rowstatus.Equals(true) && x.owner_branch_id == branchId
                            select x) on s.payment_out_collect_in_id equals x.id
                    join m in
                        (from d in Entities.payment_out_collect_in_detail
                                    where d.rowstatus.Equals(true) && d.date_process <= asOfDate
                         group d by new { d.invoice_id, d.invoice_total }
                             into g
                             select new
                             {
                                 g.Key.invoice_id,
                                 total_payment = g.Sum(x => x.payment)
                             }) on s.invoice_id equals m.invoice_id
                    select
                        new
                        {
                            x.code,
                            x.date_process,
                            s.invoice_id,
                            s.invoice_total,
                            m.total_payment,
                            s.payment,
                            x.description,
                            x.verified,
                            x.verified_date,
                            x.verified_by
                        }).ToList();

            var obj = (from item in shipment
                       join p in xx on item.Id equals p.invoice_id into px
                       from p in px.DefaultIfEmpty()
                       select new CollectInReport
                       {
                           DateProcess = item.DateProcess,
                           BranchName = item.BranchName,
                           //InvoiceId = item.Id,
                           //InvoiceDate = item.DateProcess,
                           //InvoiceCode = item.Code,
                           //InvoiceTotal = item.Total,
                           //Payment = p!=null? p.total_payment:0,
                           Balance = p!=null? item.Total - p.total_payment:item.Total,
                           ReportDescription = p!=null? p.description:"",
                           ReportPaymentOutCode = p!=null? p.code:"",
                           ReportPayment = p!=null? p.payment:0,
                           Verified = p!=null ? p.verified : false,
                           VerifiedDate = p!= null ? p.verified_date : null, 
                           VerifiedBy = p != null? p.verified_by : string.Empty
                       }).ToList();

            return obj;
        }

        public IEnumerable<CollectInReport> ReportCollectInBr(DateTime fromDate, DateTime toDate, DateTime asDateOf, int branchId, int paymentMethodId, List<int> branches)
        {
            var sql = @"SELECT
	                        s.date_process DateProcess,
                            s.code InvoiceCode,
                            b.name BranchName,
                            s.total InvoiceTotal,
                            IF (ref.total_payment > 0,s.total - ref.total_payment, s.total) Balance,
                            ref.description ReportDescription,
                            ref.date_process ReportPaymentDate,
                            ref.code ReportPaymentOutCode,
                            ref.total_payment ReportPayment,
                            IF (ref.code IS NULL, false, IF (ref.verified = 1, true, false)) Verified,
                            ref.verified_by VerifiedBy,
                            ref.verified_date VerifiedDate
                        FROM shipment s
                        INNER JOIN branch b ON s.branch_id = b.id
                        LEFT JOIN sales_invoice si ON s.invoice_id = si.id AND si.rowstatus = 1
                        LEFT JOIN (
	                        SELECT 
		                        poc.code,
		                        poc.date_process,
		                        pocd.invoice_id,
		                        pocd.invoice_total,
		                        pocd2.total_payment,
		                        poc.description,
		                        poc.verified,
		                        poc.verified_by,
		                        poc.verified_date
	                        FROM payment_out_collect_in_detail pocd
	                        INNER JOIN payment_out_collect_in poc ON poc.id = pocd.payment_out_collect_in_id AND poc.rowstatus = 1 AND poc.owner_branch_id = @branchId
	                        INNER JOIN (
		                        SELECT 
			                        invoice_id,
			                        SUM(payment) total_payment
		                        FROM payment_out_collect_in_detail
		                        WHERE rowstatus = 1 AND date_process < @asDateOf
		                        GROUP BY invoice_id
	                        ) pocd2 ON pocd.invoice_id = pocd2.invoice_id
	                        WHERE 
		                        pocd.rowstatus = 1
                        ) ref ON s.id = ref.invoice_id
                        WHERE
	                        s.rowstatus = 1 AND 
                            s.date_process >= @fromDate AND
                            s.date_process <= @toDate AND
                            s.dest_branch_id = @branchId AND 
                            s.payment_method_id = @paymentMethodId AND
	                        si.id IS NULL AND 
                            s.branch_id IN({0})";

            var list = new List<MySqlParameter>();
            list.Add(new MySqlParameter("branchId", branchId));
            list.Add(new MySqlParameter("fromDate", fromDate));
            list.Add(new MySqlParameter("toDate", toDate));
            list.Add(new MySqlParameter("paymentMethodId", paymentMethodId));
            list.Add(new MySqlParameter("asDateOf", asDateOf));
            //list.Add(new MySqlParameter("branches", string.Join(",",branches.ToArray())));

            sql = string.Format(sql, string.Join(",", branches));

            var result = Entities.ExecuteStoreQuery<CollectInReport>(sql, list.ToArray()).ToList();
            return result;
        }

        public IEnumerable<PaymentInCollectInDetailModel> OutstandingCollect(IEnumerable<PaymentInCollectInModel> master, IListParameter[] parameter, DateTime asOfDate, int branchId)
        {
            var outs = (from q in (from q in Entities.payment_out_collect_in where q.rowstatus.Equals(true) && q.branch_id == branchId select q)
                       join d in
                           (from d in Entities.payment_out_collect_in_detail where d.rowstatus.Equals(true) && d.date_process <= asOfDate select d) on q.id equals d.payment_out_collect_in_id
                       group d by new { d.invoice_id, d.invoice_total }
                           into g
                           select new
                           {
                               g.Key.invoice_total,
                               g.Key.invoice_id,
                               total_payment = g.Sum(x => x.payment)
                           }).Where(p => p.invoice_total == p.total_payment).ToList();

            var nots = (from dynamic o in outs select o.invoice_id).Cast<int>().ToList();

            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var out2 = (from d in Entities.payment_out_collect_in_detail
                where !nots.Contains(d.invoice_id)
                group d by new {d.invoice_id, d.invoice_total}
                into g
                select new
                {
                    g.Key.invoice_total,
                    g.Key.invoice_id,
                    total_payment = g.Sum(x => x.payment)
                }).ToList();

            var obj = (from item in (from item in query where item.invoice_id != null && !nots.Contains((int) item.invoice_id) select item)
                       join m in master on item.payment_in_collect_in_id equals m.Id
                       join s in Entities.shipments on item.invoice_id equals s.id
                       join b in Entities.branches on item.branch_id equals b.id
                       //join p in
                       //    (from p in Entities.payment_out_collect_in_detail where p.rowstatus.Equals(true) && p.date_process <= asOfDate && !nots.Contains(p.invoice_id) select p) on item.invoice_id equals p.invoice_id into pout
                       join p in out2 on item.invoice_id equals p.invoice_id into pout
                       from p in pout.DefaultIfEmpty()
                       select new PaymentInCollectInDetailModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           PaymentInCollectInId = item.payment_in_collect_in_id,
                           BranchId = item.branch_id,
                           BranchName = b.name,
                           DateProcess = item.date_process,
                           InvoiceId = item.invoice_id,
                           InvoiceDate = item.invoice_date,
                           InvoiceCode = item.invoice_code,
                           InvoiceTotal = item.invoice_total,
                           InvoiceBalance = item.invoice_balance,
                           //Payment = item.payment,
                           //Balance = item.balance,
                           Payment = p!= null ?p.total_payment :0,
                           Balance = p!= null?item.payment - p.total_payment:item.payment,
                           Checked = item.@checked,
                           Paid = item.paid,
                           CollectPaymentMethod = item.collect_payment_method,
                           CollectCustomerId = item.collect_customer_id,
                           CollectCustomerName = item.collect_customer_name,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           ReportDescription = m.Description,
                           ReportTtlPiece = s.ttl_piece,
                           ReportTtlGrossWeight = s.ttl_gross_weight,
                           ReportTariff = s.tariff,
                           //ReportPayment = p != null ? p.payment : 0,
                           //ReportBalance = p != null ? p.balance : 0,
                           //ReportPaymentOutDate = p != null ? p.date_process : (DateTime?)null,
                           //ReportPaymentOutCode = p != null ? p.payment_in_collect_in_code : string.Empty
                       }).ToList();

            return obj;
        }
    }
}