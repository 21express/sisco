using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class HeavyDifferenceAirwaybillFilterPopup : BaseSearchCode<AirwaybillDifferenceWeightModel, AirwaybillDifferenceWeightDataManager>//BaseSearchPopup//
    {
        public HeavyDifferenceAirwaybillFilterPopup()
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

            clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            clDate.DisplayFormat.FormatType = FormatType.DateTime;

            var clConsol = new GridColumn
            {
                Name = "clConsol",
                Caption = @"Consolidation",
                FieldName = "ConsolidatindCode",
                VisibleIndex = 1
            };

            var clShipment = new GridColumn
            {
                Name = "clShipment",
                Caption = @"No. POD",
                FieldName = "ShipmentCode",
                VisibleIndex = 1
            };

            SearchView.Columns.AddRange(new[] { clDate, clConsol, clShipment });
            SearchView.GridControl = GridSearch;

            CodeColumn = "Id";
        }

        protected override void BeforeFilter() {}

        protected override void Filter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxCode.Text) && string.IsNullOrEmpty(tbxShipment.Text))
            {
                MessageBox.Show(@"Masukkan parameter pencarian", Resources.information, MessageBoxButtons.OK);
                tbxCode.Focus();
                return;
            }

            GridSearch.DataSource = new AirwaybillDifferenceWeightDataManager().Search(BaseControl.BranchId, tbxCode.Text, tbxShipment.Text);
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }
    }
}