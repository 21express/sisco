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

namespace SISCO.Presentation.Finance.Popup
{
    public partial class TitipInvoiceFilterPopup : BaseSearchCode<OtherInvoiceModel, OtherInvoiceDataManager>
    {
        public TitipInvoiceFilterPopup()
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
            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals));

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxFrom.Value > dateNull)
            {
                var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (tbxTo.Value > dateNull)
            {
                var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            }

            if (tbxNumber.Text != "")
            {
                param.Add(WhereTerm.Default(tbxNumber.Text, "ref_number", EnumSqlOperator.Equals));
            }

            if (tbxBranch.Value != null)
            {
                param.Add(WhereTerm.Default((int) tbxBranch.Value, "branch_id", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
