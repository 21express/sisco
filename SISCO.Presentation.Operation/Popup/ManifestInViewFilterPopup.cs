using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Charts.Native;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using Debug = System.Diagnostics.Debug;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class ManifestInViewFilterPopup : BaseSearchCode<ManifestModel, ManifestDataManager>
    {
        public IListParameter[] DefaultParam
        {
            set { DataManager.DefaultParameters = value; }
        }

        public ManifestInViewFilterPopup()
        {
            InitializeComponent();

            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Date",
                FieldName = "DateProcess",
                VisibleIndex = 0,
                Width = 20
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

            var clFrom = new GridColumn
            {
                Name = "clFrom",
                Caption = @"From",
                FieldName = "BranchName",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clFrom });
            SearchView.GridControl = GridSearch;
            Load += ManifestInViewLoad;
        }

        private void ManifestInViewLoad(object sender, EventArgs e)
        {
            tbxOrigin.LookupPopup = new BranchPopup();
            tbxOrigin.AutoCompleteDataManager = new BranchDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((BranchModel)model).Name;
            tbxOrigin.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            var now = DateTime.Now;
            tbxFrom.Text = (new DateTime(now.Year, now.Month, now.Day, 0, 0, 0)).ToString();
            tbxTo.Text = (new DateTime(now.Year, now.Month, now.Day, 23, 59, 59)).ToString();
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

            if (tbxOrigin.Value > 0)
            {
                Debug.Assert(tbxOrigin.Value != null, "tbxOrigin.Value != null");
                param.Add(WhereTerm.Default((int)tbxOrigin.Value, "branch_id", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}