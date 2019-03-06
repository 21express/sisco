using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.CustomerService
{
    public class ClaimedDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public ClaimedDataManager()
        {
            Repository = new ClaimedRepository();
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

        public List<ClaimedSearch> Search (int? branchId = null, string customerName = null, string letterNo = null, DateTime? from = null,
            DateTime? to = null, string shipmentCode = null, int? custBranchId = null)
        {
            return new ClaimedRepository().Search(branchId, customerName, letterNo, from, to, shipmentCode, custBranchId);
        }

        public List<ClaimedPaymentDetail> GetPaymentBalanceClaim(int custBranchId, string customerName = null, string letterNo = null)
        {
            return new ClaimedRepository().GetPaymentBalanceClaim(custBranchId, customerName, letterNo);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((ClaimedRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public PaymentClaim GetClaim (int id)
        {
            return new ClaimedRepository().GetClaim(id);
        }

        public List<PaymentClaim> GetClaims(int paymentId)
        {
            return new ClaimedRepository().GetClaims(paymentId);
        }
    }
}
