using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DeliveryOrderListForm : BaseForm
    {
        public DeliveryOrderListForm()
        {
            InitializeComponent();

            form = this;
            Load += DeliveryOrderListLoad;
            btnView.Click += (sender, args) => LoadGrid();
            DoView.CustomColumnDisplayText += NumberGrid;
            GridDo.DoubleClick += (sender, args) => OpenRelatedForm(DoView, new DeliveryOrderForm());
            btnExport.Click += (sender, args) => ExportExcel(GridDo);
        }

        private void DeliveryOrderListLoad(object sender, EventArgs e)
        {
            ClearForm();

            tbxFrom.Text = DateTime.Now.ToString();
            tbxTo.Text = DateTime.Now.ToString();

            tbxCourier.LookupPopup = new MessengerPopup();
            tbxCourier.AutoCompleteDataManager = new EmployeeDataManager();
            tbxCourier.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxCourier.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0) AND branch_id = @1", s, BaseControl.BranchId);

            tbxFleet.LookupPopup = new FleetPopup();
            tbxFleet.AutoCompleteDataManager = new FleetDataManager();
            tbxFleet.AutoCompleteDisplayFormater = model => ((FleetModel)model).PlateNumber + " / " + ((FleetModel)model).Brand + " / " + ((FleetModel)model).Model;
            tbxFleet.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "plate_number", EnumSqlOperator.BeginWith),
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.BeginWith)
            };
        }

        private IListParameter[] FilterVoid()
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse

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

            if (tbxCourier.Value != null) param.Add(WhereTerm.Default((int)tbxCourier.Value, "messenger_id", EnumSqlOperator.Equals));
            if (tbxFleet.Value != null) param.Add(WhereTerm.Default((int)tbxFleet.Value, "fleet_id", EnumSqlOperator.Equals));

            IListParameter[] p = null;
            if (param.Any())
            {
                // ReSharper disable once CoVariantArrayConversion
                p = param.ToArray();
            }

            return p;
        }

        private void LoadGrid()
        {
            if (tbxTo.Value.Subtract(tbxFrom.Value).Days > 31)
            {
                MessageBox.Show(@"Tidak bisa lebih dari 31 hari");
                return;
            }

            var p = FilterVoid();

            var shipments = new DeliveryOrderDataManager().Get<DeliveryOrderModel>(p);
            GridDo.DataSource = shipments;
        }
    }
}
