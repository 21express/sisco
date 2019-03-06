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
    public class InvoiceTransferAcceptanceDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "InvoiceTransferAcceptanceDetail";
        public InvoiceTransferAcceptanceDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public InvoiceTransferAcceptanceDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as InvoiceTransferAcceptanceDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToinvoice_transfer_acceptance_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as InvoiceTransferAcceptanceDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.invoice_transfer_acceptance_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as InvoiceTransferAcceptanceDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.invoice_transfer_acceptance_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.invoice_transfer_acceptance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.invoice_transfer_acceptance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static invoice_transfer_acceptance_detail PopulateModelToNewEntity(InvoiceTransferAcceptanceDetailModel model)
		{
			return new invoice_transfer_acceptance_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				invoice_transfer_acceptance_id = model.InvoiceTransferAcceptanceId,
                sales_invoice_id = model.SalesInvoiceId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(invoice_transfer_acceptance_detail query, InvoiceTransferAcceptanceDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.invoice_transfer_acceptance_id = model.InvoiceTransferAcceptanceId;
            query.sales_invoice_id = model.SalesInvoiceId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static InvoiceTransferAcceptanceDetailModel PopulateEntityToNewModel(invoice_transfer_acceptance_detail item)
		{
            return new InvoiceTransferAcceptanceDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				InvoiceTransferAcceptanceId = item.invoice_transfer_acceptance_id,
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
			var query = (from a in Entities.invoice_transfer_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_transfer_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_transfer_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.airlines select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.invoice_transfer_acceptance_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_transfer_acceptance_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<UnacceptedTransferModel> GetUnAcceptedTransfer(int branchId)
        {
            var sql = @"SELECT
	                        si.ref_number RefNumber,
                            si.company_invoiced_to CustomerName,
                            si.period Period
                        FROM invoice_transfer_detail itd
                        INNER JOIN invoice_transfer it ON itd.invoice_transfer_id = it.id AND it.rowstatus = 1
                        INNER JOIN sales_invoice si ON itd.sales_invoice_id = si.id AND si.rowstatus = 1 AND si.cancelled = 0
                        LEFT JOIN invoice_transfer_acceptance_detail itad ON si.id = itad.sales_invoice_id AND itad.rowstatus = 1
                        LEFT JOIN invoice_transfer_acceptance ita ON itad.invoice_transfer_acceptance_id = ita.id AND ita.rowstatus = 1
                        WHERE itd.rowstatus = 1 AND it.branch_id = @branchId AND itad.id IS NULL AND ita.id IS NULL;";

            return Entities.ExecuteStoreQuery<UnacceptedTransferModel>(sql, new MySqlParameter("branchId", branchId)).ToList();
        }

        public List<TransferAcceptanceDetailModel> GetDetails (int acceptanceId)
        {
            var sql = @"SELECT
	                        itad.id Id,
	                        itad.invoice_transfer_acceptance_id InvoiceTransferAcceptanceId,
                            si.id SalesInvoiceId,
                            si.ref_number RefNumber,
                            si.company_invoiced_to CustomerName,
                            si.period Period,
                            'SELECT' StateChange
                        FROM invoice_transfer_acceptance_detail itad
                        INNER JOIN invoice_transfer_acceptance ita ON itad.invoice_transfer_acceptance_id = ita.id AND ita.rowstatus = 1
                        INNER JOIN sales_invoice si ON itad.sales_invoice_id = si.id
                        WHERE itad.rowstatus = 1 AND ita.id = @acceptanceId;";

            return Entities.ExecuteStoreQuery<TransferAcceptanceDetailModel>(sql, new MySqlParameter("acceptanceId", acceptanceId)).ToList();
        }

        public bool IsAccepted(string refNumber)
        {
            var sql = @"SELECT
	                        itad.id Id,
	                        itad.invoice_transfer_acceptance_id InvoiceTransferAcceptanceId,
                            si.id SalesInvoiceId,
                            si.ref_number RefNumber,
                            si.company_invoiced_to CustomerName,
                            si.period Period,
                            'SELECT' StateChange
                        FROM invoice_transfer_acceptance_detail itad
                        INNER JOIN invoice_transfer_acceptance ita ON itad.invoice_transfer_acceptance_id = ita.id AND ita.rowstatus = 1
                        INNER JOIN sales_invoice si ON itad.sales_invoice_id = si.id
                        WHERE itad.rowstatus = 1 AND si.ref_number = @refNumber;";

            var data = Entities.ExecuteStoreQuery<TransferAcceptanceDetailModel>(sql, new MySqlParameter("refNumber", refNumber)).FirstOrDefault();
            return data != null;
        }
    }
}