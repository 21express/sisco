using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class FranchisePaymentInRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "FranchisePaymentIn";
        public FranchisePaymentInRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchisePaymentInRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchisePaymentInModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_payment_in(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchisePaymentInModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_payment_in where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchisePaymentInModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_payment_in select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_payment_in where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.franchise_payment_in where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_payment_in PopulateModelToNewEntity(FranchisePaymentInModel model)
		{
			return new franchise_payment_in
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
				payment_type_id = model.PaymentTypeId,
				amount = model.Amount,
				total_invoice = model.TotalInvoice,
				total = model.Total,
				adjustment = model.Adjustment,
                fund_transfer = model.FundTransfer,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}

        private static void PopulateModelToNewEntity(franchise_payment_in query, FranchisePaymentInModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.payment_type_id = model.PaymentTypeId;
			query.amount = model.Amount;
			query.total_invoice = model.TotalInvoice;
			query.total = model.Total;
			query.adjustment = model.Adjustment;
            query.fund_transfer = model.FundTransfer;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}

        private static FranchisePaymentInModel PopulateEntityToNewModel(franchise_payment_in item)
		{
            return new FranchisePaymentInModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
				PaymentTypeId = item.payment_type_id,
				Amount = item.amount,
				TotalInvoice = item.total_invoice,
				Total = item.total,
				Adjustment = item.adjustment,
                FundTransfer = item.fund_transfer,
				Createddate = item.createddate,
				Createdby = item.createdby,
                CreatedPc = item.createdpc,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                ModifiedPc = item.modifiedpc
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.franchise_payment_in select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.franchise_payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_payment_in select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_payment_in select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<PaymentInJournal> DetailJournal(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.franchise_payment_in select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from d in (from d in Entities.franchise_payment_in_detail where d.rowstatus.Equals(true) select d)
                join q in query on d.franchise_payment_in_id equals q.id
                select new PaymentInJournal
                {
                    Code = q.code,
                    DateProcces = d.date_process,
                    PaymentType = "CASH",
                    Description = d.invoice_code,
                    Company = "Not Available",
                    Balance = d.invoice_balance,
                    Total = d.payment
                }).ToList();

            return obj;
        }

        public List<FranchiseFundTransferDetailModel> GetUnpaidFranchisePayment(int branchId)
        {
            var whereterm = GetQueryParameterLinq(new IListParameter[]
            {
                WhereTerm.Default(false, "fund_transfer"),
                WhereTerm.Default(branchId, "branch_id")
            });

            var query = (from f in Entities.franchise_payment_in select f).Where(whereterm, ListValue.ToArray()).ToList();
            var result = (from f in query
                          select new FranchiseFundTransferDetailModel
                              {
                                  InvoiceId = f.id,
                                  InvoiceCode = f.code,
                                  InvoiceDate = f.date_process,
                                  InvoiceTotal = f.total,
                                  Checked = false,
                                  StateChange = EnumStateChange.Insert
                              }).ToList();

            return result;
        }

        public List<OutstandingPayment> GetOutstandingPayment(int? franchiseId, int branchId, int paymentId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = 1");
            whereClauses.Add("s.voided = 0");
            if (franchiseId != null) whereClauses.Add("f.id = " + franchiseId);
            if (branchId != 24) whereClauses.Add("s.branch_id = " + branchId);
            whereClauses.Add("f.payment_method_id = " + paymentId);

            string sql = @"
                            SELECT
	                            s.id Id, s.`code` `Code`, s.date_process DateProcess, fc.debs Total, f.id FranchiseId, f.branch_id BranchId, b.`name` BranchName, f.`code` FranchiseCode, f.`name` FranchiseName,
                                IF(fi.id IS NULL, 0, 1) Paid, fi.`code` PaymentCode, fi.date_process PaymentDate,
                                IF(f.branch_id = 24, IF(fi.id IS NULL, 0, 1), IF(ft.id IS NULL, 0, 1)) Transfer, ft.`code` TransferCode, ft.date_process TransferDate,
                                IF(f.branch_id = 24, IF(fi.id IS NULL, 0, 1), IF(ft.confirm_admin = 1, 1, 0)) Verify, fv.`code` VerifyCode, fv.date_process VerifyDate
                            FROM shipment s
                            INNER JOIN franchise f ON s.franchise_id = f.id
                            INNER JOIN franchise_commission fc ON s.id = fc.shipment_id AND f.id = fc.franchise_id
                            LEFT JOIN franchise_payment_in_detail fp ON s.id = fp.invoice_id AND fp.rowstatus = 1
                            LEFT JOIN franchise_payment_in fi ON fp.franchise_payment_in_id = fi.id AND fi.rowstatus = 1
                            LEFT JOIN franchise_fund_transfer_detail ff ON fi.id = ff.invoice_id AND ff.rowstatus = 1
                            LEFT JOIN franchise_fund_transfer ft ON ff.franchise_fund_transfer_id = ft.id AND ft.rowstatus = 1
                            LEFT JOIN franchise_fund_transfer_verification_detail fvd ON ft.id = fvd.invoice_id AND fvd.rowstatus = 1
                            LEFT JOIN franchise_fund_transfer_verification fv ON fvd.franchise_fund_transfer_verification_id = fv.id AND fv.rowstatus = 1
                            INNER JOIN branch b ON f.branch_id = b.id
                            WHERE " + string.Join(" AND ", whereClauses) + " HAVING paid = 0 OR transfer = 0 OR verify = 0";

            return Entities.ExecuteStoreQuery<OutstandingPayment>(sql, parameters.ToArray()).ToList();
        }
    }
}