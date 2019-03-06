
using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
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
    public partial class PaymentRcFilterPopup : BaseSearchCode<PaymentRcModel, PaymentRcDataManager>
    {
        public PaymentRcFilterPopup()
        {
            InitializeComponent();

            form = this;
            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Date",
                FieldName = "DateProcess",
                VisibleIndex = 0,
                Width = 20
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

            var clPayment = new GridColumn
            {
                Name = "clPayment",
                Caption = @"Kwitansi",
                FieldName = "Kwitansi",
                VisibleIndex = 3
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clPayment });
            SearchView.GridControl = GridSearch;

            Load += PaymentRcFilterLoad;
        }

        private void PaymentRcFilterLoad(object sender, EventArgs e)
        {
            tbxCustomer.LookupPopup = new CustomerPopup();
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);
        }

        private bool ParamEmpty { get; set; }
        protected override void BeforeFilter()
        {
            ByPaging = false;

            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

            ParamEmpty = true;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxFrom.Value > dateNull)
            {
                var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                ParamEmpty = false;
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (tbxTo.Value > dateNull)
            {
                var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
                ParamEmpty = false;
            }

            if (tbxCustomer.Value != null)
            {
                param.Add(WhereTerm.Default((int) tbxCustomer.Value, "customer_id", EnumSqlOperator.Equals));
                ParamEmpty = false;
            }

            if (tbxKwitansi.Text != "") ParamEmpty = false;

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }

        protected override void Filter(object sender, EventArgs e)
        {
            base.Filter(sender, e);
            if (!ParamEmpty) AfterFilter();
        }

        private void AfterFilter()
        {
            var param = new List<WhereTerm>();
            var dm = new PaymentRcDetailDataManager();

            if (tbxKwitansi.Text != "")
            {
                param.Add(WhereTerm.Default(tbxKwitansi.Text, "invoice_code", EnumSqlOperator.Like));
            }

            // ReSharper disable once CoVariantArrayConversion
            var detail = dm.FilterPayment(CurrentFilter, param.ToArray());
            GridSearch.DataSource = detail;
            SearchView.RefreshData();
        }
    }
}
