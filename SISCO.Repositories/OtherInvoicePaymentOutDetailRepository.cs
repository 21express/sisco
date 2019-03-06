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
    public class OtherInvoicePaymentOutDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "OtherInvoicePaymentOutDetail";
        public OtherInvoicePaymentOutDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public OtherInvoicePaymentOutDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as OtherInvoicePaymentOutDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToother_invoice_payment_out_detail(entity);

            businessModel.Id = entity.id;
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as OtherInvoicePaymentOutDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.other_invoice_payment_out_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as OtherInvoicePaymentOutDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.other_invoice_payment_out_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.other_invoice_payment_out_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.other_invoice_payment_out_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static other_invoice_payment_out_detail PopulateModelToNewEntity(OtherInvoicePaymentOutDetailModel model)
		{
			return new other_invoice_payment_out_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				other_invoice_payment_out_id = model.OtherInvoicePaymentOutId,
				date_process = model.DateProcess,
				invoice_id = model.InvoiceId,
				invoice_date = model.InvoiceDate,
				invoice_code = model.InvoiceCode,
				invoice_total = model.InvoiceTotal,
				invoice_balance = model.InvoiceBalance,
				payment = model.Payment,
				balance = model.Balance,
				@checked = model.Checked,
                total_pph = model.TotalPph,
				paid = model.Paid,
				invoice_ref_number = model.InvoiceRefNumber,
                note = model.Note,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(other_invoice_payment_out_detail query, OtherInvoicePaymentOutDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.other_invoice_payment_out_id = model.OtherInvoicePaymentOutId;
			query.date_process = model.DateProcess;
			query.invoice_id = model.InvoiceId;
			query.invoice_date = model.InvoiceDate;
			query.invoice_code = model.InvoiceCode;
			query.invoice_total = model.InvoiceTotal;
			query.invoice_balance = model.InvoiceBalance;
			query.payment = model.Payment;
			query.balance = model.Balance;
			query.@checked = model.Checked;
            query.total_pph = model.TotalPph;
			query.paid = model.Paid;
			query.invoice_ref_number = model.InvoiceRefNumber;
            query.note = model.Note;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static OtherInvoicePaymentOutDetailModel PopulateEntityToNewModel(other_invoice_payment_out_detail item)
		{
			return new OtherInvoicePaymentOutDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				OtherInvoicePaymentOutId = item.other_invoice_payment_out_id,
				DateProcess = item.date_process,
				InvoiceId = item.invoice_id,
				InvoiceDate = item.invoice_date,
				InvoiceCode = item.invoice_code,
				InvoiceTotal = item.invoice_total,
				InvoiceBalance = item.invoice_balance,
				Payment = item.payment,
				Balance = item.balance,
				Checked = item.@checked,
                TotalPph = item.total_pph,
				Paid = item.paid,
				InvoiceRefNumber = item.invoice_ref_number,
                Note = item.note,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_out_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_out_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_out_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.other_invoice_payment_out_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public List<OtherInvoicePaymentOutDetailModel> GetPaymentInvoice(int origBranchId, int origBranchPayment)
        {
            var sql = @"SELECT
	                        oi.id InvoiceId,
                            opid.invoice_code InvoiceCode,
                            opid.invoice_date InvoiceDate,
                            opid.invoice_total InvoiceTotal,
                            SUM(opid.payment) - IF (opod.id IS NULL, 0, SUM(opod.payment)) InvoiceBalance,
                            0 Payment,
	                        SUM(opid.payment) - IF (opod.id IS NULL, 0, SUM(opod.payment)) Balance,
                            ROUND(opid.total_pph23) TotalPph,
                            0 Checked,
                            opid.invoice_ref_number InvoiceRefNumber,
                            'Idle' StateChange2
                        FROM siscodb.other_invoice_payment_in_detail opid
                        INNER JOIN siscodb.other_invoice_payment_in opi ON opid.other_invoice_payment_in_id = opi.id AND opi.rowstatus = 1
                        INNER JOIN siscodb.other_invoice oi ON opid.invoice_id = oi.id AND oi.rowstatus = 1 AND oi.owner_branch_id = {0} AND oi.branch_id = {1}
                        LEFT JOIN siscodb.other_invoice_payment_out_detail opod ON oi.id = opod.invoice_id AND opod.rowstatus = 1
                        LEFT JOIN siscodb.other_invoice_payment_out opo ON opod.other_invoice_payment_out_id = opo.id AND opo.rowstatus = 1
                        WHERE opid.rowstatus = 1 AND opid.cancelled = 0 AND ((opod.id IS NULL && opo.id IS NULL) || (opod.id IS NOT NULL && opo.id IS NOT NULL))
                        GROUP BY oi.id
                        HAVING Balance > 0
                        ORDER BY opi.id;";

            sql = string.Format(sql, origBranchId, origBranchPayment);

            return Entities.ExecuteStoreQuery<OtherInvoicePaymentOutDetailModel>(sql).ToList();
        }

        public int GetTotalPayment(int invoiceId)
        {
            var sql = @"SELECT
	                        IF (opod.id IS NULL, 0, SUM(opod.payment))
                        FROM siscodb.other_invoice_payment_in_detail opid
                        INNER JOIN siscodb.other_invoice_payment_in opi ON opid.other_invoice_payment_in_id = opi.id AND opi.rowstatus = 1
                        INNER JOIN siscodb.other_invoice oi ON opid.invoice_id = oi.id AND oi.rowstatus = 1
                        LEFT JOIN siscodb.other_invoice_payment_out_detail opod ON oi.id = opod.invoice_id AND opod.rowstatus = 1
                        LEFT JOIN siscodb.other_invoice_payment_out opo ON opod.other_invoice_payment_out_id = opo.id AND opo.rowstatus = 1
                        WHERE opid.rowstatus = 1 AND ((opod.id IS NULL && opo.id IS NULL) || (opod.id IS NOT NULL && opo.id IS NOT NULL)) AND opid.invoice_id = {0};";
            
            sql = string.Format(sql, invoiceId);

            return Entities.ExecuteStoreQuery<int>(sql).First();
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<OtherInvoicePaymentOutModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.other_invoice_payment_out_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.other_invoice_payment_out_id equals m.Id
                                                             join b in Entities.branches on m.BranchId equals b.id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 CustomerName = b.name,
                                                                 Kwitansi = a.invoice_ref_number
                                                             }).ToList();

            return obj;
        }
    }
}