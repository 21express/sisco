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
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class InvoiceToFinanceDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "InvoiceToFinanceDetail";
        public InvoiceToFinanceDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public InvoiceToFinanceDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as InvoiceToFinanceDetailModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddToinvoice_to_finance_detail(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as InvoiceToFinanceDetailModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.invoice_to_finance_detail where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as InvoiceToFinanceDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.invoice_to_finance_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.invoice_to_finance_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.invoice_to_finance_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static invoice_to_finance_detail PopulateModelToNewEntity(InvoiceToFinanceDetailModel model)
        {
            return new invoice_to_finance_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                invoice_to_finance_id = model.InvoiceToFinanceId,
                sales_invoice_id = model.SalesInvoiceId,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(invoice_to_finance_detail query, InvoiceToFinanceDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.invoice_to_finance_id = model.InvoiceToFinanceId;
            query.sales_invoice_id = model.SalesInvoiceId;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static InvoiceToFinanceDetailModel PopulateEntityToNewModel(invoice_to_finance_detail item)
        {
            return new InvoiceToFinanceDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                InvoiceToFinanceId = item.invoice_to_finance_id,
                SalesInvoiceId = item.sales_invoice_id,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_to_finance_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_to_finance_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_to_finance_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_to_finance_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.invoice_to_finance_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_to_finance_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<InvoiceFinanceDetailModel> Get(int invoiceFinanceId)
        {
            var sql = @"SELECT
	                        itfd.id Id,
	                        si.id SalesInvoiceId,
                            si.ref_number RefNumber,
                            si.company_invoiced_to CustomerName,
                            si.period Period,
                            si.total Total,
	                        'SELECT' StateChange
                        FROM invoice_to_finance itf
                        INNER JOIN invoice_to_finance_detail itfd ON itf.id = itfd.invoice_to_finance_id AND itfd.rowstatus = 1
                        INNER JOIN sales_invoice si ON itfd.sales_invoice_id = si.id
                        WHERE itf.rowstatus = 1 AND itf.id = @id";

            return Entities.ExecuteStoreQuery<InvoiceFinanceDetailModel>(sql, new MySqlParameter("id", invoiceFinanceId)).ToList();
        }

        public bool IsRefSent(string refNumber)
        {
            var sql = @"SELECT
	                        itfd.id Id,
	                        si.id SalesInvoiceId,
                            si.ref_number RefNumber,
	                        c.code CustomerCode,
                            si.company_invoiced_to CustomerName,
                            si.period Period,
                            si.total Total,
	                        'SELECT' StateChange
                        FROM invoice_to_finance itf
                        INNER JOIN invoice_to_finance_detail itfd ON itf.id = itfd.invoice_to_finance_id AND itfd.rowstatus = 1
                        INNER JOIN sales_invoice si ON itfd.sales_invoice_id = si.id
                        INNER JOIN customer c ON si.company_id = c.id
                        WHERE itf.rowstatus = 1 AND si.ref_number = @refnumber";

            var data = Entities.ExecuteStoreQuery<InvoiceFinanceDetailModel>(sql, new MySqlParameter("refnumber", refNumber)).FirstOrDefault();
            return data != null;
        }
    }
}