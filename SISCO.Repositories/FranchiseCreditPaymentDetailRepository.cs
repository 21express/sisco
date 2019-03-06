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

namespace SISCO.Repositories
{
    public class FranchiseCreditPaymentDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Franchise Credit Payment Detail";
        public FranchiseCreditPaymentDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseCreditPaymentDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as FranchiseCreditPaymentDetailModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTofranchise_credit_payment_detail(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as FranchiseCreditPaymentDetailModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_credit_payment_detail where d.id == model.Id select d).FirstOrDefault();

            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseCreditPaymentDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_credit_payment_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_credit_payment_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.franchise_credit_payment_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static franchise_credit_payment_detail PopulateModelToNewEntity(FranchiseCreditPaymentDetailModel model)
        {
            return new franchise_credit_payment_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                franchise_credit_payment_id = model.FranchiseCreditPaymentId,
                invoice_id = model.InvoiceId,
                invoice_date = model.InvoiceDate,
                invoice_code = model.InvoiceCode,
                invoice_total = model.InvoiceTotal,
                invoice_balance = model.InvoiceBalance,
                payment = model.Payment,
                balance = model.Balance,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby
            };
        }

        private static void PopulateModelToNewEntity(franchise_credit_payment_detail query, FranchiseCreditPaymentDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.franchise_credit_payment_id = model.FranchiseCreditPaymentId;
            query.invoice_id = model.InvoiceId;
            query.invoice_date = model.InvoiceDate;
            query.invoice_code = model.InvoiceCode;
            query.invoice_total = model.InvoiceTotal;
            query.invoice_balance = model.InvoiceBalance;
            query.payment = model.Payment;
            query.balance = model.Balance;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static FranchiseCreditPaymentDetailModel PopulateEntityToNewModel(franchise_credit_payment_detail item)
        {
            return new FranchiseCreditPaymentDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                FranchiseCreditPaymentId = item.franchise_credit_payment_id,
                InvoiceId = item.invoice_id,
                InvoiceDate = item.invoice_date,
                InvoiceCode = item.invoice_code,
                InvoiceTotal = item.invoice_total,
                InvoiceBalance = item.invoice_total,
                Payment = item.payment,
                Balance = item.balance,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
                StateChange = EnumStateChange.Select
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_credit_payment_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_credit_payment_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_credit_payment_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_credit_payment_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_credit_payment_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_credit_payment_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<FranchiseCreditPaymentDetailModel> GetInvoices(int franchiseId)
        {
            var sql = @"SELECT
	                        fi.id InvoiceId,
                            fi.code InvoiceCode,
                            fi.date_process InvoiceDate,
                            fi.total InvoiceTotal,
                            IF(fc.invoice_id IS NULL, 0, fc.totalpayment) Payment,
                            0 InvoiceBalance,
                            0 Balance
                        FROM franchise_invoice fi
                        LEFT JOIN (
	                        SELECT
		                        invoice_id,
                                SUM(payment) totalpayment
	                        FROM franchise_credit_payment_detail
                            WHERE rowstatus = 1
                            GROUP BY invoice_id
                        ) fc ON fi.id = fc.invoice_id
                        WHERE fi.rowstatus = 1 AND fi.printed = 1 AND fi.cancelled = 0 AND fi.franchise_id = {0}
                        HAVING (InvoiceTotal - Payment) > 0";

            return Entities.ExecuteStoreQuery<FranchiseCreditPaymentDetailModel>(string.Format(sql, franchiseId)).ToList();
        }
    }
}