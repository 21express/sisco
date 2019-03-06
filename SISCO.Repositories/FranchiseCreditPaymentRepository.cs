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

namespace SISCO.Repositories
{
    public class FranchiseCreditPaymentRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Franchise Credit Payment";
        public FranchiseCreditPaymentRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseCreditPaymentRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchiseCreditPaymentModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_credit_payment(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchiseCreditPaymentModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_credit_payment where d.id == model.Id select d).FirstOrDefault();

			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseCreditPaymentModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_credit_payment select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_credit_payment where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.franchise_credit_payment where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_credit_payment PopulateModelToNewEntity(FranchiseCreditPaymentModel model)
		{
            return new franchise_credit_payment
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                date_process = model.DateProcess,
				code = model.Code,
                branch_id = model.BranchId,
                payment_type_id = model.PaymentTypeId,
                description = model.Description,
                franchise_id = model.FranchiseId,
                franchise_name = model.FranchiseName,
                total_invoice = model.TotalInvoice,
                adjustment = model.Adjustment,
                total = model.Total,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(franchise_credit_payment query, FranchiseCreditPaymentModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
			query.code = model.Code;
            query.branch_id = model.BranchId;
            query.payment_type_id = model.PaymentTypeId;
            query.description = model.Description;
            query.franchise_id = model.FranchiseId;
            query.franchise_name = model.FranchiseName;
            query.total_invoice = model.TotalInvoice;
            query.adjustment = model.Adjustment;
            query.total = model.Total;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static FranchiseCreditPaymentModel PopulateEntityToNewModel(franchise_credit_payment item)
		{
            return new FranchiseCreditPaymentModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
				Code = item.code,
                BranchId = item.branch_id,
                PaymentTypeId = item.payment_type_id,
                Description = item.description,
                FranchiseId = item.franchise_id,
                FranchiseName = item.franchise_name,
                TotalInvoice = item.total_invoice,
                Adjustment = item.adjustment,
                Total = item.total,
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
			var query = (from a in Entities.franchise_credit_payment select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_credit_payment select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_credit_payment select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_credit_payment select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_credit_payment select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_credit_payment select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public string GenerateCode(int branchId)
        {
            var branchcode = (from b in Entities.branches where b.id == branchId select b).FirstOrDefault().code;
            var pattern = string.Format("FCR-{0}-{1}-{2}-#####", branchcode, DateTime.Now.Year, DateTime.Now.Month);

            return GenerateCode("franchise-credit", pattern);
        }
    }
}