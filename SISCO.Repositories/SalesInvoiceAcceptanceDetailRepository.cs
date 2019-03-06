using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Transactions;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class SalesInvoiceAcceptanceDetailRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "SalesInvoiceList";
        public SalesInvoiceAcceptanceDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public SalesInvoiceAcceptanceDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as SalesInvoiceAcceptanceDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTosales_invoice_acceptance_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as SalesInvoiceAcceptanceDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.sales_invoice_acceptance_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as SalesInvoiceAcceptanceDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.sales_invoice_acceptance_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.sales_invoice_acceptance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.sales_invoice_acceptance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static sales_invoice_acceptance_detail PopulateModelToNewEntity(SalesInvoiceAcceptanceDetailModel model)
		{
			return new sales_invoice_acceptance_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                sales_invoice_acceptance_id = model.SalesInvoiceAcceptanceId,
                sales_invoice_id = model.SalesInvoiceId,
                collector_id = model.CollectorId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(sales_invoice_acceptance_detail query, SalesInvoiceAcceptanceDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.sales_invoice_acceptance_id = model.SalesInvoiceAcceptanceId;
            query.sales_invoice_id = model.SalesInvoiceId;
            query.collector_id = model.CollectorId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static SalesInvoiceAcceptanceDetailModel PopulateEntityToNewModel(sales_invoice_acceptance_detail item)
		{
			return new SalesInvoiceAcceptanceDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                SalesInvoiceAcceptanceId = item.sales_invoice_acceptance_id,
                SalesInvoiceId = item.sales_invoice_id,
                CollectorId = item.collector_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.sales_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.sales_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.sales_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).Cast<SalesInvoiceListModel>().ToList();
        }
        
        public List<InvoiceUnAcceptedModel> GetUnaccepted(int branchId)
        {
            var sql = @"SELECT
                            si.ref_number RefNumber,
                            si.company_invoiced_to CustomerName,
                            si.period Period
                        FROM invoice_to_finance itf
                        INNER JOIN invoice_to_finance_detail itfd ON itf.id = itfd.invoice_to_finance_id AND itfd.rowstatus = 1
                        INNER JOIN sales_invoice si ON itfd.sales_invoice_id = si.id AND si.rowstatus = 1 AND si.cancelled = 0
                        LEFT JOIN sales_invoice_acceptance_detail siad ON si.id = siad.sales_invoice_id AND siad.rowstatus = 1
                        LEFT JOIN sales_invoice_acceptance sia ON siad.sales_invoice_acceptance_id = sia.id AND sia.rowstatus = 1
                        WHERE itf.branch_id = @branchId AND itf.rowstatus = 1 AND siad.id IS NULL AND sia.id IS NULL;";

            return Entities.ExecuteStoreQuery<InvoiceUnAcceptedModel>(sql, new MySqlParameter("branchId", branchId)).ToList();
        }

        public List<InvoiceAcceptanceDetailModel> GetDetails (int invoiceAcceptanceId)
        {
            var sql = @"SELECT
	                        siad.id Id,
                            si.id SalesInvoiceId,
	                        si.ref_number RefNumber,
                            si.company_invoiced_to CustomerName,
	                        si.period Period,
                            si.total Total,
                            siad.collector_id CollectorId,
                            e.name CollectorName,
                            'SELECT' StateChange
                        FROM sales_invoice_acceptance sia
                        INNER JOIN sales_invoice_acceptance_detail siad ON sia.id = siad.sales_invoice_acceptance_id AND siad.rowstatus = 1
                        INNER JOIN sales_invoice si ON si.id = siad.sales_invoice_id
                        LEFT JOIN employee e ON siad.collector_id = e.id
                        WHERE sia.rowstatus = 1 AND sia.id = @invoiceAcceptanceId";

            return Entities.ExecuteStoreQuery<InvoiceAcceptanceDetailModel>(sql, new MySqlParameter("invoiceAcceptanceId", invoiceAcceptanceId)).ToList();
        }

        public bool IsAccepted(string refNumber)
        {
            var sql = @"SELECT
	                        siad.id Id,
                            si.id SalesInvoiceId,
	                        si.ref_number RefNumber,
                            si.company_invoiced_to CustomerName,
	                        si.period Period,
                            si.total Total,
                            siad.collector_id CollectorId,
                            e.name CollectorName
                        FROM sales_invoice_acceptance sia
                        INNER JOIN sales_invoice_acceptance_detail siad ON sia.id = siad.sales_invoice_acceptance_id AND siad.rowstatus = 1
                        INNER JOIN sales_invoice si ON si.id = siad.sales_invoice_id
                        LEFT JOIN employee e ON siad.collector_id = e.id
                        WHERE sia.rowstatus = 1 AND si.ref_number = @refNumber;";

            var data = Entities.ExecuteStoreQuery<InvoiceAcceptanceDetailModel>(sql, new MySqlParameter("refNumber", refNumber)).FirstOrDefault();
            return data != null;
        }
    }
}