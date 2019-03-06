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
    public class OtherInvoiceRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "OtherInvoice";
        public OtherInvoiceRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public OtherInvoiceRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as OtherInvoiceModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToother_invoice(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as OtherInvoiceModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.other_invoice where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as OtherInvoiceModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.other_invoice select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.other_invoice where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.other_invoice where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static other_invoice PopulateModelToNewEntity(OtherInvoiceModel model)
		{
			return new other_invoice
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				ref_number = model.RefNumber,
				branch_id = model.BranchId,
                owner_branch_id = model.OwnerBranchId,
				due_date = model.DueDate,
				date_from = model.DateFrom,
				date_to = model.DateTo,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				total_sales = model.TotalSales,
				total_cost = model.TotalCost,
				total = model.Total,
				cancelled = model.Cancelled,
				in_paid = model.InPaid,
				in_total_payment = model.InTotalPayment,
				out_paid = model.OutPaid,
				out_total_payment = model.OutTotalPayment,
				description = model.Description,
                accept = model.Accept,
                accept_at = model.AcceptAt,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(other_invoice query, OtherInvoiceModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.ref_number = model.RefNumber;
			query.branch_id = model.BranchId;
            query.owner_branch_id = model.OwnerBranchId;
			query.due_date = model.DueDate;
			query.date_from = model.DateFrom;
			query.date_to = model.DateTo;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.total_sales = model.TotalSales;
			query.total_cost = model.TotalCost;
			query.total = model.Total;
			query.cancelled = model.Cancelled;
			query.in_paid = model.InPaid;
			query.in_total_payment = model.InTotalPayment;
			query.out_paid = model.OutPaid;
			query.out_total_payment = model.OutTotalPayment;
			query.description = model.Description;
            query.accept = model.Accept;
            query.accept_at = model.AcceptAt;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static OtherInvoiceModel PopulateEntityToNewModel(other_invoice item)
		{
			return new OtherInvoiceModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				RefNumber = item.ref_number,
				BranchId = item.branch_id,
                OwnerBranchId = item.owner_branch_id,
				DueDate = item.due_date,
				DateFrom = item.date_from,
				DateTo = item.date_to,
				CustomerId = item.customer_id,
				CustomerName = item.customer_name,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
				TotalSales = item.total_sales,
				TotalCost = item.total_cost,
				Total = item.total,
				Cancelled = item.cancelled,
				InPaid = item.in_paid,
				InTotalPayment = item.in_total_payment,
				OutPaid = item.out_paid,
				OutTotalPayment = item.out_total_payment,
				Description = item.description,
                Accept = item.accept,
                AcceptAt = item.accept_at,
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
			var query = (from a in Entities.other_invoice select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                       join b in Entities.branches on item.branch_id equals b.id
                       join b2 in Entities.branches on item.owner_branch_id equals b2.id
                       select new OtherInvoiceModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           DateProcess = item.date_process,
                           Code = item.code,
                           RefNumber = item.ref_number,
                           BranchId = item.branch_id,
                           BranchName = b.name,
                           OwnerBranchId = item.owner_branch_id,
                           OwnerBranch = b2.name,
                           DueDate = item.due_date,
                           DateFrom = item.date_from,
                           DateTo = item.date_to,
                           CustomerId = item.customer_id,
                           CustomerName = item.customer_name,
                           TtlPiece = item.ttl_piece,
                           TtlGrossWeight = item.ttl_gross_weight,
                           TtlChargeableWeight = item.ttl_chargeable_weight,
                           TotalSales = item.total_sales,
                           TotalCost = item.total_cost,
                           Total = item.total,
                           Cancelled = item.cancelled,
                           InPaid = item.in_paid,
                           InTotalPayment = item.in_total_payment,
                           OutPaid = item.out_paid,
                           OutTotalPayment = item.out_total_payment,
                           Description = item.description,
                           Accept = item.accept,
                           AcceptAt = item.accept_at,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           CreatedPc = item.createdpc,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           ModifiedPc = item.modifiedpc
                       });
			
            //return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return (IEnumerable<T>) obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.other_invoice select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<OtherInvoiceModel> ReportJournalCustomer(IListParameter[] parameter, DateTime asOfDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var pin =
                (from i in (from i in Entities.other_invoice_payment_in_detail where i.rowstatus.Equals(true) select i)
                    join m in (from m in Entities.other_invoice_payment_in where m.rowstatus.Equals(true) select m) on
                        i.other_invoice_payment_in_id equals m.id
                    where m.date_process <= asOfDate
                    group i by i.invoice_id
                          into gs
                          select new { invoice_id = gs.Key, total = gs.Sum(a => a.payment) }
                    ).ToList();

            /*var pir =
                (from i in
                     (from i in Entities.other_invoice_payment_in_detail where i.rowstatus.Equals(true) select i)
                 join m in
                     (from m in Entities.other_invoice_payment_in where m.rowstatus.Equals(true) select m) on
                     i.other_invoice_payment_in_id equals m.id
                 where m.date_process <= asOfDate
                 select i
                    ).ToList();*/

            var obj = (from item in query
                join p1 in pin on item.id equals p1.invoice_id into p1x
                from p1 in p1x.DefaultIfEmpty()
                join b in (from b in Entities.branches where b.rowstatus.Equals(true) select b) on item.branch_id equals b.id
                join s in Entities.sales_invoice on item.ref_number equals s.ref_number into sx
                from sx1 in sx.DefaultIfEmpty()
                //join p2 in pir on item.id equals p2.invoice_id into p2x
                //from p2 in p2x.DefaultIfEmpty()
                select new OtherInvoiceModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    RefNumber = item.ref_number,
                    BranchId = item.branch_id,
                    BranchName = b.name,
                    OwnerBranchId = item.owner_branch_id,
                    DueDate = item.due_date,
                    DateFrom = item.date_from,
                    DateTo = item.date_to,
                    CustomerId = item.customer_id,
                    CustomerName = sx1.company_invoiced_to,
                    Total = item.total,
                    InPaid = item.in_paid,
                    InTotalPayment = p1!=null?p1.total:0,
                    OutPaid = item.out_paid,
                    OutTotalPayment = item.out_total_payment,
                    Description = item.description,
                    Accept = item.accept,
                    AcceptAt = item.accept_at
                }).ToList();

            return obj;
        }

        public IEnumerable<OtherInvoiceModel> PaidReportJournalCustomer(IListParameter[] parameter, DateTime asOfDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var pin =
                (from i in
                     (from i in Entities.other_invoice_payment_in_detail where i.rowstatus.Equals(true) select i)
                 join m in
                     (from m in Entities.other_invoice_payment_in where m.rowstatus.Equals(true) select m) on
                     i.other_invoice_payment_in_id equals m.id
                 where m.date_process <= asOfDate
                 group i by i.invoice_id
                     into gs
                     select new { invoice_id = gs.Key, total = gs.Sum(a => a.payment) }
                    ).ToList();

            /*var pir =
                (from i in
                     (from i in Entities.other_invoice_payment_in_detail where i.rowstatus.Equals(true) select i)
                 join m in
                     (from m in Entities.other_invoice_payment_in where m.rowstatus.Equals(true) select m) on
                     i.other_invoice_payment_in_id equals m.id
                 where m.date_process <= asOfDate
                 select i
                    ).ToList();*/

            var obj = (from item in query
                       join p1 in pin on item.id equals p1.invoice_id
                       join b in
                           (from b in Entities.branches where b.rowstatus.Equals(true) select b) on item.branch_id equals b.id
                       //join p2 in pir on item.id equals p2.invoice_id
                       where item.total == p1.total
                       select new OtherInvoiceModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           DateProcess = item.date_process,
                           Code = item.code,
                           RefNumber = item.ref_number,
                           BranchId = item.branch_id,
                           BranchName = b.name,
                           OwnerBranchId = item.owner_branch_id,
                           DueDate = item.due_date,
                           DateFrom = item.date_from,
                           DateTo = item.date_to,
                           CustomerId = item.customer_id,
                           CustomerName = item.customer_name,
                           Total = item.total,
                           InPaid = item.in_paid,
                           InTotalPayment = p1 != null ? p1.total : 0,
                           OutPaid = item.out_paid,
                           OutTotalPayment = item.out_total_payment,
                           Description = item.description,
                           Accept = item.accept,
                           AcceptAt = item.accept_at
                       }).ToList();

            return obj;
        }

        public IEnumerable<OtherInvoiceModel> OutstandingReportJournalCustomer(IListParameter[] parameter, DateTime asOfDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var pin =
                (from i in
                     (from i in Entities.other_invoice_payment_in_detail where i.rowstatus.Equals(true) select i)
                 join m in
                     (from m in Entities.other_invoice_payment_in where m.rowstatus.Equals(true) select m) on
                     i.other_invoice_payment_in_id equals m.id
                 where m.date_process <= asOfDate
                 group i by i.invoice_id
                     into gs
                     select new { invoice_id = gs.Key, total = gs.Sum(a => a.payment) }
                    ).ToList();

            var pir =
                (from i in
                     (from i in Entities.other_invoice_payment_in_detail where i.rowstatus.Equals(true) select i)
                 join m in
                     (from m in Entities.other_invoice_payment_in where m.rowstatus.Equals(true) select m) on
                     i.other_invoice_payment_in_id equals m.id
                 where m.date_process <= asOfDate
                 select i
                    ).ToList();

            var obj = (from item in query
                       join p1 in pin on item.id equals p1.invoice_id into px from p1 in px.DefaultIfEmpty()
                       join b in
                           (from b in Entities.branches where b.rowstatus.Equals(true) select b) on item.branch_id equals b.id
                       select new OtherInvoiceModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           DateProcess = item.date_process,
                           Code = item.code,
                           RefNumber = item.ref_number,
                           BranchId = item.branch_id,
                           BranchName = b.name,
                           OwnerBranchId = item.owner_branch_id,
                           DueDate = item.due_date,
                           DateFrom = item.date_from,
                           DateTo = item.date_to,
                           CustomerId = item.customer_id,
                           CustomerName = item.customer_name,
                           Total = item.total,
                           InPaid = item.in_paid,
                           InTotalPayment = p1 != null ? p1.total : 0,
                           OutPaid = item.out_paid,
                           OutTotalPayment = item.out_total_payment,
                           Description = item.description,
                           Accept = item.accept,
                           AcceptAt = item.accept_at
                       }).ToList();

            return obj.Where(p => p.Total != p.InTotalPayment);
        }

        public List<SendInvoice> GetUnsendInvoice(int branchId, int destBranchId, DateTime start, DateTime end)
        {
            var sql = @"SELECT
	                        o.id Id,
                            1 Checked,
                            o.date_process DateProcess,
                            o.ref_number RefNumber,
                            o.customer_name CustomerName,
                            o.total Total
                        FROM other_invoice o
                        LEFT JOIN other_invoice_send_detail od ON od.other_invoice_id = o.id AND od.rowstatus = 1
                        WHERE o.rowstatus = 1 AND od.id IS NULL AND o.owner_branch_id = @branchId AND o.branch_id = @destBranchId AND o.date_process >= @start AND o.date_process <= @end";

            var sqlParams = new List<MySqlParameter>
            {
                new MySqlParameter("branchId", branchId),
                new MySqlParameter("destBranchId", destBranchId),
                new MySqlParameter("start", start),
                new MySqlParameter("end", end)
            };

            return Entities.ExecuteStoreQuery<SendInvoice>(sql, sqlParams.ToArray()).ToList();
        }

        public PaymentDescriptoin GetPaymentDescription (int pid)
        {
            var sql = @"SELECT
	                        group_concat(oipi.description, ' ') PaymentInDescription,
                            group_concat(oipo.description, ' ') PaymentOutDescription
                        FROM other_invoice oi
                        LEFT JOIN other_invoice_payment_in_detail oipid ON oi.id = oipid.invoice_id AND oipid.rowstatus = 1
                        LEFT JOIN other_invoice_payment_in oipi ON oipid.other_invoice_payment_in_id = oipi.id AND oipi.rowstatus = 1
                        LEFT JOIN other_invoice_payment_out_detail oipod ON oi.id = oipod.invoice_id AND oipod.rowstatus = 1
                        LEFT JOIN other_invoice_payment_out oipo ON oipod.other_invoice_payment_out_id = oipo.id AND oipo.rowstatus = 1
                        WHERE oi.rowstatus = 1 AND oi.id = @pid";

            return Entities.ExecuteStoreQuery<PaymentDescriptoin>(sql, new MySqlParameter("pid", pid)).FirstOrDefault();
        }
    }
}