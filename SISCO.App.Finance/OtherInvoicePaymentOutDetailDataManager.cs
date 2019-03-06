using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Finance
{
    public class OtherInvoicePaymentOutDetailDataManager : BaseDataManager
    {
        public OtherInvoicePaymentOutDetailDataManager()
        {
            Repository = new OtherInvoicePaymentOutDetailRepository();
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

        public List<OtherInvoicePaymentOutDetailModel> GetPaymentInvoice(int origBranchid, int origBranchPayment)
        {
            return ((OtherInvoicePaymentOutDetailRepository)Repository).GetPaymentInvoice(origBranchid, origBranchPayment);
        }

        public int GetTotalPayment(int invoiceId)
        {
            return new OtherInvoicePaymentOutDetailRepository().GetTotalPayment(invoiceId);
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<OtherInvoicePaymentOutModel> master,
            params IListParameter[] parameter)
        {
            return new OtherInvoicePaymentOutDetailRepository().FilterPayment(master, parameter);
        }
    }
}