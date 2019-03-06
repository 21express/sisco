using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.Finance.Popup
{
    public partial class PaymentInCollectOutFilterPopup : BaseSearchCode<PaymentInCollectOutModel, PaymentInCollectOutDataManager>
    {
        public PaymentInCollectOutFilterPopup()
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

            var clPayment = new GridColumn
            {
                Name = "clPayment",
                Caption = @"Payment Type",
                FieldName = "PaymentType",
                VisibleIndex = 2
            };

            var clKw = new GridColumn
            {
                Name = "clKw",
                Caption = @"Kwitansi",
                FieldName = "Kwitansi",
                VisibleIndex = 3
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clPayment, clKw });
            SearchView.GridControl = GridSearch;

            //DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        private bool ParamEmpty { get; set; }
        protected override void BeforeFilter()
        {
            ByPaging = false;

            var param = new List<WhereTerm>();
            ParamEmpty = true;
            param.Add(WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals));

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

            if (tbxCode.Text != "")
            {
                param.Add(WhereTerm.Default(tbxCode.Text, "code", EnumSqlOperator.Like));
                ParamEmpty = false;
            }

            if (tbxCn.Text != "") ParamEmpty = false;

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
            var dm = new PaymentInCollectOutDetailDataManager();

            if (tbxCn.Text != "")
            {
                param.Add(WhereTerm.Default(tbxCn.Text, "invoice_code", EnumSqlOperator.Like));
            }

            // ReSharper disable once CoVariantArrayConversion
            var detail = dm.FilterPayment(CurrentFilter, param.ToArray());
            GridSearch.DataSource = detail;
            SearchView.RefreshData();
        }
    }
}
