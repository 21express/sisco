using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using Corporate.Presentation.Common.Forms;
using SISCO.App.MasterData;
using SISCO.Models;
using BaseControl = Corporate.Presentation.Common.BaseControl;

namespace Corporate.Presentation.MasterData.Popup
{
    public partial class EmployeePopup : BasePopup
    {
        protected EmployeeModel.EmployeeType EmployeeType;
        public EmployeePopup(EmployeeModel.EmployeeType employeeType = EmployeeModel.EmployeeType.All, params IListParameter[] defaultParam)
        {
            InitializeComponent();
            DataManager = new EmployeeDataManager();

            DataManager.DefaultParameters = defaultParam;
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            PagingForm = new Paging { Direction = "ASC", Limit = PageLimit, SortColumn = "name" };
            EmployeeType = employeeType;

            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);
             
            Filter(sender, e);
            NavigatorPagingState = PagingState;
        }

        protected override void ClearFilter(object sender, System.EventArgs e)
        {
            base.ClearFilter(sender, e);
            var model = GotoFirstPage<EmployeeModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void Filter(object sender, System.EventArgs e)
        {
            base.Filter(sender, e);

            if (EmployeeType != EmployeeModel.EmployeeType.All)
            {
                var toAdd = new List<IListParameter>();

                toAdd.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
                switch (EmployeeType)
                {
                    case EmployeeModel.EmployeeType.CustomerService:
                        toAdd.Add(WhereTerm.Default(true, "as_customer_service"));
                        break;
                    case EmployeeModel.EmployeeType.Messenger:
                        toAdd.Add(WhereTerm.Default(true, "as_messenger"));
                        break;
                    case EmployeeModel.EmployeeType.Marketing:
                        toAdd.Add(WhereTerm.Default(true, "as_marketing"));
                        break;
                }

                AutoCompleteWheretermFormater = AutoCompleteWheretermFormater.Concat(toAdd).ToArray();
            }

            var model = GotoFirstPage<EmployeeModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            IEnumerable<EmployeeModel> model;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    model = GotoFirstPage<EmployeeModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 2:
                    model = GotoPreviousPage<EmployeeModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 3:
                    model = GotoNextPage<EmployeeModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 5:
                    model = GotoLastPage<EmployeeModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
            }

            NavigatorPagingState = PagingState;
        }

        public override void SelectRow(object sender, System.EventArgs e)
        {
            int[] rows = objGridView.GetSelectedRows();
            string code = string.Empty;
            if (rows.Count() > 0) code = objGridView.GetRowCellValue(rows[0], "Code").ToString();
            base.SelectRow(sender, e);

            SelectedText = string.Format("{0} - {1}", code, SelectedText);
        }
    }
}
