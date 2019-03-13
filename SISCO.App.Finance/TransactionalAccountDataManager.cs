using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;
using System;

namespace SISCO.App.Finance
{
    public class TransactionalAccountDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public TransactionalAccountDataManager()
        {
            Repository = new TransactionalAccountRepository();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            return Repository.Get<T>(listParameter);
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            return Repository.GetSingle<T>(listParameter);
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            return Repository.Get<T>(paging, out count, listParameter);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((TransactionalAccountRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public void AddTransaction(TransactionalAccountModel transaction, string user)
        {
            new TransactionalAccountRepository().AddTransaction(transaction, user);
        }

        public List<BankTransactionModel> GetDetails(int bankId, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            return new TransactionalAccountRepository().GetDetails(bankId, dateFrom, dateTo);
        }

        public List<BankTransactionModel> GetTransactionRevisionList(TransactionalAccountModel transaction)
        {
            return new TransactionalAccountRepository().GetTransactionRevisionList(transaction);
        }

        public decimal GetBankBalance(int bankId, DateTime transactionDate)
        {
            return new TransactionalAccountRepository().GetBankBalance(bankId, transactionDate);
        }

        public void TransactionalRevision(int pid, string description, DateTime transactionDate, decimal debit, decimal credit, DateTime startDate, string actor)
        {
            new TransactionalAccountRepository().TransactionalRevision(pid, description, transactionDate, debit, credit, startDate, actor);
        }

        public List<TransactionLookup> SearchPopup (bool isCredit, int bankId, DateTime? dateFrom = null, DateTime? dateTo = null,
            string description = null, decimal? total = 0)
        {
            if (isCredit) return new TransactionalAccountRepository().SearchTransactionCredit(bankId, dateFrom, dateTo, description, total);
            else return new TransactionalAccountRepository().SearchTransactionDebit(bankId, dateFrom, dateTo, description, total);
        }

        public decimal GetTransactionBalanceAgaintsPayment(int pid, int? paymentId = null, int? paymentCounterId = null,
             int? paymentOtherInId = null, int? paymentCollectOutId = null)
        {
            return new TransactionalAccountRepository().GetTransactionBalanceAgaintsPayment(pid, paymentId, paymentCounterId,
                paymentOtherInId, paymentCollectOutId);
        }

        public decimal GetWithdrawAgaintsCost(int branchId, DateTime beforeDate, int? costId = null)
        {
            return new TransactionalAccountRepository().GetWithdrawAgaintsCost(branchId, beforeDate, costId);
        }

        public List<TransactionJournal> GetTransactionJournal(int bankId, DateTime? dateFrom = null, DateTime? dateTo = null,
            bool closed = false)
        {
            return new TransactionalAccountRepository().GetTransactionJournal(bankId, dateFrom, dateTo, closed);
        }

        public List<TransactionJournal> GetTransactionJournalVerified(int bankId, DateTime? dateFrom = null, 
            DateTime? dateTo = null)
        {
            return new TransactionalAccountRepository().GetTransactionJournalVerified(bankId, dateFrom, dateTo);
        }

        public void Closing(int id, string actor)
        {
            new TransactionalAccountRepository().Closing(id, actor);
        }

        public void Cancellation(int id, string actor)
        {
            new TransactionalAccountRepository().Cancellation(id, actor);
        }

        public TransactionalAccountModel GetTransactionAccountAgaintsCostTransaction(int id)
        {
            return new TransactionalAccountRepository().GetTransactionAccountAgaintsCostTransaction(id);
        }
    }
}