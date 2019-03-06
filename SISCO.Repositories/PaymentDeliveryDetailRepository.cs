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
    public class PaymentDeliveryDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentDeliveryDetail";
        public PaymentDeliveryDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PaymentDeliveryDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as PaymentDeliveryDetailModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTopayment_delivery_detail(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as PaymentDeliveryDetailModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_delivery_detail where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentDeliveryDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_delivery_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_delivery_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.payment_delivery_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static payment_delivery_detail PopulateModelToNewEntity(PaymentDeliveryDetailModel model)
        {
            return new payment_delivery_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                payment_delivery_id = model.PaymentDeliveryId,
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
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(payment_delivery_detail query, PaymentDeliveryDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.payment_delivery_id = model.PaymentDeliveryId;
            query.date_process = model.DateProcess;
            query.invoice_id = model.InvoiceId;
            query.invoice_date = model.InvoiceDate;
            query.invoice_code = model.InvoiceCode;
            query.invoice_total = model.InvoiceTotal;
            query.invoice_balance = model.InvoiceBalance;
            query.payment = model.Payment;
            query.balance = model.Balance;
            query.@checked = model.Checked;
            query.paid = model.Paid;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static PaymentDeliveryDetailModel PopulateEntityToNewModel(payment_delivery_detail item)
        {
            return new PaymentDeliveryDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                PaymentDeliveryId = item.payment_delivery_id,
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
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_delivery_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_delivery_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_delivery_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.payment_delivery_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public int GetPaymentDelivery(int invoiceId)
        {
            var whereterm = GetQueryParameterLinq(new IListParameter[] { WhereTerm.Default(invoiceId, "invoice_id", EnumSqlOperator.Equals) });
            var query = (from a in Entities.payment_delivery_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();

            var invoices = (IEnumerable<PaymentDeliveryDetailModel>)query.Select(PopulateEntityToNewModel).ToList();
            if (invoices.Any())
            {
                return (int)invoices.Sum(p => p.Payment);
            }

            return 0;
        }

        public void DeActiveRows(IListParameter[] parameter, string userName)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from d in Entities.payment_delivery_detail select d).Where(whereterm, ListValue.ToArray()).ToList();

            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);

            var objs = (IEnumerable<PaymentDeliveryDetailModel>)query.Select(PopulateEntityToNewModel).ToList();
            foreach (PaymentDeliveryDetailModel obj in objs)
            {
                obj.Rowstatus = false;
                obj.Modifiedby = userName;
                obj.Modifieddate = DateTime.Now;
            }

            Entities.SaveChanges();
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentDeliveryModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_delivery_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.payment_delivery_id equals m.Id
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
    }
}