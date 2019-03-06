using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Popup
{
    public partial class TitipInvoiceAcceptanceFilterPopup : BaseSearchCode<OtherInvoiceAcceptanceModel, OtherInvoiceAcceptanceDataManager>//BaseSearchPopup//
    {
        private bool isFiltered { get; set; }
        public TitipInvoiceAcceptanceFilterPopup()
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

            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Code",
                VisibleIndex = 1,
                Width = 75
            };

            var clNumber = new GridColumn
            {
                Name = "clNumber",
                Caption = @"Ref Number",
                FieldName = "RefNumber",
                VisibleIndex = 2,
                Width = 75
            };

            var clCustomer = new GridColumn
            {
                Name = "clCustomer",
                Caption = @"Customer",
                FieldName = "CustomerName",
                VisibleIndex = 3
            };

            var clBranch = new GridColumn
            {
                Name = "clBranch",
                Caption = @"Branch",
                FieldName = "BranchName",
                VisibleIndex = 4
            };

            SearchView.Columns.AddRange(new[] { clDate, clNumber, clCode, clCustomer, clBranch });
            SearchView.GridControl = GridSearch;

            Load += TitipInvoiceLoad;
            isFiltered = false;
        }

        private void TitipInvoiceLoad(object sender, EventArgs e)
        {
            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater =
                model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
        }

        protected override void BeforeFilter()
        {
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxFrom.Value > dateNull) isFiltered = true;
            if (tbxTo.Value > dateNull) isFiltered = true;
            if (tbxNumber.Text != "") isFiltered = true;
            if (tbxBranch.Value != null) isFiltered = true;
        }

        protected override void Filter(object sender, EventArgs e)
        {
            base.Filter(sender, e);
            if (!isFiltered)
            {
                MessageBox.Show("Silakan masukan parameter pencarian.");
                return;
            }

            var data = new OtherInvoiceAcceptanceDataManager().Search(tbxFrom.Value, tbxTo.Value, tbxBranch.Value, tbxNumber.Text);
            GridSearch.DataSource = data;
            SearchView.RefreshData();
        }
    }
}