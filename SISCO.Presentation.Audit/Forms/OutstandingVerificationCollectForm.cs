using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.App.Finance;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Presentation.Audit.Forms
{
    public partial class OutstandingVerificationCollectForm : BaseForm
    {
        public OutstandingVerificationCollectForm()
        {
            InitializeComponent();
            Load += OutstandingVerificationCollectForm_load;
            btnSave.Click += (sender, args) => ExportExcel(PaymentCollectGrid);

            // Double klik pada grid otomatis buka form lain
            PaymentCollectGrid.DoubleClick += (sender, args) => OpenRelatedForm(PaymentCollectView, new VerificationCollectForm());
        }

        private void OutstandingVerificationCollectForm_load(object sender, EventArgs e)
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


            PaymentCollectGrid.DataSource = new List<PaymentOutCollectInModel>();

            var dateStart = tbxStart.DateTime;
            var dateEnd = tbxEnd.DateTime;

            dateStart = new DateTime(dateStart.Year, dateStart.Month, dateStart.Day, 0, 0, 0);
            dateEnd = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);

            // Jika cekbox outstanding di cheklist atau tidak
            if (chbOut.Checked == true)
            {
                var data = new PaymentOutCollectInDataManager().Get<PaymentOutCollectInModel>(new IListParameter[] 
                    {
                        WhereTerm.Default(dateStart, "date_process", EnumSqlOperator.GreatThanEqual),
                        WhereTerm.Default(dateEnd, "date_process", EnumSqlOperator.LesThanEqual),
                        WhereTerm.Default(false, "verified")
                    }
                        ).ToList();

                PaymentCollectGrid.DataSource = data;
                PaymentCollectView.RefreshData();
            }
            else {

                var data = new PaymentOutCollectInDataManager().Get<PaymentOutCollectInModel>(new IListParameter[] 
                    {
                        WhereTerm.Default(dateStart, "date_process", EnumSqlOperator.GreatThanEqual),
                        WhereTerm.Default(dateEnd, "date_process", EnumSqlOperator.LesThanEqual),
                        WhereTerm.Default(true, "verified")
                    }
                        ).ToList();

                PaymentCollectGrid.DataSource = data;
                PaymentCollectView.RefreshData();
            
            
            }

           

        }

     
    }
}
