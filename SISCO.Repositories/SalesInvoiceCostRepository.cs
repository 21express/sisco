using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Transactions;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class SalesInvoiceCostRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "SalesInvoiceCost";
        public SalesInvoiceCostRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public SalesInvoiceCostRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as SalesInvoiceCostModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTosales_invoice_cost(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as SalesInvoiceCostModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.sales_invoice_cost where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as SalesInvoiceCostModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.sales_invoice_cost select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.sales_invoice_cost where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.sales_invoice_cost where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static sales_invoice_cost PopulateModelToNewEntity(SalesInvoiceCostModel model)
		{
			return new sales_invoice_cost
			{
				id = model.Id,

                sales_invoice_id = model.SalesInvoiceId,
                description = model.Description,
                total = model.Total,

				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(sales_invoice_cost query, SalesInvoiceCostModel model)
		{
			query.id = model.Id;

            query.sales_invoice_id = model.SalesInvoiceId;
            query.description = model.Description;
            query.total = model.Total;

			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static SalesInvoiceCostModel PopulateEntityToNewModel(sales_invoice_cost item)
		{
			return new SalesInvoiceCostModel
			{
				Id = item.id,

                SalesInvoiceId = item.sales_invoice_id,
                Description = item.description,
                Total = item.total,

				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_cost select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_cost select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_cost select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.sales_invoice_cost select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<SalesInvoiceCostModel>().ToList();
		}

        public void Save<T>(int p, IList<T> models)
        {
            var shipmentIds = new List<int>(new[] { 0 });

            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM sales_invoice_cost WHERE sales_invoice_id = {0}", p);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as SalesInvoiceCostModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.SalesInvoiceId = p;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddTosales_invoice_cost(entity);

                    shipmentIds.Add(model.SalesInvoiceId);
                }

                Entities.SaveChanges();

                scope.Complete();
            }
        }
    }
}


