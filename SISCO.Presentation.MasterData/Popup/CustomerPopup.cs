using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class CustomerPopup : BasePopup
    {
        public CustomerPopup()
        {
            InitializeComponent();
            DataManager = new CustomerDataManager();
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            PagingForm = new Paging { Direction = "ASC", Limit = PageLimit, SortColumn = "name" };
            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public CustomerPopup(params IListParameter[] defaultParam)
        {
            InitializeComponent();
            DataManager = new CustomerDataManager();

            DevExpress.XtraGrid.Columns.GridColumn gridAddress = new DevExpress.XtraGrid.Columns.GridColumn();

            gridAddress.Caption = "Address";
            gridAddress.FieldName = "Address";
            gridAddress.Name = "clAddress";
            gridAddress.Visible = true;
            gridAddress.VisibleIndex = 2;
            gridAddress.Width = 220;

            objGridView.Columns.Add(gridAddress);

            DataManager.DefaultParameters = defaultParam;
            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = GotoFirstPage<CustomerModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void ClearFilter(object sender, System.EventArgs e)
        {
            base.ClearFilter(sender, e);
            var model = GotoFirstPage<CustomerModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void Filter(object sender, System.EventArgs e)
        {
            base.Filter(sender, e);
            var model = GotoFirstPage<CustomerModel>(sender, e).ToList();
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            IEnumerable<CustomerModel> model;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    model = GotoFirstPage<CustomerModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 2:
                    model = GotoPreviousPage<CustomerModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 3:
                    model = GotoNextPage<CustomerModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 5:
                    model = GotoLastPage<CustomerModel>(sender, e)
                        ;
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