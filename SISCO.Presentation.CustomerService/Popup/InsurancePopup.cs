using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Popup
{
    public partial class InsurancePopup : BaseSearchCode<ShipmentInsuranceModel, ShipmentInsuranceDataManager>//BaseSearchPopup//
    {
        public InsurancePopup()
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

            var clShipment = new GridColumn
            {
                Name = "clShipment",
                Caption = @"No. Resi",
                FieldName = "ShipmentCode",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clShipment });
            SearchView.GridControl = GridSearch;
            
            DataManager.DefaultParameters = new IListParameter[] { };
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

            if (!string.IsNullOrEmpty(tbxCode.Text))
            {
                param.Add(WhereTerm.Default(tbxCode.Text, "code", EnumSqlOperator.Equals));
            }

            if (!string.IsNullOrEmpty(tbxResi.Text))
            {
                param.Add(WhereTerm.Default(tbxResi.Text, "resi", EnumSqlOperator.Equals));
            }

            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters)
        {
            return new ShipmentInsuranceDataManager().Search<T>(paging, out count, parameters);
        }
    }
}
