using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.Billing;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class InvoiceDistributionReportForm : BaseForm
    {
        public InvoiceDistributionReportForm()
        {
            InitializeComponent();
            form = this;

            Load += InvoiceDistributionReportForm_Load;
            Shown += InvoiceDistributionReportForm_Shown;
        }

        void InvoiceDistributionReportForm_Shown(object sender, EventArgs e)
        {
            tbxFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            tbxTo.DateTime = tbxFrom.DateTime.AddMonths(1).AddDays(-1);

            tbxFrom.Focus();
        }

        void InvoiceDistributionReportForm_Load(object sender, EventArgs e)
        {
            btnOk.Click += btnOk_Click;
            btnExcel.Click += btnExcel_Click;
            DistributionView.CustomColumnDisplayText += NumberGrid;
            DistributionView.RowCellStyle += DistributionView_RowCellStyle;
        }

        void DistributionView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view != null && (bool)view.GetRowCellValue(e.RowHandle, view.Columns["Cancelled"]))
                e.Appearance.ForeColor = Color.Red;
            else e.Appearance.ForeColor = Color.Black;
        }

        void btnExcel_Click(object sender, EventArgs e)
        {
            if (DistributionView.RowCount > 0) ExportExcel(GridDistribution);
            else MessageBox.Show("Tidak ada data yang ditampilkan");

            tbxFrom.Focus();
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            GridDistribution.DataSource = new SalesInvoiceDataManager().GetInvoiceDistribution(BaseControl.BranchId, tbxFrom.DateTime, tbxTo.DateTime, tbxSendFrom.DateTime, tbxSendTo.DateTime);
            DistributionView.RefreshData();
        }
    }
}