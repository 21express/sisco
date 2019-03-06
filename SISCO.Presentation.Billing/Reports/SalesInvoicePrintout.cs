using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devenlab.Common;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSplashScreen;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Billing.Forms;
using SISCO.Presentation.Common.Reports;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Billing.Reports
{
    public class SalesInvoicePrintout : DotMatrixRawPrintOut<SalesInvoiceListDataRow>
    {
        public string PageHeaderLayout { get; set; }
        public string PageFooterLayout { get; set; }
        public string DetailLayout { get; set; }
        public string ReportFooterLayout { get; set; }
        public int RowPerPage { get; set; }
        public bool Continuous { get; set; }

        public SalesInvoicePrintout(bool continuous, bool printTax)
        {
            Continuous = continuous;

            RowPerPage = 30;
            PageHeaderLayout = @"





KEPADA  : {0,-36}                   {1,-10}
          {2,-36}                   {3,-10}
          {4,-36}                   {5,-10}
          Telp. {6,-30}





";
            if (!continuous)
            {
                PageHeaderLayout = "\n\n\n\n\n\n\n\n\n\n\n" + PageHeaderLayout;
            }
            
            //---------------------------------------------------------------------------------------------------------------
            DetailLayout = @"{0,5} {1,8} {2,-11} {3,-12} {4,3} {5,6:0.0}    {6,7}    {7,14:#,0.00}
";
            //---------------------------------------------------------------------------------------------------------------

            if (Continuous)
            {
                ReportFooterLayout = @"                                             Domestik :          {0,14}
{1,-42}   City Courier :      {2,14}
{3,-42}   International :     {4,14}
{5,-42}   Biaya Lainnya :     {6,14}
{7,-42}   Bea RA+Materai :    {8,14}
{9,-42}   Packing/Asuransi :  {10,14}
                                             Discount ({15,5:#,0.0}%) : {11,14}" + (printTax ? @"
                                             Tax ({12,6:P1}) :      {13,14:#,0.00}" : "") + @"
                                                               ----------------
                                             GRAND TOTAL :       {14,14}
";
            }
            else
            {
                if (printTax)
                {
                    ReportFooterLayout = @"                                             Domestik :          {0,14}
                                             City Courier :      {2,14}
                                             International :     {4,14}
                                             Biaya Lainnya :     {6,14}
                                             Bea RA+Materai :    {8,14}
                                             Packing/Asuransi :  {10,14}
{1,-42}   Discount ({15,5:#,0.0}%) : {11,14}
{3,-42}   Tax ({12,6:P1}) :      {13,14:#,0.00}
{5,-42}                     ----------------
{7,-42}   GRAND TOTAL :       {14,14}
{9,-42}
";
                }
                else
                {
                    ReportFooterLayout = @"                                             Domestik :          {0,14}
                                             City Courier :      {2,14}
                                             International :     {4,14}
                                             Biaya Lainnya :     {6,14}
                                             Bea RA+Materai :    {8,14}
                                             Packing/Asuransi :  {10,14}
{1,-42}   Discount ({15,5:#,0.0}%) : {11,14}
{3,-42}                     ----------------
{5,-42}   GRAND TOTAL :       {14,14}
{7,-42}
{9,-42}
";
                }
            }
        }

        protected override string GetLayoutFile()
        {
            return "SalesInvoicePrintout.txt";
        }

        protected override void ProcessPrint()
        {
            var customerCode = "";
            var customerAddress = "";
            var customerPhone = "";
            CustomerModel customer = new CustomerModel();
            var salesInvoice = (SalesInvoiceModel) Parameters["SalesInvoice"].Value;

            using (var customerDm = new CustomerDataManager())
            {
                customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(salesInvoice.CompanyId, "id"));

                if (customer != null)
                {
                    customerCode = customer.Code;
                    customerAddress = customer.Address;
                    customerPhone = customer.Phone;
                }
            }

            var customerAddress1 = TruncateString(customerAddress, 36);
            var customerAddress2 = (customerAddress.Length > 36) ? TruncateString(customerAddress.Substring(36), 36) : "";

            var output = new StringBuilder();
            var sb = new StringBuilder();

            //output.AppendFormat("{0}{1}{2}", (char) 27, (char) 67, (char) 62);

            int page = 0;
            int index = 0;
            int row = 0;

            bool forcedNextPage = false;
            bool isEnd = false;

            int subTotalPieces = 0;
            decimal subTotalCw = 0;
            decimal subTotalTotal = 0;
            decimal subTotalPacking = 0;
            decimal totalDocument = 0;
            decimal totalParcel = 0;

            var startPage = Convert.ToInt32(Parameters["StartPage"].Value);
            var endPage = Convert.ToInt32(Parameters["EndPage"].Value);

            while (index <= DataSource.Count() || forcedNextPage || isEnd)
            {
                if (row == 0 || row + 1 > RowPerPage || forcedNextPage || isEnd)
                {
                    //forcedNextPage = false;

                    if (page > 0 || isEnd)
                    {
                        if (!forcedNextPage)
                        {
                            sb.AppendFormat(@"                                     ------ ------             ----------------
                   SUB TOTAL :       {0,6:0} {1,6:0.0}               {2,14}
",
                                subTotalPieces,
                                subTotalCw,
                                subTotalTotal.ToString("#,0.00"));
                            if (subTotalPacking > 0)
                            {
                                sb.AppendFormat(
                                    @"                                                  Packing        {0,14:#,0.00}
",
                                    subTotalPacking);
                            }
                            sb.AppendFormat(@"                                                               ================
                                                                 {0,14}
", (subTotalTotal + subTotalPacking).ToString("#,0.00"));
                        }

                        if (isEnd)
                        {
                            if (row > RowPerPage - 3)
                            {
                                forcedNextPage = true;
                            }
                            else
                            {
                                row += 3;

                                var otherFee = new SalesInvoiceCostDataManager().
                                    Get<SalesInvoiceCostModel>(WhereTerm.Default(salesInvoice.Id, "sales_invoice_id"));

                                var salesInvoiceCostModels = otherFee as SalesInvoiceCostModel[] ?? otherFee.ToArray();
                                row += salesInvoiceCostModels.Count();

                                if (forcedNextPage)
                                {
                                    row -= 3;
                                    row -= salesInvoiceCostModels.Count();
                                }

                                sb.AppendLine();
                                sb.AppendFormat("  Total Document :    {0,14}\r\n", totalDocument.ToString("#,0.00"));
                                sb.AppendFormat("  Total Paket :      {0,14}\r\n", totalParcel.ToString("#,0.00"));

                                foreach (SalesInvoiceCostModel oFee in salesInvoiceCostModels)
                                    sb.AppendFormat("  {0, -14} :    {1,14}\r\n", oFee.Description, oFee.Total.ToString("#,0.00"));

                                forcedNextPage = false;
                            }
                        }


                        if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
                        {
                            output.Append(sb);
                        }

                        if (!forcedNextPage && isEnd)
                        {
                            break;
                        }

                        if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
                        {
                            if (Continuous)
                            {
                                //output.Append("\n\n\n\n\n\n\n");
                            }

                            output.AppendFormat("{0}",(char) 12);
                        }
                    }

                    row = 0;

                    page++;

                    sb.Clear();
                    subTotalPieces = 0;
                    subTotalCw = 0;
                    subTotalTotal = 0;
                    subTotalPacking = 0;

                    if (forcedNextPage || row < DataSource.Count())
                    {
                        sb.AppendFormat(PageHeaderLayout,
                            TruncateString(string.Format("{0} - {1}", customerCode, salesInvoice.CompanyInvoicedTo), 36),
                            TruncateString(salesInvoice .RefNumber, 10),
                            customerAddress1,
                            salesInvoice.Vdate.ToString("dd-MM-yyyy"),
                            customerAddress2,
                            page,
                            TruncateString(customerPhone, 30));
                    }
                }

                row++;
                index++;

                if (index - 1 < DataSource.Count())
                {
                    var model = DataSource.ElementAt(index - 1);

                    if (string.IsNullOrEmpty(model.PackageType))
                    {
                        model.PackageType = model.PackageTypeId == 1 ? "DOCUMENT" : (model.PackageTypeId == 2 ? "PKT" : "");
                    }
                    else
                        model.PackageType = model.PackageTypeId == 1 ? "DOCUMENT" : (model.PackageTypeId == 2 ? "PKT" : "");

                    sb.AppendFormat(DetailLayout,
                        index,
                        model.ShipmentProcessDate.ToString("dd-MM-yy"),
                        TruncateString(model.DestinationCity, 11),
                        model.ShipmentCode,
                        model.TotalPiece,
                        model.TotalChargeableWeight,
                        TruncateString(model.PackageType, 3) + " " + TruncateString(model.ServiceType, 3),
                        model.TariffTotalInBaseCurrency
                        );

                    if (model.PackingFee > 0)
                    {
                        sb.AppendFormat("{0,57}        {1,14:#,0.00}\r\n", "Packing", model.PackingFee);
                        row++;
                    }

                    if (model.InsuranceFee > 0)
                    {
                        sb.AppendFormat("{0,57}        {1,14:#,0.00}\r\n", "Insurance", model.InsuranceFee);
                        row++;
                    }

                    if (model.OtherFee > 0)
                    {
                        sb.AppendFormat("{0,57}        {1,14:#,0.00}\r\n", model.OtherLabel, model.OtherFee);
                        row++;
                    }

                    subTotalPieces += model.TotalPiece;
                    subTotalCw += model.TotalChargeableWeight;
                    subTotalTotal += model.TariffTotalInBaseCurrency;
                    subTotalPacking += model.PackingFee;

                    if ((model.PackageType != null && model.PackageType.ToUpper().Equals("DOCUMENT")) || model.PackageTypeId == 1)
                    {
                        totalDocument += model.TariffTotalInBaseCurrency;
                    }
                    else
                    {
                        totalParcel += model.TariffTotalInBaseCurrency;
                    }
                }
                else
                {
                    isEnd = true;
                }
            }


            if ((startPage == 0 || page >= startPage) && (endPage == 0 || page <= endPage))
            {
                if (RowPerPage < row) RowPerPage = row;
                output.Append(string.Concat(Enumerable.Repeat("\n", RowPerPage - row + 1)));

                var invoiceFooter = "";
                var invoiceFooter1 = "";
                var invoiceFooter2 = "";
                var invoiceFooter3 = "";
                var invoiceFooter4 = "";
                var invoiceFooter5 = "";

                if (customer != null && customer.Footer1 != string.Empty)
                {
                    invoiceFooter = customer.Footer1;
                }
                else
                {
                    using (var branchDm = new BranchDataManager())
                    {
                        var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(salesInvoice.BranchId, "id"));
                        //if (Convert.ToDecimal(Parameters["GrandTotal"].Value) <= 50000000)
                        if (!salesInvoice.RefNumber.Substring(0, 2).ToUpper().Equals("AP"))
                        {
                            invoiceFooter = branch.InvoiceFooter1;
                        }
                        else
                        {
                            invoiceFooter = branch.InvoiceFooter2;
                        }
                    }
                }

                invoiceFooter1 = TruncateString(invoiceFooter, 42);
                invoiceFooter2 = (invoiceFooter.Length > 42) ? TruncateString(invoiceFooter.Substring(42), 42) : "";
                invoiceFooter3 = (invoiceFooter.Length > 84) ? TruncateString(invoiceFooter.Substring(84), 42) : "";
                invoiceFooter4 = (invoiceFooter.Length > 126)
                    ? TruncateString(invoiceFooter.Substring(126), 42)
                    : "";
                invoiceFooter5 = (invoiceFooter.Length > 168)
                    ? TruncateString(invoiceFooter.Substring(168), 42)
                    : "";

                output.AppendFormat(ReportFooterLayout,
                    Convert.ToDecimal(Parameters["Domestic"].Value).ToString("#,0.00"),
                    invoiceFooter1,
                    Convert.ToDecimal(Parameters["CityCourier"].Value).ToString("#,0.00"),
                    invoiceFooter2,
                    Convert.ToDecimal(Parameters["International"].Value).ToString("#,0.00"),
                    invoiceFooter3,
                    Convert.ToDecimal(Parameters["OtherFee"].Value).ToString("#,0.00"),
                    invoiceFooter4,
                    Convert.ToDecimal(Parameters["RaMateraiFee"].Value).ToString("#,0.00"),
                    invoiceFooter5,
                    Convert.ToDecimal(Parameters["PackingInsuranceFee"].Value).ToString("#,0.00"),
                    Convert.ToDecimal(Parameters["Discount"].Value).ToString("#,0.00"),
                    Convert.ToDecimal(Parameters["TaxRate"].Value),
                    Math.Floor(Convert.ToDecimal(Parameters["TaxTotal"].Value)).ToString("#,0.00"),
                    Convert.ToDecimal(Parameters["GrandTotal"].Value).ToString("#,0.00"),
                    Convert.ToDecimal(Parameters["DiscountPercent"].Value));

                output.AppendFormat("{0}", (char)12);
            }

            Write(output.ToString());
        }
    }
}