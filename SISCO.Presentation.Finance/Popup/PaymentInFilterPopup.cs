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
    public partial class PaymentInFilterPopup : BaseSearchCode<PaymentInModel, PaymentInDataManager>//BaseSearchPopup//
    {
        public PaymentInFilterPopup()
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

            var clCustomer = new GridColumn
            {
                Name = "clCustomer",
                Caption = @"Customer",
                FieldName = "CustomerName",
                VisibleIndex = 2
            };

            var clPayment = new GridColumn
            {
                Name = "clPayment",
                Caption = @"Payment Type",
                FieldName = "PaymentType",
                VisibleIndex = 3
            };

            var clKw = new GridColumn
            {
                Name = "clKw",
                Caption = @"Kwitansi",
                FieldName = "Kwitansi",
                VisibleIndex = 4
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clCustomer, clPayment, clKw });
            SearchView.GridControl = GridSearch;

            Load += PaymentInLoad;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        private void PaymentInLoad(object sender, EventArgs e)
        {
            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteText = model => ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
        }

        private bool ParamEmpty { get; set; }
        protected override void BeforeFilter()
        {
            ByPaging = false;

            var param = new List<WhereTerm>();

            ParamEmpty = true;
            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

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

            if (tbxPayment.Value != null)
            {
                param.Add(WhereTerm.Default((int) tbxPayment.Value, "payment_type_id", EnumSqlOperator.Equals));
                ParamEmpty = false;
            }

            if (tbxKw.Text != "") ParamEmpty = false;

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
            var dm = new PaymentInDetailDataManager();

            if (tbxKw.Text != "")
            {
                param.Add(WhereTerm.Default(tbxKw.Text, "invoice_ref_number", EnumSqlOperator.Like));
            }

            // ReSharper disable once CoVariantArrayConversion
            var detail = dm.FilterPayment(CurrentFilter, param.ToArray());
            GridSearch.DataSource = detail;
            SearchView.RefreshData();
        }
    }
}