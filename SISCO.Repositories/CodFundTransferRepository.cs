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
    public class CodFundTransferRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Fund Transfer";
        public CodFundTransferRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CodFundTransferRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CodFundTransferModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocod_fund_transfer(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as CodFundTransferModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.cod_fund_transfer where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CodFundTransferModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.cod_fund_transfer select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.cod_fund_transfer where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.cod_fund_transfer where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static cod_fund_transfer PopulateModelToNewEntity(CodFundTransferModel model)
		{
			return new cod_fund_transfer
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                date_process = model.DateProcess,
				code = model.Code,
                branch_id = model.BranchId,
                dest_branch_id = model.DestBranchId,
                amount = model.Amount,
                description = model.Description,
                total_payment = model.TotalPayment,
                adjustment = model.Adjustment,
                total = model.Total,
                confirm_admin = model.ConfirmAdmin,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}

        private static void PopulateModelToNewEntity(cod_fund_transfer query, CodFundTransferModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
			query.code = model.Code;
            query.branch_id = model.BranchId;
            query.dest_branch_id = model.DestBranchId;
            query.amount = model.Amount;
            query.description = model.Description;
            query.total_payment = model.TotalPayment;
            query.adjustment = model.Adjustment;
            query.total = model.Total;
            query.confirm_admin = model.ConfirmAdmin;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}

        private static CodFundTransferModel PopulateEntityToNewModel(cod_fund_transfer item)
		{
            return new CodFundTransferModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
				Code = item.code,
                BranchId = item.branch_id,
                DestBranchId = item.dest_branch_id,
                Amount = item.amount,
                Description = item.description,
                TotalPayment = item.total_payment,
                Adjustment = item.adjustment,
                Total = item.total,
                ConfirmAdmin = item.confirm_admin,
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
			var query = (from a in Entities.cod_fund_transfer select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_fund_transfer select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_fund_transfer select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_fund_transfer select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.cod_fund_transfer select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_fund_transfer select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<FranchiseFundTransferVerificationDetailModel> GetUnverified(int branchId)
        {
            if (branchId == 24)
            {
                var p = new List<WhereTerm>();
                p.Add(WhereTerm.Default(false, "confirm_admin"));

                var whereterm = GetQueryParameterLinq(p.ToArray());

                var state = EnumStateChange.Insert.ToString();
                var query = (from f in Entities.cod_fund_transfer select f).Where(whereterm, ListValue.ToArray()).ToList();
                var result = (from f in query
                              join b in Entities.branches on f.branch_id equals b.id
                              select new FranchiseFundTransferVerificationDetailModel
                              {
                                  DestBranchId = b.id,
                                  DestBranch = b.name,
                                  InvoiceId = f.id,
                                  InvoiceCode = f.code,
                                  InvoiceDate = f.date_process,
                                  InvoiceTotal = f.total,
                                  Verified = false,
                                  StateChange2 = state
                              }).ToList();

                return result;
            }
            else return new List<FranchiseFundTransferVerificationDetailModel>();
        }
    }
}


