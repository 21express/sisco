using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SISCO.Models;
using SISCO.App.MasterData;
using Devenlab.Common;

namespace SISCO.Presentation.Billing.Reports
{
    public partial class FranchiseInvoicePDF : DevExpress.XtraReports.UI.XtraReport
    {
        private int index { get; set; }
        private decimal totalInsurance { get; set; }
        private decimal totalOther { get; set; }
        private decimal totalNetInvoice { get; set; }

        public FranchiseInvoicePDF()
        {
            InitializeComponent();
            
            index = 1;
            totalInsurance = 0;
            totalOther = 0;
            totalNetInvoice = 0;
        }

        private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = index.ToString("#");
            index++;
        }

        private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var franchise = Parameters["Franchise"].Value as FranchiseModel;
            var salesInvoice = Parameters["FranchiseSalesInvoice"].Value as FranchiseInvoiceModel;
            ((XRLabel)sender).Text = string.Format("{0} {1}", franchise.Code, salesInvoice.InvoicedTo);
        }

        private void xrLabel12_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var franchise = Parameters["Franchise"].Value as FranchiseModel;
            ((XRLabel)sender).Text = string.Format("{0}\n Telp. {1}", franchise.Address, franchise.Phone);
        }

        private void xrLabel13_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var salesInvoice = Parameters["FranchiseSalesInvoice"].Value as FranchiseInvoiceModel;
            ((XRLabel)sender).Text = salesInvoice.Code;
        }

        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var salesInvoice = Parameters["FranchiseSalesInvoice"].Value as FranchiseInvoiceModel;
            ((XRLabel)sender).Text = salesInvoice.DateProcess.ToString("dd-MM-yyyy");
        }

        private void xrLabel15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var invoiceFooter = "";
            var salesInvoice = Parameters["FranchiseSalesInvoice"].Value as FranchiseInvoiceModel;

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

            ((XRLabel)sender).Text = invoiceFooter;
        }

        private void xrTableCell32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as FranchiseInvoiceListModel;
            ((XRTableCell)sender).Text = model.InsuranceFee.ToString("#,#");
        }

        private void xrTableCell25_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as FranchiseInvoiceListModel;
            ((XRTableCell)sender).Text = model.OtherFee.ToString("#,#");
        }

        private void xrTableRow4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as FranchiseInvoiceListModel;
            if (model.InsuranceFee > 0) e.Cancel = false;
            else e.Cancel = true;

            totalInsurance += model.InsuranceFee;
        }

        private void xrTableRow8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as FranchiseInvoiceListModel;
            if (model.OtherFee > 0) e.Cancel = false;
            else e.Cancel = true;

            totalOther += model.OtherFee;
        }

        private void xrTableCell35_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = totalInsurance.ToString("#,#0");
            totalInsurance = 0;
        }

        private void xrTableCell39_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = totalOther.ToString("#,#0");
            totalOther = 0;
        }

        private void xrTableRow5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (totalInsurance > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrTableRow6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (totalOther > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrTableCell52_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as FranchiseInvoiceListModel;
            var netInvoice = (model.TotalSales - model.NetCommission);
            totalNetInvoice += netInvoice;
            ((XRTableCell)sender).Text = (model.TotalSales - model.NetCommission).ToString("#,#");
        }

        private void xrTableCell29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRTableCell)sender).Text = totalNetInvoice.ToString("#,#");
        }

        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = totalNetInvoice.ToString("#,#");
        }
    }
}
