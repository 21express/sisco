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
    public class InvoiceTransferDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "InvoiceTransferDetail";
        public InvoiceTransferDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public InvoiceTransferDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as InvoiceTransferDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToinvoice_transfer_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as InvoiceTransferDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.invoice_transfer_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as InvoiceTransferDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.invoice_transfer_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.invoice_transfer_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.invoice_transfer_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static invoice_transfer_detail PopulateModelToNewEntity(InvoiceTransferDetailModel model)
		{
			return new invoice_transfer_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				invoice_transfer_id = model.InvoiceTransferId,
                sales_invoice_id = model.SalesInvoiceId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(invoice_transfer_detail query, InvoiceTransferDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.invoice_transfer_id = model.InvoiceTransferId;
            query.sales_invoice_id = model.SalesInvoiceId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static InvoiceTransferDetailModel PopulateEntityToNewModel(invoice_transfer_detail item)
		{
            return new InvoiceTransferDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				InvoiceTransferId = item.invoice_transfer_id,
                SalesInvoiceId = item.sales_invoice_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.invoice_transfer_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_transfer_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_transfer_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_transfer_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.invoice_transfer_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_transfer_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<InvoiceUnTransferModel> GetUntransfer(int branchId)
        {
            var sql = @"SELECT
	                        si.ref_number RefNumber,
	                        idr.date_process DateProcess,
                            si.company_invoiced_to CustomerName,
                            si.period Period
                        FROM invoice_distribution_result_detail idrd
                        INNER JOIN invoice_distribution_result idr ON idrd.invoice_distribution_result_id = idr.id AND idr.rowstatus = 1
                        INNER JOIN sales_invoice si ON idrd.sales_invoice_id = si.id AND si.rowstatus = 1 AND si.cancelled = 0
                        LEFT JOIN invoice_transfer_detail itd ON itd.sales_invoice_id = si.id AND itd.rowstatus = 1
                        LEFT JOIN invoice_transfer it ON itd.invoice_transfer_id = it.id AND it.rowstatus = 1
                        WHERE idr.branch_id = @branchId AND idrd.rowstatus = 1 AND idrd.payment_type_id = 6 AND itd.id IS NULL AND it.id IS NULL;";

            return Entities.ExecuteStoreQuery<InvoiceUnTransferModel>(sql, new MySqlParameter("branchId", branchId)).ToList();
        }

        public List<TransferDetailModel> GetDetails (int transferId)
        {
            var sql = @"SELECT
	                        itd.id Id,
	                        it.id InvoiceTransferId,
                            si.id SalesInvoiceId,
                            si.ref_number RefNumber,
	                        si.company_invoiced_to CustomerName,
	                        si.period,
                            'SELECT' StateChange
                        FROM invoice_transfer_detail itd 
                        INNER JOIN invoice_transfer it ON itd.invoice_transfer_id = it.id AND it.rowstatus = 1
                        INNER JOIN sales_invoice si ON itd.sales_invoice_id = si.id
                        WHERE itd.rowstatus = 1 AND it.id = @transferId;";

            return Entities.ExecuteStoreQuery<TransferDetailModel>(sql, new MySqlParameter("transferId", transferId)).ToList();
        }

        public bool IsTransfered(string refNumber)
        {
            var sql = @"SELECT
	                        itd.id Id,
	                        it.id InvoiceTransferId,
                            si.id SalesInvoiceId,
                            si.ref_number RefNumber,
	                        si.company_invoiced_to CustomerName,
	                        si.period,
                            'SELECT' StateChange
                        FROM invoice_transfer_detail itd 
                        INNER JOIN invoice_transfer it ON itd.invoice_transfer_id = it.id AND it.rowstatus = 1
                        INNER JOIN sales_invoice si ON itd.sales_invoice_id = si.id
                        WHERE itd.rowstatus = 1 AND si.ref_number = @refNumber;";

            var data = Entities.ExecuteStoreQuery<TransferDetailModel>(sql, new MySqlParameter("refNumber", refNumber)).FirstOrDefault();
            return data != null;
        }
    }
}