using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Office.Utils;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Administration.Popup
{
    public partial class ShipmentNumberAllocationPopup :
        BaseSearchCode<ShipmentAllocationModel, ShipmentNumberAllocationDataManager> //BaseSearchPopup//
    {
        public ShipmentNumberAllocationPopup()
        {
            InitializeComponent();


            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Id",
                VisibleIndex = 0,
                Width = 75
            };

            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Date",
                FieldName = "AllocDate",
                VisibleIndex = 1,
                Width = 60
            };

            clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            clDate.DisplayFormat.FormatType = FormatType.DateTime;

            var clCustomer = new GridColumn
            {
                Name = "clCustomer",
                Caption = @"Customer",
                FieldName = "CustomerName",
                VisibleIndex = 2
            };

            var clStart = new GridColumn
            {
                Name = "clStart",
                Caption = @"Start",
                FieldName = "ShipmentCodeStart",
                VisibleIndex = 3
            };

            var clEnd = new GridColumn
            {
                Name = "clEnd",
                Caption = @"End",
                FieldName = "ShipmentCodeEnd",
                VisibleIndex = 4
            };

            var clCount = new GridColumn
            {
                Name = "clCount",
                Caption = @"Count",
                FieldName = "ShipmentCodeCount",
                VisibleIndex = 5
            };

            CodeColumn = "Id";
            SortColumn = "alloc_date";
            SortDirection = "DESC";

            SearchView.Columns.AddRange(new[] {clCode, clDate, clCustomer, clDate, clStart, clEnd, clCount});
            SearchView.GridControl = GridSearch;
            Load += OnLoad;
            DataManager.DefaultParameters = new IListParameter[]
            {WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)};
        }

        private void OnLoad(object sender, EventArgs e)
        {
            lkpFilterCustomer.LookupPopup = new CustomerPopup();
            lkpFilterCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpFilterCustomer.AutoCompleteDisplayFormater =
                model => ((CustomerModel) model).Code + " - " + ((CustomerModel) model).Name;
            lkpFilterCustomer.AutoCompleteWhereExpression =
                (s, p) =>
                    p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s,
                        BaseControl.BranchId);

            txtFilterShipmentNo.EditMask = "############";
        }

        protected override void BeforeFilter()
        {
            var p = new List<IListParameter>();

            p.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            if (txtFilterDate.DateTime != DateTime.MinValue)
                p.Add(WhereTerm.Default(txtFilterDate.DateTime, "alloc_date"));
            if (txtFilterShipmentNo.Text != "")
            {
                p.Add(WhereTerm.Default(Convert.ToInt64(txtFilterShipmentNo.Text), "shipment_code_start",
                    EnumSqlOperator.LesThanEqual));
                p.Add(WhereTerm.Default(Convert.ToInt64(txtFilterShipmentNo.Text), "shipment_code_end",
                    EnumSqlOperator.GreatThanEqual));
            }

            if (lkpFilterCustomer.Value != null) p.Add(WhereTerm.Default((int) lkpFilterCustomer.Value, "customer_id"));

            // ReSharper disable once CoVariantArrayConversion
            if (p.Any()) AutoCompleteWheretermFormater = p.ToArray();
        }

        public new void SelectRow(object sender, EventArgs e)
        {
            var rows = SearchView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(SearchView.GetRowCellValue(rows[0], "Id"));
                SelectedText = SearchView.GetRowCellValue(rows[0], "Id").ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.information);
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count,
            IListParameter[] parameters)
        {
            var p = parameters.Where(row => row.ColumnName != CodeColumn).ToList();

            if (!string.IsNullOrEmpty(tbxCode.Text))
            {
                int code;
                if (!int.TryParse(tbxCode.Text, out code))
                {
                    MessageBox.Show(@"Filter kode harus dalam bentuk angka");
                    count = 0;

                    return new List<T>().AsEnumerable();
                }

                p.Add(WhereTerm.Default(code, "id"));
            }

            return base.GetFromDataManager<T>(paging, out count, p.ToArray());
        }
    }
}
