using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SISCO.Presentation.Audit.Forms
{
    public partial class OutstandingVerificationInvoiceForm : BaseForm
    {
        public OutstandingVerificationInvoiceForm()
        {
            InitializeComponent();
            Load += OutstandingVerificationInvoiceForm_load;

            // Save ke Excel
            btnSave.Click += (sender, args) => ExportExcel(PaymentInvoiceGrid);

            // Double klik pada grid otomatis buka form lain
            PaymentInvoiceGrid.DoubleClick += (sender, args) => OpenRelatedForm(PaymentInvoiceView, new VerificationInvoiceForm());
        }

        private void OutstandingVerificationInvoiceForm_load(object sender, EventArgs e)
        {
            tbxStart.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).ToString();
            tbxEnd.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString();

            btnView.Click += btnView_Click;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //cek selisih tanggal awal dan akhir
            if (tbxEnd.Value.Subtract(tbxStart.Value).Days > 356)
            {
                MessageBox.Show(@"Jarak selisih Tanggal Tidak bisa lebih dari 1 Tahun");
                return;
            }

            PaymentInvoiceGrid.DataSource = new List<PaymentInModel>();

            var dateStart = tbxStart.DateTime;
            var dateEnd = tbxEnd.DateTime;

            dateStart = new DateTime(dateStart.Year, dateStart.Month, 1, 0, 0, 0);
            dateEnd = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);

            // Jika cekbox outstanding di cheklist atau tidak
            if (chbOut.Checked == true)
            {
                var data = new PaymentInDataManager().Get<PaymentInModel>(new IListParameter[]
                    {
                        WhereTerm.Default(dateStart, "date_process", EnumSqlOperator.GreatThanEqual),
                        WhereTerm.Default(dateEnd, "date_process", EnumSqlOperator.LesThanEqual),
                        WhereTerm.Default(false, "verified")
                    }).ToList();

                PaymentInvoiceGrid.DataSource = data;
                PaymentInvoiceView.RefreshData();

            }
            else 
            {
                var data = new PaymentInDataManager().Get<PaymentInModel>(new IListParameter[]
                    {
                        WhereTerm.Default(dateStart, "date_process", EnumSqlOperator.GreatThanEqual),
                        WhereTerm.Default(dateEnd, "date_process", EnumSqlOperator.LesThanEqual),
                        WhereTerm.Default(true, "verified")
                    }).ToList();

                PaymentInvoiceGrid.DataSource = data;
                PaymentInvoiceView.RefreshData();
            
            }

        }
    }
}
