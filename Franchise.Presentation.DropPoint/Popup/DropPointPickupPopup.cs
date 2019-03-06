using Devenlab.Common;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Forms;
using SISCO.App.Franchise;
using SISCO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Franchise.Presentation.DropPoint.Popup
{
    public partial class DropPointPickupPopup : BaseSearchCode<FranchiseDropPointDetailSearch, FranchiseDropPointDetailDataManager>//BaseSearchPopup//
    {
        public DropPointPickupPopup()
        {
            InitializeComponent();

            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Date",
                FieldName = "PickupDate",
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

            var clDp = new GridColumn
            {
                Name = "clDp",
                Caption = @"Drop Point",
                FieldName = "DropPointName",
                VisibleIndex = 2
            };

            var clShipmentCode = new GridColumn
            {
                Name = "clShipmentCode",
                Caption = @"POD",
                FieldName = "ShipmentCode",
                VisibleIndex = 3
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clDp, clShipmentCode });
            SearchView.GridControl = GridSearch;

            tbxFrom.DateTime = DateTime.Now;
            tbxTo.DateTime = DateTime.Now;
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(BaseControl.BranchId, "BranchId", EnumSqlOperator.Equals));
            param.Add(WhereTerm.Default(BaseControl.FranchiseId, "FranchiseId", EnumSqlOperator.Equals));

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxFrom.Value > dateNull)
            {
                var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "PickupDate", EnumSqlOperator.GreatThanEqual));
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (tbxTo.Value > dateNull)
            {
                var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "PickupDate", EnumSqlOperator.LesThanEqual));
            }

            if (!string.IsNullOrEmpty(tbxPod.Text))
            {
                param.Add(WhereTerm.Default(tbxPod.Text, "ShipmentCode", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}