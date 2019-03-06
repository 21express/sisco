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
    public class OtherInvoicePaymentOutRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "OtherInvoicePaymentOut";
        public OtherInvoicePaymentOutRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public OtherInvoicePaymentOutRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as OtherInvoicePaymentOutModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToother_invoice_payment_out(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as OtherInvoicePaymentOutModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.other_invoice_payment_out where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as OtherInvoicePaymentOutModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.other_invoice_payment_out select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.other_invoice_payment_out where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.other_invoice_payment_out where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static other_invoice_payment_out PopulateModelToNewEntity(OtherInvoicePaymentOutModel model)
		{
			return new other_invoice_payment_out
			{
				id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
                owner_branch_id = model.OwnerBranchId,
				payment_type_id = model.PaymentTypeId,
				description = model.Description,
				account_id = model.AccountId,
				amount = model.Amount,
				total_invoice = model.TotalInvoice,
				total = model.Total,
                total_pph = model.TotalPph,
				adjustment = model.Adjustment,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(other_invoice_payment_out query, OtherInvoicePaymentOutModel model)
		{
			query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
            query.owner_branch_id = model.OwnerBranchId;
			query.payment_type_id = model.PaymentTypeId;
			query.description = model.Description;
			query.account_id = model.AccountId;
			query.amount = model.Amount;
			query.total_invoice = model.TotalInvoice;
			query.total = model.Total;
            query.total_pph = model.TotalPph;
			query.adjustment = model.Adjustment;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static OtherInvoicePaymentOutModel PopulateEntityToNewModel(other_invoice_payment_out item)
		{
			return new OtherInvoicePaymentOutModel
			{
				Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
                OwnerBranchId = item.owner_branch_id,
				PaymentTypeId = item.payment_type_id,
				Description = item.description,
				AccountId = item.account_id,
				Amount = item.amount,
				TotalInvoice = item.total_invoice,
				Total = item.total,
                TotalPph = item.total_pph,
				Adjustment = item.adjustment,
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
			var query = (from a in Entities.other_invoice_payment_out select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join b in Entities.branches on item.branch_id equals b.id
                select new OtherInvoicePaymentOutModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    BranchName = b.name,
                    OwnerBranchId = item.owner_branch_id,
                    PaymentTypeId = item.payment_type_id,
                    Description = item.description,
                    AccountId = item.account_id,
                    TotalPph = item.total_pph,
                    Amount = item.amount,
                    TotalInvoice = item.total_invoice,
                    Total = item.total,
                    Adjustment = item.adjustment,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    CreatedPc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    ModifiedPc = item.modifiedpc
                });

			return (IEnumerable<T>) obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_out select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.other_invoice_payment_out select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.other_invoice_payment_out select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}
    }
}