using System.Collections.Generic;
using System.Linq;
using Corporate.Presentation.Common.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Corporate;
using SISCO.Models;
using Corporate.Presentation.Common;

namespace Corporate.Presentation.MasterData.Popup
{
    public partial class ConsigneeFilterPopup : BaseSearchCode<ConsigneeModel, ConsigneeDataManager>//BaseSearchPopup//
    {
        public ConsigneeFilterPopup()
        {
            InitializeComponent();

            var clName = new GridColumn
            {
                Name = "clName",
                Caption = @"Name",
                FieldName = "Name",
                VisibleIndex = 0,
                Width = 75
            };

            var clAddress = new GridColumn
            {
                Name = "clAddress",
                Caption = @"Address",
                FieldName = "Address",
                VisibleIndex = 1
            };

            var clPhone = new GridColumn
            {
                Name = "clPhone",
                Caption = @"Phone",
                FieldName = "Phone",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clName, clAddress, clPhone });
            SearchView.GridControl = GridSearch;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.CorporateId, "corporate_id", EnumSqlOperator.Equals)
            };

            label1.Visible = false;
            tbxCode.Visible = false;
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

            CodeColumn = "Id";

            if (!string.IsNullOrEmpty((tbxAddress.Text)))
                param.Add(WhereTerm.Default(tbxAddress.Text, "address", EnumSqlOperator.Like));

            if (!string.IsNullOrEmpty((tbxPhone.Text)))
                param.Add(WhereTerm.Default(tbxPhone.Text, "phone", EnumSqlOperator.Like));

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }
    }
}
