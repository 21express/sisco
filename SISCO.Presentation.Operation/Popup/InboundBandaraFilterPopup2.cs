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
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class InboundBandaraFilterPopup : BaseSearchCode<AirwaybillModel, AirwaybillDataManager>
    {
        public IListParameter[] DefaultParam
        {
            set { DataManager.DefaultParameters = value; }
        }

        public InboundBandaraFilterPopup()
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

            var clAirline = new GridColumn
            {
                Name = "clAirline",
                Caption = @"Airline",
                FieldName = "AirlineId",
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

            SearchView.Columns.AddRange(new[] { clDate, clCode, clAirline, clAirportOrigin, clAirportDest });
            SearchView.GridControl = GridSearch;
            Load += InboundBandaraLoad;
        }

        private void InboundBandaraLoad(object sender, EventArgs e)
        {
            tbxAirline.LookupPopup = new AirlinePopup();
            tbxAirline.AutoCompleteDataManager = new AirlineDataManager();
            tbxAirline.AutoCompleteDisplayFormater = model => ((AirlineModel)model).Name;
            tbxAirline.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            //SearchCodeLoad(sender, e);
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

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
