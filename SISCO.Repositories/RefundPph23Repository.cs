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
    public class RefundPph23Repository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "RefundPph23";
        public RefundPph23Repository()
        {
            ObjectName = OBJECT_NAME;
        }

        public RefundPph23Repository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as RefundPph23Model;
            if (model == null)
                throw new ModelNullException();

            var entity = PopulateModelToNewEntity(model);
            Entities.AddTorefund_pph23(entity);
            Entities.SaveChanges();

            model.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as RefundPph23Model;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.refund_pph23 where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as RefundPph23Model;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.refund_pph23 select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.refund_pph23 where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.refund_pph23 where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static refund_pph23 PopulateModelToNewEntity(RefundPph23Model model)
		{
            return new refund_pph23
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
                date_process = model.DateProcess,
				rowversion = model.Rowversion,
                code = model.Code,
                branch_id = model.BranchId,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.Createdpc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.Modifiedpc
			};
		}
        
        private static void PopulateModelToNewEntity(refund_pph23 query, RefundPph23Model model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.code = model.Code;
            query.branch_id = model.BranchId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.Createdpc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.Modifiedpc;
		}
        
        private static RefundPph23Model PopulateEntityToNewModel(refund_pph23 item)
		{
			return new RefundPph23Model
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess= item.date_process,
				Code = item.code,
                BranchId = item.branch_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
                Createdpc = item.createdpc,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                Modifiedpc = item.modifiedpc,
                StateChange = EnumStateChange.Idle
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.refund_pph23 select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.refund_pph23 select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.refund_pph23 select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.refund_pph23 select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<RefundPph23Model> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.refund_id equals m.Id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 Kwitansi = a.invoice_ref_number
                                                             }).ToList();

            if (obj.Count() == 0)
            {
                var q =
                (from a in Entities.other_invoice_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

                obj = (IEnumerable<PaymentInAndDetailModel>)(from a in q
                                                                 join m in master on a.refund_id equals m.Id
                                                                 select new PaymentInAndDetailModel
                                                                 {
                                                                     DateProcess = m.DateProcess,
                                                                     Code = m.Code,
                                                                     Kwitansi = a.invoice_ref_number
                                                                 }).ToList();
            }

            return obj;
        }

        public List<ReturnPph23> ReturnPph23Report(int branchId, DateTime? from, DateTime? to)
        {
            var sql = @"SELECT
	                        r.code Code,
                            r.date_process DateReturn,
                            pd.invoice_ref_number RefNumber,
                            pd.date_process DateProcess,
                            p.customer_id CompanyId,
                            p.customer_name Company,
                            pd.invoice_total TotalInvoice,
                            pd.total_pph23 TotalPph,
                            1 PayType
                        FROM siscodb.refund_pph23 r 
                        INNER JOIN siscodb.payment_in_detail pd ON r.id = pd.refund_id AND pd.rowstatus = 1
                        INNER JOIN siscodb.payment_in p ON pd.payment_in_id = p.id AND p.rowstatus = 1
                        WHERE r.rowstatus = 1 AND r.branch_id = {0}{1}

                        UNION

                        SELECT
	                        r.code Code,
                            r.date_process DateReturn,
                            pd.invoice_ref_number RefNumber,
                            pd.date_process DateProcess,
                            si.company_id CompanyId,
                            si.company_invoiced_to Company,
                            pd.invoice_total TotalInvoice,
                            pd.total_pph23 TotalPph,
                            2 PayType
                        FROM siscodb.refund_pph23 r 
                        INNER JOIN siscodb.other_invoice_payment_in_detail pd ON r.id = pd.refund_id AND pd.rowstatus = 1
                        INNER JOIN siscodb.other_invoice_payment_in p ON pd.other_invoice_payment_in_id = p.id AND p.rowstatus = 1
                        INNER JOIN sales_invoice si ON pd.invoice_ref_number = si.ref_number AND si.rowstatus = 1
                        WHERE r.rowstatus = 1 AND r.branch_id = {0}{1}

                        ORDER BY RefNumber;";

            var sqlFilter = string.Empty;
            if (from != null) sqlFilter += string.Format(" AND r.date_process >= '{0}'", ((DateTime)from).ToString("yyyy-MM-dd HH:mm:ss"));
            if (to != null) sqlFilter += string.Format(" AND r.date_process <= '{0}'", ((DateTime)to).ToString("yyyy-MM-dd HH:mm:ss"));

            sql = string.Format(sql, branchId, sqlFilter);
            return Entities.ExecuteStoreQuery<ReturnPph23>(sql).ToList();
        }
    }
}


