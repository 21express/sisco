using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class DeliveryOrderFilterPopup : BaseSearchCode<DeliveryOrderModel, DeliveryOrderDataManager>
    {
        private int _branchId { get; set; }
        public DeliveryOrderFilterPopup()
        {
            InitializeComponent();
            _branchId = BaseControl.BranchId;
            Init();
        }

        public DeliveryOrderFilterPopup(int branchId)
        {
            InitializeComponent();
            _branchId = branchId;
            Init();
        }

        private void Init()
        {
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

            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Code",
                VisibleIndex = 1,
                Width = 20
            };

            var clKurir = new GridColumn
            {
                Name = "clKurir",
                Caption = @"Kurir",
                FieldName = "Kurir",
                VisibleIndex = 2
            };

            var clKendaraan = new GridColumn
            {
                Name = "clKendaraan",
                Caption = @"Kendaraan",
                FieldName = "Kendaraan",
                VisibleIndex = 3
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clKurir, clKendaraan });
            SearchView.GridControl = GridSearch;
            Load += DeliveryOrderLoad;
        }

        private void DeliveryOrderLoad(object sender, EventArgs e)
        {
            tbxKurir.LookupPopup = new MessengerPopup();
            tbxKurir.AutoCompleteDataManager = new EmployeeDataManager();
            tbxKurir.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxKurir.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0) AND branch_id = @1", s, BaseControl.BranchId);

            tbxKendaraan.LookupPopup = new FleetPopup();
            tbxKendaraan.AutoCompleteDataManager = new FleetDataManager();
            tbxKendaraan.AutoCompleteDisplayFormater = model => ((FleetModel)model).PlateNumber + " / " + ((FleetModel)model).Brand + " / " + ((FleetModel)model).Model;
            tbxKendaraan.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "plate_number", EnumSqlOperator.BeginWith),
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.BeginWith)
            };

            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            tbxFrom.Text = DateTime.Now.ToString();
            tbxTo.Text = DateTime.Now.ToString();
            // ReSharper restore SpecifyACultureInStringConversionExplicitly
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(_branchId, "branch_id"));

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxFrom.Value > dateNull)
            {
                var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (tbxTo.Value > dateNull)
            {
                var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            }

            if (tbxKendaraan.Value != null)
                param.Add(WhereTerm.Default((int)tbxKendaraan.Value, "fleet_id", EnumSqlOperator.Equals));

            if (tbxKurir.Value != null)
                param.Add(WhereTerm.Default((int)tbxKurir.Value, "messenger_id", EnumSqlOperator.Equals));

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
