using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class OutboundBandaraFilterPopup : BaseSearchCode<AirwaybillModel, AirwaybillDataManager>//BaseSearchPopup//
    {
        public IListParameter[] DefaultParam
        {
            set { DataManager.DefaultParameters = value; }
        }

        public OutboundBandaraFilterPopup()
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

            var clId = new GridColumn
            {
                Name = "clId",
                FieldName = "Id",
                Visible = false
            };

            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Code",
                VisibleIndex = 1,
                Width = 75
            };

            var clAirline = new GridColumn
            {
                Name = "clAirline",
                Caption = @"Airline",
                FieldName = "Airline",
                VisibleIndex = 2
            };

            var clAirportOrigin = new GridColumn
            {
                Name = "clAirportOrigin",
                Caption = @"Airport Origin",
                FieldName = "Airport",
                VisibleIndex = 3
            };

            var clAirportDest = new GridColumn
            {
                Name = "clAirportDest",
                Caption = @"Airport Dest",
                FieldName = "DestAirport",
                VisibleIndex = 4
            };

            SearchView.Columns.AddRange(new[] { clId, clDate, clCode, clAirline, clAirportOrigin, clAirportDest });
            SearchView.GridControl = GridSearch;
            Load += OutboundBandaraLoad;
        }

        private void OutboundBandaraLoad(object sender, EventArgs e)
        {
            CodeColumn = "Id";

            tbxAirline.LookupPopup = new AirlinePopup();
            tbxAirline.AutoCompleteDataManager = new AirlineDataManager();
            tbxAirline.AutoCompleteDisplayFormater = model => ((AirlineModel)model).Code + " - " + ((AirlineModel)model).Name;
            tbxAirline.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            tbxOrigin.LookupPopup = new AirportPopup();
            tbxOrigin.AutoCompleteDataManager = new AirportDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            tbxDestination.LookupPopup = new AirportPopup();
            tbxDestination.AutoCompleteDataManager = new AirportDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxDestination.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            //SearchCodeLoad(sender, e);
        }

        protected override void Filter(object sender, EventArgs e)
        {
            CodeColumn = "Code";
            base.Filter(sender, e);
            CodeColumn = "Id";
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

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

            if (tbxAirline.Value != null)
                param.Add(WhereTerm.Default((int)tbxAirline.Value, "airline_id", EnumSqlOperator.Equals));

            if (tbxOrigin.Value != null)
                param.Add(WhereTerm.Default((int)tbxOrigin.Value, "airport_id", EnumSqlOperator.Like));

            if (tbxDestination.Value != null)
                param.Add(WhereTerm.Default((int)tbxDestination.Value, "dest_airport_id", EnumSqlOperator.Like));

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
