using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class ViewSalesInvoiceListForm : BaseMasterForm<SalesInvoiceModel, SalesInvoiceDataManager>
    {
        public ViewSalesInvoiceListForm()
        {
            InitializeComponent();
            form = this;

            PageLimit = 99999;

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();
        }

        public override void SelectRow(object sender, EventArgs e)
        {
            
        }

        public override void Init()
        {
            CtlClearButton = null;
            CtlGridControl = grid;
            CtlGridView = gridView;
            CtlSearchButton = btnSearch;

            base.Init();
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpCustomer.LookupPopup = new CustomerPopup();
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);
            
            lkpMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing);
            lkpMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMarketing.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_marketing", s);

            var now = DateTime.Now;
            txtDateFrom.DateTime = new DateTime(now.Year, now.Month, 1);
            txtDateTo.DateTime = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));

            txtPeriodFrom.EditMask = "######";
            txtPeriodTo.EditMask = "######";

            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.Appearance.FocusedCell.Options.UseForeColor = false;
            gridView.OptionsNavigation.UseTabKey = false;
            gridView.OptionsBehavior.FocusLeaveOnTab = true;

            gridView.RowCellStyle += (o, args) =>
            {
                if (args.RowHandle < 0) return;

                if (((bool) gridView.GetRowCellValue(args.RowHandle, "Cancelled")))
                {
                    args.Appearance.ForeColor = Color.Red;
                }
            };

            btnSaveToExcel.Click += (o, args) => ExportGridToExcel(gridView, "Billing_SalesInvoiceList");

            grid.DoubleClick += GridOnDoubleClick;
            grid.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 13)
                {
                    GridOnDoubleClick(o, args);
                }
            };

            txtDateFrom.FieldLabel = "Date From";
            txtDateFrom.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtDateTo.FieldLabel = "Date To";
            txtDateTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
        }

        private void GridOnDoubleClick(object o, EventArgs args)
        {
            var rows = gridView.GetSelectedRows();

            if (rows.Length > 0)
            {
                BaseControl.OpenRelatedForm(new CreateSalesInvoiceForm(), gridView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
            }
        }

        protected override bool ValidateForm()
        {
            var errors = ComponentValidationHelper.Validate(txtDateFrom, txtDateTo);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            return true;
        }

        protected override void PopulateForm(SalesInvoiceModel model)
        {
            //
        }

        protected override SalesInvoiceModel PopulateModel(SalesInvoiceModel model)
        {
            return model;
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            p.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

            if (txtDateFrom.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtDateFrom.DateTime.Date, "vdate", EnumSqlOperator.GreatThanEqual));
            if (txtDateTo.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtDateTo.DateTime.Date.AddDays(1), "vdate", EnumSqlOperator.LesThanEqual));

            if (txtPeriodFrom.Text != string.Empty) p.Add(WhereTerm.Default(Convert.ToInt32(txtPeriodFrom.Text), "period", EnumSqlOperator.GreatThanEqual));
            if (txtPeriodTo.Text != string.Empty) p.Add(WhereTerm.Default(Convert.ToInt32(txtPeriodTo.Text), "period", EnumSqlOperator.LesThanEqual));

            if (lkpCustomer.Value != null) p.Add(WhereTerm.Default((int) lkpCustomer.Value, "company_id"));
            if (lkpMarketing.Value != null) p.Add(WhereTerm.Default((int)lkpMarketing.Value, "employee_id"));

            return p.ToArray();
        }

        protected override void AfterGridLoad()
        {
            base.AfterGridLoad();

            if (DataSource.Any())
            {
                grid.Focus();
            }
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters)
        {
            paging.SortColumn = "ref_number";
            return base.GetFromDataManager<T>(paging, out count, parameters);
        }
    }
}
