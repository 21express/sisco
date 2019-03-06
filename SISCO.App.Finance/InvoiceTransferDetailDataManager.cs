using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class InvoiceTransferDetailDataManager : BaseDataManager
    {
        public InvoiceTransferDetailDataManager()
        {
            Repository = new InvoiceTransferDetailRepository();
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

        public List<InvoiceUnTransferModel> GetUntransfer(int branchId)
        {
            return new InvoiceTransferDetailRepository().GetUntransfer(branchId);
        }

        public List<TransferDetailModel> GetDetails (int transferId)
        {
            return new InvoiceTransferDetailRepository().GetDetails(transferId);
        }

        public bool IsTransfered(string refNumber)
        {
            return new InvoiceTransferDetailRepository().IsTransfered(refNumber);
        }
    }
}