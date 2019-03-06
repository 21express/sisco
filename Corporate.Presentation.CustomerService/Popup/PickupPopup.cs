﻿using System;
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
using Franchise.Presentation.Common;
using SISCO.App.Corporate;
using Corporate.Presentation.Common;

namespace Corporate.Presentation.CustomerService.Popup
{
    public partial class PickupPopup : BaseSearchCode<CorporatePickupModel, CorporatePickupDataManager>//BaseSearchPopup//
    {
        public PickupPopup()
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

            SearchView.Columns.AddRange(new[] { clDate, clCode });
            SearchView.GridControl = GridSearch;
            Load += OnLoad;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.CorporateId, "corporate_id", EnumSqlOperator.Equals) };
        }

        private void OnLoad(object sender, EventArgs e)
        {
            
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(BaseControl.CorporateId, "corporate_id", EnumSqlOperator.Equals));

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