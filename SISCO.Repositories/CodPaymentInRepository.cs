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
    public class CodPaymentInRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "COD Payment In";
        public CodPaymentInRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CodPaymentInRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CodPaymentInModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocod_payment_in(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as CodPaymentInModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.cod_payment_in where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CodPaymentInModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.cod_payment_in select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.cod_payment_in where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.cod_payment_in where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static cod_payment_in PopulateModelToNewEntity(CodPaymentInModel model)
		{
			return new cod_payment_in
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
                code = model.Code,
                branch_id = model.BranchId,
                description = model.Description,
                total = model.Total,
                fund_transfer = model.FundTransfer,
                total_cash = model.TotalCash,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(cod_payment_in query, CodPaymentInModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.code = model.Code;
            query.branch_id = model.BranchId;
            query.description = model.Description;
            query.total = model.Total;
            query.fund_transfer = model.FundTransfer;
            query.total_cash = model.TotalCash;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}

        private static CodPaymentInModel PopulateEntityToNewModel(cod_payment_in item)
		{
            return new CodPaymentInModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
                Code = item.code,
                BranchId = item.branch_id,
                Description = item.description,
                Total = item.total,
                FundTransfer = item.fund_transfer,
                TotalCash = item.total_cash,
				Createddate = item.createddate,
				Createdby = item.createdby,
                CreatedPc = item.createdpc,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                ModifiedPc = item.modifiedpc,
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cod_payment_in select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_payment_in select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_payment_in select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_payment_in select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.cod_payment_in select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_payment_in select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<CodFundTransferDetailModel> GetUnpaidCodPayment(int branchId)
        {
            var whereterm = GetQueryParameterLinq(new IListParameter[]
            {
                WhereTerm.Default(false, "fund_transfer"),
                WhereTerm.Default(branchId, "branch_id")
            });

            var query = (from f in Entities.cod_payment_in select f).Where(whereterm, ListValue.ToArray()).ToList();
            var result = (from f in query
                          select new CodFundTransferDetailModel
                          {
                              InvoiceId = f.id,
                              InvoiceCode = f.code,
                              InvoiceDate = f.date_process,
                              InvoiceTotal = f.total,
                              Checked = false,
                              StateChange2 = EnumStateChange.Insert.ToString()
                          }).ToList();

            return result;
        }

        public List<OutstandingCod> GetOutstandingPayment(int branchId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = 1");
            whereClauses.Add("s.voided = 0");
            whereClauses.Add("se.iscod = 1");

            if (branchId != 24) whereClauses.Add("s.dest_branch_id = " + branchId);

            string sql = @"
                            SELECT
	                            s.id Id, s.`code` `Code`, s.date_process DateProcess, se.total_cod Total, s.dest_branch_id BranchId, b.`name` BranchName,
                                IF(fi.id IS NULL, 0, 1) Paid, fi.`code` PaymentCode, fi.date_process PaymentDate,
                                IF(s.dest_branch_id = 24, IF(fi.id IS NULL, 0, 1), IF(ft.id IS NULL, 0, 1)) Transfer, ft.`code` TransferCode, ft.date_process TransferDate,
                                IF(s.dest_branch_id = 24, IF(fi.id IS NULL, 0, 1), IF(ft.confirm_admin = 1, 1, 0)) Verify, fv.`code` VerifyCode, fv.date_process VerifyDate,
                                IF(ss.id IS NULL, 0, 1) Received, ss.status_by StatusBy, ss.dateprocess StatusDate
                            FROM shipment s
                            INNER JOIN shipment_expand se ON s.id = se.shipment_id
                            LEFT JOIN shipment_status ss ON s.id = ss.shipment_id AND ss.rowstatus = 1 AND ss.tracking_status_id = 10
                            LEFT JOIN cod_payment_in_detail fp ON s.id = fp.shipment_id AND fp.rowstatus = 1
                            LEFT JOIN cod_payment_in fi ON fp.cod_payment_in_id = fi.id AND fi.rowstatus = 1
                            LEFT JOIN cod_fund_transfer_detail ff ON fi.id = ff.invoice_id AND ff.rowstatus = 1
                            LEFT JOIN cod_fund_transfer ft ON ff.cod_fund_transfer_id = ft.id AND ft.rowstatus = 1
                            LEFT JOIN cod_fund_transfer_verification_detail fvd ON ft.id = fvd.invoice_id AND fvd.rowstatus = 1
                            LEFT JOIN cod_fund_transfer_verification fv ON fvd.cod_fund_transfer_verification_id = fv.id AND fv.rowstatus = 1
                            INNER JOIN branch b ON s.dest_branch_id = b.id
                            WHERE " + string.Join(" AND ", whereClauses) + " HAVING paid = 0 OR transfer = 0 OR verify = 0";

            return Entities.ExecuteStoreQuery<OutstandingCod>(sql, parameters.ToArray()).ToList();
        }

        public List<CodPaymentReport> GetCodPaymentReport(int branchId, DateTime fromDate, DateTime toDate)
        {
            var sql = @"SELECT
	                        ci.date_process DateProcess, 
                            ci.code Code,
                            ci.description Description,
                            cid.shipment_code ShipmentCode,
                            cid.delivery_code DeliveryCode,
                            cid.total_cod TotalCod,
                            cid.actual_paid ActualPaid,
                            ci.total TotalSales,
                            ci.total_cash TotalCash
                        FROM cod_payment_in ci
                        INNER JOIN cod_payment_in_detail cid ON cid.cod_payment_in_id = ci.id AND cid.rowstatus = 1 AND cid.actual_paid > 0
                        WHERE
	                        ci.rowstatus = 1 AND ci.branch_id = @branchId AND ci.date_process >= @fromDate AND ci.date_process <= @toDate";

            var sqlParam = new List<MySqlParameter>();
            sqlParam.Add(new MySqlParameter("branchId", branchId));
            sqlParam.Add(new MySqlParameter("fromDate", fromDate));
            sqlParam.Add(new MySqlParameter("toDate", toDate));

            return Entities.ExecuteStoreQuery<CodPaymentReport>(sql, sqlParam.ToArray()).ToList();
        }
    }
}