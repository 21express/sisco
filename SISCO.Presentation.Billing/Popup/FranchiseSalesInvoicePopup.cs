using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Billing;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Billing.Popup
{
    public partial class FranchiseSalesInvoicePopup : BaseSearchCode<SalesInvoiceModel, SalesInvoiceDataManager>//BaseSearchPopup//
    {
        public FranchiseSalesInvoicePopup()
        {
            InitializeComponent();

            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Code",
                VisibleIndex = 0,
                Width = 75
            };

            var clCustomer = new GridColumn
            {
                Name = "clCustomer",
                Caption = @"Invoiced To",
                FieldName = "InvoicedTo",
                VisibleIndex = 1
            };

            CodeColumn = "Code";
            SortColumn = "date_process";
            SortDirection = "DESC";

            SearchView.Columns.AddRange(new[] { clCode, clCustomer });
            SearchView.GridControl = GridSearch;
            
            DataManager.DefaultParameters = new IListParameter[]
            {WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)};
        }

        protected override void BeforeFilter()
        {
            var p = new List<IListParameter>();

            p.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

            if (txtFilterDateFrom.DateTime != DateTime.MinValue)
                p.Add(WhereTerm.Default(txtFilterDateFrom.DateTime, "date_process", EnumSqlOperator.GreatThanEqual));
            if (txtFilterDateTo.DateTime != DateTime.MinValue)
                p.Add(WhereTerm.Default(txtFilterDateFrom.DateTime, "date_process", EnumSqlOperator.LesThanEqual));

            // ReSharper disable once CoVariantArrayConversion
            if (p.Any()) AutoCompleteWheretermFormater = p.ToArray();
        }

        public new void SelectRow(object sender, EventArgs e)
        {
            var rows = SearchView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(SearchView.GetRowCellValue(rows[0], "Id"));
                SelectedText = SearchView.GetRowCellValue(rows[0], "Id").ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.information);
        }
    }
}
