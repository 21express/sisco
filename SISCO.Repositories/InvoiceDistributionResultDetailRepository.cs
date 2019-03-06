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
    public class InvoiceDistributionResultDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "InvoiceDistributionResultDetail";
        public InvoiceDistributionResultDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public InvoiceDistributionResultDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as InvoiceDistributionResultDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToinvoice_distribution_result_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as InvoiceDistributionResultDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.invoice_distribution_result_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as InvoiceDistributionResultDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.invoice_distribution_result_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.invoice_distribution_result_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.invoice_distribution_result_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static invoice_distribution_result_detail PopulateModelToNewEntity(InvoiceDistributionResultDetailModel model)
		{
			return new invoice_distribution_result_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				invoice_distribution_result_id = model.InvoiceDistributionResultId,
                sales_invoice_id = model.SalesInvoiceId,
                collector_id = model.CollectorId,
                payment_type_id = model.PaymentTypeId,
                receipt_name = model.ReceiptName,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(invoice_distribution_result_detail query, InvoiceDistributionResultDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.invoice_distribution_result_id = model.InvoiceDistributionResultId;
            query.sales_invoice_id = model.SalesInvoiceId;
            query.collector_id = model.CollectorId;
            query.payment_type_id = model.PaymentTypeId;
            query.receipt_name = model.ReceiptName;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static InvoiceDistributionResultDetailModel PopulateEntityToNewModel(invoice_distribution_result_detail item)
		{
            return new InvoiceDistributionResultDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				InvoiceDistributionResultId = item.invoice_distribution_result_id,
                SalesInvoiceId = item.sales_invoice_id,
                CollectorId = item.collector_id,
                PaymentTypeId = item.payment_type_id,
                ReceiptName = item.receipt_name,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.invoice_distribution_result_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_distribution_result_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_distribution_result_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_distribution_result_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.invoice_distribution_result_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_distribution_result_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<InvoiceUnDistributionDetailModel> GetUnDistributed(int branchId)
        {
            var sql = @"SELECT
	                        si.ref_number RefNumber,
                            si.vdate DateProcess,
                            si.due_date DueDate,
                            si.company_invoiced_to CustomerName,
                            e.name CollectorName
                        FROM sales_invoice_acceptance sia
                        INNER JOIN sales_invoice_acceptance_detail siad ON sia.id = siad.sales_invoice_acceptance_id AND siad.rowstatus = 1
                        INNER JOIN sales_invoice si ON siad.sales_invoice_id = si.id AND si.rowstatus = 1 AND si.cancelled = 0
                        LEFT JOIN invoice_distribution_result_detail idrd ON si.id = idrd.sales_invoice_id AND idrd.rowstatus = 1
                        LEFT JOIN invoice_distribution_result idr ON idrd.invoice_distribution_result_id = idr.id AND idr.rowstatus = 1
                        LEFT JOIN employee e ON siad.collector_id = e.id
                        WHERE sia.branch_id = @branchId AND sia.rowstatus = 1 AND idrd.id IS NULL AND idr.id IS NULL;";

            return Entities.ExecuteStoreQuery<InvoiceUnDistributionDetailModel>(sql, new MySqlParameter("branchId", branchId)).ToList();
        }

        public List<InvoiceDistributionDetailModel> GetDetails(int distributionId)
        {
            var sql = @"SELECT
	                        idrd.id Id,
	                        si.id SalesInvoiceId,
	                        si.ref_number RefNumber,
	                        si.company_invoiced_to CustomerName,
	                        idrd.collector_id CollectorId,
	                        e.name CollectorName,
                            idrd.payment_type_id PaymentTypeId,
	                        pt.name PaymentTypeName,
	                        idrd.receipt_name ReceiptName,
	                        'Select' StateChange
                        FROM invoice_distribution_result idr 
                        INNER JOIN invoice_distribution_result_detail idrd ON idr.id = idrd.invoice_distribution_result_id AND idrd.rowstatus = 1
                        INNER JOIN sales_invoice si ON idrd.sales_invoice_id = si.id
                        INNER JOIN employee e ON e.id = idrd.collector_id
                        INNER JOIN payment_type pt ON idrd.payment_type_id = pt.id
                        WHERE idr.rowstatus = 1 AND idr.id = @distributionId;";

            return Entities.ExecuteStoreQuery<InvoiceDistributionDetailModel>(sql, new MySqlParameter("distributionId", distributionId)).ToList();
        }

        public bool IsDistributed (string refNumber)
        {
            var sql = @"SELECT
	                        idrd.id Id,
	                        si.id SalesInvoiceId,
	                        si.ref_number RefNumber,
	                        si.company_invoiced_to CustomerName,
	                        idrd.collector_id CollectorId,
	                        e.name CollectorName,
                            idrd.payment_type_id PaymentTypeId,
	                        pt.name PaymentTypeName,
	                        idrd.receipt_name ReceiptName,
	                        'SELECT' StateChange
                        FROM invoice_distribution_result idr 
                        INNER JOIN invoice_distribution_result_detail idrd ON idr.id = idrd.invoice_distribution_result_id AND idrd.rowstatus = 1
                        INNER JOIN sales_invoice si ON idrd.sales_invoice_id = si.id
                        INNER JOIN employee e ON e.id = idrd.collector_id
                        INNER JOIN payment_type pt ON idrd.payment_type_id = pt.id
                        WHERE idr.rowstatus = 1 AND si.ref_number = @refNumber;";

            var data = Entities.ExecuteStoreQuery<InvoiceDistributionDetailModel>(sql, new MySqlParameter("refNumber", refNumber)).FirstOrDefault();
            return data != null;
        }

        public InvoiceCollectorModel GetCollector(string refNumber)
        {
            var sql = @"SELECT
                            si.id SalesInvoiceId,
                            si.cancelled Cancelled,
                            si.printed Printed,
                            si.company_invoiced_to CustomerName,
                            IF (siad.id IS NOT NULL AND sia.id IS NOT NULL, siad.collector_id, null) CollectorId
                        FROM sales_invoice si
                        LEFT JOIN sales_invoice_acceptance_detail siad ON siad.sales_invoice_id = si.id AND siad.rowstatus = 1
                        LEFT JOIN sales_invoice_acceptance sia ON siad.sales_invoice_acceptance_id = sia.id AND sia.rowstatus = 1
                        WHERE si.rowstatus = 1 AND si.ref_number = @refNumber";

            return Entities.ExecuteStoreQuery<InvoiceCollectorModel>(sql, new MySqlParameter("refNumber", refNumber)).FirstOrDefault();
        }

        public bool IsInvoiceTransfered(string refNumber)
        {
            var sql = @"SELECT
	                        idrd.id Id,
	                        si.id SalesInvoiceId,
	                        si.ref_number RefNumber,
	                        si.company_invoiced_to CustomerName,
	                        idrd.collector_id CollectorId,
	                        e.name CollectorName,
                            idrd.payment_type_id PaymentTypeId,
	                        pt.name PaymentTypeName,
	                        idrd.receipt_name ReceiptName,
	                        'SELECT' StateChange
                        FROM invoice_distribution_result idr 
                        INNER JOIN invoice_distribution_result_detail idrd ON idr.id = idrd.invoice_distribution_result_id AND idrd.rowstatus = 1
                        INNER JOIN sales_invoice si ON idrd.sales_invoice_id = si.id
                        INNER JOIN employee e ON e.id = idrd.collector_id
                        INNER JOIN payment_type pt ON idrd.payment_type_id = pt.id
                        WHERE idr.rowstatus = 1 AND si.ref_number = @refNumber;";

            var data = Entities.ExecuteStoreQuery<InvoiceDistributionDetailModel>(sql, new MySqlParameter("refNumber", refNumber)).FirstOrDefault();
            if (data != null) return data.PaymentTypeId == 6;
            else return false;
        }
    }
}


