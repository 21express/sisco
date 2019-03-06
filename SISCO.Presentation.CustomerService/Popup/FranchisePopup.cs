using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using SISCO.App.Franchise;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.CustomerService.Popup
{
    public partial class FranchisePopup : BasePopup
    {
        public FranchisePopup()
        {
            InitializeComponent();
            DataManager = new FranchiseDataManager();

            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public FranchisePopup(params IListParameter[] defaultParam)
        {
            InitializeComponent();
            DataManager = new FranchiseDataManager();
            DataManager.DefaultParameters = defaultParam;

            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = GotoFirstPage<FranchiseModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void ClearFilter(object sender, System.EventArgs e)
        {
            base.ClearFilter(sender, e);
            var model = GotoFirstPage<FranchiseModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void Filter(object sender, System.EventArgs e)
        {
            base.Filter(sender, e);
            var model = GotoFirstPage<FranchiseModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            IEnumerable<FranchiseModel> model;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    model = GotoFirstPage<FranchiseModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 2:
                    model = GotoPreviousPage<FranchiseModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 3:
                    model = GotoNextPage<FranchiseModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 5:
                    model = GotoLastPage<FranchiseModel>(sender, e);
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