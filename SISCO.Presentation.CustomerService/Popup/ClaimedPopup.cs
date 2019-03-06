using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Popup
{
    public partial class ClaimedPopup : BaseSearchCode<ClaimedModel, ClaimedDataManager>//BaseSearchPopup//
    {
        public ClaimedPopup()
        {
            InitializeComponent();

            var cl1 = new GridColumn
            {
                Name = "cl1",
                Caption = @"Tgl",
                FieldName = "DateProcess",
                VisibleIndex = 0
            };

            cl1.DisplayFormat.FormatString = "dd-MM-yyyy";
            cl1.DisplayFormat.FormatType = FormatType.DateTime;

            var cl2 = new GridColumn
            {
                Name = "cl2",
                Caption = @"No Surat",
                FieldName = "LetterNo",
                VisibleIndex = 1
            };

            var cl3 = new GridColumn
            {
                Name = "cl3",
                Caption = @"Customer",
                FieldName = "CustomerName",
                VisibleIndex = 2
            };

            var cl4 = new GridColumn
            {
                Name = "cl4",
                Caption = @"Total",
                FieldName = "Total",
                VisibleIndex = 3
            };

            cl4.DisplayFormat.FormatString = "n0";
            cl4.DisplayFormat.FormatType = FormatType.Numeric;

            var cl5 = new GridColumn
            {
                Name = "cl5",
                Caption = @"POD",
                FieldName = "ShipmentCode",
                VisibleIndex = 4
            };

            CodeColumn = "Id";

            SearchView.Columns.AddRange(new[] { cl1, cl2, cl3, cl4, cl5 });
            SearchView.GridControl = GridSearch;

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id") };

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);
        }

        protected override void BeforeFilter()
        {
        }

        protected override void Filter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxCode.Text) && string.IsNullOrEmpty(tbxFrom.Text) && string.IsNullOrEmpty(tbxTo.Text))
            {
                MessageBox.Show(@"Masukkan parameter pencarian", Resources.information, MessageBoxButtons.OK);
                tbxCode.Focus();
                return;
            }

            GridSearch.DataSource = new ClaimedDataManager().Search(BaseControl.BranchId, tbxCustomer.Text, tbxCode.Text, tbxFrom.DateTime, tbxTo.DateTime, tbxPod.Text,
                (int?)lkpBranch.Value);
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }
    }
}
