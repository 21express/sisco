using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Popup
{
    public partial class PettyCashFilterPopup : BaseSearchCode<CostModel, CostDataManager>//BaseSearchPopup//
    {
        public PettyCashFilterPopup()
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

            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Code",
                VisibleIndex = 1,
                Width = 60
            };

            clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            clDate.DisplayFormat.FormatType = FormatType.DateTime;

            var cl1 = new GridColumn
            {
                Name = "cl1",
                Caption = @"Maksud / Tujuan",
                FieldName = "Description",
                VisibleIndex = 2
            };

            var cl2 = new GridColumn
            {
                Name = "cl2",
                Caption = "Debit",
                FieldName = "DebitAmount",
                VisibleIndex = 3,
                DisplayFormat =
                {
                    FormatString = "n0",
                    FormatType = FormatType.Numeric
                }
            };

            var cl3 = new GridColumn
            {
                Name = "cl3",
                Caption = "Kredit",
                FieldName = "CreditAmount",
                VisibleIndex = 4,
                DisplayFormat =
                {
                    FormatString = "n0",
                    FormatType = FormatType.Numeric
                }
            };

            var cl4 = new GridColumn
            {
                Name = "cl4",
                Caption = "Diterima Dari/Oleh",
                FieldName = "EmployeeName",
                VisibleIndex = 5
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, cl1, cl2, cl3, cl4 });
            SearchView.GridControl = GridSearch;

            CodeColumn = "Code";

            lkpEmployee.LookupPopup = new EmployeePopup();
            lkpEmployee.AutoCompleteDataManager = new EmployeeDataManager();
            lkpEmployee.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpEmployee.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);
        }

        protected override void BeforeFilter()
        {
        }

        protected override void Filter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxCode.Text) && string.IsNullOrEmpty(tbxDescription.Text) && 
                string.IsNullOrEmpty(tbxFrom.Text) && string.IsNullOrEmpty(tbxTo.Text) && lkpEmployee.Value == null)
            {
                MessageBox.Show(@"Masukkan parameter pencarian", Resources.information, MessageBoxButtons.OK);
                tbxCode.Focus();
                return;
            }

            GridSearch.DataSource = new PettyCashJournalDataManager().Search(BaseControl.BranchId, tbxCode.Text, tbxDescription.Text, tbxFrom.DateTime, tbxTo.DateTime, lkpEmployee.Value);
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }
    }
}
