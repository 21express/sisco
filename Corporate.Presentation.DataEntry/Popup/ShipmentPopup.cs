using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.MasterData.Popup;
using SISCO.App.MasterData;
using SISCO.Models;
using Corporate.Presentation.Common;

namespace Corporate.Presentation.DataEntry.Popup
{
    public partial class ShipmentPopup : BaseSearchCode<ShipmentModel, ShipmentDataManager>//BaseSearchPopup//
    {
        public ShipmentPopup()
        {
            InitializeComponent();

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
                Width = 75
            };

            var clOrigin = new GridColumn
            {
                Name = "clOrigin",
                Caption = @"Origin",
                FieldName = "CityName",
                VisibleIndex = 2
            };

            var clDestination = new GridColumn
            {
                Name = "clDestination",
                Caption = @"Destination",
                FieldName = "DestCity",
                VisibleIndex = 3
            };

            var clCustomer = new GridColumn
            {
                Name = "clCustomer",
                Caption = @"Customer",
                FieldName = "CustomerName",
                VisibleIndex = 3
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clOrigin, clDestination, clCustomer });
            SearchView.GridControl = GridSearch;
            Load += OnLoad;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        private void OnLoad(object sender, EventArgs e)
        {
            tbxDestination.LookupPopup = new ConsigneePopup();
            tbxDestination.AutoCompleteDataManager = new CityDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            tbxDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
            param.Add(WhereTerm.Default(BaseControl.CorporateId, "customer_id", EnumSqlOperator.Equals));
            param.Add(WhereTerm.Default(BaseControl.CityId, "city_id", EnumSqlOperator.Equals));

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

            if (tbxDestination.Value != null)
                param.Add(WhereTerm.Default((int)tbxDestination.Value, "dest_city_id", EnumSqlOperator.Equals));

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}