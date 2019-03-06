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
    public class OtherInvoiceAcceptanceRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        private const string OBJECT_NAME = "Other Invoice Acceptance";
        public OtherInvoiceAcceptanceRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public OtherInvoiceAcceptanceRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as OtherInvoiceAcceptanceModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToother_invoice_acceptance(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as OtherInvoiceAcceptanceModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.other_invoice_acceptance where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as OtherInvoiceAcceptanceModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.other_invoice_acceptance select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.other_invoice_acceptance where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.other_invoice_acceptance where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static other_invoice_acceptance PopulateModelToNewEntity(OtherInvoiceAcceptanceModel model)
		{
            return new other_invoice_acceptance
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				code = model.Code,
				date_process = model.DateProcess,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(other_invoice_acceptance query, OtherInvoiceAcceptanceModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.code = model.Code;
            query.date_process = model.DateProcess;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static OtherInvoiceAcceptanceModel PopulateEntityToNewModel(other_invoice_acceptance item)
		{
            return new OtherInvoiceAcceptanceModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Code = item.code,
				DateProcess = item.date_process,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_acceptance select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_acceptance select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_acceptance select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.other_invoice_acceptance select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.other_invoice_acceptance select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.other_invoice_acceptance select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<AcceptanceDetailSearch> Search(DateTime? start = null, DateTime? end = null, int? branchId = null, string refNumber = null)
        {
            var sql = @"SELECT
	                        o.date_process DateProcess,
                            o.code Code,
                            i.ref_number RefNumber,
                            b.name BranchName,
                            i.customer_name CustomerName
                        FROM siscodb.other_invoice_acceptance o
                        INNER JOIN other_invoice_acceptance_detail od ON o.id = od.other_invoice_acceptance_id AND od.rowstatus = 1
                        INNER JOIN other_invoice i ON od.other_invoice_id = i.id AND i.rowstatus = 1
                        INNER JOIN branch b ON i.branch_id = b.id AND b.rowstatus = 1
                        WHERE {0}";

            var sqlParam = new List<MySqlParameter>();
            var whereList = new List<string>();

            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (start > dateNull)
            {
                DateTime s = (DateTime)start;
                DateTime date1 = new DateTime(s.Year, s.Month, s.Day, 0, 0, 0);

                sqlParam.Add(new MySqlParameter("start", date1));
                whereList.Add("o.date_process >= @start");
            }

            if (end > dateNull)
            {
                DateTime e = (DateTime)end;
                DateTime date2 = new DateTime(e.Year, e.Month, e.Day, 23, 59, 59);

                sqlParam.Add(new MySqlParameter("end", date2));
                whereList.Add("o.date_process <= @end");
            }

            if (branchId != null)
            {
                sqlParam.Add(new MySqlParameter("branchId", branchId));
                whereList.Add("b.id = @branchId");
            }

            if (!string.IsNullOrEmpty(refNumber))
            {
                sqlParam.Add(new MySqlParameter("refNumber", refNumber));
                whereList.Add("i.ref_number = @refNumber");
            }

            whereList.Add("o.rowstatus = 1");

            sql = string.Format(sql, string.Join(" AND ", whereList));
            return Entities.ExecuteStoreQuery<AcceptanceDetailSearch>(sql, sqlParam.ToArray()).ToList();
        }
    }
}
