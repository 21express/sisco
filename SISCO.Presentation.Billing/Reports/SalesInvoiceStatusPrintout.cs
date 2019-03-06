using System;
using System.Linq;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Billing.Forms;
using SISCO.Presentation.Common.Reports;

namespace SISCO.Presentation.Billing.Reports
{
    public class SalesInvoiceStatusPrintout : DotMatrixRawPrintOut<SalesInvoiceListDataRow>
    {
        public string PageHeaderLayout { get; set; }
        public string PageFooterLayout { get; set; }
        public string DetailLayout { get; set; }
        public string ReportFooterLayout { get; set; }
        public string TaxLayout { get; set; }
        public int RowPerPage { get; set; }

        public SalesInvoiceStatusPrintout()
        {
            RowPerPage = 30;
            PageHeaderLayout = @"








                             KWITANSI PENAGIHAN
                             ------------------
                                  INVOICE

KEPADA: {0,-35}  NO.KWITANSI/RECEIPT NO.: {1,-10}
        {2,-35}  TANGGAL/DATE           : {3,-10}
        {4,-35}  HALAMAN/PAGE           : {5,-10}
        Telp. {6,-29}

 
<condensed>=========================================================================================================================================</condensed>
<condensed>NO.  TANGGAL     NAMA TUJUAN                    KOTA TUJUAN       NO. POD       PCS    BERAT  ISI  TGL.TERIMA  PENERIMA       HARGA KIRIM</condensed>
<condensed>-----------------------------------------------------------------------------------------------------------------------------------------</condensed>
";
            //------------------------------------------------------------------------------------------------------------------------
            DetailLayout = @"<condensed>{0,3}  {1,-10}  {2,-29}  {3,-16}  {4,-12}  {5,3:0}  {6,7:#,0.0}  {7,-3}  {8,-10}  {9,-10}  {10,14:#,0.00}</condensed>
";
            //------------------------------------------------------------------------------------------------------------------------
            PageFooterLayout = @"<condensed>=========================================================================================================================================</condensed>

                        SUB TOTAL :  {0,14:#,0.00}
";
            //------------------------------------------------------------------------------------------------------------------------
            ReportFooterLayout = @"                      Biaya Kirim :  {0,14:#,0.00}
                    Biaya Lainnya :  {1,14:#,0.00}
                   Bea RA+Materai :  {2,14:#,0.00}
                 PACK/Ass/Lainnya :  {3,14:#,0.00}
                Discount ({7,5:#,0.0}%) :  {4,14:#,0.00}{5}
                                   ================
                      GRAND TOTAL :  {6,14:#,0.00}
";
            TaxLayout = @"
                     Tax ({0:P1}) :  {1,14:#,0.00}";

        }

        protected override void ProcessPrint()
        {
            var customerCode = "";
            var customerAddress = "";
            var customerPhone = "";
            var salesInvoice = (SalesInvoiceModel)Parameters["SalesInvoice"].Value;

            var startPage = Convert.ToInt32(Parameters["StartPage"].Value);
            var endPage = Convert.ToInt32(Parameters["EndPage"].Value);

            using (var customerDm = new CustomerDataManager())
            {
                var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(salesInvoice.CompanyId, "id"));

                if (customer != null)
                {
                    customerCode = customer.Code;
                    customerAddress = customer.Address;
                    customerPhone = customer.Phone;
                }
            }

            var customerAddress1 = TruncateString(customerAddress, 35);
            var customerAddress2 = (customerAddress.Length > 35) ? TruncateString(customerAddress.Substring(35), 35) : "";

            int page = 1;
            decimal subTotalTotal = 0;
            decimal totalSales = 0;
            int totalPages = Convert.ToInt32(Math.Ceiling((decimal) DataSource.Count() / RowPerPage));

            for (var i = 0; i < DataSource.Count(); i++)
            {
                var row = DataSource.ElementAt(i);

                if (i % RowPerPage == 0)
                {
                    if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
                    {
                        Write(PageHeaderLayout,
                            TruncateString(string.Format("{0} - {1}", customerCode, salesInvoice.CompanyInvoicedTo), 35),
                            TruncateString(salesInvoice.RefNumber, 10),
                            customerAddress1,
                            salesInvoice.Vdate.ToString("dd-MM-yyyy"),
                            customerAddress2,
                            page,
                            TruncateString(customerPhone, 29));
                    }
                }

                subTotalTotal += row.TariffTotalInBaseCurrency;
                totalSales += row.TariffTotalInBaseCurrency;

                //SetFontStyle(FontStyle.Pica);
                //Write(27, 80); // Select pica width (10 cpi)
                if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
                {
                    Write(DetailLayout,
                        i + 1,
                        row.ShipmentProcessDate.ToString("dd-MM-yyyy"),
                        TruncateString(row.ConsigneeName, 35),
                        TruncateString(row.DestinationCity, 16),
                        TruncateString(row.ShipmentCode, 12),
                        row.TotalPiece,
                        row.TotalChargeableWeight,
                        TruncateString(row.PackageType, 3),
                        row.DeliveredDate != null ? ((DateTime) row.DeliveredDate).ToString("dd-MM-yyyy") : "",
                        TruncateString(row.Recipient, 10),
                        row.TariffTotalInBaseCurrency);
                }

                if (i == DataSource.Count() - 1)
                {
                    var remainder = RowPerPage - ((i + 1) % RowPerPage);
                    for (var j = 0; j < remainder; j++)
                    {
                        if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
                        {
                            Write("\r\n");
                        }
                    }
                }

                if ((i > 0 && (i + 1) % RowPerPage == 0) || (i == DataSource.Count() - 1))
                {
                    if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
                    {
                        Write(PageFooterLayout, subTotalTotal);

                        subTotalTotal = 0;

                        if (page < totalPages)
                        {
                            PageBreak();
                        }
                    }
                }

                if (i > 0 && (i+1)%RowPerPage == 0)
                {
                    page++;
                }
            }

            var tax = "";
            if (Convert.ToDecimal(Parameters["TaxRate"].Value) > 0)
            {
                tax = string.Format(TaxLayout, Convert.ToDecimal(Parameters["TaxRate"].Value), Convert.ToDecimal(Parameters["TaxTotal"].Value));
            }

            if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
            {
                Write(ReportFooterLayout,
                    totalSales,
                    Convert.ToDecimal(Parameters["OtherFee"].Value).ToString("#,0.00"),
                    Convert.ToDecimal(Parameters["RaMateraiFee"].Value).ToString("#,0.00"),
                    salesInvoice.TotalPacking.ToString("#,0.00"),
                    Convert.ToDecimal(Parameters["Discount"].Value).ToString("#,0.00"),
                    tax,
                    Convert.ToDecimal(Parameters["GrandTotal"].Value).ToString("#,0.00"),
                    Convert.ToDecimal(Parameters["DiscountPercent"].Value)
                    );
            }

            PageBreak();
        }

        protected override string GetLayoutFile()
        {
            return "InvoiceStatusPrint.txt";
        }
    }
}