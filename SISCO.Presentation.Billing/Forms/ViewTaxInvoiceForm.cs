using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class ViewTaxInvoiceForm : BaseForm
    {
        public ViewTaxInvoiceForm()
        {
            InitializeComponent();

            GridInvoice.DoubleClick += (sender, args) => OpenRelatedForm(InvoiceView, new CreateSalesInvoiceForm());
        }

        protected override void OnLoad(EventArgs e)
        {
            btnFilter.Click += Filter;
            InvoiceView.RowCellStyle += ChangeColor;

            var yearMember = new List<ComboMember>();
            for (var y = 2013; y <= DateTime.Now.Year; y++)
                yearMember.Add(new ComboMember { Id = y, Name = y.ToString() });

            cbxYear.DataSource = yearMember;

            var monthMember = new List<ComboMember>
            {
                new ComboMember(),
                new ComboMember{Id = 1, Name = "Januari"},
                new ComboMember{Id = 2, Name = "Febuari"},
                new ComboMember{Id = 3, Name = "Maret"},
                new ComboMember{Id = 4, Name = "April"},
                new ComboMember{Id = 5, Name = "Mei"},
                new ComboMember{Id = 6, Name = "Juni"},
                new ComboMember{Id = 7, Name = "Juli"},
                new ComboMember{Id = 8, Name = "Agustus"},
                new ComboMember{Id = 9, Name = "September"},
                new ComboMember{Id = 10, Name = "Oktober"},
                new ComboMember{Id = 11, Name = "November"},
                new ComboMember{Id = 12, Name = "Desember"},
            };

            cbxMonth.DataSource = monthMember;

            using (var taxInvoiceDm = new TaxInvoiceDataManager())
            {
                cmbTaxInvoice.DataSource = taxInvoiceDm.Get<TaxInvoiceModel>();
            }
            cmbTaxInvoice.DisplayMember = "Name";
            cmbTaxInvoice.ValueMember = "Id";
            cmbTaxInvoice.SelectedIndex = -1;

            cbxYear.SelectedValue = DateTime.Now.Year;
            GridInvoice.DataSource = new SalesInvoiceDataManager().GetTaxInvoice(cbxYear.SelectedValue.ToString(), cbxMonth.SelectedValue.ToString().PadLeft(2, '0'), BaseControl.BranchId, false, cmbTaxInvoice.SelectedIndex >= 0 ? (int?)cmbTaxInvoice.SelectedValue : null);
            InvoiceView.RefreshData();
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["InvoiceRevisionOf"]) != null)
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            GridInvoice.DataSource = new SalesInvoiceDataManager().GetTaxInvoice(cbxYear.SelectedValue.ToString(), (int)cbxMonth.SelectedValue > 0 ? cbxMonth.SelectedValue.ToString().PadLeft(2, '0') : null, BaseControl.BranchId, null, cmbTaxInvoice.SelectedIndex >= 0 ? (int?) cmbTaxInvoice.SelectedValue : null);
            InvoiceView.RefreshData();
        }
    }
}