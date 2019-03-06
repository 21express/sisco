using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class OutboundDaratFilterPopup : BaseSearchCode<WaybillModel, WaybillDataManager>
    {
        public IListParameter[] DefaultParam
        {
            set { DataManager.DefaultParameters = value; }
        }

        public OutboundDaratFilterPopup()
        {
            InitializeComponent();

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

            var clBranch = new GridColumn
            {
                Name = "clBranch",
                Caption = @"Branch",
                FieldName = "BranchId",
                VisibleIndex = 2
            };

            var clPengangkut = new GridColumn
            {
                Name = "clPengangkut",
                Caption = @"Pengangkut",
                FieldName = "EstCarrier",
                VisibleIndex = 3
            };

            var clDriver = new GridColumn
            {
                Name = "clDriver",
                Caption = @"Driver",
                FieldName = "EmployeeName",
                VisibleIndex = 4
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clBranch, clPengangkut, clDriver });
            SearchView.GridControl = GridSearch;
            Load += WaybillLoad;
        }

        private void WaybillLoad(object sender, EventArgs e)
        {
            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            //SearchCodeLoad(sender, e);
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

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

            if (tbxBranch.Value != null)
                param.Add(WhereTerm.Default((int)tbxBranch.Value, "branch_id", EnumSqlOperator.Equals));

            if (tbxPengangkut.Text != "")
                param.Add(WhereTerm.Default(tbxPengangkut.Text, "act_carrier", EnumSqlOperator.Like));

            if (tbxDriver.Text != "")
                param.Add(WhereTerm.Default(tbxDriver.Text, "employee_name", EnumSqlOperator.Like));

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
