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
    public class OtherInvoicePaymentInDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "OtherInvoicePaymentInDetail";
        public OtherInvoicePaymentInDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public OtherInvoicePaymentInDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as OtherInvoicePaymentInDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToother_invoice_payment_in_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as OtherInvoicePaymentInDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.other_invoice_payment_in_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as OtherInvoicePaymentInDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.other_invoice_payment_in_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.other_invoice_payment_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.other_invoice_payment_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static other_invoice_payment_in_detail PopulateModelToNewEntity(OtherInvoicePaymentInDetailModel model)
		{
			return new other_invoice_payment_in_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				other_invoice_payment_in_id = model.OtherInvoicePaymentInId,
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
				invoice_ref_number = model.InvoiceRefNumber,
                use_pph23 = model.UsePph23,
                total_pph23 = model.TotalPph23,
                use_materai = model.UseMaterai,
                materai_fee = model.MateraiFee,
                date_return = model.DateReturn,
                is_returned = model.IsReturn,
                note = model.Note,
                refund_id = model.RefundId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(other_invoice_payment_in_detail query, OtherInvoicePaymentInDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.other_invoice_payment_in_id = model.OtherInvoicePaymentInId;
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
			query.invoice_ref_number = model.InvoiceRefNumber;
            query.use_pph23 = model.UsePph23;
            query.total_pph23 = model.TotalPph23;
            query.date_return = model.DateReturn;
            query.is_returned = model.IsReturn;
            query.use_materai = model.UseMaterai;
            query.materai_fee = model.MateraiFee;
            query.note = model.Note;
            query.refund_id = model.RefundId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static OtherInvoicePaymentInDetailModel PopulateEntityToNewModel(other_invoice_payment_in_detail item)
		{
            var state = EnumStateChange.Select.ToString();
			return new OtherInvoicePaymentInDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				OtherInvoicePaymentInId = item.other_invoice_payment_in_id,
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
				InvoiceRefNumber = item.invoice_ref_number,
                UsePph23 = item.use_pph23,
                TotalPph23 = item.total_pph23,
                DateReturn = item.date_return,
                IsReturn = item.is_returned,
                UseMaterai = item.use_materai,
                MateraiFee = item.materai_fee,
                Note = item.note,
                RefundId = item.refund_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                StateChange2 = state
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.other_invoice_payment_in_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public List<OtherInvoicePaymentInDetailModel> GetPaymentInvoice(int branchId)
        {
            var sql = @"SELECT
	                        oi.id InvoiceId,
                            oi.code InvoiceCode,
                            oi.date_process InvoiceDate,
                            oi.total InvoiceTotal,
                            oi.total - IF (od.id IS NULL, 0, SUM(od.payment)) InvoiceBalance,
                            0 Payment,
	                        oi.total - IF (od.id IS NULL, 0, SUM(od.payment)) Balance,
                            0 Checked, 
                            oi.ref_number InvoiceRefNumber,
                            'Idle' StateChange2
                        FROM siscodb.other_invoice oi
                        LEFT JOIN siscodb.other_invoice_payment_in_detail od ON oi.id = od.invoice_id AND od.rowstatus = 1
                        LEFT JOIN siscodb.other_invoice_payment_in o ON od.other_invoice_payment_in_id = o.id AND o.rowstatus = 1
                        WHERE oi.rowstatus = 1 AND oi.branch_id = {0} 
                        GROUP BY oi.id
                        HAVING Balance > 0;";

            sql = string.Format(sql, branchId);
            return Entities.ExecuteStoreQuery<OtherInvoicePaymentInDetailModel>(sql).ToList();
        }

        public int GetTotalPayment(int invoiceId)
        {
            var sql = @"SELECT
                            IF (od.id IS NULL, 0, SUM(od.payment)) Payment
                        FROM siscodb.other_invoice oi
                        LEFT JOIN siscodb.other_invoice_payment_in_detail od ON oi.id = od.invoice_id AND od.rowstatus = 1
                        LEFT JOIN siscodb.other_invoice_payment_in o ON od.other_invoice_payment_in_id = o.id AND o.rowstatus = 1
                        WHERE oi.rowstatus = 1 AND oi.id = {0}
                        GROUP BY oi.id;";

            sql = string.Format(sql, invoiceId);
            return Entities.ExecuteStoreQuery<int>(sql).First();
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<OtherInvoicePaymentInModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.other_invoice_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.other_invoice_payment_in_id equals m.Id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 Kwitansi = a.invoice_ref_number
                                                             }).ToList();

            return obj;
        }
    }
}