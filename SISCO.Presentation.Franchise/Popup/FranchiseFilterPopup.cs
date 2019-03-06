using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Franchise;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.App.MasterData;

namespace SISCO.Presentation.Franchise.Popup
{
    public partial class FranchiseFilterPopup : BaseSearchCode<FranchiseModel, FranchiseDataManager>//BaseSearchPopup//
    {
        public IListParameter[] DefaultParam
        {
            set { DataManager.DefaultParameters = value; }
        }

        public FranchiseFilterPopup()
        {
            InitializeComponent();

            var clName = new GridColumn
            {
                Name = "clName",
                Caption = @"Name",
                FieldName = "Name",
                VisibleIndex = 0,
                Width = 60
            };

            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Code",
                VisibleIndex = 1,
                Width = 75
            };

            SearchView.Columns.AddRange(new[] { clName, clCode });
            SearchView.GridControl = GridSearch;
            SortColumn = "name";
            Load += FranchiseLoad;
        }

        private void FranchiseLoad(object sender, EventArgs e)
        {
            lkpCity.LookupPopup = new CityPopup();
            lkpCity.AutoCompleteDataManager = new CityDataManager();
            lkpCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

            if (tbxName.Text != "")
            {
                param.Add(WhereTerm.Default(tbxName.Text, "name", EnumSqlOperator.Like));
            }

            if (lkpCity.Value != null)
            {
                param.Add(WhereTerm.Default((int)lkpCity.Value, "city_id", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
