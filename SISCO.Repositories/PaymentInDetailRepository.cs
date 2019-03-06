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
    public class PaymentInDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PaymentInDetail";
        public PaymentInDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PaymentInDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PaymentInDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopayment_in_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PaymentInDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.payment_in_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PaymentInDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.payment_in_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.payment_in_detail where d.id == id select d).FirstOrDefault();
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
            var query = (from d in Entities.payment_in_detail select d).Where(whereterm, ListValue.ToArray()).ToList();

            if (query == null)
				throw new ModelNullException(MessageEntityNotFound);

            var objs = (IEnumerable<PaymentInDetailModel>) query.Select(PopulateEntityToNewModel).ToList();
            foreach (PaymentInDetailModel obj in objs)
            {
                obj.Rowstatus = false;
                obj.Modifiedby = userName;
                obj.Modifieddate = DateTime.Now;
            }

            Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.payment_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static payment_in_detail PopulateModelToNewEntity(PaymentInDetailModel model)
		{
			return new payment_in_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				payment_in_id = model.PaymentInId,
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
				invoice_type = model.InvoiceType,
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
        
        private static void PopulateModelToNewEntity(payment_in_detail query, PaymentInDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.payment_in_id = model.PaymentInId;
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
			query.invoice_type = model.InvoiceType;
			query.invoice_ref_number = model.InvoiceRefNumber;
            query.use_pph23 = model.UsePph23;
            query.total_pph23 = model.TotalPph23;
            query.use_materai = model.UseMaterai;
            query.materai_fee = model.MateraiFee;
            query.date_return = model.DateReturn;
            query.is_returned = model.IsReturn;
            query.note = model.Note;
            query.refund_id = model.RefundId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static PaymentInDetailModel PopulateEntityToNewModel(payment_in_detail item)
        {
            var x = EnumStateChange.Select.ToString();
			return new PaymentInDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				PaymentInId = item.payment_in_id,
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
				InvoiceType = item.invoice_type,
				InvoiceRefNumber = item.invoice_ref_number,
                UsePph23 = item.use_pph23,
                TotalPph23 = item.total_pph23,
                UseMaterai = item.use_materai,
                MateraiFee = item.materai_fee,
                DateReturn = item.date_return,
                IsReturn = item.is_returned,
                Note = item.note,
                RefundId = item.refund_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                StateChange2 = x,
                PayType = 1
			};
		}

        public IEnumerable<PaymentInDetailModel> GetKwitansi(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (from item in query
                join p in Entities.payment_in on item.payment_in_id equals p.id
                select new PaymentInDetailModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    PaymentInId = item.payment_in_id,
                    PaymentInCode = p.code,
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
                    InvoiceType = item.invoice_type,
                    InvoiceRefNumber = item.invoice_ref_number,
                    UsePph23 = item.use_pph23,
                    TotalPph23 = item.total_pph23,
                    UseMaterai = item.use_materai,
                    MateraiFee = item.materai_fee,
                    DateReturn = item.date_return,
                    IsReturn = item.is_returned,
                    Note = item.note,
                    RefundId = item.refund_id,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    StateChange2 = x
                }).ToList();

            return obj;
        }
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public int GetPaymentInvoice(int invoiceId)
        {
            var whereterm = GetQueryParameterLinq(new IListParameter[] { WhereTerm.Default(invoiceId, "invoice_id", EnumSqlOperator.Equals) });
            var query = (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();

            var invoices = (IEnumerable<PaymentInDetailModel>)query.Select(PopulateEntityToNewModel).ToList();
            if (invoices.Any())
            {
                return (int) invoices.Sum(p => p.Payment);
            }
            
            return 0;
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<PaymentInModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
                var query = (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>) (from a in query
                       join m in master on a.payment_in_id equals m.Id
                       select new PaymentInAndDetailModel
                       {
                           DateProcess = m.DateProcess,
                           Code = m.Code,
                           CustomerName = m.CustomerName,
                           PaymentType = m.PaymentType,
                           Kwitansi = a.invoice_ref_number
                       }).ToList();

            return obj;
        }
    }
}