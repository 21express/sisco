using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SISCO.Models;
using SISCO.App.MasterData;
using Devenlab.Common;

namespace SISCO.Presentation.Common.Reports
{
    public partial class InvoicePDF : DevExpress.XtraReports.UI.XtraReport
    {
        private int index { get; set; }
        private decimal totalDocument { get; set; }
        private decimal totalPackage { get; set; }
        private decimal totalPacking { get; set; }
        private decimal totalInsurance { get; set; }
        private decimal totalOther { get; set; }

        public InvoicePDF()
        {
            InitializeComponent();
            
            index = 1;
            totalDocument = 0;
            totalPackage = 0;
            totalPacking = 0;
            totalInsurance = 0;
            totalOther = 0;
        }

        private void xrTableCell15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as SalesInvoiceListModel;
            if (string.IsNullOrEmpty(model.PackageType)) model.PackageType = model.PackageTypeId == 1 ? "DOCUMENT" : (model.PackageTypeId == 2 ? "PKT" : "");
            else model.PackageType = model.PackageTypeId == 1 ? "DOCUMENT" : (model.PackageTypeId == 2 ? "PKT" : "");

            var total = !string.IsNullOrEmpty(model.Currency) ? (model.TotalTariff * model.CurrencyRate) : model.TotalTariff;

            if ((model.PackageType != null && model.PackageType.ToUpper().Equals("DOCUMENT")) || model.PackageTypeId == 1)
            {
                totalDocument += total;
            }
            else
            {
                totalPackage += total;
            }

            ((XRTableCell)sender).Text = string.Format("{0} {1}", model.PackageType.Substring(0, Math.Min(model.PackageType.Length, 3)), model.ServiceType.Substring(0, Math.Min(model.ServiceType.Length, 3)));
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as SalesInvoiceListModel;
            ((XRTableCell)sender).Text = !string.IsNullOrEmpty(model.Currency) ? (model.TotalTariff * model.CurrencyRate).ToString("#,#") : model.TotalTariff.ToString("#,#");
        }

        private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = index.ToString("#");
            index++;
        }

        private void xrTableRow3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as SalesInvoiceListModel;
            if (model.PackingFee > 0) e.Cancel = false;
            else e.Cancel = true;

            totalPacking += model.PackingFee;
        }

        private void xrTableRow4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as SalesInvoiceListModel;
            if (model.InsuranceFee > 0) e.Cancel = false;
            else e.Cancel = true;

            totalInsurance += model.InsuranceFee;
        }

        private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var customer = Parameters["Customer"].Value as CustomerModel;
            var salesInvoice = Parameters["SalesInvoice"].Value as SalesInvoiceModel;
            ((XRLabel)sender).Text = string.Format("{0} {1}", customer.Code, salesInvoice.CompanyInvoicedTo);
        }

        private void xrLabel12_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var customer = Parameters["Customer"].Value as CustomerModel;
            ((XRLabel)sender).Text = string.Format("{0}\n Telp. {1}", customer.Address, customer.Phone);
        }

        private void xrLabel13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var salesInvoice = Parameters["SalesInvoice"].Value as SalesInvoiceModel;
            ((XRLabel)sender).Text = salesInvoice.RefNumber;
        }

        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var salesInvoice = Parameters["SalesInvoice"].Value as SalesInvoiceModel;
            ((XRLabel)sender).Text = salesInvoice.Vdate.ToString("dd-MM-yyyy");
        }

        private void xrLabel15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var invoiceFooter = "";
            var customer = Parameters["Customer"].Value as CustomerModel;
            var salesInvoice = Parameters["SalesInvoice"].Value as SalesInvoiceModel;

            if (customer != null && customer.Footer1 != string.Empty)
            {
                invoiceFooter = customer.Footer1;
            }
            else
            {
                using (var branchDm = new BranchDataManager())
                {
                    var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(salesInvoice.BranchId, "id"));
                    if (Convert.ToDecimal(Parameters["GrandTotal"].Value) <= 50000000)
                    {
                        invoiceFooter = branch.InvoiceFooter1;
                    }
                    else
                    {
                        invoiceFooter = branch.InvoiceFooter2;
                    }
                }
            }

            ((XRLabel)sender).Text = invoiceFooter;
        }

        private void xrLabel36_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = totalDocument.ToString("#,#0");
        }

        private void xrLabel37_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = totalPackage.ToString("#,#0");
        }

        private void xrTableRow5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (totalOther > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrTableRow8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as SalesInvoiceListModel;
            if (model.OtherFee > 0) e.Cancel = false;
            else e.Cancel = true;

            totalOther += model.OtherFee;
        }

        private void xrTableCell33_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = totalPacking.ToString("#,#0");
        }

        private void xrTableCell36_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = totalInsurance.ToString("#,#0");
        }

        private void xrTableCell19_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = totalOther.ToString("#,#0");
        }

        private void xrTableRow6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (totalPacking > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrTableRow7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (totalInsurance > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrLabel41_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var salesInvoice = Parameters["SalesInvoice"].Value as SalesInvoiceModel;
            ((XRLabel)sender).Text = salesInvoice.InvoiceRevisionOf;

            ((XRLabel)sender).Visible = !string.IsNullOrEmpty(salesInvoice.InvoiceRevisionOf);
        }

        private void xrLabel39_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var salesInvoice = Parameters["SalesInvoice"].Value as SalesInvoiceModel;
            ((XRLabel)sender).Visible = !string.IsNullOrEmpty(salesInvoice.InvoiceRevisionOf);
        }

        private void xrLabel40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var salesInvoice = Parameters["SalesInvoice"].Value as SalesInvoiceModel;
            ((XRLabel)sender).Visible = !string.IsNullOrEmpty(salesInvoice.InvoiceRevisionOf);
        }
    }
}