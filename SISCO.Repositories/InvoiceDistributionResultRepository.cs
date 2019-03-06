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
    public class InvoiceDistributionResultRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "InvoiceDistributionResult";
        public InvoiceDistributionResultRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public InvoiceDistributionResultRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as InvoiceDistributionResultModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToinvoice_distribution_result(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as InvoiceDistributionResultModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.invoice_distribution_result where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as InvoiceDistributionResultModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.invoice_distribution_result select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.invoice_distribution_result where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.invoice_distribution_result where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static invoice_distribution_result PopulateModelToNewEntity(InvoiceDistributionResultModel model)
		{
			return new invoice_distribution_result
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
                branch_id = model.BranchId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(invoice_distribution_result query, InvoiceDistributionResultModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.branch_id = model.BranchId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static InvoiceDistributionResultModel PopulateEntityToNewModel(invoice_distribution_result item)
		{
            return new InvoiceDistributionResultModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
                BranchId = item.branch_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby  
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.invoice_distribution_result select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.invoice_distribution_result select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.invoice_distribution_result select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_distribution_result select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.invoice_distribution_result select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.invoice_distribution_result select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<InvoiceFinanceSearchModel> Search(int branchId, string refNumber = null, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var sql = @"SELECT
	                        idr.id Id,
                            idr.date_process DateProcess,
                            si.ref_number RefNumber
                        FROM invoice_distribution_result idr
                        INNER JOIN invoice_distribution_result_detail idrd ON idrd.invoice_distribution_result_id = idr.id AND idrd.rowstatus = 1
                        INNER JOIN sales_invoice si ON idrd.sales_invoice_id = si.id
                        WHERE {0}";

            var param = new List<string>();
            var sqlparam = new List<MySqlParameter>();

            param.Add("idr.rowstatus = 1");
            param.Add("idr.branch_id = @branchId");
            sqlparam.Add(new MySqlParameter("branchId", branchId));

            if (!string.IsNullOrEmpty(refNumber))
            {
                param.Add("si.ref_number = @refNumber");
                sqlparam.Add(new MySqlParameter("refNumber", refNumber));
            }

            if (dateFrom != DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("idr.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo != DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("idr.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            sql = string.Format(sql, string.Join(" AND ", param.ToArray()));
            return Entities.ExecuteStoreQuery<InvoiceFinanceSearchModel>(sql, sqlparam.ToArray()).ToList();
        }
    }
}


