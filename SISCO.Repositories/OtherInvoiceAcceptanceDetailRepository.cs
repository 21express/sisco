using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace SISCO.Repositories
{
    public class OtherInvoiceAcceptanceDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        private const string OBJECT_NAME = "Other Invoice Acceptance Detail";
        public OtherInvoiceAcceptanceDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public OtherInvoiceAcceptanceDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as OtherInvoiceAcceptanceDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToother_invoice_acceptance_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as OtherInvoiceAcceptanceDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.other_invoice_acceptance_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as OtherInvoiceAcceptanceDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.other_invoice_acceptance_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.other_invoice_acceptance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.other_invoice_acceptance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static other_invoice_acceptance_detail PopulateModelToNewEntity(OtherInvoiceAcceptanceDetailModel model)
		{
            return new other_invoice_acceptance_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				other_invoice_acceptance_id = model.OtherInvoiceAcceptanceId,
                other_invoice_id = model.OtherInvoiceId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(other_invoice_acceptance_detail query, OtherInvoiceAcceptanceDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.other_invoice_acceptance_id = model.OtherInvoiceAcceptanceId;
            query.other_invoice_id = model.OtherInvoiceId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static OtherInvoiceAcceptanceDetailModel PopulateEntityToNewModel(other_invoice_acceptance_detail item)
		{
            return new OtherInvoiceAcceptanceDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				OtherInvoiceAcceptanceId = item.other_invoice_acceptance_id,
                OtherInvoiceId = item.other_invoice_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.other_invoice_acceptance_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.other_invoice_acceptance_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.other_invoice_acceptance_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public OtherInvoiceAcceptanceDetail GetInvoice(string refNumber)
        {
            var sql = @"SELECT
	                        b.name OriginBranch,
                            b1.id DestBranchId,
	                        IF(oa.id IS NULL, 0, oa.id) OtherInvoiceAcceptanceId,
	                        o.ref_number RefNumber,
	                        o.id OtherInvoiceId,
                            o.accept Accepted,
                            o.total Total
                        FROM other_invoice o
                        INNER JOIN branch b ON o.owner_branch_id = b.id
                        INNER JOIN branch b1 ON o.branch_id = b1.id
                        LEFT JOIN other_invoice_acceptance_detail ad ON o.id = ad.other_invoice_id AND ad.rowstatus = 1
                        LEFT JOIN other_invoice_acceptance oa ON ad.other_invoice_acceptance_id = oa.id AND oa.rowstatus = 1
                        WHERE o.rowstatus = 1 AND o.ref_number = @refNumber;";

            return Entities.ExecuteStoreQuery<OtherInvoiceAcceptanceDetail>(sql, new MySqlParameter("refNumber", refNumber)).FirstOrDefault();
        }

        public List<OtherInvoiceAcceptanceDetail> GetInvoices(int otherInvoiceAcceptanceId)
        {
            var sql = @"SELECT
	                        b.name OriginBranch,
	                        IF(oa.id IS NULL, 0, oa.id) OtherInvoiceAcceptanceId,
	                        o.ref_number RefNumber,
	                        o.id OtherInvoiceId,
                            o.total Total,
                            'Select' StateChange2
                        FROM other_invoice_acceptance_detail od
                        INNER JOIN other_invoice_acceptance oa ON od.other_invoice_acceptance_id = oa.id AND oa.rowstatus = 1
                        INNER JOIN other_invoice o ON od.other_invoice_id = o.id AND o.rowstatus = 1
                        INNER JOIN branch b ON o.owner_branch_id = b.id
                        WHERE od.rowstatus = 1 AND oa.id = @id;";

            return Entities.ExecuteStoreQuery <OtherInvoiceAcceptanceDetail>(sql, new MySqlParameter("id", otherInvoiceAcceptanceId)).ToList();
        }
    }
}