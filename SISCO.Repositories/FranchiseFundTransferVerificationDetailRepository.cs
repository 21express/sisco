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
    public class FranchiseFundTransferVerificationDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Fund Transfer Verification Detail";
        public FranchiseFundTransferVerificationDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseFundTransferVerificationDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchiseFundTransferVerificationDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_fund_transfer_verification_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchiseFundTransferVerificationDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_fund_transfer_verification_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseFundTransferVerificationDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_fund_transfer_verification_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_fund_transfer_verification_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.franchise_fund_transfer_verification_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_fund_transfer_verification_detail PopulateModelToNewEntity(FranchiseFundTransferVerificationDetailModel model)
		{
			return new franchise_fund_transfer_verification_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                date_process = model.DateProcess,
                franchise_fund_transfer_verification_id = model.FranchiseFundTransferVerificationId,
                invoice_id = model.InvoiceId,
                invoice_code = model.InvoiceCode,
                invoice_date = model.InvoiceDate,
                invoice_total = model.InvoiceTotal,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby
			};
		}

        private static void PopulateModelToNewEntity(franchise_fund_transfer_verification_detail query, FranchiseFundTransferVerificationDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.franchise_fund_transfer_verification_id = model.FranchiseFundTransferVerificationId;
            query.invoice_id = model.InvoiceId;
            query.invoice_code = model.InvoiceCode;
            query.invoice_date = model.InvoiceDate;
            query.invoice_total = model.InvoiceTotal;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static FranchiseFundTransferVerificationDetailModel PopulateEntityToNewModel(franchise_fund_transfer_verification_detail item)
		{
            return new FranchiseFundTransferVerificationDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
                FranchiseFundTransferVerificationId = item.franchise_fund_transfer_verification_id,
                InvoiceId = item.invoice_id,
                InvoiceCode = item.invoice_code,
                InvoiceDate = item.invoice_date,
                InvoiceTotal = item.invoice_total,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.franchise_fund_transfer_verification_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var result = (from item in query
                          join f2 in Entities.franchise_fund_transfer on item.invoice_id equals f2.id
                          join b in Entities.branches on f2.branch_id equals b.id
                          select new FranchiseFundTransferVerificationDetailModel
                            {
                                Id = item.id,
                                Rowstatus = item.rowstatus,
                                Rowversion = item.rowversion,
                                DateProcess = item.date_process,
                                DestBranchId = b.id,
                                DestBranch = b.name,
                                FranchiseFundTransferVerificationId = item.franchise_fund_transfer_verification_id,
                                InvoiceId = item.invoice_id,
                                InvoiceCode = item.invoice_code,
                                InvoiceDate = item.invoice_date,
                                InvoiceTotal = item.invoice_total,
                                Createddate = item.createddate,
                                Createdby = item.createdby,
                                Modifieddate = item.modifieddate,
                                Modifiedby = item.modifiedby,
                                Verified = true,
                                StateChange = EnumStateChange.Update
                            }).ToList();

			return (IEnumerable<T>)result;
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_fund_transfer_verification_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_fund_transfer_verification_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_fund_transfer_verification_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_fund_transfer_verification_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_fund_transfer_verification_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<FranchiseFundTransferVerificationModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.franchise_fund_transfer_verification_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.franchise_fund_transfer_verification_id equals m.Id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 CustomerName = string.Empty,
                                                                 PaymentType = string.Empty,
                                                                 Kwitansi = a.invoice_code
                                                             }).ToList();

            return obj;
        }
    }
}


