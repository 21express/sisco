using SISCO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Popup
{
    public partial class CancellationPopup : Form
    {
        public string RevisedInvoice { get; set; }
        public string CancellationInvoice { get; set; }
        public List<SalesInvoiceRevised> InvoiceRevised { get; set; }
        public List<ShipmentModel> ShipmentRevised { get; set; }

        public CancellationPopup(string _cancellationInvoice)
        {
            InitializeComponent();
            Load += FormLoad;
            Shown += (s, a) => tbxKwitansi.Focus();

            CancellationInvoice = _cancellationInvoice;
            InvoiceRevised = new List<SalesInvoiceRevised>();
            ShipmentRevised = new List<ShipmentModel>();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            tbxKwitansi.Focus();
            btnOk.Click += ProcessCancellation;
            btnCancel.Click += (s, a) => {
                RevisedInvoice = string.Empty;
                this.Close(); 
            };
            btnCreate.Click += CreateInvoice;

            InvoiceRevised = new List<SalesInvoiceRevised>();
            btnOk.Enabled = false;
        }

        private void CreateInvoice(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxKwitansi.Text))
            {
                tbxKwitansi.Focus();
                return;
            }

            var cancelPopup = new InvoiceRevisionPopup(CancellationInvoice, tbxKwitansi.Text, InvoiceRevised)
            {
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false
            };
            cancelPopup.ShowDialog();

            if (cancelPopup.NewInvoice != null)
            {
                InvoiceRevised.Add(new SalesInvoiceRevised
                    {
                        SalesInvoice = cancelPopup.NewInvoice.SalesInvoice,
                        SalesInvoiceList = cancelPopup.NewInvoice.SalesInvoiceList,
                        SalesCosts = cancelPopup.NewInvoice.SalesCosts
                    });

                ShipmentRevised.AddRange(cancelPopup.ShipmentRevisions);

                var salesInvoice = new List<SalesInvoiceModel>();
                foreach(var s in InvoiceRevised)
                {
                    salesInvoice.Add(s.SalesInvoice);
                }

                GridReplacement.DataSource = salesInvoice;
                ReplacementView.RefreshData();

                tbxKwitansi.Clear();
                tbxKwitansi.Focus();
            }

            if (InvoiceRevised.Count > 0) btnOk.Enabled = true;
        }

        private void ProcessCancellation(object sender, EventArgs e)
        {
            if (InvoiceRevised.Count > 0)
            {
                var invoices = new List<string>();
                foreach (var x in InvoiceRevised)
                {
                    invoices.Add(x.SalesInvoice.RefNumber);
                }

                RevisedInvoice = string.Join(",", invoices);
                this.Close();
            }
            else
            {
                MessageBox.Show("Untuk proses pembatalan, harus menyertakan invoice baru.");
                tbxKwitansi.Focus();
                return;
            }
        }
    }
}