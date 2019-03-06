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
    public class PaymentOutCollectInDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentOutCollectInDetail";
        public PaymentOutCollectInDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PaymentOutCollectInDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as PaymentOutCollectInDetailModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTopayment_out_collect_in_detail(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as PaymentOutCollectInDetailModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_out_collect_in_detail where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentOutCollectInDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_out_collect_in_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_out_collect_in_detail where d.id == id select d).FirstOrDefault();
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
            var query = (from d in Entities.payment_out_collect_in_detail select d).Where(whereterm, ListValue.ToArray()).ToList();

            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);

            var objs = (IEnumerable<PaymentOutCollectInDetailModel>)query.Select(PopulateEntityToNewModel).ToList();
            foreach (PaymentOutCollectInDetailModel obj in objs)
            {
                obj.Rowstatus = false;
                obj.Modifiedby = userName;
                obj.Modifieddate = DateTime.Now;
            }

            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.payment_out_collect_in_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static payment_out_collect_in_detail PopulateModelToNewEntity(PaymentOutCollectInDetailModel model)
        {
            return new payment_out_collect_in_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                payment_out_collect_in_id = model.PaymentOutCollectInId,
                payment_in_collect_in_code = model.PaymentInCollectInCode,
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

        private static void PopulateModelToNewEntity(payment_out_collect_in_detail query, PaymentOutCollectInDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.payment_out_collect_in_id = model.PaymentOutCollectInId;
            query.payment_in_collect_in_code = model.PaymentInCollectInCode;
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

        private static PaymentOutCollectInDetailModel PopulateEntityToNewModel(payment_out_collect_in_detail item)
        {
            return new PaymentOutCollectInDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                DateProcess = item.date_process,
                PaymentOutCollectInId = item.payment_out_collect_in_id,
                PaymentInCollectInCode = item.payment_in_collect_in_code,
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
            var query = (from a in Entities.payment_out_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_out_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_out_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.payment_out_collect_in_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public int GetPaymentOutCollectIn(int invoiceId)
        {
            var whereterm = GetQueryParameterLinq(new IListParameter[] { WhereTerm.Default(invoiceId, "invoice_id", EnumSqlOperator.Equals) });
            var query = (from a in Entities.payment_out_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();

            var invoices = (IEnumerable<PaymentOutCollectInDetailModel>)query.Select(PopulateEntityToNewModel).ToList();
            if (invoices.Any())
            {
                return (int)invoices.Sum(p => p.Payment);
            }

            return 0;
        }

        public List<PaymentOutCollectInDetailModel> GetPaidCollectIn(int branchId, string paymentMethod, int paymentInBranchId)
        {
            var sql = @"SELECT
	                        p.code PaymentInCollectInCode,
                            pd.invoice_id InvoiceId,
                            pd.invoice_code InvoiceCode,
                            IF(pd.invoice_date IS NOT NULL, pd.invoice_date, NOW()) InvoiceDate,
                            pd.invoice_total InvoiceTotal,
                            (pd.invoice_total - IF (SUM(outd.payment) > 0, SUM(outd.payment), 0)) InvoiceBalance,
                            0 Payment,
                            (pd.invoice_total - IF (SUM(outd.payment) > 0, SUM(outd.payment), 0)) Balance,
                            0 Checked,
                            0 Paid,
                            pd.collect_payment_method CollectPaymentMethod,
                            'Idle' StateChange2
                        FROM siscodb.payment_in_collect_in_detail pd
                        INNER JOIN siscodb.payment_in_collect_in p ON pd.payment_in_collect_in_id = p.id AND p.rowstatus = 1
                        LEFT JOIN siscodb.payment_out_collect_in_detail outd ON pd.invoice_id = outd.invoice_id AND outd.rowstatus = 1
                        WHERE pd.branch_id = {0} AND pd.collect_payment_method = '{1}' AND pd.invoice_id > 0 AND p.branch_id = {2} AND pd.rowstatus = 1
                        GROUP BY pd.invoice_id
                        HAVING Balance > 0;";

            sql = string.Format(sql, branchId, paymentMethod, paymentInBranchId);
            return Entities.ExecuteStoreQuery<PaymentOutCollectInDetailModel>(sql).ToList();
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentOutCollectInModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_out_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.payment_out_collect_in_id equals m.Id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 CustomerName = m.CompanyName,
                                                                 PaymentType = m.PaymentType,
                                                                 Kwitansi = a.invoice_code
                                                             }).ToList();

            return obj;
        }

        internal class CollectTotalPayment
        {
            public Decimal InvoiceTotal { get; set; }
            public Int32? InvoiceId { get; set; }
            public Decimal TotalPayment { get; set; }
        }

        public IEnumerable<PaymentInCollectInDetailModel> PaidCollect(IListParameter[] parameter, DateTime asOfDate)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_out_collect_in select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            
            var obj = (from q in query
                join d in (from d in Entities.payment_out_collect_in_detail where d.rowstatus.Equals(true) && d.date_process <= asOfDate select d) on q.id equals d.payment_out_collect_in_id
                group d by new {d.invoice_id, d.invoice_total}
                into g
                select new CollectTotalPayment
                {
                    InvoiceTotal = g.Key.invoice_total,
                    InvoiceId = g.Key.invoice_id,
                    TotalPayment = g.Sum(x => x.payment)
                }).Where(p => p.InvoiceTotal == p.TotalPayment).ToList();
            
            var s = (from dynamic o in obj select o.InvoiceId).Cast<int>().ToList();

            var result = (from item in (from item in Entities.payment_in_collect_in_detail where item.rowstatus.Equals(true) select item)
                          join b in Entities.branches on item.branch_id equals b.id
                          join p in
                              (from p in Entities.payment_out_collect_in_detail
                               where p.rowstatus.Equals(true) && p.date_process <= asOfDate && s.Contains(p.invoice_id)
                               select p) on item.invoice_id equals p.invoice_id
                          join m in Entities.payment_out_collect_in on p.payment_out_collect_in_id equals m.id
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
                              Payment = item.payment,
                              Balance = item.balance,
                              //Payment = o.InvoiceTotal,
                              //Balance = item.invoice_total - o.TotalPayment,
                              Checked = item.@checked,
                              Paid = item.paid,
                              CollectPaymentMethod = item.collect_payment_method,
                              CollectCustomerId = item.collect_customer_id,
                              CollectCustomerName = item.collect_customer_name,
                              Createddate = item.createddate,
                              Createdby = item.createdby,
                              Modifieddate = item.modifieddate,
                              Modifiedby = item.modifiedby,
                              ReportDescription = m.description,
                              ReportPayment = p != null ? p.payment : 0,
                              ReportBalance = p != null ? p.balance : 0,
                              ReportPaymentOutDate = p != null ? p.date_process : (DateTime?)null,
                              ReportPaymentOutCode = p != null ? p.payment_in_collect_in_code : string.Empty
                          }).ToList();

            var tesx = result.Join(obj, item => item.InvoiceId, d => d.InvoiceId, (item, d) =>
                new PaymentInCollectInDetailModel
                {
                    Id = item.Id,
                    Rowstatus = item.Rowstatus,
                    Rowversion = item.Rowversion,
                    PaymentInCollectInId = item.PaymentInCollectInId,
                    BranchId = item.BranchId,
                    BranchName = item.BranchName,
                    DateProcess = item.DateProcess,
                    InvoiceId = item.InvoiceId,
                    InvoiceDate = item.InvoiceDate,
                    InvoiceCode = item.InvoiceCode,
                    InvoiceTotal = item.InvoiceTotal,
                    InvoiceBalance = item.InvoiceBalance,
                    Payment = d.InvoiceTotal,
                    Balance = item.InvoiceTotal - d.TotalPayment,
                    Checked = item.Checked,
                    Paid = item.Paid,
                    CollectPaymentMethod = item.CollectPaymentMethod,
                    CollectCustomerId = item.CollectCustomerId,
                    CollectCustomerName = item.CollectCustomerName,
                    ReportDescription = item.ReportDescription,
                    ReportPayment = item.ReportPayment,
                    ReportBalance = item.ReportBalance,
                    ReportPaymentOutDate = item.ReportPaymentOutDate,
                    ReportPaymentOutCode = item.ReportPaymentOutCode
                });

            return tesx;
        }

        public IEnumerable<PaymentOutCollectInDetailModel> ReportCollectOutBr(IEnumerable<PaymentOutCollectInModel> master, DateTime asOfDate)
        {
            var whereterm = GetQueryParameterLinq();
            var query = (from a in Entities.payment_out_collect_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                       join m in master on item.payment_out_collect_in_id equals m.Id
                       join b in Entities.branches on m.OwnerBranchId equals b.id
                       join p in
                           (from p in (from p in Entities.payment_in_collect_out_detail where p.rowstatus.Equals(true) && p.date_process <= asOfDate select p) 
                            join ms in (from ms in Entities.payment_in_collect_out where ms.rowstatus.Equals(true) select ms) on p.payment_in_collect_out_id equals ms.id
                            select new {p.payment, p.invoice_id, p.date_process, ms.code, ms.description}
                           ) on item.invoice_id equals p.invoice_id into pout
                       from p in pout.DefaultIfEmpty()
                       select new PaymentOutCollectInDetailModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           DateProcess = item.date_process,
                           PaymentOutCollectInId = item.payment_out_collect_in_id,
                           PaymentInCollectInCode = item.payment_in_collect_in_code,
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
                           ReportBranch = b.name,
                           ReportPayment = p != null ? p.payment : 0,
                           ReportPaymentDate = p != null ? p.date_process : (DateTime?) null,
                           ReportPaymentInCollectOutCode = p != null ? p.code : "",
                           ReportDescription = p!=null ? p.description : "",
                           Description = m.Description
                       }).ToList();

            return obj;
        }
    }
}