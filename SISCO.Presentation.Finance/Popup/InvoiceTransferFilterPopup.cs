using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.Design.WebControls;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Finance.Popup
{
    public partial class InvoiceTransferFilterPopup : BaseSearchCode<InvoiceTransferModel, InvoiceTransferDataManager>//BaseSearchPopup//
    {
        public InvoiceTransferFilterPopup()
        {
            InitializeComponent();

            form = this;
            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Date",
                FieldName = "DateProcess",
                VisibleIndex = 0,
                Width = 60
            };

            clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            clDate.DisplayFormat.FormatType = FormatType.DateTime;

            var clStt = new GridColumn
            {
                Name = "clSTT",
                Caption = @"No Kwitansi",
                FieldName = "RefNumber",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clDate, clStt });
            SearchView.GridControl = GridSearch;

            CodeColumn = "Id";
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

            GridSearch.DataSource = new InvoiceTransferDataManager().Search(BaseControl.BranchId, tbxCode.Text, tbxFrom.DateTime, tbxTo.DateTime);
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }
    }
}
