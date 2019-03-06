using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using BaseControl = SISCO.Presentation.Common.BaseControl;
using SISCO.App.MasterData;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class PromoPopup : BasePopup
    {
        public PromoPopup()
        {
            InitializeComponent();
            DataManager = new PromoDataManager();

            PagingForm = new Paging { Direction = "ASC", Limit = PageLimit, SortColumn = "name" };
            ObjNavigator.ButtonClick += NavigatorClick;
        }

        public override void LoadPopup(object sender, System.EventArgs e)
        {
            base.LoadPopup(sender, e);

            var model = GotoFirstPage<PromoModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void ClearFilter(object sender, System.EventArgs e)
        {
            base.ClearFilter(sender, e);
            var model = GotoFirstPage<PromoModel>(sender, e);
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected override void Filter(object sender, System.EventArgs e)
        {
            base.Filter(sender, e);
            var model = GotoFirstPage<PromoModel>(sender, e).ToList();
            objGrid.DataSource = model;
            NavigatorPagingState = PagingState;
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            IEnumerable<PromoModel> model;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    model = GotoFirstPage<PromoModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 2:
                    model = GotoPreviousPage<PromoModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 3:
                    model = GotoNextPage<PromoModel>(sender, e);
                    objGrid.DataSource = model;
                    break;
                case 5:
                    model = GotoLastPage<PromoModel>(sender, e);
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
