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
    public class PaymentInCollectOutDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentInCollectOutDetail";

        public PaymentInCollectOutDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PaymentInCollectOutDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as PaymentInCollectOutDetailModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTopayment_in_collect_out_detail(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as PaymentInCollectOutDetailModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query =
                (from d in Entities.payment_in_collect_out_detail where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentInCollectOutDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query =
                (from d in Entities.payment_in_collect_out_detail select d).Where(whereterm, ListValue.ToArray())
                    .FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_in_collect_out_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public void DeActiveRows(IListParameter[] parameter, string userName)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from d in Entities.payment_in_collect_out_detail select d).Where(whereterm, ListValue.ToArray())
                    .ToList();

            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);

            var objs = (IEnumerable<PaymentInCollectOutDetailModel>) query.Select(PopulateEntityToNewModel).ToList();
            foreach (PaymentInCollectOutDetailModel obj in objs)
            {
                obj.Rowstatus = false;
                obj.Modifiedby = userName;
                obj.Modifieddate = DateTime.Now;
            }

            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.payment_in_collect_out_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static payment_in_collect_out_detail PopulateModelToNewEntity(PaymentInCollectOutDetailModel model)
        {
            return new payment_in_collect_out_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                date_process = model.DateProcess,
                payment_in_collect_out_id = model.PaymentInCollectOutId,
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
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(payment_in_collect_out_detail query,
            PaymentInCollectOutDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.payment_in_collect_out_id = model.PaymentInCollectOutId;
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
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static PaymentInCollectOutDetailModel PopulateEntityToNewModel(payment_in_collect_out_detail item)
        {
            return new PaymentInCollectOutDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                DateProcess = item.date_process,
                PaymentInCollectOutId = item.payment_in_collect_out_id,
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
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_in_collect_out_detail select a).Where(whereterm, ListValue.ToArray())
                    .AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_in_collect_out_detail select a).Where(whereterm, ListValue.ToArray())
                    .ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_in_collect_out_detail select a).Where(whereterm, ListValue.ToArray())
                    .OrderBy(paging.SortColumn + " " + paging.Direction)
                    .Skip(paging.Start)
                    .Take(paging.Limit)
                    .ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.payment_in_collect_out_detail select a).Where(whereterm,
                ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
        }

        public int GetPaymentOutCollectIn(int invoiceId)
        {
            var whereterm =
                GetQueryParameterLinq(new IListParameter[]
                {WhereTerm.Default(invoiceId, "invoice_id", EnumSqlOperator.Equals)});
            var query =
                (from a in Entities.payment_in_collect_out_detail select a).Where(whereterm, ListValue.ToArray())
                    .AsQueryable();

            var invoices = (IEnumerable<PaymentInCollectOutDetailModel>) query.Select(PopulateEntityToNewModel).ToList();
            if (invoices.Any())
            {
                return (int) invoices.Sum(p => p.Payment);
            }

            return 0;
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentInCollectOutModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_in_collect_out_detail select a).Where(whereterm, ListValue.ToArray())
                    .ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>) (from a in query
                join m in master on a.payment_in_collect_out_id equals m.Id
                select new PaymentInAndDetailModel
                {
                    DateProcess = m.DateProcess,
                    Code = m.Code,
                    PaymentType = m.PaymentType,
                    Kwitansi = a.invoice_code
                }).ToList();

            return obj;
        }

        public IEnumerable<PaymentInCollectOutDetailModel> CollectOutReport(IEnumerable<ShipmentModel> shipment, DateTime asOfdate)
        {
            var obj = (from d in Entities.payment_in_collect_out_detail
                where d.rowstatus.Equals(true) && d.date_process <= asOfdate
                group d by new {d.invoice_id, d.invoice_total}
                into g
                select new
                {
                    g.Key.invoice_id,
                    total_payment = g.Sum(x => x.payment)
                }).ToList();

            var query = (from s in shipment
                join col in (
                    from d in Entities.payment_in_collect_out_detail
                    join m in Entities.payment_in_collect_out on d.payment_in_collect_out_id equals m.id
                    where d.rowstatus.Equals(true) && m.rowstatus.Equals(true)
                    select new {d.id, d.invoice_id, d.payment, d.balance, m.code, m.date_process, m.description}
                    ) on s.Id equals col.invoice_id into colx
                from col in colx.DefaultIfEmpty()
                         join sumcol in obj on s.Id equals sumcol.invoice_id into sumcolx
                from sumcol in sumcolx.DefaultIfEmpty()
                join b in Entities.branches on s.DestBranchId equals b.id
                select new PaymentInCollectOutDetailModel
                {
                    InvoiceId = s.Id,
                    InvoiceDate = s.DateProcess,
                    InvoiceCode = s.Code,
                    InvoiceTotal = s.Total,
                    Payment = sumcol != null ? sumcol.total_payment : 0,
                    Balance = sumcol != null ? s.Total - sumcol.total_payment : s.Total,
                    ReportBranch = b.code + " " + b.name,
                    ReportDate = col != null ? col.date_process : (DateTime?) null,
                    ReportCode = col != null ? col.code : "",
                    ReportDescription = col != null ? col.description : "",
                    ReportPayment = col != null ? col.payment : 0,
                }
                ).ToList();

            return query;
        }

        public IEnumerable<PaymentInCollectOutDetailModel> PaidCollectOutReport(IEnumerable<ShipmentModel> shipment, DateTime asOfdate)
        {
            var obj = (from d in Entities.payment_in_collect_out_detail
                       where d.rowstatus.Equals(true) && d.date_process <= asOfdate
                       group d by new { d.invoice_id, d.invoice_total }
                           into g
                           select new
                           {
                               g.Key.invoice_id,
                               g.Key.invoice_total,
                               total_payment = g.Sum(x => x.payment)
                           }).Where(gx => gx.invoice_total == gx.total_payment).ToList();

            var query = (from s in shipment
                         join sumcol in obj on s.Id equals sumcol.invoice_id
                         join col in
                             (
                                 from d in Entities.payment_in_collect_out_detail
                                 join m in Entities.payment_in_collect_out on d.payment_in_collect_out_id equals m.id
                                 where d.rowstatus.Equals(true) && m.rowstatus.Equals(true)
                                 select new { d.id, d.invoice_id, d.payment, d.balance, m.code, m.date_process, m.description }
                                 ) on sumcol.invoice_id equals col.invoice_id
                         join b in Entities.branches on s.DestBranchId equals b.id
                         select new PaymentInCollectOutDetailModel
                         {
                             InvoiceId = s.Id,
                             InvoiceDate = s.DateProcess,
                             InvoiceCode = s.Code,
                             InvoiceTotal = s.Total,
                             Payment = sumcol != null ? sumcol.total_payment : 0,
                             Balance = sumcol != null ? s.Total - sumcol.total_payment : s.Total,
                             ReportBranch = b.code + " " + b.name,
                             ReportDate = col != null ? col.date_process : (DateTime?)null,
                             ReportCode = col != null ? col.code : "",
                             ReportDescription = col != null ? col.description : "",
                             ReportPayment = col != null ? col.payment : 0,
                         }
                ).ToList();

            return query;
        }

        public List<PaymentInCollectOutDetailModel> GetPaymentOutCollectIn(int branchId, int destBranchId)
        {
            var sql = @"SELECT
	                        s.id InvoiceId,
                            s.code InvoiceCode,
                            s.date_process InvoiceDate,
                            s.total InvoiceTotal,
                            (s.total - IF (SUM(outd.payment) > 0, SUM(outd.payment), 0)) InvoiceBalance,
                            0 Payment,
                            (s.total - IF (SUM(outd.payment) > 0, SUM(outd.payment), 0)) Balance,
                            0 Checked,
                            0 Paid, 
                            pd.collect_payment_method CollectPaymentMethod,
                            'Idle' StateChange2
                        FROM siscodb.shipment s
                        INNER JOIN siscodb.payment_out_collect_in_detail pd ON s.id = pd.invoice_id AND pd.rowstatus = 1
                        LEFT JOIN siscodb.payment_in_collect_out_detail outd ON s.id = outd.invoice_id AND outd.rowstatus = 1
                        WHERE s.branch_id = {0} AND s.payment_method_id = 2 AND s.dest_branch_id = {1} AND s.rowstatus = 1
                        GROUP BY s.id
                        HAVING Balance > 0;";
            sql = string.Format(sql, branchId, destBranchId);
            return Entities.ExecuteStoreQuery<PaymentInCollectOutDetailModel>(sql).ToList();
        }
    }
}