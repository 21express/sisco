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
    public class ClaimedRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Claimed";
        public ClaimedRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ClaimedRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ClaimedModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToclaimeds(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as ClaimedModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.claimeds where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ClaimedModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.claimeds select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.claimeds where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.claimeds where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static claimed PopulateModelToNewEntity(ClaimedModel model)
		{
			return new claimed
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                branch_id = model.BranchId,
				date_process = model.DateProcess,
                customer_name = model.CustomerName,
                claimed_branch_id = model.ClaimedBranchId,
                customer_branch_id = model.CustomerBranchId,
                letter_no = model.LetterNo,
                description = model.Description,
                doc_name = model.DocName,
                total = model.Total,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(claimed query, ClaimedModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.branch_id = model.BranchId;
            query.date_process = model.DateProcess;
            query.customer_name = model.CustomerName;
            query.claimed_branch_id = model.ClaimedBranchId;
            query.customer_branch_id = model.CustomerBranchId;
            query.letter_no = model.LetterNo;
            query.description = model.Description;
            query.doc_name = model.DocName;
            query.total = model.Total;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static ClaimedModel PopulateEntityToNewModel(claimed item)
		{
			return new ClaimedModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                BranchId = item.branch_id,
				DateProcess = item.date_process,
                CustomerName = item.customer_name,
                ClaimedBranchId = item.claimed_branch_id,
                CustomerBranchId = item.customer_branch_id,
                LetterNo = item.letter_no,
                Description = item.description,
                DocName = item.doc_name,
                Total = item.total,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.claimeds select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.claimeds select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.claimeds select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.claimeds select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            //expression = GetQueryParameterLinqRaw(expression, ref parameters);
            //var query = (from a in Entities.claimeds select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            //if (query == null)
            //    throw new Exception(MessageEntityNotFound);
            //var tquery = (from a in Entities.claimeds select a).Where(expression, parameters);
            //totalCount = tquery.Count();
            //return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();

            var sql = @"select
	                        c.id Id,
                            c.date_process DateProcess,
                            c.branch_id BranchId,
                            c.customer_name CustomerName,
                            c.claimed_branch_id ClaimedBranchId,
                            c.customer_branch_id CustomerBranchId,
                            c.letter_no LetterNo,
                            c.description Description,
                            c.doc_name DocName,
                            c.total Total
                        from claimed c 
                        left join vw_total_payment_claim vt on c.id = vt.claimed_id
                        where {0};";

            expression = string.Format("c.rowstatus = 1 and {0}", expression);
            expression += " and (vt.total_payment < c.total or vt.total_payment is null)";

            var listParam = new List<MySqlParameter>();
            listParam.Add(new MySqlParameter("letterNo", parameters[0]));
            listParam.Add(new MySqlParameter("customerName", string.Format("%{0}%", parameters[0])));
            listParam.Add(new MySqlParameter("custBranchId", parameters[1]));

            sql = string.Format(sql, expression);

            var result = Entities.ExecuteStoreQuery<ClaimedModel>(sql, listParam.ToArray()).ToList();
            totalCount = result.Count();
            return (IEnumerable<T>)result;
        }

        public List<ClaimedSearch> Search (int? branchId = null, string customerName = null, string letterNo = null, DateTime? from = null,
            DateTime? to = null, string shipmentCode = null, int? custBranchId = null, int? claimedBranchId = null)
        {
            var sql = @"select
	                        c.id Id,
                            c.date_process DateProcess,
                            c.customer_name CustomerName,
                            c.letter_no LetterNo,
                            c.total,
                            s.code ShipmentCode
                        from claimed c
                        inner join claimed_detail cd on c.id = cd.claimed_id and cd.rowstatus = 1
                        inner join shipment s on cd.shipment_id = s.id
                        where {0}";

            var sqlParam = new List<string>();
            var mysqlParam = new List<MySqlParameter>();

            sqlParam.Add("c.rowstatus = 1");

            if (branchId != null)
            {
                sqlParam.Add("c.branch_id = @branchId");
                mysqlParam.Add(new MySqlParameter("branchId", branchId));
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                sqlParam.Add("c.customer_name LIKE @customerName");
                mysqlParam.Add(new MySqlParameter("customerName", string.Format("%{0}%", customerName)));
            }

            if (!string.IsNullOrEmpty(letterNo))
            {
                sqlParam.Add("c.letter_no = @letterNo");
                mysqlParam.Add(new MySqlParameter("letterNo", letterNo));
            }

            if (!string.IsNullOrEmpty(shipmentCode))
            {
                sqlParam.Add("s.code = @shipmentCode");
                mysqlParam.Add(new MySqlParameter("shipmentCode", shipmentCode));
            }

            if (custBranchId != null)
            {
                sqlParam.Add("c.customer_branch_id = @custBranchId");
                mysqlParam.Add(new MySqlParameter("custBranchId", custBranchId));
            }

            if (claimedBranchId != null)
            {
                sqlParam.Add("c.claimed_branch_id = @claimedBranchId");
                mysqlParam.Add(new MySqlParameter("claimedBranchId", claimedBranchId));
            }

            if (from > DateTime.MinValue)
                sqlParam.Add(string.Format("c.date_process >= '{0}'", ((DateTime)from).ToString("yyyy-MM-dd 00:00:00")));

            if (to > DateTime.MinValue)
                sqlParam.Add(string.Format("c.date_process <= '{0}'", ((DateTime)to).ToString("yyyy-MM-dd 23:59:59")));

            sql = string.Format(sql, string.Join(" AND ", sqlParam));

            return Entities.ExecuteStoreQuery<ClaimedSearch>(sql, mysqlParam.ToArray()).ToList();
        }

        public List<ClaimedPaymentDetail> GetPaymentBalanceClaim(int custBranchId, string customerName = null, string letterNo = null)
        {
            var sql = @"select
	                        c.id Id,
                            c.customer_name CustomerName,
                            c.letter_no LetterNo,
                            c.doc_name DocName,
                            c.total Total,
                            c.total - if (vt.claimed_id is null, 0, vt.total_payment) Balance
                        from claimed c 
                        left join vw_total_payment_claim vt on c.id = vt.claimed_id
                        where {0};";

            var sqlParam = new List<string>();
            sqlParam.Add("c.rowstatus = 1");
            sqlParam.Add("c.customer_branch_id = @custBranchId");
            sqlParam.Add("(vt.total_payment < c.total or vt.total_payment is null)");

            if (!string.IsNullOrEmpty(customerName))
                sqlParam.Add(string.Format("c.customer_name LIKE '%{0}%'", customerName));

            if (!string.IsNullOrEmpty(letterNo))
                sqlParam.Add(string.Format("c.letter_no LIKE '%{0}%'", letterNo));

            sql = string.Format(sql, string.Join(" AND ", sqlParam));
            return Entities.ExecuteStoreQuery<ClaimedPaymentDetail>(sql, new MySqlParameter("custBranchId", custBranchId)).ToList();
        }

        public PaymentClaim GetClaim (int id)
        {
            var sql = @"select
	                        0 Id,
	                        c.id ClaimedId,
	                        c.customer_name CustomerName,
	                        c.letter_no LetterNo,
	                        c.doc_name DocName,
	                        c.total - if (vt.claimed_id is null, 0, vt.total_payment) Total,
	                        0 Payment,
                            'Select' StateChange
                        from claimed c 
                        left join vw_total_payment_claim vt on c.id = vt.claimed_id
                        where c.rowstatus = 1 and c.id = @id;";

            return Entities.ExecuteStoreQuery<PaymentClaim>(sql, new MySqlParameter("id", id)).FirstOrDefault();
        }

        public List<PaymentClaim> GetClaims(int paymentId)
        {
            var sql = @"select
	                        pca.id Id,
	                        pca.claimed_id ClaimedId,
	                        c.customer_name CustomerName,
	                        c.letter_no LetterNo,
	                        c.doc_name DocName,
	                        pca.payment + c.total - if (vt.claimed_id is null, 0, vt.total_payment) Total,
	                        pca.payment Payment,
	                        'Select' StateChange
                        from claimed c 
                        inner join payment_claim_additional pca on c.id = pca.claimed_id and pca.rowstatus = 1
                        left join vw_total_payment_claim vt on c.id = vt.claimed_id
                        where pca.rowstatus = 1 and pca.payment_in_id = @id;";

            return Entities.ExecuteStoreQuery<PaymentClaim>(sql, new MySqlParameter("id", paymentId)).ToList();
        }

        public List<ClaimReport> GetClaimReport (int claimBranchId, DateTime? dateFrom = null, DateTime? dateTo = null, int? custBranchId = null)
        {
            var sql = @"select
	                        c.date_process ClaimDate,
                            c.letter_no LetterNo,
                            c.description Description,
                            c.customer_name CustomerName,
                            b.code BilledTo,
                            b2.code CustomerBranch,
                            c.total Total,
                            pca.payment Payment,
                            pi.date_process PaymentDate,
                            pi.code PaymentCode
                        from claimed c
                        inner join branch b on c.claimed_branch_id = b.id
                        inner join branch b2 on c.customer_branch_id = b2.id
                        left join payment_claim_additional pca on c.id = pca.claimed_id and pca.rowstatus = 1
                        left join payment_in pi on pca.payment_in_id = pi.id and pi.rowstatus = 1
                        where {0}";

            var param = new List<string>();
            var sqlParam = new List<MySqlParameter>();

            param.Add("c.rowstatus = 1");
            param.Add("c.claimed_branch_id = @claimBranchId");
            sqlParam.Add(new MySqlParameter("claimBranchId", claimBranchId));

            if (custBranchId != null)
            {
                param.Add("c.customer_branch_id = @custBranchId");
                sqlParam.Add(new MySqlParameter("custBranchId", custBranchId));
            }

            if (dateFrom != null)
                param.Add(string.Format("c.date_process >= '{0}'", ((DateTime)dateFrom).ToString("yyyy-MM-dd 00:00:00")));

            if (dateTo != null)
                param.Add(string.Format("c.date_process <= '{0}'", ((DateTime)dateTo).ToString("yyyy-MM-dd 23:59:59")));

            sql = string.Format(sql, string.Join(" AND ", param));

            return Entities.ExecuteStoreQuery<ClaimReport>(sql, sqlParam.ToArray()).ToList();
        }
    }
}