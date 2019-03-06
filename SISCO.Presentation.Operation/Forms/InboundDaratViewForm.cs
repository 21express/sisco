using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class InboundDaratViewForm : BaseForm
    {
        public InboundDaratViewForm()
        {
            InitializeComponent();

            form = this;
            Load += InboundDaratViewLoad;
            btnView.Click += (sender, args) => LoadGrid();
            WaybillView.CustomColumnDisplayText += NumberGrid;

            Shown += (sender, args) =>
            {
                var now = DateTime.Now;
                tbxFrom.Text = new DateTime(now.Year, now.Month, 1).ToString();
                tbxTo.Text = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).ToString();
                
                LoadGrid();
            };

            cbxCategory.SelectedValueChanged += (sender, args) => btnView.Focus();
            WaybillView.RowCellStyle += ChangeColor;
            WaybillView.DoubleClick += (sender, args) => OpenRelatedForm(WaybillView, new InboundDaratForm());
            btnExport.Click += (sender, args) => ExportExcel(GridWaybill);
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view != null && (bool)view.GetRowCellValue(e.RowHandle, view.Columns["Arrived"])) e.Appearance.ForeColor = Color.Black;
                else e.Appearance.ForeColor = Color.Red;
            }
        }

        private void LoadGrid()
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals));

            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            var fuck1 = tbxFrom.Value;
            if (fuck1 > dateNull)
            {
                var fdate = new DateTime(fuck1.Year, fuck1.Month, fuck1.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
            }

            var fuck2 = tbxTo.Value;
            if (fuck2 > dateNull)
            {
                var ldate = new DateTime(fuck2.Year, fuck2.Month, fuck2.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            }

            if (tbxCarrier.Text != "")
            {
                param.Add(WhereTerm.Default(tbxCarrier.Text, "est_carrier", EnumSqlOperator.Like));
            }

            if (tbxOrigin.Value != null)
            {
                param.Add(WhereTerm.Default((int) tbxOrigin.Value, "branch_id", EnumSqlOperator.Equals));
            }

            if (cbxCategory.SelectedValue.ToString() != "")
            {
                param.Add(WhereTerm.Default(cbxCategory.SelectedValue.ToString(), "act_category", EnumSqlOperator.Equals));
            }

            IListParameter[] p = null;
            if (param.Any())
            {
                // ReSharper disable once CoVariantArrayConversion
                p = param.ToArray();
            }

            var waybill = new WaybillDataManager().Get<WaybillModel>(p);
            GridWaybill.DataSource = waybill;
            WaybillView.RefreshData();
        }

        private void InboundDaratViewLoad(object sender, EventArgs e)
        {
            tbxOrigin.LookupPopup = new BranchPopup();
            tbxOrigin.AutoCompleteDataManager = new BranchDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            cbxCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxCategory.DataSource = new List<Combo> { new Combo { Text = "" }, new Combo { Text = "Kereta" }, new Combo { Text = "Mobil" } };
            cbxCategory.DisplayMember = "Text";
            cbxCategory.ValueMember = "Text";
        }
    }
}
