using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Popup
{
    public partial class SchedulerPopup : BaseSearchCode<PickupSchedulerModel, PickupSchedulerDataManager>//BaseSearchPopup//
    {
        public SchedulerPopup()
        {
            InitializeComponent();

            form = this;
            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Start",
                FieldName = "StartDate",
                VisibleIndex = 0,
                Width = 60
            };

            clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            clDate.DisplayFormat.FormatType = FormatType.DateTime;

            var clStt = new GridColumn
            {
                Name = "clSTT",
                Caption = @"Customer",
                FieldName = "CustomerName",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clDate, clStt });
            SearchView.GridControl = GridSearch;

            CodeColumn = "Id";

            lkpCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            cbxActive.Checked = true;
        }

        protected override void BeforeFilter()
        {
        }

        protected override void Filter(object sender, EventArgs e)
        {
            GridSearch.DataSource = new PickupSchedulerDataManager().Search(BaseControl.BranchId, cbxActive.Checked, cbxMon.Checked, cbxTue.Checked, cbxWed.Checked, cbxThu.Checked, cbxFri.Checked, cbxSat.Checked, cbxSun.Checked, (int?)lkpCustomer.Value, tbxCustomer.Text);
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }
    }
}
