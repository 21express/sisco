using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class SalesInvoiceAcceptanceRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "SalesInvoiceAcceptance";
        public SalesInvoiceAcceptanceRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public SalesInvoiceAcceptanceRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as SalesInvoiceAcceptanceModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTosales_invoice_acceptance(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as SalesInvoiceAcceptanceModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.sales_invoice_acceptance where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as SalesInvoiceAcceptanceModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.sales_invoice_acceptance select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.sales_invoice_acceptance where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.sales_invoice_acceptance where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static sales_invoice_acceptance PopulateModelToNewEntity(SalesInvoiceAcceptanceModel model)
		{
			return new sales_invoice_acceptance
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                code = model.Code,
                date_process = model.DateProcess,
                branch_id = model.BranchId,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(sales_invoice_acceptance query, SalesInvoiceAcceptanceModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.code = model.Code;
            query.date_process = model.DateProcess;
            query.branch_id = model.BranchId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static SalesInvoiceAcceptanceModel PopulateEntityToNewModel(sales_invoice_acceptance item)
		{
			return new SalesInvoiceAcceptanceModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                Code = item.code,
                DateProcess = item.date_process,
                BranchId = item.branch_id,
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
			var query = (from a in Entities.sales_invoice_acceptance select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_acceptance select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.sales_invoice_acceptance select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.sales_invoice_acceptance select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<SalesInvoiceAcceptanceModel>().ToList();
		}

        public List<InvoiceAcceptanceFinanceSearchModel> Search(int branchId, string refNumber = null, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var sql = @"SELECT
	                        sia.id Id,
                            sia.date_process DateProcess,
                            sia.code Code,
                            si.ref_number RefNumber
                        FROM sales_invoice_acceptance sia
                        INNER JOIN sales_invoice_acceptance_detail siad ON siad.sales_invoice_acceptance_id = sia.id AND siad.rowstatus = 1
                        INNER JOIN sales_invoice si ON siad.sales_invoice_id = si.id
                        WHERE {0}";

            var param = new List<string>();
            var sqlparam = new List<MySqlParameter>();

            param.Add("sia.rowstatus = 1");
            param.Add("sia.branch_id = @branchId");
            sqlparam.Add(new MySqlParameter("branchId", branchId));

            if (!string.IsNullOrEmpty(refNumber))
            {
                param.Add("si.ref_number = @refNumber");
                sqlparam.Add(new MySqlParameter("refNumber", refNumber));
            }

            if (dateFrom != DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("sia.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo != DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("sia.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            sql = string.Format(sql, string.Join(" AND ", param.ToArray()));
            return Entities.ExecuteStoreQuery<InvoiceAcceptanceFinanceSearchModel>(sql, sqlparam.ToArray()).ToList();
        }
    }
}