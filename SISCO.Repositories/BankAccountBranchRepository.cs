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
    public class BankAccountBranchRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Bank Account Branch";
        public BankAccountBranchRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public BankAccountBranchRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as BankAccountBranchModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTobank_account_branch(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as BankAccountBranchModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.bank_account_branch where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as BankAccountBranchModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.bank_account_branch select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.bank_account_branch where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.bank_account_branch where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static bank_account_branch PopulateModelToNewEntity(BankAccountBranchModel model)
		{
			return new bank_account_branch
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				bank_account_id = model.BankAccountId,
                branch_id = model.BranchId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(bank_account_branch query, BankAccountBranchModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.bank_account_id = model.BankAccountId;
            query.branch_id = model.BranchId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static BankAccountBranchModel PopulateEntityToNewModel(bank_account_branch item)
		{
            return new BankAccountBranchModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				BankAccountId = item.bank_account_id,
                BranchId = item.branch_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.bank_account_branch select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.bank_account_branch select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.bank_account_branch select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.bank_account_branch select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.bank_account_branch select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.bank_account_branch select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void Reupdate(int bankAccountId)
        {
            var sql = @"UPDATE bank_account_branch SET rowstatus = 0 WHERE bank_account_id = @bankAccountId";
            Entities.ExecuteStoreCommand(sql, new MySqlParameter("bankAccountId", bankAccountId));
            Entities.SaveChanges();
        }

        public void SaveChanges(int bankAccountId, int branchId, string userLogin)
        {
            var sql = string.Format(@"INSERT INTO bank_account_branch (bank_account_id, branch_id, createddate, createdby, rowstatus, rowversion)
                                SELECT {0}, {1}, NOW(), '{2}', 1, NOW() FROM dual
                                WHERE NOT EXISTS(SELECT 1 FROM bank_account_branch WHERE bank_account_id = {0} and branch_id = {1});

                                UPDATE bank_account_branch SET rowstatus = 1 WHERE bank_account_id = {0} and branch_id = {1} AND rowstatus = 0;",
                                bankAccountId, branchId, userLogin);

            Entities.ExecuteStoreCommand(sql);
            Entities.SaveChanges();
        }
    }
}