using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;

namespace SISCO.App.Billing
{
    public class SalesInvoiceDataManager : BaseDataManager
    {
        public SalesInvoiceDataManager()
        {
            Repository = new SalesInvoiceRepository();
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

        public override void Save<T>(IBaseModel businessModel)
        {
            if (string.IsNullOrEmpty(((SalesInvoiceModel)businessModel).Code))
            {
                ((SalesInvoiceModel)businessModel).Code = GenerateCode(businessModel as SalesInvoiceModel);
            }

            Repository.Save(businessModel);
        }

        private string GenerateCode(SalesInvoiceModel model)
        {
            return ((SalesInvoiceRepository)Repository).GenerateCode(model);
        }

        public List<InvoiceTax> GetTaxInvoice(string year, string month = null, int? branchId = null, bool? isprinted = null, int? taxInvoiceId = null)
        {
            return new SalesInvoiceRepository().GetTaxInvoice(year, month, branchId, isprinted, taxInvoiceId);
        }

        public List<InvoiceDistributionInternalModel> GetInvoiceDistribution(int branchId, DateTime? invoiceFrom = null, DateTime? invoiceTo = null,
            DateTime? sendFrom = null, DateTime? sendTo = null)
        {
            return new SalesInvoiceRepository().GetInvoiceDistribution(branchId, invoiceFrom, invoiceTo, sendFrom, sendTo);
        }

        public List<PrintInvoiceModel> GetInvoiceToPrint(int branchId, string year, string month, int taxInvoiceId)
        {
            return new SalesInvoiceRepository().GetInvoiceToPrint(branchId, year, month, taxInvoiceId);
        }
    }
}
