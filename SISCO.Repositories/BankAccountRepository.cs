using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class BankAccountRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Bank Account";
        public BankAccountRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public BankAccountRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as BankAccountModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTobank_account(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as BankAccountModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.bank_account where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as BankAccountModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.bank_account select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.bank_account where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.bank_account where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static bank_account PopulateModelToNewEntity(BankAccountModel model)
        {
            return new bank_account
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                branch_id = model.BranchId,
                account_no = model.AccountNo,
                bank_name = model.BankName,
                branch_name = model.BranchName,
                account_name = model.AccountName,
                account_address = model.AccountAddress,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(bank_account query, BankAccountModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.branch_id = model.BranchId;
            query.account_no = model.AccountNo;
            query.bank_name = model.BankName;
            query.branch_name = model.BranchName;
            query.account_name = model.AccountName;
            query.account_address = model.AccountAddress;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static BankAccountModel PopulateEntityToNewModel(bank_account item)
        {
            return new BankAccountModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                BranchId = item.branch_id,
                AccountNo = item.account_no,
                BankName = item.bank_name,
                BranchName = item.branch_name,
                AccountName = item.account_name,
                AccountAddress = item.account_address,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.bank_account select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.bank_account select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.bank_account select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.bank_account select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.bank_account select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.bank_account select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<BankAccountModel> GetBankShared(int branchId)
        {
            var sql = @"select
	                        ba.id Id, 
                            ba.rowstatus Rowstatus,
                            ba.rowversion Rowversion,
                            ba.account_no AccountNo,
                            ba.branch_id BranchId,
                            ba.bank_name BankName,
                            ba.branch_name BranchName,
                            ba.account_name AccountName,
                            ba.account_address AccountAddress, 
                            ba.createddate Createddate,
                            ba.createdby Createdby,
                            ba.modifieddate Modifieddate,
                            ba.modifiedby Modifiedby
                        from bank_account ba 
                        where ba.rowstatus = 1 and ba.branch_id = @branchId

                        union

                        select
	                        ba.id Id, 
                            ba.rowstatus Rowstatus,
                            ba.rowversion Rowversion,
                            ba.account_no AccountNo,
                            ba.branch_id BranchId,
                            ba.bank_name BankName,
                            ba.branch_name BranchName,
                            ba.account_name AccountName,
                            ba.account_address AccountAddress, 
                            ba.createddate Createddate,
                            ba.createdby Createdby,
                            ba.modifieddate Modifieddate,
                            ba.modifiedby Modifiedby
                        from bank_account ba
                        inner join bank_account_branch bab on ba.id = bab.bank_account_id and bab.rowstatus = 1
                        where ba.rowstatus = 1 and bab.branch_id = @branchId;";

            return Entities.ExecuteStoreQuery<BankAccountModel>(sql, new MySqlParameter("branchId", branchId)).ToList();
        }
    }
}