using System.Collections.Generic;
using System.Linq;
using Corporate.Presentation.Common.Forms;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using SISCO.App.MasterData;
using SISCO.Models;

namespace Corporate.Presentation.MasterData.Popup
{
    public partial class BranchPopup : BasePopup
    {
        public BranchPopup()
        {
            InitializeComponent();
            DataManager = new BranchDataManager();

            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public BranchPopup(params IListParameter[] defaultParam)
        {
            InitializeComponent();
            DataManager = new BranchDataManager();
            DataManager.DefaultParameters = defaultParam;

            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = GotoFirstPage<BranchModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void ClearFilter(object sender, System.EventArgs e)
        {
            base.ClearFilter(sender, e);
            var model = GotoFirstPage<BranchModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void Filter(object sender, System.EventArgs e)
        {
            base.Filter(sender, e);
            var model = GotoFirstPage<BranchModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            IEnumerable<BranchModel> model;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    model = GotoFirstPage<BranchModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 2:
                    model = GotoPreviousPage<BranchModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 3:
                    model = GotoNextPage<BranchModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 5:
                    model = GotoLastPage<BranchModel>(sender, e);
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
