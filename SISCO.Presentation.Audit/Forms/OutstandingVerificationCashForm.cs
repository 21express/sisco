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
    public partial class OutstandingVerificationCashForm : BaseForm
    {
        public OutstandingVerificationCashForm()
        {
            InitializeComponent();
            Load += OutstandingVerificationCashForm_Load;

            // Save ke Excel
            btnSave.Click += (sender, args) => ExportExcel(PaymentCounterGrid);

            // Double klik pada grid otomatis buka form lain
            PaymentCounterGrid.DoubleClick += (sender, args) => OpenRelatedForm(PaymentCounterView, new VerificationCashForm());
          
        }

 

        private void OutstandingVerificationCashForm_Load(object sender, EventArgs e)
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

            PaymentCounterGrid.DataSource = new List<PaymentInCounterModel>();

            var dateStart = tbxStart.DateTime;
            var dateEnd = tbxEnd.DateTime;
            dateStart = new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, 0, 0, 0);
            dateEnd = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);

            // Jika cekbox outstanding di cheklist atau tidak
            if (chbOut.Checked == true)
            {
                var data = new PaymentInCounterDataManager().Get<PaymentInCounterModel>(new IListParameter[]
                {
                    WhereTerm.Default(dateStart, "date_process", EnumSqlOperator.GreatThanEqual),
                    WhereTerm.Default(dateEnd, "date_process", EnumSqlOperator.LesThanEqual),
                    WhereTerm.Default(false, "verified")
                }).ToList();

                PaymentCounterGrid.DataSource = data;
                PaymentCounterView.RefreshData();

            }
            else
            {
                var data = new PaymentInCounterDataManager().Get<PaymentInCounterModel>(new IListParameter[]
                {
                    WhereTerm.Default(dateStart, "date_process", EnumSqlOperator.GreatThanEqual),
                    WhereTerm.Default(dateEnd, "date_process", EnumSqlOperator.LesThanEqual),
                    WhereTerm.Default(true, "verified")
                }).ToList();

                PaymentCounterGrid.DataSource = data;
                PaymentCounterView.RefreshData();
            
            }

            
        }
    }

}
