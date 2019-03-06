using SISCO.Models;
using System.Collections.Generic;

namespace SISCO.Presentation.Billing
{
    public class SalesInvoiceRevised
    {
        public SalesInvoiceModel SalesInvoice { get; set; }
        public List<SalesInvoiceListModel> SalesInvoiceList { get; set; }
        public List<SalesInvoiceCostModel> SalesCosts { get; set; }
    }
}