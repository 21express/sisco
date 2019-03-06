using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Billing;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
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
    public partial class InvoiceFinancePopup : BaseSearchCode<InvoiceToFinanceModel, InvoiceToFinanceDataManager>//BaseSearchPopup//
    {
        public InvoiceFinancePopup()
        {
            InitializeComponent();

            var cl1 = new GridColumn
            {
                Name = "cl1",
                Caption = @"Tgl Kirim",
                FieldName = "DateProcess",
                VisibleIndex = 0
            };

            cl1.DisplayFormat.FormatString = "dd-MM-yyyy";
            cl1.DisplayFormat.FormatType = FormatType.DateTime;

            var cl2 = new GridColumn
            {
                Name = "cl2",
                Caption = @"No Kwitansi",
                FieldName = "RefNumber",
                VisibleIndex = 1
            };

            CodeColumn = "Id";

            SearchView.Columns.AddRange(new[] { cl1, cl2 });
            SearchView.GridControl = GridSearch;

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id") };
        }

        protected override void BeforeFilter()
        {
        }

        protected override void Filter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxCode.Text) && string.IsNullOrEmpty(tbxFrom.Text) && string.IsNullOrEmpty(tbxTo.Text))
            {
                MessageBox.Show(@"Masukkan parameter pencarian", Resources.information, MessageBoxButtons.OK);
                tbxCode.Focus();
                return;
            }

            GridSearch.DataSource = new InvoiceToFinanceDataManager().Search(BaseControl.BranchId, tbxCode.Text, tbxFrom.DateTime, tbxTo.DateTime);
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }
    }
}
