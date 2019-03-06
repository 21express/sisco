using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Charts.Native;
using DevExpress.Utils;
using DevExpress.Utils.Zip.Internal;
using DevExpress.XtraGrid.Columns;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class ManifestFilterPopup : BaseSearchCode<ManifestModel, ManifestDataManager>
    {
        public IListParameter[] DefaultParam
        {
            set { DataManager.DefaultParameters = value; }
        }

        public ManifestFilterPopup()
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

            var clBranch = new GridColumn
            {
                Name = "clBranch",
                Caption = @"Dest Branch",
                FieldName = "DestBranch",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clBranch });
            SearchView.GridControl = GridSearch;
            Load += ManifestLoad;
        }

        private void ManifestLoad(object sender, EventArgs e)
        {
            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0) AND id = @1", s, BaseControl.BranchId);

            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            tbxFrom.Text = DateTime.Now.ToString();
            tbxTo.Text = DateTime.Now.ToString();
            // ReSharper restore SpecifyACultureInStringConversionExplicitly

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

            if (tbxBranch.Value != null)
                param.Add(WhereTerm.Default((int)tbxBranch.Value, "dest_branch_id", EnumSqlOperator.Equals));

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
