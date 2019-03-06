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
    public class FranchisePaymentInDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "FranchisePaymentInCounter";
        public FranchisePaymentInDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchisePaymentInDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchisePaymentInDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_payment_in_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchisePaymentInDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_payment_in_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchisePaymentInDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_payment_in_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_payment_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.franchise_payment_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_payment_in_detail PopulateModelToNewEntity(FranchisePaymentInDetailModel model)
		{
            return new franchise_payment_in_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				franchise_payment_in_id = model.FranchisePaymentInId,
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

        private static void PopulateModelToNewEntity(franchise_payment_in_detail query, FranchisePaymentInDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.franchise_payment_in_id = model.FranchisePaymentInId;
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

        private static FranchisePaymentInDetailModel PopulateEntityToNewModel(franchise_payment_in_detail item)
        {
            var x = EnumStateChange.Select.ToString();
            return new FranchisePaymentInDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				FranchisePaymentInId = item.franchise_payment_in_id,
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
				Modifiedby = item.modifiedby,
                StateChange2 = x
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.franchise_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_payment_in_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<FranchisePaymentInModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.franchise_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.franchise_payment_in_id equals m.Id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 CustomerName = string.Empty,
                                                                 PaymentType = string.Empty,
                                                                 Kwitansi = a.invoice_code
                                                             }).ToList();

            return obj;
        }
    }
}