using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using DevExpress.XtraEditors;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class CourierPopup : BasePopup
    {
        public CourierPopup()
        {
            InitializeComponent();
            DataManager = new EmployeeDataManager();

            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);
            
            Parameters.Add(WhereTerm.Default((int)EnumDepartment.Kurir, "department_id", EnumSqlOperator.Equals));
            Parameters.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

            AutoCompleteWheretermFormater = Parameters.ToArray();
            var model = GotoFirstPage<EmployeeModel>(sender, e);
            objGrid.DataSource = model;
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

            SelectedText = string.Format("{0}", SelectedText);
        }
    }
}
